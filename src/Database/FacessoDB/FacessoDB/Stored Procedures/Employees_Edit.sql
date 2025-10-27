CREATE PROCEDURE dbo.Employees_Edit 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@IDEmployee UNIQUEIDENTIFIER,
	@IDCostCenter UNIQUEIDENTIFIER,
	@IDWageGroup UNIQUEIDENTIFIER,
	@UseFixedWage bit,
	@FixedWage money,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@MatchCode nvarchar(50),
	@PersonnelNumber int,
	@IsActive bit,
	@IsIncentive bit,
	@DateOfBirth datetime,
	@DateOfJoining datetime,
	@DateOfSeparation datetime,
	@TimeCardNo nvarchar(50),
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
	@IDEmployeeNew UNIQUEIDENTIFIER OUTPUT

	WITH EXECUTE AS CALLER
	AS

	-- Die fehlenden Felder, die schon da sind
	DECLARE @IDEmployeeInternal INT,
			@IDAddressDetails UNIQUEIDENTIFIER,
			@IsCurrent bit,
			@WasCurrentFrom DateTime,
			@WasCurrentTo DateTime,
			@PersonnelNumberOriginal int,
			@DoesExist bit

	-- Aktuelle Zeit
	DECLARE	@Now DateTime
	SET @Now=GetDate()

	-- Versuchen, die Daten direkt zu ändern, indem wir sie löschen
	-- und neu einfügen. Wenn das schief geht, werden sie referenziert.
	-- Dann müssen wir uns um die Historie kümmern.
	
	-- Erstmal schauen, ob der Datensatz existiert!
	IF NOT EXISTS(SELECT * FROM [Employees]
							WHERE [IDEmployee]=@IDEmployee AND [IDSubsidiary]=@IDSubsidiary)
			BEGIN
				RAISERROR('The specified employee does not exist!',16,1)
				RETURN
			END
	
	-- Die fehlenden Daten ergänzen
	SELECT	@IDEmployeeInternal = [IDEmployeeInternal],
			@IDAddressDetails =[IDAddressDetails],
			@PersonnelNumberOriginal = [PersonnelNumber],
			@WasCurrentFrom = [WasCurrentFrom],
			@WasCurrentTo = [WasCurrentTo]
		FROM [Employees]
		WHERE [IDEmployee]=@IDEmployee AND [IDSubsidiary]=@IDSubsidiary

	-- Prüfen, ob sich die *Personalnummer* ändern wird. Falls
	-- ja, dann schauen, ob es die neue Personalnummer schon AKTIV gibt.
	IF @PersonnelNumber<>@PersonnelNumberOriginal
		BEGIN
			EXEC Employees_DoesPersonnelNumberExist	@IDSubsidiary, 
													@PersonnelNumber,
													null,
													@DoesExist
			IF @DoesExist=1
				BEGIN
					RAISERROR('The specified new personnel number does already exist!',16,1)
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
			
			UPDATE [Employees]
			SET 
				[IDCostCenter]=@IDCostCenter,
				[IDWageGroup]=@IDWageGroup,
				[UseFixedWage]=@UseFixedWage,
				[LastName]=@LastName,
				[FirstName]=@FirstName,
				[MatchCode]=@Matchcode,
				[PersonnelNumber]=@PersonnelNumber,
				[IsActive]=@IsActive,
				[IsIncentive]=@IsIncentive,
				[DateOfBirth]=@DateOfBirth,
				[DateOfJoining]=@DateOfJoining,
				[DateOfSeparation]=@DateOfSeparation,
				[TimeCardNo]=@TimeCardNo,
				[LastEdited]=GetDate(),
				[Comment]=@Comment
			WHERE [IDEmployee]=@IDEmployee AND [IDSubsidiary]=IDSubsidiary

			-- Aus Kompatiblitätsgründen zur Historienpflege für die Enterprise
			-- muss die ID zurückgegeben werden.
			IF @@error!=0 BEGIN
				ROLLBACK TRANSACTION
				RAISERROR('An error occured while updating the Employees Table! Rolling Back.',16,1)
				RETURN
			END
			Set @IDEmployeeNew = @IDEmployee
			COMMIT TRANSACTION
		END

		EXEC AddToFunctionLog @IDSubsidiary, 'Employees: Employee edited', @LastEditedByIDUser, @Now
