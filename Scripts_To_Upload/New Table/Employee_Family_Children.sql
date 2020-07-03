USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Family_Children_RF]    Script Date: 12/6/2019 1:37:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Family_Children_RF](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[ChildName] [nvarchar](100) NOT NULL,
	[GenderCode] [nvarchar](1) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Employee_Family_Children_RF_DI]  DEFAULT (getdate()),
	[DU] [datetime] NOT NULL CONSTRAINT [DF_Employee_Family_Children_RF_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Family_Children_RF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [HR].[Employee_Family_Children_RF]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Family_Children_RF_Employee_MD] FOREIGN KEY([EmployeeID])
REFERENCES [HR].[Employee_MD] ([EmployeeID])
GO

ALTER TABLE [HR].[Employee_Family_Children_RF] CHECK CONSTRAINT [FK_Employee_Family_Children_RF_Employee_MD]
GO

ALTER TABLE [HR].[Employee_Family_Children_RF]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Family_Children_RF_Utility_Gender_RF] FOREIGN KEY([GenderCode])
REFERENCES [HR].[Utility_Gender_RF] ([GenderCode])
GO

ALTER TABLE [HR].[Employee_Family_Children_RF] CHECK CONSTRAINT [FK_Employee_Family_Children_RF_Utility_Gender_RF]
GO


