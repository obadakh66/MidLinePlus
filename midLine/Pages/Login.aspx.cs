﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && username.Text != null)
            {
                var myUser = new User
                {
                    Username = username.Text,

                    Password = pass.Text
                };

                midLineDBEntities db = new midLineDBEntities();
                var currentUser = db.Users.Where(x => x.Username == username.Text).FirstOrDefault();
                Functions.Functions login_fun = new Functions.Functions();
                if (login_fun.login(myUser) == 1 || login_fun.login(myUser) == 2)
                {
                    Session["LoggedIn"] = 1;
                    Response.Redirect("DrsHome.aspx");
                    
                }
                else if (login_fun.login(myUser) == 3)
                {
                    Session["LoggedIn"] = 3;
                    Response.Redirect("homePage.aspx");
                }
                else if (login_fun.login(myUser) == 4)
                {

                    Response.Redirect("AdminHome.aspx");
                }
                else
                {
                    
                        errorValid.Attributes.Remove("hidden");
                  
                }
            }
            else
            {
                errorRequired.Attributes.Remove("hidden");
            }

        }
    }
}