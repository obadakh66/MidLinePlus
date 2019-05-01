<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/edit profile.aspx.cs" Inherits="midLine.Pages.edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <form runat="server">
           <div runat="server" id="successAlert" class="alert alert-success " role="alert" hidden="hidden">
               تم تعديل بياناتك بنجاح
             </div>
         <div runat="server" id="fileError" class="alert alert-danger " role="alert" hidden="hidden">
             خطأ في صيغة الملف , الملفات المقبولة : (png ,jpg,gif) فقط 
             </div>
    
      
                  <br />
                          
        <div class="card bg-light card-body mx-auto w-75">
            <div class="form-group">
                 <asp:FileUpload ID="imgUploader"  runat="server" class="float rigth" />
            </div>
            
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">الاسم الكامل</label>
                              <Asp:TextBox runat="server" ID="FullName"   class="form-control" aria-describedby="emailHelp" placeholder="ادخل الاسم من ثلاثه مقاطع"/>
                           </div>
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">رقم الهاتف</label>
                              <Asp:TextBox runat="server" ID="MobileNumber"  class="form-control" />
                           </div>
           
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">ادخل كلمة المرور الجديدة</label>
                              <Asp:TextBox runat="server" ID="Password" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                         
                            </div>
                       <br />
            <br />
        <asp:Button ID="save" runat="server" Text="حفظ" CssClass="btn btn-primary w-25 m-auto " OnClick="save_Click" />
        
            </div>
            </form>            
     
   
   
      
    <div>
     
         <footer class="text-center fixed-bottom">
           <hr>
        <p>&copy; 2019 mid line plus, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>