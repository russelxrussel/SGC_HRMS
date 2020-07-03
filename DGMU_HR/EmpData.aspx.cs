using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace DGMU_HR
{
    
    public partial class EmpData : System.Web.UI.Page
    {
        Employee_Data_C oEmployeeData = new Employee_Data_C();
        Utility_C oUtility = new Utility_C();
        SystemX oSystem = new SystemX();
        Payroll_C oPayroll = new Payroll_C();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DISPLAY_GENDER_LIST();
                DISPLAY_RELIGION_LIST();
                DISPLAY_CITIZENSHIP_LIST();
                DISPLAY_DEPARTMENT_LIST();
                DISPLAY_POSITION_LIST();
                DISPLAY_MARITAL_LIST();
                DISPLAY_JOB_POSTING_LIST();
                DISPLAY_BLOOD_TYPE_LIST();

                DISPLAY_COMPANY_LIST();
                DISPLAY_EMPLOYMENT_STATUS_LIST();
                DISPLAY_EMPLOYMENT_TYPE_LIST();


                DISPLAY_EMPLOYMENT_STATUS_LIST_EOS();


                gvEmployeeList.DataSource = oEmployeeData.GET_ALL_EMPLOYEE_LIST_LW();
                gvEmployeeList.DataBind();

                imgEmployeePicture.ImageUrl = "/Emp_Pictures/default-avatar.png";

               
            }
          
        }


        #region "PRE-POPULATED"
       // Display Gender
        private void DISPLAY_GENDER_LIST()
        {
            DataTable dt = oUtility.GET_GENDER_DATA();
            
                
            ddGender.DataSource = dt;
            ddGender.DataTextField = dt.Columns["GENDERDESCRIPTION"].ToString();
            ddGender.DataValueField = dt.Columns["GENDERCODE"].ToString();
            ddGender.DataBind();

            ddChildGender.DataSource = dt;
            ddChildGender.DataTextField = dt.Columns["GENDERDESCRIPTION"].ToString();
            ddChildGender.DataValueField = dt.Columns["GENDERCODE"].ToString();
            ddChildGender.DataBind();

        }
        private void DISPLAY_RELIGION_LIST()
        {
            DataTable dt = oUtility.GET_RELIGION_DATA();


            ddReligion.DataSource = dt;
            ddReligion.DataTextField = dt.Columns["RELIGION"].ToString();
            ddReligion.DataValueField = dt.Columns["RELIGIONCODE"].ToString();
            ddReligion.DataBind();

    
        }

        //CITIZENSHIP
        private void DISPLAY_CITIZENSHIP_LIST()
        {
            DataTable dt = oUtility.GET_CITIZENSHIP_DATA();


            ddCitizenship.DataSource = dt;
            ddCitizenship.DataTextField = dt.Columns["CITIZENSHIP"].ToString();
            ddCitizenship.DataValueField = dt.Columns["CITIZENSHIPCODE"].ToString();
            ddCitizenship.DataBind();

    
        }

        //MARITAL STATUS
        private void DISPLAY_MARITAL_LIST()
        {
            DataTable dt = oUtility.GET_MARITAL_DATA();


            ddMaritalStatus.DataSource = dt;
            ddMaritalStatus.DataTextField = dt.Columns["MARITALSTATUS"].ToString();
            ddMaritalStatus.DataValueField = dt.Columns["MARITALCODE"].ToString();
            ddMaritalStatus.DataBind();

   
        }

        private void DISPLAY_JOB_POSTING_LIST()
        {
            DataTable dt = oUtility.GET_JOB_POSTING_DATA();


            ddJobPosting.DataSource = dt;
            ddJobPosting.DataTextField = dt.Columns["JPDescription"].ToString();
            ddJobPosting.DataValueField = dt.Columns["JPCode"].ToString();
            ddJobPosting.DataBind();

        }

        private void DISPLAY_BLOOD_TYPE_LIST()
        {
            DataTable dt = oUtility.GET_BLOOD_TYPE_DATA();

            ddBloodType.DataSource = dt;
            ddBloodType.DataTextField = dt.Columns["BloodType"].ToString();
            ddBloodType.DataValueField = dt.Columns["BloodType"].ToString();
            ddBloodType.DataBind();

        }

        //EMPLOYMENT STATUS
        private void DISPLAY_EMPLOYMENT_STATUS_LIST()
        {
            DataTable dt = oUtility.GET_EMPLOYMENT_STATUS();


            ddEmploymentStatus.DataSource = dt;
            ddEmploymentStatus.DataTextField = dt.Columns["Status"].ToString();
            ddEmploymentStatus.DataValueField = dt.Columns["StatusCode"].ToString();
            ddEmploymentStatus.DataBind();

            ddEmploymentStatus.Items.Insert(0, new ListItem("*Select Employment Status"));

        }

        private void DISPLAY_EMPLOYMENT_STATUS_LIST_EOS()
        {
            DataTable dt = oUtility.GET_EMPLOYMENT_STATUS();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "Sys_Employee_StatusCode='" + 'X' + "'";

            ddEOSType.DataSource = dv.Table;
            ddEOSType.DataTextField = dv.Table.Columns["Status"].ToString();
            ddEOSType.DataValueField = dv.Table.Columns["StatusCode"].ToString();
            ddEOSType.DataBind();

            ddEOSType.Items.Insert(0, new ListItem("*Select End of Service"));
        }


        private void DISPLAY_EMPLOYEE_GOVTDUE_BILL_RECORDS(string _empCode)
        {
            DataTable dt = oPayroll.GET_GOVT_COMPANY_BILL();
            DataView dv = dt.DefaultView;

            dv.RowFilter = "EmpCode='" + _empCode + "'";

            dv.Sort = "Year desc, Month";
            gvShowCompanyBillTransactions.DataSource = dv.Table;
            gvShowCompanyBillTransactions.DataBind();

        }

        private void DISPLAY_EMPLOYMENT_TYPE_LIST()
        {
            DataTable dt = oUtility.GET_EMPLOYMENT_TYPE();


            ddEmploymentType.DataSource = dt;
            ddEmploymentType.DataTextField = dt.Columns["EmpTypeDesc"].ToString();
            ddEmploymentType.DataValueField = dt.Columns["EmpTypeCode"].ToString();
            ddEmploymentType.DataBind();

            ddEmploymentType.Items.Insert(0, new ListItem("*Select Employment Type"));
        }

        //DEPARTMENT
        private void DISPLAY_DEPARTMENT_LIST()
        {
            DataTable dt = oUtility.GET_DEPARTMENT_DATA();
                

            ddDepartment.DataSource = dt;
            ddDepartment.DataTextField = dt.Columns["DEPARTMENT"].ToString();
            ddDepartment.DataValueField = dt.Columns["DEPARTMENTCODE"].ToString();
            ddDepartment.DataBind();

            ddDepartment.Items.Insert(0, new ListItem("*Select Department"));
        }

        //DESIGNATION
        private void DISPLAY_POSITION_LIST()
        {
            DataTable dt = oUtility.GET_POSITION_DATA();
            
            ddPosition.DataSource = dt;
            ddPosition.DataTextField = dt.Columns["POSITION"].ToString();
            ddPosition.DataValueField = dt.Columns["POSITIONCODE"].ToString();
            ddPosition.DataBind();

            ddPosition.Items.Insert(0, new ListItem("*Select Position"));
        }

        private void DISPLAY_COMPANY_LIST()
        {
            DataTable dt = oSystem.GET_COMPANY_LIST();

            ddCompany.DataSource = dt;
            ddCompany.DataTextField = dt.Columns["CompanyName"].ToString();
            ddCompany.DataValueField = dt.Columns["CompanyCode"].ToString();
            ddCompany.DataBind();

            ddCompany.Items.Insert(0, new ListItem("*Select Company"));


            //Company Transfer
            ddTransferCompanyTo.DataSource = dt;
            ddTransferCompanyTo.DataTextField = dt.Columns["CompanyName"].ToString();
            ddTransferCompanyTo.DataValueField = dt.Columns["CompanyCode"].ToString();
            ddTransferCompanyTo.DataBind();
            ddTransferCompanyTo.Items.Insert(0, new ListItem("*Select Company"));

            //Company To Bill for Gov't ID's
            ddCompanyToBill.DataSource = dt;
            ddCompanyToBill.DataTextField = dt.Columns["CompanyName"].ToString();
            ddCompanyToBill.DataValueField = dt.Columns["CompanyCode"].ToString();
            ddCompanyToBill.DataBind();
            //ddTransferCompanyTo.Items.Insert(0, new ListItem("*Select Company"));
        }


        //Display Current Company of Employee
        private string GET_CURRENT_EMPLOYEE_COMPANY(string _employeeID)
        {
            string x = "";

            DataView dv = oEmployeeData.GET_EMPLOYEE_LIST().DefaultView;

            dv.RowFilter = "EmployeeID ='" + _employeeID + "'";

            if (dv.Count > 0)
            {
                foreach (DataRowView dvr in dv)
                {
                    x = dvr["CompanyName"].ToString();
                    //= dvr["CompanyCode"].ToString();
                }
            }
            else
            {
                x = "";
            }

            return x;
        }


        #endregion

        protected void lnkUpdateEmployeeInformation_Click(object sender, EventArgs e)
        {
           

            if (!string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtDateOfBirth.Text))
                {
                    //if (string.IsNullOrEmpty(txtApplicationDate.Text))
                    //{
                    //    txtApplicationDate.Text = DateTime.Today.ToShortDateString();
                    //}
                //SAVING EMPLOYEE DATA

                if(Convert.ToInt32(ViewState["ACTION"]) == 0)
                { 
                lblEmployeeID.Text = oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("EMP");
                }



                //oEmployeeData.INSERT_EMPLOYEE_INFORMATION(lblEmployeeID.Text, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, txtNickName.Text,
                //                              ddGender.SelectedValue.ToString(), ddMaritalStatus.SelectedValue, Convert.ToDateTime(txtDateOfBirth.Text), txtPlaceOfBirth.Text,
                //                              txtWeight.Text, txtHeight.Text, txtLandlineNumber.Text, txtMobilePhone.Text,
                //                              ddReligion.SelectedValue.ToString(), ddCitizenship.SelectedValue.ToString(),
                //                              txtPresent_Address.Text, txtProvincial_Address.Text,
                //                              txtTinNumber.Text, txtSSSNumber.Text, txtPagibigNumber.Text, txtPhilHealthNumber.Text,
                //                              Convert.ToDateTime(txtDateHired.Text), ddCompany.SelectedValue.ToString(), ddDepartment.SelectedValue.ToString(), ddPosition.SelectedValue.ToString(), ddEmploymentStatus.SelectedValue.ToString(),
                //                              Convert.ToDateTime(txtApplicationDate.Text), ddJobPosting.SelectedValue, txtApplicantEvaluation.Text, ddBloodType.SelectedValue, txtContactPerson.Text.ToUpper(), txtContactRelationship.Text.ToUpper(), txtContactNumber.Text);


                oEmployeeData.INSERT_UPDATE_EMPLOYEE_INFORMATION(lblEmployeeID.Text, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, txtNickName.Text,
                                              ddGender.SelectedValue.ToString(), ddMaritalStatus.SelectedValue, Convert.ToDateTime(txtDateOfBirth.Text), txtPlaceOfBirth.Text,
                                              txtWeight.Text, txtHeight.Text, txtLandlineNumber.Text, txtMobilePhone.Text,
                                              ddReligion.SelectedValue.ToString(), ddCitizenship.SelectedValue.ToString(),
                                              txtPresent_Address.Text, txtProvincial_Address.Text, ddBloodType.SelectedValue);

                //Response.Redirect(Request.RawUrl);
                gvEmployeeList.DataSource = oEmployeeData.GET_ALL_EMPLOYEE_LIST_LW();
                gvEmployeeList.DataBind();

                //lnkReturn_Click(sender, e);
               
               
                lblSuccessMessage.Text = "Employee successfully updated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                //Allow user to Insert other records
                CONTROL_UPDATE();

            }
                else
                {
                    lblErrorMessage.Text = "Please fillup all required field.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                    return;
                }

           
        }

       

    

        private void DisplaySelectedEmployee(string _employeeID)
        {
            DataTable dt = oEmployeeData.GET_EMPLOYEE_LIST();

            DataView dv = dt.DefaultView;
            dv.RowFilter = "EmployeeID ='" + _employeeID + "'";

            

            if (dv.Count > 0)
            {
                DataRowView dvr = dv[0];

                //Indicate action will be update
                ViewState["ACTION"] = 1;


                lblEmployeeID.Text = dvr.Row["EmployeeID"].ToString();

                txtLastName.Text = dvr.Row["Last_Name"].ToString();
                txtFirstName.Text = dvr.Row["First_Name"].ToString();
                txtMiddleName.Text = dvr.Row["Middle_Name"].ToString();
                txtNickName.Text = dvr.Row["Nick_Name"].ToString();

                lblEmployeeFullName.Text = txtLastName.Text + ", " + txtFirstName.Text;

                if (!string.IsNullOrEmpty(dvr.Row["MaritalCode"].ToString()))
                { 
                ddMaritalStatus.SelectedValue = dvr.Row["MaritalCode"].ToString();
                }

                txtDateOfBirth.Text = dvr.Row["Date_of_Birth"].ToString();
                txtPlaceOfBirth.Text = dvr.Row["Place_of_Birth"].ToString();
                txtWeight.Text = dvr.Row["Weight"].ToString();
                txtHeight.Text = dvr.Row["Height"].ToString();
                txtLandlineNumber.Text = dvr.Row["Landline_Number"].ToString();
                txtMobilePhone.Text = dvr.Row["Mobile_Number"].ToString();
                txtPresent_Address.Text = dvr.Row["Present_Address"].ToString();
                txtProvincial_Address.Text = dvr.Row["Provincial_Address"].ToString();
                
                
                ddReligion.SelectedValue = dvr.Row["ReligionCode"].ToString();
                ddCitizenship.SelectedValue = dvr.Row["CitizenshipCode"].ToString();
                ddGender.SelectedValue = dvr.Row["GenderCode"].ToString();
                

                //Employment Details
                txtTinNumber.Text = dvr.Row["TIN"].ToString();
                txtSSSNumber.Text = dvr.Row["SSS"].ToString();
                txtPagibigNumber.Text = dvr.Row["HDMF"].ToString();
                txtPhilHealthNumber.Text = dvr.Row["PhilHealth"].ToString();

                //Display Gov't Due company to bill
                if (!string.IsNullOrEmpty(dvr.Row["BillingCompanyCode"].ToString()))
                {
                    ddCompanyToBill.SelectedValue = dvr["BillingCompanyCode"].ToString();
                }
                else {
                    ddCompanyToBill.SelectedValue = dvr["CompanyCode"].ToString();
                }

                //DISPLAY TRANSACTION RECORD OF EMPLOYEE IN GOV'T DUES
                DISPLAY_EMPLOYEE_GOVTDUE_BILL_RECORDS(lblEmployeeID.Text);

                if (!string.IsNullOrEmpty(dvr.Row["Date_Hired"].ToString()))
                { 
                txtDateHired.Text = Convert.ToDateTime(dvr.Row["Date_Hired"]).ToShortDateString();
                }

                if(!string.IsNullOrEmpty(dvr.Row["Date_Applied"].ToString()))
                    { 
                txtApplicationDate.Text = Convert.ToDateTime(dvr.Row["Date_Applied"]).ToShortDateString();
                }
                //



                txtContactPerson.Text = dvr.Row["ContactPerson"].ToString();
                txtContactRelationship.Text = dvr.Row["ContactRelationship"].ToString();
                txtContactNumber.Text = dvr.Row["ContactNumber"].ToString();

                if (!string.IsNullOrEmpty(dvr.Row["CompanyCode"].ToString()))
                {
                    ddCompany.SelectedValue = dvr.Row["CompanyCode"].ToString();

                    //FOR COMPANY TRANSFER
                    ViewState["CURRENT_COMPANYCODE"] = dvr.Row["CompanyCode"].ToString();
                    //ddCompany.Enabled = false;
                }


                if (!string.IsNullOrEmpty(dvr.Row["DepartmentCode"].ToString()))
                { 
                    ddDepartment.SelectedValue = dvr.Row["DepartmentCode"].ToString();
                }

                if (!string.IsNullOrEmpty(dvr.Row["PositionCode"].ToString()))
                {
                    ddPosition.SelectedValue = dvr.Row["PositionCode"].ToString();
                }
                if (!string.IsNullOrEmpty(dvr.Row["EmploymentStatusCode"].ToString()))
                {
                    ddEmploymentStatus.SelectedValue = dvr.Row["EmploymentStatusCode"].ToString();
                }

               

                if (!string.IsNullOrEmpty(dvr.Row["EmploymentTypeCode"].ToString()))
                {
                    ddEmploymentType.SelectedValue = dvr.Row["EmploymentTypeCode"].ToString();
                }


                if (!string.IsNullOrEmpty(dvr.Row["Blood_Type"].ToString()))
                {
                    ddBloodType.SelectedValue = dvr.Row["Blood_Type"].ToString();
                }

                if (!string.IsNullOrEmpty(dvr.Row["JPCode"].ToString()))
                {
                    ddJobPosting.SelectedValue = dvr.Row["JPCode"].ToString();
                }

               
                txtApplicantEvaluation.Text = dvr.Row["Applicant_Evaluation"].ToString();


                //if (File.Exists(Server.MapPath("~/Uploads/EmployeePictures/" + lblEmployeeID.Text + ".jpg")))
                //{
                //    imgEmployeePicture.ImageUrl = "~/Uploads/EmployeePictures/" + lblEmployeeID.Text + ".jpg";
                //}
                //else
                //{
                //    imgEmployeePicture.ImageUrl = "~/Emp_Pictures/default-avatar.png";
                //}

                if (!string.IsNullOrEmpty(oEmployeeData.GET_EMPLOYEE_PICTURE(_employeeID)))
                {
                    imgEmployeePicture.ImageUrl = oEmployeeData.GET_EMPLOYEE_PICTURE(_employeeID);
                }
                else { imgEmployeePicture.ImageUrl = "~/Uploads/EmployeePictures/default-avatar.png"; }

                panel_Employee_Content.Visible = true;
                panel_ListOfEmployee.Visible = false;


                //EMPLOYEE FAMILY DISPLAY
                txtFatherName.Text = dvr.Row["F_Name"].ToString();
                txtFatherContactNumber.Text = dvr.Row["F_Contact"].ToString();
                txtMotherName.Text = dvr.Row["M_Name"].ToString();
                txtMotherContactNumber.Text = dvr.Row["M_Contact"].ToString();
                txtSiblingsCount.Text = dvr.Row["Sibling_Count"].ToString();
                txtSpouseLastName.Text = dvr.Row["S_LastName"].ToString();
                txtSpouseFirstName.Text = dvr.Row["S_FirstName"].ToString();
                txtSpouseMiddleName.Text = dvr.Row["S_MiddleName"].ToString();
                txtSpouseContactNumber.Text = dvr.Row["S_Contact"].ToString();


                //EDUCATION
                txtPrimarySchool.Text = dvr.Row["PrimarySchoolName"].ToString();
                txtPrimaryYG.Text = dvr.Row["PrimaryYG"].ToString();
                txtSecondarySchool.Text = dvr.Row["SecondarySchoolName"].ToString();
                txtSecondaryYG.Text = dvr.Row["SecondaryYG"].ToString();
                txtTertiarySchool.Text = dvr.Row["TertiarySchoolName"].ToString();
                txtTertiaryYG.Text = dvr.Row["TertiaryYG"].ToString();
                txtCourse.Text = dvr.Row["Course"].ToString();

                if (!string.IsNullOrEmpty(dvr.Row["isGraduate"].ToString()))
                {
                    chkIsGraduate.Checked = Convert.ToBoolean(dvr.Row["isGraduate"]);
                }
                else
                {
                    chkIsGraduate.Checked = false;
                }


                //DISPLAY List of Skills and Training of Employee
                DISPLAY_SKILLS_TRAINING(_employeeID);

                //WORK EVALUATION
                DISPLAY_EVALUATION_CRITERIA_LIST();
                DISPLAY_EVALUATION_RATINGS_LIST();
                //txtEvaluationRemarks.Text = oEmployeeData.GET_EMPLOYEE_WORK_EVALUATION_REMARKS(_employeeID);
                DISPLAY_EMPLOYEE_EVALUATION_RECORD(_employeeID);

                //EMPLOYEE OFFENSES

                DISPLAY_EMPLOYEE_OFFENSE(_employeeID);

                DISPLAY_EMPLOYMENT_HISTORY(_employeeID);

                //DISPLAY LIST OF EMPLOYEE ATTACHMENTS
                DISPLAY_EMPLOYEE_ATTACHMENTS(_employeeID);

                //FAMILY CHILDREN
                DISPLAY_FAMILY_CHILDREN(_employeeID);

                //DEFAULT ACTION
                ViewState["CHILD_ACTION"] = false;


                /***This area content 
                of Company Transfer TAB
                ***/

                //Show the current Company of the selected Employee.
                lblCurrentCompany.Text = GET_CURRENT_EMPLOYEE_COMPANY(_employeeID);

                //Show the History Company Transfer Record of the Employee 
                gvEmployeeTransferHistory.DataSource = oEmployeeData.GET_EMPLOYEE_COMPANY_TRANSFER(_employeeID);
                gvEmployeeTransferHistory.DataBind();


                //End of Services 
                //03.20.2020
                txtEOSDate.Text = dvr.Row["EOS_Effective_Date"].ToString();
                txtEOSDateApplied.Text = dvr.Row["EOS_Apply_Date"].ToString();
                txtEOSRemarks.Text = dvr.Row["EOS_Remarks"].ToString();
                if (!string.IsNullOrEmpty(dvr.Row["EOS_Code"].ToString()))
                {
                    ddEOSType.SelectedValue = dvr.Row["EOS_Code"].ToString();
                }
                else
                {
                    ddEOSType.SelectedIndex = 0;
                }
                //Check to disable EOS Form
                if (!string.IsNullOrEmpty(dvr.Row["IsSet"].ToString()))

                {
                if (!Convert.ToBoolean(dvr.Row["IsSet"]))
                {
                    panelEOSForm.Enabled = true;

                }
                else
                {
                    panelEOSForm.Enabled = false;
                }
                }
            }
        }

        //DISPLAY EMPLOYEE SKILLS AND TRAINING
        private void DISPLAY_SKILLS_TRAINING(string _employeeID)
        {
            //Display Employee Skills and Training
            DataTable dtSkillsTraining = oEmployeeData.GET_EMPLOYEE_SKILLS_TRAINING(_employeeID);

            if (dtSkillsTraining.Rows.Count > 0)
            {
                gvSkillsTraining.DataSource = dtSkillsTraining;
            }
            else
            {
                gvSkillsTraining.DataSource = null;
            }

            gvSkillsTraining.DataBind();
        }

        protected void U_Search_Click(object sender, EventArgs e)
        {
          //  SearchResult(txtSearch.Text);
        }

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                GridViewRow row = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow);

                DisplaySelectedEmployee(row.Cells[0].Text);

                txtSearch.Text = "";

                CONTROL_UPDATE();

                lnkRemoveEmployee.Visible = true;
          
            }


        }

        protected void lnkCreateNew_Click(object sender, EventArgs e)
        {
            panel_Employee_Content.Visible = true;
            panel_ListOfEmployee.Visible = false;

            //Clear all field

    
            

            Clear_Fields();

            imgEmployeePicture.ImageUrl = "/Emp_Pictures/default-avatar.png";

            //Indicate action will Create New Record
            ViewState["ACTION"] = 0;

            CONTROL_CREATE();

            lnkRemoveEmployee.Visible = false;

        }


        private void Clear_Fields()
        {

            lblEmployeeID.Text = "";
            lblEmployeeFullName.Text = "";

            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtNickName.Text = "";

            txtDateOfBirth.Text = "";
            txtPlaceOfBirth.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            txtLandlineNumber.Text = "";
            txtMobilePhone.Text = "";
            txtPresent_Address.Text = "";
            txtProvincial_Address.Text = "";

            ddCompany.Enabled = true;

            txtTinNumber.Text = "";
            txtSSSNumber.Text = "";
            txtPhilHealthNumber.Text = "";
            txtPagibigNumber.Text = "";
            txtDateHired.Text = "";

            ddGender.SelectedIndex = 0;
            ddCitizenship.SelectedIndex = 0;
            ddDepartment.SelectedIndex = 0;

            ddDepartment.SelectedIndex = 0;
            ddPosition.SelectedIndex = 0;
            ddEmploymentStatus.SelectedIndex = 0;

            txtApplicationDate.Text = "";

            //Family
            txtFatherName.Text = "";
            txtFatherContactNumber.Text = "";
            txtMotherName.Text = "";
            txtMotherContactNumber.Text = "";
            txtSiblingsCount.Text = "0";

            txtSpouseLastName.Text = "";
            txtSpouseFirstName.Text = "";
            txtSpouseMiddleName.Text = "";
            txtSpouseContactNumber.Text = "";

            txtContactPerson.Text = "";
            txtContactNumber.Text = "";
            txtContactRelationship.Text = "";

            //Schools
            txtPrimarySchool.Text = "";
            txtPrimaryYG.Text = "";
            txtSecondarySchool.Text = "";
            txtSecondaryYG.Text = "";
            txtTertiarySchool.Text = "";
            txtTertiaryYG.Text = "";
            txtCourse.Text = "";
            chkIsGraduate.Checked = false;

            //SKILLS AND TRAINING
            gvSkillsTraining.DataSource = null;
            gvSkillsTraining.DataBind();
            txtSkillsTraining.Text = "";
            txtStartDateTraining.Text = "";
            txtEndDateTraining.Text = "";
            txtTrainingCenterName.Text = "";
            chkCompanySponsor.Checked = false;

            //WORK EVALUATION / PERFORMANCE
            gvWorkEvaluationCriteria.DataSource = null;
            gvWorkEvaluationCriteria.DataBind();
            txtEvaluationRemarks.Text = "";
            txtEvalDateStart.Text = "";
            txtEvalDateEnd.Text = "";

            //End Of Services 03.20.2020
            txtEOSDate.Text = "";
            txtEOSDateApplied.Text = "";
            txtEOSRemarks.Text = "";
            ddEOSType.SelectedIndex = 0;

            gvWorkEvaluationRecord.DataSource = null;
            gvWorkEvaluationRecord.DataBind();

            //Offense
            gvEmployeeOffense.DataSource = null;
            gvEmployeeOffense.DataBind();

            //Attachment
            gvAttachmentList.DataSource = null;
            gvAttachmentList.DataBind();
        }

        private void Clear_SkillsTraining()
        {
            txtSkillsTraining.Text = "";
            txtTrainingCenterName.Text = "";
            txtEndDateTraining.Text = "";
            txtStartDateTraining.Text = "";
            chkCompanySponsor.Checked = false;
        }

        private void Clear_EmployeeOffenses()
        {
            txtOffenseTitle.Text = "";
            txtOffenseDetails.Text = "";
            txtOffenseRecommendation.Text = "";
        }


        private void Clear_EmploymentHistory()
        {
            txtEH_CompanyName.Text = "";
            txtEH_CompanyAddress.Text = "";
            txtEH_Position.Text = "";
            txtEH_DateStarted.Text = "";
            txtEH_DateEnd.Text = "";
            txtEH_Remarks.Text = "";
        }

        //CONTROL BEHAVIOR
        private void CONTROL_CREATE()
        {
            panelFamilyControl.Visible = false;
            panelEducationControl.Visible = false;
            panelSkillsControl.Visible = false;
            panelManageControl.Visible = false;
            panelAttachmentControl.Visible = false;
            panelEmploymentHistoryControl.Visible = false;
        }

        private void CONTROL_UPDATE()
        {
            panelFamilyControl.Visible = true;
            panelEducationControl.Visible = true;
            panelSkillsControl.Visible = true;
            panelManageControl.Visible = true;
            panelAttachmentControl.Visible = true;
            panelEmploymentHistoryControl.Visible = true;
        }
        protected void lnkReturn_Click(object sender, EventArgs e)
        {
            Clear_Fields();
            panel_Employee_Content.Visible = false;
            panel_ListOfEmployee.Visible = true;
        }

        protected void lnkUpdateFamily_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblEmployeeID.Text))
            {
                if (string.IsNullOrEmpty(txtSiblingsCount.Text))
                {
                    txtSiblingsCount.Text = "0";
                }

                oEmployeeData.INSERT_UPDATE_EMPLOYEE_FAMILY(lblEmployeeID.Text, txtFatherName.Text, txtFatherContactNumber.Text, txtMotherName.Text,
                                                     txtMotherContactNumber.Text, Convert.ToInt32(txtSiblingsCount.Text), txtSpouseLastName.Text,
                                                     txtSpouseFirstName.Text, txtSpouseMiddleName.Text, txtSpouseContactNumber.Text,
                                                     txtContactPerson.Text.ToUpper(), txtContactNumber.Text, txtContactRelationship.Text);



                lblSuccessMessage.Text = "Family background successfully updated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

            }else
            {
                lblErrorMessage.Text = "Empty field not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void lnkUpdateEducation_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(lblEmployeeID.Text))
            {
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_EDUCATION(lblEmployeeID.Text, txtPrimarySchool.Text.ToUpper(), txtPrimaryYG.Text, txtSecondarySchool.Text.ToUpper(), txtSecondaryYG.Text, txtTertiarySchool.Text.ToUpper(), txtTertiaryYG.Text, txtCourse.Text.ToUpper(), chkIsGraduate.Checked);


                lblSuccessMessage.Text = "Education background successfully updated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);
            }
            else
            {
                lblErrorMessage.Text = "Empty field not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void lnkUpdateSkills_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSkillsTraining.Text) && !string.IsNullOrEmpty(txtEndDateTraining.Text))
            {

                oEmployeeData.INSERT_UPDATE_EMPLOYEE_SKILLSTRAINING(lblEmployeeID.Text, txtSkillsTraining.Text.ToUpper(),txtTrainingCenterName.Text.ToUpper(), Convert.ToDateTime(txtStartDateTraining.Text), Convert.ToDateTime(txtEndDateTraining.Text), chkCompanySponsor.Checked);
                DISPLAY_SKILLS_TRAINING(lblEmployeeID.Text);

                lblSuccessMessage.Text = "New Skills and training successfully added.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                Clear_SkillsTraining();
            }

            else
            {
                lblErrorMessage.Text = "Empty field not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;
           
            int _ID = Convert.ToInt32(r.Cells[0].Text);

            oEmployeeData.REMOVE_EMPLOYEE_SKILLSTRAINING(_ID);
            DISPLAY_SKILLS_TRAINING(lblEmployeeID.Text);

        }

        #region "WORK EVALUATION AND RATINGS AREA LOCAL FUNCTIONS"
        /*LIST OF FUNCTIONS RELATED TO WORK EVALUATION*/

        private void DISPLAY_EVALUATION_CRITERIA_LIST()
        {
            DataTable dtWorkEvaluationCriteriaList = oUtility.GET_WORK_EVALUATION_CRITERIA_LIST();

            gvWorkEvaluationCriteria.DataSource = dtWorkEvaluationCriteriaList;
            gvWorkEvaluationCriteria.DataBind();
        }

        private void DISPLAY_EVALUATION_RATINGS_LIST()
        {
            DataTable dt = oUtility.GET_WORK_EVALUATION_RATINGS_LIST();

            gvRatingsLegend.DataSource = dt;
            gvRatingsLegend.DataBind();
        }

        private string DISPLAY_EVALUATION_RATINGS_RESULT(int _weID, string _wecCode)
        {
            string ratingCode = "";

            DataView dv = oEmployeeData.GET_EMPLOYEE_WORK_EVALUATION_RESULT(_weID).DefaultView;
            dv.RowFilter = "WEC_CODE = '" + _wecCode + "'";

            if (dv.Count > 0)
            {
                foreach(DataRowView drv in dv)
                {
                    ratingCode = drv["WER_CODE"].ToString();
                }
            }


            return ratingCode;
        }

        private void DISPLAY_EVALUATION_RESULT(int _weID)
        {
          DataTable dt =  oEmployeeData.GET_EMPLOYEE_WORK_EVALUATION_RESULT(_weID);
          gvEmployeeEvaluationResult.DataSource = dt;
          gvEmployeeEvaluationResult.DataBind();

        
        }

        private void DISPLAY_EMPLOYEE_EVALUATION_RECORD(string _employeeID)
        {
            DataTable dt = oEmployeeData.GET_EMPLOYEE_WORK_EVALUATION_RECORD(_employeeID);

            gvWorkEvaluationRecord.DataSource = dt;
            gvWorkEvaluationRecord.DataBind();
            
        }

        #endregion

        protected void gvWorkEvaluationCriteria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = oUtility.GET_WORK_EVALUATION_RATINGS_LIST();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string wecCode = e.Row.Cells[0].Text;

                DropDownList ddRatings = (e.Row.FindControl("ddRatings") as DropDownList);
                ddRatings.DataSource = dt;
                ddRatings.DataTextField = dt.Columns["WER_Title"].ToString();
                ddRatings.DataValueField = dt.Columns["WER_CODE"].ToString();
                ddRatings.DataBind();

              //  ddRatings.SelectedValue = DISPLAY_EVALUATION_RESULT(lblEmployeeID.Text, wecCode);
            }
        }

        protected void lnkCreateWorkEvaluation_Click(object sender, EventArgs e)
        {
          
            //Display Entry for Work Evaluation
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#promptEvaluationEntry').modal('show');</script>", false);
        }


        /*
        Employee Offenses
        */

        private void DISPLAY_EMPLOYEE_OFFENSE(string _employeeID)
        {
            //Display Employee Skills and Training
            DataTable dtEmployeeOffense = oEmployeeData.GET_EMPLOYEE_OFFENSES(_employeeID);

            if (dtEmployeeOffense.Rows.Count > 0)
            {
                gvEmployeeOffense.DataSource = dtEmployeeOffense;
            }
            else
            {
                gvEmployeeOffense.DataSource = null;
            }

            gvEmployeeOffense.DataBind();
        }


     
        protected void lnkOffenses_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOffenseTitle.Text) && !string.IsNullOrEmpty(txtOffenseDetails.Text))
            {
                
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_OFFENSES(lblEmployeeID.Text, txtOffenseTitle.Text,txtOffenseDetails.Text, txtOffenseRecommendation.Text);
                DISPLAY_EMPLOYEE_OFFENSE(lblEmployeeID.Text);

                lblSuccessMessage.Text = "Offenses successfully added.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                Clear_EmployeeOffenses();
            }

            else
            {
                lblErrorMessage.Text = "Empty field not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

    

        protected void lnkRemoveOffense_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            int _ID = Convert.ToInt32(r.Cells[0].Text);

            oEmployeeData.REMOVE_EMPLOYEE_OFFENSE(_ID);
            DISPLAY_EMPLOYEE_OFFENSE(lblEmployeeID.Text);
        }

     

        protected void lnkSaveWorkEvaluation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblEmployeeID.Text) && !string.IsNullOrEmpty(txtEvalDateStart.Text) && !string.IsNullOrEmpty(txtEvalDateEnd.Text))
            {
                foreach (GridViewRow row in gvWorkEvaluationCriteria.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string wecCode = row.Cells[0].Text;
                        DropDownList ddRatings = (row.FindControl("ddRatings") as DropDownList);

                        oEmployeeData.INSERT_EMPLOYEE_WORK_EVALUATION(lblEmployeeID.Text, wecCode, ddRatings.SelectedValue.ToString(), txtEvaluationRemarks.Text, Convert.ToDateTime(txtEvalDateStart.Text), Convert.ToDateTime(txtEvalDateEnd.Text));
                    }
                }

                lblSuccessMessage.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

            }
            else
            {
                lblErrorMessage.Text = "Empty field not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }

            //Close the Modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "#promptEvaluationEntry", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#promptEvaluationEntry').hide();", true);
            DISPLAY_EMPLOYEE_EVALUATION_RECORD(lblEmployeeID.Text);
        }

        protected void lnkViewEvaluation_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            int _ID = Convert.ToInt32(r.Cells[0].Text);

            txtEditEvalDateFrom.Text = r.Cells[1].Text;
            txtEditEvalDateTo.Text = r.Cells[2].Text;
            txtEditEvalRemarks.Text = r.Cells[4].Text;
            
            DISPLAY_EVALUATION_RESULT(_ID);

            panelUpdateEvaluation.Enabled = true;
        }

        protected void gvEmployeeEvaluationResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = oUtility.GET_WORK_EVALUATION_RATINGS_LIST();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int weID = Convert.ToInt32(e.Row.Cells[0].Text);
                string wecCode = e.Row.Cells[1].Text;

                DropDownList ddRatings = (e.Row.FindControl("ddRatings") as DropDownList);
                ddRatings.DataSource = dt;
                ddRatings.DataTextField = dt.Columns["WER_Title"].ToString();
                ddRatings.DataValueField = dt.Columns["WER_CODE"].ToString();
                ddRatings.DataBind();

                 ddRatings.SelectedValue = DISPLAY_EVALUATION_RATINGS_RESULT(weID, wecCode);
            }
        }

        protected void lnkEvaluationUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblEmployeeID.Text) && !string.IsNullOrEmpty(txtEditEvalDateFrom.Text) && !string.IsNullOrEmpty(txtEditEvalDateTo.Text))
            {
                foreach (GridViewRow row in gvEmployeeEvaluationResult.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int weID = Convert.ToInt32(row.Cells[0].Text);
                        string wecCode = row.Cells[1].Text;
                        DropDownList ddRatings = (row.FindControl("ddRatings") as DropDownList);

                        //oEmployeeData.INSERT_UPDATE_EMPLOYEE_WORK_EVALUATION(lblEmployeeID.Text, wecCode, ddRatings.SelectedValue.ToString(), txtEvaluationRemarks.Text, Convert.ToDateTime(txtEvalDateStart.Text), Convert.ToDateTime(txtEvalDateEnd.Text));
                        oEmployeeData.UPDATE_EMPLOYEE_WORK_EVALUATION(weID, wecCode, ddRatings.SelectedValue, txtEditEvalRemarks.Text, Convert.ToDateTime(txtEditEvalDateFrom.Text), Convert.ToDateTime(txtEditEvalDateTo.Text));
                    }
                }

                lblSuccessMessage.Text = "Work Evaluation Successfully updated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                DISPLAY_EMPLOYEE_EVALUATION_RECORD(lblEmployeeID.Text);
                panelUpdateEvaluation.Enabled = false;
            }
            else
            {
                lblErrorMessage.Text = "Empty field not allowed.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }

       
        

        protected void lnkUploadAndDownload_Click(object sender, EventArgs e)
        {
            Session["EMPLOYEEID"] = lblEmployeeID.Text;
            CALL_CHILD_PAGE("EmployeeAttachment.aspx");

        }

        private void CALL_CHILD_PAGE(string url)
        {
            string s = "window.open('" + url + "', 'popup_window', 'width=800, height=768, left=0, top=0, resizable=yes');";
            ScriptManager.RegisterClientScriptBlock(this, this.Page.GetType(), "New Page", s, true);
        }

        private void DISPLAY_EMPLOYEE_ATTACHMENTS(string _employeeID)
        {
            DataTable dt = oEmployeeData.GET_EMPLOYEE_ATTACHMENTS(_employeeID);

            gvAttachmentList.DataSource = dt;
            gvAttachmentList.DataBind();
        }

        protected void lnkAttachmentRefresh_Click(object sender, EventArgs e)
        {
            DISPLAY_EMPLOYEE_ATTACHMENTS(lblEmployeeID.Text);
        }

       

        protected void lnkRemoveAttachment_Click(object sender, EventArgs e)
        {
            oEmployeeData.REMOVE_EMPLOYEE_ATTACHMENT(Convert.ToInt16(ViewState["ATTACHMENTID"]));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "#promptRemoveAttachment", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#promptRemoveAttachment').hide();", true);
            DISPLAY_EMPLOYEE_ATTACHMENTS(lblEmployeeID.Text);
            ViewState["ATTACHMENTID"] = "";
        }

        protected void lnkDeleteAttacment_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            ViewState["ATTACHMENTID"] = Convert.ToInt32(r.Cells[0].Text);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#promptRemoveAttachment').modal('show');</script>", false);
        }

        protected void lnkUpdateEmploymentDetails_Click(object sender, EventArgs e)
        {
            //Condtitions
            if (ddCompany.SelectedIndex != 0 && ddDepartment.SelectedIndex != 0 && ddPosition.SelectedIndex != 0 
                && ddEmploymentType.SelectedIndex != 0 && ddEmploymentStatus.SelectedIndex != 0
                && !string.IsNullOrEmpty(txtDateHired.Text))
            {
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_EMPLOYMENT_DETAILS(lblEmployeeID.Text, Convert.ToDateTime(txtDateHired.Text),
                                                                        ddCompany.SelectedValue, ddDepartment.SelectedValue, ddPosition.SelectedValue,
                                                                        ddEmploymentStatus.SelectedValue, ddEmploymentType.SelectedValue);

                lblmsgSuccess.Text = "Employment Details updated successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccess').modal('show');</script>", false);
            }
        }

        protected void lnkUpdateGovtID_Click(object sender, EventArgs e)
        {
            //NO condition
            //Notes replace label employee id by ViewState Employee ID
            oEmployeeData.INSERT_UPDATE_EMPLOYEE_GOVT_ID(lblEmployeeID.Text, txtTinNumber.Text, txtSSSNumber.Text, txtPagibigNumber.Text, txtPhilHealthNumber.Text, ddCompanyToBill.SelectedValue);

            lblmsgSuccess.Text = "Government ID's record updated successfully";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccess').modal('show');</script>", false);
        }

        protected void lnkEmployeeApplicationRecord_Click(object sender, EventArgs e)
        {
            //Checking Date First
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_APPLICATION_RECORD(lblEmployeeID.Text, Convert.ToDateTime(txtApplicationDate.Text), ddJobPosting.SelectedValue, txtApplicantEvaluation.Text);

            lblmsgSuccess.Text = "Application info updated successfully";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccess').modal('show');</script>", false);
        }

        protected void lnkUpdateChild_Click(object sender, EventArgs e)
        {
            if ((bool)ViewState["CHILD_ACTION"] == false)
            {
                ViewState["CHILD_ID"] = 0;
            }
            else
            {
              //Get the current ViewState of Child selected   
            }
            oEmployeeData.INSERT_UPDATE_EMPOYEE_FAMILY_CHILDREN(lblEmployeeID.Text, txtChildName.Text, ddChildGender.SelectedValue, Convert.ToDateTime(txtChildDOB.Text), Convert.ToInt16(ViewState["CHILD_ID"]));

            //CLEAR
            txtChildName.Text = "";
            txtChildDOB.Text = "";
            ddChildGender.SelectedIndex = 0;
            ViewState["CHILD_ACTION"] = false;

            DISPLAY_FAMILY_CHILDREN(lblEmployeeID.Text);
        }


        //DISPLAY EMPLOYEE CHILDREN
        private void DISPLAY_FAMILY_CHILDREN(string _employeeID)
        {
            DataTable dt = oEmployeeData.GET_EMPLOYEE_FAMILY_CHILDREN(_employeeID);

            gvFamilyChildren.DataSource = dt;
            gvFamilyChildren.DataBind();
        }

        protected void lnkChildEdit_Click(object sender, EventArgs e)
        {
            //Display children to Edit
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            ViewState["CHILD_ID"] = Convert.ToInt32(r.Cells[0].Text);

            txtChildName.Text = r.Cells[1].Text;
            ddChildGender.SelectedValue = r.Cells[2].Text;
            txtChildDOB.Text = r.Cells[3].Text;

            //For update action
            ViewState["CHILD_ACTION"] = true;
        }

        protected void lnkChildRemove_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            int _id = Convert.ToInt32(r.Cells[0].Text);

            oEmployeeData.REMOVE_FAMILY_CHILDREN(_id);

            DISPLAY_FAMILY_CHILDREN(lblEmployeeID.Text);
        }


        private void DISPLAY_EMPLOYMENT_HISTORY(string _employeeID)
        {
            DataTable dt = oEmployeeData.GET_EMPLOYEE_EMPLOYMENT_HISTORY(_employeeID);

            gvEmploymentHistory.DataSource = dt;
            gvEmploymentHistory.DataBind();
        }
        protected void lnkUpdateEmploymentHistory_Click(object sender, EventArgs e)
        {
            //CONDITION ESTABLISH
            if (!string.IsNullOrEmpty(txtEH_CompanyName.Text) && !string.IsNullOrEmpty(txtEH_Position.Text) && !string.IsNullOrEmpty(txtEH_DateStarted.Text))
            {
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_EMPLOYMENT_HISTORY(lblEmployeeID.Text, txtEH_CompanyName.Text.ToUpper(), txtEH_CompanyAddress.Text,
                    txtEH_Position.Text, Convert.ToDateTime(txtEH_DateStarted.Text), Convert.ToDateTime(txtEH_DateEnd.Text), txtEH_Remarks.Text);

                lblSuccessMessage.Text = "Employment History successfully added.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

                //Clear
                Clear_EmploymentHistory();
                DISPLAY_EMPLOYMENT_HISTORY(lblEmployeeID.Text);
            }
            else {

            }
        }

        protected void lnkRemoveEmploymentHistory_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            int _ID = Convert.ToInt32(r.Cells[0].Text);

            oEmployeeData.REMOVE_EMPLOYEE_EMPLOYMENT_HISTORY(_ID);
            DISPLAY_EMPLOYMENT_HISTORY(lblEmployeeID.Text);
        }

        protected void lnkProcessTransfer_Click(object sender, EventArgs e)
        {
            if (oSystem.CHECK_VALID_DATE(txtDateTransfer.Text))
            {
                if (ddTransferCompanyTo.SelectedValue != ViewState["CURRENT_COMPANYCODE"].ToString() && ddTransferCompanyTo.SelectedIndex != 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#confirmationTransfer').modal('show');</script>", false);

                }
                else
                {
                    lblErrorMessageTransfer.Text = "Selected Company is match in current company.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorTransfer').modal('show');</script>", false);

                }
               
            }
            else
            {
                lblErrorMessageTransfer.Text = "Date Not Valid please review.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorTransfer').modal('show');</script>", false);

            }
        }

        protected void lnkYesTransfer_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "#confirmationTransfer", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#promptMessage').hide();", true);

            oEmployeeData.INSERT_UPDATE_EMPLOYEE_COMPANY_TRANSFER(lblEmployeeID.Text, ddTransferCompanyTo.SelectedValue, ViewState["CURRENT_COMPANYCODE"].ToString(), Convert.ToDateTime(txtDateTransfer.Text), txtTransferRemarks.Text);

            lblCurrentCompany.Text = GET_CURRENT_EMPLOYEE_COMPANY(lblEmployeeID.Text);

            //Refresh
            ddCompany.SelectedValue = ddTransferCompanyTo.SelectedValue;

            gvEmployeeTransferHistory.DataSource = oEmployeeData.GET_EMPLOYEE_COMPANY_TRANSFER(lblEmployeeID.Text);
            gvEmployeeTransferHistory.DataBind();

            //CLEAR FIELD
            txtDateTransfer.Text = "";
            ddTransferCompanyTo.SelectedIndex = 0;
            txtTransferRemarks.Text = "";

            lblSuccessMessageTransfer.Text = "Employee Transfer successfully process.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessTransfer').modal('show');</script>", false);

        }

        protected void lnkRemoveEmployeeData_Click(object sender, EventArgs e)
        {
            //Call the stored procedure to tag the employee as removed
            oEmployeeData.REMOVE_EMPLOYEE_DATA(lblEmployeeID.Text);

            //Refresh Record
            gvEmployeeList.DataSource = oEmployeeData.GET_ALL_EMPLOYEE_LIST_LW();
            gvEmployeeList.DataBind();

            Clear_Fields();
            panel_Employee_Content.Visible = false;
            panel_ListOfEmployee.Visible = true;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "#promptRemoveEmployee", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#promptMessage').hide();", true);



        }

        protected void lnkRemoveEmployee_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#promptRemoveEmployee').modal('show');</script>", false);
        }

        protected void lnkEOSUpdate_Click(object sender, EventArgs e)
        {
            if (ddEOSType.SelectedIndex != 0 || !string.IsNullOrEmpty(txtEOSDate.Text) || !string.IsNullOrEmpty(txtEOSDateApplied.Text))
            {
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_ENDOFSERVICE(lblEmployeeID.Text, ddEOSType.SelectedValue, txtEOSRemarks.Text, Convert.ToDateTime(txtEOSDateApplied.Text), Convert.ToDateTime(txtEOSDate.Text), false);
                lblSuccessEOS.Text = "End of Service updated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessEOS').modal('show');</script>", false);
            }
            else
            { 
           
                lblErrorEOS.Text = "Please select End of Service Type and fill up EOS Date";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorEOS').modal('show');</script>", false);
            }
        }

        protected void lnkShowCompanyBillTransactions_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#showCompanyBillTransactions').modal('show');</script>", false);
        }

        protected void lnkEOSRemove_Click(object sender, EventArgs e)
        {
            if (ddEOSType.SelectedIndex > 0)
            {
                lblSuccessEOS.Text = "End of service application successfully remove.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessEOS').modal('show');</script>", false);

                oEmployeeData.REMOVE_RESIGNATION_APPLICATION(lblEmployeeID.Text);
            }
            else
            {
                //do nothing or message
            }
        }

        protected void lnkUploadEmployeeImage_Click(object sender, EventArgs e)
        {
            Session["EMPLOYEEID"] = lblEmployeeID.Text;
            CALL_CHILD_PAGE("EmployeePictureAttachment.aspx");
        }
    }
}