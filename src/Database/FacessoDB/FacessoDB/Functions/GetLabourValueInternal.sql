CREATE FUNCTION dbo.GetLabourValueInternal
(@IDSubsidiary UNIQUEIDENTIFIER,
@IDLabourValue UNIQUEIDENTIFIER)
	
RETURNS int

AS
	BEGIN
		DECLARE @IDLabourValueInternal int
		SELECT @IDLabourValueInternal=[IDLabourValueInternal] FROM [LabourValues]
		WHERE [IDSubsidiary]=@IDSubsidiary AND [IDLabourValue]=@IDLabourValue
		RETURN (@IDLabourValueInternal)
	END
