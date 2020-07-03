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
    public partial class dataEntryGovtDues : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DisplayEmployeeList();

                lblFY.Text = oSystem.GET_DEFAULT_FISCAL_YEAR().ToString();

                //Will display List of the Months
                DisplayMonthsList();

                //Will display List of the Companies
                DisplayCompaniesList();
            }

        }


        //Local Function

        #region "Local Functions"

        
        //This will get the list of Months
        private void DisplayMonthsList()
        {
            DataTable dt = oSystem.GET_MONTHS_LIST();

            ddMonths.DataSource = dt;
            ddMonths.DataTextField = dt.Columns["monthName"].ToString();
            ddMonths.DataValueField = dt.Columns["monthID"].ToString();
            ddMonths.DataBind();
        }

        //This will get the list of Companies
        private void DisplayCompaniesList()
        {
            DataTable dt = oSystem.GET_COMPANY_LIST();

            ddCompanies.DataSource = dt;
            ddCompanies.DataTextField = dt.Columns["companyName"].ToString();
            ddCompanies.DataValueField = dt.Columns["companyCode"].ToString();
            ddCompanies.DataBind();
        }


        #endregion


        private void DisplayEmployeeList(string _companyCode, int _month)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_LIST_MANUAL_ENTRY_GOVTDUES(_month);
            DataView dv = dt.DefaultView;

            dv.RowFilter = "CompanyCode ='" + _companyCode + "'";
            
            gvEmployeeList.DataSource = dv;
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
                //Label lblEmployeeCode = ()
               TextBox txtDaysPresent = (e.Row.FindControl("txtDaysPresent") as TextBox);
                Label lblSSSPay = (e.Row.FindControl("lblSSSPay") as Label);
                Label lblPHPay = (e.Row.FindControl("lblPHPay") as Label);
                Label lblHDMFPay = (e.Row.FindControl("lblHDMFPay") as Label);
                //lblTenure.Text = oPayroll.GET_EMPLOYEE_YEARS_MONTHS(dateHired).ToString();
                //  ddTotalWorksInYear.SelectedValue = oPayroll.GET_EMPLOYEE_13TH_TOTALWORKINYEAR(e.Row.Cells[0].Text, oSystem.GET_DEFAULT_FISCAL_YEAR()).ToString();
                txtDaysPresent.Text = oPayroll.GET_EMPLOYEE_GOVTDUES_DAYSPRESENT(e.Row.Cells[0].Text, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToInt16(ddMonths.SelectedValue)).ToString();
                lblSSSPay.Text = oPayroll.GET_EMPLOYEE_MANUAL_GOVTDUES_SSS(e.Row.Cells[0].Text, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToInt16(ddMonths.SelectedValue)).ToString();
                lblPHPay.Text = oPayroll.GET_EMPLOYEE_MANUAL_GOVTDUES_PH(e.Row.Cells[0].Text, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToInt16(ddMonths.SelectedValue)).ToString();
                lblHDMFPay.Text = oPayroll.GET_EMPLOYEE_MANUAL_GOVTDUES_HDMF(e.Row.Cells[0].Text, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToInt16(ddMonths.SelectedValue)).ToString();
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string empCode = row.Cells[0].Text;
                    TextBox txtDaysPresent = (row.FindControl("txtDaysPresent") as TextBox);
                    double basicRate = Convert.ToDouble(row.Cells[3].Text);
                    //double totalYearBasicPay = 0, totalAbsences = 0;

                    //if (txtTotalYearBasicPay.Text == "" || string.IsNullOrEmpty(txtTotalYearBasicPay.Text))
                    //{
                    //    totalYearBasicPay = 0;
                    //    totalAbsences = 0;

                    //}
                    //else
                    //{
                    //    totalYearBasicPay = Convert.ToDouble(txtTotalYearBasicPay.Text);
                    //    totalAbsences = Convert.ToDouble(txtTotalAbsences.Text);
                    //}


                    if (basicRate > 0)
                    {
                        //oTransaction.UPDATE_BEGINNING_STOCK(ddItemList.SelectedValue, branchCode, begStock);
                        // oPayroll.INSERT_UPDATE_MANUAL_ENTRY_13TH_MONTH(empCode, oSystem.GET_DEFAULT_FISCAL_YEAR(), Convert.ToDouble(ddTotalWorksInYear.SelectedValue), totalYearBasicPay, totalAbsences);
                        //  DisplayEmployeeList();
                        oPayroll.INSERT_UPDATE_MANUAL_GOVTDUES(empCode, basicRate, Convert.ToDouble(txtDaysPresent.Text), Convert.ToInt16(oSystem.GET_DEFAULT_FISCAL_YEAR()), Convert.ToInt16(ddMonths.SelectedValue));
                        lblSuccessMessage.Text = "Government Dues Batch process successful. Please click refresh data to display changes";
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
            double basicRate = Convert.ToDouble(row.Cells[3].Text);
            // (row.Cells[0].Text);
            if (e.CommandName == "SAVE")
            {
                //TextBox txtTotalYearBasicPay = (row.FindControl("txtTotalYearBasicPay") as TextBox);
                //TextBox txtTotalAbsences = (row.FindControl("txtTotalAbsences") as TextBox);
                //DropDownList ddTotalWorksInYear = (row.FindControl("ddTotalWorksInYear") as DropDownList);
                TextBox txtDaysPresent = (row.FindControl("txtDaysPresent") as TextBox);

                if (basicRate > 0)
                {
                    //oTransaction.UPDATE_BEGINNING_STOCK(ddItemList.SelectedValue, branchCode, begStock);
                    oPayroll.INSERT_UPDATE_MANUAL_GOVTDUES(empCode, basicRate, Convert.ToDouble(txtDaysPresent.Text), Convert.ToInt16(oSystem.GET_DEFAULT_FISCAL_YEAR()), Convert.ToInt16(ddMonths.SelectedValue));
                    //DisplayEmployeeList();

                    lblSuccessMessage.Text = empName + " Gov't Dues successfully process. Please click refresh data to display changes";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
                }
                else {
                    lblErrorMessage.Text = empName + " Cannot process, No Basic Rate yet.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
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

        protected void lnkSet_Click(object sender, EventArgs e)
        {
            DisplayEmployeeList(ddCompanies.SelectedValue, Convert.ToInt16(ddMonths.SelectedValue));
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