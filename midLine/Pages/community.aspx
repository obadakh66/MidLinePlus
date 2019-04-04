<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="midLine.Pages.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->
   
    <form runat="server">
    <div class="card text-lg-right  card bg-light card-body mx-auto w-75">
   <div runat="server" id="successAlert" class="alert alert-success w-75" role="alert" hidden="hidden">
                 تم نشر منشورك بنجاح !
             </div>
  <div class="card-body">
      <h5 class="text-center">هل يوجد لديك سؤال؟</h5>
      <br />
      <label class="float-right" > اختر القسم</label>
                       <asp:DropDownList ID="ques" runat="server"  class="form-control">
                           <asp:ListItem>قسم الاسنان</asp:ListItem>
                           <asp:ListItem>قسم الاطفال</asp:ListItem>
                           <asp:ListItem>قسم العظام</asp:ListItem>
                           <asp:ListItem>قسم القلب</asp:ListItem>
                           <asp:ListItem>اقسام اخرى</asp:ListItem>
                           </asp:DropDownList>
      <br />
    <label class="float-right">اسال الاطباء</label>
      
      <asp:TextBox TextMode="MultiLine" ID="quest" Rows="5" runat="server" placeholder="اكتب سؤال,منشور , استفسار ..." CssClass="form-control w-100"/>
      
      <br />
      <br />
      
  
    <asp:Button ID="send" runat="server"  CssClass="btn btn-primary float-right" Text="ارسال" OnClick="send_Click"/>
  </div>
        
</div>
        <div class="card text-lg-right  card bg-light card-body mx-auto w-75" runat="server" id="postBox" align="right">
         
        </div>
       
                        

        </form>
</asp:Content>
