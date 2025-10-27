CREATE FUNCTION dbo.GetIDBonusLists
(@IDSubsidiary UNIQUEIDENTIFIER,
@IDEmployee UNIQUEIDENTIFIER)
	
RETURNS UNIQUEIDENTIFIER

AS
	BEGIN
		DECLARE @IDBonusLists UNIQUEIDENTIFIER,
				@IDCostCenter UNIQUEIDENTIFIER
		SELECT @IDCostCenter=IDCostCenter FROM Employees
		WHERE IDSubsidiary=@IDSubsidiary AND IDEmployee=@IDEmployee
		
		SELECT @IDBonusLists=IDBonusLists FROM BonusLists
		WHERE IDSubsidiary=@IDSubsidiary AND IDCostCenter=@IDCostCenter

		RETURN(@IDBonusLists)
		
	END
