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
    public partial class dataEntryEmployeeLeave : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayEmployeeList();
                DisplayLeavesList();

                lblFY.Text = oSystem.GET_DEFAULT_FISCAL_YEAR().ToString();
            }
        }
        
        

        private void DisplayEmployeeList()
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LIST_LW();

            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();

            imgEmployee.ImageUrl = "~/Emp_Pictures/default-avatar.png";
        }

        private void DisplayLeavesList()
        {
            DataTable dt = oPayroll.GET_LEAVES_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "IsRecurring = 1";


            ddLeavesList.DataSource = dv;
            ddLeavesList.DataTextField = dv.Table.Columns["LeaveDescription"].ToString();
            ddLeavesList.DataValueField = dv.Table.Columns["LeaveTypeCode"].ToString();
            ddLeavesList.DataBind();

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


            
            DataView dv = oPayroll.GET_EMPLOYEE_LEAVES_AVAILABLE().DefaultView;
            dv.RowFilter = "EmpCode ='" + ViewState["EMPCODE"].ToString() + "'";
            
            gvEmployeeLeaveAvailability.DataSource = dv;
            gvEmployeeLeaveAvailability.DataBind();

          
        }



    

     

     
        private double GET_LEAVE_BALANCE(string _empCode, int _appliedYear)
        {
            double x = 0;

            DataView dv = oPayroll.GET_EMPLOYEE_LEAVES_AVAILABLE().DefaultView;
            dv.RowFilter = "EmpCode ='" + _empCode + "' and Year_Applied='" + _appliedYear + "'";

            if (dv.Count > 0)
            {
                foreach (DataRowView dvr in dv)
                {
                    x = Convert.ToDouble(dvr["Balance"]);
                }
            }
            else
            {
                x = 0;
            }

            return x;
        }
     

        


    

    

      
    
     
       

        protected void lnkProcess_Click(object sender, EventArgs e)
        {
            


            if (oSystem.CHECK_VALID_DATE(txtDateApplied.Text) && oSystem.CHECK_VALID_DATE(txtDateFrom.Text) && oSystem.CHECK_VALID_DATE(txtDateTo.Text))
            {
                if (ddLeavesList.SelectedIndex == 0 && GET_LEAVE_BALANCE(ViewState["EMPCODE"].ToString(), oSystem.GET_DEFAULT_FISCAL_YEAR()) > 0)
                {
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LEAVES(ViewState["EMPCODE"].ToString(), ddLeavesList.SelectedValue, Convert.ToDateTime(txtDateApplied.Text), Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDouble(txtDays.Text), txtRemarks.Text, oSystem.GET_DEFAULT_FISCAL_YEAR());

                    //CLEAR FIELD
                    txtDateApplied.Text = "";
                    txtDays.Text = "";
                    txtDateFrom.Text = "";
                    txtDateTo.Text = "";
                    txtRemarks.Text = "";

                    //Refresh
                    DataView dv = oPayroll.GET_EMPLOYEE_LEAVES_AVAILABLE().DefaultView;
                    dv.RowFilter = "EmpCode ='" + ViewState["EMPCODE"].ToString() + "'";
                    gvEmployeeLeaveAvailability.DataSource = dv;
                    gvEmployeeLeaveAvailability.DataBind();


                    lblSuccessMessage.Text = "Employee Leave successfully process.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);


                }
                else if (ddLeavesList.SelectedIndex > 0)
                {
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LEAVES(ViewState["EMPCODE"].ToString(), ddLeavesList.SelectedValue, Convert.ToDateTime(txtDateApplied.Text), Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDouble(txtDays.Text), txtRemarks.Text, oSystem.GET_DEFAULT_FISCAL_YEAR());

                    //CLEAR FIELD
                    txtDateApplied.Text = "";
                    txtDays.Text = "";
                    txtDateFrom.Text = "";
                    txtDateTo.Text = "";
                    txtRemarks.Text = "";


                    lblSuccessMessage.Text = "Employee Leave successfully process.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);


                }
                else
                {
                    lblErrorMessage.Text = "Incentive Leave Balance is zero.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                }

      
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
    }
}