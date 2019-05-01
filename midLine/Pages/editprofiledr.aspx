<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="editprofiledr.aspx.cs" Inherits="midLine.Pages.editprofiledr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <form runat="server">
         <div runat="server" id="successAlert" class="alert alert-success " role="alert" hidden="hidden">
               تم تعديل بياناتك بنجاح
             </div>
          <div runat="server" id="fileError" class="alert alert-danger " role="alert" hidden="hidden">
             خطأ في صيغة الملف , الملفات المقبولة : (png ,jpg,gif) فقط 
             </div>



                      <asp:FileUpload ID="imgUploader" runat="server" class="float rigth"/>
      
                  
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">الاسم الكامل</label>
                              <Asp:TextBox runat="server" ID="FullName"   class="form-control" aria-describedby="emailHelp" placeholder="ادخل الاسم من ثلاثه مقاطع "/>
                           </div>
                         
                       
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">التخصص</label>
                              <Asp:TextBox runat="server" ID="Major"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل التخصص"/>
                           </div>
                            <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> سعر الكشفيه</label>
                              <Asp:TextBox runat="server" ID="Price"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل سعر الكشفيه"/>
                           </div>
                         
                            <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الموقع</label>
                              <Asp:TextBox runat="server" ID="Address"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الموقع"/>
                           </div>
                             <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> مواعيد الفراغ</label>
                              <Asp:TextBox runat="server" ID="Time"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الموقع"/>
                           </div>

                        
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الرمز السري الجديد</label>
                              <Asp:TextBox runat="server" ID="Password" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                           </div>
        <asp:Button ID="save" runat="server" Text="حفظ" class="btn btn-primary tx-tfm" OnClick="save_Click"/>
        

            </form>            
     
        
      
    <div>
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 mid line plus, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
