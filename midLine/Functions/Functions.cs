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
        public string image_retrive(int userid)
        {


            var myEntity = new midLineDBEntities();

            var query = myEntity.Users.Where(p => p.Id == userid)
                           .Select(p => p.ProfilePhoto).FirstOrDefault();

            if (query != null)
            {
                byte[] bytes = query;
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);



                return "data:image/png;base64," + base64String;

            }
            else
            {
                return "item_logo.png";
            }
        }
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
                Session["user"] = user3.Id;
                if (myUser.UserType == 1) { usertype = 1; }
                else if (myUser.UserType == 2) { usertype = 2; }
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

        public bool UpdateInfo(int id, TextBox price, string department, TextBox availableTime,string major,string address, byte[] img)
        {
            midLineDBEntities db = new midLineDBEntities();
            var user = db.Users.Where(x => x.Id==id).FirstOrDefault();
            if (user != null)
            {

                user.Price = price.Text;
                user.Department = department;
                user.AvailableTime = availableTime.Text;
                user.Major = major;
                user.Address = address;
                user.CertificatePhoto = img;
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
            LinkButton link ;
           
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
                    /* link code */
                    link = new LinkButton();
                    link.Text = request.User1.FullName;
                    link.ID = request.User1.Id.ToString();                    
                    link.Click += delegate (object sender, EventArgs e) { LinkedProfile_Click(sender, e); };                    
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
                    div2.Controls.Add(link);
                    div1.Controls.Add(div2);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(div4);
                   
                    control.Controls.Add(div1);

                }
            }
            }
        public void RetrivePatientAppointments(int id, HtmlGenericControl control)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div1, div2, div3, div4, h5, h52, img_div1, hr, status;
            LinkButton link;

            midLineDBEntities db = new midLineDBEntities();

            foreach (var request in db.AppointmentRequests)
            {
                if (request.PatientID == id)
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
                    /* link code */
                    link = new LinkButton();
                    link.Text = "الدكتور " + request.User1.FullName;
                    link.ID = request.User1.Username;
                    link.Click += delegate (object sender, EventArgs e) { LinkedProfileDr_Click(sender, e); };
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
                   
                    if (request.isAccepted == null)
                    {
                        status.InnerText = "معلق";
                        div4.Controls.Add(status);
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
                    div2.Controls.Add(link);
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
        protected void LinkedProfile_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string ID = button.ID;
            Session["USERID"] = ID;
            HttpContext.Current.Response.Redirect("profile.aspx");

        }
        public void RetriveDoctors(HtmlGenericControl control,string department)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div1, div2, div3, div4, h52, h53,h54,h55, img_div1, hr, status;
            Button request;
            LinkButton link;

            midLineDBEntities db = new midLineDBEntities();

            foreach (var doctor in db.Users)
            {
                if (doctor.Department == department &&doctor.isActive==true)
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
                  
                    /* h52 code */
                    h52 = new HtmlGenericControl("p");
                    h52.Attributes["class"] = "card-text";
                    h52.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h52.InnerText = doctor.AvailableTime;
                    /*---------------------------------*/
                    /* h53 code */
                    h53 = new HtmlGenericControl("p");
                    h53.Attributes["class"] = "card-text";
                    h53.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h53.InnerText = doctor.City +"-"+doctor.Address;
                    /*---------------------------------*/
                    /* h54 code */
                    h54 = new HtmlGenericControl("p");
                    h54.Attributes["class"] = "card-text";
                    h54.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h54.InnerText ="سعر الكشفية :"+ doctor.Price;
                    /*---------------------------------*/
                    /* h55 code */
                    h55 = new HtmlGenericControl("p");
                    h55.Attributes["class"] = "card-text";
                    h55.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h55.InnerText = "التخصص" + doctor.Major;
                    /*---------------------------------*/
                    /* status code */
                    status = new HtmlGenericControl("p");
                    status.Attributes["class"] = "card-text gray";
                    status.Style.Add(HtmlTextWriterStyle.MarginRight, "5ex");
                    status.Style.Add(HtmlTextWriterStyle.Color, "gray");

                    /*---------------------------------*/
                    /* link code */
                    link = new LinkButton();
                    link.Text ="الدكتور "+ doctor.FullName;
                    link.ID = doctor.Username;
                    link.Click += delegate (object sender, EventArgs e) { LinkedProfileDr_Click(sender, e); };
                    /*---------------------------------*/
                    /* hr code */
                    hr = new HtmlGenericControl(HtmlTextWriterTag.Hr.ToString());

                    /*---------------------------------*/
                    /* accept code */
                    request = new Button();
                    request.Text = "حجز موعد";
                    request.ID = doctor.Id.ToString();
                    request.CssClass = "btn btn-primary";
                    request.Click += delegate (object sender, EventArgs e) { request_btn_Click(sender, e); };
                    request.Style.Add(HtmlTextWriterStyle.Width, "30%");
                    request.Style.Add(HtmlTextWriterStyle.Margin, "1ex");

                    /*---------------------------------*/




                    div2.Controls.Add(img_div1);
                    div2.Controls.Add(link);
                    div1.Controls.Add(div2);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(h53);
                    div1.Controls.Add(h54);
                    div1.Controls.Add(h55);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(div4);
                    div1.Controls.Add(request);

                    control.Controls.Add(div1);

                }
            }
        }
        protected void LinkedProfileDr_Click(object sender, EventArgs e)
        {

            midLineDBEntities db = new midLineDBEntities();
            LinkButton button = (LinkButton)sender;
            string ID = button.ID;

            Session["USERID"] = ID;
            var doctor = db.Users.Where(x => x.Username == ID).FirstOrDefault();
            Session["doctorid"] = doctor.Id;
            HttpContext.Current.Response.Redirect("drprofile.aspx");

        }
        public void RetriveDoctorsFilter(HtmlGenericControl control, string department,string city)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div1, div2, div3, div4, h5, h52, h53, h54, img_div1, hr, status;
            Button request;
            control.Controls.Clear();
            
            midLineDBEntities db = new midLineDBEntities();

            foreach (var doctor in db.Users)
            {
                if (doctor.Department == department&&doctor.City==city)
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
                    h5.InnerText = doctor.FullName;
                    /*---------------------------------*/
                    /* h52 code */
                    h52 = new HtmlGenericControl("p");
                    h52.Attributes["class"] = "card-text";
                    h52.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h52.InnerText = doctor.AvailableTime;
                    /*---------------------------------*/
                    /* h53 code */
                    h53 = new HtmlGenericControl("p");
                    h53.Attributes["class"] = "card-text";
                    h53.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h53.InnerText = doctor.City;
                    /*---------------------------------*/
                    /* h54 code */
                    h54 = new HtmlGenericControl("p");
                    h54.Attributes["class"] = "card-text";
                    h54.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h54.InnerText = "سعر الكشفية :" + doctor.Price;
                    /*---------------------------------*/
                    /* status code */
                    status = new HtmlGenericControl("p");
                    status.Attributes["class"] = "card-text gray";
                    status.Style.Add(HtmlTextWriterStyle.MarginRight, "5ex");
                    status.Style.Add(HtmlTextWriterStyle.Color, "gray");

                    /*---------------------------------*/
                    /* hr code */
                    hr = new HtmlGenericControl(HtmlTextWriterTag.Hr.ToString());

                    /*---------------------------------*/
                    /* accept code */
                    request = new Button();
                    request.Text = "حجز موعد";
                    request.ID = doctor.Id.ToString();
                    request.CssClass = "btn btn-primary";
                    request.Click += delegate (object sender, EventArgs e) { request_btn_Click(sender, e); };
                    request.Style.Add(HtmlTextWriterStyle.Width, "30%");
                    request.Style.Add(HtmlTextWriterStyle.Margin, "1ex");

                    /*---------------------------------*/




                    div2.Controls.Add(img_div1);
                    div2.Controls.Add(h5);
                    div1.Controls.Add(div2);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(h53);
                    div1.Controls.Add(h54);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(div4);
                    div1.Controls.Add(request);

                    control.Controls.Add(div1);

                }
            }
        }

        protected void request_btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["doctorId"] = button.ID;
            midLineDBEntities db = new midLineDBEntities();
            int patientid = Convert.ToInt16(Session["user"].ToString());
            var count = db.AppointmentRequests.Where(x => x.PatientID == patientid).FirstOrDefault();
            if (count == null)
            {
                HttpContext.Current.Response.Redirect("AppRequest.aspx");
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('لايمكنك طلب اكثر من موعد ');</script>");
               

            }

        }
        public void RetrivePosts(HtmlGenericControl control,int userType)
        {

            System.Web.UI.HtmlControls.HtmlGenericControl div1, div2, div3, div4,div5,commentBody,commentTime,footer, commenterName, h52, hr, status;
            LinkButton link;
            Button commentBtn;
            TextBox commentText;
            midLineDBEntities db = new midLineDBEntities();

            foreach (var post in db.Posts)
            {
               
                
                    /* div1 code */
                    div1 = new HtmlGenericControl("div");
                    div1.Attributes["class"] = "card m-2";
                    div1.Style.Add(HtmlTextWriterStyle.Padding, "2ex");
                    div1.Style.Add(HtmlTextWriterStyle.Width, "90%");
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

                /* link code */
                link = new LinkButton();
                    link.Text =  post.User.FullName;
                    link.ID = post.User.Username;
                    link.Font.Size = FontUnit.XLarge;
                    link.Click += delegate (object sender, EventArgs e) { LinkedProfileDr_Click(sender, e); };
                    /*---------------------------------*/
                    /* h52 code */
                    h52 = new HtmlGenericControl("h4");
                    h52.Attributes["class"] = "card-text";
                    h52.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    h52.InnerText = post.PostDate.ToString();
                    /*---------------------------------*/
                    /* h52 code */
                    status = new HtmlGenericControl("h4");
                    status.Attributes["class"] = "card-text gray";
                    status.Style.Add(HtmlTextWriterStyle.MarginRight, "5ex");
                    status.InnerText = post.PostText;
                    /*---------------------------------*/
                    /* hr code */
                    hr = new HtmlGenericControl(HtmlTextWriterTag.Hr.ToString());

                /*---------------------------------*/
              
                commentText = new TextBox();
                commentText.Attributes["placeholder"] = "اكتب تعليقا...";
                commentText.ID = post.User.Username +DateTime.Today.Millisecond.ToString();
                commentText.Style.Add(HtmlTextWriterStyle.Width, "90%");
                commentText.CssClass = "form-control col m-2";

                /* link code */
                commentBtn = new Button();
                commentBtn.Text = "تعليق";
                commentBtn.ID = post.User.Id.ToString();
                commentBtn.Font.Size = FontUnit.XLarge;
                commentBtn.Click += delegate (object sender, EventArgs e) { comment_Click(sender, e,commentText.Text); };
                commentBtn.CssClass = "btn btn-primary float-right col m-2";
                /*---------------------------------*/

                footer = new HtmlGenericControl("div");
                footer.Attributes["class"] = "row";
                footer.ID = post.ID.ToString();
                footer.Style.Add(HtmlTextWriterStyle.Width, "90%");
                footer.Controls.Add(commentText);
                footer.Controls.Add(commentBtn);

                div2.Controls.Add(link);
                    div1.Controls.Add(div2);
                    div1.Controls.Add(hr);
                    div1.Controls.Add(h52);
                    div1.Controls.Add(status);
                    div1.Controls.Add(hr);
                    foreach(var comment in post.Comments)
                {
                    /* link code */
                    commenterName = new HtmlGenericControl("p");
                    commenterName.InnerText = comment.User.FullName;                   
                    
                    /*---------------------------------*/
                    /* h52 code */
                    commentTime = new HtmlGenericControl("h3");
                    commentTime.Attributes["class"] = "card-text float-left";
                    commentTime.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                    commentTime.InnerText = comment.CommentDate.ToString();
                    /*---------------------------------*/
                    /* h52 code */
                    commentBody = new HtmlGenericControl("p");
                    commentBody.Attributes["class"] = "card-text gray";
                    commentBody.Style.Add(HtmlTextWriterStyle.MarginRight, "5ex");
                    commentBody.InnerText = comment.CommentText;
                    /*---------------------------------*/
                    div5 = new HtmlGenericControl("div");
                    div5.Attributes["class"] = "row";
                    div5.Attributes["class"] = "card m-1";
                    div5.Style.Add(HtmlTextWriterStyle.Width, "90%");
                    div5.Controls.Add(commenterName);
                    //div5.Controls.Add(commentTime);
                    div5.Controls.Add(commentBody);
                    div4.Controls.Add(div5);
                    div1.Controls.Add(div4);
                }
                if (userType == 1)
                {
                    div1.Controls.Add(footer);
                }
                control.Controls.Add(div1);

                
            }
        }
        protected void comment_Click(object sender, EventArgs e,string commentText)
        {

            midLineDBEntities db = new midLineDBEntities();
            Button button = (Button)sender;
            int userId =Convert.ToInt16(button.ID);
            int postId = Convert.ToInt16(button.Parent.ID);
            Comment newComment = new Comment {
                DR_ID = userId,
                PostID = postId,
                CommentDate = DateTime.Now,
                CommentText = commentText

            };
            db.Comments.Add(newComment);
            db.SaveChanges();
           

        }
    }
}