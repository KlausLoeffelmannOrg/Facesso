CREATE TABLE [dbo].[SkillNeeded] (
    [IDSkillNeeded] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]  UNIQUEIDENTIFIER      NOT NULL,
    [IDSkill]       UNIQUEIDENTIFIER      NOT NULL,
    [IDWorkGroup]   UNIQUEIDENTIFIER      NOT NULL,
    [LastEdited]    DATETIME NOT NULL,
    CONSTRAINT [PK_SkillNeeded] PRIMARY KEY CLUSTERED ([IDSkillNeeded] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_SkillNeeded_Skill] FOREIGN KEY ([IDSkill], [IDSubsidiary]) REFERENCES [dbo].[Skills] ([IDSkill], [IDSubsidiary]),
    CONSTRAINT [FK_SkillNeeded_WorkGroups] FOREIGN KEY ([IDSubsidiary], [IDWorkGroup]) REFERENCES [dbo].[WorkGroups] ([IDSubsidiary], [IDWorkGroup])
);

