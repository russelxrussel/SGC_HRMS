USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_EMPLOYEE_ATTACHMENT]    Script Date: 12/6/2019 2:52:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10/01/2019>
-- Description:	<Attachment File Saving>
-- =============================================
CREATE PROCEDURE [HR].[spINSERT_EMPLOYEE_ATTACHMENT]
@EMPLOYEEID nvarchar(10),
@FILENAME nvarchar(100),
@TITLE	nvarchar(100),
@FILEPATH nvarchar(150)

AS
BEGIN
	
	INSERT INTO [HR].[Employee_Attachment_MD]
	(EmployeeID, File_Name, Title, FilePath)
	VALUES
	(@EMPLOYEEID,@FILENAME,@TITLE,@FILEPATH)
END



GO


