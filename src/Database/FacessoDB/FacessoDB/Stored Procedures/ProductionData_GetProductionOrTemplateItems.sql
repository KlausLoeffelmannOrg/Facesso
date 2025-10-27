CREATE PROCEDURE dbo.ProductionData_GetProductionOrTemplateItems
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint,
	@OrderBy tinyint, /* 0: Nach Arbeitswertnr; 1: Nach Ordinalnr */
	@DoExist bit OUTPUT,
	@IDProductionData UNIQUEIDENTIFIER output,
	@TotalReferenceIWT float=0 OUTPUT,
	@DegreeOfTime float=-2 OUTPUT,
	@DegreeOfTimeAdj float=-2 OUTPUT,
	@InsertedByInterface bit='false' OUTPUT,
	@IsSuspended bit='false' OUTPUT,
	@LastEdited datetime='01/01/2005' OUTPUT,
	@LastEditedByIDUser UNIQUEIDENTIFIER=null OUTPUT
	
	WITH EXECUTE AS CALLER
	AS
	
	SET NOCOUNT ON
	
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	
	SET @DegreeOfTime=-2
	SET @DegreeOfTimeAdj=-2
	SET @LastEdited='01/01/1900'
	
	EXEC ProductionData_DoProductionDataExist	@IDSubsidiary, 
												@IDWorkGroup, 
												@ProductionDate, 
												@Shift,
												@DoExist OUTPUT
	if @DoExist='true'
		BEGIN
			
			-- Produktionrahmendaten abfragen
			EXEC ProductionData_GetProductionData @IDSubsidiary, 
												  @IDWorkGroup OUTPUT,
												  @ProductionDate, 
												  @Shift,
												  @IDProductionData OUTPUT,
												  @TotalReferenceIWT OUTPUT,
												  @DegreeOfTime OUTPUT,
												  @DegreeOfTimeAdj OUTPUT,
												  @InsertedByInterface OUTPUT,
												  @IsSuspended OUTPUT,
												  @LastEdited OUTPUT,
												  @LastEditedByIDUser OUTPUT
											
			IF @OrderBy=0			
				SELECT     ProductionDataItems.IDProductionDataItem, ProductionDataItems.IDLabourValue, ProductionDataItems.IDArticle, ProductionDataItems.Amount, 
									  ProductionDataItems.OrdinalNumber, LabourValues.IDLabourValueInternal, LabourValues.LabourValueNumber, LabourValues.LabourValueName, 
									  LabourValues.LabourValueDescription, LabourValues.TeHMin, LabourValues.Dimension, LabourValues.IsActive, LabourValues.IsCurrent, 
									  CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, 
									  ProductionDataItems.ManuallyEdited, ProductionDataItems.IDSubsidiary, LabourValues.IDCostCenter, LabourValues.WasCurrentFrom, 
									  LabourValues.WasCurrentTo, ProductionDataItems.AmountViaInterface
				FROM         ProductionData INNER JOIN
									  ProductionDataItems ON ProductionData.IDProductionData = ProductionDataItems.IDProductionData AND 
									  ProductionData.IDSubsidiary = ProductionDataItems.IDSubsidiary INNER JOIN
									  LabourValues ON ProductionDataItems.IDLabourValue = LabourValues.IDLabourValue AND 
									  ProductionDataItems.IDSubsidiary = LabourValues.IDSubsidiary INNER JOIN
									  CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter AND LabourValues.IDSubsidiary = CostCenters.IDSubsidiary
				WHERE     (ProductionData.IDProductionData = @IDProductionData) AND (ProductionData.IDSubsidiary = @IDSubsidiary)
				ORDER BY ProductionDataItems.OrdinalNumber
			ELSE
				SELECT     ProductionDataItems.IDProductionDataItem, ProductionDataItems.IDLabourValue, ProductionDataItems.IDArticle, ProductionDataItems.Amount, 
									  ProductionDataItems.OrdinalNumber, LabourValues.IDLabourValueInternal, LabourValues.LabourValueNumber, LabourValues.LabourValueName, 
									  LabourValues.LabourValueDescription, LabourValues.TeHMin, LabourValues.Dimension, LabourValues.IsActive, LabourValues.IsCurrent, 
									  CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, 
									  ProductionDataItems.ManuallyEdited, ProductionDataItems.IDSubsidiary, LabourValues.IDCostCenter, LabourValues.WasCurrentFrom, 
									  LabourValues.WasCurrentTo, ProductionDataItems.AmountViaInterface
				FROM         ProductionData INNER JOIN
									  ProductionDataItems ON ProductionData.IDProductionData = ProductionDataItems.IDProductionData AND 
									  ProductionData.IDSubsidiary = ProductionDataItems.IDSubsidiary INNER JOIN
									  LabourValues ON ProductionDataItems.IDLabourValue = LabourValues.IDLabourValue AND 
									  ProductionDataItems.IDSubsidiary = LabourValues.IDSubsidiary INNER JOIN
									  CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter AND LabourValues.IDSubsidiary = CostCenters.IDSubsidiary
				WHERE     (ProductionData.IDProductionData = @IDProductionData) AND (ProductionData.IDSubsidiary = @IDSubsidiary)
				ORDER BY LabourValues.LabourValueNumber
			
		END
	ELSE
		BEGIN	
			
			DECLARE @IDWorkGroupInternal int,
					@ZeroIntDummy int,
					@ZeroBigIntDummy bigint,
					@ZeroFloatDummy float,
					@FalseBitDummy bit
					
			-- Interne Nummer ermitteln
			SELECT @IDWorkGroupInternal=[IDWorkGroupInternal] FROM [WorkGroups] 
			WHERE [IDSubsidiary]=@IDSubsidiary AND [IDWorkGroup]=@IDWorkGroup
			
			-- und ein paar Dummy-Werte für den Tabellenfake setzen
			SET @ZeroBigIntDummy=0
			SET @ZeroFloatDummy=0
			SET @FalseBitDummy='false'
			SET @ZeroIntDummy=0
	
			IF @OrderBy=0 
				SELECT     @ZeroBigIntDummy AS IDProductionDataItem, @ZeroIntDummy AS IDArticle, @ZeroFloatDummy AS Amount, @ZeroFloatDummy as AmountViaInterface, WorkGroupAssignments.OrdinalNumber, 
									  @FalseBitDummy AS ManuallyEdited, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, LabourValues.IDCostCenter, 
									  LabourValues.LabourValueNumber, LabourValues.LabourValueDescription, LabourValues.TeHMin, LabourValues.Dimension, LabourValues.IsActive, 
									  LabourValues.IsCurrent, LabourValues.WasCurrentFrom, LabourValues.WasCurrentTo, LabourValues.IDLabourValue, CostCenters.CostCenterName, 
									  CostCenters.CostCenterNo, LabourValues.LabourValueName, LabourValues.IDLabourValueInternal, WorkGroupAssignments.IDSubsidiary
				FROM         WorkGroupAssignments INNER JOIN
									  LabourValues ON WorkGroupAssignments.IDLabourValueInternal = LabourValues.IDLabourValueInternal AND 
									  WorkGroupAssignments.IDSubsidiary = LabourValues.IDSubsidiary INNER JOIN
									  CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter AND LabourValues.IDSubsidiary = CostCenters.IDSubsidiary
				WHERE     (WorkGroupAssignments.IDSubsidiary = @IDSubsidiary) AND (WorkGroupAssignments.IDWorkGroupInternal = @IDWorkGroupInternal)
				ORDER BY WorkGroupAssignments.OrdinalNumber
			ELSE
				SELECT     @ZeroBigIntDummy AS IDProductionDataItem, @ZeroIntDummy AS IDArticle, @ZeroFloatDummy AS Amount, @ZeroFloatDummy as AmountViaInterface, WorkGroupAssignments.OrdinalNumber, 
									  @FalseBitDummy AS ManuallyEdited, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, LabourValues.IDCostCenter, 
									  LabourValues.LabourValueNumber, LabourValues.LabourValueDescription, LabourValues.TeHMin, LabourValues.Dimension, LabourValues.IsActive, 
									  LabourValues.IsCurrent, LabourValues.WasCurrentFrom, LabourValues.WasCurrentTo, LabourValues.IDLabourValue, CostCenters.CostCenterName, 
									  CostCenters.CostCenterNo, LabourValues.LabourValueName, LabourValues.IDLabourValueInternal, WorkGroupAssignments.IDSubsidiary
				FROM         WorkGroupAssignments INNER JOIN
									  LabourValues ON WorkGroupAssignments.IDLabourValueInternal = LabourValues.IDLabourValueInternal AND 
									  WorkGroupAssignments.IDSubsidiary = LabourValues.IDSubsidiary INNER JOIN
									  CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter AND LabourValues.IDSubsidiary = CostCenters.IDSubsidiary
				WHERE     (WorkGroupAssignments.IDSubsidiary = @IDSubsidiary) AND (WorkGroupAssignments.IDWorkGroupInternal = @IDWorkGroupInternal)
				ORDER BY LabourValues.LabourValueNumber
			
		END
	
	
	 
	
	
	
		
		                   
	
	
