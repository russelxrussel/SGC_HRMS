USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Govt_ID]    Script Date: 12/6/2019 1:03:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Govt_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[TIN] [nvarchar](20) NULL,
	[SSS] [nvarchar](20) NULL,
	[HDMF] [nvarchar](20) NULL,
	[PhilHealth] [nvarchar](20) NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Employee_Govt_ID_DI]  DEFAULT (getdate()),
	[DU] [datetime] NOT NULL CONSTRAINT [DF_Employee_Govt_ID_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Govt_ID] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


