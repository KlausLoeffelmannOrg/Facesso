CREATE PROCEDURE [dbo].[CostCenters_Edit]
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@CostCenterNo int,
	@CostCenterName nvarchar(100),
	@CostCenterDescription nvarchar(4000),
	@IDCurrency UNIQUEIDENTIFIER,
	@IncentiveIndicatorSynonym nvarchar(50),
	@IncentiveWageSynonym nvarchar(50),
	@IncentiveIndicatorDimension nvarchar(50),
	@IncentiveIndicatorPrecision tinyint,
	@UseFixValuedBonus bit,
	@IncentiveIndicatorFactor decimal,
	@BaseValuePrecision tinyint,
	@BaseValueSynonym nvarchar(50),
	@LastEditedByIDUser UNIQUEIDENTIFIER,
	@ConsiderHistoryMaintenance bit,
	@IDCostCenterNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS

	
-- Die fehlenden Felder, die schon da sind
	DECLARE @IDCostCenterInternal int,
			@IsCurrent bit,
			@WasCurrentFrom DateTime,
			@WasCurrentTo DateTime,
			@CostCenterNoOriginal int,
			@DoesExist bit

	-- Aktuelle Zeit
	DECLARE	@Now DateTime
	SET @Now=GetDate()

	-- Versuchen, die Daten direkt zu ändern, indem wir sie löschen
	-- und neu einfügen. Wenn das schief geht, werden sie referenziert.
	-- Dann müssen wir uns um die Historie kümmern.
	
	-- Erstmal schauen, ob der Datensatz existiert!
	IF NOT EXISTS(SELECT * FROM [CostCenters]
							WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary)
			BEGIN
				RAISERROR('The specified costcenter does not exist!',16,1)
				RETURN
			END
	
	-- Die fehlenden Daten ergänzen
	SELECT	@IDCostCenterInternal = [IDCostCenterInternal],
			@CostCenterNoOriginal = [CostCenterNo],
			@WasCurrentFrom = [WasCurrentFrom],
			@WasCurrentTo = [WasCurrentTo] 
		FROM [CostCenters]
		WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary

	-- Prüfen, ob sich die *Kostenstellennr.* ändern wird. Falls
	-- ja, dann schauen, ob es die neue Kostenstellennr. schon AKTIV gibt.
	IF @CostCenterNo<>@CostCenterNoOriginal
		BEGIN
			EXEC CostCenters_DoesNumberExist @IDSubsidiary, 
				    						 @CostCenterNo,
											 null,
											 @DoesExist
			IF @DoesExist=1
				BEGIN
					RAISERROR('The specified new costcenter number does already exist!',16,1)
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
			UPDATE [CostCenters]
			SET [CostCenterNo]=@CostCenterNo,
				[CostCenterName]=@CostCenterName,
				[CostCenterDescription]=@CostCenterDescription,
				[IDCurrency]=@IDCurrency,
				[IncentiveIndicatorSynonym]=@IncentiveIndicatorSynonym,
				[IncentiveWageSynonym]=@IncentiveWageSynonym,
				[IncentiveIndicatorDimension]=@IncentiveIndicatorDimension,
				[IncentiveIndicatorPrecision]=@IncentiveIndicatorPrecision,
				[UseFixValuedBonus]=@UseFixValuedBonus,
				[IncentiveIndicatorFactor]=@IncentiveIndicatorFactor,
				[BaseValuePrecision]=@BaseValuePrecision,
				[BaseValueSynonym]=@BaseValueSynonym,
				[LastEdited]=@Now
			WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=IDSubsidiary
			-- Aus Kompatiblitätsgründen zur Historienpflege für die Enterprise
			-- muss die ID zurückgegeben werden.
			Set @IDCostCenterNew = @IDCostCenter
		END

	EXEC AddToFunctionLog @IDSubsidiary, 'CostCenter: Edited', @LastEditedByIDUser, @Now
		

