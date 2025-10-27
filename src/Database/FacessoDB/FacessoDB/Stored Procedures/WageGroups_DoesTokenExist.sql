CREATE PROCEDURE dbo.WageGroups_DoesTokenExist 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@WageGroupToken nvarchar(20),
	@ExcludeIDWageGroup UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDWageGroup IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [WageGroups] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [WageGroupToken]=@WageGroupToken
							AND [IsCurrent]=1)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [WageGroups] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [WageGroupToken]=@WageGroupToken
							AND [IsCurrent]=1
							AND [IDWageGroup]<>@ExcludeIDWageGroup)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
