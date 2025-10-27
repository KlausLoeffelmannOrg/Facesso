CREATE TABLE [dbo].[BonusLists] (
    [IDBonusLists]   UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]   UNIQUEIDENTIFIER      NOT NULL,
    [IDCostCenter]   UNIQUEIDENTIFIER      NOT NULL,
    [WasCurrentFrom] DATETIME NULL,
    [WasCurrentTo]   DATETIME NULL,
    [IsCurrent]      BIT      NULL,
    [LastEdited]     DATETIME CONSTRAINT [DF_BonusLists_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_BonusLists] PRIMARY KEY CLUSTERED ([IDBonusLists] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_BonusLists_CostCenter] FOREIGN KEY ([IDSubsidiary], [IDCostCenter]) REFERENCES [dbo].[CostCenters] ([IDSubsidiary], [IDCostCenter])
);

