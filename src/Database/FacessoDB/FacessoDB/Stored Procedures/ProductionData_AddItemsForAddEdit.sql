CREATE PROCEDURE dbo.ProductionData_AddItemsForAddEdit
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDProductionDataItem UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@IDProductionData UNIQUEIDENTIFIER,
	@IDLabourValue UNIQUEIDENTIFIER,
	@IDArticle UNIQUEIDENTIFIER,
	@Amount float,
	@AmountViaInterface float,
	@OrdinalNumber int,
	@ManuallyEdited bit
	
	WITH EXECUTE AS CALLER
	AS
	
	INSERT INTO [ProductionDataItemsForInsert] 
			([IDSubsidiary],[IDProductionDataItem], [IDUser], 
			 [IDProductionData], [IDLabourValue],[IDArticle],
			 [Amount], [AmountViaInterface], [OrdinalNumber], [ManuallyEdited])
	VALUES (@IDSubsidiary, @IDProductionDataItem, @IDUser, 
			@IDProductionData, @IDLabourValue, 
	        @IDArticle, @Amount, @AmountViaInterface, @OrdinalNumber, @ManuallyEdited)
		  
		  
	
		
	 
		
		  
			
