<%@ Page Language="C#" masterpagefile="~/Pages/Site.Master"  AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="midLine.Pages.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

      <br />
    <div class="mr-0" align="right">
      <div class="row">
        
         <br /><br />
        
              <div class="col col-sm-2 mr-0" >
          <div class="list-group" >
            <a href="homepage.aspx" class="list-group-item active">شخصي</a>
            <a href="#" class="list-group-item">المواعيد</a>
            <a href="edit profile.aspx" class="list-group-item">تعديل الملف الشخصي</a>
             
              <a href="homepage.aspx" class="list-group-item active">الاقسام</a>
            <a href="orthopedic section.aspx" class="list-group-item">قسم العظام</a>
            <a href="heart section.aspx" class="list-group-item">قسم القلب</a>
            <a href="dent section.aspx" class="list-group-item">قسم الأسنان</a>
            <a href="pediatrics section.aspx" class="list-group-item">قسم الاطفال</a>
            <a href="other section.aspx" class="list-group-item">اقسام اخرى</a>
                  <a href="nursing section.aspx" class="list-group-item">قسم التمريض المنزلي</a>
            
          </div>
        </div><!--/.sidebar-offcanvas-->
        <div class="container emp-profile">
             <div runat="server" id="failedAlert" class="alert alert-danger w-75" role="alert" hidden="hidden">
                            لا يمكنك تقييم نفس الشخص اكثر من مرة
             </div>
            <form method="post" runat="server">
                <div class="row">
                    <div class="col-md-4">
                        <div class="profile-img">
                          
                            <asp:Image ID="Image" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                       
                        <div class="profile-head">
                                    <h5>
                                        Kshiti Ghelani
                                    </h5>
                                    <h6>
                                        Web Developer and Designer
                                    </h6>
                                    <p class="proile-rating">: عدد التقييمات المرتفعة  <span id="ratesUp" runat="server"></span></p>
                                    <p class="proile-rating">: عدد التقييمات المنخفضة  <span id="ratesDown" runat="server"></span></p>

                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <li class="nav-item">
                                    <div class="primary m-0">
                                    <asp:DropDownList ID="dropdownlistrate" runat="server">
                                         <asp:ListItem>1</asp:ListItem>
                                          <asp:ListItem>2</asp:ListItem>
                                           <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                              <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:Button ID="rate" runat="server" Text="تقييم" class="btn btn-primary tx-tfm" OnClick="rate_Click"/>
                                    
                                  </div>
                                    <br />
                                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">معلومات المستخدم</a>
                                </li>
                                
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <Asp:Button runat="server" ID="report_btn" type="submit" class="btn btn-danger" OnClick="report_btn_Click"  Text="ابلاغ"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        
                    </div>
                    <div class="col-md-8">
                        <div class="tab-content profile-tab" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>اسم المستخدم</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p id="username" runat="server"></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>الاسم الكامل</label>
                                            </div>
                                            <div class="col-md-6">
                                                 <p id="fullName" runat="server"></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>رقم الهاتف</label>
                                            </div>
                                            <div class="col-md-6">
                                                 <p id="Mobile" runat="server"></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>المدينه</label>
                                            </div>
                                            <div class="col-md-6">
                                                 <p id="city" runat="server"></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>نوع المستخدم</label>
                                            </div>
                                            <div class="col-md-6">
                                                 <p id="userType" runat="server"></p>
                                            </div>
                                        </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </form>           
        </div>  

</div>
        </div>
    </asp:Content>
