using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace midLine.Functions
{
    public class Functions : System.Web.UI.Page
    {
        public int login(User user)
        {

            midLineDBEntities db = new midLineDBEntities();
            var myUser = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            var user2 = from u in db.Users
                        where u.Username == user.Username
                        select u;
            var user3 = user2.FirstOrDefault<User>();
            if (myUser != null && myUser.UserType != 4)    //User was found
            {

                string name = user.Username; ;
                Session["name"] = name;
                string userName = name;
                Session["userName"] = userName;
                string full_name = user.FullName;
                Session["full_name"] = full_name;
                Session["userID"] = user3.Id;
                Session["edit_user"] = user3;
                return 1;
            }
            else if (myUser != null && myUser.UserType == 4)   //User was not found
            {
                string name = user.Username; ;
                Session["name"] = name;
                string userName = name;
                Session["userName"] = userName;
                string full_name = user3.FullName;
                Session["full_name"] = full_name;
                Session["userID"] = user3.Id;
                Session["edit_user"] = user3;
                return 2;
            }
            else { return 0; }



        }
    }
}