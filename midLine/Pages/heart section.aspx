<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="heart section.aspx.cs" Inherits="midLine.Pages.heart_section" %>



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
             
              <a href="#" class="list-group-item active">الاقسام</a>
            <a href="#" class="list-group-item">قسم العظام</a>
            <a href="#" class="list-group-item">قسم القلب</a>
            <a href="#" class="list-group-item">قسم الأسنان</a>
            <a href="#" class="list-group-item">قسم الاطفال</a>
            <a href="#" class="list-group-item">اقسام اخرى</a>
            
          </div>
        </div><!--/.sidebar-offcanvas-->
          
          <div class="col container">
              <form runat="server">
              <div class="form-group">
                  <asp:DropDownList ID="DropDownList1" runat="server">
                       <asp:ListItem>اربد</asp:ListItem>
                           <asp:ListItem>عمان</asp:ListItem>
                           <asp:ListItem>الزرقاء</asp:ListItem>
                           <asp:ListItem>المفرق</asp:ListItem>
                           <asp:ListItem>جرش</asp:ListItem>
                           <asp:ListItem>عجلون</asp:ListItem>
                           <asp:ListItem>البلقاء</asp:ListItem>
                           <asp:ListItem>مادبا</asp:ListItem>
                           <asp:ListItem>الكرك</asp:ListItem>
                           <asp:ListItem>الطفيلة</asp:ListItem>
                           <asp:ListItem>معان</asp:ListItem>
                           <asp:ListItem>العقبة</asp:ListItem>
                  </asp:DropDownList>

                  <asp:Button ID="search" runat="server" Text="بحث" class=" btn btn-primary tx-tfm" />
            

              </div>
                  </form>
        

            
            
          <!--div class="row container p-1">
              <a href="Login.aspx" class="mr-5">
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم العظام</h5>
            
           </div>
        </div>
        </a>
              <a href="Login.aspx">
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم القلب</h5>
            
           </div>
        </div>
        </a>
              <a href="Login.aspx">
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم الأسنان</h5>
            
           </div>
        </div>
        </a>
              <a href="Login.aspx" class="mr-5">
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم الأذن والحنجرة</h5>
            
           </div>
        </div>
        </a>
              <a href="Login.aspx"  >
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">اقسام اخرى</h5>
            
           </div>
        </div>
        </a>
              </a>
              <a href="Login.aspx"  >
           <div class="card m-3" style="width: 18rem;">
             <img class="card-img-top" src="../1.png" alt="Card image cap">
             <div class="card-body">

             <h5 class="card-title text-center">قسم التمريض المنزلي</h5>
            
           </div>
        </div>
        </a>
          </!--div><!--/row-->
     
        </div>
      </div>
    
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
