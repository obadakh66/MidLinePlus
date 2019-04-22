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
                logout.Attributes.Remove("hidden");
                community.Attributes.Remove("hidden");
            }
            else
            {
                login.Attributes.Remove("hidden");
            }
        }
    }
}