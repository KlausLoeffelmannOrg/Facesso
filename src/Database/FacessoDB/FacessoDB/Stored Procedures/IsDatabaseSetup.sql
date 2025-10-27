CREATE PROCEDURE [dbo].[IsDatabaseSetup]
	@IsSetup [bit] OUTPUT

WITH EXECUTE AS CALLER
AS

SET NOCOUNT ON
if (SELECT COUNT(IDUser) from [Users]) > 0
	SET @IsSetup=1
else
	SET @IsSetup=0

