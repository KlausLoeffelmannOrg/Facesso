CREATE FUNCTION dbo.HasProductionData
(@IDSubsidiary UNIQUEIDENTIFIER,
 @IDWorkGroup UNIQUEIDENTIFIER,
 @ProductionDate datetime,
 @Shift tinyint)
	
RETURNS bit

AS
	BEGIN
	
	DECLARE @Return bit
	
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	
		IF EXISTS(SELECT IDProductionData FROM ProductionData 
				  WHERE IDSubsidiary=@IDSubsidiary AND
				  IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup) AND
				  ProductionDate=@ProductionDate AND
				  Shift=@Shift)
			SET @Return='TRUE'
		ELSE
			SET @Return='FALSE'
	RETURN @Return
	END
