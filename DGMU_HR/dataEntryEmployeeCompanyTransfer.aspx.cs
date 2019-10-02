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
    public partial class dataEntryEmployeeCompanyTransfer : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();
        Employee_Data_C oEmployee = new Employee_Data_C();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayEmployeeList();
                DisplayCompanyList();

            }
        }
        
        

        private void DisplayEmployeeList()
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LIST_LW();

            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();

            imgEmployee.ImageUrl = "~/Emp_Pictures/default-avatar.png";
        }

        private void DisplayCompanyList()
        {
            DataTable dt = oSystem.GET_COMPANY_LIST();
            ddTransferCompanyTo.DataSource = dt;
            ddTransferCompanyTo.DataTextField = dt.Columns["CompanyName"].ToString();
            ddTransferCompanyTo.DataValueField = dt.Columns["CompanyCode"].ToString();
            ddTransferCompanyTo.DataBind();
          
        }
   
        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;
            string sEmpName = r.Cells[1].Text;

            ViewState["EMPLOYEEID"] = sEmpCode;
            lblEmployeeName.Text = "<b>" + sEmpName + "</b>";
            
            if (File.Exists(Server.MapPath("~/Emp_Pictures/" + sEmpCode + ".jpg")))
            {
                imgEmployee.ImageUrl = "~/Emp_Pictures/" + sEmpCode + ".jpg";
            }
            else
            {
                imgEmployee.ImageUrl = "~/Emp_Pictures/default-avatar.png";
            }

            txtSearch.Text = "";
            //Display Current Company
            lblCurrentCompany.Text = GET_CURRENT_EMPLOYEE_COMPANY(sEmpCode);
            ddTransferCompanyTo.Enabled = true;

            gvEmployeeTransferHistory.DataSource = oEmployee.GET_EMPLOYEE_COMPANY_TRANSFER(ViewState["EMPLOYEEID"].ToString());
            gvEmployeeTransferHistory.DataBind();



        }


        private string GET_CURRENT_EMPLOYEE_COMPANY(string _employeeID)
        {
            string x = "";

            DataView dv = oEmployee.GET_EMPLOYEE_LIST_LW().DefaultView;

            dv.RowFilter = "EmployeeID ='" + _employeeID + "'";

            if (dv.Count > 0)
            {
                foreach (DataRowView dvr in dv)
                {
                    x = dvr["CompanyName"].ToString();
                    ViewState["CURRENTCOMPANYCODE"] = dvr["CompanyCode"].ToString();
                }
            }
            else
            {
                x = "";
            }

            return x;
        }
     

        private void clearInputs()
        {
            //CLEAR FIELD
            txtDateTransfer.Text = "";
            txtSearch.Text = "";
            txtDateStart.Text = "";
            txtDateEnd.Text = "";
            txtRemarks.Text = "";

            ViewState["CURRENTCOMPANYCODE"] = "";
            ViewState["EMPLOYEEID"] = "";
        }
        


    

    

      
    
     
       

        protected void lnkProcess_Click(object sender, EventArgs e)
        {

            //  double dAvailableBalance = GET_LEAVE_BALANCE(ViewState["EMPCODE"].ToString(), oSystem.GET_DEFAULT_FISCAL_YEAR());



            if (oSystem.CHECK_VALID_DATE(txtDateTransfer.Text) && oSystem.CHECK_VALID_DATE(txtDateStart.Text) && oSystem.CHECK_VALID_DATE(txtDateTransfer.Text))
            {
                if (ddTransferCompanyTo.SelectedValue != ViewState["CURRENTCOMPANYCODE"].ToString())
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#promptMessage').modal('show');</script>", false);

                }
                else
                {
                    lblErrorMessage.Text = "Selected Company is match in current company.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);

                }
                //else if (ddLeavesList.SelectedIndex > 0)
                //{
                //    oPayroll.INSERT_UPDATE_EMPLOYEE_LEAVES(ViewState["EMPCODE"].ToString(), ddLeavesList.SelectedValue, Convert.ToDateTime(txtDateApplied.Text), Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDouble(txtDays.Text), txtRemarks.Text, oSystem.GET_DEFAULT_FISCAL_YEAR());

                //    //CLEAR FIELD
                //    txtDateApplied.Text = "";
                //    txtDays.Text = "";
                //    txtDateFrom.Text = "";
                //    txtDateTo.Text = "";
                //    txtRemarks.Text = "";


                //    lblSuccessMessage.Text = "Employee Leave successfully process.";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);


                //}
                //else
                ////Prompt a message that Employee don't have balance for leave. But optionally allowed if the user select Yes.
                //{
                //    //lblErrorMessage.Text = "Incentive Leave Balance is zero.";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#promptMessage').modal('show');</script>", false);
                //}


            }
            else
            {
                lblErrorMessage.Text = "Date Not Valid please review.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);

            }

        }

        protected void lnkLeaveHistory_Click(object sender, EventArgs e)
        {
            //DISPLAY ON GRIDVIEW
            
            DataTable dt = oPayroll.GET_EMPLOYEE_LEAVES_HISTORY(ViewState["EMPCODE"].ToString());

            if (dt.Rows.Count > 0)
            {

            DataView dv = dt.DefaultView;
            dv.Sort = "id desc";
            gvLeaveHistory.DataSource = dv;
            gvLeaveHistory.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalShowLeaves').modal('show');</script>", false);

            }

        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "#promptMessage", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#promptMessage').hide();", true);

            oEmployee.INSERT_UPDATE_EMPLOYEE_COMPANY_TRANSFER(ViewState["EMPLOYEEID"].ToString(), ddTransferCompanyTo.SelectedValue, ViewState["CURRENTCOMPANYCODE"].ToString(), Convert.ToDateTime(txtDateTransfer.Text), Convert.ToDateTime(txtDateStart.Text), Convert.ToDateTime(txtDateEnd.Text), txtRemarks.Text);

            lblCurrentCompany.Text = GET_CURRENT_EMPLOYEE_COMPANY(ViewState["EMPLOYEEID"].ToString());

            //Refresh

            gvEmployeeTransferHistory.DataSource = oEmployee.GET_EMPLOYEE_COMPANY_TRANSFER(ViewState["EMPLOYEEID"].ToString());
            gvEmployeeTransferHistory.DataBind();

            //CLEAR FIELD
            clearInputs();

            lblSuccessMessage.Text = "Employee Transfer successfully process.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

          
        }
    }
}