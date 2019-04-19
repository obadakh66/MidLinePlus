using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class drprofile : System.Web.UI.Page
    {
        Functions.Functions function = new Functions.Functions();
        midLineDBEntities db = new midLineDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {         
            
                string username = Session["USER"].ToString();
                int rankingUp = 0;
                int rankingDown = 0;
                var currentUser = db.Users.Where(x => x.Username == username).FirstOrDefault();
            int id = currentUser.Id;
            doctorName.InnerText += currentUser.FullName;
                FullName.InnerText = currentUser.FullName;
                Major.InnerText = currentUser.Major;
                City.InnerText = currentUser.City +"-"+currentUser.Address;
            Price.InnerText = currentUser.Price;
                if (currentUser.UserType == 1) { userType.InnerText = "دكتور"; }
                if (currentUser.UserType == 2) { userType.InnerText = "ممرض"; }
                
                if (currentUser.ProfilePhoto != null)
                {
                    image.ImageUrl = function.image_retrive(id);
                }
                Session["reportedUser"] = currentUser.Id;
                foreach (var rate in db.Ratings)
                {
                    if (rate.RatedForUser == id && rate.RateValue >= 2)
                    {
                        rankingUp += 1;
                    }
                    if (rate.RatedForUser == id && rate.RateValue < 2)
                    {
                        rankingDown += 1;
                    }
                }
                ratesUp.InnerText = rankingUp.ToString();
                ratesDown.InnerText = rankingDown.ToString();
            }

        protected void rate_Click(object sender, EventArgs e)
        {
            int rateCount = 0;
            int ratedForID = Convert.ToInt16(Session["doctorid"].ToString());
            int ratedID = Convert.ToInt16(Session["user"].ToString());
            foreach (var rate in db.Ratings)
            {
                if (rate.RatedUser == ratedID && rate.RatedForUser == ratedForID)
                {
                    rateCount = 1;
                }
            }
            if (rateCount == 1)
            {
                failedAlert.Attributes.Remove("hidden");
            }
            else
            {
                Rating newRate = new Rating
                {
                    RatedUser = ratedID,
                    RatedForUser = ratedForID,
                    RateValue = Convert.ToInt16(dropdownlistrate.SelectedItem.Value)
                };
                db.Ratings.Add(newRate);
                db.SaveChanges();
            }

        
    }

        protected void report_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportPage.aspx");
        }
    }
}