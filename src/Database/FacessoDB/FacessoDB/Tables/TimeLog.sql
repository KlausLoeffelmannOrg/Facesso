CREATE TABLE [dbo].[TimeLog] (
    [IDTimeLog]                UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]             UNIQUEIDENTIFIER        NOT NULL,
    [IDWorkGroup]              UNIQUEIDENTIFIER        NOT NULL,
    [IDWorkGroupInternal]      INT        NOT NULL,
    [IDEmployee]               UNIQUEIDENTIFIER        NOT NULL,
    [IDEmployeeInternal]       INT        NOT NULL,
    [IDBonusLists]             UNIQUEIDENTIFIER        NOT NULL,
    [IDWageGroup]              UNIQUEIDENTIFIER        NOT NULL,
    [Shift]                    TINYINT    NOT NULL,
    [ProductionDate]           DATETIME   NOT NULL,
    [ShiftStart]               DATETIME   NOT NULL,
    [ShiftStartViaInterface]   DATETIME   NULL,
    [ShiftEnd]                 DATETIME   NOT NULL,
    [ShiftEndViaInterface]     DATETIME   NULL,
    [WorkBreak]                INT        CONSTRAINT [DF_TimeLog_WorkBreak] DEFAULT ((-1)) NOT NULL,
    [WorkBreakViaInterface]    INT        NULL,
    [DownTime]                 INT        CONSTRAINT [DF_TimeLog_DownTime] DEFAULT ((-1)) NOT NULL,
    [DownTimeViaInterface]     INT        NULL,
    [Handicap]                 FLOAT (53) NOT NULL,
    [AttendanceTime]           INT        CONSTRAINT [DF_TimeLog_AttendanceTime] DEFAULT ((-1)) NOT NULL,
    [WorkingTime]              INT        CONSTRAINT [DF_TimeLog_WorkingTime] DEFAULT ((-1)) NOT NULL,
    [IncentiveWageTime]        FLOAT (53) CONSTRAINT [DF_TimeLog_IncentiveWageTime] DEFAULT ((-1)) NOT NULL,
    [IncentiveWageTimeAdj]     FLOAT (53) CONSTRAINT [DF_TimeLog_IncentiveWageTimeAdj] DEFAULT ((-1)) NOT NULL,
    [DegreeOfTime]             FLOAT (53) CONSTRAINT [DF_TimeLog_DegreeOfTime] DEFAULT ((-1)) NOT NULL,
    [DegreeOfTimeAdj]          FLOAT (53) CONSTRAINT [DF_TimeLog_DegreeOfTimeAdj] DEFAULT ((-1)) NOT NULL,
    [ReferenceWageTimeProRata] FLOAT (53) CONSTRAINT [DF_TimeLog_ReferenceWageTimeProRata] DEFAULT ((-1)) NOT NULL,
    [InsertedByInterface]      BIT        NOT NULL,
    [ManuallyEdited]           BIT        NOT NULL,
    [IsSuspended]              BIT        NOT NULL,
    [LastEdited]               DATETIME   CONSTRAINT [DF_TimeLog_DateEdited] DEFAULT (getdate()) NOT NULL,
    [EditedByIDUser]           UNIQUEIDENTIFIER        NOT NULL,
    CONSTRAINT [PK_TimeLog] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDTimeLog] ASC),
    CONSTRAINT [FK_TimeLog_Employee] FOREIGN KEY ([IDSubsidiary], [IDEmployee]) REFERENCES [dbo].[Employees] ([IDSubsidiary], [IDEmployee]),
    CONSTRAINT [FK_TimeLog_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary]),
    CONSTRAINT [FK_TimeLog_WorkGroup] FOREIGN KEY ([IDSubsidiary], [IDWorkGroup]) REFERENCES [dbo].[WorkGroups] ([IDSubsidiary], [IDWorkGroup])
);


GO



CREATE TRIGGER dbo.OnTimeLog_Delete
ON dbo.TimeLog
FOR DELETE
AS

-- Wird aufgerufen, wenn sich etwas an einem ProductionData-Eintrag geändert hat
DECLARE	@IDSubsidiary UNIQUEIDENTIFIER,
		@IDWorkGroup UNIQUEIDENTIFIER,
		@Shift tinyint,
		@ProductionDate datetime,
		@TotalReferenceIWT float,
		@AttendanceTime float,
		@IDWorkGroupInternal int
		
BEGIN
	SELECT DISTINCT	@IDWorkGroup=IDWorkGroup,
					@Shift=Shift,
					@ProductionDate=ProductionDate,
					@IDSubsidiary=IDSubsidiary
					FROM deleted
					
	IF @IDWorkGroup IS NOT NULL
		BEGIN
		
			SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)

			-- Erst schauen, ob es Mengendaten gibt
			SELECT @TotalReferenceIWT=TotalReferenceIWT FROM ProductionData
			WHERE	[IDSubsidiary]=@IDSubsidiary AND 
					[IDWorkGroupInternal]=@IDWorkGroupInternal AND
					[ProductionDate]=@ProductionDate AND [Shift]=@Shift AND
					TotalReferenceIWT>-1
			
			-- Nur Dinge tun, wenn es Mengendaten gibt,
			-- dann nämlich die Zeitdifferenzen aktualisieren
			IF @TotalReferenceIWT IS NOT NULL 
				BEGIN

					DECLARE @TotalAttendanceTime float,
							@TotalDownTime float,
							@TotalWorkBreak float,
							@TotalWorkingTime float,
							@TotalEffectiveIWT float,
							@TotalEffectiveAdjIWT float,
							@DegreeOfTime float,
							@DegreeOfTimeAdj float
					
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
							
					-- Update Ergebnisse ProductionData
					UPDATE ProductionData
					SET TotalEffectiveIWT=@TotalEffectiveIWT,
						TotalEffectiveIWTADj=@TotalEffectiveAdjIWT,
						TotalDownTime=@TotalDownTime,
						TotalWorkBreakTime=@TotalWorkBreak,
						DegreeOfTime=@DegreeOfTime,
						DegreeOfTimeAdj=@DegreeOfTimeAdj
					WHERE [IDSubsidiary]=@IDSubsidiary AND 
					[IDWorkGroupInternal]=@IDWorkGroupInternal AND
					[ProductionDate]=@ProductionDate AND [Shift]=@Shift
						
					
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
				END
		END
END

GO



CREATE TRIGGER dbo.OnTimeLog_InsertUpdate
ON dbo.TimeLog
FOR INSERT, UPDATE
AS

-- Wird aufgerufen, wenn sich etwas an einem ProductionData-Eintrag geändert hat
DECLARE	@IDSubsidiary UNIQUEIDENTIFIER,
		@IDWorkGroup UNIQUEIDENTIFIER,
		@Shift tinyint,
		@ProductionDate datetime,
		@TotalReferenceIWT float,
		@AttendanceTime float,
		@IDWorkGroupInternal int
		
IF UPDATE(ShiftStart) OR UPDATE(ShiftEnd) OR UPDATE(WorkBreak) OR UPDATE(DownTime) OR
   UPDATE(Handicap)

	BEGIN
		SELECT DISTINCT	@IDWorkGroup=IDWorkGroup,
						@Shift=Shift,
						@ProductionDate=ProductionDate,
						@IDSubsidiary=IDSubsidiary
						FROM inserted
						
		IF @IDWorkGroup IS NOT NULL
			BEGIN
			
				SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)

				-- Erst schauen, ob es Mengendaten gibt
				SELECT @TotalReferenceIWT=TotalReferenceIWT FROM ProductionData
				WHERE	[IDSubsidiary]=@IDSubsidiary AND 
						[IDWorkGroupInternal]=@IDWorkGroupInternal AND
						[ProductionDate]=@ProductionDate AND [Shift]=@Shift AND
						TotalReferenceIWT>-1
				
				-- Keine Mengendaten, dann nur die Zeitdifferenzen aktualisieren
				IF @TotalReferenceIWT IS NULL 
					UPDATE TimeLog
					SET
						@AttendanceTime=DATEDIFF(mi,tl.ShiftStart, tl.ShiftEnd),
						AttendanceTime=@AttendanceTime,
						WorkingTime=@AttendanceTime-tl.WorkBreak, 
						IncentiveWageTime=@AttendanceTime-tl.WorkBreak-tl.DownTime,
						IncentiveWageTimeAdj=@AttendanceTime-tl.WorkBreak-tl.DownTime-(@AttendanceTime-tl.WorkBreak-tl.DownTime)*tl.Handicap/100,
						DegreeOfTime=-2,
						DegreeOfTimeAdj=-2,
						ReferenceWageTimeProRata=-2
					FROM TimeLog tl			
					WHERE [IDSubsidiary]=@IDSubsidiary AND 
					[IDWorkGroupInternal]=@IDWorkGroupInternal AND
					[ProductionDate]=@ProductionDate AND [Shift]=@Shift
				
				-- Es gibt Mengendaten, dann die ganze Chose aktualisieren
				ELSE
					BEGIN

						DECLARE @TotalAttendanceTime float,
								@TotalDownTime float,
								@TotalWorkBreak float,
								@TotalWorkingTime float,
								@TotalEffectiveIWT float,
								@TotalEffectiveAdjIWT float,
								@DegreeOfTime float,
								@DegreeOfTimeAdj float
						
						-- die neuen Einzelsummen bilden		
						
						UPDATE TimeLog
						SET
							@AttendanceTime=DATEDIFF(mi,tl.ShiftStart, tl.ShiftEnd),
							AttendanceTime=@AttendanceTime,
							WorkingTime=@AttendanceTime-tl.WorkBreak, 
							IncentiveWageTime=@AttendanceTime-tl.WorkBreak-tl.DownTime,
							IncentiveWageTimeAdj=@AttendanceTime-tl.WorkBreak-tl.DownTime-(@AttendanceTime-tl.WorkBreak-tl.DownTime)*tl.Handicap/100
						FROM TimeLog tl			
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
								
						-- Update Ergebnisse ProductionData
						UPDATE ProductionData
						SET TotalEffectiveIWT=@TotalEffectiveIWT,
							TotalEffectiveIWTADj=@TotalEffectiveAdjIWT,
							TotalDownTime=@TotalDownTime,
							TotalWorkBreakTime=@TotalWorkBreak,
							DegreeOfTime=@DegreeOfTime,
							DegreeOfTimeAdj=@DegreeOfTimeAdj
						WHERE [IDSubsidiary]=@IDSubsidiary AND 
						[IDWorkGroupInternal]=@IDWorkGroupInternal AND
						[ProductionDate]=@ProductionDate AND [Shift]=@Shift
							
						
						UPDATE TimeLog
						SET
							@AttendanceTime=DATEDIFF(mi,tl.ShiftStart, tl.ShiftEnd),
							AttendanceTime=@AttendanceTime,
							WorkingTime=@AttendanceTime-tl.WorkBreak, 
							IncentiveWageTime=@AttendanceTime-tl.WorkBreak-tl.DownTime,
							IncentiveWageTimeAdj=@AttendanceTime-tl.WorkBreak-tl.DownTime-(@AttendanceTime-tl.WorkBreak-tl.DownTime)*tl.Handicap/100,
							DegreeOfTime=@DegreeOfTime,
							DegreeOfTimeAdj=@DegreeOfTimeAdj,
							ReferenceWageTimeProRata=dbo.CalculateReferenceWageTimeProRata(@TotalReferenceIWT, @TotalEffectiveAdjIWT, tl.IncentiveWageTime)
						FROM TimeLog tl			
						WHERE [IDSubsidiary]=@IDSubsidiary AND 
						[IDWorkGroupInternal]=@IDWorkGroupInternal AND
						[ProductionDate]=@ProductionDate AND [Shift]=@Shift
					END
			END
	END
