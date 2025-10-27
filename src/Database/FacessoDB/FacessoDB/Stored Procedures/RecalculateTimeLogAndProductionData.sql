CREATE PROCEDURE dbo.RecalculateTimeLogAndProductionData
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint

AS
	-- Zeitgrade berechnen...
	DECLARE @ResultTable TABLE  (TotalAttendanceTime float,
								TotalDownTime float,
								TotalWorkBreak float,
								TotalWorkingTime float,
								TotalReferenceIWT float,
								TotalEffectiveIWT float,
								TotalEffectiveAdjIWT float,
								DegreeOfTime float,
								DegreeOfTimeAdj float)
	DECLARE @IDWorkGroupInternal int
			
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)
	
	INSERT @ResultTable 
	SELECT * FROM dbo.AnalysisShiftAtDay(@IDSubsidiary, @IDWorkGroupInternal,
	                                   @ProductionDate, @Shift)

	
	-- und in Produktionstabelle aktualisieren
	
	UPDATE  [ProductionData]
	SET		[DegreeOfTime]=rt.DegreeOfTime,
	        [DegreeOfTimeAdj]=rt.DegreeOfTimeAdj
	FROM @ResultTable as rt
	

	-- Alle wichtigen Werte in den betroffenen Zeitprotokolldatensätzen aktualisieren
	-- WICHTIG auch hier: Mit WorkGroupInternal referenzieren, damit durch Änderungen
	-- an einer Arbeitsgruppe auch "alte" Arbeitsgruppe noch berücksichtigt werden.
	
	UPDATE [TimeLog]
	SET	   [DegreeOfTime]=rt.DegreeOfTime,
		   [DegreeOfTimeAdj]=rt.DegreeOfTimeAdj,
		   [ReferenceWageTimeProRata]=dbo.CalculateReferenceWageTimeProRata(rt.TotalReferenceIWT, rt.TotalEffectiveIWT, IncentiveWageTime)
	FROM   TimeLog CROSS JOIN
	        @ResultTable as rt
	WHERE [IDWorkGroupInternal]=@IDWorkGroupInternal AND
		  [ProductionDate]=@ProductionDate AND
		  [Shift]=@Shift
	
	

