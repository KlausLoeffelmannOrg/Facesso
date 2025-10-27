CREATE PROCEDURE dbo.WorkGroups_DeleteAssignment
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDWorkGroupInternal int
	
	-- Interne Nummer ermitteln
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)

	-- Assignments löschen
	DELETE FROM [WorkGroupAssignments] WHERE [IDSubsidiary]=@IDSubsidiary AND
											 [IDWorkGroupInternal]=@IDWorkGroupInternal
											 
		
		  
			
