CREATE PROCEDURE dbo.TimeLog_UpdateValuesForShiftDate
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint,
	@TotalReferenceIWT float

AS
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	
	DECLARE @TotalAttendanceTime float,
			@TotalDownTime float,
			@TotalWorkBreak float,
			@TotalWorkingTime float,
			@TotalEffectiveIWT float,
			@TotalEffectiveAdjIWT float,
			@DegreeOfTime float,
			@DegreeOfTimeAdj float,
			@IDWorkGroupInternal int
	
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)
	
	-- Referenz (Soll-Minuten) im Bedarfsfall errechnen
	IF @TotalReferenceIWT IS NULL
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

	IF @TotalEffectiveIWT IS NULL 
		BEGIN
			SET @TotalAttendanceTime=-1
			SET @TotalDownTime=-1
			SET @TotalWorkBreak=-1
			SET @TotalWorkingTime=-1
			SET @TotalReferenceIWT=-1
			SET @TotalEffectiveIWT=-1
			SET @TotalEffectiveAdjIWT=-1
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
		
	-- UPDATE ProductionData
	
	DECLARE @AttendanceTime float
		
	UPDATE TimeLog
	SET
		@AttendanceTime=DATEDIFF(mi,tl.ShiftStart, tl.ShiftEnd),
		AttendanceTime=@AttendanceTime,
		WorkingTime=@AttendanceTime-tl.WorkBreak, 
		IncentiveWageTime=@AttendanceTime-tl.WorkBreak-tl.DownTime,
		IncentiveWageTimeAdj=@AttendanceTime-tl.WorkBreak-tl.DownTime-(@AttendanceTime-tl.WorkBreak-tl.DownTime)*tl.Handicap/100,
		DegreeOfTime=@DegreeOfTime,
		DegreeOfTimeAdj=@DegreeOfTimeAdj,
		ReferenceWageTimeProRata=dbo.CalculateReferenceWageTimeProRata(@TotalReferenceIWT, @TotalEffectiveIWT, tl.IncentiveWageTime)
	FROM TimeLog tl			
	WHERE [IDSubsidiary]=@IDSubsidiary AND 
	[IDWorkGroupInternal]=@IDWorkGroupInternal AND
	[ProductionDate]=@ProductionDate AND [Shift]=@Shift

