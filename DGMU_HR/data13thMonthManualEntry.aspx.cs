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
    public partial class data13thMonthManualEntry : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayEmployeeList();

                lblFY.Text = oSystem.GET_DEFAULT_FISCAL_YEAR().ToString();
            }

        }


       
        private void DisplayEmployeeList()
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LIST_MANUAL_ENTRY_13TH_MONTH();

            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();
            
        }
        
        protected void lnkPayment_Click(object sender, EventArgs e)
        {
            //Save Loan Payment List
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            ViewState["LOANSN"] = r.Cells[1].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#modalPaymentEntry').modal('show');</script>", false);
        }

       

      

        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                // DataRowView dr = (DataRowView)e.Row.DataItem;
                //string storageCode = dr["storageCode"].ToString();
                //Label lblEmployeeCode = (e.Row.Cells[0].Text)
                DropDownList ddTotalWorksInYear = (e.Row.FindControl("ddTotalWorksInYear") as DropDownList);
                //  Label lblTenure = (e.Row.FindControl("lblTenure") as Label);

                //lblTenure.Text = oPayroll.GET_EMPLOYEE_YEARS_MONTHS(dateHired).ToString();
                ddTotalWorksInYear.SelectedValue = oPayroll.GET_EMPLOYEE_13TH_TOTALWORKINYEAR(e.Row.Cells[0].Text, oSystem.GET_DEFAULT_FISCAL_YEAR()).ToString();
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string empCode = row.Cells[0].Text;

                    TextBox txtTotalYearBasicPay = (row.FindControl("txtTotalYearBasicPay") as TextBox);
                    TextBox txtTotalAbsences = (row.FindControl("txtTotalAbsences") as TextBox);
                    DropDownList ddTotalWorksInYear = (row.FindControl("ddTotalWorksInYear") as DropDownList);

                    double totalYearBasicPay = 0, totalAbsences = 0;

                    if (txtTotalYearBasicPay.Text == "" || string.IsNullOrEmpty(txtTotalYearBasicPay.Text))
                    {
                        totalYearBasicPay = 0;
                        totalAbsences = 0;

                    }
                    else
                     {
                        totalYearBasicPay = Convert.ToDouble(txtTotalYearBasicPay.Text);
                        totalAbsences = Convert.ToDouble(txtTotalAbsences.Text);
                    }


                    if (totalYearBasicPay > 0)
                    {
                        //oTransaction.UPDATE_BEGINNING_STOCK(ddItemList.SelectedValue, branchCode, begStock);
                        oPayroll.INSERT_UPDATE_MANUAL_ENTRY_13TH_MONTH(empCode, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToDouble(ddTotalWorksInYear.SelectedValue), totalYearBasicPay, totalAbsences);
                        //  DisplayEmployeeList();
                        lblSuccessMessage.Text = "Batch 13th Month Entry successfully process. Please click refresh data to display changes";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                    }
                   

                }
            }
        }



        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GridViewRow row = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow);
            string empCode = row.Cells[0].Text;
            string empName = row.Cells[1].Text;

            // (row.Cells[0].Text);
            if (e.CommandName == "SAVE")
            { 
            TextBox txtTotalYearBasicPay = (row.FindControl("txtTotalYearBasicPay") as TextBox);
            TextBox txtTotalAbsences = (row.FindControl("txtTotalAbsences") as TextBox);
            DropDownList ddTotalWorksInYear = (row.FindControl("ddTotalWorksInYear") as DropDownList);

            double totalYearBasicPay = 0, totalAbsences = 0;

            if (txtTotalYearBasicPay.Text == "" || string.IsNullOrEmpty(txtTotalYearBasicPay.Text))
            {
                totalYearBasicPay = 0;
                totalAbsences = 0;

            }
            else
            {
                totalYearBasicPay = Convert.ToDouble(txtTotalYearBasicPay.Text);
                totalAbsences = Convert.ToDouble(txtTotalAbsences.Text);
            }


            if (totalYearBasicPay > 0)
            {
                //oTransaction.UPDATE_BEGINNING_STOCK(ddItemList.SelectedValue, branchCode, begStock);
                oPayroll.INSERT_UPDATE_MANUAL_ENTRY_13TH_MONTH(empCode, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToDouble(ddTotalWorksInYear.SelectedValue), totalYearBasicPay, totalAbsences);
                //DisplayEmployeeList();

                lblSuccessMessage.Text = empName + " 13th Month successfully process. Please click refresh data to display changes";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
            }
        }
            if (e.CommandName == "REMOVE")
            {

               
                oPayroll.REMOVE_EMPLOYEE_13TH_MONTH(empCode, oSystem.GET_DEFAULT_FISCAL_YEAR());

                lblSuccessMessage.Text = empName + " 13th Month was successfully removed. Please click refresh data to display changes";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);


            }

        }

        protected void lnkRefresh_Click(object sender, EventArgs e)
        {
            //DisplayEmployeeList();
            Response.Redirect(Request.RawUrl);
        }

        //protected void lnkRemove13thMonth_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in gvEmployeeList.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            string empCode = row.Cells[0].Text;
        //            string empName = row.Cells[1].Text;


        //            oPayroll.REMOVE_EMPLOYEE_13TH_MONTH(empCode, oSystem.GET_DEFAULT_FISCAL_YEAR());

        //            lblSuccessMessage.Text = empName + " 13th Month was successfully removed. Please click refresh data to display changes";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

        //        }
        //    }

              
        //}
    }
    }