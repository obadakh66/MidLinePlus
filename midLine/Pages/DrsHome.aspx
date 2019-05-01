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
            <a href="editprofiledr.aspx" class="list-group-item">تعديل الملف الشخصي</a>
             
             
            
          </div>
        </div><!--/.sidebar-offcanvas-->
          <div class="col container">
              <div runat="server" id="successAlert" class="alert alert-success w-75" role="alert" hidden="hidden">
                 تم ارسال معلوماتك بنجاح ,سيتم تاكيد الحساب من قبل مدير الموقع خلال 12 ساعه !
             </div>
            
          <div class="row container p-3 align-content-center" runat="server" id="updateForm">
            
           
              <div class="card p-3 align-content-center col" style="width: 30rem;" id="DrForm" runat="server" hidden="hidden">
                   <h3 class="card-title">يرجى اكمال معلوماتك</h3>
              <form runat="server">
            <div class="form-group">
              <label for="exampleInputEmail1">ارفاق الشهاده المعتمده</label>
             <asp:FileUpload ID="imgUploader" runat="server" text="تحميل" required="required"/>
   
             </div>
                
            <div class="form-group">
              <label for="exampleInputEmail1">سعر الكشفية</label>
              <Asp:TextBox runat="server" ID="price"  class="form-control" placeholder="يرجى ادخال سعر الكشفية" required="required"/>
   
             </div>
          <div class="form-group">
              <label for="exampleInputEmail1">يرجى اختيار القسم</label>
             <asp:DropDownList ID="Departments" CssClass="form-control" runat="server" required="required">
                 <asp:ListItem>قسم القلب</asp:ListItem>
                 <asp:ListItem>قسم العظام</asp:ListItem>
                  <asp:ListItem>قسم الأسنان</asp:ListItem>
                  <asp:ListItem>قسم الأطفال</asp:ListItem>
                  <asp:ListItem>قسم التمريض المنزلي</asp:ListItem>
                  <asp:ListItem>قسم أقسام اخرى</asp:ListItem>
                  </asp:DropDownList>
              </div>
                     <div class="form-group">
              <label for="exampleInputEmail1">التخصص</label>
              <Asp:TextBox runat="server" ID="specilized"   class="form-control" placeholder="يرجى كتابه التخصص" required="required"/>
   
             </div>

                    <div class="form-group">
              <label for="exampleInputEmail1">المواعيد المتاحة</label>
              <Asp:TextBox runat="server" ID="availableTime"  class="form-control" placeholder="يرجى ادخال المواعيد المتاحة" required="required"/>
             </div>
                   <div class="form-group">
              <label for="exampleInputEmail1">العنوان</label>
              <Asp:TextBox runat="server" ID="Address"   class="form-control" placeholder="يرجى ادخال العنوان بالتفصيل" required="required"/>
   
             </div>
                 
           <Asp:Button runat="server" ID="update_btn"  class="btn btn-primary" OnClick="update_btn_Click" Text="تحديث"/>
</form>
          
         </div>
                <div class="card p-3 align-content-center col" style="width: 60rem;" id="InfoForm" runat="server" hidden="hidden">
                   <h3 class="card-title" runat="server" id="appcount">
                       عدد المواعيد :
        </h3>
                    <h3 class="card-title" runat="server" id="ratingAvg">معدل التقييمات : </h3>
              <div runat="server" id="PendingRequests" class="alert alert-success w-75" role="alert">لديك مواعيد معلقة عدد :</div>
          
         </div>
        
          </div><!--/row-->
     
        </div>
      </div>
    
     <br /> 
        <br />
        <br />

      <footer class="text-center fixed-bottom">
           <hr>
        <p>&copy; 2019 mid line plus, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
