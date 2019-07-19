using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DGMU_HR
{
    public class Payroll_C : Base_C

    {

        public DataTable GET_WAGE_AREA_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_WAGE_AREA_LIST]");
            return dt;
        }

        public DataTable GET_GOVT_REMITTANCE_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_GOVT_LIST]");
            return dt;
        }
        public DataTable GET_PAYROLL_GROUP_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_PAYROLL_GROUP_LIST]");
            return dt;
        }



        //LOANS LIST
        public DataTable GET_LOANS_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_LOANS_LIST]");
            return dt;
        }


        //LEAVES LIST
        public DataTable GET_LEAVES_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_LEAVES_LIST]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_LEAVES_AVAILABLE()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_LEAVES_AVAILABLE]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_LEAVES_HISTORY(string _empCode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_LEAVES_HISTORY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                  
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
       
        public DataTable GET_EMPLOYEE_LOANS()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_LOANS]");
            return dt;
        }

        //LOAN PAYMENT LIST
        public DataTable GET_EMPLOYEE_PAYMENT_LOANS_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[GET_EMPLOYEE_PAYMENT_LOAN_LIST]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_LOAN_DETAILS()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_LOAN_DETAILS]");
            return dt;
        }

        public double GET_EMPLOYEE_SALARY_LOAN_BALANCE(string _empCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_SALARY_LOAN_BALANCE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }
        public double GET_EMPLOYEE_SSS_LOAN_BALANCE(string _empCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_SSS_LOAN_BALANCE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }
        public double GET_EMPLOYEE_PAGIBIG_LOAN_BALANCE(string _empCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_PAGIBIG_LOAN_BALANCE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }



        public DataTable GET_EMPLOYEE_SALARY()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_SALARY]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_LIST_LW()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[PAYROLL].[spGET_EMPLOYEE_LIST_LW]");
            return dt;
        }

      

        public DataTable GET_EMPLOYEE_LIST_ACTIVE_LW()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_LIST_ACTIVE_LW]");
            return dt;
        }

        public double GET_EMPLOYEE_YEARS_MONTHS(DateTime _dateInput)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_YEAR_MONTHS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@INPUT_DATE", _dateInput);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        //BRANCH EMPLOYEE PAYROLL SETUP
        public DataTable GET_BRANCH_EMPLOYEE_LIST_LW_NOT_ASSIGN()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_NO_PAYROLL_GROUP_LW]");
            return dt;
        }

        public DataTable GET_BRANCH_EMPLOYEE_LIST_ASSIGNED()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_BRANCH_LW]");
            return dt;

        }


        public DataTable GET_BRANCH_WAGE_LIST_NOT_ASSIGN()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_BRANCH_WAGE_LIST_NOT_ASSIGN]");
            return dt;

        }

        public DataTable GET_WAGE_BRANCH_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[GET_WAGE_BRANCH_LIST]");
            return dt;
        }



        public DataTable GET_BRANCH_WAGE_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_BRANCH_WAGE_LIST]");
            return dt;

        }


        public DataTable GET_EMPLOYEE_SALARY_ENCODED(string _empCode, int _ppID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_SALARY_ENCODED]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@PPID", _ppID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable GET_BRANCH_INCENTIVES_TRANS(int _month, int _year, string _branchCode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_BRANCH_INCENTIVE_TRANS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }


        //VOUCHER EMPLOYEE LIST
        public DataTable GET_EMPLOYEE_VOUCHER_LIST(int _ppID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_VOUCHER_LIST]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PPID", _ppID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable GET_EMPLOYEE_VOUCHER_DATA(int _ppID, string _empCode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_VOUCHER_EMPLOYEE_DATA]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PPID", _ppID);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }

        public double GET_REGULAR_HOLIDAY(double _daysPresent, string _empCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_REGULAR_HOLIDAY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DAYPRESENT", _daysPresent);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    
                    cn.Open();
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

         return x;
        }

        public double GET_REGULAR_HOLIDAY_OT_PAY(string _empCode, double _otHours)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_REGULAR_HOLIDAY_OVERTIME_PAY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@OTHOURS", _otHours);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_SPECIAL_HOLIDAY(double _daysPresent,string _empCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_SPECIAL_HOLIDAY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@SPCHOLIDAYPRESENT", _daysPresent);
                    cn.Open();
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_SPECIAL_HOLIDAY_OT_PAY(string _empCode, double _otHours)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_SPECIAL_HOLIDAY_OVERTIME_PAY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@OTHOURS", _otHours);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_OT_PAY(string _empCode, double _otHours)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_OVERTIME_PAY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@OTHOURS", _otHours);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_SSS_SHARE(string _empCode, double _grossIncome, double _regularHoliday, double _regularHolidayOT,
                                    double _specialHoliday, double _specialHolidayOT, int _ppId)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_SSS_AMOUNT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@GROSSINCOME", _grossIncome);
                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                    cmd.Parameters.AddWithValue("@REGULARHOLIDAY", _regularHoliday);
                    cmd.Parameters.AddWithValue("@REGULARHOLIDAYOT", _regularHolidayOT);
                    cmd.Parameters.AddWithValue("@SPECIALHOLIDAY", _specialHoliday);
                    cmd.Parameters.AddWithValue("@SPECIALHOLIDAYOT", _specialHolidayOT);

                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_PHILHEALTH_SHARE(string _empCode, double _grossIncome, double _regularHoliday, double _regularHolidayOT,
                                    double _specialHoliday, double _specialHolidayOT, int _ppId)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_PHILHEALTH_AMOUNT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@GROSSINCOME", _grossIncome);
                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                    cmd.Parameters.AddWithValue("@REGULARHOLIDAY", _regularHoliday);
                    cmd.Parameters.AddWithValue("@REGULARHOLIDAYOT", _regularHolidayOT);
                    cmd.Parameters.AddWithValue("@SPECIALHOLIDAY", _specialHoliday);
                    cmd.Parameters.AddWithValue("@SPECIALHOLIDAYOT", _specialHolidayOT);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_PAGIBIG_SHARE(string _empCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_PAGIBIG_AMOUNT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        //DEDUCTION
        public double GET_TARDINESS_UNDERTIME_RESULT(string _empCode, double _tardiness_underTime)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_TARDINESS_UNDERTIME_PAY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@TARDINESS_UNDERTIME", _tardiness_underTime);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        //WITH HOLDING TAX
        public double GET_WITH_HOLDING_TAX(string _empCode, double _grossIncome, int _ppId)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_WTAX]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@GROSSINCOME", _grossIncome);
                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }



        //PAYROLL PERIOD
        public DataTable GET_PAYROLL_PERIOD_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_PAYROLL_PERIOD_LIST]");
            return dt;
        }

        public int GET_DEFAULT_PAYROLL_PERIOD()
        {
            int x = 0;

            DataTable dt = GET_PAYROLL_PERIOD_LIST();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "IsActive = '" + true + "'";
            if (dv.Count > 0)
            {
                foreach (DataRowView dvr in dv)
                {
                    x = (int)dvr["PPID"];
                }
            }
            else
            {
                x = 0;
            }

            return x;
        }


        //GET PROCESS EMPLOYEE PAYROLL STAT
        //02.26.2019
        public DataTable GET_EMPLOYEE_PAYROLL_PROCESS_STAT(int _ppId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_EMPLOYEE_PAYROLL_PROCESSED]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }




        //GET BRANCH ATTENDANCE EMPLOYEE
        public double GET_BRANCH_EMPLOYEE_ATTENDANCE(int _month, int _year, string _empCode)
        {
            double x = 0;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_BRANCH_EMPLOYEE_ATTENDANCE]", cn))
                {
                    
                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    x = Convert.ToDouble(cmd.ExecuteScalar());

                }
            }

            return x;
        }

        public double GET_BRANCH_EMPLOYEE_GROSSINCOME(int _month, int _year, string _empCode)
        {
            double x = 0;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_BRANCH_EMPLOYEE_GROSS_INCOME]", cn))
                {

                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    x = Convert.ToDouble(cmd.ExecuteScalar());

                }
            }

            return x;
        }

        public double GET_BRANCH_EMPLOYEE_HOLIDAYS_AMOUNT(int _month, int _year, string _empCode)
        {
            double x = 0;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_BRANCH_EMPLOYEE_HOLIDAYS_AMOUNT]", cn))
                {

                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    x = Convert.ToDouble(cmd.ExecuteScalar());

                }
            }

            return x;
        }

        public double GET_BRANCH_EMPLOYEE_NET_PAY(int _month, int _year, string _empCode)
        {
            double x = 0;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_BRANCH_EMPLOYEE_NET_PAY]", cn))
                {

                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    x = Convert.ToDouble(cmd.ExecuteScalar());

                }
            }

            return x;
        }


        //INCENTIVES
        public double GET_EMPLOYEE_INCENTIVE_RATE(string _empCode, double _daysPresent, string _branchCode)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_INCENTIVE_RATE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@DAYSPRESENT", _daysPresent);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public double GET_TOTAL_SALES_INCENTIVE(double _branchSales, double _employeesIncentiveRate)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_TOTAL_SALES_INCENTIVE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@BRANCHSALES", _branchSales);
                    cmd.Parameters.AddWithValue("@EMPLOYEESINCENTIVERATE", _employeesIncentiveRate);
                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        //SINGLE QUOTA FOR INCENTIVES
        public double GET_SINGLE_BRANCH_EMPLOYEE_QUOTA(string _wageCode)
        {
            int x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_INCENTIVE_RATE_SINGLE_INCENTIVE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WAGECODE", _wageCode);
                    cn.Open();

                    x = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return x;
        }




        //VOUCHER
        public double GET_EMPLOYEE_VOUCHER_COMPUTATION(int _ppid, string _empCode, double _additionalAmount)
        {
            double x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[GET_VOUCHER_EMPLOYEE_COMPUTATION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PPID", _ppid);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@ADDITIONALAMOUNT", _additionalAmount);

                    x = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public bool CHECK_EMPLOYEE_SENIOR(string _empCode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[CHECK_EMPLOYEE_SENIOR]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }

        //DISPLAY ICON FOR EMPLOYEE BRANCH TRANSFER
        public bool CHECK_DISPLAY_EMPLOYEE_TRANSFER(string _empCode, string _branchCode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[CHECK_DISPLAY_EMPLOYEE_BRANCH_TRANSFER]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }

        public bool CHECK_PAYROLL_PERIOD_EXIST(DateTime _startDate)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[CHECK_PAYROLL_PERIOD_DATE_EXIST]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                   
                    cmd.Parameters.AddWithValue("@STARTDATE", _startDate);
                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }


        public bool CHECK_EMPLOYEE_PAYROLL_EXIST(string _empCode, int _ppId)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[CHECK_EMPLOYEE_PAYROLL_EXIST]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }

        public bool CHECK_EMPLOYEE_VOUCHER_EXIST(string _empCode, int _ppId)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[CHECK_EMPLOYEE_VOUCHER_EXIST]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }

        public bool CHECK_BRANCH_INCENTIVES_EXIST(int _month, int _year, string _branchCode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[CHECK_BRANCH_INCENTIVES_EXIST]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }

        //Link of Payroll Salary Loan Deduction


        public string GET_EMPLOYEE_ACTIVE_SALARY_LOAN(string _empCode)
        {
            string sLoanSN = "";
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_ACTIVE_SALARY_LOAN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    sLoanSN = cmd.ExecuteScalar().ToString();
                }
            }

            return sLoanSN;
        }

        /*
        get active loans
            */
        public string GET_EMPLOYEE_ACTIVE_SSS_LOAN(string _empCode)
        {
            string sLoanSN = "";
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_ACTIVE_SSS_LOAN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    sLoanSN = cmd.ExecuteScalar().ToString();
                }
            }

            return sLoanSN;
        }
        public string GET_EMPLOYEE_ACTIVE_PAGIBIG_LOAN(string _empCode)
        {
            string sLoanSN = "";
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spGET_EMPLOYEE_ACTIVE_PAGIBIG_LOAN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    sLoanSN = cmd.ExecuteScalar().ToString();
                }
            }

            return sLoanSN;
        }



        public bool CHECK_EMPLOYEE_SALARY_LOAN_ACTIVE(string _empCode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[Payroll].[spCHECK_SALARY_LOAN_ACTIVE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                   
                    x = (bool)cmd.ExecuteScalar();
                }
            }   

            return x;
        }
        public bool CHECK_EMPLOYEE_SSS_LOAN_ACTIVE(string _empCode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[Payroll].[spCHECK_SSS_LOAN_ACTIVE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);

                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }
        public bool CHECK_EMPLOYEE_PAGIBIG_LOAN_ACTIVE(string _empCode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[Payroll].[spCHECK_PAGIBIG_LOAN_ACTIVE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);

                    x = (bool)cmd.ExecuteScalar();
                }
            }

            return x;
        }



        //DISPLAY STAT COUNT
        public int GET_COUNT_EMPLOYEE_ACTIVE()
        {
            int x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[PAYROLL].[spGET_COUNT_ACTIVE_EMPLOYEE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                  
                    x = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return x;
        }

        public int GET_COUNT_EMPLOYEE_SALARY_LOAN_ACTIVE()
        {
            int x = 0;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[PAYROLL].[spGET_COUNT_ACTIVE_SALARY_LOANS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    x = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return x;
        }


        //REVISED UPDATED 02.27.2019
        public DataTable GET_EMPLOYEE_ACTIVE_LOANS_STAT()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_COUNT_ACTIVE_LOANS_STAT]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_ACTIVE_LOANS_LOANS_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_ACTIVE_LOANS_LIST]");
            return dt;
        }

        public void UPDATE_SENIOR(string _empCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spUPDATE_EMPLOYEE_SENIOR]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }

        public void INSERT_UPDATE_WAGE_AREA_SETUP(string _wageCode, string _wageArea, double _wageAmount, string _supervisor,
                                                  double _srQuota, double _regQuota, double _wbQuota, double _sbQuota)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_WAGE_AREA_SETUP]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WAGECODE", _wageCode);
                    cmd.Parameters.AddWithValue("@WAGEAREA", _wageArea);
                    cmd.Parameters.AddWithValue("@WAGEAMOUNT", _wageAmount);
                    cmd.Parameters.AddWithValue("@SUPERVISOR", _supervisor);
                    cmd.Parameters.AddWithValue("@SRQUOTA", _srQuota);
                    cmd.Parameters.AddWithValue("@REGQUOTA", _regQuota);
                    cmd.Parameters.AddWithValue("@WBQUOTA", _wbQuota);
                    cmd.Parameters.AddWithValue("@SBQUOTA", _sbQuota);
                 
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void INSERT_UPDATE_PAYROLL_SETUP(string _empCode, string _payrollGroupCode, string _branchCode, double _basicRate, double _actualRate, bool _isSenior, bool _isBranchWife, bool _isDMPay, bool _isManualPay, bool _isActive)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_SALARY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@PAYROLLGROUPCODE", _payrollGroupCode);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    cmd.Parameters.AddWithValue("@BASICRATE", _basicRate);
                    cmd.Parameters.AddWithValue("@ACTUALRATE", _actualRate);
                    cmd.Parameters.AddWithValue("@ISSENIOR", _isSenior);
                    cmd.Parameters.AddWithValue("@ISBRANCHWIFE", _isBranchWife);
                    cmd.Parameters.AddWithValue("@ISDMPAY", _isDMPay);
                    cmd.Parameters.AddWithValue("@ISMANUALPAY", _isManualPay);
                    cmd.Parameters.AddWithValue("@ISACTIVE", _isActive);
                    

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }

        public void INSERT_UPDATE_PAYROLL_BRANCH_SETUP(string _empCode, string _branchCode, double _basicRate)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_BRANCH_SALARY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    cmd.Parameters.AddWithValue("@BASICRATE", _basicRate);
             
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }


        public void INSERT_UPDATE_BRANCH_WAGE_SETUP(string _branchCode, string _wageCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_BRANCH_WAGE_SETUP]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    cmd.Parameters.AddWithValue("@WAGECODE", _wageCode);
                   


                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }


        //INSERT UPDATE PAYROLL EMPLOYEE TRANSACTION
        public void INSERT_UPDATE_EMPLOYEE_PAYROLL_TRANS(int _ppId, string _empCode, double _basicRate, 
                                                         double _daysWork, double _daysPresent, double _regularHolidayQty, double _regularHoliday,
                                                         double _specialHolidayQty, double _specialHoliday, double _leaveQty, double _leave,
                                                         double _payOffQty, double _payOff, double _overTimeQty, double _overTime,
                                                         double _regHolidayOTQty, double _regHolidayOT, double _spcHolidayOTQty, double _spcHolidayOT,
                                                         double _daysAbsencesQty, double _daysAbsences,double _tardinessQty, double _tardiness,
                                                         double _underTimeQty, double _underTime,
                                                         double _sssPay, double _philHealthPay, double _hdmfPay,double _hdmfPayAdd,double _wTaxPay,
                                                         double _boardingLodging, double _cashAdvance, double _emergencyLoan, 
                                                         double _salaryLoan, double _sssLoan, double _pagibigLoan, double _salaryLoanBalance,
                                                         double _otherDeduction, double _grossIncome, double _taxableIncome, double _totalDeduction,
                                                         double _netPay, double _adjustment, double _adjustmentWTax)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_PAYROLL_TRANSACTION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PPID", _ppId);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@BASICRATE", _basicRate);
                   
                    cmd.Parameters.AddWithValue("@DAYSWORK", _daysWork);
                    cmd.Parameters.AddWithValue("@DAYSPRESENT", _daysPresent);
                    cmd.Parameters.AddWithValue("@REGULARHOLIDAYQTY", _regularHolidayQty);
                    cmd.Parameters.AddWithValue("@REGULARHOLIDAY", _regularHoliday);
                    cmd.Parameters.AddWithValue("@SPECIALHOLIDAYQTY", _specialHolidayQty);
                    cmd.Parameters.AddWithValue("@SPECIALHOLIDAY", _specialHoliday);
                    cmd.Parameters.AddWithValue("@LEAVEQTY", _leaveQty);
                    cmd.Parameters.AddWithValue("@LEAVE", _leave);
                    cmd.Parameters.AddWithValue("@PAYOFFQTY", _payOffQty);
                    cmd.Parameters.AddWithValue("@PAYOFF", _payOff);
                    cmd.Parameters.AddWithValue("@OVERTIMEQTY", _overTimeQty);
                    cmd.Parameters.AddWithValue("@OVERTIME", _overTime);
                    cmd.Parameters.AddWithValue("@REGHOLIDAYOTQTY", _regHolidayOTQty);
                    cmd.Parameters.AddWithValue("@REGHOLIDAYOT", _regHolidayOT);
                    cmd.Parameters.AddWithValue("@SPCHOLIDAYOTQTY", _spcHolidayOTQty);
                    cmd.Parameters.AddWithValue("@SPCHOLIDAYOT", _spcHolidayOT);
                    cmd.Parameters.AddWithValue("@DAYSABSENCESQTY", _daysAbsencesQty); 
                    cmd.Parameters.AddWithValue("@DAYSABSENCES", _daysAbsences);
                    cmd.Parameters.AddWithValue("@TARDINESSQTY", _tardinessQty);
                    cmd.Parameters.AddWithValue("@TARDINESS", _tardiness);
                    cmd.Parameters.AddWithValue("@UNDERTIMEQTY", _underTimeQty);
                    cmd.Parameters.AddWithValue("@UNDERTIME", _underTime);
                    cmd.Parameters.AddWithValue("@SSSPAY", _sssPay);
                    cmd.Parameters.AddWithValue("@PHILHEALTHPAY", _philHealthPay);
                    cmd.Parameters.AddWithValue("@HDMFPAY", _hdmfPay);
                    cmd.Parameters.AddWithValue("@HDMFPAYADD", _hdmfPayAdd);
                    cmd.Parameters.AddWithValue("@WTAXPAY", _wTaxPay);
                    cmd.Parameters.AddWithValue("@BOARDINGLODGING",_boardingLodging);
                    cmd.Parameters.AddWithValue("@CASHADVANCE", _cashAdvance);
                    cmd.Parameters.AddWithValue("@EMERGENCYLOAN", _emergencyLoan);
                    cmd.Parameters.AddWithValue("@SALARYLOAN", _salaryLoan);
                    cmd.Parameters.AddWithValue("@SSSLOAN", _sssLoan);
                    cmd.Parameters.AddWithValue("@PAGIBIGLOAN", _pagibigLoan);
                    cmd.Parameters.AddWithValue("@SALARYLOANBALANCE", _salaryLoanBalance);

                    cmd.Parameters.AddWithValue("@OTHERDEDUCTION", _otherDeduction);
                    cmd.Parameters.AddWithValue("@GROSSINCOME", _grossIncome);
                    cmd.Parameters.AddWithValue("@TAXABLEINCOME", _taxableIncome);
                    cmd.Parameters.AddWithValue("@TOTALDEDUCTION", _totalDeduction);
                    cmd.Parameters.AddWithValue("@NETPAY", _netPay);
                    cmd.Parameters.AddWithValue("@ADJUSTMENT", _adjustment);
                    cmd.Parameters.AddWithValue("@ADJUSTMENTWTAX", _adjustmentWTax);





                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }


        //INSERT UPDATE EMPLOYEE VOUCHER TRANSACTION
        public void INSERT_UPDATE_EMPLOYEE_VOUCHER_TRANS(int _ppid, string _empCode, double _actualRate, double _basicRate, double _computedRate, double _daysPresent, double _additionalAmount,
                                                        double _totalVoucherAmount, string _remarks)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_VOUCHER_TRANSACTION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PPID", _ppid);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@COMPUTEDRATE", _computedRate);
                    cmd.Parameters.AddWithValue("@DAYSPRESENT", _daysPresent);
                    cmd.Parameters.AddWithValue("@ACTUALRATE", _actualRate);
                    cmd.Parameters.AddWithValue("@BASICRATE", _basicRate);
                    cmd.Parameters.AddWithValue("@ADDITIONALAMOUNT", _additionalAmount);
                    cmd.Parameters.AddWithValue("@TOTALAMOUNT", _totalVoucherAmount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
         }

        public void INSERT_UPDATE_BRANCH_EMPLOYEE_INCENTIVES_TRANS(int _month, int _year, string _empCode, string _wageCode, string _branchCode, double _branchSales,
                                                                   double _totalSalesIncentives, double _daysPresent, double _empIncentivePercentage, double _empIncentiveAmount, double _empLessIncentiveAmout ,bool _isTransfer, string _remarks)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_BRANCH_EMPLOYEE_INCENTIVES_TRANSACTION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@WAGECODE", _wageCode);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    cmd.Parameters.AddWithValue("@BRANCHSALES", _branchSales);
                    cmd.Parameters.AddWithValue("@TOTALSALESINCENTIVES", _totalSalesIncentives);
                    cmd.Parameters.AddWithValue("@DAYSPRESENT", _daysPresent);
                    cmd.Parameters.AddWithValue("@EMPINCENTIVEPERCENTAGE", _empIncentivePercentage);
                    cmd.Parameters.AddWithValue("@EMPINCENTIVEAMOUNT", _empIncentiveAmount);
                    cmd.Parameters.AddWithValue("@EMPLESSINCENTIVEAMOUNT", _empLessIncentiveAmout);
                    cmd.Parameters.AddWithValue("@ISTRANSFER", _isTransfer);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);


                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    

        public void INSERT_PAYROLL_PERIOD(DateTime _startDate, DateTime _endDate)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_PAYROLL_PERIOD_SETUP]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DATESTART", _startDate);
                    cmd.Parameters.AddWithValue("@DATEEND", _endDate);



                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UPDATE_PAYROLL_PERIOD_DEFAULT(int _ppid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spUPDATE_PAYROLL_PERIOD_DEFAULT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PPID", _ppid);
                    
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        //LOAN INSERT AND UPDATE
        public void INSERT_UPDATE_EMPLOYEE_LOAN(string _loanSN, string _empCode, string _loanCode, DateTime _loanDate,
                                                double _loanAmount, string _remarks)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_LOAN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LOANSN", _loanSN);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@LOANCODE", _loanCode);
                    cmd.Parameters.AddWithValue("@LOANDATE", _loanDate);
                    cmd.Parameters.AddWithValue("@LOANAMOUNT", _loanAmount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);



                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }



        }

        //ADD LOAN
        public void INSERT_UPDATE_ADD_LOAN(string _loanSN, string _loanCode, DateTime _loanDate, double _loanAmount, string _remarks)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_LOAN_DETAILS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LOANSN", _loanSN);
                    cmd.Parameters.AddWithValue("@LOANCODE", _loanCode);
                    cmd.Parameters.AddWithValue("@LOANDATE", _loanDate);
                    cmd.Parameters.AddWithValue("@LOANAMOUNT", _loanAmount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);



                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }


        //LOAN EMPLOYEE PAYMENT
        public void INSERT_UPDATE_EMPLOYEE_LOAN_PAYMENT(string _loanPaymentOR, string _loanSN, DateTime _paymentDate, double _paymentAmount, string _paymentRemarks, string _reference)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_LOAN_PAYMENT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LOANPAYMENTOR", _loanPaymentOR);
                    cmd.Parameters.AddWithValue("@LOANSN", _loanSN);
                    cmd.Parameters.AddWithValue("@PAYMENTDATE", _paymentDate);
                    cmd.Parameters.AddWithValue("@PAYMENTAMOUNT", _paymentAmount);
                    cmd.Parameters.AddWithValue("@PAYMENTREMARKS", _paymentRemarks);
                    cmd.Parameters.AddWithValue("@REFERENCE", _reference);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }


        //LEAVE SETUP

        public DataTable GET_EMPLOYEE_LIST_LEAVE_SETUP()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Payroll].[spGET_EMPLOYEE_LIST_LEAVE_SETUP]");
            return dt;
        }

        public void INSERT_UPDATE_EMPLOYEE_LEAVES_SETUP(string _empCode, int _yearApplied, double _credit)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_LEAVES_SETUP]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@YEAR_APPLIED", _yearApplied);
                    cmd.Parameters.AddWithValue("@CREDIT", _credit);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        
        //LEAVE TRANSACTIONS 12.28.2018
        public void INSERT_UPDATE_EMPLOYEE_LEAVES(string _empCode, string _leaveTypeCode, DateTime _dateApplied, DateTime _dateFrom, 
                                DateTime _dateTo,double _daysCount, string _remarks, int _yearApplied)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spINSERT_UPDATE_EMPLOYEE_LEAVES]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@LEAVETYPECODE", _leaveTypeCode);
                    cmd.Parameters.AddWithValue("@DATEAPPLIED", _dateApplied);
                    cmd.Parameters.AddWithValue("@DATEFROM", _dateFrom);
                    cmd.Parameters.AddWithValue("@DATETO", _dateTo);
                    cmd.Parameters.AddWithValue("@DAYSCOUNT", _daysCount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                    cmd.Parameters.AddWithValue("@YEARAPPLIED", _yearApplied);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //LOAN LINK AND UNLINK PAYROLL DEDUCTION
        public void UPDATE_LINK_EMPLOYEE_SALARY_LOAN_DEDUCTION(string _loanSN)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spUPDATE_LINK_EMPLOYEE_SALARY_LOAN_DEDUCTION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LOANSN", _loanSN);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void REMOVE_BRANCH_EMPLOYEE_TRANSFER(int _month, int _year, string _empCode, string _branchCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spREMOVE_BRANCH_EMPLOYEE_TRANSFER]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@EMPCODE", _empCode);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*
        This function will remove the initial data with zero value in days present
        01.31.2019
        */
        public void REFRESH_BRANCH_INCENTIVE_LIST(int _month, int _year, string _wageCode, string _branchCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Payroll].[spREFRESH_BRANCH_INCENTIVE_LIST]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MONTH", _month);
                    cmd.Parameters.AddWithValue("@YEAR", _year);
                    cmd.Parameters.AddWithValue("@WAGECODE", _wageCode);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
