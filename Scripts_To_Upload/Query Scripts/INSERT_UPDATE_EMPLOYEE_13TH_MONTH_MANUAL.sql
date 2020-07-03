USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spINSERT_UPDATE_EMPLOYEE_13TH_MONTH_MANUAL]    Script Date: 12/6/2019 2:29:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.30.2019>
-- Description:	<INSER - UPDATE EMPLOYEE MANUAL 13TH MONTH>
-- =============================================
CREATE PROCEDURE [Payroll].[spINSERT_UPDATE_EMPLOYEE_13TH_MONTH_MANUAL]
@EMPCODE nvarchar(12),
@FY int,
@TOTALWORKSINYEAR float,
@TOTALMONTHBASICPAY float,
@TOTALABSENCES float
AS
BEGIN
		

	--CHECK IF EXIST ALREADY
	IF NOT EXISTS(SELECT * FROM [Payroll].[Manual_13thMonth_TF] WHERE EmpCode=@EMPCODE and FY=@FY)
		BEGIN
				INSERT INTO [Payroll].[Manual_13thMonth_TF]
				(EmpCode,FY,TotalWorksInYear,TotalMonthBasicPay,TotalAbsences, Computed13thMonth)
				VALUES
				(@EMPCODE,@FY,@TOTALWORKSINYEAR,@TOTALMONTHBASICPAY,@TOTALABSENCES,(@TOTALMONTHBASICPAY * (@TOTALWORKSINYEAR - @TOTALABSENCES) / @TOTALWORKSINYEAR))
		END

	ELSE
		--UPDATE
		BEGIN
				UPDATE [Payroll].[Manual_13thMonth_TF]
				SET TotalWorksInYear=@TOTALWORKSINYEAR,
				TotalMonthBasicPay = @TOTALMONTHBASICPAY,
				TotalAbsences = @TOTALABSENCES,
				Computed13thMonth = (@TOTALMONTHBASICPAY * (@TOTALWORKSINYEAR - @TOTALABSENCES) / @TOTALWORKSINYEAR)
				WHERE EmpCode=@EMPCODE and FY=@FY
		END
	
	
END



GO


