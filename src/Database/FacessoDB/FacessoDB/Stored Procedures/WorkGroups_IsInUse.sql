CREATE PROCEDURE dbo.WorkGroups_IsInUse 
	@IDWorkGroup UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IsInUse bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	IF EXISTS(SELECT * FROM [ProductionData] WHERE [IDWorkGroupInternal]=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup) AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	IF EXISTS(SELECT * FROM [TimeLog] WHERE [IDWorkGroupInternal]=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup) AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	IF EXISTS(SELECT * FROM [SkillNeeded] WHERE [IDWorkGroup]=@IDWorkGroup AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	SET @IsInUse=0
	