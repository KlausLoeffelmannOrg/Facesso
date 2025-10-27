CREATE PROCEDURE dbo.DeleteDataForOleDbImport

	@IDSubsidiary UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS

	DELETE FROM [TimeLog] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [ProductionDataItemsForInsert] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [ProductionDataItems] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [ProductionData] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [WorkGroupAssignments] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [WorkGroups] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [Employees] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [LabourValues] WHERE [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [CostCenters] WHERE CostCenterNo<>0 AND [IDSubsidiary]=@IDSubsidiary
	DELETE FROM [WageGroups] WHERE [IDSubsidiary]=@IDSubsidiary
	
		
		
	
