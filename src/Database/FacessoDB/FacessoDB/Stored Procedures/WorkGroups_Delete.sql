CREATE PROCEDURE dbo.WorkGroups_Delete

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DELETE FROM WorkGroups WHERE IDSubsidiary=@IDSubsidiary AND IDWorkGroup=@IDWorkGroup
	
	
