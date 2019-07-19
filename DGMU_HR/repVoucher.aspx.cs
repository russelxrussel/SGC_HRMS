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
    public partial class repVoucher : System.Web.UI.Page
    {
        ReportDocument oReportDocument = new ReportDocument();
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Init(object sender, EventArgs e)
        {
            displayPPeriod();
            txtDateDisplay.Text = oSystem.GET_SERVER_DATE_TIME().ToShortDateString();
            displayReport();
            
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
        private void displayReport()
        {
           
                    oReportDocument.Load(Server.MapPath("~/Reports/PayVoucher.rpt"));

                    oReportDocument.SetParameterValue("PPID", Convert.ToInt32(ddPP.SelectedValue));
                   oReportDocument.SetParameterValue("paramDate", Convert.ToDateTime(txtDateDisplay.Text));
           
                oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

                    CrystalReportViewer1.ReportSource = oReportDocument;
               



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