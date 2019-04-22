using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class contactus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {
            midLineDBEntities db = new midLineDBEntities();
            var newMsg = new Message
            {
                userEmail = email.Text,
                Subject = subject.Text,
                Message1 = mesg.InnerText
            };
            db.Messages.Add(newMsg);
            db.SaveChanges();
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if(Session["LoggedIn"].ToString() == "1")
            {
                Response.Redirect("DrsHome.aspx");
            }
            else
            {
                Response.Redirect("homePage.aspx");
            }
            
        }
    }
}