CREATE TABLE [dbo].[EmployeeHandicaps] (
    [IDEmployee]   UNIQUEIDENTIFIER        NOT NULL,
    [IDSubsidiary] UNIQUEIDENTIFIER        NOT NULL,
    [Handicap]     FLOAT (53) NOT NULL,
    [ValidFrom]    DATETIME   NOT NULL,
    CONSTRAINT [FK_EmployeeHandicap_Employees] FOREIGN KEY ([IDSubsidiary], [IDEmployee]) REFERENCES [dbo].[Employees] ([IDSubsidiary], [IDEmployee])
);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeHandicap]
    ON [dbo].[EmployeeHandicaps]([IDSubsidiary] ASC, [IDEmployee] ASC);

