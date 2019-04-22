<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/edit profile.aspx.cs" Inherits="midLine.Pages.edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <form runat="server">
           <div runat="server" id="successAlert" class="alert alert-success " role="alert" hidden="hidden">
               تم تعديل بياناتك بنجاح
             </div>
    <asp:FileUpload ID="imgUploader" runat="server" class="float rigth" />
      
                  
                          

            
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
                       
        <asp:Button ID="save" runat="server" Text="حفظ" class="btn btn-primary tx-tfm" OnClick="save_Click" />
        

            </form>            
     
        
      
    <div>
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>