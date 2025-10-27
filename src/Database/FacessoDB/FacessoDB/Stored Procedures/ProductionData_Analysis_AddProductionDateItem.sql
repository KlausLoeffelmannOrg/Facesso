CREATE PROCEDURE dbo.ProductionData_Analysis_AddProductionDateItem
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@Ticket datetime,
	@ProductionDate datetime,
	@Shift tinyint
	
WITH EXECUTE AS CALLER
AS
	SET @ProductionDate=convert(char(8),@ProductionDate,112)

	INSERT INTO ParamsProductionDates
	(IDSubsidiary, IDUser, Ticket, ProductionDate, Shift)
	VALUES
	(@IDSubsidiary, @IDUser, @Ticket, @ProductionDate, @Shift)
			         

