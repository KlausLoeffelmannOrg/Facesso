CREATE TABLE [dbo].[ProductionDataItems] (
    [IDProductionDataItem] UNIQUEIDENTIFIER      NOT NULL DEFAULT (NEWSEQUENTIALID()),
    [IDSubsidiary]         UNIQUEIDENTIFIER        NOT NULL,
    [IDProductionData]     UNIQUEIDENTIFIER     NOT NULL,
    [IDLabourValue]        UNIQUEIDENTIFIER        NOT NULL,
    [IDArticle]            UNIQUEIDENTIFIER        NOT NULL,
    [Amount]               FLOAT (53) NOT NULL,
    [AmountViaInterface]   FLOAT (53) CONSTRAINT [DF_ProductionDataItems_AmountViaInterface] DEFAULT ((-1)) NOT NULL,
    [OrdinalNumber]        INT        NOT NULL,
    [ManuallyEdited]       BIT        NOT NULL,
    CONSTRAINT [PK_ProductionDataItems] PRIMARY KEY CLUSTERED ([IDSubsidiary] ASC, [IDProductionDataItem] ASC),
    CONSTRAINT [FK_ProductionDataItems_ProductionData] FOREIGN KEY ([IDSubsidiary], [IDProductionData]) REFERENCES [dbo].[ProductionData] ([IDSubsidiary], [IDProductionData])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductionData]
    ON [dbo].[ProductionDataItems]([IDSubsidiary] ASC, [IDProductionData] ASC);


GO


CREATE TRIGGER dbo.OnProductionDataItems_InsertUpdateDelete
ON dbo.ProductionDataItems 
FOR INSERT, UPDATE, DELETE
AS

DECLARE @IDProductionData UNIQUEIDENTIFIER,
		@IDSubsidiary UNIQUEIDENTIFIER,
		@TotalReferenceIWT float

SELECT @IDProductionData=IDProductionData,@IDSubsidiary=IDSubsidiary FROM inserted

IF @IDProductionData IS NULL
	RETURN
	
SELECT @TotalReferenceIWT=SUM(ProductionDataItems.Amount * LabourValues.TeHMin)
FROM         ProductionDataItems INNER JOIN
                      LabourValues ON ProductionDataItems.IDSubsidiary = LabourValues.IDSubsidiary AND 
                      ProductionDataItems.IDLabourValue = LabourValues.IDLabourValue 
WHERE     (ProductionDataItems.IDSubsidiary = @IDSubsidiary) AND (IDProductionData = @IDProductionData)

UPDATE  ProductionData
SET     TotalReferenceIWT = @TotalReferenceIWT
WHERE   (IDSubsidiary = @IDSubsidiary) AND (IDProductionData = @IDProductionData)
