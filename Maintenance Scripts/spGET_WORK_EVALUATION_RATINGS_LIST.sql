USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_WORK_EVALUATION_RATINGS_LIST]    Script Date: 8/16/2019 9:31:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <08/14/2019>
-- Description:	<GET WORK EVALUATION RATINGS LIST>
-- =============================================
CREATE PROCEDURE [HR].[spGET_WORK_EVALUATION_RATINGS_LIST]
AS
BEGIN
	
	SELECT * FROM
	[HR].[Utility_Work_Evaluation_Ratings_RF]
	ORDER BY ARR
	
END



GO


