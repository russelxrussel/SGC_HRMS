USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYEE_BASIC_DATA]    Script Date: 12/6/2019 2:07:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/* Insert New Employee Record
02/14/2018
Revised 02/20/2018
Revised 02.09.2019 added Incase of Emergency
Revised 10.29.2019
Russel Vasquez
*/

CREATE PROC [HR].[spINSERT_UPDATE_EMPLOYEE_BASIC_DATA]
@EMPLOYEEID nvarchar(10),
@LAST_NAME nvarchar(25),
@FIRST_NAME nvarchar(25),
@MIDDLE_NAME nvarchar(25),
@NICK_NAME nvarchar(20),
@GENDERCODE nvarchar(1),
@MARITALCODE nvarchar(2),
@DATE_OF_BIRTH datetime,
@PLACE_OF_BIRTH nvarchar(100),
@WEIGHT nvarchar(10),
@HEIGHT nvarchar(10),
@LANDLINE_NUMBER nvarchar(50),
@MOBILE_NUMBER nvarchar(50),
@RELIGIONCODE nvarchar(3),
@CITIZENSHIPCODE nvarchar(3),
@PRESENT_ADDRESS nvarchar(150),
@PROVINCIAL_ADDRESS nvarchar(150),
@BLOOD_TYPE nvarchar(3)

AS
BEGIN

BEGIN TRY
	BEGIN TRANSACTION
	 
	--INSERT TO NEW EMPLOYEE RECORD
	IF NOT EXISTS(SELECT * FROM [HR].Employee_MD WHERE EmployeeID=@EMPLOYEEID)
		BEGIN
		--Insert New Employee Record
		INSERT INTO [HR].[Employee_MD] 
		(EmployeeID, Last_Name, First_Name, Middle_Name, Nick_Name, GenderCode,MaritalCode,Blood_Type, Date_Of_Birth, Place_Of_Birth, Weight, Height, Landline_Number, Mobile_Number, ReligionCode, CitizenshipCode, Present_Address, Provincial_Address)
		VALUES
		(@EMPLOYEEID,UPPER(@LAST_NAME),UPPER(@FIRST_NAME),UPPER(@MIDDLE_NAME),@NICK_NAME,@GENDERCODE,@MARITALCODE,@BLOOD_TYPE,@DATE_OF_BIRTH,@PLACE_OF_BIRTH,@WEIGHT,@HEIGHT, @LANDLINE_NUMBER,@MOBILE_NUMBER, @RELIGIONCODE, @CITIZENSHIPCODE,@PRESENT_ADDRESS,@PROVINCIAL_ADDRESS)
	
		EXEC xSystem.UPDATE_SERIES_NUMBER 'EMP'

		END

	ELSE
		
		BEGIN
		-- UPDATE BASIC INFORMATION OF EMPLOYEE
		UPDATE [HR].[Employee_MD]
		SET Last_Name=UPPER(@LAST_NAME), First_Name=UPPER(@FIRST_NAME), Middle_Name=UPPER(@MIDDLE_NAME), Nick_Name=@NICK_NAME, 
		GenderCode=@GENDERCODE, MaritalCode=@MARITALCODE,Blood_Type=@BLOOD_TYPE, Date_Of_Birth=@DATE_OF_BIRTH, Place_Of_Birth=@PLACE_OF_BIRTH, 
		Weight=@WEIGHT, Height=@HEIGHT, Landline_Number=@LANDLINE_NUMBER, Mobile_Number=@MOBILE_NUMBER, 
		ReligionCode=@RELIGIONCODE, CitizenshipCode=@CITIZENSHIPCODE, Present_Address=@PRESENT_ADDRESS, 
		Provincial_Address=@PROVINCIAL_ADDRESS
		WHERE EmployeeID=@EMPLOYEEID
		END

	

	COMMIT TRANSACTION
END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION -- Will not commit changes on all tables

END CATCH	
END
	
	
GO


