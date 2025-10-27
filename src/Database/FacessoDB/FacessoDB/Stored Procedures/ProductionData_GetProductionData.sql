CREATE PROCEDURE dbo.ProductionData_GetProductionData
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER OUTPUT,
	@ProductionDate datetime,
	@Shift tinyint,
	@IDProductionData UNIQUEIDENTIFIER output,
	@TotalReferenceIWT float OUTPUT,
	@DegreeOfTime float OUTPUT,
	@DegreeOfTimeAdj float OUTPUT,
	@InsertedByInterface bit OUTPUT,
	@IsSuspended bit OUTPUT,
	@LastEdited datetime OUTPUT,
	@LastEditedByIDUser UNIQUEIDENTIFIER OUTPUT
	
WITH EXECUTE AS CALLER
AS
	DECLARE @IDWorkGroupInternal int
	
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary,@IDWorkGroup)

	SELECT @IDProductionData=[IDProductionData],
		   @IDWorkGroup=[IDWorkGroup],
		   @TotalReferenceIWT=[TotalReferenceIWT], 
		   @DegreeOfTime=[DegreeOfTime],
		   @DegreeOfTimeAdj=[DegreeOfTimeAdj],
		   @InsertedByInterface=[InsertedByInterface],
		   @IsSuspended=[IsSuspended],
		   @LastEdited=[LastEdited],
		   @LastEditedByIDUser=[LastEditedByIDUser]
		   FROM [ProductionData]
		   WHERE [IDSubsidiary]=@IDSubsidiary AND
		         [IDWorkGroupInternal]=@IDWorkGroupInternal AND
		         [ProductionDate]=@ProductionDate AND
		         [Shift]=@Shift AND
		         [IDEmployee]=null
		         

