using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class setupPayrollYear : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayPayrollYearList();
               
            }
        }

        protected void lnkCreateItem_Click(object sender, EventArgs e)
        {

            lblActionTitle.Text = "Create Payroll Year";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#ItemContainer').modal('show');</script>", false);
        }

        private void DisplayPayrollYearList()
        {
            DataTable dt = oSystem.GET_FISCAL_YEAR_LIST();

            gvPayrollYear.DataSource = dt;
            gvPayrollYear.DataBind();

        }





        protected void btnCreateUpdate_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtYear.Text))
            {
                //Check if start date already exist between payroll period
                if (!CheckExistYear(Convert.ToInt32(txtYear.Text)))
                {
                    // oPayroll.INSERT_PAYROLL_PERIOD(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));
                    oSystem.INSERT_PAYROLL_YEAR(Convert.ToInt32(txtYear.Text));
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblErrorMessage.Text = "Payroll Year Exists!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                }

            }
            else
            {
                lblErrorMessage.Text = "Input required.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }


        }



        private bool CheckExistYear(int _year)
        {
            bool x = false;

            DataView dv = oSystem.GET_FISCAL_YEAR_LIST().DefaultView;
            dv.RowFilter = "Year ='" + _year + "'";

            if (dv.Count > 0)
            {
                x = true;
            }
            else { x = false; }



            return x;
        }

        protected void lnkDefault_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            int iPY = Convert.ToInt32(r.Cells[0].Text);
            string ppDes = r.Cells[1].Text;

            oSystem.UPDATE_PAYROLL_YEAR_DEFAULT(iPY);

         
            DisplayPayrollYearList();

        }

        private void GetPayrollYearDefault()
        {
            DataTable dt = oSystem.GET_FISCAL_YEAR_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "fStatus = 1";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    ViewState["PYID"] = drv["ID"];
                }
            }

        }

        protected void gvPayrollYear_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GetPayrollYearDefault();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView dr = (DataRowView)e.Row.DataItem;
                //string storageCode = dr["storageCode"].ToString();
                //DateTime dateHired = Convert.ToDateTime(dr["Date_Hired"]);
                int iPY = Convert.ToInt32(dr["ID"]);

                //Label lblTenure = (e.Row.FindControl("lblTenure") as Label);

                Image imgDefault = e.Row.FindControl("imgDefault") as Image;
                LinkButton lnkDefault = e.Row.FindControl("lnkDefault") as LinkButton;

                if (iPY == Convert.ToUInt32(ViewState["PYID"]))
                {
                    lnkDefault.Visible = false;
                    imgDefault.Visible = true;
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    lnkDefault.Visible = true;
                    imgDefault.Visible = false;
                }

                //lblTenure.Text = oPayroll.GET_EMPLOYEE_YEARS_MONTHS(dateHired).ToString();
            }


            //foreach (GridViewRow r in gvPayrollYear.Rows)
            //{
            //    int iPY = Convert.ToInt32(r.Cells[0].Text);
               
            //    Image imgDefault = r.FindControl("imgDefault") as Image;
            //    LinkButton lnkDefault = r.FindControl("lnkDefault") as LinkButton;

            //    if (iPY == oSystem.GET_DEFAULT_FISCAL_YEAR())
            //    {
            //        lnkDefault.Visible = false;
            //        imgDefault.Visible = true;
            //        r.BackColor = System.Drawing.Color.LightBlue;
            //    }
            //    else
            //    {
            //        lnkDefault.Visible = true;
            //        imgDefault.Visible = false;
            //    }
              
            //}
        }
    }
}