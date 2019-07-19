using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DGMU_HR
{
    public partial class dataEntryEmployeeLoan : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayEmployeeList();
     
            }
        }
        
        

        private void DisplayEmployeeList()
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LIST_LW();

            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();

            imgEmployee.ImageUrl = "~/Emp_Pictures/default-avatar.png";
        }
   
        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;
            string sEmpName = r.Cells[1].Text;

            ViewState["EMPCODE"] = sEmpCode;
            lblEmployeeName.Text = "<b>" + sEmpName + "</b>";
            
            if (File.Exists(Server.MapPath("~/Emp_Pictures/" + sEmpCode + ".jpg")))
            {
                imgEmployee.ImageUrl = "~/Emp_Pictures/" + sEmpCode + ".jpg";
            }
            else
            {
                imgEmployee.ImageUrl = "~/Emp_Pictures/default-avatar.png";
            }

            //   DisplayEmployeeAttendance(sEmpCode, Convert.ToInt16(ViewState["PPID"].ToString()));
            txtLoanAmount.Text = "0";

            DisplayLoanList();
            DisplayEmployeeLoan(ViewState["EMPCODE"].ToString());
            DisplayEmployeeLoanHistory(ViewState["EMPCODE"].ToString());
        }



        private void DisplayLoanList()
        {
            DataTable dt = oPayroll.GET_LOANS_LIST();

            ddLoansList.DataSource = dt;
            ddLoansList.DataTextField = dt.Columns["LoanName"].ToString();
            ddLoansList.DataValueField = dt.Columns["LoanCode"].ToString();
            ddLoansList.DataBind();
        }

        private void DisplayEmployeeLoan(string _empCode)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LOANS();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "EmpCode='" + _empCode + "' and IsOpen=1";

            if (dv.Count > 0)
            {
                gvActiveLoans.DataSource = dv;
                gvActiveLoans.DataBind();
            }
            else {
                gvActiveLoans.DataSource = null;
                gvActiveLoans.DataBind();
            }
        }

        private void DisplayEmployeeLoanHistory(string _empCode)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LOANS();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "EmpCode='" + _empCode + "' and IsClose=1 and IsSettled=1";

            if (dv.Count > 0)
            {
                gvEmployeeLoanHistory.DataSource = dv;
                gvEmployeeLoanHistory.DataBind();
            }
            else
            {
                gvEmployeeLoanHistory.DataSource = null;
                gvEmployeeLoanHistory.DataBind();
            }
        }

        protected void lnkCreateLoan_Click(object sender, EventArgs e)
        {
            panelNewLoan.Enabled = true;
        }

        protected void lnkProcess_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtLoanAmount.Text) > 0 && !string.IsNullOrEmpty(txtDateLoan.Text))
            {
                //Check if Loan Type have active balance
                if (!checkActiveLoanTypeExist(ViewState["EMPCODE"].ToString(), ddLoansList.SelectedValue))
                {
                    //Save Loan
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LOAN(oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("LN"), ViewState["EMPCODE"].ToString(), ddLoansList.SelectedValue, Convert.ToDateTime(txtDateLoan.Text), Convert.ToDouble(txtLoanAmount.Text), txtRemarks.Text);

                    DisplayEmployeeLoan(ViewState["EMPCODE"].ToString());

                    txtDateLoan.Text = "";
                    txtLoanAmount.Text = "0";
                    txtRemarks.Text = "";
                    panelNewLoan.Enabled = false;

                    lblSuccessMessage.Text = "Employee Loan successfully save.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
                }
                else
                {
                    lblErrorMessage.Text = "Employee has existing active " + ddLoansList.SelectedItem.ToString() + ". Use Add loan procedure instead.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                }
            }
            else {
                lblErrorMessage.Text = "Input required.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void lnkPayment_Click(object sender, EventArgs e)
        {
            //Save Loan Payment List
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            ViewState["LOANSN"] = r.Cells[1].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalPaymentEntry').modal('show');</script>", false);
        }

        protected void lnkProcessPayment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPaymentDate.Text) && Convert.ToDouble(txtPaymentAmount.Text) != 0)
            {
            oPayroll.INSERT_UPDATE_EMPLOYEE_LOAN_PAYMENT(oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("LOR"), ViewState["LOANSN"].ToString(), Convert.ToDateTime(txtPaymentDate.Text), Convert.ToDouble(txtPaymentAmount.Text), txtPaymentRemarks.Text, "LP" + oSystem.GET_SERVER_DATE_TIME().ToShortTimeString());
            Response.Redirect(Request.RawUrl);
            }
        }

        protected void lnkViewPayment_Click(object sender, EventArgs e)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_PAYMENT_LOANS_LIST();

            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            string sLoanSN = r.Cells[1].Text;

            DataView dv = dt.DefaultView;
            dv.RowFilter = "LoanSN='" + sLoanSN +"'";
            dv.Sort = "PaymentDate desc";
            

            gvLoanPaymentList.DataSource = dv;
            gvLoanPaymentList.DataBind();


            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalPaymentList').modal('show');</script>", false);
        }

        protected void lnkViewPaymentHistory_Click(object sender, EventArgs e)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_PAYMENT_LOANS_LIST();

            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            string sLoanSN = r.Cells[0].Text;

            DataView dv = dt.DefaultView;
            dv.RowFilter = "LoanSN='" + sLoanSN + "'";
            dv.Sort = "PaymentDate desc";

            gvLoanPaymentList.DataSource = dv;
            gvLoanPaymentList.DataBind();


            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalPaymentList').modal('show');</script>", false);
        }


        


        protected void gvActiveLoans_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //THIS IS APPLICABLE ONLY IN SALARY LOAN
            foreach (GridViewRow r in gvActiveLoans.Rows)
            { 
                LinkButton lnkPayroll = r.FindControl("lnkPayroll") as LinkButton;
                LinkButton lnkPayrollRemove = r.FindControl("lnkPayrollRemove") as LinkButton;
                string sLoanCode = r.Cells[2].Text;

                //Temporay disable loan link deduction for SSS and PAGIBIG
                //if (sLoanCode != "SS" && sLoanCode != "PG")
                //{

                    //if (oPayroll.CHECK_EMPLOYEE_LOAN_DEDUCTION_LINK(ViewState["EMPCODE"].ToString(), sLoanCode))
                    //{
                    //    lnkPayroll.Visible = false;
                    //    lnkPayrollRemove.Visible = false;
                    //}
                    //else
                    //{
                    //    lnkPayroll.Visible = false;
                    //    lnkPayrollRemove.Visible = false;
                    //}
                //}
                //else
                //{
                //    lnkPayroll.Visible = false;
                //    lnkPayrollRemove.Visible = false;
                //}

            }
        }

        protected void lnkPayroll_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

           string sLoanSN = r.Cells[1].Text;

            oPayroll.UPDATE_LINK_EMPLOYEE_SALARY_LOAN_DEDUCTION(sLoanSN);

            lblSuccessMessage.Text = "Loan Deduction successfully Link to Payroll";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

            DisplayEmployeeLoan(ViewState["EMPCODE"].ToString());

        }

        protected void lnkPayrollRemove_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            string sLoanSN = r.Cells[1].Text;

            oPayroll.UPDATE_LINK_EMPLOYEE_SALARY_LOAN_DEDUCTION(sLoanSN);

            lblSuccessMessage.Text = "Deduction successfully unlink from Payroll";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

            DisplayEmployeeLoan(ViewState["EMPCODE"].ToString());
        }

        protected void lnkAddLoan_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            ViewState["V_LOANSN"] = r.Cells[1].Text;
            ViewState["V_LOANCODE"] = r.Cells[2].Text;

            lblAddLoanTitle.Text = "Additional " + r.Cells[3].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalAdditionalLoan').modal('show');</script>", false);
        }

        protected void lnkAddLoanProcess_Click(object sender, EventArgs e)
        {
            oPayroll.INSERT_UPDATE_ADD_LOAN(ViewState["V_LOANSN"].ToString(), ViewState["V_LOANCODE"].ToString(),Convert.ToDateTime(txtAddLoanDate.Text),Convert.ToDouble(txtAddLoanAmount.Text),txtAddLoanRemarks.Text);
            Response.Redirect(Request.RawUrl);
        }

        private bool checkActiveLoanTypeExist(string _empCode, string _loanCode)
        {
            bool x;

            DataTable dt = oPayroll.GET_EMPLOYEE_LOANS();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "EmpCode='" + _empCode + "' and IsSettled=0 and loanCode = '" + _loanCode + "'";

            if (dv.Count > 0)
            {
                x = true;
            }
            else
            {
                x = false;
            }

            return x;
        }

        protected void lnkViewAddLoans_Click(object sender, EventArgs e)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LOAN_DETAILS();

            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            string sLoanSN = r.Cells[1].Text;

            DataView dv = dt.DefaultView;
            dv.RowFilter = "LoanSN='" + sLoanSN + "'";
            dv.Sort = "LoanDate desc";

            gvLoanDetailList.DataSource = dv;
            gvLoanDetailList.DataBind();

            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalLoanDetailList').modal('show');</script>", false);

        }
    }
}