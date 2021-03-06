﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DGMU_HR.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .bg_transparent {
            opacity: .6;
        }

        .bg_transparent:hover {
            opacity: 1;

        }

        .tr_size {
            font-size: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <br /><br /><br />
    <asp:UpdatePanel runat="server" ID="uplMain" UpdateMode="Conditional">
    <ContentTemplate>
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
                                   $('[id*=gvEmployeePayrollProcessed] tr').filter(function () {
                                       $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                   });
                               });
                           });

                            //Search function2
                           $(function searchInput2() {
                               $('[id*=txtSearchEmpStat]').on("keyup", function () {
                                   var value = $(this).val().toLowerCase();
                                   $('[id*=gvEmployeeEmploymentStatList] tr').filter(function () {
                                       $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                   });
                               });
                           });

                           //Search function3
                           $(function searchInput3() {
                               $('[id*=txtSearchEmployeeLoan]').on("keyup", function () {
                                   var value = $(this).val().toLowerCase();
                                   $('[id*=gvEmployeeLoanList] tr').filter(function () {
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
                                               $('[id*=gvEmployeePayrollProcessed] tr').filter(function () {
                                                   $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                               });
                                           });
                                       });

                                       //Search function2
                                       $(function searchInput2() {
                                           $('[id*=txtSearchEmpStat]').on("keyup", function () {
                                               var value = $(this).val().toLowerCase();
                                               $('[id*=gvEmployeeEmploymentStatList] tr').filter(function () {
                                                   $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                               });
                                           });
                                       });

                                       //Search function3
                                       $(function searchInput3() {
                                           $('[id*=txtSearchEmployeeLoan]').on("keyup", function () {
                                               var value = $(this).val().toLowerCase();
                                               $('[id*=gvEmployeeLoanList] tr').filter(function () {
                                                   $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                               });
                                           });
                                       });
                                   }
                               });
                           };
                       </script>    


           <div class="row small">
        <div class="hidden">
              
               <div class="panel panel-primary">
                <div class  ="panel-heading">
                   DGMU - Human Resources Management System
                </div>


                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-info">
                             <asp:UpdatePanel runat="server" ID="upDateTime" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
                            <span class="glyphicon glyphicon-time"></span>
                            <asp:Label runat="server" ID="lblDateTime"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                        </Triggers>
                    </asp:UpdatePanel>
                        </li>
                        <li class="list-group-item"></li>
                        <li class="list-group-item"><span class="glyphicon glyphicon-user text-success"></span> <asp:Label runat="server" ID="lblUser"></asp:Label></li>
                        <li class="list-group-item"><span class="glyphicon glyphicon-comment text-success"></span> Messages</li>
                        <li class="list-group-item"></li>
                        <li class="list-group-item"><span class="glyphicon glyphicon-eject text-danger"></span> <asp:LinkButton runat="server" ID="lblLogOut" OnClick="lblLogOut_Click"> Log-Out</asp:LinkButton></li>
                    </ul>
                </div>

                <div class="panel-footer">
                   <i class="text-muted small" style="font-size: 10px;"> Developed by: Russel Vasquez </i>
                </div>
            </div>
           
        </div>


        <div class="col-lg-9 col-md-9 col-sm-3">
            <div class="row">
                <div class="col-md-3">
                    <div class="panel panel-success">

                        <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> Manage Employee <asp:Label runat="server" ID="lblDefaultYear"></asp:Label></div>
                        <div class="panel-body bg-info">

                            <asp:HyperLink runat="server" ID="hlnkPeople" CssClass="text-muted" NavigateUrl="~/EmpData.aspx">
                                <h3>
                                    <asp:Image runat="server" ID="image1" src="images/dbh_employment.png" Width="64px" height="64px"/> Employee</h3>
                            </asp:HyperLink>

                        </div>
                        <div class="panel-footer">
                            
                                <asp:GridView runat="server" ID="gvEmployeeEmploymentStat" CssClass="table table-responsive table-hover table-condensed hidden" AutoGenerateColumns="false" ShowHeader="false" GridLines="None">
                                        <Columns>
                                           <%-- <asp:BoundField DataField="StatusCode" />--%>
                                            <asp:BoundField DataField="Status" />
                                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkEmpStat" Text='<%# Eval("CountStatus") %>' CssClass="badge bg-danger" OnClick="lnkEmpStat_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                            
                            <asp:LinkButton runat="server" ID="lnkNoGovtID" CssClass="btn btn-sm btn-danger" OnClick="lnkNoGovtID_Click">Employee List with NO Gov't ID</asp:LinkButton>
                        </div>
                    </div>

                    <div class="panel panel-danger">
                        <div class="panel-heading">Upcoming EOS List for this Month</div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="gvEOSList" CssClass="table table-responsive table-bordered" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="EmployeeName"  />
                                    <asp:BoundField DataField="EOs_Effective_Date" DataFormatString="{0:d}" HeaderText="Effectivity" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                   
                </div>
               

                 <div class="col-md-3">
                      <div class="panel panel-success">
                        <div class="panel-heading"><span class="glyphicon glyphicon-star"></span> <asp:Label runat="server" ID="lblPayrollPeriodText"></asp:Label></div>
                        <div class="panel-body bg-info">

                            <asp:HyperLink runat="server" ID="hlPayroll" CssClass="text-muted" NavigateUrl="~/dataEntryEmployeePayroll.aspx">
                                <h3>
                                    <asp:Image runat="server" ID="image2" src="images/dbh_payroll.png" /> Payroll</h3>
                            </asp:HyperLink>
                        

                          

                        </div>
                       
                        <div class="panel-footer">
                            <ul class="list-group small">
                                <li class="list-group-item">
                                    <i> # of payroll processed: </i> <asp:LinkButton runat="server" ID="lnkProcessPayrollStat" CssClass="badge bg-danger" OnClick="lnkProcessPayrollStat_Click1"></asp:LinkButton>
                                </li>
                            </ul>
                             
                               <asp:LinkButton runat="server" ID="lnkManual13thMonth" CssClass="btn btn-sm btn-success" OnClick="lnkManual13thMonth_Click">Manual 13th Month Entry</asp:LinkButton>
                             
                        </div>
                    </div>

                   
                    
                </div>

                  <div class="col-md-3">
                       <div class="panel panel-success">
                        <div class="panel-heading"><span class="glyphicon glyphicon-fire"></span> <asp:Label runat="server" ID="lblActiveLoansCount"></asp:Label></div>
                        <div class="panel-body bg-info">

                            <asp:HyperLink runat="server" ID="hlLoans" CssClass="text-muted" NavigateUrl="~/dataEntryEmployeeLoan.aspx">
                                <h3>
                                    <asp:Image runat="server" ID="image3" src="images/dbh_loan.png" />Loans</h3>
                            </asp:HyperLink>

                        </div>
                        <div class="panel-footer">
                                 <asp:GridView runat="server" ID="gvEmployeeLoanStat" CssClass="table table-responsive table-hover table-condensed" AutoGenerateColumns="false" ShowHeader="false" GridLines="None">
                                        <Columns>
                                           <%-- <asp:BoundField DataField="StatusCode" />--%>
                                            <asp:BoundField DataField="LoanName" />
                                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkEmpLoanList" Text='<%# Eval("EmpLoanStatCount") %>' CssClass="badge bg-danger" OnClick="lnkEmpLoanList_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>

                        </div>
                    </div>
                  </div>

                  <div class="col-md-3">
                      <div class="panel panel-success">
                        <div class="panel-heading"><span class="glyphicon glyphicon-plane"></span> Upcoming Employee Leaves: <b><asp:Label runat="server" ID="lblUpcomingLeaveCount"></asp:Label></b></div>
                        <div class="panel-body bg-info">

                            <asp:HyperLink runat="server" ID="hlLeaves" CssClass="text-muted" NavigateUrl="~/dataEntryEmployeeLeave.aspx">
                                <h3>
                                    <asp:Image runat="server" ID="image4" src="images/dbh_leaves.png" /> Leaves</h3>
                            </asp:HyperLink>

                        </div>
                        <div class="panel-footer">
                             <%--<div class="text-center text-muted"><i>Upcoming Leaves</i>
                                 <br />

                             </div>--%>
                            <asp:Panel runat="server" ID="panelUpcomingLeaves" Height="200px" ScrollBars="Vertical">
                            <asp:GridView runat="server" ID="gvUpcomingLeaves" CssClass="table table-responsive table-condensed small" GridLines="None" AutoGenerateColumns="false" ShowHeader="true">
                                <Columns>
                                    <asp:BoundField DataField="DateFrom" DataFormatString="{0:d}" HeaderText="From" />
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee" /> 
                                    <%--<asp:BoundField DataField="LeaveTypeCode" HeaderText="Leave" />--%>
                                    
                                    <asp:BoundField DataField="DaysCount" HeaderText="Days" />
                                </Columns>
                            </asp:GridView>
                            </asp:Panel>

                           
                        </div>
                    </div>
                   
                
                        </div>
            </div>
        </div>

          <div class="col-lg-3 col-md-3 col-sm-3">
          <asp:Panel runat="server" ID="panelBdayCorner" Height="768px" ScrollBars="Vertical">

          <div class="panel panel-primary">
                <div class="panel-heading">
                <span class="glyphicon glyphicon-star">  </span> <asp:Label runat="server" ID="lblBirthdayMonth"></asp:Label>
                </div>
                <div class="panel-body">
                   <asp:GridView ID="gvBirthdayList" runat="server" CssClass="table table-responsive table-condensed table-hover" AutoGenerateColumns="false">
                       <Columns>
                           <asp:BoundField DataField="Date_of_Birth" HeaderText="Date" DataFormatString="{0:d}" ItemStyle-Font-Size= "10px" />
                           <asp:BoundField DataField="EmployeeName" HeaderText="Employee" ItemStyle-Font-Size= "10px" />
                           <asp:BoundField DataField="Position" HeaderText="Position" ItemStyle-Font-Size= "10px" />
                       </Columns>
                   </asp:GridView>
                </div>

              
            </div>
          </asp:Panel>
           
        </div>
    </div>
   

         

        <div class="modal fade" id="modalShowProcessPayroll">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-ok"></span> Employee Payroll Processed</h4>
                                              </div>
                                              <asp:Panel runat="server" ID="panelLeaveHistory" Height="500" ScrollBars="Vertical">
                                              <div class="modal-body">
                                                  <div class="input-group">
                                                      <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                                                          placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                                                      </asp:TextBox>
                                                      <div class="input-group-btn input-group-sm">
                                                          <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                                      </div>
                                                  </div>
                                                  <br />
                                                     <asp:GridView runat="server" ID="gvEmployeePayrollProcessed" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                       <Columns>
                                                           <asp:BoundField DataField="EmployeeID" />
                                                           <asp:BoundField DataField="EmployeeFullName" />

                                                       </Columns>
                                                   </asp:GridView>
                                              </div>
                                              </asp:Panel>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
                                      </div>
                                  </div>

        <!-- Employee Employment List Status -->
         <div class="modal fade" id="modalShowEmploymentStat">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-user"></span><asp:Label runat="server" ID="lblEmployeeStatusName"></asp:Label></h4>
                                              </div>
                                              <asp:Panel runat="server" ID="panel1" Height="500" ScrollBars="Vertical">
                                              <div class="modal-body">
                                                  <div class="input-group">
                                                      <asp:TextBox ID="txtSearchEmpStat" runat="server" CssClass="form-control text-uppercase"
                                                          placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                                                      </asp:TextBox>
                                                      <div class="input-group-btn input-group-sm">
                                                          <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                                      </div>
                                                  </div>
                                                  <br />
                                                     <asp:GridView runat="server" ID="gvEmployeeEmploymentStatList" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                       <Columns>
                                                           <asp:BoundField DataField="EmployeeID" />
                                                           <asp:BoundField DataField="EmployeeName" />
                                                           <asp:BoundField DataField="Date_Hired" DataFormatString="{0:d}" />
                                                           <asp:BoundField DataField="CompanyName" />
                                                       </Columns>
                                                   </asp:GridView>
                                              </div>
                                              </asp:Panel>
                                              <div class="modal-footer">

                                              </div>
                                          </div>
                                      </div>
                                  </div>

         <!-- Employee Employment List Status -->
          <div class="modal fade" id="modalShowEmployeeLoanStat">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-warning">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title"><span class="glyphicon glyphicon-eject"></span><asp:Label runat="server" ID="lblActiveLoanName"></asp:Label></h4>
                                              </div>
                                              <asp:Panel runat="server" ID="panel2" Height="500" ScrollBars="Vertical">
                                              <div class="modal-body">
                                                  <div class="input-group">
                                                      <asp:TextBox ID="txtSearchEmployeeLoan" runat="server" CssClass="form-control text-uppercase"
                                                          placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                                                      </asp:TextBox>
                                                      <div class="input-group-btn input-group-sm">
                                                          <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                                      </div>
                                                  </div>
                                                  <br />
                                                     <asp:GridView runat="server" ID="gvEmployeeLoanList" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                       <Columns>
                                                           <asp:BoundField DataField="EmployeeID" />
                                                           <asp:BoundField DataField="EmployeeName" />
                                                       </Columns>
                                                   </asp:GridView>
                                              </div>
                                              </asp:Panel>
                                              <div class="modal-footer">

                                              </div>
                                          </div>
                                      </div>
                                  </div>
        
         </ContentTemplate>
        </asp:UpdatePanel>
    
</asp:Content>
