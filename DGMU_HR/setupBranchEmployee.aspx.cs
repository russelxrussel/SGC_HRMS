using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class setupBranchEmployee : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DisplayBranchWageList();
                DisplayWageAreaList();
            }
        }

       

        private void DisplayEmployeeList()
        {
            DataTable dt = oPayroll.GET_BRANCH_EMPLOYEE_LIST_LW_NOT_ASSIGN();
           
            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();
           
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

           lblWageAmount.Text = "Rate Per Day: " +  DisplayWageAmount(_wageCode).ToString();

            DisplayBranchEmployeeList(ddBranchList.SelectedValue.ToString());
        }

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


        private void DisplayBranchEmployeeList(string _branchCode)
        {
            DataTable dt = oPayroll.GET_BRANCH_EMPLOYEE_LIST_ASSIGNED();

            DataView dv = dt.DefaultView;
            dv.RowFilter = "BranchCode='" + _branchCode + "'";
            dv.Sort = "EmployeeName";

           
            gvLinkBranchEmployeeAssigned.DataSource = dt;
            gvLinkBranchEmployeeAssigned.DataBind();
        }



    

      

        protected void ddWageArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            DisplayBranchWageList(ddWageArea.SelectedValue.ToString());
        }

        protected void lnkSetBranch_Click(object sender, EventArgs e)
        {
            if (ddWageArea.SelectedIndex != 0)
            {
                //Display List of Employee
                DisplayEmployeeList();
            }

            else
            {
                lblErrorMessage.Text = "Please Wage Area and Branch";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void lnkEmployeeAssign_Click(object sender, EventArgs e)
        {
            //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;


            if (ddWageArea.SelectedIndex != 0)
            {

                double dWageAmount = DisplayWageAmount(ddWageArea.SelectedValue);

                oPayroll.INSERT_UPDATE_PAYROLL_BRANCH_SETUP(sEmpCode, ddBranchList.SelectedValue, dWageAmount);
                DisplayEmployeeList();
                DisplayBranchEmployeeList(ddBranchList.SelectedValue);

                //ddWageArea_SelectedIndexChanged(sender, e);

                txtSearch.Text = "";

            }
            else
            {
                lblErrorMessage.Text = "Please select Wage Area";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void ddBranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBranchEmployeeList(ddBranchList.SelectedValue);
        }

        protected void lnkBranchEmployeeRemove_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;


            if (ddWageArea.SelectedIndex != 0)
            {

                //double dWageAmount = DisplayWageAmount(ddWageArea.SelectedValue);

                oPayroll.INSERT_UPDATE_PAYROLL_BRANCH_SETUP(sEmpCode, ddBranchList.SelectedValue, 0);


                DisplayEmployeeList();
                DisplayBranchEmployeeList(ddBranchList.SelectedValue);
              
                //ddWageArea_SelectedIndexChanged(sender, e);

                txtSearch.Text = "";

                lblSuccessMessage.Text = "Employee successfully unassigned";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

            }
            else
            {
                lblErrorMessage.Text = "Please select Wage Area";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }
    }
}