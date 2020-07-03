USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYMENT_TYPE]    Script Date: 12/6/2019 12:55:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.16.2019>
-- Description:	<GET EMPLOYMENT TYPE LIST>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYMENT_TYPE]
AS
BEGIN
	
	SELECT *
	FROM  [HR].[Utility_Employment_Type_RF]
	ORDER BY arr 
	
END



GO


