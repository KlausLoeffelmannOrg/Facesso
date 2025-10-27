CREATE PROCEDURE dbo.LabourValues_Add 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@LabourValueNumber int,
	@LabourValueName nvarchar(100),
	@LabourValueDescription nvarchar(MAX),
	@TeHMin float,
	@Dimension nvarchar(50),
	@IsActive bit,
	@WasCurrentTo datetime,
	@CreatedByIDUser UNIQUEIDENTIFIER,
	@IDLabourValueNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDLabourValueInternal int
	DECLARE @Now DateTime
	
	SET @Now=GetDate()
	
	-- Verhindern, dass doppelte Kostenstellennummern existieren können!
	IF EXISTS(SELECT * FROM  [LabourValues] 
					   WHERE [IDSubsidiary]   = @IDSubsidiary 
					   AND   [LabourValueNumber]   = @LabourValueNumber)
		SET @IDLabourValueNew = null
	ELSE
		BEGIN
			
			BEGIN TRANSACTION

			-- Letzte interne ID ermitteln
			SELECT @IDLabourValueInternal=MAX([IDLabourValueInternal]) 
						FROM  [LabourValues] 
						WHERE [IDSubsidiary] = @IDSubsidiary
			
			-- um eins erhöhen, das ist die neue interne ID
			IF @IDLabourValueInternal IS NULL 
				SET @IDLabourValueInternal = 1
			ELSE
				SET @IDLabourValueInternal = @IDLabourValueInternal + 1

			-- neuen Arbeitswert in Tabelle einfügen
			INSERT INTO [LabourValues]
				([IDSubsidiary], [IDCostCenter], [IDLabourValueInternal], [IsCurrent],
				[LabourValueNumber], [LabourValueName], [LabourValueDescription],
				[TeHMin], [Dimension], [IsActive], 
				[WasCurrentFrom], [WasCurrentTo], [LastEdited])
			VALUES
				(@IDSubsidiary, @IDCostCenter, @IDLabourValueInternal, 1, 
				@LabourValueNumber, @LabourValueName, @LabourValueDescription, 
				@TeHMin, @Dimension, @IsActive, 
				@Now, @WasCurrentTo, @Now)
			
			COMMIT TRANSACTION
			--SET @IDLabourValueNew = SCOPE_IDENTITY()
			
			EXEC AddToFunctionLog @IDSubsidiary, 'LabourValue: Added new labourvalue', @CreatedByIDUser, @Now
		END
		
		  
			
