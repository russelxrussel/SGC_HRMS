<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryEmployeeLeave.aspx.cs" Inherits="DGMU_HR.dataEntryEmployeeLeave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
 
<br /><hr />  
<%--<div class="container container_content">--%>
    <div class="small">
   
<asp:UpdatePanel runat="server" ID="uplMain" UpdateMode="Conditional">
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

                                      

                                       /*Toast Notification
                                       $(function toastMessage(title,message) {
                                           toastr.options = {
                                               'closeButton': true,
                                               'debug': false,
                                               'newestOnTop': false,
                                               "progressBar": true,
                                               'positionClass': 'toast-top-right',
                                               "preventDuplicates": true,
                                               "onclick": null,
                                               "showDuration": "300",
                                               "hideDuration": "1000",
                                               "timeOut": "2000",
                                               "extendedTimeOut": "1000",
                                               "showEasing": "swing",
                                               "hideEasing": "linear",
                                               "showMethod": "fadeIn",
                                               "hideMethod": "fadeOut"
                                           }
                                           toastr["warning"](title, message)

                                       }); 
                                      */
                                   }
                               });
                           };
                       </script>           


  <div class="panel panel-warning">
    <div class="panel-heading">
 <div class="row">
     <div class="col-md-8"><h5><span class="fa fa-cogs"></span> Employee Leave Data Entry - Default Year: <asp:Label runat="server" ID="lblFY"></asp:Label> </h5></div>
     <div class="col-md-4"><div class="input-group">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                        placeholder="Search Employee" data-toggle="tooltip" data-placement="top" title="Search Employee">
                    </asp:TextBox>
                    <div class="input-group-btn input-group-sm">
                        <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-success"><span class="fa fa-search"></span></asp:LinkButton>
                    </div>
                </div></div>
 </div>

                
        
    </div>
    <div class="panel-body">
    
      
        <div class="row">
        <!-- LEFT -->
       <!-- Search Area -->
        <div class="col-md-12">
            <asp:Panel runat="server" ID="panelEmployeeList" Height="550px" ScrollBars="Vertical">
                <asp:GridView runat="server" ID="gvEmployeeList"
                    CssClass="table table-responsive table-hover" GridLines="None" AutoGenerateColumns="False">

                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                   <div class="input-group">
                          <asp:Image runat="server" ID="Image1" CssClass="img-circle" ImageUrl='<%# Eval("EmployeeAvatar") %>' />
                          <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                       
                        </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MaritalStatus" HeaderText="Status" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                        <asp:BoundField DataField="Balance" HeaderText="Leave Balance" />
                        <asp:TemplateField ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkSelect_Click" data-toggle="tooltip" data-placement="top" title="Select"><span class="fa fa-pencil-alt   "></span></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </asp:Panel>
        </div>
     
        
    </div>
         <!-- Details / Input Area -->
        <asp:Panel runat="server" ID="panelInput" Visible="false">
        <div class="row">
               
               <div class="col-md-12">
               <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-9"></div>
                        
                        <div class="col-md-3 text-right">
                            <asp:LinkButton runat="server" ID="lnkBack" CssClass="btn btn-primary btn-sm" OnClick="lnkBack_Click"><i class="fa fa-arrow-alt-circle-left"></i> Back</asp:LinkButton>
                        </div>
                        
                    </div>
                    </div>
                   
                <div class="panel-body">
                        <div class="row">
                     
                     
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <span class="fa fa-user-circle"></span> <asp:Label runat="server" ID="lblEmployeeName"></asp:Label>
                                        
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Image runat="server" ID="imgEmployee" CssClass="img-circle img-responsive text-center" Width="100px" Height="100px" />
                                            </div>
                                            <div class="col-md-8">
                                                <i class="fa fa-list-alt text-info"></i> Leaves Credit and Balances Summary
                                                <asp:GridView runat="server" ID="gvEmployeeLeaveAvailability" CssClass="table table-responsive" AutoGenerateColumns="false" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="LeaveDescription" HeaderText="Description" />
                                                <asp:BoundField DataField="Credit" HeaderText="Leave Credit" />
                                                <asp:BoundField DataField="Used" HeaderText="Used" />
                                                <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-CssClass="text-danger" ItemStyle-Font-Bold="true" />

                                            </Columns>
                                        </asp:GridView>
                                            </div>
                                        </div>
                                        
                                        <hr />
                                        <h4><i class="fa fa-book-reader text-success"></i> Records</h4>
                                        <asp:GridView runat="server" ID="gvLeaveHistory" CssClass="table table-responsive table-hover" GridLines="None" OnRowDataBound="gvLeaveHistory_RowDataBound" AutoGenerateColumns="false" HeaderStyle-CssClass="bg-warning">
                                            <Columns>
                                                <asp:BoundField DataField="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="LeaveDescription" HeaderText="Description" />
                                                <asp:BoundField DataField="DaysCount" HeaderText="Days" />
                                                <asp:BoundField DataField="DateFrom" DataFormatString="{0:d}" HeaderText="From" />
                                                <asp:BoundField DataField="DateTo" DataFormatString="{0:d}" HeaderText="To" />
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                <asp:BoundField DataField="IsPayrollProcess" />
                                                <asp:BoundField DataField="IsCancel" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkRemoveLeave" CssClass="btn btn-sm btn-danger" OnClick="lnkRemoveLeave_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                                
                            <div class="col-md-6"> 
                                <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-6"><span class="glyphicon glyphicon-tag"></span> Leave Application Entry</div>
                        <div class="col-md-6 text-right"><asp:LinkButton runat="server" ID="lnkProcess" CssClass="btn btn-primary btn-sm" OnClick="lnkProcess_Click"><i class="fa fa-hdd"></i> Process</asp:LinkButton></div>
                    </div> <!-- End of Row-->
                    </div>
                <div class="panel-body">
                    <table class="table table-responsive table-hover">
                        <tr>
                            <td>
                                <div class="input-group input-group-sm">
                                <span class="input-group-addon"><i class="fa fa-calendar-alt"></i> Date Applied:</span>
                                <asp:TextBox runat="server" ID="txtDateApplied" CssClass="form-control calendarInput"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="input-group input-group-sm">
                                <span class="input-group-addon"><i class="fa fa-file-alt"></i> Leave Type:</span>
                        <!--Make the ddLeaveList disable to prevent selection 
                            because leave available only is Service Incentive  09022019-->
                        <asp:DropDownList runat="server" ID="ddLeavesList" CssClass="form-control">
                        </asp:DropDownList>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="input-group input-group-sm">
                        <span class="input-group-addon"><i class="fa fa-calendar-alt"></i> Date From:</span>
                        <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control calendarInput"></asp:TextBox>
                                </div>
                          </td>
                            <td>
                                <div class="input-group input-group-sm">
                                <span class="input-group-addon"><i class="fa fa-calendar-alt"></i> Date To:</span>
                        <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control calendarInput"></asp:TextBox>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:CheckBox runat="server" ID="chkWithHalfday" Text="Halfday?" CssClass="checkbox-inline"/></td>
                            <td><asp:CheckBox runat="server" ID="chkIncludeToPayroll" Text="Include into payroll process?" CssClass="checkbox-inline"/></td>
                        </tr>
                        <tr>
                            <td colspan="2">
<asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" CssClass="form-control" Rows="2" placeholder="Remarks/Notes"></asp:TextBox>
                            </td>
                             
                        </tr>
                    </table>

                    
                </div>
                                    </div>
                            </div>

                            

                     </div>
                </div>
                   
                          
                    

              
                </div>

           </div>
        </div>
        
        </asp:Panel>

   

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
                      <h3><span class="glyphicon glyphicon-question-sign alert-info"></span> Employee exceed leave balance.</h3>
                     
                      <p>Are you sure you want to continue leave entry?</p>

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
