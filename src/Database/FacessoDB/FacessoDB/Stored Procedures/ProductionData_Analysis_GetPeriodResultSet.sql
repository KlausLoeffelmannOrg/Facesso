CREATE PROCEDURE dbo.ProductionData_Analysis_GetPeriodResultSet
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@Ticket datetime
	
WITH EXECUTE AS CALLER
AS
	DECLARE @IDWorkGroupInternal int
	
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary,@IDWorkGroup)

	SELECT     ProductionData.IDProductionData, ProductionData.IDSubsidiary, ProductionData.IDWorkGroup, ProductionData.IDWorkGroupInternal, 
	                      ProductionData.IDEmployee, ProductionData.ProductionDate, ProductionData.Shift, ProductionData.TotalReferenceIWT, 
	                      ProductionData.TotalEffectiveIWT, ProductionData.TotalEffectiveIWTAdj, ProductionData.TotalDownTime, ProductionData.TotalWorkBreakTime, 
	                      ProductionData.DegreeOfTime, ProductionData.DegreeOfTimeAdj, ProductionData.InsertedByInterface, ProductionData.IsSuspended, 
	                      ProductionData.LastEdited, ProductionData.LastEditedByIDUser
	FROM         ProductionData INNER JOIN
	                      ParamsProductionDates ON ProductionData.IDSubsidiary = ParamsProductionDates.IDSubsidiary AND 
	                      ProductionData.ProductionDate = ParamsProductionDates.ProductionDate AND ProductionData.Shift = ParamsProductionDates.Shift
	WHERE     (ProductionData.IDWorkGroupInternal = @IDWorkGroupInternal) AND (ProductionData.IDSubsidiary = @IDSubsidiary) AND 
	                      (ParamsProductionDates.IDSubsidiary = @IDSubsidiary) AND (ParamsProductionDates.Ticket = @Ticket) AND 
	                      (ParamsProductionDates.IDUser = @IDUser)     
		         

