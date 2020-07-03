USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYEE_PREVIOUS_EMPLOYMENT_HISTORY]    Script Date: 12/6/2019 2:10:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.29.2019>
-- Description:	<GET CHILDREN>
-- =============================================
CREATE PROCEDURE [HR].[spINSERT_UPDATE_EMPLOYEE_PREVIOUS_EMPLOYMENT_HISTORY]
@EMPLOYEEID nvarchar(10),
@COMPANYNAME nvarchar(70),
@COMPANYADDRESS nvarchar(100),
@POSITION nvarchar(50),
@DATESTARTED datetime,
@DATEENDED datetime,
@REMARKS NVARCHAR(100)
AS
BEGIN
	
		INSERT INTO [HR].[Employee_Previous_Employment_History_RF]
		(EmployeeID, CompanyName, CompanyAddress,Position,DateStarted,DateEnded, Remarks)
		VALUES
		(@EMPLOYEEID,@COMPANYNAME,@COMPANYADDRESS,@POSITION,@DATESTARTED,@DATEENDED,@REMARKS)
	
END



GO


