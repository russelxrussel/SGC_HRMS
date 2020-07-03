USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Application_Record]    Script Date: 12/6/2019 1:03:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Application_Record](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[Date_Applied] [datetime] NOT NULL,
	[JPCode] [nvarchar](3) NULL CONSTRAINT [DF_Employee_Application_Record_JPCode]  DEFAULT ('RF'),
	[Applicant_Evaluation] [nvarchar](250) NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Employee_Application_Record_DI]  DEFAULT (getdate()),
	[DU] [datetime] NOT NULL CONSTRAINT [DF_Employee_Application_Record_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Application_Record] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


