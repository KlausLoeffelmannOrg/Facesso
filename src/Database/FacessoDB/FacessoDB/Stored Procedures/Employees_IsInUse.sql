CREATE PROCEDURE dbo.Employees_IsInUse 
	@IDEmployee UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IsInUse bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	IF EXISTS(SELECT * FROM [TimeLog] WHERE [IDEmployee]=@IDEmployee AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	IF EXISTS(SELECT * FROM [SkillProvided] WHERE [IDEmployee]=@IDEmployee AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	SET @IsInUse=0
	