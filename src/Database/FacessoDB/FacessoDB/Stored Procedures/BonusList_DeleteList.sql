CREATE PROCEDURE dbo.BonusList_DeleteList
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@IDUserCalled UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS

	DECLARE @IDBonusLists UNIQUEIDENTIFIER
	
	-- @IDBonusList aus Kostenstelle ermitteln
	SELECT @IDBonusLists=[IDBonusLists] FROM [BonusLists] 
	WHERE [IDSubsidiary]=@IDSubsidiary 
	AND [IDCostCenter]=@IDCostCenter

	
	DELETE [BonusList] WHERE [IDSubsidiary]=@IDSubsidiary AND [IDBonusLists]=@IDBonusLists
	DELETE [BonusLists] WHERE [IDSubsidiary]=@IDSubsidiary AND [IDCostCenter]=@IDCostCenter
	
	DECLARE @Now datetime
	SET @Now=GetDate()
	
	EXEC AddToFunctionLog @IDSubsidiary, 'BonusList: List deleted', @IDUserCalled, @Now
	
	
	
	
	
	
	                   
	
	
