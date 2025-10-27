CREATE PROCEDURE dbo.Employees_GetInWorkGroupOnShiftDate
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint

	WITH EXECUTE AS CALLER
	AS
	
	SELECT DISTINCT 
	                      TimeLog.DegreeOfTime, TimeLog.DegreeOfTimeAdj, Employees.IDEmployee, Employees.IDSubsidiary, Employees.IDEmployeeInternal, 
	                      Employees.IDCostCenter, Employees.IDWageGroup, Employees.UseFixedWage, Employees.FixedWage, Employees.IDAddressDetails, 
	                      Employees.LastName, Employees.FirstName, Employees.Matchcode, Employees.PersonnelNumber, Employees.IsCurrent, Employees.IsActive, 
	                      Employees.IsIncentive, Employees.WasCurrentFrom, Employees.WasCurrentTo, Employees.DateOfBirth, Employees.DateOfJoining, 
	                      Employees.DateOfSeparation, Employees.TimeCardNo, Employees.Comment, Employees.LastEdited, CostCenters.CostCenterNo, 
	                      CostCenters.CostCenterName, CostCenters.IncentiveWageSynonym
	FROM         TimeLog INNER JOIN
	                      Employees ON TimeLog.IDSubsidiary = Employees.IDSubsidiary AND TimeLog.IDEmployee = Employees.IDEmployee INNER JOIN
	                      CostCenters ON Employees.IDSubsidiary = CostCenters.IDSubsidiary AND Employees.IDCostCenter = CostCenters.IDCostCenter
	WHERE     (TimeLog.IDSubsidiary = @IDSubsidiary) AND (TimeLog.IDWorkGroupInternal = dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)) AND 
	                      (TimeLog.ProductionDate = @ProductionDate) AND (TimeLog.Shift = @Shift)
	

