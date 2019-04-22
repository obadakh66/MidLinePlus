<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="PostPage.aspx.cs" Inherits="midLine.Pages.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="card text-lg-right  card bg-light card-body" >
   <div runat="server" id="successAlert" class="alert alert-success w-75" role="alert" hidden="hidden">
                 تم نشر منشورك بنجاح !
             </div>
        <form runat="server">
  <div class="card w-50 p-5" style="margin-right:300px">
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
            <br />
             <div class="card p-5 w-50 row" style="margin-right:300px" id="commentBox" runat="server" hidden="hidden">
                 <div >
      <h5 class="text-center">اضف تعليق </h5>
      <br />
            <div class="row">    
      <label class="float-right" > ادخل رقم المنشور</label>
                </div>
                  <div class="row">
       <asp:TextBox ID="postId" CssClass="form-control" runat="server"></asp:TextBox>
                     </div>
      <br />
          <div class="row">       
    <label class="float-right">اكتب تعليق</label>
              </div>
                 <div class="row">
             <asp:TextBox ID="commentText" CssClass="form-control float-right" runat="server"/>
</div>
      <br />
      <br />
    <div class="row">
    <asp:Button ID="comment" runat="server"  CssClass="btn btn-primary float-right w-100" Text="تعليق" OnClick="comment_Click"/>
        </div>

        </div>  
  </div>
            <div class="card-body" runat="server" id="mainBox">

            </div>
    </form>    
</div>
             
                        

        
</asp:Content>
