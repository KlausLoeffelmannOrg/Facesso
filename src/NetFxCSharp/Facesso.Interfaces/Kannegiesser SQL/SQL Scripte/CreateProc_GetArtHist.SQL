USE [MISDB]
GO
/****** Object:  StoredProcedure [PROGHIST].[GetArtHist]    Script Date: 08/03/2011 20:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Pöppel
-- Create date: 16.9.2010
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [PROGHIST].[GetArtHist]
	-- Add the parameters for the stored procedure here
	@MachineID int,
	@StartTime datetime,
	@EndTime datetime
	WITH EXECUTE AS OWNER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT     dbo.tblMachHistAnchor.StartTime, dbo.tblMachHistAnchor.EndTime, dbo.tblMachines.SysID, dbo.tblSystems.SysShortName, dbo.tblMachines.SystemMaster, 
                      dbo.tblMachHistAnchor.MachID, dbo.tblMachines.MachShortName, dbo.tblMachHistDetail.ProdDur, dbo.tblArticles.ArticleName, dbo.tblArticles.ArticleID, 
                      dbo.tblMachHistDetail.Counter, dbo.tblMachHistDetail.Counter * dbo.tblPrograms_Criterias.TargetMachineTime AS TargetDur1, dbo.tblUnits.UnitName
	FROM         dbo.tblMachHistDetail INNER JOIN
                      dbo.tblMachHistAnchor ON dbo.tblMachHistDetail.MachHistID = dbo.tblMachHistAnchor.MachHistID INNER JOIN
                      dbo.tblMachines ON dbo.tblMachHistDetail.MachID = dbo.tblMachines.MachID INNER JOIN
                      dbo.tblSystems ON dbo.tblMachines.SysID = dbo.tblSystems.SysID INNER JOIN
                      dbo.tblPrograms_Criterias ON dbo.tblMachHistDetail.MachID = dbo.tblPrograms_Criterias.MachID AND 
                      dbo.tblMachHistDetail.PgmID = dbo.tblPrograms_Criterias.PgmID AND dbo.tblMachHistDetail.CritID = dbo.tblPrograms_Criterias.CritID INNER JOIN
                      dbo.tblArticles ON dbo.tblPrograms_Criterias.ArticleID = dbo.tblArticles.ArticleID INNER JOIN
                      dbo.tblCriterias ON dbo.tblPrograms_Criterias.MachID = dbo.tblCriterias.MachID AND dbo.tblPrograms_Criterias.CritID = dbo.tblCriterias.CritID INNER JOIN
                      dbo.tblUnits ON dbo.tblCriterias.CritUnit = dbo.tblUnits.UnitID
	WHERE     (dbo.tblMachHistDetail.Counter <> 0 and dbo.tblMachHistAnchor.StartTime>=@StartTime AND dbo.tblMachHistAnchor.EndTime<=@EndTime and dbo.tblMachHistAnchor.MachID=@MachineID)

END


