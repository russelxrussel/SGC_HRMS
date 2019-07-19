using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace DGMU_HR
{
    
    public partial class EmpPaySetup : System.Web.UI.Page
    {
        Employee_Data_C oEmployeeData = new Employee_Data_C();
        Utility_C oUtility = new Utility_C();
        SystemX oSystem = new SystemX();
        Payroll_C oPayroll = new Payroll_C();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
               
                DISPLAY_BRANCH_LIST();
                PAYROLL_GROUP_LIST();

                DataTable dt = oPayroll.GET_EMPLOYEE_LIST_LW();
                DataView dv = dt.DefaultView;
                dv.RowFilter = "Status='" + "ACTIVE" + "'";

                gvEmployeeList.DataSource = dv;
                gvEmployeeList.DataBind();

                imgEmployeePicture.ImageUrl = "/Emp_Pictures/default-avatar.png";
            }
           
        }


        #region "PRE-POPULATED"
       
        private void DISPLAY_BRANCH_LIST()
        {
            DataTable dt = oPayroll.GET_WAGE_BRANCH_LIST();

            DataView dv = dt.DefaultView;
            dv.Sort = "BranchName ASC";
            ddBranchList.DataSource = dv;
            ddBranchList.DataTextField = dv.Table.Columns["BranchName"].ToString();
            ddBranchList.DataValueField = dv.Table.Columns["BranchCode"].ToString();
            ddBranchList.DataBind();

            //ddBranchList.Items.Insert(0, new ListItem("--Select Branch--"));


        }

        private void PAYROLL_GROUP_LIST()
        {
            DataTable dt = oPayroll.GET_PAYROLL_GROUP_LIST();
            
            ddPayrollGroup.DataSource = dt;
            ddPayrollGroup.DataTextField = dt.Columns["PayrollGroupName"].ToString();
            ddPayrollGroup.DataValueField = dt.Columns["PayrollGroupCode"].ToString();
            ddPayrollGroup.DataBind();

            ddPayrollGroup.Items.Insert(0, new ListItem("--Select Payroll Group--"));

        }


        private void GET_WAGE_AMOUNT(string _branchCode)
        {
            DataTable dt = oPayroll.GET_WAGE_BRANCH_LIST();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "BranchCode ='" + _branchCode + "'";

            if (dv.Count > 0)
            { 
            foreach (DataRowView drv in dv)
                {
                    txtBasicRatePerDay.Text = drv["WageAmount"].ToString();
                }
            }
        }




        #endregion

        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

          
                //foreach (GridViewRow r in gvEmployeeList.Rows)
                //{
                //try
                //{
                  

                   
                //        Image imgEmployee = r.FindControl("imgEmployee") as Image;
                //        string sEmployeeID = r.Cells[1].Text;
              


                //    if (File.Exists(Server.MapPath("~/Emp_Pictures/" + sEmployeeID + ".jpg")))
                //    {
                //        imgEmployee.ImageUrl = "~/Emp_Pictures/" + sEmployeeID + ".jpg";
                //    }
                //    else
                //    {
                //        imgEmployee.ImageUrl = "~/Emp_Pictures/default-avatar.png";
                //    }


                //}
                //catch { }
                //}
            
        }

 
  
  
        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          

            if (e.CommandName == "PayrollSetup")
            {
                GridViewRow row = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow);

                DataTable dt = oPayroll.GET_EMPLOYEE_SALARY();

                DataView dv = dt.DefaultView;
                dv.RowFilter = "EmployeeID ='" + row.Cells[0].Text  + "'";

                if (dv.Count > 0)
                {
                    DataRowView dvr = dv[0];

                    lblEmpCode.Text = dvr.Row["EmployeeID"].ToString();
                    lblEmpName.Text = dvr.Row["EmployeeName"].ToString();

                    if (!string.IsNullOrEmpty(dvr.Row["PayrollGroupCode"].ToString()))
                    {
                        ddPayrollGroup.SelectedValue = dvr.Row["PayrollGroupCode"].ToString();
                    }

                    //Identify Salary Type and implement condition in corresponding selection.
                    if (ddPayrollGroup.SelectedValue == "BP")
                    {
                        chkDebitMemo.Visible = true;
                        chkManualSalary.Checked = false;
                        chkManualSalary.Visible = false;
                    }
                    else {
                        chkManualSalary.Visible = true;
                        chkDebitMemo.Visible = false;
                        chkDebitMemo.Checked = false;
                    }

                    if (!string.IsNullOrEmpty(dvr.Row["BranchCode"].ToString()))
                    {
                        ddBranchList.SelectedValue = dvr.Row["BranchCode"].ToString();
                        panelBranch.Visible = true;
                    }
                    else
                    {
                        panelBranch.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(dvr.Row["IsSenior"].ToString()))
                    { 
                        chkIsSenior.Checked = (bool)dvr.Row["IsSenior"];
                    }

                    if (!string.IsNullOrEmpty(dvr.Row["IsBranchWife"].ToString()))
                    {
                        chkIsBranchWife.Checked = (bool)dvr.Row["IsBranchWife"];
                    }

                    if (!string.IsNullOrEmpty(dvr.Row["IsDMPay"].ToString()))
                    {
                        chkDebitMemo.Checked = (bool)dvr.Row["IsDMPay"];
                    }

                    if (!string.IsNullOrEmpty(dvr.Row["IsManualSalary"].ToString()))
                    {
                        chkManualSalary.Checked = (bool)dvr.Row["IsManualSalary"];
                    }

                    txtBasicRatePerDay.Text = dvr.Row["BasicRate"].ToString();
                    txtActualRatePerDay.Text = dvr.Row["ActualRate"].ToString();


               
                    if (File.Exists(Server.MapPath("~/Emp_Pictures/" + lblEmpCode.Text + ".jpg")))
                    {
                        imgEmployeePicture.ImageUrl = "~/Emp_Pictures/" + lblEmpCode.Text + ".jpg";
                    }
                    else{
                        imgEmployeePicture.ImageUrl = "~/Emp_Pictures/default-avatar.png";
                    }
                   
                   }
           
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalPayrollSetup').modal('show');</script>", false);
            }





        }

        protected void ddBranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            GET_WAGE_AMOUNT(ddBranchList.SelectedValue.ToString());

        }

        protected void ddPayrollGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddPayrollGroup.SelectedIndex != 0)
            {
                if (ddPayrollGroup.SelectedIndex == 1)
                {
                    panelBranch.Visible = true;
                    txtBasicRatePerDay.Enabled = false;
                    chkManualSalary.Visible = false;
                    chkDebitMemo.Visible = true;
                }
                else
                {
                    panelBranch.Visible = false;
                    txtBasicRatePerDay.Enabled = true;
                    chkManualSalary.Visible = true;
                    chkDebitMemo.Visible = false;
                }
            }
            else
            {
                panelBranch.Visible = false;
            }
          
        }

        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            //Check input
            if (ddPayrollGroup.SelectedIndex != 0 && !string.IsNullOrEmpty(txtBasicRatePerDay.Text))
            {
                if (string.IsNullOrEmpty(txtActualRatePerDay.Text))
                {
                    txtActualRatePerDay.Text = "0";
                }

                oPayroll.INSERT_UPDATE_PAYROLL_SETUP(lblEmpCode.Text, ddPayrollGroup.SelectedValue, ddBranchList.SelectedValue, Convert.ToDouble(txtBasicRatePerDay.Text), Convert.ToDouble(txtActualRatePerDay.Text), chkIsSenior.Checked,chkIsBranchWife.Checked,chkDebitMemo.Checked,chkManualSalary.Checked, true);

          
                Response.Redirect(Request.RawUrl);

            }
            else
            {
                lblErrorMessage.Text = "Payroll Group and basic Rate required";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }
    }
}