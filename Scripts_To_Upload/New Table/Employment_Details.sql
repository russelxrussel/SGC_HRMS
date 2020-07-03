USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Employment_Details]    Script Date: 12/6/2019 1:02:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Employment_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[Date_Hired] [datetime] NULL,
	[CompanyCode] [nvarchar](4) NULL CONSTRAINT [DF_Employee_Employment_Details_CompanyCode]  DEFAULT ('DGMU'),
	[DepartmentCode] [nvarchar](3) NULL,
	[PositionCode] [nvarchar](3) NULL,
	[EmploymentStatusCode] [nvarchar](5) NULL,
	[EmploymentTypeCode] [nvarchar](1) NULL,
	[DI] [datetime] NULL CONSTRAINT [DF_Employee_Employment_Details_DI]  DEFAULT (getdate()),
	[DU] [datetime] NULL CONSTRAINT [DF_Employee_Employment_Details_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Employment_Details] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


