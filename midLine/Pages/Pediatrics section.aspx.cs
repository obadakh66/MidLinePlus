﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class nose_and_throat_section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.Functions heartdoctors = new Functions.Functions();
            heartdoctors.RetriveDoctors(PediaDoctors, "قسم الأطفال");
        }

        protected void search_Click(object sender, EventArgs e)
        {
            Functions.Functions heartdoctors = new Functions.Functions();
            heartdoctors.RetriveDoctorsFilter(PediaDoctors, "قسم الأطفال",city.SelectedItem.Text);
        }
    }
}