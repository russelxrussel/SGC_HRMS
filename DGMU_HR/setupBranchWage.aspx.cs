using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class setupBranchWage : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        Utility_C oUtility = new Utility_C();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayBranchWageList();
                DisplayWageAreaList();
            }
        }

       

        private void DisplayBranchWageList()
        {
            DataTable dt = oPayroll.GET_BRANCH_WAGE_LIST_NOT_ASSIGN();
            DataView dv = dt.DefaultView;
           
            dv.Sort = "BranchName";
        
            gvBranchList.DataSource = dv;
            gvBranchList.DataBind();
           
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




    

        protected void btnLinkedBranch_Click(object sender, EventArgs e)
        {
            //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sBranchCode = r.Cells[0].Text;

           
            if (ddWageArea.SelectedIndex != 0)
            {


                oPayroll.INSERT_UPDATE_BRANCH_WAGE_SETUP(sBranchCode, ddWageArea.SelectedValue.ToString());
                DisplayBranchWageList();

                ddWageArea_SelectedIndexChanged(sender, e);

                txtSearch.Text = "";

            }
            else
            {
                lblErrorMessage.Text = "Please select Wage Area";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
          
        }

        protected void ddWageArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = oPayroll.GET_BRANCH_WAGE_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "WageCode='" + ddWageArea.SelectedValue.ToString() + "'";
            dv.Sort = "BranchName";

            gvLinkBranch.DataSource = dv;
            gvLinkBranch.DataBind();
        }

        protected void lnkNewBranch_Click(object sender, EventArgs e)
        {
            lblActionTitle.Text = "Create New Branch";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#ItemContainer').modal('show');</script>", false);
        }

        protected void btnCreateUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBranchCode.Text) && !string.IsNullOrEmpty(txtBranchName.Text))
            {
                oUtility.INSERT_BRANCH(txtBranchCode.Text.ToUpper(), txtBranchName.Text.ToUpper());

                Response.Redirect(Request.RawUrl);
            }
           
        }
    }
}