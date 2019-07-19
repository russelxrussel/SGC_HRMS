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
    public partial class repPayslip : System.Web.UI.Page
    {

        ReportDocument oReportDocument = new ReportDocument();
        Payroll_C oPayroll = new Payroll_C();

        protected void Page_Init(object sender, EventArgs e)
        {

              displayReport();

       

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayPPeriod();
                displayPayrollGroup();
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

            ddPP.DataSource = dv;
            ddPP.DataTextField = dv.Table.Columns["Description"].ToString();
            ddPP.DataValueField = dv.Table.Columns["PPID"].ToString();
            ddPP.DataBind();
            

        }

        private void displayPayrollGroup()
        {
            DataTable dt = oPayroll.GET_PAYROLL_GROUP_LIST();
            DataView dv = dt.DefaultView;

            dv.Sort = "PayrollGroupCode desc";

            ddPayrollGroup.DataSource = dv;
            ddPayrollGroup.DataTextField = dv.Table.Columns["PayrollGroupName"].ToString();
            ddPayrollGroup.DataValueField = dv.Table.Columns["PayrollGroupCode"].ToString();
            ddPayrollGroup.DataBind();
        }

        private void displayReport()
        {
            
            if (ddPayrollGroup.SelectedValue == "DP")
            {
                oReportDocument.Load(Server.MapPath("~/Reports/Payslips.rpt"));
            }
            else
            {
                oReportDocument.Load(Server.MapPath("~/Reports/Payslips_Branch.rpt"));
            }

            try
            {

           
            oReportDocument.SetParameterValue("PPID", Convert.ToInt32(ddPP.SelectedValue));
            oReportDocument.SetParameterValue("PayrollGroupCode", ddPayrollGroup.SelectedValue);
            // oReportDocument.SetParameterValue("DateRange", myRangeValue);
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