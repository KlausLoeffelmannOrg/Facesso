CREATE PROCEDURE dbo.BaseData_DoWorkGroupsExist
	@IDSubsidiary UNIQUEIDENTIFIER,
	@DoExist bit OUTPUT
	
WITH EXECUTE AS CALLER
AS
	IF EXISTS(SELECT * FROM WorkGroups WHERE IDSubsidiary=@IDSubsidiary)
		SET @DoExist='true'
	ELSE
		SET @DoExist='false'
	

