<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="setupWageArea.aspx.cs" Inherits="DGMU_HR.setupWageArea" %>
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


<div class="row">
    
<div class="col-md-3">
    
    

 <asp:LinkButton runat="server" ID="lnkCreateItem" OnClick="lnkCreateItem_Click" 
        CssClass="btn btn-primary btn-sm"><span class="glyphicon glyphicon-plus-sign"></span> CREATE</asp:LinkButton>
</div>

 <div class="col-md-3 col-md-offset-6">
                     
                    </div>
</div>
 <hr />
  <div class="panel panel-warning">
    <div class="panel-heading">
    <h4><span class="glyphicon glyphicon-tasks"></span> Wage Per Area Supervisor - Maintenance </h4>
    </div>
    <div class="panel-body">

    <!-- Display Gridview List of Items -->
    <asp:GridView runat="server" ID="gvStorageArea" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">
    
        <Columns>
            <asp:TemplateField ItemStyle-CssClass="text-left">
            <ItemTemplate>
            <asp:Button ID="btnEditItem" runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" OnClick="btnEditItem_Click" />
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="WageCode" HeaderText="Code" />
            <asp:BoundField DataField="WageArea" HeaderText="Area" />
            <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" />
            <asp:BoundField DataField="WageAmount" HeaderText="Basic Rate" />
            <asp:BoundField DataField="SrQuota" HeaderText ="Senior Quota Multiplier" />
            <asp:BoundField DataField="RegQuota" HeaderText ="Regular Quota Multiplier" />
            <asp:BoundField DataField="WBQuota" HeaderText ="Branch Wife Quota Multiplier" />
            <asp:BoundField DataField="SBQuota" HeaderText ="Branch Single Employee Quota Multiplier" />
           
        </Columns>
    
    </asp:GridView>
 
    </div>
   </div>


        <!--MESSAGE MODAL SECTION-->

        <!--Create Update Container -->
        <div class="modal fade" id="ItemContainer" data-backdrop="static" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-header bg-warning">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"><asp:Label runat="server" ID="lblActionTitle"></asp:Label></h4>
                </div>

              
                  
                <div class="modal-body">
                      <asp:UpdatePanel runat="server" ID="panelSubContent">
                    <ContentTemplate>

                 
                    
                        <div class="row">

                            <div class="col-md-3">
                                <div class="form-group has-error">
                                    <small class="form-text text-muted">Code</small>
                                    <asp:TextBox runat="server" CssClass="form-control text-uppercase" ID="txtWageCode"
                                        placeholder="CODE" MaxLength="3"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group has-error">
                                    <small class="form-text text-muted">Wage Area Supervisor</small>
                                    <asp:TextBox runat="server" CssClass="form-control text-uppercase" ID="txtWageArea"
                                        placeholder=" Wage Area Supervisor" data-toggle="tooltip" data-placement="top" title="Wage Area Supervisor"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-3">
                                <small class="form-text text-muted">Wage Salary Amount</small>
                                <asp:TextBox runat="server" ID="txtWageAmount" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Wage Amount" onkeypress="return(event.charCode == 8 || event.charCode == 0) ? 0: event.charCode >= 46 && event.charCode <=57" ></asp:TextBox>
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <small class="form-text text-muted">Supervisor</small>
                              <asp:TextBox runat="server" ID="txtSupervisorName" placeholder="Area Supervisor" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Area Supervisor Name"></asp:TextBox>
                            </div>
                           
                        </div>

                        <div class="row">
                             <div class="col-md-6">
                                <small class="form-text text-muted">Sr Quota Multiplier</small>
                                <asp:TextBox runat="server" ID="txtSrQuota" placeholder="Sr Quota" CssClass="form-control" TextMode="Number" data-toggle="tooltip" data-placement="top" title="Senior Multiplier"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <small class="form-text text-muted">Jr Quota Multiplier</small>
                                <asp:TextBox runat="server" ID="txtRegularQuota" placeholder="Regular Quota" CssClass="form-control" TextMode="Number" data-toggle="tooltip" data-placement="top" title="Regular Multiplier"></asp:TextBox>
                            </div>
                             
                        </div>
                          
                        <br />
                        <div class="row">
                           
                        
                        <div class="col-md-6">
                                <small class="form-text text-muted">Branch Wife Quota Multiplier</small>
                                <asp:TextBox runat="server" ID="txtBranchWifeQuota" placeholder="Branch Wife Quota" CssClass="form-control" TextMode="Number" data-toggle="tooltip" data-placement="top" title="Branch Wife Multiplier"></asp:TextBox>
                            </div>
                              <div class="col-md-6">
                                <small class="form-text text-muted">Branch Single Employee Quota Multiplier</small>
                                <asp:TextBox runat="server" ID="txtBranchSingleQuota" placeholder="Branch Single Employee Quota" CssClass="form-control" TextMode="Number" data-toggle="tooltip" data-placement="top" title="Branch Single Employee  Multiplier"></asp:TextBox>
                            </div>
                            </div>
                        <br />
                    <asp:Button runat="server" ID="btnCreateUpdate"  CssClass="btn btn-success btn-sm" OnClick="btnCreateUpdate_Click" Text="Create" />
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
              </div>

                <div class="modal-footer">
                    
                
                <asp:LinkButton runat="server" ID="lnkClose" CssClass="btn btn-danger btn-sm" data-dismiss="modal">Cancel</asp:LinkButton>

                </div>


                 
            </div>
            </div>

          
       </div>
     

               

    </ContentTemplate>
</asp:UpdatePanel>
</div><!-- END OF DIV CONTAINER-->


</asp:Content>
