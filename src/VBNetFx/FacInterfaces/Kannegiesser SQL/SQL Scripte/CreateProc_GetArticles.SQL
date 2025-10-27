USE [MISDB]
GO
/****** Object:  StoredProcedure [PROGHIST].[GetArticles]    Script Date: 08/03/2011 19:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [PROGHIST].[GetArticles]
    WITH EXECUTE AS OWNER
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT		ArticleID,
                ArticleName
    FROM		dbo.tblArticles
    ORDER BY	ArticleID ASC,
                ArticleName ASC
END

