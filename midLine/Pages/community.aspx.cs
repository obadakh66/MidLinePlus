using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class community : System.Web.UI.Page
    {
       public string hi = "مرحباااا";
        midLineDBEntities db = new midLineDBEntities();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            midLineDBEntities db = new midLineDBEntities();
            string Id =Session["user"].ToString();
            int id;
            int type=0;
            if(Id!=null && Id != "")
            { id= Convert.ToInt16(Id);
                var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                if (user.UserType == 1) { type = 1; }
                if (user.UserType == 2) { type = 2; }
                if (user.UserType == 3) { type = 3; }
                if (user.UserType == 4) { type = 4; }
            }
            else
            { type = 5; }
            Functions.Functions functions = new Functions.Functions();
            functions.RetrivePosts(postBox,type);
        }

        protected void send_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt16(Session["userId"].ToString());
            midLineDBEntities db = new midLineDBEntities();
           
            Post newPost = new Post
            {
                UserID = id,
                PostDate = DateTime.Now,
                PostText = quest.Text,
                Department = ques.SelectedItem.Text

            };
            if (newPost != null)
            {
                db.Posts.Add(newPost);
                db.SaveChanges();
            }
            Response.Redirect("community.aspx");
        }
       
    }
}