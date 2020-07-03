USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYEE_EMPLOYMENT_HISTORY]    Script Date: 12/6/2019 4:19:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.29.2019>
-- Description:	<GET EMPLOYMENT_HISTORY>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYEE_EMPLOYMENT_HISTORY]
@EMPLOYEEID nvarchar(10)
AS
BEGIN
	
	SELECT *
	FROM [HR].[Employee_Previous_Employment_History_RF]
	Where EmployeeID = @EMPLOYEEID
	ORDER BY DateStarted Desc
	
END



GO


