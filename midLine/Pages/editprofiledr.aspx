<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editprofiledr.aspx.cs" Inherits="midLine.Pages.editprofiledr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <form runat="server">
    <asp:FileUpload ID="imgUploader" runat="server" class="float rigth" />
      
                  
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم المستخدم</label>
                              <Asp:TextBox runat="server" ID="username"   class="form-control" aria-describedby="emailHelp" placeholder="ادخل الاسم "/>
                           </div>

            
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">الاسم الكامل</label>
                              <Asp:TextBox runat="server" ID="FullName"   class="form-control" aria-describedby="emailHelp" placeholder="ادخل الاسم من ثلاثه مقاطع"/>
                           </div>
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">رقم الهاتف</label>
                              <Asp:TextBox runat="server" ID="MobileNumber"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل رقم الهاتف"/>
                           </div>
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">رمز السري الحالي</label>
                              <Asp:TextBox runat="server" ID="Password" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                           </div>
                         <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الرمز السري الجديد</label>
                              <Asp:TextBox runat="server" ID="ReEnterPass" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
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
