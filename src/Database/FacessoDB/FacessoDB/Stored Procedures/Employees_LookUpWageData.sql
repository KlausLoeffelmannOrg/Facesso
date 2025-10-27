CREATE PROCEDURE dbo.Employees_LookUpWageData 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDEmployee UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@DegreeOfTime float,
	@UseFixValuedBonus bit OUTPUT,
	@BaseWage float output,
	@Percentage float OUTPUT,
	@AbsoluteValue float OUTPUT
	
	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDBonusLists UNIQUEIDENTIFIER,
	        @UseFixedWage bit,
	        @IDWageGroup UNIQUEIDENTIFIER
	
	-- Ermitteln, ob für den Mitarbeiter die Lohntabelle verwendet wird
	SELECT @UseFixedWage=UseFixedWage, @BaseWage=FixedWage, @IDWageGroup=IDWageGroup
	FROM Employees
	WHERE IDSubsidiary=@IdSubsidiary AND IDEmployee=@IDEmployee
	
	IF @UseFixedWage='false'
		-- Falls nicht, dann den entsprechenden Basislohn in der Lohngruppentabelle nachschlagen
		SELECT @BaseWage=HourlyRate
		FROM WageGroups
		WHERE IDSubsidiary=@IDSubsidiary AND IDWageGroup=@IDWageGroup

	-- Ermitteln, ob der Mitarbeiter, über die Kostenstelle gesteuert, sich für die 
	-- Prämienlohnberechnung über die Prozentetabelle oder die Fixbetrag-Tabelle qualifiziert.
	
	SELECT @UseFixValuedBonus=UseFixValuedBonus
	FROM CostCenters 
	WHERE IDSUbsidiary=@IDSubsidiary AND
	      IDCostCenter=@IDCostCenter
	      
	-- Die entsprechende Bonuslist-ID für die Kostenstelle rausfinden
	SELECT @IDBonusLists=IDBonusLists 
	FROM BonusLists
	WHERE IDSubsidiary=@IDSubsidiary AND
	      IDCostCenter=@IDCostCenter
	      
	-- In der Tabelle Bonuslists den entsprechenden Eintrag finden
	-- (als Basis den DegreeOfTime-Wert finden, der dem übergebenden am nächsten kommt)
	
	DECLARE @ResultTable TABLE
				(IDBonusList UNIQUEIDENTIFIER,
				 Percentage float,
				 AbsoluteValue float,
				 TempValue float)

	INSERT @ResultTable (IDBonusList, Percentage, AbsoluteValue, TempValue)
	SELECT     TOP (1) IDBonusList, Percentage, AbsoluteValue, ABS(@DegreeOfTime - DegreeOfTime) AS TempValue
	FROM         BonusList
	WHERE     (IDSubsidiary = @IDSubsidiary) AND (IDBonusLists = @IDBonusLists)
	ORDER BY TempValue
	
	SELECT @Percentage=Percentage, @AbsoluteValue=AbsoluteValue FROM @ResultTable
