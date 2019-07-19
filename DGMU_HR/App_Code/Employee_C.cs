using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DGMU_HR
{
    public class Employee_C : Base_C

    
    {
    
    }
    

    public class Employee_Data_C : Base_C
    {

        #region "RETRIEVAL DATA"
        public byte[] GET_EMPLOYEE_IMAGE(string _employeeID)
        {
            byte[] x;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_IMAGE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);


                    cn.Open();

                    try
                    {
                        x = (byte[])cmd.ExecuteScalar();
                    }
                    catch
                    { x = null; }

                }
            }

            return x;
        }

        public byte[] GET_EMPLOYEE_FINGER_PRINT(string _employeeID)
        {
            byte[] x;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_FINGERPRINT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);


                    cn.Open();

                    try
                    {
                        x = (byte[])cmd.ExecuteScalar();
                    }
                    catch
                    { x = null; }

                }
            }

            return x;
        }


        public DataTable GET_EMPLOYEE_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_EMPLOYEE_LIST]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_LIST_LW()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_EMPLOYEE_LIST_LW]");
            return dt;
        
        }

        public DataTable GET_EMPLOYEE_EMPLOYMENT_STAT()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_EMPLOYEE_EMPLOYMENT_STATUS_STAT]");
            return dt;
        }

        //02.27.2019
        public DataTable GET_EMPLOYEE_UPCOMING_LEAVES()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_EMPLOYEE_UPCOMING_LEAVES]");
            return dt;
        }

        public DataTable GET_EMPLOYEE_SKILLS_TRAINING(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_SKILLSTRAINING]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }


        #endregion

        #region "CREATE AND UPDATE DATA"

        public void INSERT_EMPLOYEE_INFORMATION(string _employeeID, string _lastname, string _firstname, string _middleName, string _nickName,
                                                string _genderCode, string _maritalCode, DateTime _dateOfBirth, string _placeOfBirth, string _weight, string _height,
                                                string _landLineNumber, string _mobileNumber, string _religionCode, string _citizenshipCode,
                                                string _presentAddress, string _provincialAddress,
                                                string _tin, string _sss, string _hdmf, string _philHealth, DateTime _dateHired, string _companyCode,string _departmentCode,
                                                string _positionCode, string _employmentStatusCode, DateTime _dateApplied, string _jpCode, string _applicantEvaluation, string _bloodType,
                                                string _contactPerson, string _contactRelationship, string _contactNumber)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_DATA]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID",_employeeID);
                    cmd.Parameters.AddWithValue("@LAST_NAME", _lastname);
                    cmd.Parameters.AddWithValue("@FIRST_NAME", _firstname);
                    cmd.Parameters.AddWithValue("@MIDDLE_NAME", _middleName);
                    cmd.Parameters.AddWithValue("@NICK_NAME", _nickName);
                    cmd.Parameters.AddWithValue("@GENDERCODE", _genderCode);
                    cmd.Parameters.AddWithValue("@MARITALCODE", _maritalCode);
                    cmd.Parameters.AddWithValue("@DATE_OF_BIRTH", _dateOfBirth);
                    cmd.Parameters.AddWithValue("@PLACE_OF_BIRTH", _placeOfBirth);
                    cmd.Parameters.AddWithValue("@WEIGHT", _weight);
                    cmd.Parameters.AddWithValue("@HEIGHT", _height);
                    cmd.Parameters.AddWithValue("@LANDLINE_NUMBER", _landLineNumber);
                    cmd.Parameters.AddWithValue("@MOBILE_NUMBER", _mobileNumber);
                    cmd.Parameters.AddWithValue("@RELIGIONCODE", _religionCode);
                    cmd.Parameters.AddWithValue("@CITIZENSHIPCODE", _citizenshipCode);
                    cmd.Parameters.AddWithValue("@PRESENT_ADDRESS", _presentAddress);
                    cmd.Parameters.AddWithValue("@PROVINCIAL_ADDRESS", _provincialAddress);

                    cmd.Parameters.AddWithValue("@TIN", _tin);
                    cmd.Parameters.AddWithValue("@SSS", _sss);
                    cmd.Parameters.AddWithValue("@HDMF", _hdmf);
                    cmd.Parameters.AddWithValue("@PHILHEALTH", _philHealth);
                    cmd.Parameters.AddWithValue("@DATE_HIRED", _dateHired);
                    cmd.Parameters.AddWithValue("@COMPANYCODE", _companyCode);
                    cmd.Parameters.AddWithValue("@DEPARTMENTCODE", _departmentCode);
                    cmd.Parameters.AddWithValue("@POSITIONCODE", _positionCode);
                    cmd.Parameters.AddWithValue("@EMPLOYMENTSTATUSCODE", _employmentStatusCode);

                  

                    cmd.Parameters.AddWithValue("@DATE_APPLIED", _dateApplied);
                    cmd.Parameters.AddWithValue("@JPCODE", _jpCode);
                    cmd.Parameters.AddWithValue("@APPLICANT_EVALUATION", _applicantEvaluation);

                    cmd.Parameters.AddWithValue("@BLOOD_TYPE", _bloodType);

                    cmd.Parameters.AddWithValue("@CONTACTPERSON", _contactPerson);
                    cmd.Parameters.AddWithValue("@CONTACTRELATIONSHIP", _contactRelationship);
                    cmd.Parameters.AddWithValue("@CONTACTNUMBER", _contactNumber);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }


        public void INSERT_EMPLOYEE_FAMILY(string _employeeID, string _fName, string _fContact, string _mName, string _mContact, int _siblingCount,
                                            string _sLastName, string _sFirstName, string _sMiddleName, string _sContact)
        {

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_FAMILY_DATA]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@F_NAME", _fName);
                    cmd.Parameters.AddWithValue("@F_CONTACT", _fContact);
                    cmd.Parameters.AddWithValue("@M_NAME", _mName);
                    cmd.Parameters.AddWithValue("@M_CONTACT", _mContact);
                    cmd.Parameters.AddWithValue("@SIBLING_COUNT", _siblingCount);
                    cmd.Parameters.AddWithValue("@S_LASTNAME", _sLastName);
                    cmd.Parameters.AddWithValue("@S_FIRSTNAME", _sFirstName);
                    cmd.Parameters.AddWithValue("@S_MIDDLENAME", _sMiddleName);
                    cmd.Parameters.AddWithValue("@S_CONTACT", _sContact);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UPDATE_EMPLOYEE_INFORMATION(string _employeeID, int _imageSize, byte[] _image_data)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spUPDATE_EMPLOYEE_DATA]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@SIZE", _imageSize);
                    cmd.Parameters.AddWithValue("@IMAGE_DATA", _image_data);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        
        public void INSERT_EMPLOYEE_PICTURE(string _employeeID, string _picture_name, int _size, byte[] _image_data)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_PICTURE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@PICTURE_NAME", _picture_name);
                    cmd.Parameters.AddWithValue("@SIZE", _size);
                    cmd.Parameters.AddWithValue("@IMAGE_DATA", _image_data);


                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void INSERT_UPDATE_EMPLOYEE_EDUCATION(string _employeeID, string _primarySchoolName, string _primaryYG, string _secondarySchoolName, string _secondaryYG,
                                                     string _tertiarySchoolName, string _tertiaryYG, string _course, bool _isGraduate)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERTUPDATE_EMPLOYEE_EDUCATION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@PRIMARYSCHOOLNAME", _primarySchoolName);
                    cmd.Parameters.AddWithValue("@PRIMARYYG", _primaryYG);
                    cmd.Parameters.AddWithValue("@SECONDARYSCHOOLNAME", _secondarySchoolName);
                    cmd.Parameters.AddWithValue("@SECONDARYYG", _secondaryYG);
                    cmd.Parameters.AddWithValue("@TERTIARYSCHOOLNAME", _tertiarySchoolName);
                    cmd.Parameters.AddWithValue("@TERTIARYYG", _tertiaryYG);
                    cmd.Parameters.AddWithValue("@COURSE", _course);
                    cmd.Parameters.AddWithValue("@ISGRADUATE", _isGraduate);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //INSERT NEW RECORD OF SKILLS AND TRAINNG
        public void INSERT_UPDATE_EMPLOYEE_SKILLSTRAINING(string _employeeID, string _skillsTraining, string _trainingCenter, DateTime _endTrainingDate)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERTUPDATE_EMPLOYEE_SKILLSTRAINING]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@SKILLSTRAINING", _skillsTraining);
                    cmd.Parameters.AddWithValue("@TRAININGCENTER", _trainingCenter);
                    cmd.Parameters.AddWithValue("@ENDTRAININGDATE", _endTrainingDate);
                    
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //REMOVE SKILLS AND TRAINING
        public void REMOVE_EMPLOYEE_SKILLSTRAINING(int _id)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_SKILLS_TRAINING]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);
               
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        #endregion


    }

}
