CREATE FUNCTION dbo.EmployeeInternal
(@IDSubsidiary UNIQUEIDENTIFIER,
@IDEmployee UNIQUEIDENTIFIER)
	
RETURNS int

AS
	BEGIN
		DECLARE @IDEmployeeInternal int
		SELECT @IDEmployeeInternal=[IDEmployeeInternal] FROM [Employees]
		WHERE [IDSubsidiary]=@IDSubsidiary AND [IDEmployee]=@IDEmployee
		RETURN (@IDEmployeeInternal)
	END
