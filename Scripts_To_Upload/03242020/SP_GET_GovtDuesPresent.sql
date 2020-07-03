USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spGET_EMPLOYEE_GOVTDUES_DAYSPRESENT]    Script Date: 3/24/2020 12:07:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <03.20.2020>
-- Description:	<GET EMPLOYEE DAYS PRESENT IN SELECTED MONTH AND YEAR>
-- =============================================
CREATE PROCEDURE [Payroll].[spGET_EMPLOYEE_GOVTDUES_DAYSPRESENT]
@EMPCODE nvarchar(10),
@MONTH int,
@YEAR int
AS
BEGIN
	
	SELECT DaysPresent
	FROM [Payroll].[Payroll_GovtDues_Manual_TF]
	WHERE EmpCode = @EMPCODE AND Year = @YEAR AND Month=@MONTH
	
	
END


GO


