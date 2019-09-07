USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYEE_WORK_EVALUATION_REMARKS]    Script Date: 8/16/2019 9:30:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <08/15/2019>
-- Description:	<GET EMPLOYEE WORK EVALUATION REMARKS>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYEE_WORK_EVALUATION_REMARKS]
@EMPLOYEEID nvarchar(10)
AS
BEGIN
	
SELECT * 
FROM
[HR].Employee_Work_Evaluation_Hdr_MD
WHERE EmployeeID=@EMPLOYEEID
	
END



GO


