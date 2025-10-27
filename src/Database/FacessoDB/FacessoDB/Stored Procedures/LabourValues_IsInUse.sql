CREATE PROCEDURE dbo.LabourValues_IsInUse 
	@IDLabourValue UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IsInUse bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	IF EXISTS(SELECT * FROM [WorkGroupAssignments] WHERE [IDLabourValueInternal]=dbo.GetLabourValueInternal(@IDSubsidiary, @IDLabourValue) AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	SET @IsInUse=0
	