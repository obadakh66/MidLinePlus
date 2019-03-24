<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/nursing section.aspx.cs" Inherits="midLine.Pages.nursing_section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <div class="mr-0" align="right">
        <!-- Modal -->

        <form runat="server" dir="rtl">
     
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
              <div class="row">
             
              <div class="form-group">
                  <asp:DropDownList ID="city" runat="server">
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
                 
                  </div>
              <div class="row" runat="server" id="Nursing"></div>
        

            
            
       
        </div>
      </div>
    </form>
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
   
</asp:Content>