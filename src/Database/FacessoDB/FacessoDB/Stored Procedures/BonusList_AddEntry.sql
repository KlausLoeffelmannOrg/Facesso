CREATE PROCEDURE dbo.BonusList_AddEntry
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@DegreeOfTime float,
	@Percentage float,
	@AbsoluteValue money,
	@IDUserCreated UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS

	DECLARE @IDBonusLists UNIQUEIDENTIFIER,
			@Now datetime
			
	-- @IDBonusList aus Kostenstelle ermitteln
	SELECT @IDBonusLists=[IDBonusLists] FROM [BonusLists] 
	WHERE [IDSubsidiary]=@IDSubsidiary 
	AND [IDCostCenter]=@IDCostCenter
	
	INSERT INTO [BonusList] ([IDSubsidiary], [IDBonusLists], 
	                         [DegreeOfTime], [Percentage], 
	                         [AbsoluteValue])
	                  VALUES
	                  (@IDSubsidiary, @IDBonusLists, @DegreeOfTime,
	                   @Percentage, @AbsoluteValue)

	SET @Now=GetDate()
	EXEC AddToFunctionLog @IDSubsidiary, 'BonusList: Entry added', @IDUserCreated, @Now
	                   
	
	
