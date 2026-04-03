Imports System.Windows.Forms

Public Interface IVersionPermissionInfo
End Interface

Public Interface IRolePermissionInfo
End Interface

Public Enum ClearanceLevel As Long
    None = 0
    ViewReportsOnProductionData = 1
    ViewReportsOnIndividuals = 2
    ViewSystemData = 4
    PrintReportsOnProductionData = 8 Or ClearanceLevel.ViewReportsOnProductionData
    PrintReportsOnIndividuals = 16 Or ClearanceLevel.ViewReportsOnIndividuals
    PrintSystemData = 32 Or ClearanceLevel.ViewSystemData
    EnterNewProductionData = 64 Or ClearanceLevel.PrintReportsOnProductionData
    EnterNewIndividualsData = 128 Or ClearanceLevel.PrintReportsOnIndividuals
    CorrectProductionData = 256 Or ClearanceLevel.PrintReportsOnProductionData
    CorrectIndiviualsData = 512 Or ClearanceLevel.PrintReportsOnIndividuals
    PerformAccounting = 1024 Or ClearanceLevel.EnterNewProductionData Or ClearanceLevel.EnterNewIndividualsData
    PerformImport = 2048
    PerformExport = 4096
    ChangeImportExportRules = 8192 Or ClearanceLevel.PerformImport Or ClearanceLevel.PerformExport
    ChangeBaseData = 16384
    ChangeSystemData = 32768 Or ClearanceLevel.ViewSystemData
    SystemMaintenance = 65536 Or ChangeSystemData
    Admin = &HFFFFFFFFFFFFFFFF
End Enum

Public Enum FacessoVersion As Byte
    FacessoLight = 4
    FacessoStandard = 5
    FacessoProfessional = 6
    FacessoEnterprise = 7
End Enum

Public Structure FacessoVersionPermissionInfo
    Implements IVersionPermissionInfo

    Private myFacessoVersion As FacessoVersion

    Sub New(ByVal facVersion As FacessoVersion)
        If facVersion = 2 Then
            facVersion = FacessoVersion.FacessoEnterprise
        End If
        myFacessoVersion = facVersion
    End Sub

    Public ReadOnly Property FacessoVersion() As FacessoVersion
        Get
            Return myFacessoVersion
        End Get
    End Property
End Structure

Public Structure FacessoRolePermissionInfo
    Implements IRolePermissionInfo

    Private myClearanceLevel As ClearanceLevel

    Sub New(ByVal Cl As ClearanceLevel)
        myClearanceLevel = Cl
    End Sub

    Public ReadOnly Property ClearanceLevel() As ClearanceLevel
        Get
            Return myClearanceLevel
        End Get
    End Property
End Structure
