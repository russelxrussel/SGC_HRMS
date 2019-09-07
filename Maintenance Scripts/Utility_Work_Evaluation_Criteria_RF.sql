USE [DGMU]
GO

/****** Object:  Table [HR].[Utility_Work_Evaluation_Criteria_RF]    Script Date: 8/16/2019 9:27:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Utility_Work_Evaluation_Criteria_RF](
	[WEC_ID] [int] IDENTITY(1,1) NOT NULL,
	[WEC_CODE] [nvarchar](2) NOT NULL,
	[WEC_Title] [nvarchar](50) NOT NULL,
	[WEC_Details] [nvarchar](200) NULL,
	[ARR] [nvarchar](2) NULL,
 CONSTRAINT [PK_Utility_Work_Evaluation_Criteria_RF] PRIMARY KEY CLUSTERED 
(
	[WEC_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


