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

              


                gvEmployeeList.DataSource = oEmployeeData.GET_EMPLOYEE_LIST_LW();
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

        }

        //DEPARTMENT
        private void DISPLAY_DEPARTMENT_LIST()
        {
            DataTable dt = oUtility.GET_DEPARTMENT_DATA();
                

            ddDepartment.DataSource = dt;
            ddDepartment.DataTextField = dt.Columns["DEPARTMENT"].ToString();
            ddDepartment.DataValueField = dt.Columns["DEPARTMENTCODE"].ToString();
            ddDepartment.DataBind();

        }

        //DESIGNATION
        private void DISPLAY_POSITION_LIST()
        {
            DataTable dt = oUtility.GET_POSITION_DATA();



            ddPosition.DataSource = dt;
            ddPosition.DataTextField = dt.Columns["POSITION"].ToString();
            ddPosition.DataValueField = dt.Columns["POSITIONCODE"].ToString();
            ddPosition.DataBind();

        }

        private void DISPLAY_COMPANY_LIST()
        {
            DataTable dt = oSystem.GET_COMPANY_LIST();

            ddCompany.DataSource = dt;
            ddCompany.DataTextField = dt.Columns["CompanyName"].ToString();
            ddCompany.DataValueField = dt.Columns["CompanyCode"].ToString();
            ddCompany.DataBind();

        }





        #endregion

        protected void lnkUpdateEmployeeInformation_Click(object sender, EventArgs e)
        {
           

            if (!string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtDateOfBirth.Text) && !string.IsNullOrEmpty(txtDateHired.Text))
                {
                    if (string.IsNullOrEmpty(txtApplicationDate.Text))
                    {
                        txtApplicationDate.Text = DateTime.Today.ToShortDateString();
                    }
                //SAVING EMPLOYEE DATA

                if(Convert.ToInt32(ViewState["ACTION"]) == 0)
                { 
                lblEmployeeID.Text = oSystem.GENERATE_SERIES_NUMBER_EMPLOYEE("EMP");
                }

               

                oEmployeeData.INSERT_EMPLOYEE_INFORMATION(lblEmployeeID.Text, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, txtNickName.Text,
                                              ddGender.SelectedValue.ToString(), ddMaritalStatus.SelectedValue, Convert.ToDateTime(txtDateOfBirth.Text), txtPlaceOfBirth.Text,
                                              txtWeight.Text, txtHeight.Text, txtLandlineNumber.Text, txtMobilePhone.Text,
                                              ddReligion.SelectedValue.ToString(), ddCitizenship.SelectedValue.ToString(),
                                              txtPresent_Address.Text, txtProvincial_Address.Text,
                                              txtTinNumber.Text, txtSSSNumber.Text, txtPagibigNumber.Text, txtPhilHealthNumber.Text,
                                              Convert.ToDateTime(txtDateHired.Text), ddCompany.SelectedValue.ToString(), ddDepartment.SelectedValue.ToString(), ddPosition.SelectedValue.ToString(), ddEmploymentStatus.SelectedValue.ToString(),
                                              Convert.ToDateTime(txtApplicationDate.Text), ddJobPosting.SelectedValue, txtApplicantEvaluation.Text, ddBloodType.SelectedValue, txtContactPerson.Text.ToUpper(), txtContactRelationship.Text.ToUpper(), txtContactNumber.Text);

                //Response.Redirect(Request.RawUrl);
                gvEmployeeList.DataSource = oEmployeeData.GET_EMPLOYEE_LIST_LW();
                gvEmployeeList.DataBind();

                lnkReturn_Click(sender, e);

                lblSuccessMessage.Text = "Employee successfully updated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

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


           
                txtDateHired.Text = Convert.ToDateTime(dvr.Row["Date_Hired"]).ToShortDateString();
                txtApplicationDate.Text = Convert.ToDateTime(dvr.Row["Date_Applied"]).ToShortDateString();
                //



                txtContactPerson.Text = dvr.Row["ContactPerson"].ToString();
                txtContactRelationship.Text = dvr.Row["ContactRelationship"].ToString();
                txtContactNumber.Text = dvr.Row["ContactNumber"].ToString();

                if (!string.IsNullOrEmpty(dvr.Row["CompanyCode"].ToString()))
                {
                    ddCompany.SelectedValue = dvr.Row["CompanyCode"].ToString();
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

                if (!string.IsNullOrEmpty(dvr.Row["Blood_Type"].ToString()))
                {
                    ddBloodType.SelectedValue = dvr.Row["Blood_Type"].ToString();
                }

                if (!string.IsNullOrEmpty(dvr.Row["JPCode"].ToString()))
                {
                    ddJobPosting.SelectedValue = dvr.Row["JPCode"].ToString();
                }

               
                txtApplicantEvaluation.Text = dvr.Row["Applicant_Evaluation"].ToString();
                

                if (File.Exists(Server.MapPath("~/Emp_Pictures/" + lblEmployeeID.Text + ".jpg")))
                {
                    imgEmployeePicture.ImageUrl = "~/Emp_Pictures/" + lblEmployeeID.Text + ".jpg";
                }
                else
                {
                    imgEmployeePicture.ImageUrl = "~/Emp_Pictures/default-avatar.png";
                }

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

        }


        private void Clear_Fields()
        {

            lblEmployeeID.Text = "";

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



            //WORK EVALUATION / PERFORMANCE
            gvWorkEvaluationCriteria.DataSource = null;
            gvWorkEvaluationCriteria.DataBind();
            txtEvaluationRemarks.Text = "";

            gvWorkEvaluationRecord.DataSource = null;
            gvWorkEvaluationRecord.DataBind();
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

                oEmployeeData.INSERT_EMPLOYEE_FAMILY(lblEmployeeID.Text, txtFatherName.Text, txtFatherContactNumber.Text, txtMotherName.Text,
                                                     txtMotherContactNumber.Text, Convert.ToInt32(txtSiblingsCount.Text), txtSpouseLastName.Text,
                                                     txtSpouseFirstName.Text, txtSpouseMiddleName.Text, txtSpouseContactNumber.Text);



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

        protected void lnkUploadFile_Click(object sender, EventArgs e)
        {
            if (fuAttachment.HasFile)
            { 
            fuAttachment.SaveAs(Server.MapPath("~/Uploads/EmployeeAttachment/" + fuAttachment.FileName.ToString()));
            string fullPath = fuAttachment.FileName.ToString();
            oEmployeeData.INSERT_EMPLOYEE_ATTACHMENT(lblEmployeeID.Text, txtAttachmentFileName.Text, fullPath);
            lblSuccessMessage.Text = "Attachment Success.";
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgSuccessModal').modal('show');</script>", false);

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
    }
}