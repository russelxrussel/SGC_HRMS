USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spINSERT_UPDATE_EMPLOYEE_CHILDREN]    Script Date: 12/6/2019 1:38:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/* Employee FAMILY Record
10/29/2019
Russel Vasquez
*/

CREATE PROC [HR].[spINSERT_UPDATE_EMPLOYEE_CHILDREN]
@EMPLOYEEID nvarchar(10),
@CHILDNAME	nvarchar(100),
@GENDERCODE nvarchar(1),
@DOB datetime,
@IDTEMP int
AS
BEGIN

BEGIN TRY
	BEGIN TRANSACTION
	--IDENTIFY ACTION 
	--INSERT TO FAMILY CHILDREN RECORD
	IF NOT EXISTS(SELECT * FROM [HR].[Employee_Family_Children_RF] WHERE ChildName=@CHILDNAME)
		BEGIN
		--Insert New Employee Record
		INSERT INTO [HR].[Employee_Family_Children_RF]
		(EmployeeID,ChildName,GenderCode,DOB)
		VALUES
		(@EMPLOYEEID,@CHILDNAME,@GENDERCODE,@DOB)
	
		END

	ELSE
		
		BEGIN
		-- UPDATE EMPLOYEE CHILDREN
		UPDATE [HR].[Employee_Family_Children_RF]
		SET 
		ChildName=@CHILDNAME, GenderCode=@GENDERCODE, DOB=@DOB
		WHERE ID=@IDTEMP
		END

	
	COMMIT TRANSACTION
END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION -- Will not commit changes on all tables

END CATCH

END

GO

