USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYEE_GOVT_ID]    Script Date: 12/6/2019 1:05:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/* Insert Government IDs'
10.22.2019
Russel Vasquez
*/

CREATE PROC [HR].[spINSERT_UPDATE_EMPLOYEE_GOVT_ID]
@EMPLOYEEID nvarchar(10),
@TIN nvarchar(20),
@SSS nvarchar(20),
@HDMF nvarchar(20),
@PHILHEALTH nvarchar(20)


AS
BEGIN

--BEGIN TRY
--	BEGIN TRANSACTION
	--IDENTIFY ACTION 
	
	--*** FOR GOV'T IDs TABLE
	IF NOT EXISTS(SELECT * FROM [HR].[Employee_Govt_ID] WHERE EmployeeID=@EMPLOYEEID)
		BEGIN
		--Insert Record in Employee Govt
		INSERT INTO [HR].[Employee_Govt_ID]
		(EmployeeID, TIN, SSS, HDMF, PhilHealth)
		VALUES
		(@EMPLOYEEID, @TIN, @SSS, @HDMF, @PHILHEALTH)
		END
	ELSE
		BEGIN
		-- UPDATE Employee Govt
		UPDATE [HR].[Employee_Govt_ID]
		SET TIN=@TIN, SSS=@SSS, HDMF=@HDMF, PhilHealth=@PHILHEALTH, DU=getdate()
		WHERE EmployeeID = @EMPLOYEEID 
		END

--	COMMIT TRANSACTION
--END TRY

--BEGIN CATCH

--	ROLLBACK TRANSACTION -- Will not commit changes on all tables

--END CATCH	
END
	
	
GO


