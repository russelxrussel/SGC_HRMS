USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spREMOVE_EMPLOYEE_OFFENSE]    Script Date: 8/16/2019 9:33:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <08.15.2019>
-- Description:	<REMOVE EMPLOYEE OFFENSE>
-- =============================================
CREATE PROCEDURE [HR].[spREMOVE_EMPLOYEE_OFFENSE]
@OFFENSE_ID int
AS
BEGIN
	
	DELETE FROM [HR].Employee_Offenses_MD
	WHERE OffenseID=@OFFENSE_ID

END



GO


