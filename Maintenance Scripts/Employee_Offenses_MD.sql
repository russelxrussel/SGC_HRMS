USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Offenses_MD]    Script Date: 8/16/2019 9:32:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Offenses_MD](
	[OffenseID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[OffenseTitle] [nvarchar](100) NOT NULL,
	[OffenseDetails] [nvarchar](250) NOT NULL,
	[OffenseRecommendation] [nvarchar](250) NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Employee_Offenses_MD_DI]  DEFAULT (getdate()),
	[DU] [datetime] NOT NULL CONSTRAINT [DF_Employee_Offenses_MD_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Offenses_MD] PRIMARY KEY CLUSTERED 
(
	[OffenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [HR].[Employee_Offenses_MD]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Offenses_MD_Employee_MD] FOREIGN KEY([EmployeeID])
REFERENCES [HR].[Employee_MD] ([EmployeeID])
GO

ALTER TABLE [HR].[Employee_Offenses_MD] CHECK CONSTRAINT [FK_Employee_Offenses_MD_Employee_MD]
GO


