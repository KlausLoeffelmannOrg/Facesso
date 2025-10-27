CREATE PROCEDURE dbo.ApplicationSettings_Set
	@IDApplicationSettings UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IsGlobal bit,
	@IDUser UNIQUEIDENTIFIER,
	@Settings xml,
	@IDAppSettingsNew UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDUserActual UNIQUEIDENTIFIER
	
	-- Wenn Global, dann Systemuser verwenden
	IF @IsGlobal='true'
		SELECT @IDUserActual=[IDUser],
			   @IDSubsidiary=[IDSubsidiary]
			   FROM Users WHERE [IDUserInternal]=-1
	ELSE
		SET @IDUserActual=@IDUser
	
	-- Wenn IDApplicationSettings 0 ist, neuen Eintrag erstellen, sonst
	-- vorhandene Daten nur updaten
	
	IF @IDApplicationSettings=null
		BEGIN
			INSERT INTO [ApplicationSettings] ([IDSubsidiary], [IsGlobal],[IDUser], [Settings])
			VALUES (@IDSubsidiary, @IsGlobal, @IDUserActual, @Settings)
		END
	ELSE
		BEGIN
			UPDATE [ApplicationSettings]
			SET [Settings]=@Settings
			WHERE [IDApplicationSettings]=@IDApplicationSettings AND
				[IDSubsidiary]=@IDSubsidiary AND
				[IDUser]=@IDUserActual
		END
		
				
			  
	
	
	
	
	
	