<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryPayrollVoucher.aspx.cs" Inherits="DGMU_HR.dataEntryPayrollVoucher" %>
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
 
               <%-- <h4><span class="glyphicon glyphicon-cog"></span> Payroll Voucher </h4>--%>
          <h5><span class="glyphicon glyphicon-cog"></span> <asp:Label runat="server" ID="lblPayrollPeriodText"></asp:Label></h5>
   
    </div>
    <div class="panel-body">
    <div class="row">
        <!-- LEFT -->
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
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False" OnRowDataBound="gvEmployeeList_RowDataBound">
    
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
        <div class="col-md-6">
            <div class="row">
               
                 <div class="col-md-6">
                     <div class="panel panel-warning">
                         <div class="panel-heading"> <asp:Label runat="server" ID="lblHeading"></asp:Label></div>
                         <div class="panel-body">
                             <table class="table table-responsive">
                                 <tr>
                                     <td>Actual Rate:</td> <td><asp:Label runat="server" ID="lblActualRate"></asp:Label></td>
                                 </tr>
                                 <tr>
                                         <td>Basic Rate:</td> <td><asp:Label runat="server" ID="lblBasicRate"></asp:Label></td>
                                 </tr>

                                 <tr>
                                     <td>Computed Rate:</td><td><asp:Label runat="server" ID="lblComputedRated"></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td>Additional:</td><td><asp:TextBox runat="server" ID="txtAdditionalAmount" TextMode="Number" CssClass="form-control"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>Remarks:</td><td><asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" Rows="2" CssClass="form-control" placeholder="Remarks"></asp:TextBox></td>
                                 </tr>
                                 <tr><td>Total Voucher Amount:</td>
                                     <td><b><asp:Label runat="server" ID="lblComputedVoucher"></asp:Label></b></td>

                                 </tr>
                             </table>

                             <div class="row">
                                 <div class="col-md-6"><asp:LinkButton runat="server" ID="lnkCompute" CssClass="btn btn-warning btn-sm" data-toggle="tooltip" data-placement="top" title="Compute Voucher" OnClick="lnkCompute_Click"><span class="glyphicon glyphicon-th"></span></asp:LinkButton></div>
                                 <div class="col-md-6 text-right"><asp:LinkButton runat="server" ID="lnkProcess" CssClass="btn btn-success btn-sm" data-toggle="tooltip" data-placement="top" title="Process Voucher" OnClick="lnkProcess_Click"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton></div>
                             </div>
                         </div>
                     </div>
                </div>
                
                <div class="col-md-6">
                     <div class="panel panel-success">
                <div class="panel-heading"> Payroll Attendance Summary</div>
                <div class="panel-body">
                    <table class="table table-responsive">
                        <tr>
                            <td>Day(s) Present</td>
                            <td>
                                <asp:Label runat="server" ID="lblDaysPresent"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Leave</td>
                            <td>
                                <asp:Label runat="server" ID="lblLeave"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Pay-Off</td>
                            <td>
                                <asp:Label runat="server" ID="lblPayOff"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Legal Holiday</td>
                            <td>
                                <asp:Label runat="server" ID="lblLegalHoliday"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Special Holiday</td>
                            <td>
                                <asp:Label runat="server" ID="lblSpecialHoliday"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Absent</td>
                            <td>
                                <asp:Label runat="server" ID="lblAbsent" CssClass="text-danger"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
                </div>
            </div>
           
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
