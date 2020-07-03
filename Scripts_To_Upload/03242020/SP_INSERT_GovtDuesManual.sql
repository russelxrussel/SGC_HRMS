USE [DGMU]
GO

/****** Object:  StoredProcedure [Payroll].[spINSERT_UPDATE_EMPLOYEE_MANUAL_GOVTDUES]    Script Date: 3/24/2020 12:09:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <03.20.2020>
-- Description:	<INSERT / UPDATE MANUAL GOV'T DUES>
-- =============================================
CREATE PROCEDURE [Payroll].[spINSERT_UPDATE_EMPLOYEE_MANUAL_GOVTDUES] 
@EMPCODE nvarchar(12),
@BASICRATE float,
@DAYSPRESENT float,
@YEAR int,
@MONTH int

AS
BEGIN
	
	--EMPLOYEE GROSS INCOME
	DECLARE @GROSSINCOME float
	SET @GROSSINCOME = @BASICRATE * @DAYSPRESENT

	--GOV'T DUES
	DECLARE @SSS_DUE float
	DECLARE @PH_DUE float
	DECLARE @HDMF_DUE float
	
	--For Gov't Billing of Dues
	DECLARE @GOVTBILLINGCOMPANYCODE NVARCHAR(10)


	DECLARE @BILLINGCOMPANYCODE nvarchar(10) = (SELECT BillingCompanyCode FROM [HR].[Employee_Govt_ID]
										       WHERE EmployeeID = @EMPCODE)

	DECLARE @COMPANYCODE nvarchar(10) = (SELECT CompanyCode FROM [HR].[Employee_Employment_Details]
										 WHERE EmployeeID = @EMPCODE)

	--CONDITION FOR GOV'T Billing Dues
	SET @GOVTBILLINGCOMPANYCODE = ISNULL(@BILLINGCOMPANYCODE,@COMPANYCODE)



	--SSS COMPUTATION
	DECLARE @SSS_ID nvarchar(15) = (SELECT SSS FROM [HR].[Employee_Govt_ID]
								 WHERE EmployeeID=@EMPCODE)
								
	IF @SSS_ID IS NULL OR @SSS_ID = ''
		BEGIN
		SELECT 0 as EEShare
		END
	ELSE
		BEGIN
		-- EMPLOYEE SHARE	
		SET @SSS_DUE = (SELECT ROUND(EE,2) as EEShare
						FROM [Payroll].[Payroll_SSS_Matrix_RF]
						WHERE (@GROSSINCOME) BETWEEN Range_Low and Range_High)
		
		   -- EMPLOYER SHARE	
		DECLARE @SSS_ER float =	(SELECT (ER + EC) as EEShare
							     FROM [Payroll].[Payroll_SSS_Matrix_RF]
								 WHERE (@GROSSINCOME) BETWEEN Range_Low and Range_High)
		END
	--PHIL HEALTH
	DECLARE @PHILHEALTH_ID nvarchar(15) = (SELECT PhilHealth FROM [HR].[Employee_Govt_ID]
								 WHERE EmployeeID=@EMPCODE)

	IF @PHILHEALTH_ID IS NULL OR @PHILHEALTH_ID = ''
	BEGIN
		SELECT 0 As PhilHealth_Total
	END
	
	ELSE
		BEGIN			

		   IF @GROSSINCOME <> 0
		   BEGIN
			
			IF (@GROSSINCOME) > 0 AND (@GROSSINCOME) <10000.01
				BEGIN
				SET @PH_DUE = (SELECT ROUND((300), 2)) 
				END
			ELSE IF (@GROSSINCOME) > 10000.01 AND (@GROSSINCOME) < 59999.99
				BEGIN
				SET @PH_DUE = (SELECT ROUND(((@GROSSINCOME) * 3 / 100), 2))
				END
			ELSE
				BEGIN
				SET @PH_DUE = (SELECT ROUND(1800, 2))
				END

			END
	--PAGIBIG/HDMF
	DECLARE @PAGIBIG_ID nvarchar(15) = (SELECT HDMF FROM [HR].[Employee_Govt_ID]
								 WHERE EmployeeID=@EMPCODE)

			IF @PAGIBIG_ID IS NULL OR @PAGIBIG_ID = ''
			BEGIN
			SET @HDMF_DUE = (SELECT 0)
			END
			ELSE
			BEGIN
			SET @HDMF_DUE = (SELECT ROUND(100, 2))
			END
		--BEGIN NOW TRANSACTION
		
		IF NOT EXISTS(SELECT * FROM [Payroll].[Payroll_GovtDues_Manual_TF] WHERE EmpCode=@EMPCODE and Year=@YEAR and MONTH=@MONTH)
		BEGIN
		--INSERT
		INSERT INTO [Payroll].[Payroll_GovtDues_Manual_TF]
		(EmpCode, BillingCompanyCode, Month, Year, DaysPresent,BasicRate,GrossIncome, 
		SSS_EE,SSS_ER,SSS_Total,
		PH_EE,PH_ER,PH_Total, 
		HDMF_EE,HDMF_ER,HDMF_Total)
		VALUES
		(@EMPCODE, @GOVTBILLINGCOMPANYCODE, @MONTH,@YEAR,@DAYSPRESENT,@BASICRATE,@GROSSINCOME,
		@SSS_DUE,@SSS_ER,(@SSS_ER+@SSS_DUE),
		@PH_DUE,@PH_DUE,(@PH_DUE * 2),
		@HDMF_DUE,@HDMF_DUE,(@HDMF_DUE * 2))
		
		END	
			ELSE
			
			BEGIN
			--UPDATE WHEN EXISTING
			UPDATE [Payroll].[Payroll_GovtDues_Manual_TF]
			SET DaysPresent=@DAYSPRESENT, BasicRate=@BASICRATE, GrossIncome=@GROSSINCOME,
			SSS_EE=@SSS_DUE, SSS_ER=@SSS_ER, SSS_Total=(@SSS_ER+@SSS_DUE),
			PH_EE=@PH_DUE,PH_ER=@PH_DUE,PH_Total=(@PH_DUE * 2),
			HDMF_EE=@HDMF_DUE,HDMF_ER=@HDMF_DUE,HDMF_Total=(@HDMF_DUE * 2)
			WHERE EmpCode=@EMPCODE and Year=@YEAR and MONTH=@MONTH
			END

	

	END

	


		--IF NOT EXISTS(SELECT * FROM [Payroll].[Payroll_GovtDues_TF] WHERE EmpCode=@EMPCODE and Year=@YEAR and MONTH=@MONTH and GovtRemitanceCode = 'PH')
		--BEGIN
		----INSERT
		--INSERT INTO [Payroll].[Payroll_GovtDues_TF]
		--(GovtRemitanceCode, CompanyCode, PPID, EmpCode,DaysPresent,BasicRate, EEAmount,ERAmount,Total, Month, Year, GrossIncome)
		--VALUES
		--('PH', @GOVTBILLINGCOMPANYCODE, 99999, @EMPCODE,@DAYSPRESENT,@BASICRATE,,@MONTH,@YEAR, @GROSSINCOME)
		--END	
		--	ELSE
			
		--	BEGIN
		--	--UPDATE WHEN EXISTING
		--	UPDATE [Payroll].[Payroll_GovtDues_TF]
		--	SET DaysPresent=@DAYSPRESENT, BasicRate=@BASICRATE, EEAmount=@PH_DUE, ERAmount=@PH_DUE, Total=(@PH_DUE *2),GrossIncome=@GROSSINCOME
		--	WHERE EmpCode=@EMPCODE and Year=@YEAR and MONTH=@MONTH  and GovtRemitanceCode = 'PH'
		--	END


		--END
 
    
		
		--IF NOT EXISTS(SELECT * FROM [Payroll].[Payroll_GovtDues_TF] WHERE EmpCode=@EMPCODE and Year=@YEAR and MONTH=@MONTH and GovtRemitanceCode = 'HDMF')
		--BEGIN
		----INSERT
		--INSERT INTO [Payroll].[Payroll_GovtDues_TF]
		--(GovtRemitanceCode, CompanyCode, PPID, EmpCode,DaysPresent,BasicRate, EEAmount,ERAmount,Total, Month, Year, GrossIncome)
		--VALUES
		--('HDMF', @GOVTBILLINGCOMPANYCODE, 99999, @EMPCODE,@DAYSPRESENT,@BASICRATE,,@MONTH,@YEAR, @GROSSINCOME)
		--END	
		--	ELSE
			
		--	BEGIN
		--	--UPDATE WHEN EXISTING
		--	UPDATE [Payroll].[Payroll_GovtDues_TF]
		--	SET DaysPresent=@DAYSPRESENT, BasicRate=@BASICRATE, EEAmount=@HDMF_DUE, ERAmount=@HDMF_DUE, Total=(@HDMF_DUE *2),GrossIncome=@GROSSINCOME 
		--	WHERE EmpCode=@EMPCODE and Year=@YEAR and MONTH=@MONTH and GovtRemitanceCode = 'HDMF'
		--	END


			

END



GO


