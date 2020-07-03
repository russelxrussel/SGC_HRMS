USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spREMOVE_EMPLOYEE_ATTACHMENTS]    Script Date: 12/6/2019 2:52:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.15.2019>
-- Description:	<REMOVE SELECTED EMPLOYEE ATTACHMENT>
-- =============================================
CREATE PROCEDURE [HR].[spREMOVE_EMPLOYEE_ATTACHMENTS]
@EMPATTACHMENTID int
AS
BEGIN

	UPDATE [HR].[Employee_Attachment_MD]
	SET IsDeleted = 1, DateDeleted = GETDATE()
	WHERE EmpAttachmentID = @EMPATTACHMENTID

END


GO


