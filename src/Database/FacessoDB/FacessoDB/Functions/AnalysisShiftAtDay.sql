CREATE FUNCTION dbo.AnalysisShiftAtDay
(@IDSubsidiary UNIQUEIDENTIFIER,
@IDWorkGroupInternal int,
@ProductionDate datetime,
@Shift tinyint)
	
RETURNS @ReturnTable TABLE
(TotalAttendanceTime float,
 TotalDownTime float,
 TotalWorkBreak float,
 TotalWorkingTime float,
 TotalReferenceIWT float,
 TotalEffectiveIWT float,
 TotalEffectiveAdjIWT float,
 DegreeOfTime float,
 DegreeOfTimeAdj float)

AS
	BEGIN
	
		SET @ProductionDate=convert(char(8),@ProductionDate,112)
		
		DECLARE @TotalAttendanceTime float,
				@TotalDownTime float,
				@TotalWorkBreak float,
				@TotalWorkingTime float,
		        @TotalReferenceIWT float,
				@TotalEffectiveIWT float,
				@TotalEffectiveAdjIWT float,
				@DegreeOfTime float,
				@DegreeOfTimeAdj float
		
		-- Referenz (Soll-Minuten) errechnen
		SELECT @TotalReferenceIWT=[TotalReferenceIWT] FROM [ProductionData]
		WHERE [IDSubsidiary]=@IDSubsidiary AND 
		[IDWorkGroupInternal]=@IDWorkGroupInternal AND
		[ProductionDate]=@ProductionDate AND [Shift]=@Shift
		
		-- Effektiv (IST-Minuten) errechnen
		SELECT @TotalAttendanceTime=Sum(AttendanceTime),
			   @TotalDownTime=Sum(DownTime),
			   @TotalWorkBreak=Sum(WorkBreak),
			   @TotalWorkingTime=Sum(WorkingTime),
			   @TotalEffectiveIWT=Sum(IncentiveWageTime),
			   @TotalEffectiveAdjIWT=Sum(IncentiveWageTime-(IncentiveWageTime*Handicap/100))
			   FROM [TimeLog]
		WHERE [IDSubsidiary]=@IDSubsidiary AND 
		[IDWorkGroupInternal]=@IDWorkGroupInternal AND
		[ProductionDate]=@ProductionDate AND [Shift]=@Shift
		
		if @TotalEffectiveIWT IS NULL 
			BEGIN
				SET @TotalAttendanceTime=0
				SET @TotalDownTime=0
				SET @TotalWorkBreak=0
				SET @TotalWorkingTime=0
				SET @TotalReferenceIWT=0
				SET @TotalEffectiveIWT=0
				SET @TotalEffectiveAdjIWT=0
				SET @DegreeOfTime=-2
				SET @DegreeOfTimeAdj=-2
			END
		ELSE
			IF @TotalEffectiveIWT=0 
				BEGIN
					SET @DegreeOfTime=-1
					SET @DegreeOfTimeAdj=-1
				END
			ELSE
				BEGIN
					SET @DegreeOfTime=(@TotalReferenceIWT/@TotalEffectiveIWT)*100
					SET @DegreeOfTimeAdj=(@TotalReferenceIWT/@TotalEffectiveAdjIWT)*100
				END
			
		INSERT INTO @ReturnTable
		VALUES (@TotalAttendanceTime, @TotalDownTime, @TotalWorkBreak,
		        @TotalWorkingTime, @TotalReferenceIWT, @TotalEffectiveIWT,
		        @TotalEffectiveAdjIWT, @DegreeOfTime, @DegreeOfTimeAdj)
		        
		RETURN
	END
