CREATE TABLE [dbo].[FunctionLog] (
    [IDFunctionLog]  UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]   UNIQUEIDENTIFIER            NOT NULL,
    [FunctionText]   NVARCHAR (MAX) NOT NULL,
    [CalledByIDUser] UNIQUEIDENTIFIER            NOT NULL,
    [DateCalled]     DATETIME       NOT NULL,
    [OnComputer]     NVARCHAR (255) NULL,
    CONSTRAINT [PK_FunctionLog] PRIMARY KEY CLUSTERED ([IDFunctionLog] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_FunctionLog_Users] FOREIGN KEY ([IDSubsidiary], [CalledByIDUser]) REFERENCES [dbo].[Users] ([IDSubsidiary], [IDUser])
);

