using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class profile : System.Web.UI.Page
    {
        Functions.Functions function = new Functions.Functions();
        midLineDBEntities db = new midLineDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {            
            int id = Convert.ToInt16(Session["USERID"].ToString());
            int rankingUp=0;
            int rankingDown = 0;
            var currentUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            username.InnerText = currentUser.Username;
            fullName.InnerText = currentUser.FullName;
            Mobile.InnerText = currentUser.MobileNumber;
            city.InnerText = currentUser.City;
            
           
             userType.InnerText = "مريض"; 
            if (currentUser.ProfilePhoto != null)
            {
                Image.ImageUrl = function.image_retrive(id);
            }
            Session["reportedUser"] = currentUser.Id;
            foreach (var rate in db.Ratings)
            {
                if (rate.RatedForUser == id && rate.RateValue>=2)
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



        protected void report_btn_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ReportPage.aspx");
        }

        protected void rate_Click(object sender, EventArgs e)
        {
            int rateCount=0;
            int ratedForID = Convert.ToInt16(Session["USERID"].ToString());
            int ratedID = Convert.ToInt16(Session["userId"].ToString());
            foreach(var rate in db.Ratings)
            {
                if(rate.RatedUser==ratedID && rate.RatedForUser == ratedForID)
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
    }
}