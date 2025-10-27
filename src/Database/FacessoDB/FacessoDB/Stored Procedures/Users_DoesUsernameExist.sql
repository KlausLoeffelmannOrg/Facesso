CREATE PROCEDURE dbo.Users_DoesUsernameExist 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@Username nvarchar(50),
	@ExcludeIDUser UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDUser IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [Users] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [Username]=@Username
							AND [IsCurrent]=1)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [Users] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [Username]=@Username
							AND [IsCurrent]=1
							AND [IDUser]<>@ExcludeIDUser)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END