using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace midLine.Functions
{
    public class Functions : System.Web.UI.Page
    {
        public int login(User user)
        {
            int usertype;
            midLineDBEntities db = new midLineDBEntities();
            var myUser = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            var user2 = from u in db.Users
                        where u.Username == user.Username
                        select u;
            var user3 = user2.FirstOrDefault<User>();
            if (myUser != null && myUser.UserType != 4)    //User was found
            {

                string name = user.Username;
                Session["name"] = name;
                string userName = name;
                Session["userName"] = userName;
                string full_name = user.FullName;
                Session["full_name"] = full_name;
                Session["userID"] = user3.Id;
                Session["edit_user"] = user3;
                if (user.UserType == 1) { usertype = 1; }
                else if (user.UserType == 2) { usertype = 2; }
                else{ usertype=3; }
                
                return usertype;
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
                return 4;
            }
            else { return 0; }



        }

        public bool UpdateInfo(int id, TextBox price, TextBox department, TextBox availableTime)
        {
            midLineDBEntities db = new midLineDBEntities();
            var user = db.Users.Where(x => x.Id==id).FirstOrDefault();
            if (user != null)
            {

                user.Price = price.Text;
                user.Department = department.Text;
                user.AvailableTime = availableTime.Text;

                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RetriveAppointments(int id, HtmlGenericControl control)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div1, div2,div3,div4, h5, h52,img_div1,hr,status;
            Button acceptRequest;
            Button rejectRequest;

           
            midLineDBEntities db = new midLineDBEntities();
           
            foreach (var request in db.AppointmentRequests)
            {
                if (request.DoctorID == id )
                {
                    /* div1 code */
                    div1 = new HtmlGenericControl("div");
                    div1.Attributes["class"] = "card m-2";
                    div1.Style.Add(HtmlTextWriterStyle.Padding, "2ex");
                    div1.Style.Add(HtmlTextWriterStyle.Width, "20rem");
                    /*---------------------------------*/
                    /* div2 code */
                    div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "card-body row";
                    /*---------------------------------*/
                    /* div3 code */
                    div3 = new HtmlGenericControl("div");
                    div3.Attributes["class"] = "row";

                    /* div4 code */
                    div4 = new HtmlGenericControl("div");
                    div4.Attributes["class"] = "row";
                    /*---------------------------------*/
                    /* img code */
                    img_div1 = new HtmlGenericControl("img");
                    img_div1.Attributes["class"] = "rounded-circle ml-2";
                    img_div1.Attributes["src"] = "../1.png";
                    img_div1.Attributes["width"] = "40";
                    img_div1.Attributes["height"] = "40";
                    /*---------------------------------*/
                    /* h5 code */
                    h5 = new HtmlGenericControl("h5");
                    h5.Attributes["class"] = "card-title";
                    h5.InnerText = request.User1.FullName;
                    /*---------------------------------*/
                    /* h52 code */
                    h52 = new HtmlGenericControl("p");
                    h52.Attributes["class"] = "card-text";
                    h52.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h52.InnerText = request.Time;
                    /*---------------------------------*/
                    /* h52 code */
                    status = new HtmlGenericControl("p");
                    status.Attributes["class"] = "card-text gray";
                    status.Style.Add(HtmlTextWriterStyle.MarginRight, "5ex");
                    status.Style.Add(HtmlTextWriterStyle.Color, "gray");
                    
                    /*---------------------------------*/
                    /* hr code */
                    hr = new HtmlGenericControl(HtmlTextWriterTag.Hr.ToString());
                   
                    /*---------------------------------*/
                    /* accept code */
                    acceptRequest = new Button();
                    acceptRequest.Text = "قبول";
                    acceptRequest.ID = "accept" + request.ID;
                    acceptRequest.CssClass = "btn btn-primary";
                    acceptRequest.Click += delegate (object sender, EventArgs e) { accept_btn_Click(sender, e,request.ID); };
                    acceptRequest.Style.Add(HtmlTextWriterStyle.Width, "30%");
                    acceptRequest.Style.Add(HtmlTextWriterStyle.Margin, "1ex");
                    /*---------------------------------*/
                    /* reject code */
                    rejectRequest = new Button();
                    rejectRequest.Text = "رفض";
                    rejectRequest.ID = "reject" + request.ID;
                    rejectRequest.CssClass = "btn btn-danger";
                    rejectRequest.Click += delegate (object sender, EventArgs e) { reject_btn_Click(sender, e,request.ID); };
                    rejectRequest.Style.Add(HtmlTextWriterStyle.Width, "30%");
                    rejectRequest.Style.Add(HtmlTextWriterStyle.Margin, "1ex");
                    /*---------------------------------*/
                    if (request.isAccepted == null)
                    {
                        div4.Controls.Add(acceptRequest);
                        div4.Controls.Add(rejectRequest);
                    }
                    else if (request.isAccepted == true)
                    {
                        status.InnerText = "مقبول";
                        div4.Controls.Add(status);
                    }
                    else
                    {
                        status.InnerText = "مرفوض";
                        div4.Controls.Add(status);
                    }

                        div2.Controls.Add(img_div1);
                    div2.Controls.Add(h5);
                    div1.Controls.Add(div2);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(div4);
                   
                    control.Controls.Add(div1);

                }
            }
            }
        protected void accept_btn_Click(object sender, EventArgs e,int requestId)
        {
            midLineDBEntities db = new midLineDBEntities();
            var request = db.AppointmentRequests.Where(x => x.ID == requestId).FirstOrDefault();
            request.isAccepted = true;
            db.SaveChanges();
            
        }
        protected void reject_btn_Click(object sender, EventArgs e,int requestId)
        {
            midLineDBEntities db = new midLineDBEntities();
            var request = db.AppointmentRequests.Where(x => x.ID == requestId).FirstOrDefault();
            request.isAccepted = !true;
            db.SaveChanges();
        }
    }
}