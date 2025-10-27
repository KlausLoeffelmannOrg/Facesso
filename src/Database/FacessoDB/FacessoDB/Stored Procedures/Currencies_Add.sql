CREATE PROCEDURE dbo.Currencies_Add
	@CurrencyToken nvarchar(20),
	@CurrencyCode nchar(3),
	@FactorToEuroAverage money,
	@CurrencyPlainText nvarchar(50),
	@NewIDCurrency int OUTPUT
AS
	INSERT INTO [Currencies] ([CurrencyToken], [CurrencyCode], [FactorToEuroAverage], [CurrencyPlainText])
	VALUES (@CurrencyToken, @CurrencyCode, @FactorToEuroAverage, @CurrencyPlainText)
	
	--SET @NewIDCurrency = SCOPE_IDENTITY()
	
