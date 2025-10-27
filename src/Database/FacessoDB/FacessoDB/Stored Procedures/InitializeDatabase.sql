CREATE PROCEDURE InitializeDatabase
	@CryptedAdminPassword varbinary(128),
	@CryptedSystemPassword varbinary(128),
	@SubsidiaryName nvarchar(100),
	@SubsidiaryStreet nvarchar(100),
	@SubsidiaryZip nvarchar(10),
	@SubsidiaryCity nvarchar(100),
	@SubsidiaryCountryCode nvarchar(10),
	@SubsidiaryCountry nvarchar(100),
	@SubsidiaryPrimaryPhone nvarchar(100),
	@CostCenterName nvarChar(100),
	@CostCenterDescription nvarChar(4000)

WITH EXECUTE AS CALLER
AS
DECLARE @IDSystemUser UNIQUEIDENTIFIER
DECLARE @IDSubsidiary UNIQUEIDENTIFIER
DECLARE @IDSystemCostCenter UNIQUEIDENTIFIER
DECLARE @IDEuroCurrency UNIQUEIDENTIFIER
DECLARE @IDCurrency UNIQUEIDENTIFIER

-- Alle Tabelleninhalte löschen
EXEC dbo.SafelyTruncateAllTables

BEGIN TRANSACTION

-- Filiale anlegen
INSERT INTO Subsidiaries
           (SubsidiaryName, Street, Zip, City, CountryCode, Country, PrimaryPhone, LastEdited)
     VALUES
           (@SubsidiaryName, @SubsidiaryStreet, @SubsidiaryZip, @SubsidiaryCity, 
            @SubsidiaryCountryCode, @SubsidiaryCountry, @SubsidiaryPrimaryPhone,
            GetDate())

SET @IDSubsidiary='86E7FF98-E9EC-4B3C-A420-15B00EF1A08D'

-- Währungstabelle anlegen
EXEC Currencies_Add '€', 'EUR', 1, 'Euro', @IDEuroCurrency OUTPUT;
EXEC Currencies_Add 'CHF', 'CHF', 0.6496, 'Schweizer Franken', @IDCurrency OUTPUT;
EXEC Currencies_Add 'DKK', 'DKK', 0.1343, 'Dänische Kronen', @IDCurrency OUTPUT;
EXEC Currencies_Add '£', 'GBP', 1.4785, 'Britische Pfund', @IDCurrency OUTPUT;
EXEC Currencies_Add 'PLN', 'PLN', 0.2339, 'Polnischer Zloty', @IDCurrency OUTPUT;
EXEC Currencies_Add 'CZK', 'CZK', 0.03275, 'Tschechische Krone', @IDCurrency OUTPUT;
EXEC Currencies_Add '$', 'USD', 0.7739, 'U.S. Dollar', @IDCurrency OUTPUT;

-- Basiskostenstelle anlegen
INSERT INTO [dbo].[CostCenters]
			([IDSubsidiary],[IDCostCenterInternal], [IsCurrent], [CostCenterNo],
			 [CostCenterName],[CostCenterDescription],[IDCurrency], [IncentiveIndicatorSynonym],
			 [IncentiveWageSynonym], [IncentiveIndicatorDimension], [IncentiveIndicatorPrecision],
			 [UseFixValuedBonus], [IncentiveIndicatorFactor], [BaseValuePrecision], [BaseValueSynonym],
			 [WasCurrentFrom],[WasCurrentTo], [LastEdited])
	Values
			(@IDSubsidiary,0,1,0,@CostCenterName,@CostCenterDescription, 
			 @IDEuroCurrency, 'Zeitgrad', 'Prämienlohn', '%',0,
			 'false',1,3,'te in HMin',
			 GetDate(), '12/31/2199',GetDate())

SET @IDSystemCostCenter='59FFEF85-3564-40DC-94D6-85916A7DEF12'

-- Facesso!GenericSystem als Benutzer anlegen.
INSERT INTO [dbo].[Users]
           ([IDUserInternal],[IDSubsidiary],[IDCostCenter],[FirstName],
            [LastName],[IDAddressDetails],[Username],[Password],[ClearanceLevel],
            [HasWorkstationAccess],[HasInternetAccess],[IsActivated],[DoesExpire],[ExpireDate],
            [IsSystemAccount], [WasCurrentFrom],[WasCurrentTo],[Comment],[IsCurrent])
     VALUES
           (-1,@IDSubsidiary,@IDSystemCostCenter,'Facesso','GenericSystem',null,'Facesso!GenericSystem',
           @CryptedSystemPassword,-1,1,1,1,0,'12/31/2199',
           1,GetDate(),'12/31/2199','Systemkonto - darf nicht gelöscht werden',1)
           
SET @IDSystemUser='A4F8C78C-23E3-429E-B96C-3F6C30DE34AF'

-- Lohntabelle für die Basiskostenstelle anlegen
EXEC BonusList_CreateBaseList @IDSystemCostCenter, @IDSubsidiary, @IDSystemUser

-- Facesso!TimeDataInterface als Benutzer anlegen.
           INSERT INTO [dbo].[Users]
           ([IDUserInternal],[IDSubsidiary],[IDCostCenter],[FirstName],
            [LastName],[IDAddressDetails],[Username],[Password],[ClearanceLevel],
            [HasWorkstationAccess],[HasInternetAccess],[IsActivated],[DoesExpire],[ExpireDate],
            [IsSystemAccount], [WasCurrentFrom],[WasCurrentTo],[Comment],[IsCurrent])
     VALUES
           (-2,@IDSubsidiary,@IDSystemCostCenter,'Facesso','TimeDataInterface',null,'Facesso!TimeDataInterface',
           @CryptedSystemPassword,-1,1,1,1,0,'12/31/2199',
           1,GetDate(),'12/31/2199','Systemkonto - darf nicht gelöscht werden', 1)

-- Facesso!ProdDataInterface als Benutzer anlegen.
           INSERT INTO [dbo].[Users]
           ([IDUserInternal],[IDSubsidiary],[IDCostCenter],[FirstName],
            [LastName],[IDAddressDetails],[Username],[Password],[ClearanceLevel],
            [HasWorkstationAccess],[HasInternetAccess],[IsActivated],[DoesExpire],[ExpireDate],
            [IsSystemAccount], [WasCurrentFrom],[WasCurrentTo],[Comment],[IsCurrent])
     VALUES
           (-3,@IDSubsidiary,@IDSystemCostCenter,'Facesso','ProdDataInterface',null,'Facesso!ProdDataInterface',
           @CryptedSystemPassword,-1,1,1,1,0,'12/31/2199',
           1,GetDate(),'12/31/2199','Systemkonto - darf nicht gelöscht werden',1)

-- Den Administrator als Benutzer anlegen
INSERT INTO [dbo].[Users]
           ([IDUserInternal],[IDSubsidiary],[IDCostCenter],[FirstName],[LastName],[IDAddressDetails],
           [Username],[Password],[ClearanceLevel],[HasWorkstationAccess],[HasInternetAccess],
           [IsActivated],[DoesExpire],[ExpireDate],[IsSystemAccount],[WasCurrentFrom],
           [WasCurrentTo],[Comment],[IsCurrent])
     VALUES
           (0,@IDSubsidiary,@IDSystemCostCenter,'Facesso','Administrator',null,'Administrator',
           @CryptedAdminPassword,-1,1,1,1,0,'12/31/2199',
           0,GetDate(),'12/31/2199','Administratorkonto - darf nicht gelöscht werden',1)

COMMIT TRANSACTION
