USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spGET_EMPLOYEE_LIST_MANUAL_GOVTDUES]    Script Date: 3/24/2020 12:19:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <03.20.2020>
-- Description:	<GET EMPLOYEE LIST FOR Manual Entry of Govt Dues Computation>
-- =============================================
CREATE PROCEDURE [Payroll].[spGET_EMPLOYEE_LIST_MANUAL_GOVTDUES]
@MONTH int
AS
BEGIN
	DECLARE @YEAR int = (SELECT YEAR FROM xSystem.Years_RF WHERE fStatus=1)
	
	SELECT A.EmployeeID,A.Date_Of_Birth,D.Date_Hired,F.Position,E.Department,G.Status, C.GenderDescription,
	(A.Last_Name + ', ' + A.First_Name + ' ' + LEFT(a.Middle_Name, 1) + '.') as EmployeeName, H.maritalStatus,
	Month(Date_of_birth) as BdayMonth, Day(Date_of_birth) as BdayDay, y.CompanyCode, y.CompanyName,
	ISNULL(W.BasicRate,0) as BasicRate, 
	ISNULL(Z.CompanyName,Y.CompanyName) as BillingCompany,
	ISNULL((SELECT SSS_EE FROM [Payroll].[Payroll_GovtDues_Manual_TF] WHERE EmpCode=A.EmployeeID AND Month = @MONTH), 0) as SSS_EE,
	ISNULL((SELECT PH_EE FROM [Payroll].[Payroll_GovtDues_Manual_TF] WHERE EmpCode=A.EmployeeID AND Month = @MONTH), 0) as PH_EE,
	ISNULL((SELECT HDMF_EE FROM [Payroll].[Payroll_GovtDues_Manual_TF] WHERE EmpCode=A.EmployeeID AND Month = @MONTH), 0) as HDMF_EE
	--ISNULL(P.SSS_EE,0) AS SSS_EE,
	--ISNULL(P.PH_EE,0) AS PH_EE,
	--ISNULL(P.HDMF_EE,0) AS HDMF_EE,
	--ISNULL(P.Month,0) as Month
	FROM [HR].[Employee_MD] A
	INNER JOIN [HR].Utility_Gender_RF C
	ON A.GenderCode = C.GenderCode
	LEFT JOIN [HR].[Employee_Employment_Details] D
	ON A.EmployeeID = D.EmployeeID
	LEFT JOIN [xSystem].[Company_RF] Y
	ON D.CompanyCode = Y.CompanyCode
	LEFT JOIN [HR].Utility_Department_RF E
	ON D.DepartmentCode = E.DepartmentCode
	LEFT JOIN [HR].[Utility_Position_RF] F
	ON D.PositionCode = F.PositionCode
	LEFT JOIN [hr].[Utility_Employment_Status_RF] G
	ON D.EmploymentStatusCode = G.StatusCode
	LEFT JOIN [HR].Utility_Marital_RF H
	ON A.MaritalCode = H.maritalCode
	LEFT JOIN [HR].[Employee_Family_MD] K
	ON A.EmployeeID = K.EmployeeID

	--INCLUDE SALARY
	LEFT JOIN [Payroll].[Employee_Salary_MF] W
	ON A.EmployeeID = W.EmpCode

	--COMPANY TO BILL
	LEFT JOIN [HR].[Employee_Govt_ID] X
	ON A.EmployeeID = X.EmployeeID
	LEFT JOIN [xSystem].Company_RF Z
	ON X.BillingCompanyCode = Z.CompanyCode

	WHERE A.IsRemoved = 0 And G.Sys_Employee_StatusCode = 'A'
	ORDER BY a.Last_Name, a.First_Name ASC


	
	
END


GO


