USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Previous_Employment_History_RF]    Script Date: 12/6/2019 2:09:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Previous_Employment_History_RF](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[CompanyName] [nvarchar](70) NOT NULL,
	[CompanyAddress] [nvarchar](100) NULL,
	[Position] [nvarchar](50) NULL,
	[DateStarted] [datetime] NOT NULL,
	[DateEnded] [datetime] NULL,
	[Remarks] [nvarchar](150) NULL,
	[DI] [datetime] NULL CONSTRAINT [DF_Employee_Previous_Employment_Record_RF_DI]  DEFAULT (getdate()),
	[DU] [datetime] NULL CONSTRAINT [DF_Employee_Previous_Employment_Record_RF_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Previous_Employment_Record_RF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [HR].[Employee_Previous_Employment_History_RF]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Previous_Employment_Record_RF_Employee_MD] FOREIGN KEY([EmployeeID])
REFERENCES [HR].[Employee_MD] ([EmployeeID])
GO

ALTER TABLE [HR].[Employee_Previous_Employment_History_RF] CHECK CONSTRAINT [FK_Employee_Previous_Employment_Record_RF_Employee_MD]
GO


