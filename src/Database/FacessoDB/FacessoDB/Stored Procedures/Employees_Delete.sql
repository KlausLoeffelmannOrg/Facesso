Create PROCEDURE dbo.Employees_Delete

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDEmployee UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DELETE FROM Employees WHERE IDSubsidiary=@IDSubsidiary AND IDEmployee=@IDEmployee
	
	
