using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace DGMU_HR
{
    public partial class dataEntryBranchIncentives : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DisplayBranchWageList();
                DisplayWageAreaList();

                txtMonth.Text = DateTime.Now.ToString();
            }
        }


        

        private void DisplayEmployeeList()
        {
            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;

            DataTable dt = oPayroll.GET_BRANCH_EMPLOYEE_LIST_ASSIGNED();

            DataView dv = dt.DefaultView;
            dv.RowFilter = "BranchCode <> '" + ddBranchList.SelectedValue + "'";

            gvBranchEmployeeList.DataSource = dv;
            gvBranchEmployeeList.DataBind();


            if (!oPayroll.CHECK_BRANCH_INCENTIVES_EXIST(month, year, ddBranchList.SelectedValue))
            {
               
                SaveInitially();
            }
           

        }

        private void DisplayWageAreaList()
        {
            DataTable dt = oPayroll.GET_WAGE_AREA_LIST();

            ddWageArea.DataSource = dt;
            ddWageArea.DataTextField = dt.Columns["WageArea"].ToString();
            ddWageArea.DataValueField = dt.Columns["WageCode"].ToString();
            ddWageArea.DataBind();

            ddWageArea.Items.Insert(0, new ListItem("--Select Area--"));
        }


        private void DisplayBranchWageList(string _wageCode)
        {
            DataTable dt = oPayroll.GET_BRANCH_WAGE_LIST();

            DataView dv = dt.DefaultView;
            dv.RowFilter = "WageCode='" + _wageCode + "'";
            dv.Sort = "BranchName";

            ddBranchList.DataSource = dv;
            ddBranchList.DataTextField = dv.Table.Columns["BranchName"].ToString();
            ddBranchList.DataValueField = dv.Table.Columns["BranchCode"].ToString();
            ddBranchList.DataBind();


            DisplayBranchEmployeeList(ddBranchList.SelectedValue.ToString());
        }

        private double DisplayWageAmount(string _wageCode)
        {
            double dWageAmount = 0;

            DataTable dt = oPayroll.GET_WAGE_AREA_LIST();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "WageCode = '" + _wageCode + "'";

            foreach (DataRowView drv in dv)
            {
                dWageAmount = Convert.ToDouble(drv["WageAmount"]);
            }
            

            return dWageAmount;
        }


        private void DisplayBranchEmployeeList(string _branchCode)
        {
            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;

            txtBranchMonthlySales.Text = "";
            lblTotalIncentives.Text = "";

            if (!oPayroll.CHECK_BRANCH_INCENTIVES_EXIST(month, year, ddBranchList.SelectedValue))
            {
                DataTable dt = oPayroll.GET_BRANCH_EMPLOYEE_LIST_ASSIGNED();

                DataView dv = dt.DefaultView;
                dv.RowFilter = "BranchCode='" + _branchCode + "'";
                dv.Sort = "IsSenior desc, EmployeeName";


                gvLinkBranchEmployeeAssigned.DataSource = dt;
                gvLinkBranchEmployeeAssigned.DataBind();
            }
            else
            {
                DataTable dt = oPayroll.GET_BRANCH_INCENTIVES_TRANS(month, year, ddBranchList.SelectedValue);

                gvLinkBranchEmployeeAssigned.DataSource = dt;
                gvLinkBranchEmployeeAssigned.DataBind();

                foreach (DataRow dr in dt.Rows)
                {
                    txtBranchMonthlySales.Text = dr["BranchSales"].ToString();
                    txtRemarks.Text = dr["Remarks"].ToString();
                    lblTotalIncentives.Text = string.Format("{0:n}", dr["TotalSalesIncentives"]);

                }
                //Display data from table

                DataView dv = dt.DefaultView;

                foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
                {
                    string sEmployeeID = r.Cells[1].Text;
                    TextBox txtDaysPresent = r.FindControl("txtDaysPresent") as TextBox;
                    TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;
                    Label lblIncentiveAmount = r.FindControl("lblIncentiveAmount") as Label;

                    dv.RowFilter = "EmpCode = '" + sEmployeeID + "'";

                    if (dv.Count > 0)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            txtDaysPresent.Text = drv["DaysPresent"].ToString();
                            txtIncentivePercentage.Text = drv["EmpIncentivePercentage"].ToString();
                            lblIncentiveAmount.Text = string.Format("{0:n}", drv["EmpIncentiveAmount"]);

                        }
                       
                    }
                   
                   
              
                }

              

            }
        }



    

      

        protected void ddWageArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBranchWageList(ddWageArea.SelectedValue.ToString());

            DisplayEmployeeList();

        }

     

        protected void lnkEmployeeTransfer_Click(object sender, EventArgs e)
        {
            //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;

            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;

            oPayroll.INSERT_UPDATE_BRANCH_EMPLOYEE_INCENTIVES_TRANS(month, year, sEmpCode, ddWageArea.SelectedValue, ddBranchList.SelectedValue,
                                                                    0, 0, 0, 0, 0,0, true, "");

            //Refresh Gridview of Branch Employee computed incentives
            ddWageArea_SelectedIndexChanged(sender, e);

            lblSuccessMessage.Text = "Employee successfully transferred.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

        }

        protected void lnkRemoveEmployeeTransfer_Click(object sender, EventArgs e)
        {
            //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[1].Text;

            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;


            oPayroll.REMOVE_BRANCH_EMPLOYEE_TRANSFER(month, year, sEmpCode, ddBranchList.SelectedValue);

            //Refresh Gridview of Branch Employee computed incentives
            ddWageArea_SelectedIndexChanged(sender, e);

            lblSuccessMessage.Text = "Employee Transferred successfully remove.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

        }


        protected void ddBranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBranchEmployeeList(ddBranchList.SelectedValue);

            DisplayEmployeeList();
        }

        protected void lnkBranchEmployeeRemove_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;


            if (ddWageArea.SelectedIndex != 0)
            {

                //double dWageAmount = DisplayWageAmount(ddWageArea.SelectedValue);

                oPayroll.INSERT_UPDATE_PAYROLL_BRANCH_SETUP(sEmpCode, ddBranchList.SelectedValue, 0);


                DisplayEmployeeList();
                DisplayBranchEmployeeList(ddBranchList.SelectedValue);
              
                //ddWageArea_SelectedIndexChanged(sender, e);

                txtSearch.Text = "";

                lblSuccessMessage.Text = "Employee successfully unassigned";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

            }
            else
            {
                lblErrorMessage.Text = "Please select Wage Area";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void lnkSetAsSenior_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            
            string sEmpCode = r.Cells[0].Text;

            oPayroll.UPDATE_SENIOR(sEmpCode);

            lblSuccessMessage.Text = "Setting Senior successfully updated.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

        }

        protected void gvLinkBranchEmployeeAssigned_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;


            foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
            {
                string sEmployeeID = r.Cells[1].Text;
                TextBox txtDaysPresent = r.FindControl("txtDaysPresent") as TextBox;
                Label lblIncomeNoHolidays = r.FindControl("lblGrossIncome") as Label;
                Image imgSenior = r.FindControl("imgSenior") as Image;
                Image imgTransfer = r.FindControl("imgEmpTransfer") as Image;
                LinkButton lnkRemove = r.FindControl("lnkRemove") as LinkButton;

                txtDaysPresent.Text = oPayroll.GET_BRANCH_EMPLOYEE_ATTENDANCE(month, year, sEmployeeID).ToString();

                


                /*
                NOTE: GROSS change to NET INCOME. as changed on 11.05.2018
                Process: Gross Income less the total Holidays Computation.
                */
                double dHolidaysAmount = 0, dGrossIncome = 0, dTotalIncome = 0;
                dHolidaysAmount = oPayroll.GET_BRANCH_EMPLOYEE_HOLIDAYS_AMOUNT(month, year, sEmployeeID);
                dGrossIncome = oPayroll.GET_BRANCH_EMPLOYEE_GROSSINCOME(month, year, sEmployeeID);
                dTotalIncome =  dGrossIncome - dHolidaysAmount;

               
                lblIncomeNoHolidays.Text = string.Format("{0:n}", dTotalIncome);

                if (oPayroll.CHECK_EMPLOYEE_SENIOR(sEmployeeID))
                { imgSenior.Visible = true;
                  r.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                { imgSenior.Visible = false; }

                if (oPayroll.CHECK_DISPLAY_EMPLOYEE_TRANSFER(sEmployeeID, ddBranchList.SelectedValue))
                { //imgTransfer.Visible = true;
                    lnkRemove.Visible = true;
                }
                else
                { //imgTransfer.Visible = false;
                   lnkRemove.Visible = false;
                }
            }
        }            
          

       

        protected void lnkCompute_Click(object sender, EventArgs e)
        {

            double tot = 0;
            double employeeIncentiveRate = 0;

            //Check first if Branch Sales has amount
            if (!string.IsNullOrEmpty(txtBranchMonthlySales.Text) && ddWageArea.SelectedIndex != 0)
            {
                
                    foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
                    {
                        string sEmployeeID = r.Cells[1].Text;
                        TextBox txtDaysPresent = r.FindControl("txtDaysPresent") as TextBox;
                        Label lblIncentiveCount = r.FindControl("lblIncentiveCount") as Label;


                    if (gvLinkBranchEmployeeAssigned.Rows.Count == 1)
                    {
                        lblIncentiveCount.Text = oPayroll.GET_SINGLE_BRANCH_EMPLOYEE_QUOTA(ddWageArea.SelectedValue).ToString();
                    }
                    else { 
                        lblIncentiveCount.Text = oPayroll.GET_EMPLOYEE_INCENTIVE_RATE(sEmployeeID, Convert.ToDouble(txtDaysPresent.Text), ddBranchList.SelectedValue).ToString();
                    }

                    double incentiveCount = Convert.ToDouble(lblIncentiveCount.Text);
                        employeeIncentiveRate += incentiveCount;

                        //lblIncentiveAmount.Text =  Convert.ToDouble(txtIncentivePercentage.Text)

                    }
                }
               

                tot = oPayroll.GET_TOTAL_SALES_INCENTIVE(Convert.ToDouble(txtBranchMonthlySales.Text), employeeIncentiveRate);

                lblTotalIncentives.Text = string.Format("{0:n}", tot);

                if (tot > 0)
                {
                    foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
                    {
                        Label lblIncentiveAmount = r.FindControl("lblIncentiveAmount") as Label;
                        TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;
                        double incentivePercentage = 0;

                        txtIncentivePercentage.Enabled = true;

                        if (!string.IsNullOrEmpty(txtIncentivePercentage.Text))
                        { incentivePercentage = Convert.ToDouble(txtIncentivePercentage.Text); }
                        else { incentivePercentage = 0; }

                    }

                //DateTime dtMonth = Convert.ToDateTime(txtMonth.Text);
                //string monthName = new DateTime(dtMonth).ToString("MMM", CultureInfo.InvariantCulture);
                //

                txtRemarks.Text = "Overtime Pay for the month of " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(txtMonth.Text).Month) + " " + Convert.ToDateTime(txtMonth.Text).Year.ToString();
                }
                else
                {
                    //disable saving / printing.
                    // panelEmployeeList.Enabled = false;
                    //lblErrorMessage.Text = "";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                    foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
                    {
                        TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;
                        txtIncentivePercentage.Text = "";
                        txtIncentivePercentage.Enabled = false;

                    }

                txtRemarks.Text = "";
            }

            }
          
        //else
        //    {
        //        lblErrorMessage.Text = "Input required Area and Branch Sales.";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
        //    }
        //    //lblSuccessMessage.Text = tot.ToString();
        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
        //}

        protected void lnkComputeEmployeeIncentive_Click(object sender, EventArgs e)
        {
            lnkCompute_Click(sender, e);

            double forCheckTotal = 0;

            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;


            foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
            {

                TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;
                double incentivePercentage = 0;
                if (!string.IsNullOrEmpty(txtIncentivePercentage.Text))
                { incentivePercentage = Convert.ToDouble(txtIncentivePercentage.Text); }
                else { incentivePercentage = 0; }

                forCheckTotal += incentivePercentage;


            }

            
            if (forCheckTotal != 100)
            {
                lblErrorMessage.Text = "Total percentage should be 100%";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
            else
            {
                //Display computed
              
                foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
                {
                    string sEmployeeID = r.Cells[1].Text;
                    Label lblIncentiveAmount = r.FindControl("lblIncentiveAmount") as Label;
                    Label lblTotalIncomeAndIncentives = r.FindControl("lblTotalIncomeAndIncentives") as Label;
                    Label lblGrossIncome = r.FindControl("lblGrossIncome") as Label;
                    Label lblLessHolidayAmount = r.FindControl("lblLessHolidayAmount") as Label;
                    TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;

                    double incentivePercentage = 0, totalIncomeAndIncentives = 0;
                    if (!string.IsNullOrEmpty(txtIncentivePercentage.Text))
                    { incentivePercentage = Convert.ToDouble(txtIncentivePercentage.Text); }
                    else { incentivePercentage = 0; }



                    // Holiday less on Total Incentive per employee
                    lblLessHolidayAmount.Text = string.Format("{0:n}", oPayroll.GET_BRANCH_EMPLOYEE_HOLIDAYS_AMOUNT(month, year, sEmployeeID));

                    double totalEmployeeIncentive = (Convert.ToDouble(lblTotalIncentives.Text) * incentivePercentage ) / 100;
                    lblIncentiveAmount.Text = string.Format("{0:n}", totalEmployeeIncentive);

                    totalIncomeAndIncentives = (Convert.ToDouble(lblIncentiveAmount.Text) + Convert.ToDouble(lblGrossIncome.Text)) - Convert.ToDouble(lblLessHolidayAmount.Text);
                    lblTotalIncomeAndIncentives.Text = string.Format("{0:n}", totalIncomeAndIncentives);
                }

                lnkProcessSave.Enabled = true;

            }
        }

        protected void lnkProcessSave_Click(object sender, EventArgs e)
        {
            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;

            if (!string.IsNullOrEmpty(txtBranchMonthlySales.Text) && !string.IsNullOrEmpty(lblTotalIncentives.Text))
            {
                foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
                {
                    string sEmployeeCode = r.Cells[1].Text;
                    Label lblIncentiveAmount = r.FindControl("lblIncentiveAmount") as Label;
                    Label lblLessHolidayAmount = r.FindControl("lblLessHolidayAmount") as Label;
                    Label lblTotalIncomeAndIncentives = r.FindControl("lblTotalIncomeAndIncentives") as Label;
                    TextBox txtDaysPresent = r.FindControl("txtDaysPresent") as TextBox;
                    TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;


                    double empIncentivePercentage = 0;
                    if (!string.IsNullOrEmpty(txtIncentivePercentage.Text))
                    { empIncentivePercentage = Convert.ToDouble(txtIncentivePercentage.Text); }
                    else { empIncentivePercentage = 0; }

                    //if (empIncentivePercentage > 0)
                    //{

                        oPayroll.INSERT_UPDATE_BRANCH_EMPLOYEE_INCENTIVES_TRANS(month, year, sEmployeeCode, ddWageArea.SelectedValue,
                                                                                ddBranchList.SelectedValue, Convert.ToDouble(txtBranchMonthlySales.Text),
                                                                                Convert.ToDouble(lblTotalIncentives.Text), Convert.ToDouble(txtDaysPresent.Text),
                                                                                empIncentivePercentage, Convert.ToDouble(lblIncentiveAmount.Text),Convert.ToDouble(lblLessHolidayAmount.Text), false, txtRemarks.Text);
                    //}
                }

                //lblSuccessMessage.Text = "Incentive Computation successfully save.";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                lblErrorMessage.Text = "Branch Sales and Incentives required.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        //This will save initially to table 
        //Handle transfer of other branch employee
        private void SaveInitially()
        {
            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;

            double branchSales = 0;
            if (!string.IsNullOrEmpty(txtBranchMonthlySales.Text))
            {
                branchSales = Convert.ToDouble(txtBranchMonthlySales.Text);
            }
            else { branchSales = 0; }
            foreach (GridViewRow r in gvLinkBranchEmployeeAssigned.Rows)
            {
                string sEmployeeCode = r.Cells[1].Text;
                Label lblIncentiveAmount = r.FindControl("lblIncentiveAmount") as Label;
                Label lblLessHolidayAmount = r.FindControl("lblLessHolidayAmount") as Label;
                Label lblTotalIncomeAndIncentives = r.FindControl("lblTotalIncomeAndIncentives") as Label;
                TextBox txtDaysPresent = r.FindControl("txtDaysPresent") as TextBox;
                TextBox txtIncentivePercentage = r.FindControl("txtIncentivePercentage") as TextBox;


                double empIncentivePercentage = 0, totalIncentives=0, daysPresent=0, empIncentiveAmount=0, empLessIncentiveAmount=0 ;
                if (!string.IsNullOrEmpty(txtIncentivePercentage.Text))
                { empIncentivePercentage = Convert.ToDouble(txtIncentivePercentage.Text); }
                else { empIncentivePercentage = 0; }

                if (!string.IsNullOrEmpty(lblTotalIncentives.Text))
                { totalIncentives = Convert.ToDouble(lblTotalIncentives.Text); }
                else { totalIncentives = 0; }

                if (!string.IsNullOrEmpty(lblLessHolidayAmount.Text))
                { empLessIncentiveAmount = Convert.ToDouble(lblLessHolidayAmount.Text); }
                else { empLessIncentiveAmount = 0; }

                if (!string.IsNullOrEmpty(txtDaysPresent.Text))
                { daysPresent = Convert.ToDouble(txtDaysPresent.Text); }
                else { daysPresent = 0; }

                if (!string.IsNullOrEmpty(lblIncentiveAmount.Text))
                { empIncentiveAmount = Convert.ToDouble(lblIncentiveAmount.Text); }
                else { empIncentiveAmount = 0; }



                //if (empIncentivePercentage > 0)
                //{

                oPayroll.INSERT_UPDATE_BRANCH_EMPLOYEE_INCENTIVES_TRANS(month, year, sEmployeeCode, ddWageArea.SelectedValue,
                                                                            ddBranchList.SelectedValue, branchSales,
                                                                            totalIncentives, daysPresent,
                                                                            empIncentivePercentage, empIncentiveAmount,empLessIncentiveAmount, false, txtRemarks.Text);

                //}
            }
           }

        protected void lnkClearIncentiveZero_Click(object sender, EventArgs e)
        {
            int month = Convert.ToDateTime(txtMonth.Text).Month;
            int year = Convert.ToDateTime(txtMonth.Text).Year;

            oPayroll.REFRESH_BRANCH_INCENTIVE_LIST(month, year, ddWageArea.SelectedValue.ToString(), ddBranchList.SelectedValue.ToString());

            ddWageArea.SelectedIndex = 0;
            ddWageArea_SelectedIndexChanged(sender, e);

        }
    }
           
}