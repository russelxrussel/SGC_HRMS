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
    public partial class repCompanyPayrollSummary : System.Web.UI.Page
    {
        ReportDocument oReportDocument = new ReportDocument();
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Init(object sender, EventArgs e)
        {
            txtMonth.Text = oSystem.GET_SERVER_DATE_TIME().ToShortDateString();
            
            displayReport();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
          
                
            }

            displayReport();

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {

            //Cleaning Report Documents
            oReportDocument.Close();

        }

       

     

        private void displayReport()
        {

            int _month = Convert.ToDateTime(txtMonth.Text).Month;
            int _year = Convert.ToDateTime(txtMonth.Text).Year;

           
            oReportDocument.Load(Server.MapPath("~/Reports/Summary_List_Payroll_Company.rpt"));
           

            try
            {
                
                oReportDocument.SetParameterValue("_month", _month);
                oReportDocument.SetParameterValue("_year", _year);
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