USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spGET_EMPLOYEE_13TH_TOTALWORKSINYEAR]    Script Date: 12/6/2019 2:29:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <11.21.2019>
-- Description:	<GET EMPLOYEE 13TH MONHT TOTAL WORK IN A YEAR>
-- =============================================
CREATE PROCEDURE [Payroll].[spGET_EMPLOYEE_13TH_TOTALWORKSINYEAR]
@EMPCODE nvarchar(10),
@FY int
AS
BEGIN
	
	SELECT TotalWorksInYear
	FROM [Payroll].[Manual_13thMonth_TF]
	WHERE EmpCode = @EMPCODE AND FY = @FY
	
	
END


GO


