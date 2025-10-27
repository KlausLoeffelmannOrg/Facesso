CREATE PROCEDURE dbo.NotificationRecipients_DoesEmailExist

	@IDSubsidiary UNIQUEIDENTIFIER,
	@Email nvarchar(255),
	@CheckGlobal bit,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	IF @CheckGlobal='true'
		BEGIN
			IF EXISTS(SELECT * FROM NotificationRecipients
							WHERE SMTPAddress=@Email)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM NotificationRecipients 
							WHERE IDSubsidiary=@IDSubsidiary 
							AND SMTPAddress=@Email)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
