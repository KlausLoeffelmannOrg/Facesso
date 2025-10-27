CREATE PROCEDURE dbo.TimeLog_Analysis_GetEmployeeResult
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@Ticket datetime,
	@IDEmployee UNIQUEIDENTIFIER
	
WITH EXECUTE AS CALLER
AS
	DECLARE @IDWorkGroupInternal int

	SELECT     TimeLog.IDTimeLog, TimeLog.IDSubsidiary, TimeLog.IDWorkGroup, TimeLog.IDWorkGroupInternal, TimeLog.IDEmployee, 
	                      TimeLog.IDEmployeeInternal, TimeLog.IDBonusLists, TimeLog.IDWageGroup, TimeLog.Shift, TimeLog.ProductionDate, TimeLog.ShiftStart, 
	                      TimeLog.ShiftStartViaInterface, TimeLog.ShiftEnd, TimeLog.ShiftEndViaInterface, TimeLog.WorkBreak, TimeLog.WorkBreakViaInterface, 
	                      TimeLog.DownTime, TimeLog.DownTimeViaInterface, TimeLog.Handicap, TimeLog.AttendanceTime, TimeLog.WorkingTime, 
	                      TimeLog.IncentiveWageTime, TimeLog.IncentiveWageTimeAdj, TimeLog.DegreeOfTime, TimeLog.DegreeOfTimeAdj, 
	                      TimeLog.ReferenceWageTimeProRata, TimeLog.InsertedByInterface, TimeLog.ManuallyEdited, TimeLog.IsSuspended, TimeLog.LastEdited, 
	                      TimeLog.EditedByIDUser
	FROM         TimeLog INNER JOIN
	                      ParamsProductionDates ON TimeLog.IDSubsidiary = ParamsProductionDates.IDSubsidiary AND 
	                      TimeLog.ProductionDate = ParamsProductionDates.ProductionDate AND TimeLog.Shift = ParamsProductionDates.Shift
	WHERE     (TimeLog.IDEmployee = @IDEmployee) AND (TimeLog.IDSubsidiary = @IDSubsidiary) AND (ParamsProductionDates.IDSubsidiary = @IDSubsidiary) 
	                      AND (ParamsProductionDates.IDUser = @IDUser) AND (ParamsProductionDates.Ticket = @Ticket)
	 
	                      
		         

