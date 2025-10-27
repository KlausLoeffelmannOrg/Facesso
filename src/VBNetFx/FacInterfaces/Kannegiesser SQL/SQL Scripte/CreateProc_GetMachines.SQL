USE [MISDB]
GO
/****** Object:  StoredProcedure [PROGHIST].[GetMachines]    Script Date: 08/03/2011 19:13:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sebastian Pöppel
-- Create date: 16.9.2010
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [PROGHIST].[GetMachines]
    WITH EXECUTE AS OWNER
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT		MachID AS MachineID,
                MachShortName AS MachineName
    FROM		dbo.tblMachines
    ORDER BY	MachID ASC
END

