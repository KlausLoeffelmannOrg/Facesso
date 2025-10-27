CREATE PROCEDURE [dbo].[WageGroups_Edit]
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCurrency UNIQUEIDENTIFIER,
	@IDWageGroup UNIQUEIDENTIFIER,
	@IsTemplate bit,
	@WageGroupToken nvarchar(20),
	@Comment nvarchar(MAX),
	@HourlyRate money,
	@LastEditedByIDUser UNIQUEIDENTIFIER,
	@ConsiderHistoryMaintenance bit,
	@IDWageGroupNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS

	
-- Die fehlenden Felder, die schon da sind
	DECLARE @IDWageGroupInternal int,
			@IsCurrent bit,
			@WasCurrentFrom DateTime,
			@WasCurrentTo DateTime,
			@WageGroupTokenOriginal nvarchar(20),
			@DoesExist bit

	-- Aktuelle Zeit
	DECLARE	@Now DateTime
	SET @Now=GetDate()

	-- Versuchen, die Daten direkt zu ändern, indem wir sie löschen
	-- und neu einfügen. Wenn das schief geht, werden sie referenziert.
	-- Dann müssen wir uns um die Historie kümmern.
	
	-- Erstmal schauen, ob der Datensatz existiert!
	IF NOT EXISTS(SELECT * FROM [WageGroups]
							WHERE [IDWageGroup]=@IDWageGroup AND [IDSubsidiary]=@IDSubsidiary)
			BEGIN
				RAISERROR('The specified wagegroup does not exist!',16,1)
				RETURN
			END
	
	-- Die fehlenden Daten ergänzen
	SELECT	@IDWageGroupInternal = [IDWageGroupInternal],
			@WageGroupTokenOriginal = [WageGroupToken],
			@WasCurrentFrom = [WasCurrentFrom],
			@WasCurrentTo = [WasCurrentTo] 
		FROM [WageGroups]
		WHERE [IDWageGroup]=@IDWageGroup AND [IDSubsidiary]=@IDSubsidiary

	-- Prüfen, ob sich das *Lohngruppen-Token* ändern wird. Falls
	-- ja, dann schauen, ob es das neue schon AKTIV gibt.
	IF @WageGroupToken<>@WageGroupTokenOriginal
		BEGIN
			EXEC WageGroups_DoesTokenExist @IDSubsidiary, 
				    				       @WageGroupToken,
											 null,
											 @DoesExist
			IF @DoesExist=1
				BEGIN
					RAISERROR('The specified new wagegroup token does already exist!',16,1)
					RETURN
				END
		END
		
	-- Historiepflege betreiben, oder nicht

	IF @ConsiderHistoryMaintenance=1
		BEGIN
			SET @ConsiderHistoryMaintenance=1
		END
	ELSE
		BEGIN
			UPDATE [WageGroups]
			SET [IsTemplate]=@IsTemplate,
				[IDCurrency]=@IDCurrency,
				[WageGroupToken]=@WageGroupToken,
				[Comment]=@Comment,
				[HourlyRate]=@HourlyRate,
				[LastEdited]=@Now
			WHERE [IDWageGroup]=@IDWageGroup AND [IDSubsidiary]=IDSubsidiary
			-- Aus Kompatiblitätsgründen zur Historienpflege für die Enterprise
			-- muss die ID zurückgegeben werden.
			Set @IDWageGroupNew = @IDWageGroup
		END

	EXEC AddToFunctionLog @IDSubsidiary, 'Wagegroups: Wagegroup Edited', @LastEditedByIDUser, @Now
		

