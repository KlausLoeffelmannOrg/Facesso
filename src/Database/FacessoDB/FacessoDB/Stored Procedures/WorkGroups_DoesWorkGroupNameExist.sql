CREATE PROCEDURE dbo.WorkGroups_DoesWorkGroupNameExist 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@WorkGroupName nvarchar(100),
	@ExcludeIDWorkGroup UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDWorkGroup IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [WorkGroups] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [WorkGroupName]=@WorkGroupName
							AND [IsCurrent]=1)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [WorkGroups] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [WorkGroupName]=@WorkGroupName
							AND [IsCurrent]=1
							AND [IDWorkGroup]<>@ExcludeIDWorkGroup)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
