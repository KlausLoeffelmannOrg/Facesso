CREATE PROCEDURE dbo.WorkGroups_GetItems 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint,
	@JoinedWithCostcenter bit

	WITH EXECUTE AS CALLER
	AS
	
	If (@ProductionDate IS NULL) or (@Shift is NULL)
		IF @JoinedWithCostCenter='false'
			SELECT * FROM WorkGroups WHERE IDSubsidiary=@IDSubsidiary
		ELSE
			SELECT     WorkGroups.IDWorkGroup, WorkGroups.IDSubsidiary, WorkGroups.IDWorkGroupInternal, WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, 
			                      WorkGroups.WorkgroupName, WorkGroups.WorkGroupDescription, WorkGroups.IsActive, WorkGroups.IsCurrent, WorkGroups.IsPeaceWork, 
			                      WorkGroups.OrdinalNo, WorkGroups.TimeSettingDetails, WorkGroups.WasCurrentFrom, WorkGroups.WasCurrentTo, WorkGroups.LastEdited, 
			                      CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorDimension, 
			                      CostCenters.IncentiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, 
			                      WorkGroups.WorkloadIWT, WorkGroups.IsConceptional
			FROM         WorkGroups INNER JOIN
			                      CostCenters ON WorkGroups.IDSubsidiary = CostCenters.IDSubsidiary AND WorkGroups.IDCostCenter = CostCenters.IDCostCenter
			WHERE     (WorkGroups.IDSubsidiary = @IDSubsidiary)
			
	ELSE
		IF @JoinedWithCostCenter='false'
			SELECT dbo.HasProductionData(@IDSubsidiary, WorkGroups.IDWorkGroup, @ProductionDate, @Shift) AS HasProductionData, WorkGroups.IDWorkGroup, 
			                      WorkGroups.IDSubsidiary, WorkGroups.IDWorkGroupInternal, WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, 
			                      WorkGroups.WorkgroupName, WorkGroups.WorkGroupDescription, WorkGroups.IsActive, WorkGroups.IsCurrent, WorkGroups.IsPeaceWork, 
			                      WorkGroups.OrdinalNo, WorkGroups.TimeSettingDetails, WorkGroups.WasCurrentFrom, WorkGroups.WasCurrentTo, WorkGroups.LastEdited, 
			                      WorkGroups.WorkloadIWT, WorkGroups.IsConceptional
			FROM  WorkGroups 
			WHERE IDSubsidiary=@IDSubsidiary
		ELSE
			SELECT     dbo.HasProductionData(@IDSubsidiary, WorkGroups.IDWorkGroup, @ProductionDate, @Shift) AS HasProductionData, WorkGroups.IDWorkGroup, 
			                      WorkGroups.IDSubsidiary, WorkGroups.IDWorkGroupInternal, WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, 
			                      WorkGroups.WorkgroupName, WorkGroups.WorkGroupDescription, WorkGroups.IsActive, WorkGroups.IsCurrent, WorkGroups.IsPeaceWork, 
			                      WorkGroups.OrdinalNo, WorkGroups.TimeSettingDetails, WorkGroups.WasCurrentFrom, WorkGroups.WasCurrentTo, WorkGroups.LastEdited, 
			                      CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorDimension, 
			                      CostCenters.IncentiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, 
			                      WorkGroups.WorkloadIWT, WorkGroups.IsConceptional
			FROM         WorkGroups INNER JOIN
			                      CostCenters ON WorkGroups.IDSubsidiary = CostCenters.IDSubsidiary AND WorkGroups.IDCostCenter = CostCenters.IDCostCenter
			WHERE     (WorkGroups.IDSubsidiary = @IDSubsidiary)
