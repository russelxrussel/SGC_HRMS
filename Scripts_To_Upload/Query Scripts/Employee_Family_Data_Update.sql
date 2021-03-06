USE [DGMU]
GO
/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYEE_FAMILY_DATA]    Script Date: 12/6/2019 1:47:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* Employee FAMILY Record
07/04/2018
Russel Vasquez
*/

ALTER PROC [HR].[spINSERT_UPDATE_EMPLOYEE_FAMILY_DATA]
@EMPLOYEEID nvarchar(10),
@F_NAME nvarchar(100),
@F_CONTACT nvarchar(30),
@M_NAME nvarchar(100),
@M_CONTACT nvarchar(30),
@SIBLING_COUNT int,
@S_LASTNAME nvarchar(25),
@S_FIRSTNAME nvarchar(25),
@S_MIDDLENAME nvarchar(25),
@S_CONTACT nvarchar(30),
@CONTACTPERSON nvarchar(70),
@CONTACTNUMBER nvarchar(50),
@CONTACTRELATIONSHIP nvarchar(50)
AS
BEGIN

BEGIN TRY
	BEGIN TRANSACTION
	--IDENTIFY ACTION 
	--INSERT TO DELIVERY INFO
	IF NOT EXISTS(SELECT * FROM [HR].Employee_Family_MD WHERE EmployeeID=@EMPLOYEEID)
		BEGIN
		--Insert New Employee Record
		INSERT INTO [HR].[Employee_Family_MD]
		(EmployeeID,F_Name,F_Contact,M_Name,M_Contact,Sibling_Count,S_LastName,S_FirstName,S_MiddleName,S_Contact,
		ContactPerson,ContactNumber,ContactRelationship)
		VALUES
		(@EMPLOYEEID,UPPER(@F_NAME),@F_CONTACT,UPPER(@M_NAME),@M_CONTACT,@SIBLING_COUNT,UPPER(@S_LASTNAME),UPPER(@S_FIRSTNAME),UPPER(@S_MIDDLENAME),@S_CONTACT,
		@CONTACTPERSON,@CONTACTNUMBER,@CONTACTRELATIONSHIP)
	
		END

	ELSE
		
		BEGIN
		-- UPDATE BASIC INFORMATION OF EMPLOYEE
		UPDATE [HR].[Employee_Family_MD]
		SET 
		F_Name = UPPER(@F_NAME), F_Contact = @F_CONTACT,
		M_Name = UPPER(@M_NAME), M_Contact = @M_CONTACT, Sibling_Count = @SIBLING_COUNT,
		S_LastName = UPPER(@S_LASTNAME), S_FirstName = UPPER(@S_FIRSTNAME),
		S_MiddleName = UPPER(@S_MIDDLENAME), S_Contact = @S_CONTACT, 
		ContactPerson=@CONTACTPERSON,ContactNumber=@CONTACTNUMBER,ContactRelationship=@CONTACTRELATIONSHIP,
		DU=getdate()
		WHERE EmployeeID=@EMPLOYEEID
		END

	
	COMMIT TRANSACTION
END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION -- Will not commit changes on all tables

END CATCH

END
