CREATE PROCEDURE dbo.WorkGroups_GetAssignedLabourValues
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDWorkGroupInternal int
	
	-- Interne Nummer ermitteln
	
	SELECT @IDWorkGroupInternal=[IDWorkGroupInternal] FROM [WorkGroups] 
	WHERE [IDSubsidiary]=@IDSubsidiary AND [IDWorkGroup]=@IDWorkGroup

	-- Daten abholen
	
	SELECT     LabourValues.IDLabourValue, LabourValues.IDSubsidiary, LabourValues.IDLabourValueInternal, LabourValues.IDCostCenter, 
	                      LabourValues.LabourValueNumber, LabourValues.LabourValueName, LabourValues.LabourValueDescription, LabourValues.TeHMin, 
	                      LabourValues.Dimension, LabourValues.IsActive, LabourValues.IsCurrent, LabourValues.WasCurrentFrom, LabourValues.WasCurrentTo, 
	                      LabourValues.LastEdited, CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym
	FROM         WorkGroupAssignments INNER JOIN
	                      LabourValues ON WorkGroupAssignments.IDLabourValueInternal = LabourValues.IDLabourValueInternal INNER JOIN
	                      CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter
	WHERE		WorkGroupAssignments.IDSubsidiary=@IDSubsidiary AND
				WorkGroupAssignments.IDWorkGroupInternal=@IDWorkGroupInternal
				
	 
		
		  
			
