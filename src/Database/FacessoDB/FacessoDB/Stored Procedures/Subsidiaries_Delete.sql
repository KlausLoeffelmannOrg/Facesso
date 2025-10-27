CREATE PROCEDURE Subsidiaries_Delete
@IDSubsidiary UNIQUEIDENTIFIER,
@DeletedByIDUser UNIQUEIDENTIFIER,
@IDSubsidiaryContainingUser UNIQUEIDENTIFIER


WITH EXECUTE AS CALLER
AS

ALTER TABLE Users NOCHECK CONSTRAINT FK_Users_CostCenters

DELETE FROM ApplicationSettings WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM ProductionDataItems WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM ProductionData WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM NotificationRecipients WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM BonusList WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM BonusLists WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM WorkGroupAssignments WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM WorkGroups WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM LabourValues WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM Employees WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM WageGroups WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM CostCenters WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM SkillNeeded WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM SkillProvided WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM Skills WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM FunctionLog WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM AddressDetails WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM Users WHERE IDSubsidiary=@IDSubsidiary
DELETE FROM Subsidiaries WHERE IDSubsidiary=@IDSubsidiary

ALTER TABLE Users CHECK CONSTRAINT FK_Users_CostCenters

-- Anlegen der Subsidiary ins Log eintragen
DECLARE @now datetime
SET @now=getdate()
EXEC AddToFunctionLog @IDSubsidiaryContainingUser, 'Subsidiary: Deleted completely', @DeletedByIDUser, @now ,null
