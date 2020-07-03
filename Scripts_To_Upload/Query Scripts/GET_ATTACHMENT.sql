USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spGET_EMPLOYEE_ATTACHMENTS]    Script Date: 12/6/2019 2:52:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.01.2019>
-- Description:	<GET EMPLOYEE ATTACHMENT>
-- =============================================
CREATE PROCEDURE [HR].[spGET_EMPLOYEE_ATTACHMENTS]
@EMPLOYEEID nvarchar(10)
AS
BEGIN

	SELECT *
	FROM [HR].[Employee_Attachment_MD] A
	INNER JOIN [HR].[Employee_MD] B
	ON A.EmployeeID = B.EmployeeID
	WHERE A.EmployeeID=@EMPLOYEEID AND ISDeleted = 0
	ORDER BY A.DI DESC, A.Title


END


GO


