CREATE TABLE [dbo].[ParamsWorkGroups] (
    [IDParamsWorkGroups] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]       UNIQUEIDENTIFIER      NOT NULL,
    [IDUser]             UNIQUEIDENTIFIER      NOT NULL,
    [Ticket]             DATETIME NOT NULL,
    [IDWorkGroup]        UNIQUEIDENTIFIER      NOT NULL,
    CONSTRAINT [PK_ParamsWorkGroups] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDParamsWorkGroups] ASC, [IDUser] ASC, [Ticket] ASC),
    CONSTRAINT [FK_ParamsWorkGroups_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

