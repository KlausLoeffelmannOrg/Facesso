CREATE PROCEDURE dbo.CostCenters_Add 

	@IDSubsidiary UNIQUEIDENTIFIER,
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
	@WasCurrentTo datetime,
	@CreatedByIDUser UNIQUEIDENTIFIER,
	@IDCostCenterNew UNIQUEIDENTIFIER OUTPUT
	

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDCostCenterInternal int
	DECLARE @Now DateTime
	
	SET @Now=GetDate()
	
	-- Verhindern, dass doppelte Kostenstellennummern existieren können!
	IF EXISTS(SELECT * FROM  [CostCenters] 
					   WHERE [IDSubsidiary]   = @IDSubsidiary 
					   AND   [CostCenterNo]   = @CostCenterNo)
		SET @IDCostCenterNew = null
	ELSE
		BEGIN
			
			BEGIN TRANSACTION

			-- Letzte interne ID ermitteln
			SELECT @IDCostCenterInternal=MAX([IDCostCenterInternal]) 
						FROM  [CostCenters] 
						WHERE [IDSubsidiary] = @IDSubsidiary
			
			-- um eins erhöhen, das ist die neue interne ID
			SET @IDCostCenterInternal = @IDCostCenterInternal + 1

			-- neue Kostenstelle in Tabelle einfügen
			INSERT INTO [CostCenters]
				([IDSubsidiary], [IDCostCenterInternal], [IsCurrent],
				[CostCenterNo], [CostCenterName], [CostCenterDescription],
				[IDCurrency], [IncentiveIndicatorSynonym], [IncentiveWageSynonym], [IncentiveIndicatorDimension], 
				[IncentiveIndicatorPrecision], [UseFixValuedBonus], [IncentiveIndicatorFactor],
				[BaseValuePrecision], [BaseValueSynonym],
				[WasCurrentFrom], [WasCurrentTo])
			VALUES
				(@IDSubsidiary, @IDCostCenterInternal, 1, @CostCenterNo,
				@CostCenterName, @CostCenterDescription, 
				@IDCurrency, @IncentiveIndicatorSynonym, @IncentiveWageSynonym, @IncentiveIndicatorDimension, 
				@IncentiveIndicatorPrecision, @UseFixValuedBonus, @IncentiveIndicatorFactor,
				@BaseValuePrecision, @BaseValueSynonym,
				@Now, @WasCurrentTo)
			
			COMMIT TRANSACTION
			--SET @IDCostCenterNew = SCOPE_IDENTITY()
			
			EXEC AddToFunctionLog @IDSubsidiary, 'CostCenter: Added new', @CreatedByIDUser, @Now
		END
		
		  
			
