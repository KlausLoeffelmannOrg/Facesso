CREATE PROCEDURE dbo.Users_Add
	@IDSubsidiary UNIQUEIDENTIFIER,
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
	@WasCurrentTo datetime,
	@CreatedByIDUser UNIQUEIDENTIFIER,
	@Comment ntext,
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
	@IDUserNew UNIQUEIDENTIFIER

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDUserInternal int,
			@IDAddressDetail UNIQUEIDENTIFIER,
			@Now DateTime
	
	SET @Now=GetDate()
	--SET @IDAddressDetail=NEWID()  
	
	-- Verhindern, dass doppelte Benutzernamen existieren können!
	IF EXISTS(SELECT * FROM  [Users] 
					   WHERE [IDSubsidiary]   = @IDSubsidiary 
					   AND   [Username]   =		@Username)
		SET @IDUserNew = null
	ELSE
		BEGIN
			
			BEGIN TRANSACTION
			
			EXEC AddressDetails_Add @IDSubsidiary, @LastName, @MiddleName, @FirstName,
										     @Title, @Street, @Zip, @City, @CountryCode,
										     @Country, @CompanyPhone, @PrivatePhone, @CompanyEmail, 
										     @PrivateEmail, @CompanyMobile, @PrivateMobile,
										     @URL, @PersonnelNo, @IDAddressDetail;

			-- Letzte interne ID ermitteln
			SELECT @IDUserInternal=MAX([IDUserInternal]) 
						FROM  [Users] 
						WHERE [IDSubsidiary] = @IDSubsidiary
			
			-- um eins erhöhen - das ist die neue interne ID
			SET @IDUserInternal = @IDUserInternal + 1

			-- neuen Benutzer in Tabelle einfügen
			INSERT INTO [Users]
				([IDSubsidiary], [IDUserInternal], [IDCostCenter],
				[FirstName], [LastName], [IDAddressDetails],
				[Username],[Password], [ClearanceLevel],[HasWorkstationAccess],
				[HasInternetAccess],[IsActivated],[IsCurrent],[DoesExpire],
				[ExpireDate], [Comment], [IsSystemAccount],
				[WasCurrentFrom], [WasCurrentTo])
			VALUES
				(@IDSubsidiary, @IDUserInternal, @IDCostCenter,
				@FirstName, @LastName, @IDAddressDetail,
				@Username, @Password, @ClearanceLevel,@HasWorkstationAccess,
				@HasInternetAccess,@IsActivated,1,@DoesExpire,
				@ExpireDate, @Comment, 0,
				@Now, @WasCurrentTo)
			
			if @@error!=0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE			
				COMMIT TRANSACTION
		END
		
		EXEC AddToFunctionLog @IDSubsidiary, 'Users: New user added', @CreatedByIDUser, @Now

