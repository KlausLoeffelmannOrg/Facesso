CREATE PROCEDURE [dbo].[WorkGroups_Edit]
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@WorkGroupNumber int,
	@WorkGroupName nvarchar(100),
	@WorkGroupDescription nvarchar(MAX),
	@IsActive bit,
	@IsPeaceWork bit,
	@IsConceptional bit,
	@OrdinalNo int,
	@TimeSettingDetails xml,
	@LastEditedByIDUser UNIQUEIDENTIFIER,
	@ConsiderHistoryMaintenance bit,
	@IDWorkGroupNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS

	
-- Die fehlenden Felder, die schon da sind
	DECLARE @IDWorkGroupInternal int,
			@IsCurrent bit,
			@WasCurrentFrom DateTime,
			@WasCurrentTo DateTime,
			@WorkGroupNumberOriginal int,
			@DoesExist bit

	-- Aktuelle Zeit
	DECLARE	@Now DateTime
	SET @Now=GetDate()

	-- Versuchen, die Daten direkt zu ändern, indem wir sie löschen
	-- und neu einfügen. Wenn das schief geht, werden sie referenziert.
	-- Dann müssen wir uns um die Historie kümmern.
	
	-- Erstmal schauen, ob der Datensatz existiert!
	IF NOT EXISTS(SELECT * FROM [WorkGroups]
							WHERE [IDWorkGroup]=@IDWorkGroup AND [IDSubsidiary]=@IDSubsidiary)
			BEGIN
				RAISERROR('The specified labour value does not exist!',16,1)
				RETURN
			END
	
	-- Die fehlenden Daten ergänzen
	SELECT	@IDWorkGroupInternal = [IDWorkGroupInternal],
			@WorkGroupNumberOriginal = [WorkGroupNumber],
			@WasCurrentFrom = [WasCurrentFrom],
			@WasCurrentTo = [WasCurrentTo] 
		FROM [WorkGroups]
		WHERE [IDWorkGroup]=@IDWorkGroup AND [IDSubsidiary]=@IDSubsidiary

	-- Prüfen, ob sich die *Kostenstellennr.* ändern wird. Falls
	-- ja, dann schauen, ob es die neue Kostenstellennr. schon AKTIV gibt.
	IF @WorkGroupNumber<>@WorkGroupNumberOriginal
		BEGIN
			EXEC WorkGroups_DoesWorkGroupNumberExist @IDSubsidiary, 
				    						 @WorkGroupNumber,
											 null,
											 @DoesExist
			IF @DoesExist=1
				BEGIN
					RAISERROR('The specified new Workgroup number does already exist!',16,1)
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
			UPDATE [WorkGroups]
			SET [IDCostCenter]=@IDCostCenter,
				[WorkGroupNumber]=@WorkGroupNumber,
				[WorkGroupName]=@WorkGroupName,
				[WorkGroupDescription]=@WorkGroupDescription,
				[IsActive]=@IsActive,
				[IsPeaceWork]=@IsPeaceWork,
				[IsConceptional]=@IsConceptional,
				[OrdinalNo]=@OrdinalNo,
				[TimeSettingDetails]=@TimeSettingDetails,
				[LastEdited]=@Now
			WHERE [IDWorkGroup]=@IDWorkGroup AND [IDSubsidiary]=IDSubsidiary
			-- Aus Kompatiblitätsgründen zur Historienpflege für die Enterprise
			-- muss die ID zurückgegeben werden.
			Set @IDWorkGroupNew = @IDWorkGroup
		END

	EXEC AddToFunctionLog @IDSubsidiary, 'Workgroup: Workgroup edited', @LastEditedByIDUser, @Now
