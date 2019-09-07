USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Work_Evaluation_Hdr_MD]    Script Date: 8/16/2019 9:29:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Work_Evaluation_Hdr_MD](
	[WE_ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[GeneralRemarks] [nvarchar](250) NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Employee_Work_Evaluation_Hdr_MD_DI]  DEFAULT (getdate()),
	[DU] [datetime] NOT NULL CONSTRAINT [DF_Employee_Work_Evaluation_Hdr_MD_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Work_Evaluation_Hdr_MD] PRIMARY KEY CLUSTERED 
(
	[WE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


