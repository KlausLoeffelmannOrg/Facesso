CREATE PROCEDURE dbo.WorkGroups_AddAssignmentRecord
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDLabourValueInternal int,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@OrdinalNumber int
	
	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDWorkGroupInternal int
	
	-- Interne Nummer ermitteln
	SELECT @IDWorkGroupInternal=[IDWorkGroupInternal] FROM [WorkGroups] 
	WHERE [IDSubsidiary]=@IDSubsidiary AND [IDWorkGroup]=@IDWorkGroup

	
	INSERT INTO [WorkGroupAssignments] 
	([IDSubsidiary],[IDLabourValueInternal],[IDWorkGroupInternal],[OrdinalNumber])
	VALUES (@IDSubsidiary, @IDLabourValueInternal, @IDWorkGroupInternal, @OrdinalNumber)
	 
		
		  
			
