using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DGMU_HR
{
    public class SystemX:Base_C
    {

        public DataTable GET_COMPANY_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[xSYSTEM].[spGET_COMPANY]");
            return dt;
        }

        public int SERIESNUMBER { get; set; }

        public string GENERATE_SERIES_NUMBER_EMPLOYEE(string _prefixCode)
        {
            SERIESNUMBER = 0;
            string PrefixCode = "";
            string PrefixAppend = "";
            string AutoNumber = "";
            bool bIsNumberOnly = false;

            //try
            //{
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("xSystem.GET_SERIES_NUMBER", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PREFIXCODE", _prefixCode);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            PrefixCode = dr["PrefixCode"].ToString();
                            PrefixAppend = dr["PrefixAppend"].ToString();
                            bIsNumberOnly = (bool)dr["IsNumberOnly"];

                            if ((int)dr["Series"] > 0)
                            {

                                SERIESNUMBER = (int)dr["Series"] + 1;

                                /*Format Transaction AutoNumber
                                 * UP TO 99999 AutoNumbers
                                 */

                                if (SERIESNUMBER > 9999)
                                {
                                    if (bIsNumberOnly)
                                    {
                                        AutoNumber = SERIESNUMBER.ToString();
                                    }
                                    else
                                    {
                                        AutoNumber = PrefixAppend + '-' + SERIESNUMBER;
                                    }
                                }
                                else if (SERIESNUMBER > 999)
                                {
                                    if (bIsNumberOnly)
                                    {
                                        AutoNumber = "0"  + SERIESNUMBER;
                                    }
                                    else
                                    {
                                        AutoNumber = PrefixAppend + "-0" + SERIESNUMBER;
                                    }
                                }
                                else if (SERIESNUMBER > 99)
                                {
                                    if (bIsNumberOnly)
                                    {
                                        AutoNumber = "00" + SERIESNUMBER;
                                    }
                                    else
                                    {
                                        AutoNumber = PrefixAppend + "-00" + SERIESNUMBER;
                                    }

                                }

                                else if (SERIESNUMBER > 9)
                                {
                                    if (bIsNumberOnly)
                                    {
                                        AutoNumber = "000" + SERIESNUMBER;
                                    }
                                    else
                                    {
                                        AutoNumber = PrefixAppend + "-000" + SERIESNUMBER;
                                    }

                                }

                                else
                                {
                                    if (bIsNumberOnly)
                                    {
                                        AutoNumber = "0000" + SERIESNUMBER;
                                    }
                                    else
                                    {
                                        AutoNumber = PrefixAppend + "-0000" + SERIESNUMBER;
                                    }
                                }

                            }

                            else
                            {
                                SERIESNUMBER = SERIESNUMBER + 1;
                                if (bIsNumberOnly)
                                {
                                    AutoNumber = "0000" + SERIESNUMBER;
                                }
                                else
                                {
                                    AutoNumber = PrefixAppend + "-0000" + SERIESNUMBER;
                                }


                            }
                        }

                    }


                }
            }

            //}

            //catch { 

            //}


            return AutoNumber;

        }


        public DateTime GET_SERVER_DATE_TIME()
        {
            DateTime ServerDT;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[xSystem].[GET_SERVER_DATE_TIME]", cn))
                {

                    cn.Open();

                    ServerDT = (DateTime)cmd.ExecuteScalar();
                }

                return ServerDT;
            }
        }

        public DataSet GET_USER_MENU()
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_MENU]", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }

            return ds;
        }


        public DataTable GET_USER_INFO(string _userCode, string _password)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[xSystem].[spVALIDATE_USER]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USERCODE", _userCode);
                    cmd.Parameters.AddWithValue("PASSWORD", _password);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        //CHECKING Date Input
        public bool CHECK_VALID_DATE(string _input)
        {
            var dateFormats = new[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" };
            DateTime dateInput;

            bool valid_Date = DateTime.TryParseExact(_input,dateFormats, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out dateInput);

            return valid_Date;
        }

        public DataTable GET_FISCAL_YEAR_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[xSystem].[spGET_FISCAL_YEAR]");
            return dt;
        }

        public int GET_DEFAULT_FISCAL_YEAR()
        {
            int x = 0;

            DataTable dt = GET_FISCAL_YEAR_LIST();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "fStatus = '" + true + "'";
            if (dv.Count > 0)
            {
                foreach (DataRowView dvr in dv)
                {
                    x = (int)dvr["Year"];
                }
            }
            else
            {
                x = 0;
            }

            return x;
        }

        //Get list of Months
        public DataTable GET_MONTHS_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[xSystem].[spGET_MONTHS_LIST]");
            return dt;
        }

      


        public void INSERT_PAYROLL_YEAR(int _year)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[xSystem].[spINSERT_PAYROLL_YEAR_SETUP]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@YEAR", _year);


                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UPDATE_PAYROLL_YEAR_DEFAULT(int _id)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[xSystem].[spUPDATE_PAYROLL_YEAR_DEFAULT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}