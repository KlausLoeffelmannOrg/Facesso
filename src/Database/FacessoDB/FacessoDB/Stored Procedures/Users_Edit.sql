CREATE PROCEDURE dbo.Users_Edit 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDUser UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Username nvarchar(100),
	@Password varbinary(128),
	@ClearanceLevel bigint,
	@HasWorkstationAccess bit,
	@HasInternetAccess bit,
	@IsActivated bit,
	@DoesExpire bit,
	@ExpireDate datetime,
	@Comment ntext,
	@LastEditedByIDUser UNIQUEIDENTIFIER,

	-- Addressdetails	
	@MiddleName [nvarchar](100) = null,
	@Title [nvarchar](100) = null,
	@Street [nvarchar](100) = null,
	@Zip [nchar](100) = null,
	@City [nvarchar](100) = null,
	@CountryCode [nvarchar](10) = null,
	@Country [nvarchar](50) = null,
	@CompanyPhone [nvarchar](50) = null,
	@PrivatePhone [nvarchar](50) = null,
	@CompanyEmail [nvarchar](255) = null,
	@PrivateEmail [nvarchar](255) = null,
	@CompanyMobile [nvarchar](50) = null,
	@PrivateMobile [nvarchar](50) = null,
	@URL [nvarchar](255) = null,
	@PersonnelNo [int] = null,

	-- Internal control
	@ConsiderHistoryMaintenance bit,
	@IDUserNew INT OUTPUT

	WITH EXECUTE AS CALLER
	AS

	-- Die fehlenden Felder, die schon da sind
	DECLARE @IDUserInternal int,
			@IDAddressDetails UNIQUEIDENTIFIER,
			@IsCurrent bit,
			@WasCurrentFrom DateTime,
			@WasCurrentTo DateTime,
			@UsernameOriginal nvarchar(100),
			@DoesExist bit

	-- Aktuelle Zeit
	DECLARE	@Now DateTime
	SET @Now=GetDate()

	-- Versuchen, die Daten direkt zu ändern, indem wir sie löschen
	-- und neu einfügen. Wenn das schief geht, werden sie referenziert.
	-- Dann müssen wir uns um die Historie kümmern.
	
	-- Erstmal schauen, ob der Datensatz existiert!
	IF NOT EXISTS(SELECT * FROM [Users]
							WHERE [IDUser]=@IDUser AND [IDSubsidiary]=@IDSubsidiary)
			BEGIN
				RAISERROR('The specified user does not exist!',16,1)
				RETURN
			END
	
	-- Die fehlenden Daten ergänzen
	SELECT	@IDUserInternal = [IDUserInternal],
			@IDAddressDetails =[IDAddressDetails],
			@UsernameOriginal = [Username],
			@WasCurrentFrom = [WasCurrentFrom],
			@WasCurrentTo = [WasCurrentTo]
		FROM [Users]
		WHERE [IDCostCenter]=@IDCostCenter AND [IDSubsidiary]=@IDSubsidiary

	-- Prüfen, ob sich der *Username* ändern wird. Falls
	-- ja, dann schauen, ob es die neue Kostenstellennr. schon AKTIV gibt.
	IF @Username<>@UsernameOriginal
		BEGIN
			exec Users_DoesUsernameExist		@IDSubsidiary, 
												@Username,
												null,
												@DoesExist
			IF @DoesExist=1
				BEGIN
					RAISERROR('The specified new username number does already exist!',16,1)
					RETURN
				END
		END
		
	-- Historiepflege betreiben, oder nicht
	IF @ConsiderHistoryMaintenance=1
		BEGIN
			SET @ConsiderHistoryMaintenance=1
			-- Todo: Logik zur Historiepflege
		END
	ELSE
		BEGIN
			BEGIN TRANSACTION
			
			EXEC AddressDetails_Edit	@IDAddressDetails, @IDSubsidiary, @LastName, @MiddleName, @FirstName,
										@Title, @Street, @Zip, @City, @CountryCode, @Country,
										@CompanyPhone, @PrivatePhone, @CompanyEmail, @PrivateEmail,
										@CompanyMobile, @PrivateMobile, @URL, @PersonnelNo
			IF @@error!=0 BEGIN
				ROLLBACK TRANSACTION
				RAISERROR('An error occured while updating the AddressDetails-Table!',16,1)
				RETURN
			END
			
			UPDATE [Users]
			SET [LastName]=@LastName,
				[FirstName]=@FirstName,
				[Username]=@Username,
				[Password]=@Password,
				[ClearanceLevel]=@ClearanceLevel,
				[HasWorkStationAccess]=@HasWorkstationAccess,
				[HasInternetAccess]=@HasInternetAccess,
				[IsActivated]=@IsActivated,
				[DoesExpire]=@DoesExpire,
				[ExpireDate]=@ExpireDate,
				[Comment]=@Comment,
				[IsSystemAccount]=0
			WHERE [IDUser]=@IDUser AND [IDSubsidiary]=IDSubsidiary
			-- Aus Kompatiblitätsgründen zur Historienpflege für die Enterprise
			-- muss die ID zurückgegeben werden.
			IF @@error!=0 BEGIN
				ROLLBACK TRANSACTION
				RAISERROR('An error occured while updating the Users Table! Rolling Back.',16,1)
				RETURN
			END
			COMMIT TRANSACTION
		END

		EXEC AddToFunctionLog @IDSubsidiary, 'Users: User edited', @LastEditedByIDUser, @Now
