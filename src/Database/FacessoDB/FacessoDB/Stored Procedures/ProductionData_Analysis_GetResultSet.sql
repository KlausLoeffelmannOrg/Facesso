CREATE PROCEDURE dbo.ProductionData_Analysis_GetResultSet
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@Ticket datetime
	
WITH EXECUTE AS CALLER
AS
	DECLARE @IDWorkGroupInternal int

	SELECT     ProductionData.IDProductionData, ProductionData.IDSubsidiary, ProductionData.IDWorkGroup, ProductionData.IDWorkGroupInternal, 
	                      ProductionData.IDEmployee, ProductionData.ProductionDate, ProductionData.Shift, ProductionData.TotalReferenceIWT, 
	                      ProductionData.TotalEffectiveIWT, ProductionData.TotalEffectiveIWTAdj, ProductionData.TotalDownTime, ProductionData.TotalWorkBreakTime, 
	                      ProductionData.DegreeOfTime, ProductionData.DegreeOfTimeAdj, ProductionData.InsertedByInterface, ProductionData.IsSuspended, 
	                      WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, WorkGroups.WorkgroupName, WorkGroups.WorkGroupDescription, WorkGroups.IsActive, 
	                      WorkGroups.IsPeaceWork, WorkGroups.OrdinalNo, WorkGroups.IsCurrent, WorkGroups.TimeSettingDetails, WorkGroups.WasCurrentFrom, 
	                      WorkGroups.WasCurrentTo, WorkGroups.LastEdited, CostCenters.CostCenterNo, CostCenters.CostCenterName, 
	                      CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveWageSynonym, CostCenters.IncentiveIndicatorDimension, 
	                      CostCenters.IncentiveIndicatorPrecision, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, WorkGroups.WorkloadIWT
	FROM         ProductionData INNER JOIN
	                      WorkGroups ON ProductionData.IDSubsidiary = WorkGroups.IDSubsidiary AND ProductionData.IDWorkGroup = WorkGroups.IDWorkGroup INNER JOIN
	                      CostCenters ON WorkGroups.IDSubsidiary = CostCenters.IDSubsidiary AND WorkGroups.IDCostCenter = CostCenters.IDCostCenter INNER JOIN
	                      ParamsWorkGroups ON ProductionData.IDSubsidiary = ParamsWorkGroups.IDSubsidiary AND 
	                      ProductionData.IDWorkGroupInternal = dbo.WorkGroupInternal(@IDSubsidiary, ParamsWorkGroups.IDWorkGroup) INNER JOIN
	                      ParamsProductionDates ON ProductionData.IDSubsidiary = ParamsProductionDates.IDSubsidiary AND 
	                      ProductionData.ProductionDate = ParamsProductionDates.ProductionDate AND ProductionData.Shift = ParamsProductionDates.Shift
	WHERE     (ProductionData.IDSubsidiary = @IDSubsidiary) AND (ParamsProductionDates.IDUser = @IDUser) AND (ParamsProductionDates.Ticket = @Ticket) AND 
	                      (ParamsProductionDates.IDSubsidiary = @IDSubsidiary) AND (ParamsWorkGroups.IDSubsidiary = @IDSubsidiary) AND 
	                      (ParamsWorkGroups.IDUser = @IDUser) AND (ParamsWorkGroups.Ticket = @Ticket) 
	                      
		         

