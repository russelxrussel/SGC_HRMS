using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class dataEntryPayrollVoucher : System.Web.UI.Page
    {
        Payroll_C oPayroll = new Payroll_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DisplayPayrollPeriodToday();

                DisplayEmployeeList(Convert.ToInt16(ViewState["PPID"].ToString()));

            }
        }


        private void DisplayPayrollPeriodToday()
        {
            DataTable dt = oPayroll.GET_PAYROLL_PERIOD_LIST();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "IsActive = 1";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    lblPayrollPeriodText.Text = "Voucher - Payroll Period : " + drv["Description"].ToString();
                    ViewState["PPID"] = drv["PPID"];
                    ViewState["PPDESCRIPTION"] = drv["Description"];
                }
            }

        }


        private void DisplayEmployeeList(int _ppid)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_VOUCHER_LIST(_ppid);
           
            gvEmployeeList.DataSource = dt;
            gvEmployeeList.DataBind();
           
        }

        private void DisplayEmployeeVoucherData(int _ppid, string _empCode)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_VOUCHER_DATA(_ppid, _empCode);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtAdditionalAmount.Text = dr["AdditionalAmount"].ToString();
                    lblComputedVoucher.Text = string.Format("{0:n}",dr["TotalAmount"]);
                    txtRemarks.Text = dr["Remarks"].ToString();
                }
            }

        }

        private void DisplayEmployeeAttendance(string _empCode, int _ppid)
        {
            DataTable dt = oPayroll.GET_EMPLOYEE_SALARY_ENCODED(_empCode, _ppid);
            DataView dv = dt.DefaultView;

            dv.RowFilter = "EmpCode ='" + _empCode + "' and ppid = '" + _ppid + "'";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    lblDaysPresent.Text = drv["DaysPresent"].ToString();
                    lblLeave.Text = drv["Leave_Qty"].ToString();
                    lblPayOff.Text = drv["PayOff_Qty"].ToString();
                    lblLegalHoliday.Text = drv["RegularHoliday_Qty"].ToString();
                    lblSpecialHoliday.Text = drv["SpecialHoliday_Qty"].ToString();
                    lblAbsent.Text = drv["DayAbsences_Qty"].ToString();
                }
            }

            DataTable dtEmpSalary = oPayroll.GET_EMPLOYEE_SALARY();
            DataView dvEmpSalary = dtEmpSalary.DefaultView;

            dvEmpSalary.RowFilter = "EmpCode = '" + _empCode + "'";
            if (dvEmpSalary.Count > 0)
            {
                double total = 0, actualRate = 0, BasicRate = 0;
                foreach (DataRowView drv in dvEmpSalary)
                {
    
                    lblActualRate.Text = string.Format("{0:n}",drv["ActualRate"]);
                    lblBasicRate.Text = string.Format("{0:n}",drv["BasicRate"]);
                    actualRate = Convert.ToDouble(lblActualRate.Text);
                    BasicRate = Convert.ToDouble(lblBasicRate.Text);

                }

                total = actualRate - BasicRate;

                lblComputedRated.Text = string.Format("{0:n}",total);
            }

        }

        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
            // string selAppNum = r.Cells[2].Text;
            string sEmpCode = r.Cells[0].Text;
            string sEmpName = r.Cells[1].Text;

            ViewState["EMPCODE"] = sEmpCode;
            lblHeading.Text = "Process Voucher Payment of : <b>" + sEmpName + "</b>";

            DisplayEmployeeAttendance(sEmpCode, Convert.ToInt16(ViewState["PPID"].ToString()));
            txtAdditionalAmount.Text = "0";

            DisplayEmployeeVoucherData(Convert.ToInt16(ViewState["PPID"].ToString()), sEmpCode);
        }

        protected void lnkCompute_Click(object sender, EventArgs e)
        {
            double additionalAmount = 0, computedTotalVoucherAmount = 0;
            if (!string.IsNullOrEmpty(txtAdditionalAmount.Text))
            {
                additionalAmount = Convert.ToDouble(txtAdditionalAmount.Text);
            }
            else { additionalAmount = 0; }

            ViewState["ADDITIONALAMOUNT"] = additionalAmount;
            computedTotalVoucherAmount = oPayroll.GET_EMPLOYEE_VOUCHER_COMPUTATION(Convert.ToInt16(ViewState["PPID"].ToString()),
                                                                                ViewState["EMPCODE"].ToString(), additionalAmount);

            lblComputedVoucher.Text = string.Format("{0:n}", computedTotalVoucherAmount);

            txtRemarks.Text = "Overtime Pay from " + ViewState["PPDESCRIPTION"].ToString();
        }

        protected void lnkProcess_Click(object sender, EventArgs e)
        {
            lnkCompute_Click(sender, e);
            
            oPayroll.INSERT_UPDATE_EMPLOYEE_VOUCHER_TRANS(Convert.ToInt16(ViewState["PPID"].ToString()),
                                                           ViewState["EMPCODE"].ToString(), Convert.ToDouble(lblActualRate.Text),
                                                           Convert.ToDouble(lblBasicRate.Text), Convert.ToDouble(lblComputedRated.Text),
                                                           Convert.ToDouble(lblDaysPresent.Text), Convert.ToDouble(ViewState["ADDITIONALAMOUNT"]),
                                                           Convert.ToDouble(lblComputedVoucher.Text), txtRemarks.Text);



            clearInputs();
            DisplayEmployeeList(Convert.ToInt16(ViewState["PPID"].ToString()));

            lblSuccessMessage.Text = "Employee voucher successfully process.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
            

        }

        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow r in gvEmployeeList.Rows)
            {
                try
                {
                    string sEmpCode = r.Cells[0].Text;
                    LinkButton lnkSelect = r.FindControl("lnkSelect") as LinkButton;

                    if (oPayroll.CHECK_EMPLOYEE_VOUCHER_EXIST(sEmpCode,Convert.ToInt16(ViewState["PPID"].ToString())))
                    {
                        lnkSelect.CssClass = "btn btn-sm btn-success";
                        lnkSelect.Text = "Edit";
                    }

                


                }
                catch { }
            }
        }


        private void clearInputs()
        {
            lblActualRate.Text = "";
            lblBasicRate.Text = "";
            lblComputedRated.Text = "";
            lblComputedVoucher.Text = "";
            txtAdditionalAmount.Text = "";
            txtRemarks.Text = "";

            lblAbsent.Text = "";
            lblLeave.Text = "";
            lblAbsent.Text = "";
            lblLegalHoliday.Text = "";
            lblSpecialHoliday.Text = "";
            lblPayOff.Text = "";
            lblDaysPresent.Text = "";
        }
        
    
    }
}