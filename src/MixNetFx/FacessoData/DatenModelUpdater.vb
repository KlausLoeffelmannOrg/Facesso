Imports System.Data.SqlClient

Public Class DatenModelUpdater
    Inherits ActiveDevelop.SqlTools.DatabaseSchemaUpdateManager

    Public Sub New(ByVal connection As String, ByVal silent As Boolean)
        MyBase.New(connection, silent)
    End Sub

    Public Function CheckIfUpdateRequired() As Boolean
        If Not CheckTableExists("[dbo].[EmployeeHandicaps]") Then
            Return True
        End If
        Return False
    End Function

    Public Sub PerformSchemaUpdate()
        Try
            StartTransaction()
            If Not CheckTableExists("[dbo].[EmployeeHandicaps]") Then
                ' Tabelle anlegen
                ExecDDLStmt("CREATE TABLE [dbo].[EmployeeHandicaps](" & _
                 "[IDEmployee] [int] NOT NULL," & _
                 "[IDSubsidiary] [int] NOT NULL," & _
                 "[Handicap] [float] NOT NULL," & _
                 "[ValidFrom] [datetime] NOT NULL)")

                ' NON Unique Index anlegen (Tabelle hat keine eindeutige ID)
                ExecDDLStmt("Create Index IX_EmployeeHandicap on [dbo].[EmployeeHandicaps] (IDSubsidiary, IDEmployee)")

                ' Foreign Key anlegen
                ExecDDLStmt("ALTER TABLE [dbo].[EmployeeHandicaps]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeHandicap_Employees] FOREIGN KEY([IDSubsidiary], [IDEmployee]) " & _
                                "REFERENCES [dbo].[Employees] ([IDSubsidiary], [IDEmployee])")

                ' Aktivieren ? oder Daten prüfen ? (wird so vom management studio generiert)
                ExecDDLStmt("ALTER TABLE [dbo].[EmployeeHandicaps] CHECK CONSTRAINT [FK_EmployeeHandicap_Employees]")

                Commit()
            End If
        Catch ex As Exception
            Rollback()
            Throw ex
        End Try
    End Sub

End Class
