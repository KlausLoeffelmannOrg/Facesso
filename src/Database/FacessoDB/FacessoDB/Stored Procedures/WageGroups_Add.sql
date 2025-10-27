CREATE PROCEDURE dbo.WageGroups_Add
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCurrency UNIQUEIDENTIFIER,
	@IsTemplate bit,
	@WageGroupToken nvarchar(20),
	@Comment nvarchar(MAX),
	@HourlyRate money,
	@WasCurrentTo datetime,
	@CreatedByIDUser UNIQUEIDENTIFIER,
	@IDWageGroupNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDWageGroupInternal int,
			@Now DateTime
	
	SET @Now=GetDate()
	
	-- Verhindern, dass doppelte Lohngruppen-Token existieren können!
	IF EXISTS(SELECT * FROM  [WageGroups] 
					   WHERE [IDSubsidiary]		= @IDSubsidiary 
					   AND   [WageGroupToken]   = @WageGroupToken)
		SET @IDWageGroupNew = null
	ELSE
		BEGIN
			
			BEGIN TRANSACTION
			-- Letzte interne ID ermitteln
			SELECT @IDWageGroupInternal=MAX([IDWageGroupInternal]) 
						FROM  [WageGroups] 
						WHERE [IDSubsidiary] = @IDSubsidiary
			
			-- um eins erhöhen - das ist die neue interne ID
			IF @IDWageGroupInternal IS NULL
				SET @IDWageGroupInternal=1
			ELSE
				SET @IDWageGroupInternal = @IDWageGroupInternal + 1

			-- neue Lohngruppe in Tabelle einfügen
			INSERT INTO [WageGroups]
				([IDSubsidiary], [IDWageGroupInternal],[IDCurrency],
				[IsTemplate],[WageGroupToken],[Comment], [HourlyRate],
				[WasCurrentFrom], [WasCurrentTo], [IsCurrent], [LastEdited])
			VALUES
				(@IDSubsidiary, @IDWageGroupInternal, @IDCurrency,
				@IsTemplate, @WageGroupToken, @Comment, @HourlyRate,
				@Now, @WasCurrentTo, 1, @Now)
			
			if @@error!=0
				BEGIN
					ROLLBACK TRANSACTION
					SET @IDWageGroupNew=null
					RETURN
				END
			ELSE			
				COMMIT TRANSACTION
			--SET @IDWageGroupNew = SCOPE_IDENTITY()
		END
		
		EXEC AddToFunctionLog @IDSubsidiary, 'WageGroups: New wagegroup added', @CreatedByIDUser, @Now

