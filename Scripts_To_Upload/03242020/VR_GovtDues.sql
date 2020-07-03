SELECT        HR.Employee_MD.Last_Name, HR.Employee_MD.First_Name, HR.Employee_MD.Middle_Name, HR.Employee_Govt_ID.SSS, HR.Employee_Govt_ID.HDMF, HR.Employee_Govt_ID.PhilHealth, 
                         Payroll.Payroll_GovtDues_Manual_TF.BillingCompanyCode, Payroll.Payroll_GovtDues_Manual_TF.GrossIncome, Payroll.Payroll_GovtDues_Manual_TF.SSS_EE, Payroll.Payroll_GovtDues_Manual_TF.SSS_ER, 
                         Payroll.Payroll_GovtDues_Manual_TF.SSS_Total, Payroll.Payroll_GovtDues_Manual_TF.PH_EE, Payroll.Payroll_GovtDues_Manual_TF.PH_ER, Payroll.Payroll_GovtDues_Manual_TF.PH_Total, 
                         Payroll.Payroll_GovtDues_Manual_TF.HDMF_EE, Payroll.Payroll_GovtDues_Manual_TF.HDMF_ER, Payroll.Payroll_GovtDues_Manual_TF.HDMF_Total, Payroll.Payroll_GovtDues_Manual_TF.Month, 
                         Payroll.Payroll_GovtDues_Manual_TF.Year, xSystem.Company_RF.CompanyName, xSystem.Months_RF.monthName, xSystem.Months_RF.arr
FROM            HR.Employee_Govt_ID INNER JOIN
                         HR.Employee_MD ON HR.Employee_Govt_ID.EmployeeID = HR.Employee_MD.EmployeeID INNER JOIN
                         Payroll.Payroll_GovtDues_Manual_TF ON HR.Employee_MD.EmployeeID = Payroll.Payroll_GovtDues_Manual_TF.EmpCode INNER JOIN
                         xSystem.Company_RF ON Payroll.Payroll_GovtDues_Manual_TF.BillingCompanyCode = xSystem.Company_RF.CompanyCode INNER JOIN
                         xSystem.Months_RF ON Payroll.Payroll_GovtDues_Manual_TF.Month = xSystem.Months_RF.monthID