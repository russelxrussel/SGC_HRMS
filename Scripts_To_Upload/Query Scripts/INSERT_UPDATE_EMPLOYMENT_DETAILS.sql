USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYMENT_DETAILS]    Script Date: 12/6/2019 1:04:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/* Insert Employment Detail Initial
10.22.2019
Russel Vasquez
*/

CREATE PROC [HR].[spINSERT_UPDATE_EMPLOYMENT_DETAILS]
@EMPLOYEEID nvarchar(10),
@DATE_HIRED datetime,
@COMPANYCODE nvarchar(4),
@DEPARTMENTCODE nvarchar(3),
@POSITIONCODE nvarchar(3),
@EMPLOYMENTSTATUSCODE nvarchar(5),
@EMPLOYMENTTYPECODE nvarchar(1)

AS
BEGIN

--BEGIN TRY
--	BEGIN TRANSACTION
	--IDENTIFY ACTION 
	
	--*** FOR EMPLOYMENT DETAILS TABLE
	IF NOT EXISTS(SELECT * FROM [HR].[Employee_Employment_Details] WHERE EmployeeID=@EMPLOYEEID)
		BEGIN
		--Insert Record in Employment Details
		INSERT INTO [HR].[Employee_Employment_Details]
		(EmployeeID, Date_Hired,CompanyCode, DepartmentCode, PositionCode, EmploymentStatusCode,EmploymentTypeCode)
		VALUES
		(@EMPLOYEEID, @DATE_HIRED,@COMPANYCODE, @DEPARTMENTCODE, @POSITIONCODE, @EMPLOYMENTSTATUSCODE,@EMPLOYMENTTYPECODE)
		END
	ELSE
		BEGIN
		-- UPDATE EMPLOYMENT DETAILS
		UPDATE [HR].[Employee_Employment_Details]
		SET Date_Hired=@DATE_HIRED,CompanyCode=@COMPANYCODE, DepartmentCode=@DEPARTMENTCODE, PositionCode=@POSITIONCODE, 
		EmploymentStatusCode=@EMPLOYMENTSTATUSCODE,EmploymentTypeCode=@EMPLOYMENTTYPECODE
		WHERE EmployeeID = @EMPLOYEEID 
		END

--	COMMIT TRANSACTION
--END TRY

--BEGIN CATCH

--	ROLLBACK TRANSACTION -- Will not commit changes on all tables

--END CATCH	
END
	
	
GO


