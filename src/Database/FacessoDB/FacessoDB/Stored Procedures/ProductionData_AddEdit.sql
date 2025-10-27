CREATE PROCEDURE dbo.ProductionData_AddEdit
	@IDProductionData UNIQUEIDENTIFIER=null output,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDWorkGroup UNIQUEIDENTIFIER,
	@ProductionDate datetime,
	@Shift tinyint,
	@InsertedByInterface bit,
	@IsSuspended bit,
	@LastEditedByIDUser UNIQUEIDENTIFIER
	
	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDWorkGroupInternal int
	
	SET @ProductionDate=convert(char(8),@ProductionDate,112)
	SET @IDWorkGroupInternal=dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)
	
	IF @IDProductionData=null
		BEGIN
			INSERT INTO [ProductionData] 
					([IDSubsidiary],[IDWorkGroup],[IDWorkGroupInternal], [ProductionDate],[Shift],
					[InsertedByInterface], [IsSuspended],
					[LastEditedByIDUser], [LastEdited])
			VALUES (@IDSubsidiary, @IDWorkGroup, @IDWorkGroupInternal, 
					@ProductionDate, @Shift,
					@InsertedByInterface, @IsSuspended,
					@LastEditedByIDUser, GetDate())
			        
			--SET @IDProductionData=SCOPE_IDENTITY()
		END
	ELSE
		UPDATE [ProductionData]
		SET [LastEditedByIDUser]=@LastEditedByIDUser,
			[IsSuspended]=@IsSuspended,
			[InsertedByInterface]=@InsertedByInterface
		WHERE [IDProductionData]=@IDProductionData

		
	 
		
		  
			
