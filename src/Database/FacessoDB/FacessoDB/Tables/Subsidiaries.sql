CREATE TABLE [dbo].[Subsidiaries] (
    [IDSubsidiary]   UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [SubsidiaryName] NVARCHAR (100) NOT NULL,
    [Street]         NVARCHAR (100) NOT NULL,
    [Zip]            NVARCHAR (100) NOT NULL,
    [City]           NVARCHAR (100) NOT NULL,
    [CountryCode]    NVARCHAR (10)  NOT NULL,
    [Country]        NVARCHAR (100) NOT NULL,
    [PrimaryPhone]   NVARCHAR (100) NOT NULL,
    [LastEdited]     DATETIME       CONSTRAINT [DF_Subsidiaries_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Subsidiaries] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC)
);

