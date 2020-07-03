USE [DGMU]
GO

/****** Object:  Table [HR].[Employee_Attachment_MD]    Script Date: 12/6/2019 2:51:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HR].[Employee_Attachment_MD](
	[EmpAttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[File_Name] [nvarchar](100) NOT NULL,
	[FilePath] [nvarchar](200) NOT NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Employee_Attachment_MD_DI]  DEFAULT (getdate()),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_Employee_Attachment_MD_IsDeleted]  DEFAULT ((0)),
	[DateDeleted] [datetime] NULL,
 CONSTRAINT [PK_Employee_Attachment_MD] PRIMARY KEY CLUSTERED 
(
	[EmpAttachmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


