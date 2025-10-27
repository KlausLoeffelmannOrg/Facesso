CREATE TABLE [dbo].[Articles] (
    [IDArticle]       UNIQUEIDENTIFIER             NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]    UNIQUEIDENTIFIER             NOT NULL,
    [IDMachine]       INT             NOT NULL,
    [IDCostCenter]    INT             NOT NULL,
    [IDLabourValue]   INT             NOT NULL,
    [ItemNumber]      NVARCHAR (50)   NOT NULL,
    [ItemName]        NVARCHAR (100)  NOT NULL,
    [ItemDescription] NVARCHAR (4000) NOT NULL,
    [IsActive]        BIT             NOT NULL,
    [IsCurrent]       BIT             NOT NULL,
    [WasCurrentFrom]  DATETIME        NOT NULL,
    [WasCurrentTo]    DATETIME        NOT NULL,
    [LastEdited]      DATETIME        CONSTRAINT [DF_Articles_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([IDArticle] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_Articles_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dieser Datensatz wird nicht gelöscht, sondern kann nur auf "IsCurrent"=false gesetzt werden, damit die Historie der Daten erhalten bleibt... ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Articles', @level2type = N'COLUMN', @level2name = N'WasCurrentFrom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Die Felder WasCurrentFrom und WasCurrentTo bestimmen, in welchem Zeitraum dieser Datensatz der gültige (IsCurrent=true) war.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Articles', @level2type = N'COLUMN', @level2name = N'WasCurrentTo';

