<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="setupBranchWage.aspx.cs" Inherits="DGMU_HR.setupBranchWage" %>
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
                                   $('[id*=gvBranchList] tr').filter(function () {
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
                                               $('[id*=gvBranchList] tr').filter(function () {
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
 
                <h4><span class="glyphicon glyphicon-wrench"></span> Branch - Wage Maintenance </h4>
   
    </div>
    <div class="panel-body">
    <div class="row">
        <!-- LEFT -->
        <div class="col-md-5">
            <ul class="list-group">
               
                <li class="list-group-item">
                    <small class="form-text text-muted">Wage Area Supervisor</small>
                      <asp:DropDownList runat="server" id="ddWageArea" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Wage Area" AutoPostBack="true" OnSelectedIndexChanged="ddWageArea_SelectedIndexChanged">

                </asp:DropDownList>
                </li>

                <li class="list-group-item">
      
      <asp:GridView runat="server" ID="gvLinkBranch" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">
    
        <Columns>
           
            <asp:BoundField DataField="BranchCode" HeaderText="Code" />
           <asp:BoundField DataField="BranchName" HeaderText="Branch" />
            <asp:TemplateField ItemStyle-CssClass="text-center">
            <ItemTemplate>
            <asp:LinkButton ID="lnkBranchUnLinked" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btnLinkedBranch_Click"><span class="glyphicon glyphicon-resize-full"></span> UnLink</asp:LinkButton>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           
        </Columns>
    
    </asp:GridView>
                </li>
            </ul>
          
        </div>

        <!--RIGHT -->
        <div class="col-md-7">
             <div class="input-group">
                 <div class="input-group-btn input-group-sm">
                  <asp:LinkButton ID="lnkNewBranch" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkNewBranch_Click"><span class="glyphicon glyphicon-plus-sign"></span> New Branch</asp:LinkButton>
                      </div>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                        placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Branch">
                    </asp:TextBox>
                    <div class="input-group-btn input-group-sm">
                        <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                    </div>
                </div>
         <hr />
            <asp:Panel runat="server" ID="panelBranchListNoAssignment" Height="650px" ScrollBars="Vertical">
            <asp:GridView runat="server" ID="gvBranchList" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">
    
        <Columns>
            <asp:BoundField DataField="BranchCode" HeaderText="Code" />
           <asp:BoundField DataField="BranchName" HeaderText="Branch" />
            <asp:TemplateField ItemStyle-CssClass="text-center">
            <ItemTemplate>
            <asp:LinkButton ID="lnkBranchLinked" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnLinkedBranch_Click"><span class="glyphicon glyphicon-link"></span> Link</asp:LinkButton>
           <%-- <asp:LinkButton ID="lnkBranchUnLinked" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btnLinkedBranch_Click"><span class="glyphicon glyphicon-resize-full"></span> UnLink</asp:LinkButton>--%>
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
 
         <!--Create Update Container -->
        <div class="modal fade" id="ItemContainer" data-backdrop="static" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-header bg-warning">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"><asp:Label runat="server" ID="lblActionTitle"></asp:Label></h4>
                </div>

              
                  
                <div class="modal-body">
                  <asp:UpdatePanel runat="server" ID="panelSubContent" UpdateMode="Conditional">
                    <ContentTemplate>

                 
                    
                        <div class="row">

                            <div class="col-md-4">
                                <div class="form-group has-error">
                                    <small class="form-text text-muted">Code</small>
                                    <asp:TextBox runat="server" CssClass="form-control text-uppercase" ID="txtBranchCode"
                                        placeholder="CODE" MaxLength="6"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group has-error">
                                    <small class="form-text text-muted">Branch Name</small>
                                    <asp:TextBox runat="server" CssClass="form-control text-uppercase" ID="txtBranchName"
                                        placeholder=" Branch" data-toggle="tooltip" data-placement="top" title="Branch Name"></asp:TextBox>
                                </div>

                            </div>

                           
                        </div>
                    
                    <asp:Button runat="server" ID="btnCreateUpdate" OnClick="btnCreateUpdate_Click"  CssClass="btn btn-success btn-sm" Text="Create" />
                    
                      
                    </ContentTemplate>
                </asp:UpdatePanel>
              </div>

                <div class="modal-footer">
                    
                
                <asp:LinkButton runat="server" ID="lnkClose" CssClass="btn btn-danger btn-sm" data-dismiss="modal">Cancel</asp:LinkButton>

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
