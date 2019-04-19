<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AppRequest.aspx.cs" Inherits="midLine.Pages.WebForm4" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <!-- Bootstrap -->
<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
<!-- Bootstrap -->
<!-- Bootstrap DatePicker -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
<!-- Bootstrap DatePicker -->
<script type="text/javascript">
    $(function () {
        $('[id*=txtDate]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd/mm/yyyy",
            language: "tr"
        });
    });
</script>
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
           <div class="row container p-3 align-content-center">
                 <div class="card w-50 p-5">
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم الدكتور</label><br />
                              <Asp:TextBox runat="server" ID="doctorFullName"  class="form-control float-right w-100" aria-describedby="emailHelp" ReadOnly="true" />
                           </div>
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم المريض</label><br />
                              <Asp:TextBox runat="server" ID="patientFullName"   class="form-control w-100" aria-describedby="emailHelp" ReadOnly="true"/>
                           </div>
                      
                       <div class="form-group">
                      <label for="exampleInputEmail1" class="float-right">تاريخ الموعد</label><br />            
                    <asp:TextBox ID="txtDate" runat="server" class="w-100 float-right"></asp:TextBox>
                           </div>
                           <div class="form-group">
                <label for="exampleInputEmail1" class="float-right">وقت الموعد</label><br />            

                <cc1:TimeSelector ID="TimeSelector1" runat="server" class="w-100 float-left">
                  </cc1:TimeSelector>
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                          </div>
                    
                         
                   <div class="form-group">
                           <div class="col-md-12 text-center ">
                              <Asp:Button runat="server" ID="appRequest" type="submit" class=" btn btn-block mybtn btn-primary tx-tfm" Text="حجز موعد" OnClick="appRequest_Click"/>
                           </div>
                       </div>   
                  </div>       
                    
                    </div>

          </div>     
                    
           </div>
            
       
       
     
    </form>
       
      <hr>
        <br />
      <footer class="text-center">
        <p>&copy; 2019 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
   
</asp:Content>
