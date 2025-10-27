CREATE TABLE [dbo].[Users] (
    [IDUser]               UNIQUEIDENTIFIER             NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]         UNIQUEIDENTIFIER             NOT NULL,
    [IDUserInternal]       INT             NOT NULL,
    [IDCostCenter]         UNIQUEIDENTIFIER             NOT NULL,
    [FirstName]            NVARCHAR (100)  NOT NULL,
    [LastName]             NVARCHAR (100)  NOT NULL,
    [IDAddressDetails]     UNIQUEIDENTIFIER             NULL,
    [Username]             NVARCHAR (100)  NOT NULL,
    [Password]             VARBINARY (128) NOT NULL,
    [ClearanceLevel]       BIGINT          NOT NULL,
    [HasWorkstationAccess] BIT             NOT NULL,
    [HasInternetAccess]    BIT             NOT NULL,
    [IsActivated]          BIT             NOT NULL,
    [IsCurrent]            BIT             NULL,
    [DoesExpire]           BIT             NOT NULL,
    [ExpireDate]           DATETIME        NOT NULL,
    [IsSystemAccount]      BIT             NOT NULL,
    [WasCurrentFrom]       DATETIME        NOT NULL,
    [WasCurrentTo]         DATETIME        NOT NULL,
    [Comment]              NTEXT           NULL,
    [LastEdited]           DATETIME        CONSTRAINT [DF_Users_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDUser] ASC),
    CONSTRAINT [FK_Users_AddressDetails] FOREIGN KEY ([IDSubsidiary], [IDAddressDetails]) REFERENCES [dbo].[AddressDetails] ([IDSubsidiary], [IDAddressDetail]),
    CONSTRAINT [FK_Users_CostCenters] FOREIGN KEY ([IDSubsidiary], [IDCostCenter]) REFERENCES [dbo].[CostCenters] ([IDSubsidiary], [IDCostCenter]),
    CONSTRAINT [FK_Users_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);


GO
CREATE NONCLUSTERED INDEX [IX_IDUserInternal]
    ON [dbo].[Users]([IDUserInternal] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Username]
    ON [dbo].[Users]([Username] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Users_IDAddressDetails]
    ON [dbo].[Users]([IDAddressDetails] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UsersLastNameFirstName]
    ON [dbo].[Users]([LastName] ASC, [FirstName] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dieser Datensatz wird nicht gelöscht, sondern kann nur auf "IsCurrent"=false gesetzt werden, damit die Historie der Daten erhalten bleibt... ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'WasCurrentFrom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Die Felder WasCurrentFrom und WasCurrentTo bestimmen, in welchem Zeitraum dieser Datensatz der gültige (IsCurrent=true) war.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'WasCurrentTo';

