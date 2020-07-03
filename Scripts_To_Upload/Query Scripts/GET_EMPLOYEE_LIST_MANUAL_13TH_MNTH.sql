USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spGET_EMPLOYEE_LIST_MANUAL_13TH_MONTH]    Script Date: 12/6/2019 2:28:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <09/27/2018>
-- Description:	<GET EMPLOYEE LIST LIGHT WEIGHT FOR PAYROLL>
-- =============================================
CREATE PROCEDURE [Payroll].[spGET_EMPLOYEE_LIST_MANUAL_13TH_MONTH]
AS
BEGIN
	
	DECLARE @YEAR int = (SELECT YEAR FROM xSystem.Years_RF WHERE fStatus=1)
	
	SELECT A.EmployeeID,A.Date_Of_Birth,D.Date_Hired,F.Position,E.Department,G.Status, C.GenderDescription,
	(A.Last_Name + ', ' + A.First_Name + ' ' + LEFT(a.Middle_Name, 1) + '.') as EmployeeName, H.maritalStatus,
	Y.PayrollGroupName,ISNULL((SELECT TotalWorksInYear FROM [Payroll].[Manual_13thMonth_TF] WHERE EmpCode=A.EmployeeID and FY=@YEAR), 0) as TotalWorksInYear,
	ISNULL((SELECT TotalMonthBasicPay FROM [Payroll].[Manual_13thMonth_TF] WHERE EmpCode=A.EmployeeID and FY=@YEAR), 0) as TotalMonthBasicPay,
	ISNULL((SELECT TotalAbsences FROM [Payroll].[Manual_13thMonth_TF] WHERE EmpCode=A.EmployeeID and FY=@YEAR), 0) as TotalAbsences,
	ISNULL((SELECT Computed13thMonth FROM [Payroll].[Manual_13thMonth_TF] WHERE EmpCode=A.EmployeeID and FY=@YEAR), 0) as Computed13thMonth
	FROM [HR].[Employee_MD] A
	--INNER JOIN [HR].[Employee_Picture_RF] B
	--ON A.EmployeeID = B.EmployeeID
	INNER JOIN [HR].Utility_Gender_RF C
	ON A.GenderCode = C.GenderCode
	LEFT JOIN [HR].[Employee_Employment_Details_MD] D
	ON A.EmployeeID = D.EmployeeID
	LEFT JOIN [HR].Utility_Department_RF E
	ON D.DepartmentCode = E.DepartmentCode
	LEFT JOIN [HR].[Utility_Position_RF] F
	ON D.PositionCode = F.PositionCode
	LEFT JOIN [hr].[Utility_Employment_Status_RF] G
	ON D.EmploymentStatusCode = G.StatusCode
	LEFT JOIN [HR].Utility_Marital_RF H
	ON A.MaritalCode = H.maritalCode
	LEFT JOIN [Payroll].[Employee_Salary_MF] X
	ON A.EmployeeID = X.EmpCode
	LEFT JOIN [Payroll].[Payroll_Group_RF] Y
	ON X.PayrollGroupCode = Y.PayrollGroupCode
	WHERE D.EmploymentStatusCode = 'ACT'
	ORDER BY a.Last_Name ASC

	
	
END


GO


