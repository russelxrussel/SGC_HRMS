USE [DGMU]
GO

/****** Object:  View [Payroll].[VR_13TH_MONTH]    Script Date: 12/6/2019 2:48:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Payroll].[VR_13TH_MONTH]
AS
SELECT        HR.Employee_MD.Last_Name, HR.Employee_MD.First_Name, HR.Employee_MD.Middle_Name, Payroll.Manual_13thMonth_TF.EmpCode, Payroll.Manual_13thMonth_TF.FY, 
                         Payroll.Manual_13thMonth_TF.TotalMonthBasicPay, Payroll.Manual_13thMonth_TF.Computed13thMonth, HR.Employee_Employment_Details.CompanyCode, xSystem.Company_RF.CompanyName
FROM            Payroll.Manual_13thMonth_TF INNER JOIN
                         HR.Employee_MD ON Payroll.Manual_13thMonth_TF.EmpCode = HR.Employee_MD.EmployeeID INNER JOIN
                         HR.Employee_Employment_Details ON Payroll.Manual_13thMonth_TF.EmpCode = HR.Employee_Employment_Details.EmployeeID INNER JOIN
                         xSystem.Company_RF ON HR.Employee_Employment_Details.CompanyCode = xSystem.Company_RF.CompanyCode

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[55] 4[19] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Manual_13thMonth_TF (Payroll)"
            Begin Extent = 
               Top = 8
               Left = 248
               Bottom = 204
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Employee_MD (HR)"
            Begin Extent = 
               Top = 16
               Left = 21
               Bottom = 205
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee_Employment_Details (HR)"
            Begin Extent = 
               Top = 29
               Left = 502
               Bottom = 261
               Right = 765
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Company_RF (xSystem)"
            Begin Extent = 
               Top = 196
               Left = 257
               Bottom = 326
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4230
         Alias = 900
         Table = 2745
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
   ' , @level0type=N'SCHEMA',@level0name=N'Payroll', @level1type=N'VIEW',@level1name=N'VR_13TH_MONTH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Payroll', @level1type=N'VIEW',@level1name=N'VR_13TH_MONTH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'Payroll', @level1type=N'VIEW',@level1name=N'VR_13TH_MONTH'
GO


