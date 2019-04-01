using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class edit_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Session["userId"].ToString());
            midLineDBEntities db = new midLineDBEntities();
            var currentUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            username.Text = currentUser.Username;
            FullName.Text = currentUser.FullName;
            MobileNumber.Text = currentUser.MobileNumber;
            Password.Text = currentUser.Password;
          
           
        }

        protected void save_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Session["userId"].ToString());
            midLineDBEntities db = new midLineDBEntities();
            var currentUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            currentUser.Username =  username.Text;
            currentUser.FullName  = FullName.Text;
            currentUser.MobileNumber = MobileNumber.Text;
            currentUser.Password =   Password.Text;
            
            if (imgUploader.PostedFile != null)
            {

                byte[] bytes;
                using (BinaryReader br = new BinaryReader(imgUploader.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(imgUploader.PostedFile.ContentLength);
                }
                currentUser.ProfilePhoto = bytes;
            }
            db.SaveChanges();
        }
    
    }
}