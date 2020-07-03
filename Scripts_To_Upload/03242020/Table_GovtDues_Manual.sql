USE [DGMU]
GO

/****** Object:  Table [Payroll].[Payroll_GovtDues_Manual_TF]    Script Date: 3/24/2020 12:05:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Payroll].[Payroll_GovtDues_Manual_TF](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [nvarchar](10) NOT NULL,
	[BillingCompanyCode] [nvarchar](4) NOT NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[DaysPresent] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_DaysPresent]  DEFAULT ((0)),
	[BasicRate] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_BasicRate]  DEFAULT ((0)),
	[GrossIncome] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_GrossIncome]  DEFAULT ((0)),
	[SSS_EE] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_SSS_EE]  DEFAULT ((0)),
	[SSS_ER] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_SSS_ER]  DEFAULT ((0)),
	[SSS_Total] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_SSS_Total]  DEFAULT ((0)),
	[PH_EE] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_PH_EE]  DEFAULT ((0)),
	[PH_ER] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_PH_ER]  DEFAULT ((0)),
	[PH_Total] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_PH_Total]  DEFAULT ((0)),
	[HDMF_EE] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_HDMF_EE]  DEFAULT ((0)),
	[HDMF_ER] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_HDMF_ER]  DEFAULT ((0)),
	[HDMF_Total] [float] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_HDMF_Total]  DEFAULT ((0)),
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_DI]  DEFAULT (getdate()),
	[DU] [datetime] NOT NULL CONSTRAINT [DF_Payroll_GovtDues_Manual_TF_DU]  DEFAULT (getdate()),
 CONSTRAINT [PK_Payroll_GovtDues_Manual_TF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


