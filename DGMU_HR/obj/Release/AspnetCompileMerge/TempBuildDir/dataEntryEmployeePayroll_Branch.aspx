<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryEmployeePayroll_Branch.aspx.cs" Inherits="DGMU_HR.dataEntryEmployeePayroll_Branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

<br /><br />   
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

        <style type="text/css">
            .tbInput {
                width: 100px;
            }

            tr {
                font-size: 12px;
            }

            .sub_label {
                font-size: 12px;
                color: red;
            }
        </style>

  <div class="panel panel-success">
    <div class="panel-heading">
    
                <h5><span class="glyphicon glyphicon-cog"></span> Branch Payslip : <b> <asp:Label runat="server" ID="lblPayrollPeriodText"></asp:Label></b></h5>
   
    </div>
    <div class="panel-body">
    <div class="row">
        <!-- LEFT -->
         
        <div class="col-md-4 col-sm-4">
            <asp:Panel runat="server" ID="panelLeft">
            <ul class="list-group">
             
                 <li class="list-group-item">
                     <asp:Panel runat="server" ID="panelBranchPayroll" Visible="true">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:DropDownList runat="server" id="ddWageArea" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Wage Area" AutoPostBack="true" OnSelectedIndexChanged="ddWageArea_SelectedIndexChanged"> </asp:DropDownList>
                        </div>
                         <div class="col-md-6">
                            <asp:DropDownList runat="server" id="ddBranchList" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Branch" AutoPostBack="true" OnSelectedIndexChanged="ddBranchList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    </asp:Panel>
                    
                </li>

                <li class="list-group-item">
                       <div class="input-group">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                        placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                    </asp:TextBox>
                    <div class="input-group-btn input-group-sm">
                        <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                    </div>
                </div>
                </li>

              
                <li class="list-group-item">
      
    
            <%--Panel to control height--%>
        <asp:Panel runat="server" id="panelEmployeeList" Height="500px" ScrollBars="Vertical">
           
       
       <asp:GridView runat="server" ID="gvEmployeeList" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False" OnRowDataBound="gvEmployeeList_RowDataBound">
    
            <Columns>
           <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
           <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
           <asp:TemplateField ItemStyle-CssClass="text-center">
           <ItemTemplate>
           <asp:LinkButton ID="lnkEmployeeAssign" runat="server" CssClass="btn btn-primary btn-sm" data-toggle="tooltip" data-placement="top" title="Encode Salary" OnClick="lnkEmployeeAssign_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
              
              </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           
        </Columns>
    
    </asp:GridView>
             </asp:Panel>
                </li>
            </ul>
           </asp:Panel>
        </div>
       

        <!--RIGHT -->
        
        <div class="col-md-8 col-sm-8">
            <asp:Panel runat="server" ID="panelRight" ScrollBars="None" Enabled="false">
                <div class="row">
                    <div class="col-md-6">
                        <h4><b><span class="glyphicon glyphicon-user"></span> <asp:Label runat="server" ID="lblEmployeeCodeAndName"></asp:Label></b></h4>
                    </div>
                    <div class="col-md-6 text-right">
                      <%--  <asp:LinkButton runat="server" ID="lnkCancel" CssClass="btn btn-sm btn-danger" OnClick="lnkCancel_Click">Cancel</asp:LinkButton>--%>
                    </div>
                </div>
            
              <div class="row">
                <div class="col-md-4 col-sm-4">
                    <table class="table table-responsive table-hover">
                        <thead>
                            <caption>
                                <b class="text-success">EARNINGS</b>
                                <asp:Label ID="lblBasicRate" runat="server"></asp:Label>
                            </caption>
                        </thead>
                        <tr>
                            <td class="td_label"># Days Worked: </td>
                            <td>
                                
                                <asp:TextBox runat="server" ID="txtDaysWork"  CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox>
                                                              </div>    
                                </td>
                        </tr>
                         <tr>
                            <td># Leave w/Pay: </td>
                            <td><asp:TextBox runat="server" ID="txtLeavePay" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        
                         <tr>
                            <td>Pay-Off: </td>
                            <td><asp:TextBox runat="server" ID="txtPayOff" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        
                         <tr>
                            <td>Regular OT: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtOverTime" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Hour Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblOTTotal"></asp:Label></span>
                               </div> 
                                </td>

                        </tr>

                  <tr>
                            <td>Regular Holiday: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtRegularHoliday" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Day Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblRegularHoliday"></asp:Label></span>
                            </div>
                                </td>
                        </tr>
                   <tr>
                            <td>Regular Holiday (NP): </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtRegularHolidayNP" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Day Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblRegularHolidayNP"></asp:Label></span>
                            </div>
                                </td>
                        </tr>

                       

                         <tr>
                            <td>Reg Holiday OT: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtRegularHolidayOT" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Hour Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblRegularHolidayOT"></asp:Label></span>
                               </div> 
                                </td>

                        </tr>
                        <tr>
                            <td>Spc NW Holiday: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtSpecialHoliday" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Day Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblSpecialHoliday"></asp:Label></span>
                                </div>
                                </td>
                        </tr>

                    <tr>
                            <td>Spc NW Holiday (NP): </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtSpecialHolidayNP" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Day Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblSpecialHolidayNP"></asp:Label></span>
                            </div>
                                </td>
                        </tr>
                         <tr>
                            <td>Spc NW Holiday OT: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtSpecialHolidayOT" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Hour Input"></asp:TextBox>
                                <span class="input-group-addon alert-success"><asp:Label runat="server" ID="lblSpecialHolidayOT"></asp:Label></span>
                               </div> 
                                </td>

                        </tr
                  <tr>

                        </tr>
                            <td>Adjustment: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtAdjustment" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Hour Input"></asp:TextBox>
                                
                               </div> 
                                </td>

                  <tr>
                            <td>Adjustment Taxable: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtAdjustmentWTax" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Hour Input"></asp:TextBox>
                                
                               </div> 
                                </td>

                        </tr>
                       
                        
                    </table>
                </div>

              <div class="col-md-4 col-sm-4">
                    <table class="table table-responsive table-hover">
                        <thead>
                            <caption>
                                <b class="text-danger">DEDUCTIONS</b></caption>
                        </thead>
                        <tr>
                            <td># Absence Day(s): </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtAbsence" CssClass="form-control tbInput" TextMode="Number" Enabled="false" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Day Input"></asp:TextBox>
                                <span class="input-group-addon alert-danger"><asp:Label runat="server" ID="lblAbsence"></asp:Label></span>

                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td>Tardiness: </td>
                            <td><div class="input-group">
                                <asp:TextBox runat="server" ID="txtTardiness" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Minute Input"></asp:TextBox>
                                <span class="input-group-addon alert-danger"><asp:Label runat="server" ID="lblTardiness"></asp:Label></span>
                            </div>
                                </td>
                        </tr>
                        
                        <tr>
                            <td>Undertime: </td>
                            <td>
                                <div class="input-group">
                                <asp:TextBox runat="server" ID="txtUndertime" CssClass="form-control tbInput" TextMode="Number" MaxLength="5" data-toggle="tooltip" data-placement="top" title="Per Minute Input"></asp:TextBox>
                                    <span class="input-group-addon alert-danger"><asp:Label runat="server" ID="lblUndertime"></asp:Label></span>
                                </div>
                                    </td>
                        </tr>
                        <tr>
                            <td>Cash Advance: </td>
                            <td><asp:TextBox runat="server" ID="txtBoardingLodging" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Cash Advance 1: </td>
                            <td><asp:TextBox runat="server" ID="txtCashAdvance" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        
                        
                         <tr>
                            <td>Emergency Loan: </td>
                            <td><asp:TextBox runat="server" ID="txtEmergencyLoan" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox></td>
                        </tr>
                          <tr>
                            <td>Salary Loan: </td>
                            <td>
                                <div class="input-group">
                                <asp:TextBox runat="server" ID="txtSalaryLoan" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox>
                                <span class="input-group-addon alert-warning"><asp:Label runat="server" ID="lblLoanBalance" data-toggle="tooltip" data-placement="top" title="Salary Loan Balance" CssClass="sub_label"></asp:Label></span>
                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td>SSS Loan: </td>
                            <td>
                                <div class="input-group">
                                <asp:TextBox runat="server" ID="txtSSSLoan" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox>
                                <span class="input-group-addon alert-warning"><asp:Label runat="server" ID="lblSSSLoan" data-toggle="tooltip" data-placement="top" title="SSS Loan Balance" CssClass="sub_label"></asp:Label></span>
                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td>Pagibig Loan: </td>
                            <td>
                                <div class="input-group">
                                <asp:TextBox runat="server" ID="txtPagibigLoan" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox>
                                <span class="input-group-addon alert-warning"><asp:Label runat="server" ID="lblPagibigLoan" data-toggle="tooltip" data-placement="top" title="Pagibig Loan Balance" CssClass="sub_label"></asp:Label></span>
                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td>Other Deduction: </td>
                            <td><asp:TextBox runat="server" ID="txtOtherDeduction" CssClass="form-control tbInput" TextMode="Number" MaxLength="5"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>  

              <div class="col-md-4 col-sm-4">
                    <table class="table table-responsive table-hover">
                        <thead>
                            <caption>
                                <b class="text-danger">GOV&#39;T DUES</b></caption>
                        </thead>
                        <tr>
                            <td>SSS: </td>
                            <td class="text-right">
                                <asp:TextBox runat="server" ID="txtSSSDue" CssClass="form-control"></asp:TextBox>
                                <%--<asp:Label runat="server" ID="lblSSS"></asp:Label></td>--%></td>
                        </tr>
                         <tr>
                            <td>Phil Health: </td>
                            <td class="text-right"><asp:TextBox runat="server" ID="txtPhilHealthDue" CssClass="form-control"></asp:TextBox>
                                <%--<asp:Label runat="server" ID="lblPhilHealth" ></asp:Label></td>--%></td>
                        </tr>
                        
                        <tr>
                            <td>Pag-Ibig (HDMF): </td>
                            <td class="text-right"><asp:TextBox runat="server" ID="txtPagibigDue" CssClass="form-control"></asp:TextBox>
                                <%--<asp:Label runat="server" ID="lblPagibig"></asp:Label>--%>
                             
                            </td>
                        </tr>
                        <tr>
                            <td>Pag-Ibig (Add):</td>
                            <td class="text-right"> <asp:TextBox runat="server" ID="txtPagIbigAdditional" CssClass="form-control tbInput" TextMode="Number" MaxLength="5">  </asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>W/Tax: </td>
                            <td class="text-right"><asp:Label runat="server" ID="lblWTax"></asp:Label></td>
                        </tr>
                       
                    </table>
                    

                     <table class="table table-responsive table-hover">
                        <tr>
                            <th class="text-primary"><b>SALARY BREAKDOWN</b></th>
                            <tr>
                                <td>Gross Income: </td>
                                <td class="text-right"><b>
                                    <asp:Label ID="lblTotalGross" runat="server"></asp:Label>
                                    </b></td>
                            </tr>
                            <tr>
                                <td>NonTaxable Adj.: </td>
                                <td class="text-right">
                                    <asp:Label ID="lblNonTaxableAdjustment" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="hidden">
                                <td>Taxable Income: </td>
                                <td class="text-right">
                                    <asp:Label ID="lblTaxableIncome" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Deductions/Gov&#39;t Dues: </td>
                                <td class="text-right"><b>
                                    <asp:Label ID="lblTotalDeduction" runat="server" CssClass="text-danger"></asp:Label>
                                    </b></td>
                            </tr>
                            <tr>
                                <td>Loans : </td>
                                <td class="text-right"><b>
                                    <asp:Label ID="lblTotalLoans" runat="server" CssClass="text-danger"></asp:Label>
                                    </b></td>
                            </tr>
                            <tr>
                                <td><b>NET PAY: </b></td>
                                <td class="text-right">
                                    <h4><b>
                                        <asp:Label ID="lblTotalNetPay" runat="server"></asp:Label>
                                        </b></h4>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkCompute" runat="server" CssClass="btn btn-warning btn-sm" data-placement="top" data-toggle="tooltip" OnClick="lnkCompute_Click" title="Compute Payroll">Compute</asp:LinkButton>
                                </td>
                                <td class="text-right">
                                    <asp:LinkButton ID="lnkProcess" runat="server" CssClass="btn btn-primary btn-sm" data-placement="top" data-toggle="tooltip" OnClick="lnkProcess_Click" title="Process Employee Payroll">Process</asp:LinkButton>
                                </td>
                            </tr>
                        </tr>
                    </table>
                </div>
              
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
</div> <!--END OF DIV CONTAINER-->


</asp:Content>
