CREATE PROCEDURE dbo.ProductionDataItems_Add
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDProductionData UNIQUEIDENTIFIER,
	@IDLabourValue UNIQUEIDENTIFIER,
	@IDArticle UNIQUEIDENTIFIER,
	@Amount float,
	@AmountViaInterface float,
	@OrdinalNumber int,
	@ManuallyEdited bit,
	@IDProductionDataItem UNIQUEIDENTIFIER OUTPUT
	
	WITH EXECUTE AS CALLER
	AS
	
	INSERT INTO [ProductionDataItems] 
			([IDSubsidiary],[IDProductionData], [IDLabourValue],[IDArticle],
			[Amount], [AmountViaInterface], [OrdinalNumber], [ManuallyEdited])
	VALUES (@IDSubsidiary, @IDProductionData, @IDLabourValue, 
	        @IDArticle, @Amount, @AmountViaInterface, @OrdinalNumber, @ManuallyEdited)
	        
	--SET @IDProductionDataItem=SCOPE_IDENTITY()
	 
		
		  
			
