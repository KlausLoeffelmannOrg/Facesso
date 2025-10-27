CREATE PROCEDURE dbo.LabourValues_Delete

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDLabourValue UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DELETE FROM LabourValues WHERE IDSubsidiary=@IDSubsidiary AND IDLabourValue=@IDLabourValue
	
	
