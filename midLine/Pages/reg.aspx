<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="midLine.Pages.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align-content-center">
				<div class="content-center w-75">
					 <div class="logo mb-3">
						 <div class="col-md-12 text-center">
							<h1>التسجيل</h1>
						 </div>
					</div>
                   <form runat="server">
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">اسم المستخدم</label>
                              <input type="email" name="email"  class="form-control float-right" id="email" aria-describedby="emailHelp" placeholder="ادخل الاسم">
                           </div>
                           <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">الاسم الكامل</label>
                              <input type="password" name="password" id="fullname"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الاسم من ثلاثه مقاطع">
                           </div>
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">رقم الهاتف</label>
                              <input type="password" name="password" id="number"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل رقم الهاتف">
                           </div>
                        <div class="form-group">
                              <label for="exampleInputEmail1" class="float-right">رمز السري</label>
                              <input type="password" name="password" id="password"  class="form-control" aria-describedby="emailHelp" placeholder="ادخل الرمز السري">
                           </div>
                       <label class="float-right" > اختر المدينه</label>
                               <select>
                                   <option value="اربد">اربد</option>
                                   <option value="عجلون">عجلون</option>
                                      <option value="البلقاء">البلقاء</option>
                                     <option value="معان" >معان</option>
                                   <option value="الطفيله" >الطفيله</option>
                                   <option value="العقبه" >العقبه</option>
                                   <option value="الكرك" >الكرك</option>
                                   <option value="الزرقاء" >الزرقاء</option>
                                   <option value="المفرق" >المفرق</option>
                                   <option value="مادبا" >مادبا</option>
                                   <option value="جرش" >جرش</option>
                                   <option value="عمان" selected >عمان</option>


                               </select>
                       <p>
                       <label class="float-right">اختر الجنس</label>
                       <select>
                           <option value="ذكر" selected >ذكر</option>
                           <option value="انثى">انثى</option>
                           </p>

                       </select>
                           <div class="form-group">
                              <p class="text-center"> <a href="#"></a></p>
                           </div>
                           <div class="col-md-12 text-center ">
                              <button type="submit" class=" btn btn-block mybtn btn-primary tx-tfm">تسجيل</button>
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
