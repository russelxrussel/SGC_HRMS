USE [DGMU]
GO

/****** Object:  Table [xSystem].[Employee_StatusCode_RF]    Script Date: 12/6/2019 12:43:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [xSystem].[Employee_StatusCode_RF](
	[Sys_Employee_StatusCode] [nvarchar](1) NOT NULL,
	[StatusDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusCode_RF] PRIMARY KEY CLUSTERED 
(
	[Sys_Employee_StatusCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


