CREATE PROCEDURE dbo.TimeLog_GetOverlappingLogItems
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDEmployee UNIQUEIDENTIFIER,
	@ShiftStart datetime,
	@ShiftEnd datetime,
	@ExcludeIDTimeLog UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS
	
	IF @ExcludeIDTimeLog IS NULL
		SET @ExcludeIDTimeLog=null
	
	
	SELECT     TimeLog.IDTimeLog, TimeLog.IDSubsidiary, TimeLog.Shift, TimeLog.ProductionDate, TimeLog.ShiftStart, TimeLog.ShiftEnd, 
	                      WorkGroups.IDWorkGroupInternal, WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, WorkGroups.WorkgroupName, 
	                      WorkGroups.WorkGroupDescription, WorkGroups.IsActive, WorkGroups.IsCurrent, WorkGroups.IsPeaceWork, WorkGroups.TimeSettingDetails, 
	                      WorkGroups.OrdinalNo, WorkGroups.WasCurrentFrom, WorkGroups.WasCurrentTo, WorkGroups.LastEdited, CostCenters.CostCenterNo, 
	                      CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorFactor, 
	                      CostCenters.IncentiveIndicatorDimension, CostCenters.IncentiveIndicatorPrecision, TimeLog.IDWorkGroup, CostCenters.IncentiveWageSynonym, 
	                      CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, WorkGroups.WorkloadIWT, WorkGroups.IsConceptional
	FROM         TimeLog INNER JOIN
	                      WorkGroups ON TimeLog.IDWorkGroup = WorkGroups.IDWorkGroup AND TimeLog.IDSubsidiary = WorkGroups.IDSubsidiary INNER JOIN
	                      CostCenters ON WorkGroups.IDSubsidiary = CostCenters.IDSubsidiary AND WorkGroups.IDCostCenter = CostCenters.IDCostCenter
	WHERE     (TimeLog.ShiftEnd > @ShiftStart) AND (TimeLog.ShiftStart < @ShiftEnd) AND (TimeLog.IDSubsidiary = @IDSubsidiary) AND 
	                      (TimeLog.IDEmployee = @IDEmployee) AND (TimeLog.IDTimeLog <> @ExcludeIDTimeLog)
