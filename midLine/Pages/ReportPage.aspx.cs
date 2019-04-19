using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void report_btn_modal_Click(object sender, EventArgs e)
        {
            Functions.Functions function = new Functions.Functions();
            int id = Convert.ToInt16(Session["user"].ToString());
            midLineDBEntities db = new midLineDBEntities();
            var newReport = new Report
            {
                ReportedUserID = Convert.ToInt16(Session["reportedUser"].ToString()),
                UserID = id,
                ReportText = item_notes.InnerText.ToString()
            };
            db.Reports.Add(newReport);
            db.SaveChanges();
            report_alert.Attributes.Remove("hidden");
        }
    }
}