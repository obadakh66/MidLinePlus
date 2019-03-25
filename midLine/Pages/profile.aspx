<%@ Page Language="C#" masterpagefile="~/Pages/Site.Master"  AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="midLine.Pages.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

      <br />
    <div class="mr-0" align="right">
      <div class="row">
        
         <br /><br />
        
              <div class="col col-sm-2 mr-0" >
          <div class="list-group" >
            <a href="#" class="list-group-item active">شخصي</a>
            <a href="#" class="list-group-item">المواعيد</a>
            <a href="#" class="list-group-item">تعديل الملف الشخصي</a>
             
              <a href="homepage.aspx" class="list-group-item active">الاقسام</a>
            <a href="orthopedic section.aspx" class="list-group-item">قسم العظام</a>
            <a href="heart section.aspx" class="list-group-item">قسم القلب</a>
            <a href="dent section.aspx" class="list-group-item">قسم الأسنان</a>
            <a href="pediatrics section.aspx" class="list-group-item">قسم الاطفال</a>
            <a href="other section.aspx" class="list-group-item">اقسام اخرى</a>
                  <a href="nursing section.aspx" class="list-group-item">قسم التمريض المنزلي</a>
            
          </div>
        </div><!--/.sidebar-offcanvas-->
          <form id="imageprofile" runat="server">

          <asp:Image ID="Image1" runat="server" />
              </form>
          <br /> <br />

           <div class=" col-md-9 col-lg-9  "> 
                  <table class="table table-user-information  border-primary">
                    <tbody>
                      <tr>
                        <td>اسم المستخدم</td>
                        <td></td>
                      </tr>
                      <tr>
                        <td>رقم الهاتف</td>
                        <td></td>
                      </tr>
                      <tr>
                        <td>المدينه</td>
                        <td></td>
                      </tr>
                   
                         <tr>
                             <tr>
                        <td>نوع المستخدم</td>
                        <td></td>
                      </tr>
                     
                    </tbody>
                  </table>
                  


    </asp:Content>
