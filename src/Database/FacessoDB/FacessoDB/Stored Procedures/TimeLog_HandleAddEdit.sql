CREATE PROCEDURE dbo.TimeLog_HandleAddEdit
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@Ticket datetime
	 
	WITH EXECUTE AS CALLER
	AS
	
	-- Die zu löschenden Daten entfernen
	
	DELETE FROM TimeLog
	FROM         TimeLog INNER JOIN
	                      TimeLogForInsert ON TimeLog.IDSubsidiary = TimeLogForInsert.IDSubsidiary AND 
	                      TimeLog.IDTimeLog = TimeLogForInsert.IDTimeLog
	WHERE TimeLogForInsert.Deleted='true' AND
		  TimeLogForInsert.IDUser=@IDUser AND
		  TimeLogForInsert.IDSubsidiary=@IDSubsidiary AND
		  TimeLogForInsert.Ticket=@Ticket
	
	-- Neue Werte werden eingefügt
	INSERT	TimeLog (IDSubsidiary, IDWorkGroup, IDWorkGroupInternal, IDEmployee,
					 IDEmployeeInternal, IDBonusLists, IDWageGroup,
					 Shift, ProductionDate,
					 ShiftStart, ShiftStartViaInterface,
					 ShiftEnd, ShiftEndViaInterface,
					 WorkBreak, WorkBreakViaInterface,
					 DownTime, DownTimeViaInterface,
					 Handicap, IsSuspended,
					 InsertedByInterface, ManuallyEdited, LastEdited, EditedByIDUser)
	SELECT	IDSubsidiary,
			IDWorkgroup,
			dbo.WorkGroupInternal(IDSubsidiary, IDWorkgroup) as IDWorkGroupInternal,
			IDEmployee, 
			dbo.EmployeeInternal(IDSubsidiary, IDEmployee) as IDEmployeeInternal,
			dbo.GetIDBonusLists(IDSubsidiary, IDEmployee) as IDBonusList, 
			dbo.GetIDWageGroup(IDSubsidiary, IDEmployee) as IDWageGroup,
			Shift, 
			ProductionDate, 
			ShiftStart, 
			ShiftStartViaInterface = CASE InsertedByInterface WHEN 'true' THEN ShiftStart ELSE NULL END,
			ShiftEnd, 
			ShiftEndViaInterface = CASE InsertedByInterface WHEN 'true' THEN ShiftEnd ELSE NULL END,
			WorkBreak, 
			WorkBreakViaInterface = CASE InsertedByInterface WHEN 'true' THEN WorkBreak ELSE NULL END,
			DownTime, 
			DownTimeViaInterface = CASE InsertedByInterface WHEN 'true' THEN DownTime ELSE NULL END,
			Handicap, 
			'false' as IsSuspended,
			InsertedByInterface,
			ManuallyEdited,
			GetDate() as LastEdited,
			EditedByIDUser

	FROM	TimeLogForInsert

	WHERE	IDSubsidiary=@IDSubsidiary AND
			IDUser=@IDUser AND
			Ticket=@Ticket AND
			IDTimeLog=null
			
	-- Hilfsdaten der neuen Datensätze löschen
	DELETE FROM TimeLogForInsert
	WHERE	IDSubsidiary=@IDSubsidiary AND
			IDUser=@IDUser AND
			Ticket=@Ticket AND
			IDTimeLog=null
			
	UPDATE  TimeLog
	
	SET     ShiftStart=TimeLogForInsert.ShiftStart,
			ShiftStartViaInterface = CASE TimeLogForInsert.InsertedByInterface WHEN 'true' THEN TimeLogForInsert.ShiftStart ELSE NULL END,
			ShiftEnd=TimeLogForInsert.ShiftEnd, 
			ShiftEndViaInterface = CASE TimeLogForInsert.InsertedByInterface WHEN 'true' THEN TimeLogForInsert.ShiftEnd ELSE NULL END,
			WorkBreak=TimeLogForInsert.WorkBreak, 
			WorkBreakViaInterface = CASE TimeLogForInsert.InsertedByInterface WHEN 'true' THEN TimeLogForInsert.WorkBreak ELSE NULL END,
			DownTime=TimeLogForInsert.DownTime, 
			DownTimeViaInterface = CASE TimeLogForInsert.InsertedByInterface WHEN 'true' THEN TimeLogForInsert.DownTime ELSE NULL END,
			Handicap=TimeLogForInsert.Handicap,
			InsertedByInterface=TimeLogForInsert.InsertedByInterface,
			ManuallyEdited=TimeLogForInsert.ManuallyEdited,
			LastEdited=GetDate(),
			EditedByIDUser=@IDUser
	        
	FROM         TimeLog INNER JOIN
	                      TimeLogForInsert ON TimeLog.IDSubsidiary = TimeLogForInsert.IDSubsidiary AND 
	                      Timelog.IDTimeLog = TimeLogForInsert.IDTimeLog
	WHERE     (TimeLogForInsert.IDSubsidiary = @IDSubsidiary) AND 
			  (TimeLogForInsert.IDUser = @IDUser) AND
			  (TimeLogForInsert.Ticket=@Ticket)
			  
		-- Hilfsdaten der neuen Datensätze löschen
	DELETE FROM TimeLogForInsert
	WHERE	IDSubsidiary=@IDSubsidiary AND
			IDUser=@IDUser AND
			Ticket=@Ticket AND
			IDTimeLog=null


