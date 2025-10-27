CREATE TABLE [dbo].[WorkGroups] (
    [IDWorkGroup]          UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]         UNIQUEIDENTIFIER             NOT NULL,
    [IDWorkGroupInternal]  INT             NOT NULL,
    [IDCostCenter]         UNIQUEIDENTIFIER             NOT NULL,
    [WorkGroupNumber]      INT             NOT NULL,
    [WorkgroupName]        NVARCHAR (100)  NOT NULL,
    [WorkGroupDescription] NVARCHAR (4000) NULL,
    [WorkloadIWT]          FLOAT (53)      CONSTRAINT [DF_WorkGroups_WorkloadIWT] DEFAULT ((480)) NOT NULL,
    [IsActive]             BIT             NOT NULL,
    [IsCurrent]            BIT             NOT NULL,
    [IsPeaceWork]          BIT             NOT NULL,
    [IsConceptional]       BIT             CONSTRAINT [DF_WorkGroups_IsConceptional] DEFAULT ('false') NOT NULL,
    [OrdinalNo]            INT             NOT NULL,
    [TimeSettingDetails]   XML             NOT NULL,
    [WasCurrentFrom]       DATETIME        NOT NULL,
    [WasCurrentTo]         DATETIME        NOT NULL,
    [LastEdited]           DATETIME        CONSTRAINT [DF_WorkGroups_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_WorkGroups] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDWorkGroup] ASC),
    CONSTRAINT [FK_WorkGroups_CostCenter] FOREIGN KEY ([IDSubsidiary], [IDCostCenter]) REFERENCES [dbo].[CostCenters] ([IDSubsidiary], [IDCostCenter]),
    CONSTRAINT [FK_WorkGroups_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dieser Datensatz wird nicht gelöscht, sondern kann nur auf "IsCurrent"=false gesetzt werden, damit die Historie der Daten erhalten bleibt... ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkGroups', @level2type = N'COLUMN', @level2name = N'WasCurrentFrom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Die Felder WasCurrentFrom und WasCurrentTo bestimmen, in welchem Zeitraum dieser Datensatz der gültige (IsCurrent=true) war.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkGroups', @level2type = N'COLUMN', @level2name = N'WasCurrentTo';

