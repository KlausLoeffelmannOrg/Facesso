CREATE PROCEDURE dbo.AddressDetails_Add 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@LastName [nvarchar](100),
	@MiddleName [nvarchar](100) = null,
	@FirstName [nvarchar](100) = null,
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
	@IDAddressDetail UNIQUEIDENTIFIER
	
WITH EXECUTE AS CALLER
AS

INSERT INTO [dbo].[AddressDetails]
           ([IDSubsidiary]
		   --,[IDAddressDetail]
		   ,[PersonnelNo]
           ,[LastName]
           ,[MiddleName]
           ,[FirstName]
           ,[Title]
           ,[Street]
           ,[Zip]
           ,[City]
           ,[CountryCode]
           ,[Country]
           ,[CompanyPhone]
           ,[PrivatePhone]
           ,[CompanyEmail]
           ,[PrivateEmail]
           ,[CompanyMobile]
           ,[PrivateMobile]
           ,[URL])
     VALUES
           (@IDSubsidiary
		   --,@IDAddressDetail
		   ,@PersonnelNo
           ,@LastName
           ,@MiddleName
           ,@FirstName
           ,@Title
           ,@Street
           ,@Zip
           ,@City
           ,@CountryCode
           ,@Country
           ,@CompanyPhone
           ,@PrivatePhone
           ,@CompanyEmail
           ,@PrivateEmail
           ,@CompanyMobile
           ,@PrivateMobile
           ,@URL)

RETURN


