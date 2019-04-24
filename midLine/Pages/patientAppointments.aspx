<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="patientAppointments.aspx.cs" Inherits="midLine.Pages.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
    <div class="mr-0" align="right">
      <div class="row">
        
         <br /><br />
        
              <div class="col col-sm-2 mr-0" >
          <div class="list-group" >
            <a href="drHome.aspx" class="list-group-item active">شخصي</a>
            <a href="#" class="list-group-item">المواعيد</a>
            <a href="#" class="list-group-item">تعديل الملف الشخصي</a>
             
             
            
          </div>
        </div><!--/.sidebar-offcanvas-->
          <div class="col container">
             
            <form runat="server">
          <div class="row container p-3 align-content-center" runat="server" id="appContainer">
              
              
          </div><!--/row-->
          </form>
     
        </div>
      </div>
    
     

      <footer class="text-center fixed-bottom">
           <hr>
        <p>&copy; 2019 mid line plus, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
