<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="midLine.Pages.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class=" card bg-light ">
				<div class=" card-body mx-auto w-50">
					 <div class="logo mb-3">
						 <div class="col-md-12 text-center">
							<h1>التسجيل</h1>
						 </div>
					</div>
                     <div runat="server" id="successAlert" class="alert alert-success w-75" role="alert" hidden="hidden">
                 انشاء الحساب بنجاح يمكنك تسجيل الدخول  <a href="Login.aspx"> الآن  </a>
             </div>
                    <div runat="server" id="failedAlert" class="alert alert-danger w-75" role="alert" hidden="hidden">
                            يرجى التأكد من معلومات
             </div>
                     <div runat="server" id="usernameAlert" class="alert alert-danger w-75" role="alert" hidden="hidden">
                            اسم المستخدم غير متوفر يرجى اختيار اسم مستخدم آحر
             </div>
                   <form runat="server">
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم المستخدم</label>
                              <Asp:TextBox runat="server" ID="Username"  class="form-control float-right" aria-describedby="emailHelp" placeholder="ادخل اسم المستخدم" required="required"/>
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
                              <label for="exampleInputEmail1" class="float-right">رمز السري</label>
                              <Asp:TextBox runat="server" ID="Password" type="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                           </div>
                         <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اعد كتابة</label>
                              <Asp:TextBox runat="server" ID="ReEnterPass" type="password"  class="form-control" data-match="#pass" aria-describedby="emailHelp" placeholder="ادخل الرمز السري"/>
                           </div>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" 
                             ControlToCompare="Password" ControlToValidate="ReEnterPass" ErrorMessage="كلمات المرور غير متطابقة" ForeColor="#29436D"></asp:CompareValidator>
                        <div class="form-group">
                        <label class="float-right" > اختر المدينه</label>
                       <asp:DropDownList ID="City" runat="server"  class="form-control">
                           <asp:ListItem>اربد</asp:ListItem>
                           <asp:ListItem>عمان</asp:ListItem>
                           <asp:ListItem>الزرقاء</asp:ListItem>
                           <asp:ListItem>المفرق</asp:ListItem>
                           <asp:ListItem>جرش</asp:ListItem>
                           <asp:ListItem>عجلون</asp:ListItem>
                           <asp:ListItem>السلط</asp:ListItem>
                           <asp:ListItem>مادبا</asp:ListItem>
                           <asp:ListItem>الكرك</asp:ListItem>
                           <asp:ListItem>الطفيلة</asp:ListItem>
                           <asp:ListItem>معان</asp:ListItem>
                           <asp:ListItem>العقبة</asp:ListItem>
                           </asp:DropDownList>
                      </div>
                          <div class="form-group">
                        <label class="float-right" > اختر الجنس</label>
                       <asp:DropDownList ID="Gender" runat="server"  class="form-control">
                           <asp:ListItem>ذكر</asp:ListItem>
                           <asp:ListItem>انثى</asp:ListItem>
                         
                           </asp:DropDownList>
                      </div>
                         <div class="form-group">
                        <label class="float-right" >  تسجيل كـ</label>
                       <asp:DropDownList ID="UserType" runat="server"  class="form-control">
                           <asp:ListItem Value="1">دكتور</asp:ListItem>
                           <asp:ListItem Value="2">ممرض</asp:ListItem>
                         
                           <asp:ListItem Value="3">مريض</asp:ListItem>
                         
                           </asp:DropDownList>
                      </div>
                       
                             
                     
                           <div class="form-group">
                              <p class="text-center"> <a href="#"></a></p>
                           </div>
                           <div class="col-md-12 text-center ">
                              <Asp:Button runat="server" ID="Register_btn" type="submit" class=" btn btn-block mybtn btn-primary tx-tfm" Text="تسجيل" OnClick="Register_btn_Click"/>
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
                              <p class="text-center">  لديك حساب؟<a href="#" id="signup">الدخول </a></p>
                           </div>
                        </form>
                 
				</div>
			</div>
     
</asp:Content>
