USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYEE_APPLICATION_RECORD]    Script Date: 12/6/2019 1:05:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/* Insert Application Record
10.22.2019
Russel Vasquez
*/

CREATE PROC [HR].[spINSERT_UPDATE_EMPLOYEE_APPLICATION_RECORD]
@EMPLOYEEID nvarchar(10),
@DATE_APPLIED datetime,
@JPCODE nvarchar(3),
@APPLICANT_EVALUATION nvarchar(250)


AS
BEGIN

--BEGIN TRY
--	BEGIN TRANSACTION
	--IDENTIFY ACTION 
	
	--*** FOR Application Table
	IF NOT EXISTS(SELECT * FROM [HR].[Employee_Application_Record] WHERE EmployeeID=@EMPLOYEEID)
		BEGIN
		--Insert Record in Employee Govt
		INSERT INTO [HR].[Employee_Application_Record]
		(EmployeeID,Date_Applied, JPCode, Applicant_Evaluation)
		VALUES
		(@EMPLOYEEID,@DATE_APPLIED,@JPCODE,@APPLICANT_EVALUATION)
		END
	ELSE
		BEGIN
		-- UPDATE Employee Application
		UPDATE [HR].[Employee_Application_Record]
		SET Date_Applied=@DATE_APPLIED,JPCode=@JPCODE,Applicant_Evaluation=@APPLICANT_EVALUATION, DU=getdate()
		WHERE EmployeeID = @EMPLOYEEID 
		END

--	COMMIT TRANSACTION
--END TRY

--BEGIN CATCH

--	ROLLBACK TRANSACTION -- Will not commit changes on all tables

--END CATCH	
END
	
	
GO


