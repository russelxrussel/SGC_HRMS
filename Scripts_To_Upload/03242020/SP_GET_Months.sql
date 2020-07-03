USE [DGMU]
GO

/****** Object:  StoredProcedure [xSystem].[spGET_MONTHS_LIST]    Script Date: 3/24/2020 12:06:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <02.26.2019>
-- Description:	<GET MONTH LIST>
-- =============================================
CREATE PROCEDURE [xSystem].[spGET_MONTHS_LIST]
AS
BEGIN
	
	SELECT *
	FROM [xSystem].[Months_RF]
	ORDER BY arr
END



GO


