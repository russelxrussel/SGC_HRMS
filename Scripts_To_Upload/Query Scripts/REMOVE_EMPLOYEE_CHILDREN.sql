USE [DGMU]
GO

/****** Object:  StoredProcedure [HR].[spREMOVE_EMPLOYEE_CHILDREN]    Script Date: 12/6/2019 1:39:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<RUSSEL VASQUEZ>
-- Create date: <10.29.2019>
-- Description:	<REMOVE CHILDREN>
-- =============================================
CREATE PROCEDURE [HR].[spREMOVE_EMPLOYEE_CHILDREN]
@ID nvarchar(10)
AS
BEGIN
	
	DELETE [HR].[Employee_Family_Children_RF]
	WHERE ID=@ID
	
END



GO


