CREATE PROCEDURE dbo.BonusList_FromBaseCostCenter
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDBaseCostCenter UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@IDUserCalled UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDBonusListsBase UNIQUEIDENTIFIER,
			@IDBonusLists UNIQUEIDENTIFIER,
			@Now datetime

	SET @Now=GetDate()
	
	-- @IDBonusList der Basiskostenstelle ermitteln
	SELECT @IDBonusListsBase=[IDBonusLists] FROM [BonusLists] 
	WHERE [IDSubsidiary]=@IDSubsidiary 
	AND [IDCostCenter]=@IDBaseCostCenter
	
		-- Basis in BonusLists-Tabelle anlegen
	INSERT INTO [BonusLists] ([IDSubsidiary], [IDCostCenter])
	VALUES (@IDSubsidiary, @IDCostCenter)
	
	--SET @IDBonusLists=SCOPE_IDEnTITY()

	--INSERT INTO [BonusList] 
	--SELECT IDSubsidiary, @IDBonusLists AS IDBonusLists, DegreeOfTime, Percentage, AbsoluteValue, @Now as DateCreated
	--FROM BonusList
	--WHERE (IDSubsidiary = @IDSubsidiary) AND (IDBonusLists = @IDBonusListsBase)
	
	EXEC AddToFunctionLog @IDSubsidiary, 'BonusList: Created based on base cost center', @IDUserCalled, @Now
	
	
	
	
	                   
	
	
