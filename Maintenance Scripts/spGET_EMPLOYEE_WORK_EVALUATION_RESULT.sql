USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYEE_WORK_EVALUATION_RESULT]    Script Date: 8/16/2019 9:30:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <08/15/2019>
-- Description:	<GET EMPLOYEE WORK EVALUATION RESULT>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYEE_WORK_EVALUATION_RESULT]
@EMPLOYEEID nvarchar(10),
@WEC_CODE nvarchar(2)
AS
BEGIN
	
SELECT * 
FROM
[HR].Employee_Work_Evaluation_Rows_MD
WHERE EmployeeID=@EMPLOYEEID AND WEC_Code=@WEC_CODE
	
END



GO


