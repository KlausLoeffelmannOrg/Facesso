CREATE PROCEDURE dbo.ProductionData_DoProductionDataExist
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint,
	@DoExist bit OUTPUT
	
	WITH EXECUTE AS CALLER
	AS
	
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	
	IF EXISTS(SELECT * FROM [ProductionData] WHERE
	          [IDSubsidiary]=@IDSubsidiary AND
	          [IDWorkGroupInternal]=dbo.WorkGroupInternal(@IDSubsidiary,@IDWorkGroup) AND
	          [ProductionDate]=@ProductionDate AND
	          [Shift]=@Shift AND
	          [IDEmployee]=null)
		SET @DoExist='true'
	ELSE
		SET @DoExist='false'
	          
			  
	
	
	
	
	 
	
	
	
		
		                   
	
	
