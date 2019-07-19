using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DGMU_HR
{
   
    public class Utility_C : Base_C
    {

        #region "GET / SELECT METHOD"

        public DataTable GET_GENDER_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_GENDER]");
            return dt;
        }

        //RELIGION
        public DataTable GET_RELIGION_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_RELIGION]");
            return dt;
        }


        //CITIZENSHIP
        public DataTable GET_CITIZENSHIP_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_CITIZENSHIP]");
            return dt;
        }

        //EMPLOYMENT STATUS
        public DataTable GET_EMPLOYMENT_STATUS()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_EMPLOYMENT_STATUS]");
            return dt;
        }

        //DEPARTMENT
        public DataTable GET_DEPARTMENT_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_DEPARTMENT]");
            return dt;
        }

        //DESIGNATION
        public DataTable GET_POSITION_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_POSITION]");
            return dt;
        }

        //MARITAL STATUS
        public DataTable GET_MARITAL_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_MARITAL]");
            return dt;
        }

        //JOB POSTING
        public DataTable GET_JOB_POSTING_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_JOB_POSTING]");
            return dt;
        }

        //BLOOD TYPE
        public DataTable GET_BLOOD_TYPE_DATA()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_BLOOD_TYPE]");
            return dt;
        }


        //BRANCH LIST FOR PAYROLL
        public DataTable GET_BRANCH_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[Master].[GET_BRANCH_DATA]");
            return dt;
        }





        #endregion

        #region "DATA MANIPULATION"

        public void INSERT_BRANCH(string _branchCode, string _branchName)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[Utility].[INSERT_BRANCH]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BRANCHCODE", _branchCode);
                    cmd.Parameters.AddWithValue("@BRANCHNAME", _branchName);


                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion



    }

}
