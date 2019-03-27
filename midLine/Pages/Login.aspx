<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="midLine.Pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="card bg-light">
				<div class="card-body mx-auto w-50">
					 <div class="logo mb-3">
						 <div class="col-md-12 text-center">
							<h1>تسجيل الدخول</h1>
						 </div>
					</div>
                   <form runat="server">
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم المستخدم</label>
                              <Asp:TextBox runat="server" ID="username" class="form-control float-right"  aria-describedby="emailHelp" placeholder="ادخل اسم المستخدم "/>
                           </div>
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">رمز الدخول</label>
                              <Asp:TextBox type="password" runat="server" ID="pass"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز"/>
                           </div>
                           <div class="form-group">
                              <p class="text-center"> <a href="#"></a></p>
                           </div>
                           <div class="col-md-12 text-center ">
                           
                               <asp:Button ID="Login" runat="server" Text="تسجيل الدخول" class=" btn btn-block mybtn btn-primary tx-tfm" OnClick="Login_Click" />
                           </div>
                           <div class="col-md-12 ">
                              <div class="login-or">
                                 <hr class="hr-or">
                                 <span class="span-or"></span>
                              </div>
                           </div>
                           <div class="col-md-12 mb-3">
                              <p class="text-center">
                                 <a href="javascript:void();" class="google btn mybtn"><i class="fa fa-google-plus">
                                 </i> 
                                 </a>
                              </p>
                           </div>
                           <div class="form-group">
                              <p class="text-center">لا يوجد لديك حساب؟ <a href="#" id="signup">تسجيل </a></p>
                           </div>
                        </form>
                 
				</div>
			</div>
     
</asp:Content>
