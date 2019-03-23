using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_btn_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Username = Username.Text,
                FullName = FullName.Text,
                Password = Password.Text,
                MobileNumber = MobileNumber.Text,
                City = City.SelectedItem.ToString(),
                Gender = Gender.SelectedItem.ToString(),

            };

            midLineDBEntities1 db = new midLineDBEntities1();
            db.Users.Add(newUser);
            db.SaveChanges();
        }
    }
}