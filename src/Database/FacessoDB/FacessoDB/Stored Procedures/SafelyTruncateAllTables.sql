CREATE PROCEDURE SafelyTruncateAllTables
WITH EXECUTE AS CALLER
AS

BEGIN TRANSACTION
ALTER TABLE Users NOCHECK CONSTRAINT FK_Users_CostCenters

DELETE FROM [ApplicationSettings]
DELETE FROM [ProductionDataItems]
DELETE FROM [ProductionData]
DELETE FROM [TimeLog]
DELETE FROM [NotificationRecipients]
DELETE FROM [BonusList]
DELETE FROM [BonusLists]
DELETE FROM [WorkGroupAssignments]
DELETE FROM [WorkGroups]
DELETE FROM [LabourValues]
DELETE FROM [Employees]
DELETE FROM [WageGroups]
DELETE FROM [CostCenters]
DELETE FROM [Currencies]
DELETE FROM [SkillNeeded]
DELETE FROM [SkillProvided]
DELETE FROM [Skills]
DELETE FROM [FunctionLog]
DELETE FROM [Users]
DELETE FROM [Subsidiaries]
DELETE FROM [AddressDetails]

ALTER TABLE Users CHECK CONSTRAINT FK_Users_CostCenters

commit transaction

DBCC CHECKIDENT('ApplicationSettings', RESEED, 0)
DBCC CHECKIDENT('ProductionDataItems', RESEED, 0)
DBCC CHECKIDENT('ProductionData', RESEED, 0)
DBCC CHECKIDENT('TimeLog', RESEED, 0)
DBCC CHECKIDENT('NotificationRecipients', RESEED, 0)
DBCC CHECKIDENT('BonusList', RESEED, 0)
DBCC CHECKIDENT('BonusLists', RESEED, 0)
DBCC CHECKIDENT('WorkGroupAssignments', RESEED, 0)
DBCC CHECKIDENT('WorkGroups', RESEED, 0)
DBCC CHECKIDENT('LabourValues', RESEED, 0)
DBCC CHECKIDENT('AddressDetails', RESEED, 0)
DBCC CHECKIDENT('Employees', RESEED, 0)
DBCC CHECKIDENT('WageGroups', RESEED, 0)
DBCC CHECKIDENT('CostCenters', RESEED, 0)
DBCC CHECKIDENT('Currencies', RESEED, 0)
DBCC CHECKIDENT('SkillNeeded', RESEED, 0)
DBCC CHECKIDENT('SkillProvided', RESEED, 0)
DBCC CHECKIDENT('Skills', RESEED, 0)
DBCC CHECKIDENT('FunctionLog', RESEED, 0)
DBCC CHECKIDENT('Users', RESEED, 0)
DBCC CHECKIDENT('Subsidiaries', RESEED, 0)



