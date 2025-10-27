CREATE PROCEDURE dbo.CostCenters_IsInUse 
	@IDCostCenter UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IsInUse bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	IF EXISTS(SELECT * FROM [LabourValues] WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	IF EXISTS(SELECT * FROM [Employees] WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END
		
	IF EXISTS(SELECT * FROM [Users] WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	IF EXISTS(SELECT * FROM [WorkGroups] WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary)
		BEGIN
			SET @IsInUse=1
			RETURN
		END

	SET @IsInUse=0
	