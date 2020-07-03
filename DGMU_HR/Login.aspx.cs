using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DGMU_HR
{
    public partial class Login : System.Web.UI.Page
    {
        SystemX oSystem = new SystemX();

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtUsername.Text = "1";
            //txtPassword.Text = "1";

      
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                DataTable dt = oSystem.GET_USER_INFO(txtUsername.Text, txtPassword.Text);

                if (dt.Rows.Count > 0)
                {
                    DataView dv = dt.DefaultView;
                    foreach (DataRowView drv in dv)
                    {
                        Session["USER"] = drv["Username"].ToString();
                        Response.Redirect("~/home.aspx");
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Invalid username and password.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
                }


            }
            else {
                lblErrorMessage.Text = "Username and Password required!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>$('#msgErrorModal').modal('show');</script>", false);
            }
        }
    }
}