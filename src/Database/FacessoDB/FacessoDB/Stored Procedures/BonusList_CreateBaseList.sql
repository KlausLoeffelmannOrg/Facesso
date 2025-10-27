CREATE PROCEDURE dbo.BonusList_CreateBaseList
	@IDCostCenter UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUserCreated UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS

	-- Basis in BonusLists-Tabelle anlegen
	INSERT INTO [BonusLists] ([IDSubsidiary], [IDCostCenter])
	VALUES (@IDSubsidiary, @IDCostCenter)
	
	DECLARE @DegreeOfTime float,
			@Percentage float
	
	SET @DegreeOfTime=75
	SET @Percentage=100
	
	WHILE @DegreeOfTime<100 BEGIN
		exec BonusList_AddEntry @IDSubsidiary, @IDCostCenter, @DegreeOfTime, @Percentage, 0, @IDUserCreated
		SET @DegreeOfTime=@DegreeOfTime+1
	END
	
	WHILE @DegreeOfTime<115 BEGIN
		exec BonusList_AddEntry @IDSubsidiary, @IDCostCenter, @DegreeOfTime, @Percentage, 0, @IDUserCreated
		SET @DegreeOfTime=@DegreeOfTime+1
		SET @Percentage=@Percentage+1
	END

	WHILE @DegreeOfTime<135 BEGIN
		exec BonusList_AddEntry @IDSubsidiary, @IDCostCenter, @DegreeOfTime, @Percentage, 0, @IDUserCreated
		SET @DegreeOfTime=@DegreeOfTime+1
		SET @Percentage=@Percentage+0.5
	END
	
	WHILE @DegreeOfTime<150 BEGIN
		exec BonusList_AddEntry @IDSubsidiary, @IDCostCenter, @DegreeOfTime, @Percentage, 0, @IDUserCreated
		SET @DegreeOfTime=@DegreeOfTime+1
	END
	
	Declare @Now datetime
	SET @Now=GetDate()
	EXEC AddToFunctionLog @IDSubsidiary, 'BonusList: Baselist created', @IDUserCreated, @Now
	

	
		