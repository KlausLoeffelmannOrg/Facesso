CREATE TABLE [dbo].[ProductionDataItemsForInsert] (
    [IDProductionDataItemForInsert] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]                  UNIQUEIDENTIFIER        NOT NULL,
    [IDProductionDataItem]          UNIQUEIDENTIFIER     NOT NULL,
    [IDUser]                        UNIQUEIDENTIFIER        NOT NULL,
    [IDProductionData]              UNIQUEIDENTIFIER     NOT NULL,
    [IDLabourValue]                 UNIQUEIDENTIFIER        NOT NULL,
    [IDArticle]                     UNIQUEIDENTIFIER        NOT NULL,
    [Amount]                        FLOAT (53) NOT NULL,
    [AmountViaInterface]            FLOAT (53) NOT NULL,
    [OrdinalNumber]                 INT        NOT NULL,
    [ManuallyEdited]                BIT        NOT NULL,
    [Ticket]                        DATETIME   NULL,
    CONSTRAINT [PK_ProductionDataItemForInsert] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDProductionDataItemForInsert] ASC),
    CONSTRAINT [FK_ProductionDataItemsForInsert_ProductionData] FOREIGN KEY ([IDSubsidiary], [IDProductionData]) REFERENCES [dbo].[ProductionData] ([IDSubsidiary], [IDProductionData])
);


GO
CREATE NONCLUSTERED INDEX [IX_ForFastFinding]
    ON [dbo].[ProductionDataItemsForInsert]([IDSubsidiary] ASC, [IDUser] ASC, [IDProductionData] ASC);

