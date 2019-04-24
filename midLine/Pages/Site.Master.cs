using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                midLineDBEntities db = new midLineDBEntities();
                int id = Convert.ToInt16(Session["user"].ToString());
                var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                if(user.UserType==1 || user.UserType == 2)
                { drHome.Attributes.Remove("hidden"); }
                if (user.UserType == 3)
                { userHome.Attributes.Remove("hidden"); }
                logout.Attributes.Remove("hidden");
                community.Attributes.Remove("hidden");
            
            }
            else
            {
                login.Attributes.Remove("hidden");
                signup.Attributes.Remove("hidden");
            }
        }
    }
}