using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Session["userId"].ToString());
            midLineDBEntities db = new midLineDBEntities();
            var currentUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            username.InnerText = currentUser.Username;
            fullName.InnerText = currentUser.FullName;
            Mobile.InnerText = currentUser.MobileNumber;
            city.InnerText = currentUser.City;
            if (currentUser.UserType == 1)
            { userType.InnerText = "دكتور"; }
            else if(currentUser.UserType == 2)
            { userType.InnerText = "ممرض"; }
            else { userType.InnerText = "مريض"; }
        }



        protected void report_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportPage.aspx");
        }
    }
}