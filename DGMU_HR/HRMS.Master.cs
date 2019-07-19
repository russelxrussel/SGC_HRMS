﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace DGMU_HR
{
    public partial class HRMS : System.Web.UI.MasterPage
    {
        SystemX oSystem = new SystemX();
        protected void Page_Load(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            DataTable dt = oSystem.GET_USER_MENU().Tables[0];
            DataRow[] parentMenus = dt.Select("ParentMenuId = 0 or ParentMenuId is null");

            string unorderelist = generateMenus(parentMenus, dt, sb);


            var sb2 = new StringBuilder();
            sb2.Append("<ul  class=\"nav navbar-nav\">");
            sb2.Append(unorderelist);
            sb2.Append("</ul>");
            myDiv.InnerHtml = sb2.ToString();
        }

        private string generateMenus(DataRow[] menu, DataTable dt, StringBuilder sb)
        {
            // sb.Append("<ul  class=\"nav navbar-nav\">");
            if (menu.Length > 0)
            {

                foreach (DataRow dr in menu)
                {
                    bool flgMenuChild = (bool)dr["flgChild"];

                    string urlPosition = dr["Position"].ToString();
                    string urlText = dr["URL"].ToString();
                    string menuText = dr["MenuText"].ToString();
                    string menuID = dr["MenuID"].ToString();
                    string parentID = dr["ParentMenuID"].ToString();

                    string line;

                    //Condition will be true if menu have parent.
                    if (flgMenuChild)
                    {

                        if (urlPosition == "MID") //Main Menu Children
                        {

                            line = string.Format(@"<li class=""dropdown-submenu""><a href=""{0}"" class=""dropdown-toggle"" data-toggle=""dropdown"">{1} </a>", urlText, menuText, @"</li>");
                        }

                        else
                        {
                            //if (menuText == "HOME")
                            //{
                            //    line = string.Format(@"<li><a href=""{0}"" class=""dropdown-toggle"" data-toggle=""dropdown""><span class=""glyphicon glyphicon-home""></span> {1}</a>", urlText, menuText, @"</li>"); 
                            //}

                            //else
                            //{
                            if (urlPosition == "TOP") //Main Menu
                            {
                                line = string.Format(@"<li><a href=""{0}"" class=""dropdown-toggle"" data-toggle=""dropdown""> {1} <span class=""caret""></span></a>", urlText, menuText, @"</li>");
                            }
                            else //SubMenu Children
                            {
                                line = string.Format(@"<li class=""dropdown-menu""><a href=""{0}"" class=""dropdown-toggle"" data-toggle=""dropdown""> {1} </a>", urlText, menuText, @"</li>");
                            }
                            //}
                        }
                    }

                    else //No parent link
                    {
                        if (menuText == "HOME")
                        {
                            line = string.Format(@"<li><a href=""{0}"" class=""dropdown-toggle"" data-toggle=""dropdown""><span class=""glyphicon glyphicon-home""></span> {1}</a>", urlText, menuText, @"</li>");
                        }
                        else
                        {
                            line = string.Format(@"<li><a href=""{0}""><span class=""glyphicon glyphicon-globe""></span>  {1}</a>", urlText, menuText, @"</li>");
                        }

                    }



                    sb.Append(line);



                    //Recursive 


                    DataRow[] subMenu = dt.Select(String.Format("ParentMenuId = {0}", menuID));
                    if (subMenu.Length > 0 && !menuID.Equals(parentID))
                    {

                        var subMenuBuilder = new StringBuilder();
                        sb.Append("<ul class=\"dropdown-menu multi-level\">");
                        sb.Append(generateMenus(subMenu, dt, subMenuBuilder));
                        sb.Append("</ul>");
                    }



                } //End of Foreach

            }

            // sb.Append("</ul>");

            return sb.ToString();

        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}