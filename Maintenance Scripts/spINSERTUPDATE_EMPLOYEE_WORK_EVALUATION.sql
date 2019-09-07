USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERTUPDATE_EMPLOYEE_WORK_EVALUATION]    Script Date: 8/16/2019 9:31:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/* UPDATE Employee Work Evaluation
08.14.2019
Russel Vasquez
*/

CREATE PROC [HR].[spINSERTUPDATE_EMPLOYEE_WORK_EVALUATION]
@EMPLOYEEID nvarchar(10),
@WEC_CODE nvarchar(2),
@WER_CODE nvarchar(2),
@GENERAL_REMARKS nvarchar(250)

AS
BEGIN

BEGIN TRY
	BEGIN TRANSACTION
	
		IF NOT EXISTS(SELECT * FROM [HR].[Employee_Work_Evaluation_Hdr_MD] WHERE EmployeeID=@EMPLOYEEID)
			BEGIN
			INSERT INTO [HR].[Employee_Work_Evaluation_Hdr_MD]
			(EmployeeID, GeneralRemarks)
			VALUES
			(@EMPLOYEEID,@GENERAL_REMARKS)
			END
		ELSE
			BEGIN
			UPDATE [HR].[Employee_Work_Evaluation_Hdr_MD]
			SET GeneralRemarks = @GENERAL_REMARKS
			WHERE EmployeeID=@EMPLOYEEID
			END
		
		
		IF NOT EXISTS(SELECT * FROM [HR].[Employee_Work_Evaluation_Rows_MD] WHERE EmployeeID=@EMPLOYEEID and WEC_CODE=@WEC_CODE)
			INSERT INTO [HR].[Employee_Work_Evaluation_Rows_MD]
			(EmployeeID, WEC_CODE,WER_CODE)
			VALUES
			(@EMPLOYEEID,@WEC_CODE,@WER_CODE)
		ELSE
			BEGIN
			UPDATE [HR].[Employee_Work_Evaluation_Rows_MD]
			SET WER_CODE=@WER_CODE
			WHERE EmployeeID=@EMPLOYEEID and WEC_CODE=@WEC_CODE
			END

	COMMIT TRANSACTION
END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION -- Will not commit changes on all tables

END CATCH

END


GO


