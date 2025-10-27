CREATE PROCEDURE dbo.CostCenters_DoesNumberExist 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@CostCenterNo int,
	@ExcludeIDCostCenter UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDCostCenter IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [CostCenters] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [CostCenterNo]=@CostCenterNo
							AND [IsCurrent]=1)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [CostCenters] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [CostCenterNo]=@CostCenterNo
							AND [IsCurrent]=1
							AND [IDCostCenter]<>@ExcludeIDCostCenter)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
