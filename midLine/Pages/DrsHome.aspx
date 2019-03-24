<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="DrsHome.aspx.cs" Inherits="midLine.Pages.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <br />
    <div class="mr-0" align="right">
      <div class="row">
        
         <br /><br />
        
              <div class="col col-sm-2 mr-0" >
          <div class="list-group" >
            <a href="#" class="list-group-item active">شخصي</a>
            <a href="drAppointments.aspx" class="list-group-item">المواعيد</a>
            <a href="#" class="list-group-item">تعديل الملف الشخصي</a>
             
             
            
          </div>
        </div><!--/.sidebar-offcanvas-->
          <div class="col container">
              <div runat="server" id="successAlert" class="alert alert-success w-75" role="alert" hidden="hidden">
                 تم اكمال معلوماتك بنجاح يمكنك الآن استقبال مواعيد !
             </div>
            
          <div class="row container p-3 align-content-center">
            
            <div class="col-4"></div>
              <div class="card p-3 align-content-center col" style="width: 30rem;">
                   <h3 class="card-title">يرجى اكمال معلوماتك</h3>
              <form runat="server">
            <div class="form-group">
              <label for="exampleInputEmail1">سعر الكشفية</label>
              <Asp:TextBox runat="server" ID="price"  class="form-control" placeholder="يرجى ادخال سعر الكشفية"/>
   
             </div>
          <div class="form-group">
              <label for="exampleInputEmail1">يرجى اختيار القسم</label>
             <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                 <asp:ListItem>قسم القلب</asp:ListItem>
                 <asp:ListItem>قسم العظام</asp:ListItem>
                  </asp:DropDownList>
              </div>
                    <div class="form-group">
              <label for="exampleInputEmail1">المواعيد المتاحة</label>
              <Asp:TextBox runat="server" ID="availableTime" Rows="3"  class="form-control" placeholder="يرجى ادخال المواعيد المتاحة"/>
   
             </div>
           <Asp:Button runat="server" ID="update_btn"  class="btn btn-primary" OnClick="update_btn_Click" Text="تحديث"/>
</form>
          
         </div>
         <div class="col-4"></div>
          </div><!--/row-->
     
        </div>
      </div>
    
     

      <footer class="text-center fixed-bottom">
           <hr>
        <p>&copy; 2016 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
