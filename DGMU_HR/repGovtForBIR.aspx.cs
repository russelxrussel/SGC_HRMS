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
    public partial class repGovtForBIR : System.Web.UI.Page
    {
        ReportDocument oReportDocument = new ReportDocument();
        Payroll_C oPayroll = new Payroll_C();
        SystemX oSystem = new SystemX();

        protected void Page_Init(object sender, EventArgs e)
        {

            //txtMonth.Text = oSystem.GET_SERVER_DATE_TIME().ToShortDateString();
            //txtDateDisplay.Text = oSystem.GET_SERVER_DATE_TIME().ToShortDateString();
            //  displayPPeriod();
            txtSelectedDate.Text  = oSystem.GET_SERVER_DATE_TIME().ToShortDateString();
            displayReport();
        }

     
       

        //}
        private void displayReport()
        {



            //int _month = Convert.ToDateTime(txtMonth.Text).Month;
            //int _year = Convert.ToDateTime(txtMonth.Text).Year;

            DateTime _selectedDate = Convert.ToDateTime(txtSelectedDate.Text);

            oReportDocument.Load(Server.MapPath("~/Reports/Summary_Company_For_BIR.rpt"));

            //oReportDocument.SetParameterValue("paramMonth", _month);
            //oReportDocument.SetParameterValue("paramYear", _year);
            oReportDocument.SetParameterValue("Date_selection", _selectedDate);
            // oReportDocument.SetParameterValue("DateRange", myRangeValue);
            oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

                    CrystalReportViewer1.ReportSource = oReportDocument;
                //}
                //else
                //{
                //    oReportDocument.Load(Server.MapPath("~/Reports/DeliverySummary_Partners.rpt"));

                //    oReportDocument.SetParameterValue("PartnerCode", ddPartnerList.SelectedValue.ToString());
                //    oReportDocument.SetParameterValue("DateRange", myRangeValue);
                //    oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

                //    CrystalReportViewer1.ReportSource = oReportDocument;
                //}
                //oReportDocument2.SetParameterValue("PartnerCode", ddPartnerList.SelectedValue.ToString());
                //oReportDocument2.SetParameterValue("DateRange", myRangeValue);
                //oReportDocument2.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

                //CrystalReportViewer2.ReportSource = oReportDocument2;
            //}
            //catch
            //{

            //}



        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            displayReport();
        }
    }
}