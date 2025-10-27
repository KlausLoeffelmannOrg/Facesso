Create PROCEDURE dbo.BaseData_DoLabourValuesExist
	@IDSubsidiary UNIQUEIDENTIFIER,
	@DoExist bit OUTPUT
	
WITH EXECUTE AS CALLER
AS
	IF EXISTS(SELECT * FROM LabourValues WHERE IDSubsidiary=@IDSubsidiary)
		SET @DoExist='true'
	ELSE
		SET @DoExist='false'
	

