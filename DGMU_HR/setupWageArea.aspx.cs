using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class setupWageArea : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayStorageAreaList();
            }
        }

        protected void lnkCreateItem_Click(object sender, EventArgs e)
        {
            
            txtWageCode.Enabled = true;
            txtWageCode.Text = "";
            txtWageArea.Text = "";
            txtWageAmount.Text = "0";
            txtRegularQuota.Text = "0";
            txtSrQuota.Text = "0";
            txtBranchWifeQuota.Text = "0";

            lblActionTitle.Text = "Create Wage Area";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#ItemContainer').modal('show');</script>", false);
        }

        private void DisplayStorageAreaList()
        {
            DataTable dt = oPayroll.GET_WAGE_AREA_LIST();

            gvStorageArea.DataSource = dt;
            gvStorageArea.DataBind();
           
        }


        protected void btnCreateUpdate_Click(object sender, EventArgs e)
        {

            //

            if (!string.IsNullOrEmpty(txtWageCode.Text) && !string.IsNullOrEmpty(txtWageArea.Text) &&
                !string.IsNullOrEmpty(txtWageAmount.Text) && Convert.ToDouble(txtWageAmount.Text) != 0)
            {

                double srQuota=0, regQuota=0, wbQuota=0, sbQuota;

                if (!string.IsNullOrEmpty(txtSrQuota.Text))
                {
                    srQuota = Convert.ToDouble(txtSrQuota.Text);
                }
                else { srQuota = 0; }

                if (!string.IsNullOrEmpty(txtRegularQuota.Text))
                { regQuota = Convert.ToDouble(txtRegularQuota.Text); }
                else { regQuota = 0; }

                if (!string.IsNullOrEmpty(txtBranchWifeQuota.Text))
                { wbQuota = Convert.ToDouble(txtBranchWifeQuota.Text); }
                else { wbQuota = 0; }

                if (!string.IsNullOrEmpty(txtBranchSingleQuota.Text))
                { sbQuota = Convert.ToDouble(txtBranchSingleQuota.Text); }
                else { sbQuota = 0; }

                double dWageAmount = Convert.ToDouble(txtWageAmount.Text);

                oPayroll.INSERT_UPDATE_WAGE_AREA_SETUP(txtWageCode.Text, txtWageArea.Text, dWageAmount, txtSupervisorName.Text.ToUpper(),
                                                       srQuota, regQuota, wbQuota, sbQuota);

                Response.Redirect(Request.RawUrl);
            }

            else
            {
                lblErrorMessage.Text = "Input required.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }

           
        }

        

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sWageCode = r.Cells[1].Text;

            DataTable dt = oPayroll.GET_WAGE_AREA_LIST();

            DataRow[] dr;
            dr = dt.Select("WageCode = '" + sWageCode + "'");

            if (dr.Length > 0)
            {
                //Will display the selected item info
                foreach (DataRow row in dr)
                {
                    txtWageCode.Text = row["WageCode"].ToString();
                    txtWageArea.Text = row["WageArea"].ToString();
                    txtWageAmount.Text = row["WageAmount"].ToString();
                    txtSupervisorName.Text = row["Supervisor"].ToString();
                    txtSrQuota.Text = row["SrQuota"].ToString();
                    txtRegularQuota.Text = row["RegQuota"].ToString();
                    txtBranchWifeQuota.Text = row["WBQuota"].ToString();
                    txtBranchSingleQuota.Text = row["SBQuota"].ToString();
                    txtWageArea.Focus();
                    txtWageCode.Enabled = false;

                }

            }

            btnCreateUpdate.Text = "Update";



            lblActionTitle.Text = "Modify Wage Supervisor Area - " + sWageCode;

            //Will use as reference to update item.


            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#ItemContainer').modal('show');</script>", false);

        }
    }
}