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
    public partial class repEmployeeNoGovtID : System.Web.UI.Page
    {
        ReportDocument oReportDocument = new ReportDocument();
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Init(object sender, EventArgs e)
        {
      
            displayNoGovtIDs();
        }

      
        protected void Page_UnLoad(object sender, EventArgs e)
        {

            //Cleaning Report Documents
            oReportDocument.Close();

        }

       

     

        private void displayNoGovtIDs()
        {
            
                oReportDocument.Load(Server.MapPath("~/Reports/No_Govt_IDs.rpt"));
                
                oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

                CrystalReportViewer1.ReportSource = oReportDocument;

           
        }
     


      
     

      
    }
}