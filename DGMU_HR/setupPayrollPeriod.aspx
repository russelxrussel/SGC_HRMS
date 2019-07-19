<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="setupPayrollPeriod.aspx.cs" Inherits="DGMU_HR.setupPayrollPeriod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

<br /><br /><hr />   
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
    <h4><span class="glyphicon glyphicon-wrench"></span> Payroll Period Maintenance </h4>
    </div>
    <div class="panel-body">
 <asp:LinkButton runat="server" ID="lnkCreateItem" OnClick="lnkCreateItem_Click" 
        CssClass="btn btn-primary btn-sm"><span class="glyphicon glyphicon-plus-sign"></span> CREATE</asp:LinkButton>
        <hr />
    <!-- Display Gridview List of Items -->
    <asp:GridView runat="server" ID="gvPayrollPeriod" CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False" OnRowDataBound="gvPayrollPeriod_RowDataBound">
        <Columns>
            <asp:BoundField DataField="PPID" HeaderText="Code" />
             <asp:BoundField DataField="Description" HeaderText="Description" />
           <asp:BoundField DataField="Date_Start" HeaderText="Start" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Date_End" HeaderText="End" DataFormatString="{0:d}" />
            <asp:TemplateField>
                <ItemTemplate>
                     <asp:Image runat="server" ID="imgDefault" ImageUrl="~/images/approve.png" Visible="false" />
                     <asp:LinkButton runat="server" ID="lnkDefault" CssClass="btn btn-sm btn-primary" Visible="false" OnClick="lnkDefault_Click" data-toggle="tooltip" data-placement="top" title="Set as Default Payroll Period"><span class="glyphicon glyphicon-map-marker"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
                      <asp:UpdatePanel runat="server" ID="panelSubContent" UpdateMode="Conditional">
                    <ContentTemplate>

                    <ul class="list-group">
                    
                    <li class="list-group-item">
                    
                    <div class="row">
                     
                         
                        <div class="col-md-6">
                        <div class="form-group has-error">
                            <small class="form-text text-muted">Start Date</small>
                                            <asp:TextBox runat="server" CssClass="form-control text-uppercase calendarInput" ID="txtStartDate"
                                                placeholder="Start"></asp:TextBox>
                                        </div>
                            
                        </div>

                        <div class="col-md-6">
                             <div class="form-group has-error">
                                 <small class="form-text text-muted">End Date</small>
                                            <asp:TextBox runat="server" CssClass="form-control text-uppercase calendarInput" ID="txtEndDate"
                                                placeholder="End"></asp:TextBox>
                                        </div>
                        </div>
                    
               
                    </li>

                   

                    
               </ul>
              
                   
                    
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

    </ContentTemplate>
</asp:UpdatePanel>
<!--</div> END OF DIV CONTAINER-->


</asp:Content>
