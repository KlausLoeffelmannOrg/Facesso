using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace Facesso.Tests.Reflective
{
    /// <summary>
    /// Loads the Faccesso assembly via reflection, enumerates all types and members,
    /// and compares the result against a baseline text file.
    /// If no baseline exists yet, it creates one for future comparison.
    /// </summary>
    public class AssemblyContentTests
    {
        private static readonly string BaselineFolder = GetBaselineDirectory();
        private static readonly string BaselineFileName = "Facesso_AssemblyContent.txt";

        private static string GetBaselineDirectory([CallerFilePath] string callerFilePath = "") 
            => Path.Combine(
                Path.GetDirectoryName(callerFilePath)!,
                "Baselines");

        [Fact]
        public void Facesso_AssemblyContent_MatchesBaseline()
        {
            // Load the Facesso Application assembly through a well-known type it contains.
            var assembly = typeof(frmFacessoShell).Assembly;
            var currentContent = BuildAssemblyContentTable(assembly);

            Directory.CreateDirectory(BaselineFolder);
            var baselinePath = Path.Combine(BaselineFolder, BaselineFileName);

            if (!File.Exists(baselinePath))
            {
                File.WriteAllText(baselinePath, currentContent, Encoding.UTF8);
                Assert.Fail(
                    $"No baseline file existed. A new baseline has been written to:\n{baselinePath}\n" +
                    "Re-run the test to verify against this baseline.");
            }

            var baselineContent = File.ReadAllText(baselinePath, Encoding.UTF8);

            Assert.Equal(baselineContent, currentContent);
        }

        /// <summary>
        /// Builds a deterministic textual "memory table" of all types and their members
        /// contained in the given assembly.
        /// </summary>
        private static string BuildAssemblyContentTable(Assembly assembly)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# Assembly Content: {assembly.GetName().Name}");
            sb.AppendLine($"# Generated: deterministic (date omitted)");
            sb.AppendLine();

            var types = assembly.GetTypes()
                .Where(t => !t.FullName.StartsWith("<") && !t.Name.StartsWith("<"))
                .OrderBy(t => t.FullName, StringComparer.Ordinal)
                .ToList();

            foreach (var type in types)
            {
                var category = CategorizeType(type);
                sb.AppendLine($"[{category}] {type.FullName}");

                // For Enum, list the enum values
                if (type.IsEnum)
                {
                    foreach (var name in Enum.GetNames(type).OrderBy(n => n, StringComparer.Ordinal))
                    {
                        sb.AppendLine($"  [EnumValue] {name}");
                    }
                    sb.AppendLine();
                    continue;
                }

                // For Delegates, list the Invoke signature only
                if (typeof(Delegate).IsAssignableFrom(type) && type != typeof(Delegate) && type != typeof(MulticastDelegate))
                {
                    var invoke = type.GetMethod("Invoke");
                    if (invoke != null)
                    {
                        sb.AppendLine($"  [Invoke] {FormatMethod(invoke)}");
                    }
                    sb.AppendLine();
                    continue;
                }

                // For Classes, Structs, Modules, Interfaces: list all declared members
                var members = type.GetMembers(
                        BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Instance | BindingFlags.Static |
                        BindingFlags.DeclaredOnly)
                    .Where(m => !IsCompilerGenerated(m))
                    .OrderBy(m => m.MemberType.ToString(), StringComparer.Ordinal)
                    .ThenBy(m => m.Name, StringComparer.Ordinal)
                    .ToList();

                foreach (var member in members)
                {
                    var accessibility = GetAccessibility(member);
                    var memberKind = GetMemberKind(member);
                    var detail = GetMemberDetail(member);

                    sb.AppendLine($"  [{memberKind}] [{accessibility}] {member.Name}{detail}");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static string CategorizeType(Type type)
        {
            if (type.IsEnum)
                return "Enum";
            if (typeof(Delegate).IsAssignableFrom(type) && type != typeof(Delegate) && type != typeof(MulticastDelegate))
                return "Delegate";
            if (type.IsValueType && !type.IsEnum)
                return "Struct";
            if (type.IsInterface)
                return "Interface";
            if (type.GetCustomAttributes(false)
                    .Any(a => a.GetType().FullName == "Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute"))
                return "Module";
            if (type.IsClass)
                return "Class";
            return "Other";
        }

        private static string GetAccessibility(MemberInfo member)
        {
            switch (member)
            {
                case FieldInfo fi:
                    if (fi.IsPublic) return "Public";
                    if (fi.IsFamily) return "Protected";
                    if (fi.IsFamilyOrAssembly) return "Protected Internal";
                    if (fi.IsAssembly) return "Internal";
                    if (fi.IsFamilyAndAssembly) return "Private Protected";
                    return "Private";

                case MethodBase mb:
                    if (mb.IsPublic) return "Public";
                    if (mb.IsFamily) return "Protected";
                    if (mb.IsFamilyOrAssembly) return "Protected Internal";
                    if (mb.IsAssembly) return "Internal";
                    if (mb.IsFamilyAndAssembly) return "Private Protected";
                    return "Private";

                case PropertyInfo pi:
                    var getter = pi.GetGetMethod(true);
                    var setter = pi.GetSetMethod(true);
                    var accessor = getter ?? setter;
                    if (accessor == null) return "Private";
                    return GetAccessibility(accessor);

                case EventInfo ei:
                    var addMethod = ei.GetAddMethod(true);
                    if (addMethod == null) return "Private";
                    return GetAccessibility(addMethod);

                case Type t:
                    if (t.IsPublic || t.IsNestedPublic) return "Public";
                    if (t.IsNestedFamily) return "Protected";
                    if (t.IsNestedFamORAssem) return "Protected Internal";
                    if (t.IsNestedAssembly) return "Internal";
                    return "Private";

                default:
                    return "Unknown";
            }
        }

        private static string GetMemberKind(MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Constructor: return "Constructor";
                case MemberTypes.Event: return "Event";
                case MemberTypes.Field: return "Field";
                case MemberTypes.Method: return "Method";
                case MemberTypes.Property: return "Property";
                case MemberTypes.NestedType: return "NestedType";
                default: return member.MemberType.ToString();
            }
        }

        private static string GetMemberDetail(MemberInfo member)
        {
            switch (member)
            {
                case MethodInfo mi:
                    return FormatMethod(mi);
                case ConstructorInfo ci:
                    return $"({FormatParameters(ci.GetParameters())})";
                case PropertyInfo pi:
                    var indexParams = pi.GetIndexParameters();
                    var suffix = indexParams.Length > 0
                        ? $"({FormatParameters(indexParams)})"
                        : "";
                    return $"{suffix} : {FormatTypeName(pi.PropertyType)}";
                case FieldInfo fi:
                    return $" : {FormatTypeName(fi.FieldType)}";
                case EventInfo ei:
                    return ei.EventHandlerType != null
                        ? $" : {FormatTypeName(ei.EventHandlerType)}"
                        : "";
                default:
                    return "";
            }
        }

        private static string FormatMethod(MethodInfo mi)
        {
            var parameters = FormatParameters(mi.GetParameters());
            return $"({parameters}) : {FormatTypeName(mi.ReturnType)}";
        }

        private static string FormatParameters(ParameterInfo[] parameters)
        {
            return string.Join(", ", parameters.Select(p => $"{FormatTypeName(p.ParameterType)} {p.Name}"));
        }

        private static string FormatTypeName(Type type)
        {
            if (type == typeof(void)) return "Void";
            if (type.IsGenericType)
            {
                var genericDef = type.GetGenericTypeDefinition().Name;
                var baseName = genericDef.Substring(0, genericDef.IndexOf('`'));
                var args = string.Join(", ", type.GetGenericArguments().Select(FormatTypeName));
                return $"{baseName}<{args}>";
            }
            return type.Name;
        }

        private static bool IsCompilerGenerated(MemberInfo member)
        {
            // Filter out compiler-generated backing fields and methods
            if (member.GetCustomAttributes(false)
                    .Any(a => a.GetType().FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute"))
                return true;

            // Filter out property backing fields (VB generates these with $ prefix)
            if (member is FieldInfo fi && fi.Name.Contains("$"))
                return true;

            return false;
        }
    }
}
