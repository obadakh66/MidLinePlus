using System;
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

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var myUser = new User
            {
                Username = username.Text,

                Password = pass.Text
            };


            Functions.Functions login_fun = new Functions.Functions();
            if (login_fun.login(myUser) == 1|| login_fun.login(myUser) == 2)
            {
                Response.Redirect("drHome.aspx");
            }
            else if (login_fun.login(myUser) == 3)
            {
                Response.Redirect("homePage.aspx");
            }
            else
            {
                Response.Redirect("adminPage.aspx");
            }

        }
    }
}