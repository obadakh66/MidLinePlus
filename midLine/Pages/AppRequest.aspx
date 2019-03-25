<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AppRequest.aspx.cs" Inherits="midLine.Pages.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <div class="mr-0" align="right">
        <!-- Modal -->
         <div runat="server" id="successAlert" class="alert alert-success w-75" role="alert" hidden="hidden">
                تم ارسال طلبك بنجاح
             </div>
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
                 <div class="card">
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم الدكتور</label>
                              <Asp:TextBox runat="server" ID="doctorFullName"  class="form-control float-right" aria-describedby="emailHelp" Enabled="false" />
                           </div>
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم المريض</label>
                              <Asp:TextBox runat="server" ID="patientFullName"   class="form-control" aria-describedby="emailHelp" Enabled="false"/>
                           </div>
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">موعد الحجز</label>
                              <Asp:TextBox runat="server" ID="time"  class="form-control" aria-describedby="emailHelp" placeholder="اختر موعدا للحجز"/>
                           </div>
                  
                           <div class="col-md-12 text-center ">
                              <Asp:Button runat="server" ID="appRequest" type="submit" class=" btn btn-block mybtn btn-primary tx-tfm" Text="حجز موعد" OnClick="appRequest_Click"/>
                           </div>
                          
                  </div>       
                         
                    
           </div>
            
       
        </div>
      </div>
    </form>
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
   
</asp:Content>
