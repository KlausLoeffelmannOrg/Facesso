CREATE TABLE [dbo].[SkillProvided] (
    [IDSkillProvided] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]    UNIQUEIDENTIFIER      NOT NULL,
    [IDEmployee]      UNIQUEIDENTIFIER      NOT NULL,
    [IDSkill]         UNIQUEIDENTIFIER      NOT NULL,
    [LastEdited]      DATETIME CONSTRAINT [DF_SkillProvided_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_SkillProvided] PRIMARY KEY CLUSTERED ([IDSkillProvided] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_SkillProvided_Employees] FOREIGN KEY ([IDSubsidiary], [IDEmployee]) REFERENCES [dbo].[Employees] ([IDSubsidiary], [IDEmployee]),
    CONSTRAINT [FK_SkillProvided_Skill] FOREIGN KEY ([IDSkill], [IDSubsidiary]) REFERENCES [dbo].[Skills] ([IDSkill], [IDSubsidiary])
);

