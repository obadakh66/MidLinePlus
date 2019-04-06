<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="midLine.Pages.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="col col-md-10">
           <div class="row mt-5 " style="margin-left:350px" runat="server" id="mainContent">
                <div class="container" hidden="hidden" id="con" runat="server">
 
  <h2>Certification Image</h2>
  <div class="card w-100" >
      
    <div class="card-body" id="modal_body" runat="server">
        <asp:Image ID="modalImage" runat="server"  />
    </div>
      <asp:Button ID="close" CssClass="btn btn-danger w-25" runat="server" Text="close" OnClick="close_Click"  />
  </div>
</div>
   <div class="card w-100 row">
       <h4 class="card-title">Doctors</h4>
  <div class="panel panel-container" id="doctorsTable" runat="server">
			
		</div>
</div>
               <div class="card w-100 row mt-5">
       <h4 class="card-title">Nurses</h4>
  <div class="panel panel-container" id="nursesTable" runat="server">
			
		</div>
</div>
 <div class="card w-100 row mt-5">
       <h4 class="card-title">Patients</h4>
  <div class="panel panel-container" id="patients" runat="server">
			
		</div>
</div>
       
      </div>
  
   
      
           </div>
</asp:Content>
