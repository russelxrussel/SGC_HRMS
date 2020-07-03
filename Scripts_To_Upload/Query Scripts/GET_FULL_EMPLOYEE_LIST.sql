USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_FULL_EMPLOYEE_LIST]    Script Date: 12/6/2019 1:06:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10/27/2019>
-- VERSION 2
-- Description:	<GET EMPLOYEE LIST>
-- =============================================
CREATE PROCEDURE [HR].[spGET_FULL_EMPLOYEE_LIST]
AS
BEGIN
	
	SELECT *, C.GenderDescription,
	(A.Last_Name + ', ' + A.First_Name + ' ' + LEFT(a.Middle_Name, 1) + '.') as EmployeeName,
	(A.Last_Name + A.First_Name + A.Middle_Name) as SearchText
	FROM [HR].[Employee_MD] A
	INNER JOIN [HR].Utility_Gender_RF C
	ON A.GenderCode = C.GenderCode
	--LEFT JOIN [HR].[Employee_Employment_Details_MD] D
	--ON A.EmployeeID = D.EmployeeID
	
	LEFT JOIN [HR].Utility_Marital_RF H
	ON A.MaritalCode = H.maritalCode
	LEFT JOIN [HR].[Employee_Family_MD] K
	ON A.EmployeeID = K.EmployeeID
	LEFT JOIN [HR].[Employee_Education_MD] I
	ON A.EmployeeID = I.EmployeeID

	--REVISED BY JOINING NEW CREATED TABLE OF EMPLOYEE DETAILS, GOV'ID
	LEFT JOIN [HR].[Employee_Employment_Details] R
	ON A.EmployeeID = R.EmployeeID
	LEFT JOIN [HR].[Employee_Govt_ID] S
	ON A.EmployeeID = S.EmployeeID
	LEFT JOIN [HR].[Employee_Application_Record] T
	ON A.EmployeeID = T.EmployeeID
	--*** EMPLOYMENT DETAILS
	--DEPARTMENT
	LEFT JOIN [HR].Utility_Department_RF E
	ON R.DepartmentCode = E.DepartmentCode
	--POSITION
	LEFT JOIN [HR].[Utility_Position_RF] F
	ON R.PositionCode = F.PositionCode
	--EMPLOYMENT STATUS
	LEFT JOIN [hr].[Utility_Employment_Status_RF] G
	ON R.EmploymentStatusCode = G.StatusCode
	--EMPLOYMENT TYPE
	LEFT JOIN [HR].[Utility_Employment_Type_RF] U
	ON R.EmploymentTypeCode = U.EmpTypeCode

	--APPLICANT RECORD
	LEFT JOIN [HR].[Utility_Job_Posting_RF] V
	ON T.JPCode = V.JPCode
	
	--COMPANY
	LEFT JOIN [xSystem].[Company_RF] X
	ON R.CompanyCode = X.CompanyCode

	ORDER BY a.Last_Name ASC
END



GO


