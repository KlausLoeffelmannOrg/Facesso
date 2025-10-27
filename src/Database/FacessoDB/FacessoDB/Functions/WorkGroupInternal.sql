CREATE FUNCTION dbo.WorkGroupInternal
(@IDSubsidiary UNIQUEIDENTIFIER,
 @IDWorkGroup UNIQUEIDENTIFIER)
	
RETURNS int

AS
	BEGIN
		DECLARE @IDWorkGroupInternal int
		SELECT @IDWorkGroupInternal=[IDWorkGroupInternal] FROM [WorkGroups]
		WHERE [IDSubsidiary]=@IDSubsidiary AND [IDWorkgroup]=@IDWorkGroup
		RETURN (@IDWorkGroupInternal)
	END
