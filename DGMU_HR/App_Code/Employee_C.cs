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

        public Employee_Data_C()
        {
            //Call Update Effictivity Resign
            RESIGN_EFFECTIVITY_PROCESS();
        }

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


        //public DataTable GET_EMPLOYEE_LIST()
        //{
        //    DataTable dt = new DataTable();
        //    dt = queryCommandDT_StoredProc("[HR].[spGET_EMPLOYEE_LIST]");
        //    return dt;
        //}

        //Revised version 2
        public DataTable GET_EMPLOYEE_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_FULL_EMPLOYEE_LIST]");
            return dt;
        }

        public DataTable GET_ALL_EMPLOYEE_LIST_LW()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_ALL_EMPLOYEE_LIST_LW]");
            return dt;

        }
        public DataTable GET_ACTIVE_EMPLOYEE_LIST_LW()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_ACTIVE_EMPLOYEE_LIST_LW]");
            return dt;

        }

        //List of Employee for Active with Leaves 05.15.2020
        public DataTable GET_ACTIVE_EMPLOYEE_LIST_LW_LEAVES()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("[HR].[spGET_ACTIVE_EMPLOYEE_LIST_LW_LEAVES]");
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

        //Employment History
        public DataTable GET_EMPLOYEE_EMPLOYMENT_HISTORY(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_EMPLOYMENT_HISTORY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        //CHILDREN FAMILY 10.29.2019

        public DataTable GET_EMPLOYEE_FAMILY_CHILDREN(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_CHILDREN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public void INSERT_UPDATE_EMPOYEE_FAMILY_CHILDREN(string _employeeID, string _childrenName, string _genderCode, DateTime _dob, int _idTemp)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_CHILDREN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@CHILDNAME", _childrenName);
                    cmd.Parameters.AddWithValue("@GENDERCODE", _genderCode);
                    cmd.Parameters.AddWithValue("@DOB", _dob);
                    cmd.Parameters.AddWithValue("@IDTEMP", _idTemp);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void REMOVE_FAMILY_CHILDREN(int _ID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_EMPLOYEE_CHILDREN]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", _ID);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

      

        #endregion

        #region "CREATE AND UPDATE DATA"

        //public void INSERT_EMPLOYEE_INFORMATION(string _employeeID, string _lastname, string _firstname, string _middleName, string _nickName,
        //                                        string _genderCode, string _maritalCode, DateTime _dateOfBirth, string _placeOfBirth, string _weight, string _height,
        //                                        string _landLineNumber, string _mobileNumber, string _religionCode, string _citizenshipCode,
        //                                        string _presentAddress, string _provincialAddress,
        //                                        string _tin, string _sss, string _hdmf, string _philHealth, DateTime _dateHired, string _companyCode, string _departmentCode,
        //                                        string _positionCode, string _employmentStatusCode, DateTime _dateApplied, string _jpCode, string _applicantEvaluation, string _bloodType,
        //                                        string _contactPerson, string _contactRelationship, string _contactNumber)
        //{
        //    using (SqlConnection cn = new SqlConnection(CS))
        //    {

        //        using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_DATA]", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
        //            cmd.Parameters.AddWithValue("@LAST_NAME", _lastname);
        //            cmd.Parameters.AddWithValue("@FIRST_NAME", _firstname);
        //            cmd.Parameters.AddWithValue("@MIDDLE_NAME", _middleName);
        //            cmd.Parameters.AddWithValue("@NICK_NAME", _nickName);
        //            cmd.Parameters.AddWithValue("@GENDERCODE", _genderCode);
        //            cmd.Parameters.AddWithValue("@MARITALCODE", _maritalCode);
        //            cmd.Parameters.AddWithValue("@DATE_OF_BIRTH", _dateOfBirth);
        //            cmd.Parameters.AddWithValue("@PLACE_OF_BIRTH", _placeOfBirth);
        //            cmd.Parameters.AddWithValue("@WEIGHT", _weight);
        //            cmd.Parameters.AddWithValue("@HEIGHT", _height);
        //            cmd.Parameters.AddWithValue("@LANDLINE_NUMBER", _landLineNumber);
        //            cmd.Parameters.AddWithValue("@MOBILE_NUMBER", _mobileNumber);
        //            cmd.Parameters.AddWithValue("@RELIGIONCODE", _religionCode);
        //            cmd.Parameters.AddWithValue("@CITIZENSHIPCODE", _citizenshipCode);
        //            cmd.Parameters.AddWithValue("@PRESENT_ADDRESS", _presentAddress);
        //            cmd.Parameters.AddWithValue("@PROVINCIAL_ADDRESS", _provincialAddress);

        //            cmd.Parameters.AddWithValue("@TIN", _tin);
        //            cmd.Parameters.AddWithValue("@SSS", _sss);
        //            cmd.Parameters.AddWithValue("@HDMF", _hdmf);
        //            cmd.Parameters.AddWithValue("@PHILHEALTH", _philHealth);
        //            cmd.Parameters.AddWithValue("@DATE_HIRED", _dateHired);
        //            cmd.Parameters.AddWithValue("@COMPANYCODE", _companyCode);
        //            cmd.Parameters.AddWithValue("@DEPARTMENTCODE", _departmentCode);
        //            cmd.Parameters.AddWithValue("@POSITIONCODE", _positionCode);
        //            cmd.Parameters.AddWithValue("@EMPLOYMENTSTATUSCODE", _employmentStatusCode);



        //            cmd.Parameters.AddWithValue("@DATE_APPLIED", _dateApplied);
        //            cmd.Parameters.AddWithValue("@JPCODE", _jpCode);
        //            cmd.Parameters.AddWithValue("@APPLICANT_EVALUATION", _applicantEvaluation);

        //            cmd.Parameters.AddWithValue("@BLOOD_TYPE", _bloodType);

        //            cmd.Parameters.AddWithValue("@CONTACTPERSON", _contactPerson);
        //            cmd.Parameters.AddWithValue("@CONTACTRELATIONSHIP", _contactRelationship);
        //            cmd.Parameters.AddWithValue("@CONTACTNUMBER", _contactNumber);

        //            cn.Open();

        //            cmd.ExecuteNonQuery();

        //        }
        //    }
        //}


        //UPDATE 10.29.2019

        public void INSERT_UPDATE_EMPLOYEE_INFORMATION(string _employeeID, string _lastname, string _firstname, string _middleName, string _nickName,
                                               string _genderCode, string _maritalCode, DateTime _dateOfBirth, string _placeOfBirth, string _weight, string _height,
                                               string _landLineNumber, string _mobileNumber, string _religionCode, string _citizenshipCode,
                                               string _presentAddress, string _provincialAddress, string _bloodType)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_BASIC_DATA]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
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
                    
                    cmd.Parameters.AddWithValue("@BLOOD_TYPE", _bloodType);

                  
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }


        //10.22.2019
        public void INSERT_UPDATE_EMPLOYEE_EMPLOYMENT_DETAILS(string _employeeID, DateTime _dateHired, string _companyCode, string _departmentCode,
                                                               string _positionCode, string _employmentStatusCode, string _employmentTypeCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYMENT_DETAILS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@DATE_HIRED", _dateHired);
                    cmd.Parameters.AddWithValue("@COMPANYCODE", _companyCode);
                    cmd.Parameters.AddWithValue("@DEPARTMENTCODE", _departmentCode);
                    cmd.Parameters.AddWithValue("@POSITIONCODE", _positionCode);
                    cmd.Parameters.AddWithValue("@EMPLOYMENTSTATUSCODE", _employmentStatusCode);
                    cmd.Parameters.AddWithValue("@EMPLOYMENTTYPECODE", _employmentTypeCode);
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //10.22.2019
        public void INSERT_UPDATE_EMPLOYEE_GOVT_ID(string _employeeID, string _tin, string _sss, string _hdmf, string _philHealth, string _billingCompanyCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_GOVT_ID]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@TIN", _tin);
                    cmd.Parameters.AddWithValue("@SSS", _sss);
                    cmd.Parameters.AddWithValue("@HDMF", _hdmf);
                    cmd.Parameters.AddWithValue("@PHILHEALTH", _philHealth);
                    cmd.Parameters.AddWithValue("@BILLINGCOMPANYCODE", _billingCompanyCode);
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //10.22.2019
        public void INSERT_UPDATE_EMPLOYEE_APPLICATION_RECORD(string _employeeID, DateTime _dateApplied, string _jpCode, string _applicantEvaluation)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_APPLICATION_RECORD]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@DATE_APPLIED", _dateApplied);
                    cmd.Parameters.AddWithValue("@JPCODE", _jpCode);
                    cmd.Parameters.AddWithValue("@APPLICANT_EVALUATION", _applicantEvaluation);
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        
        //****** COMMENTED 10.29.2019 *********
        //CREATE NEW FUNCTION WHICH INCLUDED INCASE OF EMERGENCY

        //public void INSERT_EMPLOYEE_FAMILY(string _employeeID, string _fName, string _fContact, string _mName, string _mContact, int _siblingCount,
        //                                    string _sLastName, string _sFirstName, string _sMiddleName, string _sContact)
        //{

        //    using (SqlConnection cn = new SqlConnection(CS))
        //    {

        //        using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_FAMILY_DATA]", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
        //            cmd.Parameters.AddWithValue("@F_NAME", _fName);
        //            cmd.Parameters.AddWithValue("@F_CONTACT", _fContact);
        //            cmd.Parameters.AddWithValue("@M_NAME", _mName);
        //            cmd.Parameters.AddWithValue("@M_CONTACT", _mContact);
        //            cmd.Parameters.AddWithValue("@SIBLING_COUNT", _siblingCount);
        //            cmd.Parameters.AddWithValue("@S_LASTNAME", _sLastName);
        //            cmd.Parameters.AddWithValue("@S_FIRSTNAME", _sFirstName);
        //            cmd.Parameters.AddWithValue("@S_MIDDLENAME", _sMiddleName);
        //            cmd.Parameters.AddWithValue("@S_CONTACT", _sContact);

        //            cn.Open();

        //            cmd.ExecuteNonQuery();

        //        }
        //    }
        //}

        public void INSERT_UPDATE_EMPLOYEE_FAMILY(string _employeeID, string _fName, string _fContact, string _mName, string _mContact, int _siblingCount,
                                            string _sLastName, string _sFirstName, string _sMiddleName, string _sContact,
                                            string _contactPerson, string _contactNumber, string _contactRelationship)
        {

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_FAMILY_DATA]", cn))
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
                    cmd.Parameters.AddWithValue("@CONTACTPERSON", _contactPerson);
                    cmd.Parameters.AddWithValue("@CONTACTNUMBER", _contactNumber);
                    cmd.Parameters.AddWithValue("@CONTACTRELATIONSHIP", _contactRelationship);

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



        #region "PICTURES AND ATTACHMENTS"
        //10.01.2019
        public DataTable GET_EMPLOYEE_ATTACHMENTS(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_ATTACHMENTS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public string GET_EMPLOYEE_PICTURE(string _employeeID)
        {
            string picturePath = "";

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_PICTURE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);


                    cn.Open();

                    try
                    {
                        picturePath = (string)cmd.ExecuteScalar();
                    }
                    catch {
                        picturePath = "";
                    }

                }
            }

            return picturePath;
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

        //05.03.2020
        public void INSERT_UPDATE_EMPLOYEE_PICTURE(string _employeeID, string _picturePath)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_PICTURE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@PICTURE_PATH", _picturePath);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void INSERT_EMPLOYEE_ATTACHMENT(string _employeeID, string _fileName, string _title, string _filePath)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_ATTACHMENT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@FILENAME", _fileName);
                    cmd.Parameters.AddWithValue("@TITLE", _title);
                    cmd.Parameters.AddWithValue("@FILEPATH", _filePath);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //REMOVE ATTACHMENT
        public void REMOVE_EMPLOYEE_ATTACHMENT(int _empAttachmentID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_EMPLOYEE_ATTACHMENTS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPATTACHMENTID", _empAttachmentID);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }

        }
        #endregion


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
        public void INSERT_UPDATE_EMPLOYEE_SKILLSTRAINING(string _employeeID, string _skillsTraining, string _trainingCenter,DateTime _startTrainingDate, DateTime _endTrainingDate, bool _isCompanySponsor)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERTUPDATE_EMPLOYEE_SKILLSTRAINING]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@SKILLSTRAINING", _skillsTraining);
                    cmd.Parameters.AddWithValue("@TRAININGCENTER", _trainingCenter);
                    cmd.Parameters.AddWithValue("@STARTTRAININGDATE", _startTrainingDate);
                    cmd.Parameters.AddWithValue("@ENDTRAININGDATE", _endTrainingDate);
                    cmd.Parameters.AddWithValue("@ISCOMPANYSPONSOR", _isCompanySponsor);
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }



        //EMPLOYMENT HISTORY 10.29.2019
        public void INSERT_UPDATE_EMPLOYEE_EMPLOYMENT_HISTORY(string _employeeID, string _companyName, string _companyAddress, string _position, DateTime _dateStarted, DateTime _dateEnded, string _remarks)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_PREVIOUS_EMPLOYMENT_HISTORY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@COMPANYNAME", _companyName);
                    cmd.Parameters.AddWithValue("@COMPANYADDRESS", _companyAddress);
                    cmd.Parameters.AddWithValue("@POSITION", _position);
                    cmd.Parameters.AddWithValue("@DATESTARTED", _dateStarted);
                    cmd.Parameters.AddWithValue("@DATEENDED", _dateEnded);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void REMOVE_EMPLOYEE_EMPLOYMENT_HISTORY(int _id)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_EMPLOYMENT_HISTORY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);

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

        /*EMPLOYEE REMOVE DATA 12.09.2019 */
        public void REMOVE_EMPLOYEE_DATA(string _employeeID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_EMPLOYEE_DATA]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /*WORK EVALUATION INSERT-UPDATE
        */
        public void INSERT_EMPLOYEE_WORK_EVALUATION(string _employeeID, string _wecCode, string _werCode, string _generalRemarks, DateTime _dateStart, DateTime _dateEnd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_EMPLOYEE_WORK_EVALUATION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@WEC_CODE", _wecCode);
                    cmd.Parameters.AddWithValue("@WER_CODE", _werCode);
                    cmd.Parameters.AddWithValue("@GENERAL_REMARKS", _generalRemarks);
                    cmd.Parameters.AddWithValue("@DATESTART", _dateStart);
                    cmd.Parameters.AddWithValue("@DATEEND", _dateEnd);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UPDATE_EMPLOYEE_WORK_EVALUATION(int _weID, string _wecCode, string _werCode, string _generalRemarks, DateTime _dateStart, DateTime _dateEnd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spUPDATE_EMPLOYEE_WORK_EVALUATION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WE_ID", _weID);
                    cmd.Parameters.AddWithValue("@WEC_CODE", _wecCode);
                    cmd.Parameters.AddWithValue("@WER_CODE", _werCode);
                    cmd.Parameters.AddWithValue("@GENERAL_REMARKS", _generalRemarks);
                    cmd.Parameters.AddWithValue("@DATESTART", _dateStart);
                    cmd.Parameters.AddWithValue("@DATEEND", _dateEnd);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }



        #endregion
        public string GET_EMPLOYEE_WORK_EVALUATION_REMARKS(string _employeeID)
        {
            string x = "";

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_WORK_EVALUATION_REMARKS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);


                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            x = dr["GeneralRemarks"].ToString();
                        }
                    }
                }

                return x;
            }


        }
      
        public DataTable GET_EMPLOYEE_WORK_EVALUATION_RESULT(int _weID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_WORK_EVALUATION_RESULT]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WE_ID", _weID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GET_EMPLOYEE_WORK_EVALUATION_RECORD(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_WORK_EVALUATION_RECORD]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        /*
        EMPLOYEE OFFENSES
        */
        public void INSERT_UPDATE_EMPLOYEE_OFFENSES(string _employeeID, string _offenseTitle, string _offenseDetails, string _offenseRecommendation)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERTUPDATE_EMPLOYEE_OFFENSES]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@OFFENSE_TITLE", _offenseTitle);
                    cmd.Parameters.AddWithValue("@OFFENSE_DETAILS", _offenseDetails);
                    cmd.Parameters.AddWithValue("@OFFENSE_RECOMMENDATION", _offenseRecommendation);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public DataTable GET_EMPLOYEE_OFFENSES(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_OFFENSES]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public void REMOVE_EMPLOYEE_OFFENSE(int _offenseID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_EMPLOYEE_OFFENSE]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OFFENSE_ID", _offenseID);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /*
        TRANSFER OF EMPLOYEE COMPANY
        09.20.2019
        */

        public DataTable GET_EMPLOYEE_COMPANY_TRANSFER(string _employeeID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_EMPLOYEE_COMPANY_HISTORY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
        public void INSERT_UPDATE_EMPLOYEE_COMPANY_TRANSFER(string _employeeID, string _companyCode, string _oldCompanyCode, DateTime _transferDate, string _remarks)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_TRANSFER]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@COMPANYCODE", _companyCode);
                    cmd.Parameters.AddWithValue("@OLDCOMPANYCODE", _oldCompanyCode);
                    cmd.Parameters.AddWithValue("@TRANSFERDATE", _transferDate);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }


        /*
        END OF SERVICES SECTION
            */

        public DataTable GET_END_OF_SERVICES_LIST()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spGET_RESIGN_APPLICATION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public void INSERT_UPDATE_EMPLOYEE_ENDOFSERVICE(string _employeeID, string _eosCode, string _eosRemarks, 
                                                        DateTime _eosApplyDate, DateTime _eosEffectiveDate, 
                                                        bool _isCancel)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spINSERT_UPDATE_EMPLOYEE_EOS]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);
                    cmd.Parameters.AddWithValue("@EOS_CODE", _eosCode);
                    cmd.Parameters.AddWithValue("@EOS_REMARKS", _eosRemarks);
                    cmd.Parameters.AddWithValue("@EOS_APPLY_DATE", _eosApplyDate);
                    cmd.Parameters.AddWithValue("@EOS_EFFECTIVE_DATE", _eosEffectiveDate);
                    cmd.Parameters.AddWithValue("@ISCANCEL", _isCancel);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void REMOVE_RESIGNATION_APPLICATION(string _employeeID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spREMOVE_RESIGN_APPLICATION]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EMPLOYEEID", _employeeID);


                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void RESIGN_EFFECTIVITY_PROCESS()
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("[HR].[spUPDATE_RESIGN_EFFECTIVITY]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }

        }

    }
}