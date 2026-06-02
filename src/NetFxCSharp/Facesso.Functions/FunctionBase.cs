using ActiveDev;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public interface IFacessoFunction
    {
        IVersionPermissionInfo VersionPermission { get; }

        IRolePermissionInfo RolePermission { get; }

        string VersionPermissionViolationMessage { get; }

        string RolePermissionViolationMessage { get; }
    }

    public sealed class FunctionHandler<FacessoFunction>
        where FacessoFunction : IFacessoFunction, new()
    {
        public static FacessoFunction GetFunctionInstance()
        {
            FacessoFunction locFacessoFunction = new FacessoFunction();
            if (!(FacessoGeneric.PermitFunctionForRole(locFacessoFunction.RolePermission)))
            {
                MessageBox.Show(locFacessoFunction.RolePermissionViolationMessage, "Fehlende Rechte:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return default(FacessoFunction);
            }

            if (!(FacessoGeneric.PermitFunctionForVersion(locFacessoFunction.VersionPermission)))
            {
                MessageBox.Show(locFacessoFunction.VersionPermissionViolationMessage, "In dieser Programversion nicht verfügbar:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return default(FacessoFunction);
            }

            //Todo: Log in Database
            return locFacessoFunction;
        }
    }

    public class FacessoFunctionBase : IFacessoFunction
    {
        internal FacessoFunctionBase()
        {
        }

        public virtual IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.None);
            }
        }

        public virtual IVersionPermissionInfo VersionPermission
        {
            get
            {
                return new FacessoVersionPermissionInfo(FacessoVersion.FacessoStandard);
            }
        }

        public virtual string RolePermissionViolationMessage
        {
            get
            {
                return "Sie haben nicht die erforderlichen Rechte, diese Funktion verwenden zu können!";
            }
        }

        public virtual string VersionPermissionViolationMessage
        {
            get
            {
                return "In dieser Ausbaustufe von Facesso dürfen Sie diese Funktion nicht verwenden";
            }
        }
    }
}