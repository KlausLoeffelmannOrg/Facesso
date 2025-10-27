CREATE PROCEDURE dbo.ProductionData_Analysis_DeleteProductionDateItems
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@Ticket datetime
	
WITH EXECUTE AS CALLER
AS
	DELETE FROM ParamsProductionDates WHERE IDSubsidiary=@IDSubsidiary
	AND IDUser=@IDUser AND Ticket=@Ticket

