USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYEE_CHILDREN]    Script Date: 12/6/2019 1:39:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.29.2019>
-- Description:	<GET CHILDREN>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYEE_CHILDREN]
@EMPLOYEEID nvarchar(10)
AS
BEGIN
	
	SELECT *
	FROM [HR].[Employee_Family_Children_RF] A
	INNER JOIN [HR].Utility_Gender_RF B
	ON A.GenderCode = B.GenderCode
	Where EmployeeID = @EMPLOYEEID
	ORDER BY DOB desc
	
END



GO


