using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class setupPayrollPeriod : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayPayrollPeriodList();
                // DisplayPayrollPeriodToday();
            }
        }

        protected void lnkCreateItem_Click(object sender, EventArgs e)
        {

            lblActionTitle.Text = "Create Payroll Period";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#ItemContainer').modal('show');</script>", false);
        }

        private void DisplayPayrollPeriodList()
        {
            DataTable dt = oPayroll.GET_PAYROLL_PERIOD_LIST();

            gvPayrollPeriod.DataSource = dt;
            gvPayrollPeriod.DataBind();

        }





        protected void btnCreateUpdate_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text))
            {
                //Check if start date already exist between payroll period
                if (!oPayroll.CHECK_PAYROLL_PERIOD_EXIST(Convert.ToDateTime(txtStartDate.Text)))
                {
                    oPayroll.INSERT_PAYROLL_PERIOD(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblErrorMessage.Text = "Payroll Date Exists!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                }

            }
            else
            {
                lblErrorMessage.Text = "Input required.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }


        }



        protected void lnkDefault_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            int iPP = Convert.ToInt32(r.Cells[0].Text);
            string ppDes = r.Cells[1].Text;

            oPayroll.UPDATE_PAYROLL_PERIOD_DEFAULT(iPP);

            //lblSuccessMessage.Text = ppDes + " successfully set as default payroll period.";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);

            DisplayPayrollPeriodList();

        }

        private void GetPayrollPeriodDefault()
        {
            DataTable dt = oPayroll.GET_PAYROLL_PERIOD_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "IsActive = 1";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    ViewState["PPID"] = drv["PPID"];
                }
            }

        }

        protected void gvPayrollPeriod_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GetPayrollPeriodDefault();
            
            foreach (GridViewRow r in gvPayrollPeriod.Rows)
            {
                int iPP = Convert.ToInt32(r.Cells[0].Text);
               
                Image imgDefault = r.FindControl("imgDefault") as Image;
                LinkButton lnkDefault = r.FindControl("lnkDefault") as LinkButton;

                if (iPP == Convert.ToInt32(ViewState["PPID"]))
                {
                    lnkDefault.Visible = false;
                    imgDefault.Visible = true;
                    r.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    lnkDefault.Visible = true;
                    imgDefault.Visible = false;
                }
              
            }
        }
    }
}