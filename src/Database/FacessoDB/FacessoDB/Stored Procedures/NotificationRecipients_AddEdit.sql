CREATE PROCEDURE dbo.NotificationRecipients_AddEdit
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDNotificationRecipient UNIQUEIDENTIFIER OUTPUT,
	@Title nvarchar(100),
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@SMTPAddress nvarchar(255),
	@SMTPAddressFallOver nvarchar(255),
	@IsGlobal bit,
	@Tag nvarchar(255)
	
	WITH EXECUTE AS CALLER
	AS
	
	IF @IDNotificationRecipient=null
		BEGIN
			INSERT INTO NotificationRecipients
					(IDSubsidiary,Title,FirstName, LastName,
					SMTPAddress, SMTPAddressFallOver, IsGlobal, Tag)
			VALUES (@IDSubsidiary, @Title, @FirstName, @LastName, @SMTPAddress,
					@SMTPAddressFallOver,@IsGlobal,@Tag)
			--SET @IDNotificationRecipient=SCOPE_IDENTITY()
		END
	ELSE
		UPDATE NotificationRecipients
		SET Title=@Title,
			FirstName=@FirstName,
			LastName=@LastName,
			SMTPAddress=@SMTPAddress,
			SMTPAddressFallOver=@SMTPAddressFallOver,
			IsGlobal=@IsGlobal,
			Tag=@Tag,
			LastEdited=GetDate()
		WHERE [IDNotificationRecipient]=@IDNotificationRecipient

		
	 
		
		  
			
