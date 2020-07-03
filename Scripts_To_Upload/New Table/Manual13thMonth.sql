USE [DGMU]
GO

/****** Object:  Table [Payroll].[Manual_13thMonth_TF]    Script Date: 12/6/2019 2:26:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Payroll].[Manual_13thMonth_TF](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [nvarchar](12) NOT NULL,
	[FY] [nvarchar](5) NOT NULL,
	[TotalWorksInYear] [float] NOT NULL CONSTRAINT [DF_Manual_13thMonth_TF_NumberOfWorksInYear]  DEFAULT ((0)),
	[TotalMonthBasicPay] [float] NOT NULL CONSTRAINT [DF_Manual_13thMonth_TF_TotalYearBasicPay]  DEFAULT ((0)),
	[Computed13thMonth] [float] NOT NULL CONSTRAINT [DF_Manual_13thMonth_TF_Computed13thMonth]  DEFAULT ((0)),
	[TotalAbsences] [float] NULL,
	[ChargeCompanyCode] [nvarchar](4) NULL,
	[DI] [datetime] NOT NULL CONSTRAINT [DF_Manual_13thMonth_TF_DI]  DEFAULT (getdate()),
 CONSTRAINT [PK_Manual_13thMonth_TF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


