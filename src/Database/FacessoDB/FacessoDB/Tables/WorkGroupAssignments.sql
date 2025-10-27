CREATE TABLE [dbo].[WorkGroupAssignments] (
    [IDWorkGroupAssignment] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]          UNIQUEIDENTIFIER      NOT NULL,
    [IDLabourValueInternal] INT      NOT NULL,
    [IDWorkGroupInternal]   INT      NOT NULL,
    [OrdinalNumber]         INT      NOT NULL,
    [LastEdited]            DATETIME CONSTRAINT [DF_WorkGroupAssignments_LastEdited] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_WorkGroupAssignments] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDWorkGroupAssignment] ASC),
    CONSTRAINT [FK_WorkGroupAssignments_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

