using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;

namespace ActiveDev
{
    public class ADFunction : IComparable
    {
        public delegate double ADFunctionDelegate(double[] parArray);

        protected string myFunctionname;
        protected int myParameters;
        protected ADFunctionDelegate myFunctionProc;
        protected ArrayList myConsts;
        protected bool myIsOperator;
        protected byte myPriority;

        public ADFunction(char functionname, ADFunctionDelegate functionProc, byte priority)
        {
            if (priority < 1)
            {
                throw new ArgumentException("Priority kann fuer Operatoren nicht kleiner 1 sein.");
            }

            myFunctionname = functionname.ToString();
            myParameters = 2;
            myFunctionProc = functionProc;
            myIsOperator = true;
            myPriority = priority;
        }

        public ADFunction(string functionName, ADFunctionDelegate functionProc, int parameters)
        {
            myFunctionname = functionName;
            myFunctionProc = functionProc;
            myParameters = parameters;
            myIsOperator = false;
            myPriority = 0;
        }

        public string FunctionName
        {
            get { return myFunctionname; }
        }

        public int Parameters
        {
            get { return myParameters; }
        }

        public bool IsOperator
        {
            get { return myIsOperator; }
        }

        public byte Priority
        {
            get { return myPriority; }
        }

        public ADFunctionDelegate FunctionProc
        {
            get { return myFunctionProc; }
        }

        public double Operate(double[] parArray)
        {
            if (Parameters > -1 && parArray.Length != Parameters)
            {
                throw new ArgumentException("Anzahl Parameter entspricht nicht der Vorschrift der Funktion " + FunctionName);
            }

            return myFunctionProc(parArray);
        }

        public int CompareTo(object obj)
        {
            if (obj != null && obj.GetType().FullName == "ActiveDev.ADFunction")
            {
                return myPriority.CompareTo(((ADFunction)obj).Priority) * -1;
            }

            throw new ArgumentException("Nur ActiveDev.Function-Objekte koennen verglichen/sortiert werden");
        }
    }

    public class ADFormularParser
    {
        protected string myFormular;
        protected ArrayList myFunctions;
        protected ArrayList myOperators;
        protected static ArrayList myPredefinedFunctions;
        protected double myResult;
        protected bool myIsCalculated;
        protected ArrayList myConsts;
        private int myConstEnumCounter;

        protected static double myXVariable;
        protected static double myYVariable;
        protected static double myZVariable;

        static ADFormularParser()
        {
            myPredefinedFunctions = new ArrayList
            {
                new ADFunction('+', Addition, 1),
                new ADFunction('-', Substraction, 1),
                new ADFunction('*', Multiplication, 2),
                new ADFunction('/', Division, 2),
                new ADFunction('\\', Remainder, 2),
                new ADFunction('^', Power, 3),
                new ADFunction("PI", PI, 1),
                new ADFunction("Sin", Sin, 1),
                new ADFunction("Cos", Cos, 1),
                new ADFunction("Tan", Tan, 1),
                new ADFunction("Max", Max, -1),
                new ADFunction("Min", Min, -1),
                new ADFunction("Sqrt", Sqrt, 1),
                new ADFunction("Tanh", Tanh, 1),
                new ADFunction("LogDec", LogDec, 1),
                new ADFunction("XVar", XVar, 1),
                new ADFunction("YVar", YVar, 1),
                new ADFunction("ZVar", ZVar, 1)
            };
        }

        public ADFormularParser(string formular)
        {
            myFunctions = (ArrayList)myPredefinedFunctions.Clone();
            myFormular = formular;
            OnAddFunctions();
        }

        public virtual void OnAddFunctions()
        {
        }

        private void Calculate()
        {
            var locFormular = myFormular;
            var locOpStr = string.Empty;

            myOperators = new ArrayList();
            foreach (ADFunction adf in myFunctions)
            {
                if (adf.IsOperator)
                {
                    myOperators.Add(adf);
                }
            }

            myOperators.Sort();

            foreach (ADFunction ops in myFunctions)
            {
                if (ops.IsOperator)
                {
                    locOpStr += "\\" + ops.FunctionName;
                }
            }

            locFormular = PrepareFormular(locFormular, locOpStr);
            locFormular = GetConsts(locFormular);

            myResult = ParseSimpleTerm(Parse(locFormular, locOpStr));
            IsCalculated = true;
        }

        protected virtual string Parse(string formular, string operatorRegEx)
        {
            string locTemp;
            Match locTerm;
            Match locFuncName;
            MatchCollection locMoreInnerTerms;
            var locPreliminaryResult = new ArrayList();
            var locOperatorRegEx = "\\([\\d\\;" + operatorRegEx + "]*\\)";

            ADFunction adf = null;

            locTerm = Regex.Match(formular, locOperatorRegEx);
            if (locTerm.Value == string.Empty)
            {
                return formular;
            }

            locTemp = formular.Substring(0, locTerm.Index);
            locFuncName = Regex.Match(locTemp, "[a-zA-Z]*", RegexOptions.RightToLeft);
            locMoreInnerTerms = Regex.Matches(locTerm.Value, "[\\d" + operatorRegEx + "]*[;|\\)]");

            foreach (Match locMatch in locMoreInnerTerms)
            {
                locTemp = locMatch.Value;
                locTemp = locTemp.Replace(";", string.Empty).Replace(")", string.Empty);
                locPreliminaryResult.Add(ParseSimpleTerm(locTemp));
            }

            if (locFuncName.Value == string.Empty && locMoreInnerTerms.Count > 1)
            {
                throw new SyntaxErrorException("Mehrere Klammerparameter aber kein Funktionsname angegeben!");
            }

            if (locFuncName.Value != string.Empty)
            {
                var locFuncFound = false;

                foreach (ADFunction function in myFunctions)
                {
                    if (function.FunctionName.ToUpper() == locFuncName.Value.ToUpper())
                    {
                        locFuncFound = true;
                        adf = function;
                        break;
                    }
                }

                if (!locFuncFound)
                {
                    throw new SyntaxErrorException("Der Funktionsname wurde nicht gefunden");
                }

                formular = formular.Replace(locFuncName.Value + locTerm.Value, myConstEnumCounter.ToString("000"));
                var locArgs = new double[locPreliminaryResult.Count];
                locPreliminaryResult.CopyTo(locArgs);
                myConsts.Add(adf.Operate(locArgs));
                myConstEnumCounter += 1;
            }
            else
            {
                formular = formular.Replace(locTerm.Value, myConstEnumCounter.ToString("000"));
                myConsts.Add(Convert.ToDouble(locPreliminaryResult[0]));
                myConstEnumCounter += 1;
            }

            return Parse(formular, operatorRegEx);
        }

        protected virtual double ParseSimpleTerm(string formular)
        {
            if (formular.IndexOfAny(new[] { '(', ')' }) > -1)
            {
                formular = formular.Remove(0, 1);
                formular = formular.Remove(formular.Length - 1, 1);
            }

            foreach (ADFunction adf in myOperators)
            {
                while (true)
                {
                    if (formular.Length == 3)
                    {
                        return Convert.ToDouble(myConsts[int.Parse(formular)]);
                    }

                    var locPos = formular.IndexOf(adf.FunctionName.ToCharArray()[0]);
                    if (locPos == -1)
                    {
                        break;
                    }

                    var locDblArr = new double[2];
                    locDblArr[0] = Convert.ToDouble(myConsts[int.Parse(formular.Substring(locPos - 3, 3))]);
                    locDblArr[1] = Convert.ToDouble(myConsts[int.Parse(formular.Substring(locPos + 1, 3))]);

                    var locResult = adf.Operate(locDblArr);
                    myConsts.Add(locResult);
                    formular = formular.Remove(locPos - 3, 7);
                    formular = formular.Insert(locPos - 3, myConstEnumCounter.ToString("000"));
                    myConstEnumCounter += 1;
                }
            }

            return 0;
        }

        protected virtual string GetConsts(string formular)
        {
            var locRegEx = new Regex("[\\d,.]+[S]*");
            myConstEnumCounter = 0;
            myConsts = new ArrayList();
            return locRegEx.Replace(formular, EnumConstsProc);
        }

        protected virtual string EnumConstsProc(Match m)
        {
            try
            {
                myConsts.Add(double.Parse(m.Value));
                var locString = myConstEnumCounter.ToString("000");
                myConstEnumCounter += 1;
                return locString;
            }
            catch (Exception)
            {
                myConsts.Add(double.NaN);
                return "ERR";
            }
        }

        protected virtual string PrepareFormular(string formular, string operatorRegEx)
        {
            var locBracketCounter = 0;

            foreach (var locChar in formular.ToCharArray())
            {
                if (locChar == '(')
                {
                    locBracketCounter += 1;
                }

                if (locChar == ')')
                {
                    locBracketCounter -= 1;
                    if (locBracketCounter < 0)
                    {
                        throw new SyntaxErrorException("Zu viele Klammer-Zu-Zeichen.");
                    }
                }
            }

            if (locBracketCounter > 0)
            {
                throw new SyntaxErrorException("Eine offene Klammer wurde nicht ordnungsgemaess geschlossen.");
            }

            formular = Regex.Replace(formular, "\\s", string.Empty);

            if (formular.StartsWith("-") || formular.StartsWith("+"))
            {
                formular = formular.Insert(0, "0");
            }

            return Regex.Replace(
                formular,
                "(?<operator>[" + operatorRegEx + "])-(?<zahl>[\\d\\.,]*)",
                "${operator}((0-1)*${zahl})");
        }

        public string Formular
        {
            get { return myFormular; }
            set
            {
                IsCalculated = false;
                myFormular = value;
            }
        }

        public double Result
        {
            get
            {
                if (!IsCalculated)
                {
                    Calculate();
                }

                return myResult;
            }
        }

        public bool IsCalculated
        {
            get { return myIsCalculated; }
            set { myIsCalculated = value; }
        }

        public ArrayList Functions
        {
            get { return myFunctions; }
            set { myFunctions = value; }
        }

        public static double Addition(double[] args)
        {
            return args[0] + args[1];
        }

        public static double Substraction(double[] args)
        {
            return args[0] - args[1];
        }

        public static double Multiplication(double[] args)
        {
            return args[0] * args[1];
        }

        public static double Division(double[] args)
        {
            return args[0] / args[1];
        }

        public static double Remainder(double[] args)
        {
            return (double)decimal.Remainder(new decimal(args[0]), new decimal(args[1]));
        }

        public static double Power(double[] args)
        {
            return Math.Pow(args[0], args[1]);
        }

        public static double Sin(double[] args)
        {
            return Math.Sin(args[0]);
        }

        public static double Cos(double[] args)
        {
            return Math.Cos(args[0]);
        }

        public static double Tan(double[] args)
        {
            return Math.Tan(args[0]);
        }

        public static double Sqrt(double[] args)
        {
            return Math.Sqrt(args[0]);
        }

        public static double PI(double[] args)
        {
            return Math.PI;
        }

        public static double Tanh(double[] args)
        {
            return Math.Tanh(args[0]);
        }

        public static double LogDec(double[] args)
        {
            return Math.Log10(args[0]);
        }

        public static double XVar(double[] args)
        {
            return XVariable;
        }

        public static double YVar(double[] args)
        {
            return YVariable;
        }

        public static double ZVar(double[] args)
        {
            return ZVariable;
        }

        public static double Max(double[] args)
        {
            if (args.Length == 0)
            {
                return 0;
            }

            var retDouble = args[0];
            foreach (var locDouble in args)
            {
                if (retDouble < locDouble)
                {
                    retDouble = locDouble;
                }
            }

            return retDouble;
        }

        public static double Min(double[] args)
        {
            if (args.Length == 0)
            {
                return 0;
            }

            var retDouble = args[0];
            foreach (var locDouble in args)
            {
                if (retDouble > locDouble)
                {
                    retDouble = locDouble;
                }
            }

            return retDouble;
        }

        public static double XVariable
        {
            get { return myXVariable; }
            set { myXVariable = value; }
        }

        public static double YVariable
        {
            get { return myYVariable; }
            set { myYVariable = value; }
        }

        public static double ZVariable
        {
            get { return myZVariable; }
            set { myZVariable = value; }
        }
    }
}
