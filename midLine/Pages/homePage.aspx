﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="midLine.Pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <br />
    <div class="mr-0" align="right">
      <div class="row">
        
         <br /><br />
        
              <div class="col col-sm-2 mr-0" >
          <div class="list-group" >
            <a href="homePage.aspx" class="list-group-item active white">شخصي</a>
            <a href="patientAppointments.aspx" class="list-group-item">المواعيد</a>
            <a href="edit profile.aspx" class="list-group-item">تعديل الملف الشخصي</a>
             
              <a href="homepage.aspx" class="list-group-item active">الاقسام</a>
            <a href="orthopedic section.aspx" class="list-group-item">قسم العظام</a>
            <a href="heart section.aspx" class="list-group-item">قسم القلب</a>
            <a href="dent section.aspx" class="list-group-item">قسم الأسنان</a>
            <a href="Pediatrics section.aspx" class="list-group-item">قسم الاطفال</a>
            <a href="other section.aspx" class="list-group-item">اقسام اخرى</a>
            <a href="nursing section.aspx" class="list-group-item">قسم التمريض المنزلي</a>
            
          </div>
        </div><!--/.sidebar-offcanvas-->
         
          <div class="col container">
            
            
          <div class="row container p-1">
              <a href="orthopedic section.aspx" class="mr-5">
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" style=" width="200"; height="200";" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم العظام</h5>
            
           </div>
        </div>
        </a>
              <a href="heart section.aspx">
           <div class="card m-3" style="width: 18rem;">
             <img class="rounded" style=" width="200"; height="200";" src="../4.jpg"  alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم القلب</h5>
            
           </div>
        </div>
        </a>
              <a href="dent section.aspx">
           <div class="card m-3" style="width: 18rem;">
             <img class="img-thumbnail"  style=" width="200"; height="200";"   src="../9.jpg"  alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم الأسنان</h5>
            
           </div>
        </div>
        </a>
              <a href="Pediatrics section.aspx" class="mr-5">
           <div class="card m-3" style="width: 18rem;">
             <img class="img-thumbnail" style=" width="200"; height="200";" src="../baby.jpg" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم الاطفال</h5>
            
           </div>
        </div>
        </a>
              <a href="other section.aspx"  >
           <div class="card m-3" style="width: 18rem;">
             <img class="img-thumbnail" style=" width="200"; height="200";" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">اقسام اخرى</h5>
            
           </div>
        </div>
        </a>
              
              <a href="nursing section.aspx"  >
           <div class="card m-3" style="width: 18rem;">
             <img class="img-thumbnail" style=" width="200"; height="200";" src="../5.jpg"  alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم التمريض المنزلي</h5>
            
           </div>
        </div>
        </a>
          </div><!--/row-->
      
        </div>
                                     

      </div>
    <br />
        <br />
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 mid line plus, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
