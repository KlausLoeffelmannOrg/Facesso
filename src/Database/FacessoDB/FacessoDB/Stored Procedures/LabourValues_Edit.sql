CREATE PROCEDURE [dbo].[LabourValues_Edit]
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDLabourValue UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@LabourValueNumber int,
	@LabourValueName nvarchar(100),
	@LabourValueDescription nvarchar(MAX),
	@TeHMin float,
	@Dimension nvarchar(50),
	@IsActive bit,
	@LastEditedByIDUser int,
	@ConsiderHistoryMaintenance bit,
	@IDLabourValueNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS

	
-- Die fehlenden Felder, die schon da sind
	DECLARE @IDLabourValueInternal int,
			@IsCurrent bit,
			@WasCurrentFrom DateTime,
			@WasCurrentTo DateTime,
			@LabourValueNumberOriginal int,
			@DoesExist bit

	-- Aktuelle Zeit
	DECLARE	@Now DateTime
	SET @Now=GetDate()

	-- Versuchen, die Daten direkt zu ändern, indem wir sie löschen
	-- und neu einfügen. Wenn das schief geht, werden sie referenziert.
	-- Dann müssen wir uns um die Historie kümmern.
	
	-- Erstmal schauen, ob der Datensatz existiert!
	IF NOT EXISTS(SELECT * FROM [LabourValues]
							WHERE [IDLabourValue]=@IDLabourValue AND [IDSubsidiary]=@IDSubsidiary)
			BEGIN
				RAISERROR('The specified labour value does not exist!',16,1)
				RETURN
			END
	
	-- Die fehlenden Daten ergänzen
	SELECT	@IDLabourValueInternal = [IDLabourValueInternal],
			@LabourValueNumberOriginal = [LabourValueNumber],
			@WasCurrentFrom = [WasCurrentFrom],
			@WasCurrentTo = [WasCurrentTo] 
		FROM [Labourvalues]
		WHERE [IDLabourValue]=@IDLabourValue AND [IDSubsidiary]=@IDSubsidiary

	-- Prüfen, ob sich die *Kostenstellennr.* ändern wird. Falls
	-- ja, dann schauen, ob es die neue Kostenstellennr. schon AKTIV gibt.
	IF @LabourValueNumber<>@LabourValueNumberOriginal
		BEGIN
			EXEC LabourValues_DoesNumberExist @IDSubsidiary, 
				    						 @LabourValueNumber,
											 null,
											 @DoesExist
			IF @DoesExist=1
				BEGIN
					RAISERROR('The specified new Labour value number does already exist!',16,1)
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
			UPDATE [LabourValues]
			SET [IDCostCenter]=@IDCostCenter,
				[LabourValueNumber]=@LabourValueNumber,
				[LabourValueName]=@LabourValueName,
				[LabourValueDescription]=@LabourValueDescription,
				[TeHMin]=@TeHMin,
				[Dimension]=@Dimension,
				[IsActive]=@IsActive,
				[LastEdited]=@Now
			WHERE [IDLabourValue]=@IDLabourValue AND [IDSubsidiary]=IDSubsidiary
			-- Aus Kompatiblitätsgründen zur Historienpflege für die Enterprise
			-- muss die ID zurückgegeben werden.
			Set @IDLabourValueNew = @IDLabourValue
		END

	EXEC AddToFunctionLog @IDSubsidiary, 'LabourValues: Labour value edited', @LastEditedByIDUser, @Now
