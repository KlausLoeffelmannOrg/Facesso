CREATE TABLE [dbo].[ApplicationSettings] (
    [IDApplicationSettings] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]          UNIQUEIDENTIFIER NOT NULL,
    [IsGlobal]              BIT NOT NULL,
    [IDUser]                UNIQUEIDENTIFIER NOT NULL,
    [Settings]              XML NOT NULL,
    CONSTRAINT [PK_ApplicationSettings] PRIMARY KEY CLUSTERED ([IDApplicationSettings] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_ApplicationSettings_Users] FOREIGN KEY ([IDSubsidiary], [IDUser]) REFERENCES [dbo].[Users] ([IDSubsidiary], [IDUser])
);

