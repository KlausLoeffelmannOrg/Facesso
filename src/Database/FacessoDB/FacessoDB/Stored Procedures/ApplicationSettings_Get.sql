CREATE PROCEDURE dbo.ApplicationSettings_Get
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IsGlobal bit,
	@IDUser UNIQUEIDENTIFIER,
	@Settings xml OUTPUT,
	@IDApplicationSettings UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	IF @IsGlobal='true'
		SELECT @Settings=[Settings],
			@IDApplicationSettings=[IDApplicationSettings]
			FROM [ApplicationSettings] WHERE
			[IsGlobal]='true'
	ELSE
		SELECT @Settings=[Settings],
			@IDApplicationSettings=[IDApplicationSettings]
			FROM [ApplicationSettings] WHERE
			[IDSubsidiary]=@IDSubsidiary AND
			[IDUser]=@IDUser
			

		
	
		
				
			  
	
	
	
	
	
	