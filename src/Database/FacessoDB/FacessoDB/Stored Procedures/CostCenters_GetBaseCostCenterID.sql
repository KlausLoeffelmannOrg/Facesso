CREATE PROCEDURE CostCenters_GetBaseCostCenterID

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDBaseCostCenter UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	SELECT @IDBaseCostCenter=IDCostCenter FROM CostCenters 
	WHERE IDSubsidiary=@IDSubsidiary AND CostCenterNo=0
	

	
	
		
	
