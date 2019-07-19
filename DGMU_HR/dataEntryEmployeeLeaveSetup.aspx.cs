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
    public partial class dataEntryEmployeeLeaveSetup : System.Web.UI.Page
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
            DataTable dt = oPayroll.GET_EMPLOYEE_LIST_LEAVE_SETUP();

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

                DataRowView dr = (DataRowView)e.Row.DataItem;
                //string storageCode = dr["storageCode"].ToString();
                DateTime dateHired = Convert.ToDateTime(dr["Date_Hired"]);

                Label lblTenure = (e.Row.FindControl("lblTenure") as Label);

                lblTenure.Text = oPayroll.GET_EMPLOYEE_YEARS_MONTHS(dateHired).ToString();
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string empCode = row.Cells[0].Text;

                    TextBox txtCredit = (row.FindControl("txtCredit") as TextBox);

                    double creditLeave = 0;

                    if (txtCredit.Text == "")
                    {
                        creditLeave = 0;
                    }
                    else
                    {
                        creditLeave = Convert.ToDouble(txtCredit.Text);
                    }


                    if (creditLeave > 0)
                    {
                        //oTransaction.UPDATE_BEGINNING_STOCK(ddItemList.SelectedValue, branchCode, begStock);
                        oPayroll.INSERT_UPDATE_EMPLOYEE_LEAVES_SETUP(empCode,oSystem.GET_DEFAULT_FISCAL_YEAR(), creditLeave);
                    }

                    //lnkViewStock_Click(sender, e);

                    //lblMessageSuccess.Text = "Branches beginning successfully updated.";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                }
            }
        }
    }
    }