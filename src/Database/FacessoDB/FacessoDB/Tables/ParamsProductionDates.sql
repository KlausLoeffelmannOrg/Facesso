CREATE TABLE [dbo].[ParamsProductionDates] (
    [IDParamsProductionDates] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]            UNIQUEIDENTIFIER      NOT NULL,
    [IDUser]                  UNIQUEIDENTIFIER      NOT NULL,
    [Ticket]                  DATETIME NOT NULL,
    [ProductionDate]          DATETIME NOT NULL,
    [Shift]                   TINYINT  NOT NULL,
    [Tag]                     BIGINT   NULL,
    CONSTRAINT [PK_ParamsProductionDates] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDParamsProductionDates] ASC, [IDUser] ASC, [Ticket] ASC),
    CONSTRAINT [FK_ParamsProductionDates_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

