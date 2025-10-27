CREATE TABLE [dbo].[CostCenters] (
    [IDCostCenter]                UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]                UNIQUEIDENTIFIER             NOT NULL,
    [IDCostCenterInternal]        INT             NOT NULL,
    [IsCurrent]                   BIT             NOT NULL,
    [CostCenterNo]                INT             NOT NULL,
    [CostCenterName]              NVARCHAR (100)  NOT NULL,
    [CostCenterDescription]       NVARCHAR (4000) NULL,
    [IDCurrency]                  UNIQUEIDENTIFIER             NOT NULL,
    [IncentiveIndicatorSynonym]   NVARCHAR (50)   NOT NULL,
    [IncentiveWageSynonym]        NVARCHAR (50)   NOT NULL,
    [IncentiveIndicatorDimension] NVARCHAR (10)   NOT NULL,
    [IncentiveIndicatorPrecision] TINYINT         CONSTRAINT [DF_CostCenters_IncentiveDecimalPlaces] DEFAULT ((0)) NOT NULL,
    [UseFixValuedBonus]           BIT             NOT NULL,
    [IncentiveIndicatorFactor]    FLOAT (53)      NOT NULL,
    [BaseValuePrecision]          TINYINT         CONSTRAINT [DF_CostCenters_TePrecision] DEFAULT ((2)) NOT NULL,
    [BaseValueSynonym]            NVARCHAR (50)   CONSTRAINT [DF_CostCenters_BaseValueSynonym] DEFAULT (N'te in h/min') NOT NULL,
    [WasCurrentFrom]              DATETIME        NOT NULL,
    [WasCurrentTo]                DATETIME        NOT NULL,
    [LastEdited]                  DATETIME        CONSTRAINT [DF_CostCenters_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_CostCenters] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDCostCenter] ASC),
    CONSTRAINT [FK_CostCenters_Currencies] FOREIGN KEY ([IDCurrency]) REFERENCES [dbo].[Currencies] ([IDCurrency])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dieser Datensatz wird nicht gelöscht, sondern kann nur auf "IsCurrent"=false gesetzt werden, damit die Historie der Daten erhalten bleibt... ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CostCenters', @level2type = N'COLUMN', @level2name = N'WasCurrentFrom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Die Felder WasCurrentFrom und WasCurrentTo bestimmen, in welchem Zeitraum dieser Datensatz der gültige (IsCurrent=true) war.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CostCenters', @level2type = N'COLUMN', @level2name = N'WasCurrentTo';

