USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spREMOVE_EMPLOYMENT_HISTORY]    Script Date: 12/6/2019 2:11:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.29.2019>
-- Description:	<REMOVE SKILLS TRAINING>
-- =============================================
CREATE PROCEDURE [HR].[spREMOVE_EMPLOYMENT_HISTORY]
@ID int
AS
BEGIN
	
	DELETE FROM [HR].[Employee_Previous_Employment_History_RF]
	WHERE id=@ID 

END



GO


