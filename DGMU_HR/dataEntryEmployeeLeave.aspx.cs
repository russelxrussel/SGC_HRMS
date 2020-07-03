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
        Employee_Data_C oEmployee = new Employee_Data_C();
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
            DataTable dt = oEmployee.GET_ACTIVE_EMPLOYEE_LIST_LW_LEAVES();

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

        private void displayLeaveHistory()
        {
            //DISPLAY ON GRIDVIEW

            DataTable dt = oPayroll.GET_EMPLOYEE_LEAVES_HISTORY(ViewState["EMPCODE"].ToString());
            DataView dv = dt.DefaultView;
            dv.Sort = "DateFrom desc";
            //if (dt.Rows.Count > 0)
            //{
            //    DataView dv = dt.DefaultView;
            //    dv.Sort = "id desc";
               
            //}

            gvLeaveHistory.DataSource = dv;
            gvLeaveHistory.DataBind();
        }

        
        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;
            Label empName = r.Cells[1].FindControl("lblEmployeeName") as Label;
            //string sEmpName = ;
            lblEmployeeName.Text = "<b>" + empName.Text + "</b>";


            ViewState["EMPCODE"] = sEmpCode;
            
            if (!string.IsNullOrEmpty(oEmployee.GET_EMPLOYEE_PICTURE(sEmpCode)))
            {
                imgEmployee.ImageUrl = oEmployee.GET_EMPLOYEE_PICTURE(sEmpCode);
            }
            else
            {
                imgEmployee.ImageUrl = "~/Uploads/EmployeePictures/default-avatar.png";
            }


            
            DataView dv = oPayroll.GET_EMPLOYEE_LEAVES_AVAILABLE().DefaultView;
            dv.RowFilter = "EmpCode ='" + ViewState["EMPCODE"].ToString() + "'";

            gvEmployeeLeaveAvailability.DataSource = dv;
            gvEmployeeLeaveAvailability.DataBind();


            //This will display all leave application of Employee
            displayLeaveHistory();

            panelEmployeeList.Visible = false;
            panelInput.Visible = true;
            clearInputs();

            //This will control the visibility of Checkbox Include to Payroll
            //Once the Employee has balance of Leave Checkbox Visible is True,else False
            if (GET_LEAVE_BALANCE(ViewState["EMPCODE"].ToString(), oSystem.GET_DEFAULT_FISCAL_YEAR()) > 0) 
                chkIncludeToPayroll.Visible = true;
                else
                chkIncludeToPayroll.Visible = false;

            //Call Toast
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "toastMessage()", true);
           
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
     

        private void clearInputs()
        {
            //CLEAR FIELD
            txtDateApplied.Text = "";
            
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtRemarks.Text = "";
            txtSearch.Text = "";
            chkIncludeToPayroll.Checked = false;
            chkIncludeToPayroll.Checked = false;

        }
        


    

    

      
    
     
       

        protected void lnkProcess_Click(object sender, EventArgs e)
        {

            double dAvailableBalance = GET_LEAVE_BALANCE(ViewState["EMPCODE"].ToString(), oSystem.GET_DEFAULT_FISCAL_YEAR());

            double daysLeave = 0, payableLeave = 0;

        
       
            if (oSystem.CHECK_VALID_DATE(txtDateApplied.Text) && oSystem.CHECK_VALID_DATE(txtDateFrom.Text) && oSystem.CHECK_VALID_DATE(txtDateTo.Text))
            {
                //Add 1 day to handle the same date of dateFrom and dateTo.
                daysLeave = (Convert.ToDateTime(txtDateTo.Text) - Convert.ToDateTime(txtDateFrom.Text)).TotalDays + 1;

                if (chkWithHalfday.Checked) {
                    daysLeave -= .5;
                }

                ///Compute the Payable Leave
                if (daysLeave <= dAvailableBalance)
                {
                    payableLeave = daysLeave;
                }
                else {
                    //Get the difference of daysleave and available balance
                    payableLeave = daysLeave - (daysLeave - dAvailableBalance);
                }

                if (dAvailableBalance > 0)
                {
                    //Process and Store data in table
                    oPayroll.INSERT_UPDATE_EMPLOYEE_LEAVES(ViewState["EMPCODE"].ToString(),
                        ddLeavesList.SelectedValue, Convert.ToDateTime(txtDateApplied.Text), 
                        Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), 
                        daysLeave,payableLeave, txtRemarks.Text, oSystem.GET_DEFAULT_FISCAL_YEAR(),
                        chkWithHalfday.Checked, chkIncludeToPayroll.Checked);

                   
                    ////Refresh
                    //DataView dv = oPayroll.GET_EMPLOYEE_LEAVES_AVAILABLE().DefaultView;
                    //dv.RowFilter = "EmpCode ='" + ViewState["EMPCODE"].ToString() + "'";
                    //gvEmployeeLeaveAvailability.DataSource = dv;
                    //gvEmployeeLeaveAvailability.DataBind();


                    //lblSuccessMessage.Text = "Employee Leave successfully process.";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
                    MessageFeedBack("Leave successfully process.");
                    lnkBack_Click(sender, e);
                    
                }

                //else
                ////Prompt a message that Employee don't have balance for leave. But optionally allowed if the user select Yes.
                //{
                //    //lblErrorMessage.Text = "Incentive Leave Balance is zero.";
                //   // ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#promptMessage').modal('show');</script>", false);
                //}

                

            }
            else
            {
                lblErrorMessage.Text = "Date Not Valid please review.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);

            }
            
        }

     
    

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "#promptMessage", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#promptMessage').hide();", true);

            //oPayroll.INSERT_UPDATE_EMPLOYEE_LEAVES(ViewState["EMPCODE"].ToString(), ddLeavesList.SelectedValue, Convert.ToDateTime(txtDateApplied.Text), Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), 1, txtRemarks.Text, oSystem.GET_DEFAULT_FISCAL_YEAR());

            //CLEAR FIELD
            clearInputs();

            //Refresh
            DataView dv = oPayroll.GET_EMPLOYEE_LEAVES_AVAILABLE().DefaultView;
            dv.RowFilter = "EmpCode ='" + ViewState["EMPCODE"].ToString() + "'";
            gvEmployeeLeaveAvailability.DataSource = dv;
            gvEmployeeLeaveAvailability.DataBind();

         
            lblSuccessMessage.Text = "Employee Leave successfully process.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

          
        }

        
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            //MessageFeedBack("texting");
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "toastMessage('DGMU', 'Sorry error detected')", true);

            clearInputs();

            panelInput.Visible = false;
            panelEmployeeList.Visible = true;


            //Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Please Enter Name', 'Error')", true);
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastMessage('DGMU', 'Sorry error detected')", true);

        }

        protected void lnkRemoveLeave_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow gvr = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            int id =  Convert.ToInt16(gvr.Cells[0].Text);

            oPayroll.REMOVE_UPDATE_EMPLOYEE_LEAVES(id, ViewState["EMPCODE"].ToString(), oSystem.GET_DEFAULT_FISCAL_YEAR());

            MessageFeedBack("Leave successfully cancelled.");
        }

        protected void gvLeaveHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow r in gvLeaveHistory.Rows)
            {
                try
                {
                    string sEmpCode = r.Cells[0].Text;
                    LinkButton lnkRemoveLeave = r.FindControl("lnkRemoveLeave") as LinkButton;
                    bool bIsPayrollProcess = Convert.ToBoolean(r.Cells[6].Text);
                    bool bIsCancel = Convert.ToBoolean(r.Cells[7].Text);

                    if (bIsPayrollProcess)
                    {
                        lnkRemoveLeave.Visible = false;
                    }
                    else if (bIsCancel)
                    {
                        r.BackColor = System.Drawing.Color.OrangeRed;
                        lnkRemoveLeave.Visible = false;
                    }
                    else {
                        lnkRemoveLeave.Visible = true;
                    }

                    //if (bIsCancel)
                    //    r.BackColor = System.Drawing.Color.DarkGray;


                }
                catch { }
            }
        

    }


        private void ToastMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            //sb.Append("$(function () {");
            //sb2.Append("alert('Hello');");
            //sb.Append(count.ToString());
            //sb.Append(Mensahe + "');");
            //sb.Append("</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg","<scipt>alert('Hi');</script>", true);
            //string message = "alert('Hello! Mudassar.')";
            sb.Append("ToastAlertMessage();");
            sb.Append("function ToastAlertMessage(){");
            sb.Append(" toastr[\"warning\"](\"Toast Message\", \"Try lang\")");
            sb.Append(" toastr.options = { ");
            sb.Append(" \"closeButton\": true, ");
            sb.Append(" \"newestOnTop\": false, ");
            sb.Append(" \"progressBar\": true, ");
            sb.Append(" \"debug\": false,\"positionClass\": \"toast-top-right\", \"preventDuplicates\": true, ");
            sb.Append(" \"onclick\": null, ");
            sb.Append(" \"showDuration\": \"300\", ");
            sb.Append(" \"hideDuration\": \"1000\", ");
            sb.Append(" \"timeOut\": \"2000\", ");
            sb.Append(" \"extendedTimeOut\": \"1000\", ");
            sb.Append(" \"showEasing\": \"swing\", ");
            sb.Append(" \"hideEasing\": \"linear\", ");
            sb.Append(" \"showMethod\": \"fadeIn\", ");
            sb.Append(" \"hideMethod\": \"fadeOut\" ");
            sb.Append("   } } </script>");

          
          
             ScriptManager.RegisterStartupScript(this, this.GetType(), "toast", sb.ToString(), true);
        }

        private void MessageFeedBack(string yourMessage) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();


            sb.Append("alert('");
            sb.Append(yourMessage);
            sb.Append("');");
            
            //string message = "alert('Hello! Mudassar.')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", sb.ToString(), true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MessageNow", sb.ToString(), true);
        }
    }
}