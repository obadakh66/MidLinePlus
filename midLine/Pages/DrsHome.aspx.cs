using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm6 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string DR_ID = Session["userID"].ToString();
            int Dr_ID = Convert.ToInt16(DR_ID);
            var db = new midLineDBEntities();
            var doctor = db.Users.Where(x => x.Id == Dr_ID).FirstOrDefault();
            if (doctor.Price == null)
            {
                DrForm.Attributes.Remove("hidden");
            }
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            string DR_ID = Session["userID"].ToString();
            int Dr_ID = Convert.ToInt16(DR_ID);
            Functions.Functions heartdoctors = new Functions.Functions();

            bool result = heartdoctors.UpdateInfo(Dr_ID,price,Departments.SelectedItem.Text,availableTime);
            if (result == true) {
                successAlert.Attributes.Remove("hidden");
                updateForm.Visible = false;
            }
        }
    }
}