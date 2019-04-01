<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="editprofiledr.aspx.cs" Inherits="midLine.Pages.editprofiledr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <form runat="server">
    <asp:FileUpload ID="imgUploader" runat="server" class="float rigth"/>
      
                  
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">الاسم الكامل</label>
                              <Asp:TextBox runat="server" ID="username"   class="form-control" aria-describedby="emailHelp" placeholder="ادخل الاسم من ثلاثه مقاطع "/>
                           </div>
                         
                       
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">التخصص</label>
                              <Asp:TextBox runat="server" ID="Password" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل التخصص"/>
                           </div>
                            <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> سعر الكشفيه</label>
                              <Asp:TextBox runat="server" ID="TextBox2" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل سعر الكشفيه"/>
                           </div>
                         
                            <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الموقع</label>
                              <Asp:TextBox runat="server" ID="TextBox3" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الموقع"/>
                           </div>
                              <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الشهادات</label>
                              <Asp:TextBox runat="server" ID="TextBox4" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الشهادات الحاصل عليها "/>
                           </div>

                         <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الرمز السري الحالي</label>
                              <Asp:TextBox runat="server" ID="ReEnterPass" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                           </div>
        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right"> الرمز السري الجديد</label>
                              <Asp:TextBox runat="server" ID="TextBox1" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                           </div>
        <asp:Button ID="save" runat="server" Text="حفظ" class="btn btn-primary tx-tfm"  />
        

            </form>            
     
        
      
    <div>
      <hr>

      <footer class="text-center">
        <p>&copy; 2019 Company, Inc.</p>
      </footer>

    </div><!--/.container-->
</asp:Content>
