CREATE TABLE [dbo].[BonusList] (
    [IDBonusList]   UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]  UNIQUEIDENTIFIER      NOT NULL,
    [IDBonusLists]  UNIQUEIDENTIFIER      NOT NULL,
    [DegreeOfTime]  MONEY    NOT NULL,
    [Percentage]    MONEY    NOT NULL,
    [AbsoluteValue] MONEY    NOT NULL,
    [LastEdited]    DATETIME CONSTRAINT [DF_BonusList_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_BonusList] PRIMARY KEY CLUSTERED ([IDBonusList] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_BonusList_BonusLists] FOREIGN KEY ([IDBonusLists], [IDSubsidiary]) REFERENCES [dbo].[BonusLists] ([IDBonusLists], [IDSubsidiary])
);

