<%@ Page Language="C#"  MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="midLine.Pages.contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

          <form runat="server">

<div class="card-center bg-light" >
  
  <div class="card-body mx-auto w-75">
   <center> <h1 class="card-title">للتواصل والاقتراحات</h1></center>

      <div class="card-group">
          <label>البريد الالكتروني</label>
          <asp:TextBox ID="email" runat="server" CssClass="float-right form-control" placeholder="ادخل البريد الالكتروني"></asp:TextBox>
      </div>
      <br />

      <div class="card-group">
          <label>الموضوع</label>
          <asp:TextBox ID="TextBox1" runat="server" CssClass="float-right form-control" placeholder="ادخل اسم الموضوع"></asp:TextBox>
      </div>
      <br />

      <div class="card-group">
          <label>الرساله</label>
          <textarea id="mesg" runat="server" class="form-control" rows="4" palceholder="ادخل محتوى الرساله"></textarea>

      </div>

   <br />
   <br />
    <asp:Button ID="send" runat="server" Text="ارسال" class="btn btn-primary"></asp:Button>
  </div>
</div>


          
              </form>
        </asp:content>
