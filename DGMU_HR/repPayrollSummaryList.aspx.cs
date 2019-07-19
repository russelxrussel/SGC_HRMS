using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;


namespace DGMU_HR
{
    public partial class repPayrollSummaryList : System.Web.UI.Page
    {
        ReportDocument oReportDocument = new ReportDocument();
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Init(object sender, EventArgs e)
        {
            
            displayReport();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayPPeriod();
                
            }

            displayReport();

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {

            //Cleaning Report Documents
            oReportDocument.Close();

        }

        private void displayPPeriod()
        {
            DataTable dt = oPayroll.GET_PAYROLL_PERIOD_LIST();
            DataView dv = dt.DefaultView;

            dv.Sort = "IsActive desc";
            
            ddPayrollPeriodList.DataSource = dv;
            ddPayrollPeriodList.DataTextField = dv.Table.Columns["Description"].ToString();
            ddPayrollPeriodList.DataValueField = dv.Table.Columns["PPID"].ToString();
            ddPayrollPeriodList.DataBind();


        }



        private void displayReport()
        {


            if (optWithATM.Checked)
            {
                oReportDocument.Load(Server.MapPath("~/Reports/Summary_Payroll_Billing_Company_With_ATM.rpt"));
            }
            else if (optNonATM.Checked)
            {
                oReportDocument.Load(Server.MapPath("~/Reports/Summary_Payroll_Billing_Company_Non_ATM.rpt"));
            }
            else
            { 
                oReportDocument.Load(Server.MapPath("~/Reports/Summary_Payroll_Billing_Company_Final.rpt"));
            }


            try
            {
                
              
                oReportDocument.SetParameterValue("PPID", Convert.ToInt32(ddPayrollPeriodList.SelectedValue));
                oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

                CrystalReportViewer1.ReportSource = oReportDocument;

            }
            catch
            {

            }
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            displayReport();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            oReportDocument.Close();
            oReportDocument.Dispose();
        }
    }
}