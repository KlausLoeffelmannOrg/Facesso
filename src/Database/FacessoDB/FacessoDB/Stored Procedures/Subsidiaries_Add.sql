CREATE PROCEDURE Subsidiaries_Add
	@SubsidiaryName nvarchar(100),
	@SubsidiaryStreet nvarchar(100),
	@SubsidiaryZip nvarchar(10),
	@SubsidiaryCity nvarchar(100),
	@SubsidiaryCountryCode nvarchar(10),
	@SubsidiaryCountry nvarchar(100),
	@SubsidiaryPrimaryPhone nvarchar(100),
	@CreatedByIDUser UNIQUEIDENTIFIER,
	@IDSubsidiaryCreated int,
	@IDSubsidiaryNew UNIQUEIDENTIFIER OUTPUT

WITH EXECUTE AS CALLER
AS

DECLARE @IDAdminUser UNIQUEIDENTIFIER
DECLARE @IDSystemCostCenter UNIQUEIDENTIFIER
DECLARE @IDEuroCurrency int
DECLARE @IDCurrency int

BEGIN TRANSACTION

-- Filiale anlegen
INSERT INTO Subsidiaries
           (SubsidiaryName, Street, Zip, City, CountryCode, Country, PrimaryPhone, LastEdited)
     VALUES
           (@SubsidiaryName, @SubsidiaryStreet, @SubsidiaryZip, @SubsidiaryCity, 
            @SubsidiaryCountryCode, @SubsidiaryCountry, @SubsidiaryPrimaryPhone,
            GetDate())
            
--SET @IDSubsidiaryNew=SCOPE_IDENTITY()

IF @@ERROR>0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR('Inserting Subsidiary failed while inserting the Subsidiaries-Record',16,1)
		RETURN
	END

-- Basiskostenstelle anlegen, diese dabei von der der ersten Subsidiary übernehmen
INSERT CostCenters (IDSubsidiary, IDCostCenterInternal, IsCurrent, CostCenterNo, CostCenterName, CostCenterDescription, IDCurrency, IncentiveIndicatorSynonym, IncentiveWageSynonym, IncentiveIndicatorDimension, IncentiveIndicatorPrecision, UseFixValuedBonus, IncentiveIndicatorFactor, BaseValuePrecision, BaseValueSynonym, WasCurrentFrom, WasCurrentTo, LastEdited)
SELECT	@IDSubsidiaryNew as IDSubsidiary,
		1 as IDCostCenterInternal, 
		'true' as IsCurrent, 
		CostCenterNo,
		CostCenterName,
		CostCenterDescription,
		IDCurrency,
		IncentiveIndicatorSynonym,
		IncentiveWageSynonym,
		IncentiveIndicatorDimension,
		IncentiveIndicatorPrecision,
		UseFixValuedBonus,
		IncentiveIndicatorFactor,
		BaseValuePrecision,
		BaseValueSynonym,
		Getdate() as WasCurrentFrom,
		'12/31/2199' as WasCurrentTo,
		GetDate() as LastEdited
FROM CostCenters
WHERE IDSubsidiary='86E7FF98-E9EC-4B3C-A420-15B00EF1A08D' AND CostCenterNo=0

--SET @IDSystemCostCenter=SCOPE_IDENTITY()

IF @@ERROR>0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR('Inserting Subsidiary failed while inserting base cost center',16,1)
		RETURN
	END

-- Den Administrator als Benutzer anlegen; auch aus der Stamm-Subsidiary kopieren
SET @IDAdminUser=NEWID()

INSERT Users (IDUSER, IDSubsidiary, IDUserInternal, IDCostCenter, FirstName, LastName, IDAddressDetails, Username, Password, ClearanceLevel, HasWorkstationAccess, HasInternetAccess, IsActivated, IsCurrent, DoesExpire, [ExpireDate], IsSystemAccount, WasCurrentFrom, WasCurrentTo, Comment, LastEdited)
SELECT @IDAdminUser as IDUSER,
@IDSubsidiaryNew as IDSubsidiary,
	   null as IDUserInternal,
	   @IDSystemCostCenter as IDCostCenter,
	   FirstName,
	   LastName,
	   null as IDAddressDetails,
	   Username,
	   Password,
	   ClearanceLevel,
	   'true' as HasWorkstationAccess,
	   'true' as HasInternetAccess,
       'true' as IsActivated,
       'true' as IsCurrent,
       'false' as DoesExpire,
       '12/31/2199' as ExpireDate,
       'true' as IsSystemAccount,
       getdate() as WasCurrentFrom,
       '12/31/2199' as WasCurrentTo,
       null as Comment,
       GetDate() as LastEdited
FROM Users
WHERE IDSubsidiary='86E7FF98-E9EC-4B3C-A420-15B00EF1A08D' AND IDUserInternal=0 

IF @@ERROR>0 
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR('Inserting Subsidiary failed while inserting the new subsidiary administrator',16,1)
		RETURN
	END

-- Lohntabelle für die Basiskostenstelle anlegen
EXEC BonusList_CreateBaseList @IDSystemCostCenter, @IDSubsidiaryNew, @IDAdminUser

-- Anlegen der Subsidiary ins Log eintragen
DECLARE @now datetime
SET @now=getdate()
EXEC AddToFunctionLog @IDSubsidiaryCreated, 'Subsidiary: Added new', @CreatedByIDUser, @now ,null
COMMIT TRANSACTION
