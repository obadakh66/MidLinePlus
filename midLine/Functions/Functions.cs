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
                    img_div1.Attributes["src"] = image_retrive(request.DoctorID);
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
        public void RetrivePosts(HtmlGenericControl control, int userType)
        {
            Random random = new Random();
            System.Web.UI.HtmlControls.HtmlGenericControl div1, div2, div3, div4, div5,name,postID,department, commentBody, commentTime, commenterName, h52, hr, status;
            
          
            midLineDBEntities db = new midLineDBEntities();

            foreach (var post in db.Posts)
            {


                /* div1 code */
                div1 = new HtmlGenericControl("div");
                div1.Attributes["class"] = "card m-2";
                div1.Style.Add(HtmlTextWriterStyle.Padding, "2ex");
                div1.Style.Add(HtmlTextWriterStyle.Width, "90%");
                div1.ID = post.ID.ToString() + "=" + random.Next().ToString();
                /*---------------------------------*/
                /* div2 code */
                div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "card-body";
                /*---------------------------------*/
               
                /* div4 code */
                div4 = new HtmlGenericControl("div");
                div4.Attributes["class"] = "row";

                /*---------------------------------*/

                /* link code */
                name = new HtmlGenericControl("h2");
                name.InnerText = post.User.FullName;
                name.Attributes["class"] = "card-text col-md-10";

                /*---------------------------------*/
                /* link code */
                postID = new HtmlGenericControl("p");
                postID.InnerText ="رقم المنشور : " +post.ID.ToString();
                postID.Attributes["class"] = "card-text col";

                /*---------------------------------*/
                /* h52 code */
                department = new HtmlGenericControl("p");
                department.Attributes["class"] = "card-text row";
                department.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                department.InnerText = post.Department.ToString();
                /*---------------------------------*/
                /* h52 code */
                h52 = new HtmlGenericControl("p");
                h52.Attributes["class"] = "card-text gray row";
                h52.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5ex");
                h52.InnerText = post.PostDate.ToString();
                /*---------------------------------*/
              
                /* h52 code */
                status = new HtmlGenericControl("p");
                status.Attributes["class"] = "card-text row";
                status.Style.Add(HtmlTextWriterStyle.MarginRight, "5ex");
                status.InnerText = post.PostText;
                /*---------------------------------*/
                /* hr code */
                hr = new HtmlGenericControl(HtmlTextWriterTag.Hr.ToString());

                div4.Controls.Add(name);
                div4.Controls.Add(postID);

                div2.Controls.Add(div4);
                div2.Controls.Add(department);
                div2.Controls.Add(h52);
                div2.Controls.Add(status);
                div2.Controls.Add(hr);
                div1.Controls.Add(div2);

                
                control.Controls.Add(div1);
               
                foreach (var comment in post.Comments)
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
                    div5.Attributes["class"] = "card m-1 p-5";
                    div5.Style.Add(HtmlTextWriterStyle.Width, "90%");
                    div5.Controls.Add(commenterName);
                    //div5.Controls.Add(commentTime);
                    div5.Controls.Add(commentBody);
                    div1.Controls.Add(div5);
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
                    img_div1.Attributes["src"] = image_retrive(request.PatientID);
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
            HttpContext.Current.Response.Redirect("drAppointments.aspx");
            
        }
        protected void reject_btn_Click(object sender, EventArgs e,int requestId)
        {
            midLineDBEntities db = new midLineDBEntities();
            var request = db.AppointmentRequests.Where(x => x.ID == requestId).FirstOrDefault();
            request.isAccepted = !true;
            db.SaveChanges();
            HttpContext.Current.Response.Redirect("drAppointments.aspx");لا
        }
        protected void LinkedProfile_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string ID = button.ID;
            Session["USERID"] = ID;
            HttpContext.Current.Response.Redirect("profile.aspx");

        }
        protected void comment_Click(object sender, EventArgs e, string commentText)
        {

            midLineDBEntities db = new midLineDBEntities();
            Button button = (Button)sender;
            string ll = button.ID;

            int length = ll.IndexOf("=");
            string ll2 = button.Parent.ID;

            int length2 = ll2.IndexOf("=");
            int userId = Convert.ToInt16(button.ID.Substring(0, length));
            int postId = Convert.ToInt16(button.Parent.ID.Substring(0, length2));
            Comment newComment = new Comment
            {
                DR_ID = userId,
                PostID = postId,
                CommentDate = DateTime.Now,
                CommentText = "okkkk"

            };
            db.Comments.Add(newComment);
            db.SaveChanges();


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
            Session["doctorid"] = doctor.Username;
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
        public void call_messages(HtmlGenericControl users_table)
        {
            HtmlGenericControl main_table = new HtmlGenericControl("Table");
            main_table.Attributes["class"] = "table";
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
          
            cell.Attributes.Add("scope", "col");
            cell2.Attributes.Add("scope", "col");
            cell3.Attributes.Add("scope", "col");
         


            cell.Text = "Email";
            row.Font.Bold = true;
            cell2.Text = "Subject";
            cell3.Text = "Message";
           

            HtmlGenericControl thead = new HtmlGenericControl(HtmlTextWriterTag.Thead.ToString());
            row.Controls.Add(cell);
            row.Controls.Add(cell2);
            row.Controls.Add(cell3);
          
            thead.Controls.Add(row);
            main_table.Controls.Add(thead);

            HtmlGenericControl tbody = new HtmlGenericControl(HtmlTextWriterTag.Tbody.ToString());
            midLineDBEntities db = new midLineDBEntities();
            foreach (var message in db.Messages)
            {

                TableRow row_n = new TableRow();
                TableCell userid = new TableCell();
                userid.Font.Bold = true;
                TableCell fname = new TableCell();
                TableCell lname = new TableCell();
               
                userid.Attributes.Add("scope", "col");
                fname.Attributes.Add("scope", "col");
                lname.Attributes.Add("scope", "col");
              

                userid.Text = message.userEmail;
                fname.Text = message.Subject;
                lname.Text = message.Message1;
              


               


                row_n.Controls.Add(userid);
                row_n.Controls.Add(fname);
                row_n.Controls.Add(lname);
              
                tbody.Controls.Add(row_n);
                main_table.Controls.Add(tbody);
            }

            users_table.Controls.Add(main_table);

        }
        public void CallUsers(HtmlGenericControl users_table,Image img,HtmlGenericControl modal,int userType)
        {
            HtmlGenericControl main_table = new HtmlGenericControl("Table");
            main_table.Attributes["class"] = "table";
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
            TableCell cell7 = new TableCell();
            TableCell cell8 = new TableCell();
            TableCell cell9 = new TableCell();
            cell.Attributes.Add("scope", "col");
            cell2.Attributes.Add("scope", "col");
            cell3.Attributes.Add("scope", "col");
            
            cell5.Attributes.Add("scope", "col");
            cell6.Attributes.Add("scope", "col");
            cell7.Attributes.Add("scope", "col");
            cell8.Attributes.Add("scope", "col");
            cell9.Attributes.Add("scope", "col");


            cell.Text = "ID";
            row.Font.Bold = true;
            cell2.Text = "Full Name";
            cell3.Text = "Major";
           
            cell5.Text = "Username";
            cell6.Text = "Address";
            cell7.Text = "Certificate";
            cell8.Text = "Is Approved";
            cell9.Text = "Activate";

            HtmlGenericControl thead = new HtmlGenericControl(HtmlTextWriterTag.Thead.ToString());
            row.Controls.Add(cell);
            row.Controls.Add(cell2);
            row.Controls.Add(cell3);
           
            row.Controls.Add(cell5);
            row.Controls.Add(cell6);
            row.Controls.Add(cell7);
            row.Controls.Add(cell8);
            row.Controls.Add(cell9);
            thead.Controls.Add(row);
            main_table.Controls.Add(thead);
            Random random = new Random();
            HtmlGenericControl tbody = new HtmlGenericControl(HtmlTextWriterTag.Tbody.ToString());
            midLineDBEntities db = new midLineDBEntities();
            foreach (var doctor in db.Users)
            {
                if (doctor.UserType == userType)
                {
                    TableRow row_n = new TableRow();
                    TableCell userid = new TableCell();
                    userid.Font.Bold = true;
                    TableCell fullname = new TableCell();
                    TableCell major = new TableCell();
                    
                    TableCell username = new TableCell();
                    TableCell address = new TableCell();
                    TableCell certificate = new TableCell();
                    TableCell isapproved = new TableCell();
                    TableCell check2 = new TableCell();
                    userid.Attributes.Add("scope", "col");
                    fullname.Attributes.Add("scope", "col");
                    major.Attributes.Add("scope", "col");
                    username.Attributes.Add("scope", "col");
                    address.Attributes.Add("scope", "col");
                    certificate.Attributes.Add("scope", "col");
                    isapproved.Attributes.Add("scope", "col");
                    check2.Attributes.Add("scope", "col");

                    userid.Text = doctor.Id.ToString();
                    fullname.Text = doctor.FullName;
                    major.Text = doctor.Major;
                    username.Text = doctor.Username;
                    address.Text =doctor.City+"\\"+ doctor.Address;
                    isapproved.Text = doctor.isActive.ToString();


                    LinkButton openCertificate = new LinkButton();
                    openCertificate.Attributes["class"] = "btn btn-secondary";
                  
                    openCertificate.ID = doctor.Id.ToString();
                    openCertificate.Text = "Open Certificate";
                    openCertificate.Click += delegate (object sender, EventArgs e) { Certificate_btn_Click(sender, e,img,modal); };

                    LinkButton activate = new LinkButton();
                    activate.Attributes["class"] = "btn btn-secondary";
                   
                    activate.ID = doctor.Username;
                    activate.Text = "Activate";
                    activate.Click += delegate (object sender, EventArgs e) { Activate_btn_Click(sender, e); };

                    check2.Controls.Add(activate);
                    certificate.Controls.Add(openCertificate);

                    fullname.Attributes.Add("scope", "col");
                    major.Attributes.Add("scope", "col");
                    username.Attributes.Add("scope", "col");
                    address.Attributes.Add("scope", "col");
                    certificate.Attributes.Add("scope", "col");
                    isapproved.Attributes.Add("scope", "col");
                    check2.Attributes.Add("scope", "col");
                    certificate.Attributes.Add("scope", "col");

                    row_n.Controls.Add(userid);
                    row_n.Controls.Add(fullname);
                    row_n.Controls.Add(major);
                    row_n.Controls.Add(username);
                    row_n.Controls.Add(address);
                    row_n.Controls.Add(certificate);
                    row_n.Controls.Add(isapproved);
                    row_n.Controls.Add(check2);
                    tbody.Controls.Add(row_n);

                    main_table.Controls.Add(tbody);
                }
            }

            users_table.Controls.Add(main_table);

        }
        public void Certificate_btn_Click(object sender, EventArgs e, Image img,HtmlGenericControl modal)
        {

            LinkButton button = (LinkButton)sender;
            
            midLineDBEntities db = new midLineDBEntities();
            int id_n = Convert.ToInt16(button.ID);
            var review = from c in db.Users where c.Id == id_n select c;

            var userss = review.FirstOrDefault();
            img.ImageUrl = certificate_retrive(img, userss.Id);
            modal.Controls.Add(img);
            modal.Attributes.Remove("hidden");
        }
        public void Activate_btn_Click(object sender, EventArgs e)
        {

            LinkButton button = (LinkButton)sender;
            
            midLineDBEntities db = new midLineDBEntities();
           
            var review = from c in db.Users where c.Username == button.ID select c;

            var userss = review.FirstOrDefault();
            userss.isActive = true;
            db.SaveChanges();
            HttpContext.Current.Response.Redirect("Users.aspx");
        }
        public string certificate_retrive(Image modal, int userid)
        {


            var myEntity = new midLineDBEntities();

            var query = myEntity.Users.Where(p => p.Id == userid)
                           .Select(p => p.CertificatePhoto).FirstOrDefault();

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
        public void CallPatients(HtmlGenericControl users_table)
        {
            HtmlGenericControl main_table = new HtmlGenericControl("Table");
            main_table.Attributes["class"] = "table";
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
           
            cell.Attributes.Add("scope", "col");
            cell2.Attributes.Add("scope", "col");
            cell5.Attributes.Add("scope", "col");
            cell6.Attributes.Add("scope", "col");
           


            cell.Text = "ID";
            row.Font.Bold = true;
            cell2.Text = "Full Name";
           
            cell5.Text = "Username";
            cell6.Text = "Address";
           

            HtmlGenericControl thead = new HtmlGenericControl(HtmlTextWriterTag.Thead.ToString());
            row.Controls.Add(cell);
            row.Controls.Add(cell2);
            row.Controls.Add(cell5);
            row.Controls.Add(cell6);
          
            thead.Controls.Add(row);
            main_table.Controls.Add(thead);
           
            HtmlGenericControl tbody = new HtmlGenericControl(HtmlTextWriterTag.Tbody.ToString());
            midLineDBEntities db = new midLineDBEntities();
            foreach (var patient in db.Users)
            {
                if (patient.UserType == 3)
                {
                    TableRow row_n = new TableRow();
                    TableCell userid = new TableCell();
                    userid.Font.Bold = true;
                    TableCell fullname = new TableCell();
                    TableCell username = new TableCell();
                    TableCell address = new TableCell();
                   
                    userid.Attributes.Add("scope", "col");
                    fullname.Attributes.Add("scope", "col");
                    username.Attributes.Add("scope", "col");
                    address.Attributes.Add("scope", "col");
                 

                    userid.Text = patient.Id.ToString();
                    fullname.Text = patient.FullName;
                    username.Text = patient.Username;
                    address.Text = patient.City ;


                  
                    fullname.Attributes.Add("scope", "col");
                    username.Attributes.Add("scope", "col");
                    address.Attributes.Add("scope", "col");
                  
                    row_n.Controls.Add(userid);
                    row_n.Controls.Add(fullname);
                    row_n.Controls.Add(username);
                    row_n.Controls.Add(address);
                    tbody.Controls.Add(row_n);
                    main_table.Controls.Add(tbody);
                }
            }

            users_table.Controls.Add(main_table);

        }
        public void CallReports(HtmlGenericControl Reports_table)
        {
            HtmlGenericControl main_table = new HtmlGenericControl("Table");
            main_table.Attributes["class"] = "table";
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();

            cell.Attributes.Add("scope", "col");
            cell2.Attributes.Add("scope", "col");
            cell5.Attributes.Add("scope", "col");
            cell6.Attributes.Add("scope", "col");



            cell.Text = "ID";
            row.Font.Bold = true;
            cell2.Text = "reported user";

            cell5.Text = "user id";
            cell6.Text = "report text";


            HtmlGenericControl thead = new HtmlGenericControl(HtmlTextWriterTag.Thead.ToString());
            row.Controls.Add(cell);
            row.Controls.Add(cell2);
            row.Controls.Add(cell5);
            row.Controls.Add(cell6);

            thead.Controls.Add(row);
            main_table.Controls.Add(thead);

            HtmlGenericControl tbody = new HtmlGenericControl(HtmlTextWriterTag.Tbody.ToString());
            midLineDBEntities db = new midLineDBEntities();
            foreach (var report in db.Reports)
            {
               
                    TableRow row_n = new TableRow();
                    TableCell id = new TableCell();
                    id.Font.Bold = true;
                    TableCell reporteduser = new TableCell();
                    TableCell userid = new TableCell();
                    TableCell reporttext = new TableCell();

                    id.Attributes.Add("scope", "col");
                    reporteduser.Attributes.Add("scope", "col");
                    userid.Attributes.Add("scope", "col");
                    reporttext.Attributes.Add("scope", "col");


                    id.Text = report.ID.ToString();
                    reporteduser.Text = report.ReportedUserID.ToString();
                    userid.Text = report.UserID.ToString();
                    reporttext.Text = report.ReportText;



                    reporteduser.Attributes.Add("scope", "col");
                    userid.Attributes.Add("scope", "col");
                    reporttext.Attributes.Add("scope", "col");

                    row_n.Controls.Add(id);
                    row_n.Controls.Add(reporteduser);
                    row_n.Controls.Add(userid);
                    row_n.Controls.Add(reporttext);
                    tbody.Controls.Add(row_n);
                    main_table.Controls.Add(tbody);
                
            }

            Reports_table.Controls.Add(main_table);

        }
        public void RetriveAdminPosts(HtmlGenericControl control)
        {
            HtmlGenericControl main_table = new HtmlGenericControl("Table");
            main_table.Attributes["class"] = "table";
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
            TableCell cell7 = new TableCell();

            cell.Attributes.Add("scope", "col");
            cell2.Attributes.Add("scope", "col");
            cell5.Attributes.Add("scope", "col");
            cell6.Attributes.Add("scope", "col");
            cell7.Attributes.Add("scope", "col");



            cell.Text = "ID";
            row.Font.Bold = true;
            cell2.Text = "post date";

            cell5.Text = "user id";
            cell6.Text = "post text";
            cell7.Text = "Action";



            HtmlGenericControl thead = new HtmlGenericControl(HtmlTextWriterTag.Thead.ToString());
            row.Controls.Add(cell);
            row.Controls.Add(cell2);
            row.Controls.Add(cell5);
            row.Controls.Add(cell6);
            row.Controls.Add(cell7);

            thead.Controls.Add(row);
            main_table.Controls.Add(thead);

            HtmlGenericControl tbody = new HtmlGenericControl(HtmlTextWriterTag.Tbody.ToString());
            midLineDBEntities db = new midLineDBEntities();
            foreach (var post in db.Posts)
            {

                TableRow row_n = new TableRow();
                TableCell id = new TableCell();
                id.Font.Bold = true;
                TableCell postdate = new TableCell();
                TableCell userid = new TableCell();
                TableCell postText = new TableCell();
                TableCell action = new TableCell();

                id.Attributes.Add("scope", "col");
                postdate.Attributes.Add("scope", "col");
                userid.Attributes.Add("scope", "col");
                postText.Attributes.Add("scope", "col");
                action.Attributes.Add("scope", "col");


                id.Text = post.ID.ToString();
                postdate.Text = post.PostDate.ToString();
                userid.Text = post.UserID.ToString();
                postText.Text = post.PostText;

                LinkButton delete = new LinkButton();
                delete.Attributes["class"] = "btn btn-secondary";

                delete.ID = post.ID.ToString();
                delete.Text = "Delete Post";
                delete.Click += delegate (object sender, EventArgs e) { Delete_Click(sender, e); };

                action.Controls.Add(delete);
                row_n.Controls.Add(id);
                row_n.Controls.Add(postdate);
                row_n.Controls.Add(userid);
                row_n.Controls.Add(postText);
                row_n.Controls.Add(action);
                tbody.Controls.Add(row_n);

                main_table.Controls.Add(tbody);

            }

            control.Controls.Add(main_table);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {

            midLineDBEntities db = new midLineDBEntities();
            LinkButton button = (LinkButton)sender;
          
            int userId = Convert.ToInt16(button.ID);
            var post = db.Posts.Where(x => x.ID == userId).FirstOrDefault();
            foreach(var comment in db.Comments)
            {
                if (comment.PostID == userId)
                {
                    db.Comments.Remove(comment);
                }
            }
           
            db.Posts.Remove(post);

            db.SaveChanges();
            HttpContext.Current.Response.Redirect("Posts.aspx");


        }

    }
}