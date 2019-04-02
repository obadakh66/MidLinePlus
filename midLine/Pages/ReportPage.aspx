<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="midLine.Pages.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form runat="server">
    <center><div class="text-left" id="report_body" runat="server" style="padding:10ex;border-style:solid;border-color:#722f37;width:70%;margin:2ex;color:#722f37">
          <%-- ------------------------------------------ --%>
           <div runat="server" class="alert  alert-success alert-dismissible fade show" role="alert" hidden="hidden"   id="report_alert" aria-disabled="True"> 
    
              <strong>Success!</strong> Your Report has been sent successfully , Thank You .
              <button type="button" class="close" data-dismiss="alert" aria-label="Close">
              <span aria-hidden="true">&times;</span>
              </button>
           </div>
          <%-- ------------------------------------------ --%>
          <div class="form-group text-center" >
           <h4 class="modal-title  font-weight-bold" style="margin-bottom:2ex"><asp:Label ID="item_id_label" runat="server"></asp:Label>  </h4>
      
            </div>
        <center>  <h1> <label for="report_body" > ابلاغ </label>   </h1>     </center>
        <br />
           <center><h2> <label for="report_body" >ساعدنا في معرفه السبب:</label></h2> </center>


                <div class="form-group " style="margin:1ex">
                <label for="item_notes" class="float-right">الملاحظات:</label>
                <textarea class="form-control" id="item_notes" rows="6" runat="server"></textarea>
                </div>
               
          
          <%-- -------------------------------------------------------------- --%>
           
            <div class="modal-footer d-flex justify-content-center" id="modal_footer" runat="server">
                <asp:Button ID="report_btn_modal" CssClass="btn btn-primary all_btn" runat="server" Text="تأكيد" BackColor="#722f37" OnClick="report_btn_modal_Click"  />
           </div>

       </div></center>
         </form>
</asp:Content>
