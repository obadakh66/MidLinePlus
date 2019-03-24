using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.Functions fun = new Functions.Functions();
            fun.RetriveAppointments(1, appContainer);
        }
    }
}