Create PROCEDURE dbo.CostCenters_Delete

	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DELETE FROM CostCenters WHERE IDSubsidiary=@IDSubsidiary AND IDCostCenter=@IDCostCenter
	
	
