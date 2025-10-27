CREATE TABLE [dbo].[Skills] (
    [IDSkill]          UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]     UNIQUEIDENTIFIER            NOT NULL,
    [SkillDescription] NVARCHAR (MAX) NOT NULL,
    [LastEdited]       DATETIME       CONSTRAINT [DF_Skills_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([IDSkill] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_Skills_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

