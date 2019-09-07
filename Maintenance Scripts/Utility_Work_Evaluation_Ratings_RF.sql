USE [DGMU]
GO

/****** Object:  Table [HR].[Utility_Work_Evaluation_Ratings_RF]    Script Date: 8/16/2019 9:27:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Utility_Work_Evaluation_Ratings_RF](
	[WER_ID] [int] IDENTITY(1,1) NOT NULL,
	[WER_CODE] [nvarchar](2) NOT NULL,
	[WER_Title] [nvarchar](20) NOT NULL,
	[Value_Min] [float] NOT NULL CONSTRAINT [DF_Utility_Work_Evaluation_Ratings_RF_Value_Min]  DEFAULT ((0)),
	[Value_Max] [float] NOT NULL CONSTRAINT [DF_Utility_Work_Evaluation_Ratings_RF_Value_Max]  DEFAULT ((0)),
	[ARR] [nvarchar](1) NULL,
 CONSTRAINT [PK_Utility_Work_Evaluation_Ratings_RF] PRIMARY KEY CLUSTERED 
(
	[WER_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


