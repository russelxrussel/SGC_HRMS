USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spGET_EMPLOYEE_MANUAL_GOVTDUES_HDMF]    Script Date: 3/24/2020 12:09:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <03.20.2020>
-- Description:	<GET EMPLOYEE SSS PAYMENT>
-- =============================================
CREATE PROCEDURE [Payroll].[spGET_EMPLOYEE_MANUAL_GOVTDUES_HDMF]
@EMPCODE nvarchar(10),
@MONTH int,
@YEAR int
AS
BEGIN
	
	SELECT HDMF_EE
	FROM [Payroll].[Payroll_GovtDues_Manual_TF]
	WHERE EmpCode = @EMPCODE AND Year = @YEAR AND Month=@MONTH
	
	
END


GO


