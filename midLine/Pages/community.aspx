<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="midLine.Pages.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <div class="card text-lg-right  card bg-light card-body mx-auto" style="width: 50rem; margin-top:5rem; margin-right:auto">
  
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
      
      <asp:TextBox ID="quest" runat="server" CssClass="w-100"></asp:TextBox>
      <br />
      <br />
   
    <asp:Button ID="send" runat="server"  CssClass="btn btn-primary float-left" Text="ارسال"></asp:Button>
  </div>
</div>

        </form>
</asp:Content>
