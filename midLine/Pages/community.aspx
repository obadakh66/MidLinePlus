<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="midLine.Pages.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->
    <style>
        
.panel-google-plus {
    position: relative;
    border-radius: 0px;
    border: 1px solid rgb(216, 216, 216);
    font-family: 'Roboto', sans-serif;
}
.panel-google-plus > .dropdown {
    position: absolute;
    top: 5px;
    right: 15px;
}
.panel-google-plus > .dropdown > span > span {
    font-size: 10px;   
}
.panel-google-plus > .dropdown > .dropdown-menu {
    left: initial;
    right: 0px;
    border-radius: 2px;
}
.panel-google-plus > .panel-google-plus-tags {
    position: absolute;
    top: 35px;
    right: -3px;
}
.panel-google-plus > .panel-google-plus-tags > ul {
    list-style: none;
    padding: 0px;
    margin: 0px;
}
.panel-google-plus > .panel-google-plus-tags > ul:hover {
    box-shadow: 0px 0px 3px rgb(0, 0, 0);   
    box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.25);   
}
.panel-google-plus > .panel-google-plus-tags > ul > li {
    display: block;
    right: 0px;
    width: 0px;
    padding: 5px 0px 5px 0px;
    background-color: rgb(245, 245, 245);
    font-size: 12px;
    overflow: hidden;
}
.panel-google-plus > .panel-google-plus-tags > ul > li::after {
    content:"";
    position: absolute;
    top: 0px;
    right: 0px;
    height: 100%;
	border-right: 3px solid rgb(66, 127, 237);
}
.panel-google-plus > .panel-google-plus-tags > ul:hover > li,
.panel-google-plus > .panel-google-plus-tags > ul > li:first-child {
    padding: 5px 15px 5px 10px;
    width: auto;
    cursor: pointer;
    margin-left: auto;
}
.panel-google-plus > .panel-google-plus-tags > ul:hover > li {
    background-color: rgb(255, 255, 255);   
}
.panel-google-plus > .panel-google-plus-tags > ul > li:hover {
    background-color: rgb(66, 127, 237);
    color: rgb(255, 255, 255);
}
.panel-google-plus > .panel-heading,
.panel-google-plus > .panel-footer {
    background-color: rgb(255, 255, 255);
    border-width: 0px; 
}
.panel-google-plus > .panel-heading {
    margin-top: 20px;    
    padding-bottom: 5px; 
}
.panel-google-plus > .panel-heading > img { 
    margin-right: 15px;
}
.panel-google-plus > .panel-heading > h3 {
    margin: 0px;
    font-size: 14px;
    font-weight: 700;
}
.panel-google-plus > .panel-heading > h5 {
    color: rgb(153, 153, 153);
    font-size: 12px;
    font-weight: 400;
}
.panel-google-plus > .panel-body {
    padding-top: 5px;
    font-size: 13px;
}
.panel-google-plus > .panel-body > .panel-google-plus-image {
    display: block;
    text-align: center;
    background-color: rgb(245, 245, 245);
    border: 1px solid rgb(217, 217, 217);
}
.panel-google-plus > .panel-body > .panel-google-plus-image > img {
    max-width: 100%;
}

.panel-google-plus > .panel-footer {
    font-size: 14px;
    font-weight: 700;
    min-height: 54px;
}
.panel-google-plus > .panel-footer > .btn {
    float: left;
    margin-right: 8px;
}
.panel-google-plus > .panel-footer > .input-placeholder {
    display: block;
    margin-left: 98px;
    color: rgb(153, 153, 153);
    font-size: 12px;
    font-weight: 400;
    padding: 8px 6px 7px;
    border: 1px solid rgb(217, 217, 217);
    border-radius: 2px;
    box-shadow: rgba(0, 0, 0, 0.0470588) 0px 1px 0px 0px;
}
.panel-google-plus.panel-google-plus-show-comment > .panel-footer > .input-placeholder {
    display: none;   
}
.panel-google-plus > .panel-google-plus-comment {
    display: none;
    padding: 10px 20px 15px;
    border-top: 1px solid rgb(229, 229, 229);
    background-color: rgb(245, 245, 245);
}
.panel-google-plus.panel-google-plus-show-comment > .panel-google-plus-comment {
    display: block;
}
/*.panel-google-plus > .panel-google-plus-comment > img {
    float: left;   
}*/
.panel-google-plus > .panel-google-plus-comment > .panel-google-plus-textarea {
    float: right;
    width: calc(100% - 56px);
}
.panel-google-plus > .panel-google-plus-comment > .panel-google-plus-textarea > textarea {
    display: block;
    /*margin-left: 60px;
    width: calc(100% - 56px);*/
    width: 100%;
    background-color: rgb(255, 255, 255);
    border: 1px solid rgb(217, 217, 217);
    box-shadow: rgba(0, 0, 0, 0.0470588) 0px 1px 0px 0px;
    resize: vertical;
}
.panel-google-plus > .panel-google-plus-comment > .panel-google-plus-textarea > .btn {
    margin-top: 10px;
    margin-right: 8px;
    width: 100%;
}
@media (min-width: 992px) {
    .panel-google-plus > .panel-google-plus-comment > .panel-google-plus-textarea > .btn {
        width: auto;
    }    
}


.panel-google-plus .btn {
    border-radius: 3px;   
}
.panel-google-plus .btn-default {
    border: 1px solid rgb(217, 217, 217);
    box-shadow: rgba(0, 0, 0, 0.0470588) 0px 1px 0px 0px;
}
.panel-google-plus .btn-default:hover, 
.panel-google-plus .btn-default:focus, 
.panel-google-plus .btn-default:active {
    background-color: rgb(255, 255, 255);
    border-color: rgb(0, 0, 0);    
}
    </style>
    <form runat="server">
    <div class="card text-lg-right  card bg-light card-body mx-auto w-50">
  
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
      
      <asp:TextBox TextMode="MultiLine" ID="quest" Rows="5" runat="server" CssClass="w-100"></asp:TextBox>
      
      <br />
      <br />
      
  
    <asp:Button ID="send" runat="server"  CssClass="btn btn-primary float-left" Text="ارسال"></asp:Button>
  </div>
        
</div>
        <div class="row" align="right">
             <% for (int i = 0; i <= 5; i++)
                     {
                         Response.Write("<div class='container'><div class='[ w-75 ]'>" +

                        "<div class='[ panel panel-default ] panel-google-plus'> <div class='panel-heading'><img class='[ img-circle pull-right m-2 ]' src='https://lh3.googleusercontent.com/-CxXg7_7ylq4/AAAAAAAAAAI/AAAAAAAAAQ8/LhCIKQC5Aq4/s46-c-k-no/photo.jpg' alt='Mouse0270' />" +
                          " <h2 class='m-2 pull-right'>" + i.ToString() +"</h2><br/><h5 class='pull-right'><span>Jun 27, 2014</span> </h5></div><br/>" +
                  " <div class='panel-body'><h5>Do people born in 2000 get to choose if they are Generation Y or Generation Z? How do you decide what generation you want to belong to?</h5></div>" +
                  " <div class='card m-5 p-1'><div class='row mr-2'><h5>alina kabor</h5></div><div class='row mr-2'>yes i agree with that yes i agree with that yes i agree with that yes i agree with thatyes i agree with thatyes i agree with thatyes i agree with that </div></div>"+
                  "<div class='panel-footer'><button type = 'button' class='[ btn btn-primary float-right mx-2 ]'>اكتب تعليقا</button><input class='form-control w-75' id='Text1' type='text' /> " +
                  " </div> </div></div>   </div></div></div>");
                 } %>
        </div>
                         <div class='card m-5'>
                             <div class='row p-5'>
                                 <p>alina kabor</p>

                             </div>
                             <div class='row p-2'>yes i agree with that </div></div>

        </form>
</asp:Content>
