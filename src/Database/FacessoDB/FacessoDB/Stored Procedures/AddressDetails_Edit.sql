CREATE PROCEDURE dbo.AddressDetails_Edit 
	@IDAddressDetail UNIQUEIDENTIFIER,
	@IDSubsidiary UNIQUEIDENTIFIER,
	@LastName nvarchar(100),
	@MiddleName nvarchar(100) = null,
	@FirstName nvarchar(100) = null,
	@Title nvarchar(100) = null,
	@Street nvarchar(100) = null,
	@Zip nchar(100) = null,
	@City nvarchar(100) = null,
	@CountryCode nvarchar(10) = null,
	@Country nvarchar(50) = null,
	@CompanyPhone nvarchar(50) = null,
	@PrivatePhone nvarchar(50) = null,
	@CompanyEmail nvarchar(255) = null,
	@PrivateEmail nvarchar(255) = null,
	@CompanyMobile nvarchar(50) = null,
	@PrivateMobile nvarchar(50) = null,
	@URL nvarchar(255) = null,
	@PersonnelNo int = null
	
WITH EXECUTE AS CALLER
AS
UPDATE [AddressDetails]
		SET [PersonnelNo]=@PersonnelNo,
			[LastName]=@LastName,
			[MiddleName]=@MiddleName,
			[FirstName]=@FirstName,
			[Title]=@Title,
			[Street]=@Street,
			[Zip]=@Zip,
			[City]=@City,
			[CountryCode]=@CountryCode,
			[Country]=@Country,
			[CompanyPhone]=CompanyPhone,
			[PrivatePhone]=@PrivatePhone,
			[CompanyEmail]=@CompanyEmail,
			[PrivateEmail]=@PrivateEmail,
			[CompanyMobile]=@CompanyMobile,
			[PrivateMobile]=@PrivateMobile,
			[URL]=@URL
		WHERE [IDSubsidiary]=@IDSubsidiary AND [IDAddressDetail]=@IDAddressDetail

