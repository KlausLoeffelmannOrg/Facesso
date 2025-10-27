CREATE PROCEDURE dbo.ProductionData_Analysis_GetShiftDateResultSet
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER OUTPUT,
	@ProductionDate datetime,
	@Shift tinyint
	
WITH EXECUTE AS CALLER
AS
	DECLARE @IDWorkGroupInternal int
	
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary,@IDWorkGroup)

	SELECT     ProductionData.IDProductionData, ProductionData.IDSubsidiary, ProductionData.IDWorkGroup, ProductionData.IDWorkGroupInternal, 
	                      ProductionData.IDEmployee, ProductionData.ProductionDate, ProductionData.Shift, ProductionData.TotalReferenceIWT, 
	                      ProductionData.TotalEffectiveIWT, ProductionData.TotalEffectiveIWTAdj, ProductionData.TotalDownTime, ProductionData.TotalWorkBreakTime, 
	                      ProductionData.DegreeOfTime, ProductionData.DegreeOfTimeAdj, ProductionData.InsertedByInterface, ProductionData.IsSuspended, 
	                      WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, WorkGroups.WorkgroupName, WorkGroups.WorkGroupDescription, WorkGroups.IsActive, 
	                      WorkGroups.IsPeaceWork, WorkGroups.OrdinalNo, WorkGroups.IsCurrent, WorkGroups.TimeSettingDetails, WorkGroups.WasCurrentFrom, 
	                      WorkGroups.WasCurrentTo, WorkGroups.LastEdited, CostCenters.CostCenterNo, CostCenters.CostCenterName, 
	                      CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveWageSynonym, CostCenters.IncentiveIndicatorDimension, 
	                      CostCenters.IncentiveIndicatorPrecision, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, CostCenters.IncentiveIndicatorFactor, 
	                      WorkGroups.WorkloadIWT, WorkGroups.IsConceptional
	FROM         ProductionData INNER JOIN
	                      WorkGroups ON ProductionData.IDSubsidiary = WorkGroups.IDSubsidiary AND ProductionData.IDWorkGroup = WorkGroups.IDWorkGroup INNER JOIN
	                      CostCenters ON WorkGroups.IDSubsidiary = CostCenters.IDSubsidiary AND WorkGroups.IDCostCenter = CostCenters.IDCostCenter
	WHERE     (ProductionData.IDSubsidiary = @IDSubsidiary) AND (ProductionData.IDWorkGroupInternal = @IDWorkGroupInternal) AND 
	                      (ProductionData.ProductionDate = @ProductionDate) AND (ProductionData.Shift = @Shift) AND (ProductionData.IDEmployee = null)
		         

