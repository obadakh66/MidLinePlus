﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace midLine.Pages
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Session["userId"].ToString());
            Functions.Functions fun = new Functions.Functions();
            fun.RetrivePatientAppointments(id, appContainer);
        }
    }
}