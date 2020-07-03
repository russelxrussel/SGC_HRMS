using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DGMU_HR
{
    public partial class EmployeePictureAttachment : System.Web.UI.Page
    {
        Employee_Data_C oEmployeeData = new Employee_Data_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
            
            }

        }

        protected void lnkUploadFile_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Uploads/EmployeePictures/");

            if (fuAttachment.HasFile)
            {
                string fiExtension = Path.GetExtension(fuAttachment.PostedFile.FileName);

                //Check extension 
                if (fiExtension != ".jpg" && fiExtension != ".png")
                {
                    Response.Write("<script language='javascript'> { alert('File Extenstion must .jpg or .png');}</script>");
                }
                else
                { 

                fuAttachment.SaveAs(folderPath + Session["EMPLOYEEID"].ToString() + fiExtension);
                string fullPath = "/Uploads/EmployeePictures/" + Session["EMPLOYEEID"].ToString() + fiExtension;
               
                //Save the into database
                oEmployeeData.INSERT_UPDATE_EMPLOYEE_PICTURE(Session["EMPLOYEEID"].ToString(), fullPath);
               
                Response.Write("<script language='javascript'> { alert('Employee Picture successfully uploaded /n please reload image.'); window.close();}</script>");
                }
            }
        }

       

    
    }
}