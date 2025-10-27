CREATE TABLE [dbo].[LabourValues] (
    [IDLabourValue]          UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]           UNIQUEIDENTIFIER            NOT NULL,
    [IDLabourValueInternal]  INT            NOT NULL,
    [IDCostCenter]           UNIQUEIDENTIFIER            NOT NULL,
    [LabourValueNumber]      INT            NOT NULL,
    [LabourValueName]        NVARCHAR (100) NOT NULL,
    [LabourValueDescription] NVARCHAR (MAX) NULL,
    [TeHMin]                 FLOAT (53)     NOT NULL,
    [Dimension]              NVARCHAR (100) NOT NULL,
    [IsActive]               BIT            NOT NULL,
    [IsCurrent]              BIT            NOT NULL,
    [WasCurrentFrom]         DATETIME       NOT NULL,
    [WasCurrentTo]           DATETIME       NOT NULL,
    [LastEdited]             DATETIME       CONSTRAINT [DF_LabourValues_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_LabourValues] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDLabourValue] ASC),
    CONSTRAINT [FK_LabourValues_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dieser Datensatz wird nicht gelöscht, sondern kann nur auf "IsCurrent"=false gesetzt werden, damit die Historie der Daten erhalten bleibt... ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LabourValues', @level2type = N'COLUMN', @level2name = N'WasCurrentFrom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Die Felder WasCurrentFrom und WasCurrentTo bestimmen, in welchem Zeitraum dieser Datensatz der gültige (IsCurrent=true) war.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LabourValues', @level2type = N'COLUMN', @level2name = N'WasCurrentTo';

