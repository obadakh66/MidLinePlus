using System;
using System.Collections.Generic;
using System.IO;
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
            var appCount = db.AppointmentRequests.Where(x => x.DoctorID == Dr_ID).Count();
            var ratingCount = db.Ratings.Where(x => x.RatedForUser == Dr_ID).Count();
            int ratingSum = 0;
            foreach (var rate in db.Ratings)
            {
                if (rate.RatedForUser == Dr_ID)
                {
                    ratingSum += rate.RateValue;
                }
            }
            if (ratingCount != 0)
            {
                int ratingAVg = ratingSum / ratingCount;
                ratingAvg.InnerText += "5/"+ratingAVg.ToString();
            }
            var pendingRequests = db.AppointmentRequests.Where(x => x.DoctorID == Dr_ID && x.isAccepted == null).Count();
            appcount.InnerText += appCount.ToString();
            
            PendingRequests.InnerText += pendingRequests.ToString();
            var doctor = db.Users.Where(x => x.Id == Dr_ID).FirstOrDefault();
            if (doctor.Price == null)
            {
                DrForm.Attributes.Remove("hidden");
            }
            else
            {
                InfoForm.Attributes.Remove("hidden");

            }
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            byte[] bytes;
            bool result;
            string DR_ID = Session["userID"].ToString();
            int Dr_ID = Convert.ToInt16(DR_ID);
            Functions.Functions heartdoctors = new Functions.Functions();
            if (imgUploader.PostedFile != null)
            {


                using (BinaryReader br = new BinaryReader(imgUploader.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(imgUploader.PostedFile.ContentLength);
                }
                result = heartdoctors.UpdateInfo(Dr_ID, price, Departments.SelectedItem.Text, availableTime, specilized.Text, Address.Text, bytes);
                if (result == true)
                {
                    successAlert.Attributes.Remove("hidden");
                    updateForm.Visible = false;
                }
            }
            else
            {
                result = heartdoctors.UpdateInfo(Dr_ID, price, Departments.SelectedItem.Text, availableTime, specilized.Text, Address.Text, null);

                if (result == true)
                {
                    successAlert.Attributes.Remove("hidden");
                    updateForm.Visible = false;
                }
            }
        }
    }
}