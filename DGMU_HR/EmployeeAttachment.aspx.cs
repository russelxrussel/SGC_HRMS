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
    public partial class EmployeeAttachment : System.Web.UI.Page
    {
        Employee_Data_C oEmployeeData = new Employee_Data_C();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
            DISPLAY_EMPLOYEE_ATTACHMENTS(Session["EMPLOYEEID"].ToString());
            }

        }

        protected void lnkUploadFile_Click(object sender, EventArgs e)
        {
            if (fuAttachment.HasFile && !string.IsNullOrEmpty(txtAttachmentFileName.Text))
            {
                fuAttachment.SaveAs(Server.MapPath("~/Uploads/EmployeeAttachment/" + fuAttachment.FileName.ToString()));
                string fullPath = "~/Uploads/EmployeeAttachment/" + fuAttachment.FileName.ToString();
                FileInfo fi = new FileInfo(fullPath);
                oEmployeeData.INSERT_EMPLOYEE_ATTACHMENT(Session["EMPLOYEEID"].ToString(),  fi.Name, txtAttachmentFileName.Text, fullPath);

                DISPLAY_EMPLOYEE_ATTACHMENTS(Session["EMPLOYEEID"].ToString());
                txtAttachmentFileName.Text = "";
               
            }
        }

        private void DISPLAY_EMPLOYEE_ATTACHMENTS(string _employeeID)
        {
            DataTable dt = oEmployeeData.GET_EMPLOYEE_ATTACHMENTS(_employeeID);

            gvEmployeeAttachments.DataSource = dt;
            gvEmployeeAttachments.DataBind();
        }

        protected void lnkDownloadAttachment_Click(object sender, EventArgs e)
        {
            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;


            string _fileName = r.Cells[3].Text;

            Response.Clear();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(_fileName));
            Response.WriteFile(_fileName);
            Response.End();



        }
    }
}