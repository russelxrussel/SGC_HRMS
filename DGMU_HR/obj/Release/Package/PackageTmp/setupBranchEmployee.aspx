<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="setupBranchEmployee.aspx.cs" Inherits="DGMU_HR.setupBranchEmployee" %>
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
 
                <h4><span class="glyphicon glyphicon-wrench"></span> Branch - Employee Maintenance </h4>
   
    </div>
    <div class="panel-body">
    <div class="row">
        <!-- LEFT -->
        <div class="col-md-6">
            <ul class="list-group">
               
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-md-8">
                            <small class="form-text text-muted">Wage Area Supervisor</small>
                            <asp:DropDownList runat="server" id="ddWageArea" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Wage Area" AutoPostBack="true" OnSelectedIndexChanged="ddWageArea_SelectedIndexChanged"> </asp:DropDownList>
                        </div>
                         <div class="col-md-4">
                             <small class="form-text text-muted">Wage Area Salary Per Day</small>
                             <b><asp:Label runat="server" ID="lblWageAmount"></asp:Label></b>
                        </div>
                    </div>
                      
                          
               
                </li>

                <li class="list-group-item">
                      <div class="row">
                        <div class="col-md-8">
                            <small class="form-text text-muted">Branch</small>
                             <asp:DropDownList runat="server" id="ddBranchList" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Branch" AutoPostBack="true" OnSelectedIndexChanged="ddBranchList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <div class="col-md-4">
                           <asp:LinkButton runat="server" ID="lnkSetBranch" CssClass="btn btn-sm btn-primary" OnClick="lnkSetBranch_Click"><span class="glyphicon glyphicon-pushpin"></span> SET</asp:LinkButton>
                        </div>
                    </div>
                   
                </li>

              
                <li class="list-group-item">
      
      <asp:GridView runat="server" ID="gvLinkBranchEmployeeAssigned" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">
    
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
           <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
            <asp:BoundField DataField="Date_Hired"  DataFormatString="{0:d}" HeaderText="Date Hired" />
            <asp:TemplateField ItemStyle-CssClass="text-center">
            <ItemTemplate>
            <asp:LinkButton ID="lnkBranchEmployeeRemove" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lnkBranchEmployeeRemove_Click"> <span class="glyphicon glyphicon-resize-full"></span> Remove</asp:LinkButton>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           
        </Columns>
    
    </asp:GridView>
                </li>
            </ul>
          
        </div>

        <!--RIGHT -->
        <div class="col-md-6">
             <div class="input-group">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                        placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                    </asp:TextBox>
                    <div class="input-group-btn input-group-sm">
                        <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                    </div>
                </div>
         <hr />
            <asp:Panel runat="server" ID="panelEmployeeNoPayrollGroup" Height="650px" ScrollBars="Vertical">
            <asp:GridView runat="server" ID="gvEmployeeList" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">
    
        <Columns>
           <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
           <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
            <asp:BoundField DataField="Date_Hired"  DataFormatString="{0:d}" HeaderText="Date Hired" />
            <asp:TemplateField ItemStyle-CssClass="text-center">
            <ItemTemplate>
            <asp:LinkButton ID="lnkEmployeeAssign" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkEmployeeAssign_Click"><span class="glyphicon glyphicon-plus"></span> Assign</asp:LinkButton>
              </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           
        </Columns>
    
    </asp:GridView>
                </asp:Panel>
        </div>
    </div>
    <!-- Display Gridview List of Items -->
    
 
    </div>
   </div>
 
        
        <div class="modal fade" id="msgSuccessModal">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-success">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title">DGMU Enterprises System</h4>
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
