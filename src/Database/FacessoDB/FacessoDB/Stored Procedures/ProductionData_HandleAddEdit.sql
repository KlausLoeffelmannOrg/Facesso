CREATE PROCEDURE dbo.ProductionData_HandleAddEdit
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDProductionData UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@ReturnResultSet bit
	
	WITH EXECUTE AS CALLER
	AS
	
	-- Neue Werte werden eingefügt
	INSERT	[ProductionDataItems] ([IDSubsidiary],[IDProductionData],[IDLabourValue],
			[IDArticle],[Amount],[AmountViaInterface],[OrdinalNumber],[ManuallyEdited])
	SELECT	[IDSubsidiary],[IDProductionData],[IDLabourValue],
			[IDArticle],[Amount],[AmountViaInterface],[OrdinalNumber],[ManuallyEdited]
	FROM	[ProductionDataItemsForInsert]
	WHERE	[IDSubsidiary]=@IDSubsidiary AND
			[IDProductionData]=@IDProductionData AND
			[IDUser]=@IDUser AND
			[IDProductionDataItem] = null
			
	-- Vorhandene Werte werden aktualisiert
	-- Das ganze je nachdem, ob eine gültige ID (>0) angegeben wurde oder nicht (<1)
	UPDATE    ProductionDataItems
	SET              Amount = ProductionDataItemsForInsert.Amount, AmountViaInterface=ProductionDataItemsForInsert.AmountViaInterface,
					      OrdinalNumber = ProductionDataItemsForInsert.OrdinalNumber, 
	                      ManuallyEdited = ProductionDataItemsForInsert.ManuallyEdited
	FROM         ProductionDataItems INNER JOIN
	                      ProductionDataItemsForInsert ON ProductionDataItems.IDSubsidiary = ProductionDataItemsForInsert.IDSubsidiary AND 
	                      ProductionDataItems.IDProductionData = ProductionDataItemsForInsert.IDProductionData AND 
	                      ProductionDataItems.IDProductionDataItem = ProductionDataItemsForInsert.IDProductionDataItem
	WHERE     (ProductionDataItems.IDSubsidiary = @IDSubsidiary) AND (ProductionDataItems.IDProductionData = @IDProductionData) AND 
	                      (ProductionDataItemsForInsert.IDUser = @IDUser)
	
	-- Hilfsdaten wieder löschen
	DELETE FROM [ProductionDataItemsForInsert]
	WHERE [IDSubsidiary]=@IDSubsidiary AND
		  [IDProductionData]=@IDProductionData AND
		  [IDUser]=@IDUser
			
	-- Ergebnissatz im Bedarfsfall zurückliefern
	IF @ReturnResultSet='true'
		SELECT * FROM [ProductionDataItems] WHERE [IDSubsidiary]=@IDSubsidiary AND
												[IDProductionData]=@IDProductionData
											ORDER BY [OrdinalNumber]
	

	
		  
		  
	
		
	 
		
		  
			
