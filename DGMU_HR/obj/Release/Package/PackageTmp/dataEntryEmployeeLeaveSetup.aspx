<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryEmployeeLeaveSetup.aspx.cs" Inherits="DGMU_HR.dataEntryEmployeeLeaveSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
 

<br /><br /><hr />  
<%--<div class="container container_content">--%>
    <div>
   
<asp:UpdatePanel runat="server" ID="uplMain">
    <ContentTemplate>

       <!-- Tooltip Section-->
       <script type="text/javascript">
                           $(function () {
                               $('[data-toggle="tooltip"]').tooltip()
                           })
                            
                           $(function () {
                               $('.calendarInput').datetimepicker(
                                   {
                                       format: 'L'
                                   });
                           });
                           //Search function
                           $(function searchInput() {
                               $('[id*=txtSearch]').on("keyup", function () {
                                   var value = $(this).val().toLowerCase();
                                   $('[id*=gvEmployeeList] tr').filter(function () {
                                       $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                   });
                               });
                           });


                           //On UpdatePanel Refresh
                           var prm = Sys.WebForms.PageRequestManager.getInstance();
                           if (prm != null) {
                               prm.add_endRequest(function (sender, e) {
                                   if (sender._postBackSettings.panelsToUpdate != null) {

                                       $(function () {
                                           $('[data-toggle="tooltip"]').tooltip()
                                       })

                                       $(function () {
                                           $('.calendarInput').datetimepicker(
                                               {
                                                   format: 'L'
                                               });
                                       });

                                       //Search function
                                       $(function searchInput() {
                                           $('[id*=txtSearch]').on("keyup", function () {
                                               var value = $(this).val().toLowerCase();
                                               $('[id*=gvEmployeeList] tr').filter(function () {
                                                   $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                               });
                                           });
                                       });

                                   }
                               });
                           };
                       </script>           


  <div class="panel panel-warning">
    <div class="panel-heading">
 
                <h5><span class="glyphicon glyphicon-cog"></span> Employee Leave Setup : YEAR APPLIED: <asp:Label runat="server" ID="lblFY"></asp:Label></h5>
        
    </div>
    <div class="panel-body">
    
      
        <div class="row">
        <!-- LEFT -->
       <!-- Search Area -->
         <div class="col-md-3">
             <div class="input-group">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                        placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                    </asp:TextBox>
                    <div class="input-group-btn input-group-sm">
                        <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                    </div>
             </div>
         </div>
        <div class="col-md-3 col-md-offset-6 text-right">
            <asp:LinkButton runat="server" ID="lnkSave" CssClass="btn btn-primary" OnClick="lnkSave_Click"><span class="glyphicon glyphicon-saved"></span> Save</asp:LinkButton>
        </div>
        <div class="col-md-12">
             
         <hr />
            <asp:Panel runat="server" ID="panelEmployeeList" Height="550px" ScrollBars="Vertical">
                <asp:GridView runat="server" ID="gvEmployeeList"
                    CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False" OnRowDataBound="gvEmployeeList_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                        <asp:BoundField DataField="Date_Hired" HeaderText ="Date Hired" DataFormatString="{0:d}" />
                       
                         <asp:TemplateField ItemStyle-CssClass="text-center" HeaderText="Tenure" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTenure" CssClass="text-center"></asp:Label> 
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderText="Leave Credit" ControlStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtCredit" Text='<%# Eval("LeaveCredit") %>' CssClass="form-control text-center" Width="80px" TextMode="Number"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </asp:Panel>
        </div>
     
       
    </div>


    <!-- Display Modal Input Here -->
   

    </div>
   </div>


     

    </div>
   </div>
 
 
        
        <!-- User Notificaton -->
        <div class="modal fade" id="msgSuccessModal">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-success">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title">HR Management System</h4>
                                              </div>
                                              <div class="modal-body">
                                                  <h4 class="text-success">
                                                      <span class="glyphicon glyphicon-saved"></span>&nbsp;
                         <asp:Label runat="server" ID="lblSuccessMessage"></asp:Label></h4>
                                              </div>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
                                      </div>
                                  </div>

        <div class="modal fade" id="msgErrorModal">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-danger">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title">HR Management System</h4>
                                              </div>
                                              <div class="modal-body">
                                                  <h4 class="text-danger">
                                                      <span class="glyphicon glyphicon-remove"></span>&nbsp;
                                            <asp:Label runat="server" ID="lblErrorMessage"></asp:Label></h4>
                                              </div>
                                             
                                          </div>
                                      </div>
                                  </div>
               

    </ContentTemplate>
</asp:UpdatePanel>
</div><!-- END OF DIV CONTAINER-->


</asp:Content>
