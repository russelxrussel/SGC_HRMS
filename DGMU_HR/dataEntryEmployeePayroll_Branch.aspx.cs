using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class dataEntryEmployeePayroll_Branch : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DisplayPayrollGroupList();
                DisplayWageAreaList();

              
                DisplayPayrollPeriodToday();

                //Display List of Employee for Payslip encoding.
                //DisplayEmployeeListOffice("DP");

            }
        }

        private void DisplayPayrollPeriodToday()
        {
            DataTable dt = oPayroll.GET_PAYROLL_PERIOD_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "IsActive = 1";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                   lblPayrollPeriodText.Text = "Payroll Period : " + drv["Description"].ToString();
                   ViewState["PPID"] = drv["PPID"];
                   ViewState["PPCUTOFF"] = drv["PPCutOff"];
                }
            }

        }

        private void DisplayEmployeeList()
        {
            DataTable dt = oPayroll.GET_BRANCH_EMPLOYEE_LIST_LW_NOT_ASSIGN();
           
            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();
           
        }

        private void DisplayPayrollGroupList()
        {
            //DataTable dt = oPayroll.GET_PAYROLL_GROUP_LIST();

            //ddPayrollGroup.DataSource = dt;
            //ddPayrollGroup.DataTextField = dt.Columns["PayrollGroupName"].ToString();
            //ddPayrollGroup.DataValueField = dt.Columns["PayrollGroupCode"].ToString();
            //ddPayrollGroup.DataBind();

            //ddPayrollGroup.Items.Insert(0, new ListItem("--Select Payroll Group--"));
        }


        private void DisplayWageAreaList()
        {
            DataTable dt = oPayroll.GET_WAGE_AREA_LIST();

            ddWageArea.DataSource = dt;
            ddWageArea.DataTextField = dt.Columns["WageArea"].ToString();
            ddWageArea.DataValueField = dt.Columns["WageCode"].ToString();
            ddWageArea.DataBind();

            ddWageArea.Items.Insert(0, new ListItem("--Select Wage Area--"));
        }

        private void DisplayBranchWageList(string _wageCode)
        {
            DataTable dt = oPayroll.GET_BRANCH_WAGE_LIST();

            DataView dv = dt.DefaultView;
            dv.RowFilter = "WageCode='" + _wageCode + "'";
            dv.Sort = "BranchName";

            ddBranchList.DataSource = dv;
            ddBranchList.DataTextField = dv.Table.Columns["BranchName"].ToString();
            ddBranchList.DataValueField = dv.Table.Columns["BranchCode"].ToString();
            ddBranchList.DataBind();

            //lblWageAmount.Text = "Rate Per Day: " +  DisplayWageAmount(_wageCode).ToString();
         
            DisplayBranchEmployeeList("BP",ddBranchList.SelectedValue.ToString());
        }

        //private void DisplayEmployeeListOffice(string _payrollGroup)
        //{
        //    DataTable dt = oPayroll.GET_EMPLOYEE_SALARY();
        //    DataView dv = dt.DefaultView;
        //   // dv.RowFilter = "PayrollGroupCode IS NOT NULL and PayrollGroupCode ='" + _payrollGroup + "'";
        //    dv.RowFilter = "PayrollGroupCode ='" + _payrollGroup + "'";
        //    dv.Sort = "EmployeeName";

        //    gvEmployeeList.DataSource = dt;
        //    gvEmployeeList.DataBind();
        //}

        private double DisplayWageAmount(string _wageCode)
        {
            double dWageAmount = 0;

            DataTable dt = oPayroll.GET_WAGE_AREA_LIST();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "WageCode = '" + _wageCode + "'";

            foreach (DataRowView drv in dv)
            {
                dWageAmount = Convert.ToDouble(drv["WageAmount"]);
            }
            

            return dWageAmount;
        }

        private double Get_Employee_BasicRate(string _empCode)
        {
            double x = 0;

            DataTable dt = oPayroll.GET_EMPLOYEE_SALARY();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "EmployeeID ='" + _empCode + "'";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    x = Convert.ToDouble(drv.Row["BasicRate"]);
                }
            }
            else
            {
                x = 0;
            }
            return x;
        }


        private void DisplayBranchEmployeeList(string _payrollGroupCode,string _branchCode)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_SALARY();

            DataView dv = dt.DefaultView;
            dv.RowFilter = "PayrollGroupCode = '" + _payrollGroupCode  + "' and BranchCode='" + _branchCode + "'";
            dv.Sort = "EmployeeName";


            gvEmployeeList.DataSource = dv;
            gvEmployeeList.DataBind();
        }


        private double Compute_Gross_Income(string _empCode)
        {
            double totalGrossIncome = 0;
            double basicRate = 0;
            double RegularTotal = 0;
            double regHolidayTotal = 0, spcHolidayTotal = 0;
            double HolidayTotal = 0, OTTotal = 0, ORHTotal = 0, OShTotal = 0;

            double daysWork = 0, wLeave = 0, payoff = 0;
            double regHolidayQty = 0, spcHolidayQty = 0;
            double OTHours = 0, RegularOTHour = 0, SpecialOTHour = 0;

            double daysPresent = 0;

            double adjustment = 0, adjustmentWTax = 0;

            basicRate = Get_Employee_BasicRate(_empCode);

            if (!string.IsNullOrEmpty(txtDaysWork.Text) && Convert.ToDouble(txtDaysWork.Text) > 0)
            {
                daysWork = Convert.ToDouble(txtDaysWork.Text);
            }
            else
            {
              daysWork = 0;
            }

            if (!string.IsNullOrEmpty(txtLeavePay.Text) && Convert.ToDouble(txtLeavePay.Text) > 0)
            {
                wLeave = Convert.ToDouble(txtLeavePay.Text);
            }
            else
            { wLeave = 0; }

            if (!string.IsNullOrEmpty(txtPayOff.Text) && Convert.ToDouble(txtPayOff.Text) > 0)
            {
                payoff = Convert.ToDouble(txtPayOff.Text);
            }
            else { payoff = 0; }

            //HOLIDAY
            if (!string.IsNullOrEmpty(txtRegularHoliday.Text) && Convert.ToDouble(txtRegularHoliday.Text) > 0)
            {
                regHolidayQty = Convert.ToDouble(txtRegularHoliday.Text);
                
            }
            else { regHolidayQty = 0; }

            if (!string.IsNullOrEmpty(txtSpecialHoliday.Text) && Convert.ToDouble(txtSpecialHoliday.Text) > 0)
            {
                spcHolidayQty = Convert.ToDouble(txtSpecialHoliday.Text);
            }
            else { spcHolidayQty = 0; }

            if (!string.IsNullOrEmpty(txtSpecialHolidayOT.Text) && Convert.ToDouble(txtSpecialHolidayOT.Text) > 0)
            {
                SpecialOTHour = Convert.ToDouble(txtSpecialHolidayOT.Text);
            }
            else { SpecialOTHour = 0; }

            if (!string.IsNullOrEmpty(txtRegularHolidayOT.Text) && Convert.ToDouble(txtRegularHolidayOT.Text) > 0)
            {
                RegularOTHour = Convert.ToDouble(txtRegularHolidayOT.Text);
            }
            else { RegularOTHour = 0; }

            if (!string.IsNullOrEmpty(txtOverTime.Text) && Convert.ToDouble(txtOverTime.Text) > 0)
            {
                OTHours = Convert.ToDouble(txtOverTime.Text);
            }
            else { OTHours = 0; }

            if (!string.IsNullOrEmpty(txtAdjustment.Text) && Convert.ToDouble(txtAdjustment.Text) > 0)
            {
                adjustment = Convert.ToDouble(txtAdjustment.Text);
            }
            else { adjustment = 0; }

            if (!string.IsNullOrEmpty(txtAdjustmentWTax.Text) && Convert.ToDouble(txtAdjustmentWTax.Text) > 0)
            {
                adjustmentWTax = Convert.ToDouble(txtAdjustmentWTax.Text);
            }
            else { adjustmentWTax = 0; }

            ViewState["LEAVEQTY"] = wLeave;
            ViewState["LEAVE"] = wLeave * basicRate;
       
            ViewState["PAYOFFQTY"] = payoff;
            ViewState["PAYOFF"] = payoff * basicRate;

            OTTotal = oPayroll.GET_OT_PAY(_empCode, OTHours);
            ViewState["OVERTIMEQTY"] = OTHours;
            ViewState["OVERTIME"] = OTTotal;

            lblOTTotal.Text = OTTotal.ToString();

            //regHolidayTotal = regHolidayQty * (basicRate * oPayroll.GET_REGULAR_HOLIDAY());
            regHolidayTotal = oPayroll.GET_REGULAR_HOLIDAY(regHolidayQty, _empCode);
            lblRegularHoliday.Text = regHolidayTotal.ToString();

            ViewState["REGULARHOLIDAYQTY"] = regHolidayQty;
            ViewState["REGULARHOLIDAY"] = regHolidayTotal;

            spcHolidayTotal = oPayroll.GET_SPECIAL_HOLIDAY(spcHolidayQty,_empCode);
            lblSpecialHoliday.Text = spcHolidayTotal.ToString();
            ViewState["SPECIALHOLIDAYQTY"] = spcHolidayQty;
            ViewState["SPECIALHOLIDAY"] = spcHolidayTotal;

            //OT HOLIDAY
            ORHTotal = oPayroll.GET_REGULAR_HOLIDAY_OT_PAY(_empCode, RegularOTHour);
            lblRegularHolidayOT.Text = ORHTotal.ToString();
            ViewState["RHOVERTIMEQTY"] = RegularOTHour;
            ViewState["RHOVERTIME"] = ORHTotal;

            OShTotal = oPayroll.GET_SPECIAL_HOLIDAY_OT_PAY(_empCode, SpecialOTHour);
            lblSpecialHolidayOT.Text = OShTotal.ToString();
            ViewState["SHOVERTIMEQTY"] = SpecialOTHour;
            ViewState["SHOVERTIME"] = OShTotal;


            ViewState["ADJUSTMENT"] = adjustment;
            ViewState["ADJUSTMENTWTAX"] = adjustmentWTax;

            HolidayTotal = regHolidayTotal + spcHolidayTotal;

            daysPresent = daysWork;


            ViewState["DAYSPRESENT"] = daysPresent;

            RegularTotal = (daysPresent * basicRate) + (wLeave * basicRate) + (payoff * basicRate);

            totalGrossIncome = (RegularTotal + HolidayTotal + OTTotal + ORHTotal + OShTotal +  adjustmentWTax) - Compute_Deduction_Taxable(_empCode);

            
           

            return totalGrossIncome;


        }

        private double Compute_Deduction_Taxable(string _empCode)
        {
            double totalDeductionTaxable = 0;
            double basicRate = 0;
            double dayAbsent = 0, tardiness = 0, underTime = 0;

            double totalTardiness = 0, totalUnderTime = 0, totalAbsent = 0;

         

            basicRate = Get_Employee_BasicRate(_empCode);


            if (!string.IsNullOrEmpty(txtAbsence.Text) && Convert.ToDouble(txtAbsence.Text) > 0)
            {
                dayAbsent = Convert.ToDouble(txtAbsence.Text);
            }
            else
            {
                dayAbsent = 0;
            }

            if (!string.IsNullOrEmpty(txtTardiness.Text) && Convert.ToDouble(txtTardiness.Text) > 0)
            {
                tardiness = Convert.ToDouble(txtTardiness.Text);
            }
            else
            {
                tardiness = 0;
            }

            if (!string.IsNullOrEmpty(txtUndertime.Text) && Convert.ToDouble(txtUndertime.Text) > 0)
            {
                underTime = Convert.ToDouble(txtUndertime.Text);
            }
            else
            {
                underTime = 0;
            }


            totalTardiness = oPayroll.GET_TARDINESS_UNDERTIME_RESULT(_empCode, tardiness);
            lblTardiness.Text = totalTardiness.ToString();
            ViewState["TARDINESSQTY"] = tardiness;
            ViewState["TARDINESS"] = totalTardiness;

            totalUnderTime = oPayroll.GET_TARDINESS_UNDERTIME_RESULT(_empCode, underTime);
            lblUndertime.Text = totalUnderTime.ToString();
            ViewState["UNDERTIMEQTY"] = underTime;
            ViewState["UNDERTIME"] = totalUnderTime;

            totalAbsent = basicRate * dayAbsent;
            lblAbsence.Text = totalAbsent.ToString();
            ViewState["DAYABSENTQTY"] = dayAbsent;
            ViewState["DAYABSENT"] = totalAbsent;

            //ViewState["DAYSPRESENT"] = Convert.ToDouble(ViewState["DAYSPRESENT"].ToString()) - dayAbsent; 

            totalDeductionTaxable = totalAbsent + totalTardiness + totalUnderTime;

            return totalDeductionTaxable;

        }

        private double Compute_Government_Due_WoutTax(string _empCode)
        {
            double totalGovernmentDeduction = 0;
            double SSS = 0, PhilHealth = 0, PagIbig = 0;

            /* Payroll Period should be the second cut off to Display and compute 
            * Employee government deductions.
            * 01.07.2019
            */
            if ((int)ViewState["PPCUTOFF"] == 2)
            { 
           
            SSS = oPayroll.GET_SSS_SHARE(_empCode, Compute_Gross_Income(_empCode), Convert.ToDouble(ViewState["REGULARHOLIDAY"].ToString()), Convert.ToDouble(ViewState["RHOVERTIME"].ToString()), Convert.ToDouble(ViewState["SPECIALHOLIDAY"].ToString()), Convert.ToDouble(ViewState["SHOVERTIME"].ToString()), Convert.ToInt32(ViewState["PPID"]));
            lblSSS.Text = string.Format("{0:n}",SSS);

            PhilHealth = oPayroll.GET_PHILHEALTH_SHARE(_empCode, Compute_Gross_Income(_empCode), Convert.ToDouble(ViewState["REGULARHOLIDAY"].ToString()), Convert.ToDouble(ViewState["RHOVERTIME"].ToString()), Convert.ToDouble(ViewState["SPECIALHOLIDAY"].ToString()), Convert.ToDouble(ViewState["SHOVERTIME"].ToString()), Convert.ToInt32(ViewState["PPID"]));
            lblPhilHealth.Text = string.Format("{0:n}", PhilHealth);

            PagIbig = oPayroll.GET_PAGIBIG_SHARE(_empCode);
            lblPagibig.Text = string.Format("{0:n}", PagIbig);

            totalGovernmentDeduction = SSS + PhilHealth + PagIbig;
            }
            else
            { totalGovernmentDeduction = 0; }

            return totalGovernmentDeduction;
        }

        private double Compute_TaxableIncome(string _empCode)
        {
            double taxableIncome = 0;

            double grossIncome = Compute_Gross_Income(_empCode);
            
            double governmentDuesIncludeTaxComputation = Compute_Government_Due_WoutTax(_empCode);



            /* Payroll Period should be the second cut off to Display and compute 
            * Employee government deductions.
            * 01.07.2019
            */
            if ((int)ViewState["PPCUTOFF"] == 2)
            {
                taxableIncome = grossIncome - governmentDuesIncludeTaxComputation;
            }
            else
            { taxableIncome = 0; }

                return taxableIncome;
        }

        private double Compute_WTax(string _empCode)
        {
            double WTaxTotal = 0;
            
            WTaxTotal = oPayroll.GET_WITH_HOLDING_TAX(_empCode,Compute_TaxableIncome(_empCode), Convert.ToInt32(ViewState["PPID"]));

            return WTaxTotal;
        }


        private double Compute_Total_Deductions(string _empCode)
        {
            double total_Deductions = 0;
            double hdmfAdditional = 0;

            double boardinglodging = 0, cashAdvance = 0, emergencyLoan = 0, salaryLoan = 0, sssLoan = 0, pagibigLoan = 0, otherDeduction = 0;

            if (!string.IsNullOrEmpty(txtBoardingLodging.Text) && Convert.ToDouble(txtBoardingLodging.Text) > 0)
            {
                boardinglodging = Convert.ToDouble(txtBoardingLodging.Text);
            }
            else
            {
                boardinglodging = 0;
            }

            if (!string.IsNullOrEmpty(txtCashAdvance.Text) && Convert.ToDouble(txtCashAdvance.Text) > 0)
            {
                cashAdvance = Convert.ToDouble(txtCashAdvance.Text);
            }
            else
            {
                cashAdvance = 0;
            }

            if (!string.IsNullOrEmpty(txtEmergencyLoan.Text) && Convert.ToDouble(txtEmergencyLoan.Text) > 0)
            {
                emergencyLoan = Convert.ToDouble(txtEmergencyLoan.Text);
            }
            else
            {
                emergencyLoan = 0;
            }

            if (!string.IsNullOrEmpty(txtSalaryLoan.Text) && Convert.ToDouble(txtSalaryLoan.Text) > 0)
            {
                salaryLoan = Convert.ToDouble(txtSalaryLoan.Text);
            }
            else
            {
                salaryLoan = 0;
            }

            if (!string.IsNullOrEmpty(txtSSSLoan.Text) && Convert.ToDouble(txtSSSLoan.Text) > 0)
            {
                sssLoan = Convert.ToDouble(txtSSSLoan.Text);
            }
            else
            {
                sssLoan = 0;
            }

            if (!string.IsNullOrEmpty(txtPagibigLoan.Text) && Convert.ToDouble(txtPagibigLoan.Text) > 0)
            {
                pagibigLoan = Convert.ToDouble(txtPagibigLoan.Text);
            }
            else
            {
                pagibigLoan = 0;
            }

            if (!string.IsNullOrEmpty(txtOtherDeduction.Text) && Convert.ToDouble(txtOtherDeduction.Text) > 0)
            {
                otherDeduction = Convert.ToDouble(txtOtherDeduction.Text);
            }
            else
            {
                otherDeduction = 0;
            }

            if (!string.IsNullOrEmpty(txtPagIbigAdditional.Text) && Convert.ToDouble(txtPagIbigAdditional.Text) > 0)
            {
                hdmfAdditional = Convert.ToDouble(txtPagIbigAdditional.Text);
            }
            else
            {
                hdmfAdditional = 0;
            }

            //PAGIBIG ADDITIONAL


            ViewState["BOARDINGLODGING"] = boardinglodging;
            ViewState["CASHADVANCE"] = cashAdvance;
            ViewState["EMERGENCYLOAN"] = emergencyLoan;
            ViewState["SALARYLOAN"] = salaryLoan;
            ViewState["SSSLOAN"] = sssLoan;
            ViewState["PAGIBIGLOAN"] = pagibigLoan;
            ViewState["OTHERDEDUCTION"] = otherDeduction;
            ViewState["HDMFPAYADD"] = hdmfAdditional;

            total_Deductions =  Compute_Government_Due_WoutTax(_empCode) + Compute_WTax(_empCode)
                                + boardinglodging + cashAdvance + emergencyLoan + salaryLoan + sssLoan + pagibigLoan 
                                + otherDeduction + hdmfAdditional;

            return total_Deductions;
        }

        private double Compute_Net_Pay(string _empCode)
        {
            double totalNetPay = 0;

            totalNetPay = Compute_Gross_Income(_empCode) - Compute_Total_Deductions(_empCode) + Convert.ToDouble(ViewState["ADJUSTMENT"].ToString());

            return totalNetPay;
        }


        protected void ddWageArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            DisplayBranchWageList(ddWageArea.SelectedValue.ToString());
        }

       

     

        protected void ddBranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
           DisplayBranchEmployeeList("BP", ddBranchList.SelectedValue);
        }

       

        //protected void ddPayrollGroup_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddPayrollGroup.SelectedValue == "BP")
        //    {
        //        panelBranchPayroll.Visible = true;

        //        gvEmployeeList.DataSource = null;
        //        gvEmployeeList.DataBind();
        //    }
        //    else if (ddPayrollGroup.SelectedValue == "DP")
        //    {
        //        panelBranchPayroll.Visible = false;
        //        ddWageArea.SelectedIndex = 0;

        //        DisplayEmployeeListOffice(ddPayrollGroup.SelectedValue.ToString());
        //    }
        //}

        protected void lnkEmployeeAssign_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;
            string sEmpName = r.Cells[1].Text;


            
            panelRight.Enabled = true;
            Clear_Inputs();
            txtSearch.Text = "";
            ViewState["EMP_CODE"] = sEmpCode;
            lblEmployeeCodeAndName.Text = sEmpName;

            lblBasicRate.Text = " (Rate Per Day: <b>" + string.Format("{0:n}", Get_Employee_BasicRate(sEmpCode)) + "</b>)";

         
            if (oPayroll.CHECK_EMPLOYEE_PAYROLL_EXIST(sEmpCode, Convert.ToInt16(ViewState["PPID"])))
            {
                DataTable dt = oPayroll.GET_EMPLOYEE_SALARY_ENCODED(sEmpCode, Convert.ToInt16(ViewState["PPID"]));

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                    txtDaysWork.Text = dr["DaysPresent"].ToString();
                    txtLeavePay.Text = dr["Leave_Qty"].ToString();
                    txtPayOff.Text = dr["Payoff_Qty"].ToString();
                    txtOverTime.Text = dr["OverTime_Qty"].ToString();
                    txtRegularHoliday.Text = dr["RegularHoliday_Qty"].ToString();
                    txtRegularHolidayOT.Text = dr["RegHolidayOT_Qty"].ToString();
                    txtSpecialHoliday.Text = dr["SpecialHoliday_Qty"].ToString();
                    txtSpecialHolidayOT.Text = dr["SpcHolidayOT_Qty"].ToString();
                    txtAdjustment.Text = dr["Adjustment"].ToString();
                    txtAdjustmentWTax.Text = dr["AdjustmentWTax"].ToString();

                    txtAbsence.Text = dr["DayAbsences_Qty"].ToString();
                    txtUndertime.Text = dr["UnderTime_Qty"].ToString();
                    txtTardiness.Text = dr["Tardiness_Qty"].ToString();

                    txtBoardingLodging.Text = dr["BoardLodging"].ToString();
                    txtCashAdvance.Text = dr["CashAdvance"].ToString();
                    txtEmergencyLoan.Text = dr["EmergencyLoan"].ToString();
                    txtSalaryLoan.Text = dr["SalaryLoan"].ToString();
                    txtSSSLoan.Text = dr["SSSLoan"].ToString();
                    txtPagibigLoan.Text = dr["PagibigLoan"].ToString();

                    txtOtherDeduction.Text = dr["OtherDeduction"].ToString();

                    txtPagIbigAdditional.Text = dr["HDMFPayAdd"].ToString();
                    }
                }
                
               
            }

            double _salaryLoanBalance = 0, _sssLoanBalance = 0, _pagibigLoanBalance = 0;

            _salaryLoanBalance = Convert.ToDouble(txtSalaryLoan.Text) + oPayroll.GET_EMPLOYEE_SALARY_LOAN_BALANCE(sEmpCode);
            _sssLoanBalance = Convert.ToDouble(txtSSSLoan.Text) + oPayroll.GET_EMPLOYEE_SSS_LOAN_BALANCE(sEmpCode);
            _pagibigLoanBalance = Convert.ToDouble(txtPagibigLoan.Text) + oPayroll.GET_EMPLOYEE_PAGIBIG_LOAN_BALANCE(sEmpCode);

            lblLoanBalance.Text = "<b>(" + string.Format("{0:n}", _salaryLoanBalance) + ")</b>";
            lblSSSLoan.Text = "<b>(" + string.Format("{0:n}", _sssLoanBalance ) + ")</b>";
            lblPagibigLoan.Text = "<b>(" + string.Format("{0:n}", _pagibigLoanBalance) + ")</b>";

            ViewState["SALARYLOANBALANCE"] = _salaryLoanBalance;
        }

        protected void lnkCompute_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDaysWork.Text) && Convert.ToDouble(txtDaysWork.Text) != 0)
            {

                string _empCode = ViewState["EMP_CODE"].ToString();


                lblTotalGross.Text = string.Format("{0:n}", Compute_Gross_Income(_empCode));
                lblTotalDeduction.Text = string.Format("{0:n}", Compute_Total_Deductions(_empCode));
               // lblTaxableIncome.Text = string.Format("{0:n}", Compute_TaxableIncome(_empCode));

                lblWTax.Text = string.Format("{0:n}", Compute_WTax(_empCode));

                lblTotalNetPay.Text = string.Format("{0:n}", Compute_Net_Pay(_empCode));

                lblNonTaxableAdjustment.Text = string.Format("{0:n}", ViewState["ADJUSTMENT"].ToString());
            }
            else
            {

                lblErrorMessage.Text = "Empty or 0 days of work not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);

            }

        }

        protected void lnkProcess_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDaysWork.Text) && Convert.ToDouble(txtDaysWork.Text) != 0)
            {

                lnkCompute_Click(sender, e);

                double daysWork = Convert.ToDouble(txtDaysWork.Text);
                double basicRate = Get_Employee_BasicRate(ViewState["EMP_CODE"].ToString());
                //double basicPay = basicRate * Convert.ToDouble(ViewState["DAYSPRESENT"].ToString());

                double sssPay = Convert.ToDouble(lblSSS.Text);
                double philHealthPay = Convert.ToDouble(lblPhilHealth.Text);
                double hdmfPay = Convert.ToDouble(lblPagibig.Text);
                double wTaxPay = Convert.ToDouble(lblWTax.Text);

                double grossIncome = Convert.ToDouble(lblTotalGross.Text);
                double taxableIncome = Convert.ToDouble(lblTaxableIncome.Text);
                double totalDeduction = Convert.ToDouble(lblTotalDeduction.Text);
                double netPay = Convert.ToDouble(lblTotalNetPay.Text);

                //double payOffQty = Convert.ToDouble(txtPayOff.Text);


                oPayroll.INSERT_UPDATE_EMPLOYEE_PAYROLL_TRANS(Convert.ToInt16(ViewState["PPID"]), ViewState["EMP_CODE"].ToString(), basicRate, daysWork, Convert.ToDouble(ViewState["DAYSPRESENT"].ToString()),
                                                                Convert.ToDouble(ViewState["REGULARHOLIDAYQTY"].ToString()), Convert.ToDouble(ViewState["REGULARHOLIDAY"].ToString()),
                                                                Convert.ToDouble(ViewState["SPECIALHOLIDAYQTY"].ToString()), Convert.ToDouble(ViewState["SPECIALHOLIDAY"].ToString()),
                                                                Convert.ToDouble(ViewState["LEAVEQTY"].ToString()), Convert.ToDouble(ViewState["LEAVE"].ToString()), Convert.ToDouble(ViewState["PAYOFFQTY"].ToString()), Convert.ToDouble(ViewState["PAYOFF"].ToString()),
                                                                Convert.ToDouble(ViewState["OVERTIMEQTY"].ToString()), Convert.ToDouble(ViewState["OVERTIME"].ToString()), Convert.ToDouble(ViewState["RHOVERTIMEQTY"].ToString()), Convert.ToDouble(ViewState["RHOVERTIME"].ToString()),
                                                                Convert.ToDouble(ViewState["SHOVERTIMEQTY"].ToString()), Convert.ToDouble(ViewState["SHOVERTIME"].ToString()),
                                                                Convert.ToDouble(ViewState["DAYABSENTQTY"].ToString()), Convert.ToDouble(ViewState["DAYABSENT"].ToString()),
                                                                Convert.ToDouble(ViewState["TARDINESSQTY"].ToString()), Convert.ToDouble(ViewState["TARDINESS"].ToString()),
                                                                Convert.ToDouble(ViewState["UNDERTIMEQTY"].ToString()), Convert.ToDouble(ViewState["UNDERTIME"].ToString()),
                                                                sssPay, philHealthPay, hdmfPay, Convert.ToDouble(ViewState["HDMFPAYADD"].ToString()), wTaxPay,
                                                                Convert.ToDouble(ViewState["BOARDINGLODGING"].ToString()), Convert.ToDouble(ViewState["CASHADVANCE"].ToString()), Convert.ToDouble(ViewState["EMERGENCYLOAN"].ToString()),
                                                                Convert.ToDouble(ViewState["SALARYLOAN"].ToString()), Convert.ToDouble(ViewState["SSSLOAN"].ToString()), Convert.ToDouble(ViewState["PAGIBIGLOAN"].ToString()),Convert.ToDouble(ViewState["SALARYLOANBALANCE"].ToString()),
                                                                Convert.ToDouble(ViewState["OTHERDEDUCTION"].ToString()), grossIncome, taxableIncome, totalDeduction, netPay,
                                                                Convert.ToDouble(ViewState["ADJUSTMENT"].ToString()), Convert.ToDouble(ViewState["ADJUSTMENTWTAX"].ToString()));



                //Process Salary Loan Deduction for those employee with active link
                string sLoanSalarySN = "", sLoanSSSSN = "", sLoanPagibigSN = "";

                //SALARY LOAN
                if (oPayroll.CHECK_EMPLOYEE_SALARY_LOAN_ACTIVE(ViewState["EMP_CODE"].ToString()))
                {
                    sLoanSalarySN = oPayroll.GET_EMPLOYEE_ACTIVE_SALARY_LOAN(ViewState["EMP_CODE"].ToString());
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LOAN_PAYMENT(oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("LOR"), sLoanSalarySN, oSystem.GET_SERVER_DATE_TIME().Date, Convert.ToDouble(ViewState["SALARYLOAN"].ToString()), lblPayrollPeriodText.Text, ViewState["PPID"].ToString());
                }

                //SSS
                if (oPayroll.CHECK_EMPLOYEE_SSS_LOAN_ACTIVE(ViewState["EMP_CODE"].ToString()))
                {
                    sLoanSSSSN = oPayroll.GET_EMPLOYEE_ACTIVE_SSS_LOAN(ViewState["EMP_CODE"].ToString());
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LOAN_PAYMENT(oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("LOR"), sLoanSSSSN, oSystem.GET_SERVER_DATE_TIME().Date, Convert.ToDouble(ViewState["SSSLOAN"].ToString()), lblPayrollPeriodText.Text, ViewState["PPID"].ToString());
                }

                //PAG-IBIG
                if (oPayroll.CHECK_EMPLOYEE_PAGIBIG_LOAN_ACTIVE(ViewState["EMP_CODE"].ToString()))
                {
                    sLoanPagibigSN = oPayroll.GET_EMPLOYEE_ACTIVE_PAGIBIG_LOAN(ViewState["EMP_CODE"].ToString());
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LOAN_PAYMENT(oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("LOR"), sLoanPagibigSN, oSystem.GET_SERVER_DATE_TIME().Date, Convert.ToDouble(ViewState["PAGIBIGLOAN"].ToString()), lblPayrollPeriodText.Text, ViewState["PPID"].ToString());
                }
                 

                lblSuccessMessage.Text = lblEmployeeCodeAndName.Text + " payroll successfully process.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                panelLeft.Enabled = true;
                panelRight.Enabled = false;
                //RESET
                Clear_Inputs();


                //if (ddPayrollGroup.SelectedIndex == 1)
                //{
                //    ddBranchList_SelectedIndexChanged(sender, e);
                //}
                //else
                //{
                //    ddPayrollGroup_SelectedIndexChanged(sender, e);
                //}
            }

            else
            {

                lblErrorMessage.Text = "Empty or 0 days of work not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);

            }


        }

        //CLEAR
        private void Clear_Inputs()
        {
            txtDaysWork.Text = "0";
            txtLeavePay.Text = "0";
            txtPayOff.Text = "0";
            txtOverTime.Text = "0";
            txtRegularHoliday.Text = "0";
            txtRegularHolidayOT.Text = "0";
            txtSpecialHoliday.Text = "0";
            txtSpecialHolidayOT.Text = "0";
            txtAdjustment.Text = "0";
            txtAdjustmentWTax.Text = "0";

            //Deduction
            txtAbsence.Text = "0";
            txtTardiness.Text = "0";
            txtUndertime.Text = "0";
            txtBoardingLodging.Text = "0";
            txtCashAdvance.Text = "0";
            txtEmergencyLoan.Text = "0";
            txtSalaryLoan.Text = "0";
            txtSSSLoan.Text = "0";
            txtPagibigLoan.Text = "0";

            txtOtherDeduction.Text = "0";
            txtPagIbigAdditional.Text = "0";

            lblOTTotal.Text = "0";
            lblRegularHoliday.Text = "0";
            lblRegularHolidayOT.Text = "0";
            lblSpecialHoliday.Text = "0";
            lblSpecialHolidayOT.Text = "0";
            lblAbsence.Text = "0";
            lblTardiness.Text = "0";
            lblUndertime.Text = "0";


            //GOVT DUES
            lblSSS.Text = "0";
            lblPhilHealth.Text = "0";
            lblPagibig.Text = "0";
            lblWTax.Text = "0";

            //Breakdown
            lblTotalGross.Text = "0";
            lblTaxableIncome.Text = "0";
            lblTotalDeduction.Text = "0";
            lblTotalNetPay.Text = "0";
            lblNonTaxableAdjustment.Text = "0";

            lblEmployeeCodeAndName.Text = "";
            lblBasicRate.Text = "";

            //LOANS
            lblLoanBalance.Text = "";
            lblSSSLoan.Text = "";
            lblPagibigLoan.Text = "";

            ViewState["SALARYLOANBALANCE"] = 0;

        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            //panelLeft.Enabled = true;
            //panelRight.Enabled = false;
            ////RESET
            //Clear_Inputs();
        }

        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //COMMENTED TO ENHANCE PERFORMANCE in loading of LIST. 09272018

            foreach (GridViewRow r in gvEmployeeList.Rows)
            {
                try
                {
                    string sEmpCode = r.Cells[0].Text;
                LinkButton lnkEditSalary = r.FindControl("lnkEmployeeAssign") as LinkButton;

                if (oPayroll.CHECK_EMPLOYEE_PAYROLL_EXIST(sEmpCode, Convert.ToInt16(ViewState["PPID"])))
                {
                    lnkEditSalary.Text = "Edit";
                    lnkEditSalary.CssClass = "btn btn-success btn-sm";
                }

                    //else
                    //{
                    //    imgEmployee.ImageUrl = "../Emp_Pictures/default-avatar.png";
                    //}


                }
                catch { }
            }
        }
    }
}