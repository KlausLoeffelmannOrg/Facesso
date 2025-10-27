CREATE TABLE [dbo].[WageGroups] (
    [IDWageGroup]         UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]        UNIQUEIDENTIFIER            NOT NULL,
    [IDWageGroupInternal] INT            NOT NULL,
    [IDCurrency]          UNIQUEIDENTIFIER            NOT NULL,
    [IsTemplate]          BIT            NOT NULL,
    [WageGroupToken]      NVARCHAR (20)  NOT NULL,
    [Comment]             NVARCHAR (MAX) NULL,
    [HourlyRate]          MONEY          NOT NULL,
    [WasCurrentFrom]      DATETIME       NOT NULL,
    [WasCurrentTo]        DATETIME       NOT NULL,
    [IsCurrent]           BIT            NOT NULL,
    [LastEdited]          DATETIME       CONSTRAINT [DF_WageGroups_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_WageGroups] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDWageGroup] ASC),
    CONSTRAINT [FK_WageGroups_Currencies] FOREIGN KEY ([IDCurrency]) REFERENCES [dbo].[Currencies] ([IDCurrency]),
    CONSTRAINT [FK_WageGroups_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WageGroups_WageGroupToken]
    ON [dbo].[WageGroups]([WageGroupToken] ASC);

