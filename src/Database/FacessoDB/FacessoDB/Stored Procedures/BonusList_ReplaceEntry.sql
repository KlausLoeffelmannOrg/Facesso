CREATE PROCEDURE dbo.BonusList_ReplaceEntry
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@DegreeOfTime float,
	@Percentage float,
	@AbsoluteValue money,
	@IDUserCalled UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDBonusLists UNIQUEIDENTIFIER
	
	-- @IDBonusList aus Kostenstelle ermitteln
	SELECT @IDBonusLists=[IDBonusLists] FROM [BonusLists] 
	WHERE [IDSubsidiary]=@IDSubsidiary 
	AND [IDCostCenter]=@IDCostCenter

	
	Update [BonusList] 
				SET		[Percentage]=@Percentage,
						[AbsoluteValue]=@AbsoluteValue
						
				WHERE
	                    [IDSubsidiary]=@IDSubsidiary AND
	                    [IDBonusLists]=@IDBonusLists AND
	                    [DegreeOfTime]=@DegreeOfTime
	
	DECLARE @Now datetime
	SET @Now=GetDate()
	EXEC AddToFunctionLog @IDSubsidiary, 'BonusList: Entry deleted', @IDUserCalled, @Now
	                   
	
	
