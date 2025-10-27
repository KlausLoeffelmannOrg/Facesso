CREATE PROCEDURE dbo.Employees_Add
	@IDEmployeeNew UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@IDWageGroup UNIQUEIDENTIFIER,
	@UseFixedWage bit,
	@FixedWage money,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Matchcode nvarchar(50),
	@PersonnelNumber int,
	@IsActive bit,
	@IsIncentive bit,
	@WasCurrentTo datetime,
	@DateOfBirth datetime,
	@DateOfJoining datetime,
	@DateOfSeparation datetime,
	@TimeCardNo nvarchar(50),
	@Comment ntext,
	@CreatedByIDUser UNIQUEIDENTIFIER,
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
	@PersonnelNo [int] = null

	WITH EXECUTE AS CALLER
	AS
	
	DECLARE @IDEmployeeInternal INT,
			@IDAddressDetail UNIQUEIDENTIFIER,
			@Now DateTime
	
	SET @Now=GetDate()
	
	-- Verhindern, dass doppelte Personalnummern existieren können!
	IF EXISTS(SELECT * FROM  [Employees] 
					   WHERE [IDSubsidiary]		= @IDSubsidiary 
					   AND   [PersonnelNumber]  = @PersonnelNumber
					   AND   [IsCurrent] = 1)
		SET @IDEmployeeNew = null 
		
	ELSE
		BEGIN
		
			EXEC AddressDetails_Add @IDSubsidiary, @LastName, @MiddleName, @FirstName,
							@Title, @Street, @Zip, @City, @CountryCode,
							@Country, @CompanyPhone, @PrivatePhone, @CompanyEmail, 
							@PrivateEmail, @CompanyMobile, @PrivateMobile,
							@URL, @PersonnelNo, @IDAddressDetail OUTPUT;

			IF @IDAddressDetail IS NULL
				BEGIN
					RAISERROR('Address details could not be created in address details table!',16,1)
					RETURN
				END


			-- Letzte interne ID ermitteln
			SELECT @IDEmployeeInternal=MAX([IDEmployeeInternal]) 
						FROM  [Employees] 
						WHERE [IDSubsidiary] = @IDSubsidiary
			
			-- um eins erhöhen - das ist die neue interne ID
			IF @IDEmployeeInternal IS NULL
				SET @IDEmployeeInternal=1
			ELSE
				SET @IDEmployeeInternal = @IDEmployeeInternal + 1
				
				-- nach Umstellung auf GUIDS wird jetzt eine GUID generiert

			BEGIN TRANSACTION

			-- neuen Benutzer in Tabelle einfügen
			INSERT INTO [Employees]
				([IDSubsidiary], [IDEmployeeInternal], [IDCostCenter], [IDWageGroup],
				[UseFixedWage], [FixedWage], [Matchcode], 
				[FirstName], [LastName], [IDAddressDetails],
				[PersonnelNumber], [IsCurrent], [IsActive], [IsIncentive], 
				[WasCurrentFrom], [WasCurrentTo], [DateOfBirth], [DateOfJoining], 
				[DateOfSeparation], [TimeCardNo], [Comment], [LastEdited])
			VALUES
				(@IDSubsidiary, @IDEmployeeInternal, @IDCostCenter,@IDWageGroup,
				@UseFixedWage, @FixedWage, @Matchcode, 
				@FirstName, @LastName, @IDAddressDetail,
				@PersonnelNumber, 1, @IsActive, @IsIncentive, 
				@Now, @WasCurrentTo, @DateOfBirth, @DateOfJoining,
				@DateOfSeparation, @TimeCardNo, @Comment, @Now)
			
			if @@error!=0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE			
				COMMIT TRANSACTION
		END
		
		EXEC AddToFunctionLog @IDSubsidiary, 'Users: New user added', @CreatedByIDUser, @Now

