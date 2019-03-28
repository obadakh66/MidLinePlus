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
            midLineDBEntities db = new midLineDBEntities();
            int check=0;
            foreach(var user in db.Users)
            {
                if (user.Username == Username.Text)
                {
                    check = 1;
                }
            }
            if (check != 1)
            {
                User newUser = new User
                {
                    Username = Username.Text,
                    FullName = FullName.Text,
                    Password = Password.Text,
                    MobileNumber = MobileNumber.Text,
                    City = City.SelectedItem.ToString(),
                    Gender = Gender.SelectedItem.ToString(),
                    UserType = Convert.ToInt16(UserType.SelectedValue),
                };

                if (newUser != null && !newUser.Username.Contains(" "))
                {

                    db.Users.Add(newUser);
                    db.SaveChanges();
                    successAlert.Attributes.Remove("hidden");
                }
                else
                {

                    failedAlert.Attributes.Remove("hidden");
                }
            }
            else
            {
                usernameAlert.Attributes.Remove("hidden");
            }
        }
    }
}