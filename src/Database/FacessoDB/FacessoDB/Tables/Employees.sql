CREATE TABLE [dbo].[Employees] (
    [IDEmployee]         UNIQUEIDENTIFIER             NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]       UNIQUEIDENTIFIER             NOT NULL,
    [IDEmployeeInternal] INT             NOT NULL,
    [IDCostCenter]       UNIQUEIDENTIFIER             NOT NULL,
    [IDWageGroup]        UNIQUEIDENTIFIER             NULL,
    [UseFixedWage]       BIT             NOT NULL,
    [FixedWage]          MONEY           NULL,
    [IDAddressDetails]   UNIQUEIDENTIFIER             NOT NULL,
    [LastName]           NVARCHAR (100)  NOT NULL,
    [FirstName]          NVARCHAR (100)  NOT NULL,
    [Matchcode]          NVARCHAR (50)   NULL,
    [PersonnelNumber]    INT             NOT NULL,
    [IsCurrent]          BIT             NOT NULL,
    [IsActive]           BIT             NOT NULL,
    [IsIncentive]        BIT             NOT NULL,
    [WasCurrentFrom]     DATETIME        NOT NULL,
    [WasCurrentTo]       DATETIME        NOT NULL,
    [DateOfBirth]        DATETIME        NULL,
    [DateOfJoining]      DATETIME        NULL,
    [DateOfSeparation]   DATETIME        NULL,
    [TimeCardNo]         NVARCHAR (50)   NULL,
    [Comment]            NVARCHAR (4000) NULL,
    [LastEdited]         DATETIME        CONSTRAINT [DF_Employees_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDEmployee] ASC),
    CONSTRAINT [FK_Employees_AddressDetails] FOREIGN KEY ([IDSubsidiary], [IDAddressDetails]) REFERENCES [dbo].[AddressDetails] ([IDSubsidiary], [IDAddressDetail]),
    CONSTRAINT [FK_Employees_CostCenter] FOREIGN KEY ([IDSubsidiary], [IDCostCenter]) REFERENCES [dbo].[CostCenters] ([IDSubsidiary], [IDCostCenter]),
    CONSTRAINT [FK_Employees_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary]),
    CONSTRAINT [FK_Employees_WageGroups] FOREIGN KEY ([IDSubsidiary], [IDWageGroup]) REFERENCES [dbo].[WageGroups] ([IDSubsidiary], [IDWageGroup])
);


GO
CREATE NONCLUSTERED INDEX [IX_Employees_LastName]
    ON [dbo].[Employees]([LastName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Employees_PersonnelNumber]
    ON [dbo].[Employees]([PersonnelNumber] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Bestimmt, ob ein Mitarbeiter einen fixen Betrag erhält, und nicht auf die Lohngruppentabelle (WageGroup) zurückgreift.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'UseFixedWage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Kennzeichnet, ob der aktuelle Datensatz der verwendete und kein solcher ist, der auf Grund von Änderungen als Historiedatensatz gilt.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'IsCurrent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Bestimmt, ob der aktuelle Mitarbeiter aktiviert ist. Nur aktivierte Mitarbeiter erscheinen in Auswahlen und nur aktivierte Mitarbeiter werden als Zählbasis für das jeweilige Lizenzmodell gewertet.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'IsActive';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dieser Datensatz wird nicht gelöscht, sondern kann nur auf "IsCurrent"=false gesetzt werden, damit die Historie der Daten erhalten bleibt... ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'WasCurrentFrom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Die Felder WasCurrentFrom und WasCurrentTo bestimmen, in welchem Zeitraum dieser Datensatz der gültige (IsCurrent=true) war.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'WasCurrentTo';

