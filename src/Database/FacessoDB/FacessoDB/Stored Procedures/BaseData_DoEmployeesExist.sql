CREATE PROCEDURE dbo.BaseData_DoEmployeesExist
	@IDSubsidiary UNIQUEIDENTIFIER,
	@DoExist bit OUTPUT
	
WITH EXECUTE AS CALLER
AS
	IF EXISTS(SELECT * FROM Employees WHERE IDSubsidiary=@IDSubsidiary)
		SET @DoExist='true'
	ELSE
		SET @DoExist='false'
	

