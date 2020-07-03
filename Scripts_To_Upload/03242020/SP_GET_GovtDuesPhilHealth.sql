USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spGET_EMPLOYEE_MANUAL_GOVTDUES_PH]    Script Date: 3/24/2020 12:08:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <03.20.2020>
-- Description:	<GET EMPLOYEE SSS PAYMENT>
-- =============================================
CREATE PROCEDURE [Payroll].[spGET_EMPLOYEE_MANUAL_GOVTDUES_PH]
@EMPCODE nvarchar(10),
@MONTH int,
@YEAR int
AS
BEGIN
	
	SELECT PH_EE
	FROM [Payroll].[Payroll_GovtDues_Manual_TF]
	WHERE EmpCode = @EMPCODE AND Year = @YEAR AND Month=@MONTH
	
	
END


GO


