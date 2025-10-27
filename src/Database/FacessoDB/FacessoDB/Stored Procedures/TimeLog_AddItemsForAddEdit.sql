CREATE PROCEDURE dbo.TimeLog_AddItemsForAddEdit
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDTimeLog UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@IDEmployee UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint,
	@ShiftStart datetime,
	@ShiftEnd datetime,
	@WorkBreak int,
	@DownTime int,
	@Handicap float,
	@InsertedByInterface bit,
	@ManuallyEdited bit,
	@LastEditedByIDUser UNIQUEIDENTIFIER,
	@Ticket datetime,
	@Deleted bit
	
	WITH EXECUTE AS CALLER
	AS
	
	INSERT INTO [TimeLogForInsert] 
			([IDSubsidiary],[IDTimeLog], [IDUser], 
			 [IDWorkGroup], [IDEmployee],[Shift],
			 [ProductionDate], [ShiftStart], [ShiftEnd],
			 [WorkBreak], [DownTime], [Handicap],
			 [InsertedByInterface], [ManuallyEdited], [EditedByIDUser], [Ticket], [Deleted])
	VALUES (@IDSubsidiary, @IDTimeLog, @IDUser, 
			@IDWorkgroup, @IDEmployee, @Shift,
			@ProductionDate, @ShiftStart, @ShiftEnd, @WorkBreak,
			@DownTime, @Handicap, @InsertedByInterface, @ManuallyEdited,
			@LastEditedByIDUser, @Ticket, @Deleted)
		  
		  
	
		
	 
		
		  
			
