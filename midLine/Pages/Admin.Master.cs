using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            midLineDBEntities db = new midLineDBEntities();
            AppCount.InnerText = "# Of Appointments : " + db.AppointmentRequests.Count().ToString();
            ReportsCount.InnerText = "# Of Reports : " + db.Reports.Count().ToString();
            UsersCount.InnerText = "# Of Users : " + db.Users.Count().ToString();
            PostCount.InnerText = "# Of Posts : " + db.Posts.Count().ToString();
        }
    }
}