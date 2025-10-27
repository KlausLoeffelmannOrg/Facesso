CREATE PROCEDURE dbo.TimeLog_GetLogItemsForRange
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDEmployee UNIQUEIDENTIFIER,
	@StartDate datetime,
	@EndDate datetime
	 
	WITH EXECUTE AS CALLER
	AS
	
	SELECT     TimeLog.IDTimeLog, TimeLog.IDSubsidiary, TimeLog.IDWorkGroup, TimeLog.IDWorkGroupInternal, TimeLog.IDEmployee, TimeLog.IDBonusLists, 
	                      TimeLog.IDWageGroup AS IDWageGroupTimeLog, TimeLog.Shift, TimeLog.ProductionDate, TimeLog.ShiftStart, TimeLog.ShiftStartViaInterface, 
	                      TimeLog.ShiftEnd, TimeLog.ShiftEndViaInterface, TimeLog.WorkBreak, TimeLog.WorkBreakViaInterface, TimeLog.DownTime, 
	                      TimeLog.DownTimeViaInterface, TimeLog.Handicap, TimeLog.AttendanceTime, TimeLog.WorkingTime, TimeLog.IncentiveWageTime, 
	                      TimeLog.IncentiveWageTimeAdj, TimeLog.DegreeOfTime, TimeLog.DegreeOfTimeAdj, TimeLog.ReferenceWageTimeProRata, 
	                      TimeLog.InsertedByInterface, TimeLog.ManuallyEdited, TimeLog.LastEdited, TimeLog.EditedByIDUser, Employees.IDCostCenter, 
	                      Employees.IDWageGroup, Employees.UseFixedWage, Employees.IDAddressDetails, Employees.FixedWage, Employees.LastName, 
	                      Employees.Matchcode, Employees.FirstName, Employees.IsCurrent, Employees.PersonnelNumber, Employees.IsActive, Employees.IsIncentive, 
	                      Employees.WasCurrentFrom, Employees.WasCurrentTo, Employees.DateOfBirth, Employees.DateOfJoining, Employees.DateOfSeparation, 
	                      Employees.TimeCardNo, Employees.Comment, CostCenters.CostCenterNo, CostCenters.CostCenterName, Employees.IDEmployeeInternal, 
	                      TimeLog.IsSuspended
	FROM         Employees INNER JOIN
	                      TimeLog ON Employees.IDSubsidiary = TimeLog.IDSubsidiary AND Employees.IDEmployee = TimeLog.IDEmployee INNER JOIN
	                      CostCenters ON Employees.IDSubsidiary = CostCenters.IDSubsidiary AND Employees.IDCostCenter = CostCenters.IDCostCenter
	WHERE     (TimeLog.IDSubsidiary = @IDSubsidiary) AND (TimeLog.ProductionDate >= @StartDate) AND (TimeLog.ProductionDate < @EndDate) AND 
	                      (TimeLog.IDEmployee = @IDEmployee)
	ORDER BY TimeLog.ShiftStart
	
