USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYEE_OFFENSES]    Script Date: 8/16/2019 9:33:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <08.15.2019>
-- Description:	<GET EMPLOYEE OFFENSES>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYEE_OFFENSES]
@EMPLOYEEID nvarchar(10)
AS
BEGIN
	
	SELECT *
	FROM [HR].[Employee_Offenses_MD]
	Where EmployeeID = @EMPLOYEEID
	ORDER BY OffenseID
	
END



GO


