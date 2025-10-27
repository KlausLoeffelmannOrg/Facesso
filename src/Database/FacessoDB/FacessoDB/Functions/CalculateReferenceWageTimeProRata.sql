CREATE FUNCTION dbo.CalculateReferenceWageTimeProRata
(@TotalReferenceIWT float,
@TotalEffectiveIWT float,
@IncentiveWageTime float)
	
RETURNS float

AS
	BEGIN
	
		DECLARE @Result float

		IF @TotalEffectiveIWT=0
			SET @Result=-1
		ELSE
			SET @Result=@TotalReferenceIWT/@TotalEffectiveIWT*@IncentiveWageTime	

		RETURN(@Result)

	END
