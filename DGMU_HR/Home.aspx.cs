using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class Home : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        Employee_Data_C oEmployee = new Employee_Data_C();
        SystemX oSystem = new SystemX();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                DisplayEmployeeEmploymentStat();

                DisplayPayrollPeriodToday();

                lblDefaultYear.Text = " Year: <b>" + oSystem.GET_DEFAULT_FISCAL_YEAR().ToString() + "</b> <p> Today is:" + DateTime.Now.ToShortDateString() +"</p>";

                //lblCountActiveEmployee.Text = "Active Employee's : <b>" + oPayroll.GET_COUNT_EMPLOYEE_ACTIVE() + "</b>";
                //  lnkActiveEmployees.Text = oPayroll.GET_COUNT_EMPLOYEE_ACTIVE().ToString();

                // lblActiveLoansCount.Text = "Active Salary Loans : <b>" + oPayroll.GET_COUNT_EMPLOYEE_SALARY_LOAN_ACTIVE() + "</b>";

                //if (!string.IsNullOrEmpty(lblUser.Text))
                //{
                //    
                //}
                //else
                //{
                //    Response.Redirect("~/login.aspx");
                //}
               
                lblUser.Text = Session["USER"].ToString();
               

                DisplayMonthBirthday(oSystem.GET_SERVER_DATE_TIME().Month);

                DisplayMonthEndOfService(oSystem.GET_SERVER_DATE_TIME().Month);

                //DISPLAY EMPLOYEE PAYROLL PROCESSED
                DisplayEmployeePayrollProcessed(oPayroll.GET_DEFAULT_PAYROLL_PERIOD());
                lnkProcessPayrollStat.Text = gvEmployeePayrollProcessed.Rows.Count.ToString();

                DisplayEmployeeLoanStat();


                //Upcoming Leaves.
                DisplayUpcomingLeaves();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = oSystem.GET_SERVER_DATE_TIME().ToLongDateString() + " " + oSystem.GET_SERVER_DATE_TIME().ToLongTimeString();
        }

        private void DisplayMonthBirthday(int _month)
        {
            DataTable dt = oEmployee.GET_ACTIVE_EMPLOYEE_LIST_LW();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Status = '" + "Active" + "' and BdayMonth = '" + _month + "'";
            dv.Sort = "BdayDay, Date_Of_Birth, EmployeeName";

            lblBirthdayMonth.Text = dv.Count.ToString() + " Birthday celebrant(s) for the month of " + oSystem.GET_SERVER_DATE_TIME().ToString("MMMM") + " " + oSystem.GET_SERVER_DATE_TIME().Year.ToString();

            if (dv.Count > 0)
            {
                gvBirthdayList.DataSource = dv;
                gvBirthdayList.DataBind();
            } 
        }

        //END OF SERVICES LIST 03.29.2020
        private void DisplayMonthEndOfService(int _month)
        {
            DataTable dt = oEmployee.GET_END_OF_SERVICES_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "EffectiveMonth = '" + _month + "'";
            dv.Sort = "IsSet, EOs_Effective_Date, EmployeeName";

           // lblBirthdayMonth.Text = dv.Count.ToString() + " Birthday celebrant(s) for the month of " + oSystem.GET_SERVER_DATE_TIME().ToString("MMMM") + " " + oSystem.GET_SERVER_DATE_TIME().Year.ToString();

            if (dv.Count > 0)
            {
                gvEOSList.DataSource = dv;
                gvEOSList.DataBind();
            }
        }

        private void DisplayEmployeeEmploymentStat()
        {
            DataTable dt = oEmployee.GET_EMPLOYEE_EMPLOYMENT_STAT();

            gvEmployeeEmploymentStat.DataSource = dt;
            gvEmployeeEmploymentStat.DataBind();
        }

        private void DisplayEmployeeLoanStat()
        {
            lblActiveLoansCount.Text = "Active Loans";

            DataTable dt = oPayroll.GET_EMPLOYEE_ACTIVE_LOANS_STAT();

            gvEmployeeLoanStat.DataSource = dt;
            gvEmployeeLoanStat.DataBind();

        }

        private void DisplayUpcomingLeaves()
        {
            DataView dv = oEmployee.GET_EMPLOYEE_UPCOMING_LEAVES().DefaultView;

            dv.Sort = "DateFrom, EmployeeName";

            gvUpcomingLeaves.DataSource = dv;
            gvUpcomingLeaves.DataBind();

            lblUpcomingLeaveCount.Text = dv.Count.ToString();
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
                   

                    lblPayrollPeriodText.Text = "Payroll Period : <b>" + drv["Description"].ToString() + "</b>";
                  
                }
            }

        }

        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }

      
        //Display List of Employee Processed Payroll
        protected void DisplayEmployeePayrollProcessed(int _ppID)
        {
            txtSearch.Text = "";
            DataView dv = oPayroll.GET_EMPLOYEE_PAYROLL_PROCESS_STAT(_ppID).DefaultView;
            dv.Sort = "EmployeeFullName";

            gvEmployeePayrollProcessed.DataSource = dv;
            gvEmployeePayrollProcessed.DataBind();
        }

        protected void lnkProcessPayrollStat_Click1(object sender, EventArgs e)
        {
           // DisplayEmployeePayrollProcessed(Convert.ToInt32(ViewState["PPID"]));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalShowProcessPayroll').modal('show');</script>", false);
        }
        
        protected void lnkEmpStat_Click(object sender, EventArgs e)
        {
            txtSearchEmpStat.Text = "";

            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            //string sStatusCode = r.Cells[0].Text;
            string sStatus = r.Cells[0].Text;

            lblEmployeeStatusName.Text = "List of " + sStatus + " Employee's";


            DataView dv = oEmployee.GET_ALL_EMPLOYEE_LIST_LW().DefaultView;
            dv.RowFilter = "Status ='" + sStatus + "'";


            if (dv.Count > 0)
            {
                gvEmployeeEmploymentStatList.DataSource = dv;
                gvEmployeeEmploymentStatList.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalShowEmploymentStat').modal('show');</script>", false);
            }

            
        }

        protected void lnkEmpLoanList_Click(object sender, EventArgs e)
        {
            txtSearchEmployeeLoan.Text = "";

            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            //string sStatusCode = r.Cells[0].Text;
            string sLoanName = r.Cells[0].Text;

            DataView dv = oPayroll.GET_EMPLOYEE_ACTIVE_LOANS_LOANS_LIST().DefaultView;
            dv.RowFilter = "LoanName ='" + sLoanName + "'";

            lblActiveLoanName.Text = "List of " + sLoanName + " Employee's";

            if (dv.Count > 0)
            {
                gvEmployeeLoanList.DataSource = dv;
                gvEmployeeLoanList.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalShowEmployeeLoanStat').modal('show');</script>", false);
            }
        }

       
        protected void lnkNoGovtID_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/repEmployeeNoGovtID.aspx");
        }

        protected void lnkManual13thMonth_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/data13thMonthManualEntry.aspx");
        }
    }
}