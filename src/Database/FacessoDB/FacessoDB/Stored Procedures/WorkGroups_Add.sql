CREATE PROCEDURE dbo.WorkGroups_Add 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@WorkGroupNumber int,
	@WorkGroupName nvarchar(100),
	@WorkGroupDescription nvarchar(4000),
	@IsActive bit,
	@IsPeaceWork bit,
	@IsConceptional bit,
	@OrdinalNo int,
	@TimeSettingDetails xml,
	@WasCurrentTo datetime,
	@CreatedByIDUser UNIQUEIDENTIFIER,
	@IDWorkGroupNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDWorkGroupInternal int
	DECLARE @Now DateTime
	
	SET @Now=GetDate()
	
	-- Verhindern, dass doppelte Arbeitsgruppennummern existieren können!
	IF EXISTS(SELECT * FROM  [WorkGroups] 
					   WHERE [IDSubsidiary]   = @IDSubsidiary 
					   AND   [WorkGroupNumber]   = @WorkGroupNumber)
		SET @IDWorkGroupNew = null
	ELSE
		BEGIN
			
			BEGIN TRANSACTION

			-- Letzte interne ID ermitteln
			SELECT @IDWorkGroupInternal=MAX([IDWorkGroupInternal]) 
						FROM  [WorkGroups] 
						WHERE [IDSubsidiary] = @IDSubsidiary
			
			-- um eins erhöhen, das ist die neue interne ID
			IF @IDWorkGroupInternal IS NULL
				SET @IDWorkGroupInternal = 1
			ELSE
				SET @IDWorkGroupInternal = @IDWorkGroupInternal + 1

			-- neuen Arbeitswert in Tabelle einfügen
			INSERT INTO [WorkGroups]
				([IDSubsidiary], [IDWorkGroupInternal], [IDCostCenter], [IsCurrent],
				[WorkGroupNumber], [WorkGroupName], [WorkGroupDescription],
				[IsActive], [IsPeaceWork], [IsConceptional], [OrdinalNo], 
				[TimeSettingDetails],
				[WasCurrentFrom], [WasCurrentTo], [LastEdited])
			VALUES
				(@IDSubsidiary, @IDWorkGroupInternal, @IDCostCenter, 1, 
				@WorkGroupNumber, @WorkGroupName, @WorkGroupDescription, 
				@IsActive, @IsPeacework, @IsConceptional, @OrdinalNo, 
				@TimeSettingDetails,
				@Now, @WasCurrentTo, @Now)
			
			COMMIT TRANSACTION
			--SET @IDWorkGroupNew = SCOPE_IDENTITY()
			
			EXEC AddToFunctionLog @IDSubsidiary, 'WorkGroups: Added new workgroup', @CreatedByIDUser, @Now
		END
		
		  
			
