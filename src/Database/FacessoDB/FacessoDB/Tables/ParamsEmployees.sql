CREATE TABLE [dbo].[ParamsEmployees] (
    [IDParamsEmployees] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]      UNIQUEIDENTIFIER      NOT NULL,
    [IDUser]            UNIQUEIDENTIFIER      NOT NULL,
    [Ticket]            DATETIME NOT NULL,
    [IDEmployee]        UNIQUEIDENTIFIER      NOT NULL,
    CONSTRAINT [PK_ParamsEmployees] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDParamsEmployees] ASC, [IDUser] ASC, [Ticket] ASC),
    CONSTRAINT [FK_ParamsEmployees_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

