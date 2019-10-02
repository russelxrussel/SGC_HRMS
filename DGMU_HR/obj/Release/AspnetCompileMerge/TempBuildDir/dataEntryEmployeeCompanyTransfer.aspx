<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryEmployeeCompanyTransfer.aspx.cs" Inherits="DGMU_HR.dataEntryEmployeeCompanyTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
 

<br /><br /><hr />  
<%--<div class="container container_content">--%>
    <div class="small">
   
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
 
                <h5><span class="glyphicon glyphicon-cog"></span> Employee Company Transfer </h5>
        
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
         <hr />
            <asp:Panel runat="server" ID="panelEmployeeList" Height="550px" ScrollBars="Vertical">
                <asp:GridView runat="server" ID="gvEmployeeList"
                    CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">

                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />

                        <asp:TemplateField ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkSelect_Click" data-toggle="tooltip" data-placement="top" title="Select"><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </asp:Panel>
        </div>
     
         <!--RIGHT -->
         <!-- Details / Input Area -->
        <div class="col-md-9">
               
               <div class="col-md-12">
               <div class="panel panel-default">
                <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> <asp:Label runat="server" ID="lblEmployeeName"></asp:Label></div>
                <div class="panel-body">
                        <div class="row">
                     
                      <div class="col-md-2 hidden">
                             
                                 <div class="text-center">
                                     <asp:Image runat="server" ID="imgEmployee" CssClass="img-circle img-responsive" Width="200px" Height="200px" />
                                     <hr />
                                    
                                 </div>
                          
                          </div>

                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <span class="glyphicon glyphicon-briefcase"></span> Employment Transfer History
                                    </div>
                                    <div class="panel-body">
                                       <h5> Current Company :
                                        <b><asp:Label runat="server" ID="lblCurrentCompany"></asp:Label></b></h5>
                                        <hr />
                                        <asp:GridView runat="server" ID="gvEmployeeTransferHistory" CssClass="table table-responsive" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="OldCompany" HeaderText="Previous Company" />
                                                <asp:BoundField DataField="DateEnd" HeaderText="Date End" DataFormatString="{0:d}" />
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                               <%-- <asp:BoundField DataField="Used" HeaderText="Used" />
                                                <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-CssClass="text-danger" ItemStyle-Font-Bold="true" />--%>

                                            </Columns>
                                        </asp:GridView>


                                    </div>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading"><span class="glyphicon glyphicon-tag"></span> Company Transfer Data Entry</div>
                                    <div class="panel-body">
                                        <ul class="list-group">
                                             <li class="list-group-item">
                                                <div class="input-group">
                                                    <span class="input-group-addon alert-warning">Date End in Current Company:</span>
                                                    <asp:TextBox runat="server" ID="txtDateEnd" CssClass="form-control calendarInput"></asp:TextBox>
                                                    
                                                </div>
                                            </li>

                                            <li class="list-group-item">
                                                <div class="input-group">
                                                    <span class="input-group-addon alert-warning">Date Transfer:</span>
                                                    <asp:TextBox runat="server" ID="txtDateTransfer" CssClass="form-control calendarInput"></asp:TextBox>
                                                </div>
                                            </li>

                                            <li class="list-group-item">
                                                <div class="input-group">

                                                    <span class="input-group-addon alert-warning">Transfer To :</span>

                                                    <asp:DropDownList runat="server" ID="ddTransferCompanyTo" CssClass="form-control" Enabled="false">
                                                    </asp:DropDownList>

                                                    <%-- <span class="input-group-addon alert-warning">Days</span>
                        <asp:TextBox runat="server" ID="txtDays" CssClass="form-control"></asp:TextBox>--%>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="input-group">
                                                    <span class="input-group-addon alert-warning">Date Start:</span>
                                                    <asp:TextBox runat="server" ID="txtDateStart" CssClass="form-control calendarInput"></asp:TextBox>
                                                   
                                                </div>
                                            </li>
                                           

                                            <li class="list-group-item">
                                                <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" CssClass="form-control" Rows="2" placeholder="Remarks/Notes"></asp:TextBox>
                                            </li>

                                            <li class="list-group-item text-right">
                                                <asp:LinkButton runat="server" ID="lnkProcess" CssClass="btn btn-primary btn-sm" OnClick="lnkProcess_Click"><span class="glyphicon glyphicon-floppy-saved"></span> Process</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                             

                     </div>
                </div>
                   
                          
                    

              
                </div>

           </div>
        </div>
    </div>


   

    </div>
   </div>


          <!-- Additional Loan -->
         <div class="modal fade" id="modalShowLeaves">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-object-align-right"></span> Leave History</h4>
                                              </div>
                                              <asp:Panel runat="server" ID="panelLeaveHistory" Height="400" ScrollBars="Vertical">
                                              <div class="modal-body">
                                                   <asp:GridView runat="server" ID="gvLeaveHistory" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                       <Columns>
                                                           <asp:BoundField DataField="LeaveDescription" HeaderText="Description" />
                                                           <asp:BoundField DataField="DaysCount" HeaderText="Days" />
                                                           <asp:BoundField DataField="DateFrom" DataFormatString="{0:d}" HeaderText="From" />
                                                           <asp:BoundField DataField="DateTo" DataFormatString="{0:d}" HeaderText="To" />
                                                           <asp:BoundField DataField="Remarks" HeaderText="Remarks"/>
                                                       </Columns>
                                                   </asp:GridView>
                                              </div>
                                              </asp:Panel>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
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
               
        <!--PROMPT USER SELECTION -->
        <div class="modal fade" id="promptMessage" data-backdrop="static" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-header alert-warning">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">HR Management System</h4>
                </div>
                 
                      <div class="modal-body">
                      <h3><span class="glyphicon glyphicon-question-sign alert-info"></span> Transfer Employee Company?.</h3>
                     
                      <p>Are you sure you want to continue to transfer employee company record?</p>
                       

                      </div>
                

                  <div class="modal-footer">
                    
                <asp:LinkButton runat="server" ID="lnkOK" CssClass="btn btn-primary btn-sm" OnClick="lnkOK_Click">Yes</asp:LinkButton>

                <asp:LinkButton runat="server" ID="lnkClose" CssClass="btn btn-danger btn-sm" data-dismiss="modal">No</asp:LinkButton>

                </div>


                 
            </div>
            </div>

          
       </div>

    </ContentTemplate>
</asp:UpdatePanel>
</div><!-- END OF DIV CONTAINER-->


</asp:Content>
