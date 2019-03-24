<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="drAppointments.aspx.cs" Inherits="midLine.Pages.WebForm5" %>
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
              
               <div class="card m-2" style="width: 25rem;">
  
             <div class="card-body">
                 <div class="row">
                       <img src="../1.png" class="rounded-circle ml-2" alt="Cinque Terre" width="40" height="40"> 
                      <h5 class="card-title">الدكتور علي سلطان</h5>
                    
                 </div>
                <br />
                 <p class="card-text">قسم العظام</p>
                 
                  <Asp:Button runat="server" ID="accept"  class="btn btn-primary" Text="قبول"/>
                  <Asp:Button runat="server" ID="reject"  class="btn btn-danger" Text="رفض"/>
                 </div>
            </div>
               <div class="card m-2" style="width: 25rem;">
  
             <div class="card-body">
                 <h5 class="card-title">Card title</h5>
                 <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                  <Asp:Button runat="server" ID="accepts"  class="btn btn-primary" Text="قبول"/>
                  <Asp:Button runat="server" ID="rejects"  class="btn btn-danger" Text="رفض"/>
                 </div>
            </div>
                  
          </div><!--/row-->
          </form>
     
        </div>
      </div>
    
     

      <footer class="text-center fixed-bottom">
           <hr>
        <p>&copy; 2016 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
