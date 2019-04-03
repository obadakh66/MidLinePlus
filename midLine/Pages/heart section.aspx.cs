using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class heart_section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.Functions heartdoctors = new Functions.Functions();
            heartdoctors.RetriveDoctors(heartDoctors,"قسم القلب");
            Session["userId"] = Session["userId"];
        }

        protected void search_Click(object sender, EventArgs e)
        {
            Functions.Functions heartdoctors = new Functions.Functions();
            heartdoctors.RetriveDoctorsFilter(heartDoctors, "قسم القلب",city.SelectedItem.Text);
        }
    }
}