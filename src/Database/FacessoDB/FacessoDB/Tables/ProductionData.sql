CREATE TABLE [dbo].[ProductionData] (
    [IDProductionData]     UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]         UNIQUEIDENTIFIER        NOT NULL,
    [IDWorkGroup]          UNIQUEIDENTIFIER        NOT NULL,
    [IDWorkGroupInternal]  INT        NOT NULL,
    [IDEmployee]           UNIQUEIDENTIFIER        CONSTRAINT [DF_ProductionData_IDEmployee] DEFAULT (NULL) NOT NULL,
    [ProductionDate]       DATETIME   NOT NULL,
    [Shift]                TINYINT    NOT NULL,
    [TotalReferenceIWT]    FLOAT (53) CONSTRAINT [DF_ProductionData_TotalReferenceIWT] DEFAULT ((-1)) NOT NULL,
    [TotalEffectiveIWT]    FLOAT (53) CONSTRAINT [DF_ProductionData_TotalEffectiveIWT] DEFAULT ((-1)) NOT NULL,
    [TotalEffectiveIWTAdj] FLOAT (53) CONSTRAINT [DF_ProductionData_TotalEffectiveIWTAdj] DEFAULT ((-1)) NOT NULL,
    [TotalDownTime]        FLOAT (53) CONSTRAINT [DF_ProductionData_TotalDownTime] DEFAULT ((-1)) NOT NULL,
    [TotalWorkBreakTime]   FLOAT (53) CONSTRAINT [DF_ProductionData_TotalWorkBreakTime] DEFAULT ((-1)) NOT NULL,
    [DegreeOfTime]         FLOAT (53) CONSTRAINT [DF_ProductionData_DegreeOfTime] DEFAULT ((-1)) NOT NULL,
    [DegreeOfTimeAdj]      FLOAT (53) CONSTRAINT [DF_ProductionData_DegreeOfTimeAdj] DEFAULT ((-1)) NOT NULL,
    [InsertedByInterface]  BIT        NOT NULL,
    [IsSuspended]          BIT        NOT NULL,
    [LastEdited]           DATETIME   CONSTRAINT [DF_ProductionData_LastEdited] DEFAULT (getdate()) NOT NULL,
    [LastEditedByIDUser]   UNIQUEIDENTIFIER        NOT NULL,
    CONSTRAINT [PK_ProductionData] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDProductionData] ASC),
    CONSTRAINT [FK_ProductionData_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary]),
    CONSTRAINT [FK_ProductionData_WorkGroups] FOREIGN KEY ([IDSubsidiary], [IDWorkGroup]) REFERENCES [dbo].[WorkGroups] ([IDSubsidiary], [IDWorkGroup])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccessData]
    ON [dbo].[ProductionData]([IDSubsidiary] ASC, [ProductionDate] ASC, [Shift] ASC, [IDWorkGroup] ASC);


GO



CREATE TRIGGER dbo.OnProductionData_InsertUpdate
ON dbo.ProductionData 
FOR INSERT, UPDATE
AS

-- Wird aufgerufen, wenn sich etwas an einem ProductionData-Eintrag geändert hat
DECLARE	@IDSubsidiary UNIQUEIDENTIFIER,
		@IDWorkGroup UNIQUEIDENTIFIER,
		@Shift tinyint,
		@ProductionDate datetime,
		@TotalReferenceIWT float
		
IF UPDATE(TotalReferenceIWT)
	BEGIN
		SELECT	@IDWorkGroup=IDWorkGroup,
				@Shift=Shift,
				@ProductionDate=ProductionDate,
				@IDSubsidiary=IDSubsidiary,
				@TotalReferenceIWT=TotalReferenceIWT
				FROM inserted
				WHERE TotalReferenceIWT>-1
		IF @IDWorkGroup IS NOT NULL
			BEGIN

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
					
				-- Update Ergebnisse TimeLog
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
					ReferenceWageTimeProRata=dbo.CalculateReferenceWageTimeProRata(@TotalReferenceIWT, @TotalEffectiveAdjIWT, tl.IncentiveWageTime)
				FROM TimeLog tl			
				WHERE [IDSubsidiary]=@IDSubsidiary AND 
				[IDWorkGroupInternal]=@IDWorkGroupInternal AND
				[ProductionDate]=@ProductionDate AND [Shift]=@Shift
			END
	END
