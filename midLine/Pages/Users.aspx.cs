using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.Functions function = new Functions.Functions();
            function.CallUsers(doctorsTable, modalImage,con,1);
            function.CallUsers(nursesTable, modalImage, con, 2);
            function.CallPatients(patients);
        }

        protected void close_Click(object sender, EventArgs e)
        {
            con.Attributes.Add("hidden","hidden");
        }
    }
}