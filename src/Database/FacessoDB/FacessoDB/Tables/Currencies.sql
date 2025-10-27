CREATE TABLE [dbo].[Currencies] (
    [IDCurrency]          UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [CurrencyToken]       NVARCHAR (20)  NOT NULL,
    [CurrencyCode]        NCHAR (3)      NOT NULL,
    [FactorToEuroAverage] MONEY          NOT NULL,
    [CurrencyPlainText]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED ([IDCurrency] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CurrencyToken]
    ON [dbo].[Currencies]([CurrencyToken] ASC);

