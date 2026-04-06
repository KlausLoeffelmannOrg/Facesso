using System.Windows.Forms;

namespace Facesso
{
    public interface IVersionPermissionInfo { }

    public interface IRolePermissionInfo { }

    public enum ClearanceLevel : long
    {
        None = 0,
        ViewReportsOnProductionData = 1,
        ViewReportsOnIndividuals = 2,
        ViewSystemData = 4,
        PrintReportsOnProductionData = 8 | ViewReportsOnProductionData,
        PrintReportsOnIndividuals = 16 | ViewReportsOnIndividuals,
        PrintSystemData = 32 | ViewSystemData,
        EnterNewProductionData = 64 | PrintReportsOnProductionData,
        EnterNewIndividualsData = 128 | PrintReportsOnIndividuals,
        CorrectProductionData = 256 | PrintReportsOnProductionData,
        CorrectIndiviualsData = 512 | PrintReportsOnIndividuals,
        PerformAccounting = 1024 | EnterNewProductionData | EnterNewIndividualsData,
        PerformImport = 2048,
        PerformExport = 4096,
        ChangeImportExportRules = 8192 | PerformImport | PerformExport,
        ChangeBaseData = 16384,
        ChangeSystemData = 32768 | ViewSystemData,
        SystemMaintenance = 65536 | ChangeSystemData,
        Admin = unchecked((long)0xFFFFFFFFFFFFFFFF)
    }

    public enum FacessoVersion : byte
    {
        FacessoLight = 4,
        FacessoStandard = 5,
        FacessoProfessional = 6,
        FacessoEnterprise = 7
    }

    public struct FacessoVersionPermissionInfo : IVersionPermissionInfo
    {
        private FacessoVersion myFacessoVersion;

        public FacessoVersionPermissionInfo(FacessoVersion facVersion)
        {
            if (facVersion == (FacessoVersion)2)
                facVersion = FacessoVersion.FacessoEnterprise;
            myFacessoVersion = facVersion;
        }

        public FacessoVersion FacessoVersion => myFacessoVersion;
    }

    public struct FacessoRolePermissionInfo : IRolePermissionInfo
    {
        private ClearanceLevel myClearanceLevel;

        public FacessoRolePermissionInfo(ClearanceLevel cl)
        {
            myClearanceLevel = cl;
        }

        public ClearanceLevel ClearanceLevel => myClearanceLevel;
    }
}
