CREATE PROCEDURE Subsidiaries_Edit
	@IDSubsidiary UNIQUEIDENTIFIER,
	@SubsidiaryName nvarchar(100),
	@SubsidiaryStreet nvarchar(100),
	@SubsidiaryZip nvarchar(10),
	@SubsidiaryCity nvarchar(100),
	@SubsidiaryCountryCode nvarchar(10),
	@SubsidiaryCountry nvarchar(100),
	@SubsidiaryPrimaryPhone nvarchar(100),
	@LastEditedByIDUser UNIQUEIDENTIFIER,
	@IDSubsidiaryEdited UNIQUEIDENTIFIER

WITH EXECUTE AS CALLER
AS

UPDATE Subsidiaries
SET SubsidiaryName=@SubsidiaryName,
    Street=@SubsidiaryStreet,
    Zip=@SubsidiaryZip,
    City=@SubsidiaryCity,
    CountryCode=@SubsidiaryCountryCode,
    Country=@SubsidiaryCountry,
    PrimaryPhone=@SubsidiaryPrimaryPhone
WHERE IDSubsidiary=@IDSubsidiary

-- Editieren der Subsidiary ins Log eintragen
DECLARE @now datetime
SET @now=getdate()
EXEC AddToFunctionLog @IDSubsidiaryEdited, 'Subsidiary: Edited', @LastEditedByIDUser, @now ,null

