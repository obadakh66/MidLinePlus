using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        int doctorID;
        int PatientID;

        protected void Page_Load(object sender, EventArgs e)
        {
            doctorID =Convert.ToInt16(Session["doctorId"].ToString());
            PatientID = Convert.ToInt16(Session["userId"].ToString());

            midLineDBEntities db = new midLineDBEntities();
            var doctor = db.Users.Where(x => x.Id == doctorID).FirstOrDefault();
            var doctorName = doctor.FullName;
            var patient = db.Users.Where(x => x.Id == PatientID).FirstOrDefault();
            var patientName = patient.FullName;

            doctorFullName.Text = doctorName.ToString();
            patientFullName.Text = patientName.ToString();

        }

        protected void appRequest_Click(object sender, EventArgs e)
        {
            midLineDBEntities db = new midLineDBEntities();
            AppointmentRequest appointment = new AppointmentRequest
            {
                DoctorID = doctorID,
                PatientID = PatientID,
                Time = txtDate.Text+"  "+TimeSelector1.Hour.ToString() +":"+ TimeSelector1.Minute.ToString() +" "+ TimeSelector1.AmPm.ToString()
            };
            if (appointment != null)
            {
                db.AppointmentRequests.Add(appointment);
                db.SaveChanges();
                successAlert.Attributes.Remove("hidden");
            }
        }
       
    }
}