<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryEmployeeLoan.aspx.cs" Inherits="DGMU_HR.dataEntryEmployeeLoan" %>
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
 
                <h6><span class="glyphicon glyphicon-cog"></span> Employee Loan Management </h6>
        
    </div>
    <div class="panel-body">
    <div class="row">
        <!-- LEFT -->
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
        <div class="col-md-9">
            <div class="row">
               
                <div class="col-md-12">
               <div class="panel panel-default">
                <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> <asp:Label runat="server" ID="lblEmployeeName"></asp:Label></div>
                <div class="panel-body">
                        <div class="row">
                      <div class="col-md-5 hidden">
                     <div class="panel panel-success">
                         <div class="panel-heading">Create New Loan  <asp:LinkButton runat="server" ID="lnkCreateLoan" CssClass="btn btn-primary btn-sm" data-toggle="tooltip" data-placement="top" title="New Loan" OnClick="lnkCreateLoan_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>    
                           </div>
                         <div class="panel-body">
                             
                                 <div class="text-left">
                                     <asp:Image runat="server" ID="imgEmployee" CssClass="img-circle" Width="100px" Height="100px" Visible="false" />
                                 </div>
                             
                             
                            <asp:Panel runat="server" ID="panelNewLoan" Enabled="false">
                            <table class="table table-responsive sm">
                                 <tr>
                                     <td>Loan Date:</td> <td><asp:TextBox runat="server" ID="txtDateLoan" CssClass="form-control calendarInput"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>Loan Type:</td> <td><asp:DropDownList runat="server" ID="ddLoansList" CssClass="form-control"></asp:DropDownList></td>
                                 </tr>
                                 <tr>
                                    <td>Reference #:</td><td><asp:TextBox runat="server" ID="txtLoanReferenceNumber" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                     <td>Principal Amount:</td><td><asp:TextBox runat="server" ID="txtLoanAmount" TextMode="Number" CssClass="form-control"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>Loan Amount + Interest:</td><td><asp:TextBox runat="server" ID="txtLoanAmountAndInterest" TextMode="Number" CssClass="form-control"></asp:TextBox></td>
                                 </tr>
                               
                                <tr>
                                     <td>Monthly Amortization:</td><td><asp:TextBox runat="server" ID="txtLoanMonthlyAmortization" TextMode="Number" CssClass="form-control"></asp:TextBox></td>
                                 </tr>
                                <tr>
                                     <td>Date Start:</td> <td><asp:TextBox runat="server" ID="txtLoanStartDate" CssClass="form-control calendarInput"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>Date End:</td> <td><asp:TextBox runat="server" ID="txtLoanEndDate" CssClass="form-control calendarInput"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>Remarks:</td><td><asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" CssClass="form-control" placeholder="Remarks"></asp:TextBox></td>
                                 </tr>
                                
                             </table>
                            
                            <div class="text-right">
                           <asp:LinkButton runat="server" ID="lnkProcess" CssClass="btn btn-success btn-sm" data-toggle="tooltip" data-placement="top" title="Process Loan" OnClick="lnkProcess_Click"><span class="glyphicon glyphicon-check"></span></asp:LinkButton>
                                </div>
                                </asp:Panel>
                         </div>
                     </div>
                </div>
                     <div class="col-md-12">
                <div class="panel panel-danger">
                <div class="panel-heading"> <span class="glyphicon glyphicon-briefcase"></span> Active Loans and Balances Summary</div>
                <div class="panel-body">
                   <asp:GridView runat="server" ID="gvActiveLoans"
                    CssClass="table table-responsive table-hover table-condensed sm" AutoGenerateColumns="False" OnRowDataBound="gvActiveLoans_RowDataBound">

                    <Columns>
                         <asp:TemplateField HeaderStyle-CssClass ="hidden" ItemStyle-CssClass="hidden">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkPayroll" Visible="false" CssClass="btn btn-primary btn-sm" data-toggle="tooltip" data-placement="top" title="Link to Payroll Deduction" OnClick="lnkPayroll_Click"><span class="glyphicon glyphicon-link"></span></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkPayrollRemove" Visible="false" CssClass="btn btn-danger btn-sm" data-toggle="tooltip" data-placement="top" title="Unlink Deduction from Payroll" OnClick="lnkPayrollRemove_Click"><span class="glyphicon glyphicon-resize-full"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                         
                        <asp:BoundField DataField="LoanSN" HeaderText="Code" />
                        <asp:BoundField DataField="LoanReferenceNumber" HeaderText="Reference" />
                        <asp:BoundField DataField="LoanCode" HeaderStyle-CssClass ="hidden" ItemStyle-CssClass="hidden" />
                        <asp:BoundField DataField="LoanName" HeaderText="Name" />
                        <asp:BoundField DataField="LoanAmount" HeaderText="Princ. Amount" DataFormatString="{0:n}" />
                        <asp:BoundField DataField="LoanAmountAndInterest" HeaderText="Amount + Intrs." DataFormatString="{0:n}" />
                        <asp:BoundField DataField="MonthlyAmortization" HeaderText="Amortization" DataFormatString="{0:n}" />
                        <asp:BoundField DataField="TotalPayment" ItemStyle-CssClass="text-success" HeaderText="Payment" DataFormatString="{0:n}" />
                        <asp:BoundField DataField="Balance" ItemStyle-CssClass="text-danger" HeaderText="Balance" DataFormatString="{0:n}" />
                     
                        
                         <asp:TemplateField HeaderText="Add Loan">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkAddLoan" Visible="true" CssClass="btn btn-success btn-sm" data-toggle="tooltip" data-placement="top" title="Additional Loan" OnClick="lnkAddLoan_Click"><span class="glyphicon glyphicon-plus-sign"></span></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkViewAddLoans" CssClass="btn btn-info btn-sm" OnClick="lnkViewAddLoans_Click"><span class="glyphicon glyphicon-list-alt" data-toggle="tooltip" data-placement="top" title="View Loans"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Manual Pay">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkPayment" CssClass="btn btn-primary btn-sm" OnClick="lnkPayment_Click" data-toggle="tooltip" data-placement="top" title="Payment Entry"><span class="glyphicon glyphicon-circle-arrow-up"></span></asp:LinkButton>
                                  <asp:LinkButton runat="server" ID="lnkViewPayment" CssClass="btn btn-warning btn-sm" OnClick="lnkViewPayment_Click"><span class="glyphicon glyphicon-bookmark" data-toggle="tooltip" data-placement="top" title="View Payment Transactions"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                              
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                          </asp:GridView>
                    </div>
      </div>
                                 <div class="panel panel-info">
                <div class="panel-heading"><span class="glyphicon glyphicon-bell"></span> Loan History</div>
                <div class="panel-body">
                    <asp:GridView runat="server" ID="gvEmployeeLoanHistory" CssClass="table table-responsive table-hover table-condensed" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="LoanSN" HeaderText="Code" />
                            <asp:BoundField DataField="LoanReferenceNumber" HeaderText="Reference" />
                            <asp:BoundField DataField="LoanName" HeaderText="Name" />
                            <asp:BoundField DataField="LoanAmount" HeaderText="Amount" DataFormatString="{0:n}" />
                            <asp:BoundField DataField="DateClose" HeaderText="Date Settled" DataFormatString="{0:d}" />
                             <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkViewPayment" CssClass="btn btn-warning btn-sm" OnClick="lnkViewPaymentHistory_Click"><span class="glyphicon glyphicon-bookmark" data-toggle="tooltip" data-placement="top" title="View Payment History"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
    <!-- Display Modal Input Here -->
     <div class="modal fade" id="modalPaymentEntry">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-success">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title">Loan Payment</h4>
                                              </div>
                                              <div class="modal-body">
                                                  <table class="table table-responsive table-condensed">
                                                      <tr>
                                                          <td>Payment Date</td>
                                                          <td><asp:TextBox runat="server" ID="txtPaymentDate" CssClass="form-control calendarInput"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                          <td>Amount</td>
                                                          <td><asp:TextBox runat="server" ID="txtPaymentAmount" CssClass="form-control" TextMode="Number"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                          <td>Remarks</td>
                                                          <td><asp:TextBox runat="server" ID="txtPaymentRemarks" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Remarks"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                          <td></td>
                                                          <td>
                                                              <div class="text-right">
                                                          <asp:LinkButton runat="server" ID="lnkProcessPayment" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Process Payment" OnClick="lnkProcessPayment_Click"><span class="glyphicon glyphicon-saved"></span></asp:LinkButton>
                                                               </div>
                                                              </td>
                                                      </tr>

                                                  </table>
                                                  <%--<h4 class="text-success">
                                                      <span class="glyphicon glyphicon-saved"></span>&nbsp;
                         <asp:Label runat="server" ID="Label1"></asp:Label></h4>--%>
                                              </div>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
                                      </div>
                                  </div>
 
    <!-- Payment List -->
         <div class="modal fade" id="modalPaymentList">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-bookmark"></span> Loan Payment List</h4>
                                              </div>
                                              <div class="modal-body">
                                                  <asp:GridView runat="server" ID="gvLoanPaymentList" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                      <Columns>
                                                          <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" DataFormatString="{0:d}" />
                                                          <asp:BoundField DataField="LoanPaymentOR" HeaderText="Series" />
                                                          <asp:BoundField DataField="PaymentAmount" HeaderText="Amount" DataFormatString="{0:n}" />
                                                          <asp:BoundField DataField="PaymentRemarks" HeaderText="Remarks" />
                                                      </Columns>
                                                  </asp:GridView>
                                              </div>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
                                      </div>
                                  </div>

         <!-- Payment List -->
         <div class="modal fade" id="modalLoanDetailList">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-bookmark"></span> Loan Lists</h4>
                                              </div>
                                              <div class="modal-body">
                                                  <asp:GridView runat="server" ID="gvLoanDetailList" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                      <Columns>
                                                          <asp:BoundField DataField="LoanDate" HeaderText="Loan Date" DataFormatString="{0:d}" />
                                                          <asp:BoundField DataField="LoanAmount" HeaderText="Loan Amount" DataFormatString="{0:n}" />
                                                          <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                      </Columns>
                                                  </asp:GridView>
                                              </div>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
                                      </div>
                                  </div>

    </div>
   </div>


          <!-- Additional Loan -->
         <div class="modal fade" id="modalAdditionalLoan">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-plus-sign"></span> <asp:Label runat="server" ID="lblAddLoanTitle"></asp:Label></h4>
                                              </div>
                                              <div class="modal-body">
                                                   <table class="table table-responsive table-condensed">
                                                      <tr>
                                                          <td>Loan Date</td>
                                                          <td><asp:TextBox runat="server" ID="txtAddLoanDate" CssClass="form-control calendarInput"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                          <td>Amount</td>
                                                          <td><asp:TextBox runat="server" ID="txtAddLoanAmount" CssClass="form-control" TextMode="Number"></asp:TextBox></td>
                                                      </tr>
                                                       <tr>
                                                          <td>Amount + Interest</td>
                                                          <td><asp:TextBox runat="server" ID="txtAddLoanAmountAndInterest" CssClass="form-control" TextMode="Number"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                          <td>Remarks</td>
                                                          <td><asp:TextBox runat="server" ID="txtAddLoanRemarks" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Remarks"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                          <td></td>
                                                          <td>
                                                              <div class="text-right">
                                                          <asp:LinkButton runat="server" ID="lnkAddLoanProcess" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Process Additional Loan" OnClick="lnkAddLoanProcess_Click"><span class="glyphicon glyphicon-saved"></span></asp:LinkButton>
                                                               </div>
                                                              </td>
                                                      </tr>

                                                  </table>
                                              </div>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
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
