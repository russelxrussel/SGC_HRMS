USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Work_Evaluation_Rows_MD]    Script Date: 8/16/2019 9:29:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Work_Evaluation_Rows_MD](
	[WE_ROW_ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[WEC_CODE] [nvarchar](2) NOT NULL,
	[WER_CODE] [nvarchar](2) NOT NULL,
	[DI] [datetime] NULL CONSTRAINT [DF_Employee_Work_Evaluation_MD_DI]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_Work_Evaluation_Rows_MD] PRIMARY KEY CLUSTERED 
(
	[WE_ROW_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [HR].[Employee_Work_Evaluation_Rows_MD]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Work_Evaluation_MD_Utility_Work_Evaluation_Criteria_RF] FOREIGN KEY([WEC_CODE])
REFERENCES [HR].[Utility_Work_Evaluation_Criteria_RF] ([WEC_CODE])
GO

ALTER TABLE [HR].[Employee_Work_Evaluation_Rows_MD] CHECK CONSTRAINT [FK_Employee_Work_Evaluation_MD_Utility_Work_Evaluation_Criteria_RF]
GO

ALTER TABLE [HR].[Employee_Work_Evaluation_Rows_MD]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Work_Evaluation_MD_Utility_Work_Evaluation_Ratings_RF] FOREIGN KEY([WER_CODE])
REFERENCES [HR].[Utility_Work_Evaluation_Ratings_RF] ([WER_CODE])
GO

ALTER TABLE [HR].[Employee_Work_Evaluation_Rows_MD] CHECK CONSTRAINT [FK_Employee_Work_Evaluation_MD_Utility_Work_Evaluation_Ratings_RF]
GO

ALTER TABLE [HR].[Employee_Work_Evaluation_Rows_MD]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Work_Evaluation_Rows_MD_Employee_MD] FOREIGN KEY([EmployeeID])
REFERENCES [HR].[Employee_MD] ([EmployeeID])
GO

ALTER TABLE [HR].[Employee_Work_Evaluation_Rows_MD] CHECK CONSTRAINT [FK_Employee_Work_Evaluation_Rows_MD_Employee_MD]
GO


