CREATE FUNCTION dbo.DegreeOfTimeAbsolute
(@IDSubsidiary UNIQUEIDENTIFIER,
@IDWorkGroup UNIQUEIDENTIFIER,
@ProductionDate datetime,
@shift tinyint)
	
RETURNS float

AS
	BEGIN
	
		SET @ProductionDate=convert(char(8),@ProductionDate,112)
		
		DECLARE @TotalEffectiveIWT float,
		        @TotalReferenceIWT float,
		        @ReturnValue float,
		        @IDWorkGroupInternal int
		
		SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)
		
		-- Referenz (Soll-Minuten) errechnen
		SELECT @TotalReferenceIWT=[TotalReferenceIWT] FROM [ProductionData]
		WHERE [IDSubsidiary]=@IDSubsidiary AND 
		[IDWorkGroupInternal]=@IDWorkGroupInternal AND
		[ProductionDate]=@ProductionDate AND [Shift]=Shift
		
		-- Effektiv (IST-Minuten) errechnen
		SELECT @TotalEffectiveIWT=Sum(IncentiveWageTime) FROM [TimeLog]
		WHERE [IDSubsidiary]=@IDSubsidiary AND 
		[IDWorkGroupInternal]=@IDWorkGroupInternal AND
		[ProductionDate]=@ProductionDate AND [Shift]=Shift
		
		if @TotalEffectiveIWT=0
			SET @ReturnValue=-1
		ELSE
			SET @ReturnValue=(@TotalReferenceIWT/@TotalEffectiveIWT)*100
		        
		RETURN (@ReturnValue)
	END
