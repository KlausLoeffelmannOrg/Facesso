CREATE TABLE [dbo].[TimeLogForInsert] (
    [IDTimeLogForInsert]  UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]        UNIQUEIDENTIFIER        NOT NULL,
    [IDTimeLog]           UNIQUEIDENTIFIER     NOT NULL,
    [IDUser]              UNIQUEIDENTIFIER        NOT NULL,
    [IDWorkGroup]         UNIQUEIDENTIFIER        NOT NULL,
    [IDEmployee]          UNIQUEIDENTIFIER        NOT NULL,
    [Shift]               TINYINT    NOT NULL,
    [ProductionDate]      DATETIME   NOT NULL,
    [ShiftStart]          DATETIME   NOT NULL,
    [ShiftEnd]            DATETIME   NOT NULL,
    [WorkBreak]           INT        NOT NULL,
    [DownTime]            INT        NOT NULL,
    [Handicap]            FLOAT (53) NOT NULL,
    [InsertedByInterface] BIT        NOT NULL,
    [ManuallyEdited]      BIT        NOT NULL,
    [EditedByIDUser]      UNIQUEIDENTIFIER        NOT NULL,
    [Deleted]             BIT        NOT NULL,
    [Ticket]              DATETIME   NOT NULL,
    CONSTRAINT [PK_TimeLogForInsert] PRIMARY KEY CLUSTERED ([IDTimeLogForInsert] ASC, [IDSubsidiary] ASC),
    CONSTRAINT [FK_TimeLogForInsert_Subsidiaries] FOREIGN KEY ([IDSubsidiary]) REFERENCES [dbo].[Subsidiaries] ([IDSubsidiary])
);

