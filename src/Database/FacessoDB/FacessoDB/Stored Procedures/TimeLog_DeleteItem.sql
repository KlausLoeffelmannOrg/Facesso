CREATE PROCEDURE dbo.TimeLog_DeleteItem
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDTimeLog UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS
	
	DELETE FROM TimeLog
	WHERE IDSubsidiary=@IDSubsidiary AND IDTimeLog=@IDTimeLog		  
		  
	
		
	 
		
		  
			
