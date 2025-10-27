CREATE TABLE [dbo].[NotificationRecipients] (
    [IDSubsidiary]            UNIQUEIDENTIFIER            NOT NULL,
    [IDNotificationRecipient] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [Title]                   NVARCHAR (100) NULL,
    [FirstName]               NVARCHAR (100) NOT NULL,
    [LastName]                NVARCHAR (100) NOT NULL,
    [SMTPAddress]             NVARCHAR (255) NOT NULL,
    [SMTPAddressFallOver]     NVARCHAR (255) NULL,
    [IsGlobal]                BIT            NOT NULL,
    [Tag]                     NVARCHAR (255) NULL,
    [LastEdited]              DATETIME       CONSTRAINT [DF_NotificationRecepients_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_NotificationRecepients] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDNotificationRecipient] ASC),
    CONSTRAINT [FK_NotificationRecepients_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

