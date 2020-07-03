USE [DGMU]
GO

/****** Object:  Table [HR].[Utility_Employment_Type_RF]    Script Date: 12/6/2019 12:54:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Utility_Employment_Type_RF](
	[ETID] [int] IDENTITY(1,1) NOT NULL,
	[EmpTypeCode] [nvarchar](1) NOT NULL,
	[EmpTypeDesc] [nvarchar](50) NOT NULL,
	[Arr] [nvarchar](2) NULL,
 CONSTRAINT [PK_Utility_Job_Status_RF] PRIMARY KEY CLUSTERED 
(
	[ETID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


