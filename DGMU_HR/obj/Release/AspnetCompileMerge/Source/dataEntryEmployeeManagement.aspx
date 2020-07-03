<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/HRMS.Master" CodeBehind="dataEntryEmployeeManagement.aspx.cs" Inherits="DGMU_HR.dataEntryEmployeeManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
 

<br /><br /><br />

        <div>
               <asp:UpdatePanel runat="server" ID="upListEmployee" UpdateMode="Conditional">
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

             

                        <asp:Panel runat="server" Visible="true" ID="panel_ListOfEmployee">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">

                                        <div class="col-md-3">
                                            <h4><b><span class="glyphicon glyphicon-cog"></span> Employee Management</b></h4>
                                        </div>
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-4 text-right">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                                                    placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                                                </asp:TextBox>
                                                <div class="input-group-btn input-group-sm">
                                                    <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <div class="panel-body">
                                 
                                       <asp:Panel runat="server" ID="panelListEmployee" Height="800px" ScrollBars="Vertical">
                                    <asp:GridView runat="server" ID="gvEmployeeList" GridLines="None" OnRowCommand="gvEmployeeList_RowCommand" AutoGenerateColumns="false" CssClass="table table-hover table-condensed table-responsive small" OnRowDataBound="gvEmployeeList_RowDataBound" ShowHeader="true">
                                        <Columns>
                                            <%--<asp:TemplateField ItemStyle-Width="60px" ControlStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:Image runat="server" ID="imgEmployee" Width="50px" Height="50px" CssClass="img-rounded img-responsive" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="EmployeeID" ReadOnly="true" />
                                            <asp:BoundField DataField="EmployeeName" />
                                            <asp:BoundField DataField="GenderDescription" />
                                            <asp:BoundField DataField="MaritalStatus" />
                                            <asp:BoundField DataField="Date_Hired" DataFormatString="{0:MM/d/yyyy}" HtmlEncode="false" HeaderText="Date Hired" />
                                            <asp:BoundField DataField="PayrollGroupName" HeaderText="Payroll Group" />
                                          
                                            <asp:BoundField DataField="Department" />
                                            <asp:BoundField DataField="Status" />

                                         
                                            <asp:TemplateField ItemStyle-Width="50px" ControlStyle-Width="40px" ItemStyle-CssClass="text-right">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkPayrollSetup" CommandName="PayrollSetup" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Payroll Setup"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-Width="50px" ControlStyle-Width="40px" ItemStyle-CssClass="text-right">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkPayrollHistory" CommandName="PayrollHistory" CssClass="btn btn-warning" data-toggle="tooltip" data-placement="top" title="Payroll History"><span class="glyphicon glyphicon-list-alt"></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </asp:Panel>

                                </div>
                            </div>

                        </asp:Panel>

               </div>

              <div class="modal fade" id="modalPayrollSetup" data-backdrop="static" data-keyboard="false">
              
              <div class="modal-dialog">
             <div class="modal-content">
                 <div class="modal-header bg-info">
                     <button class="close" data-dismiss="modal">
                         &times;</button>
                     <h4 class="modal-title">
                         DGMU Payroll System</h4>
                 </div>
                 <div class="modal-body">
                  <div class="row">
                      <div class="col-md-3">
                          <asp:Image runat="server" ID="imgEmployeePicture" Width="120px" Height="120px" CssClass="img-thumbnail img-responsive" />
                      </div>
                      <div class="col-md-9">
                          <ul class="list-group-item">
                              <li class="list-group-item"><strong><span class="glyphicon glyphicon-credit-card text-danger"></span> <asp:Label runat="server" ID="lblEmpCode"></asp:Label></strong></li>
                              <li class="list-group-item"><span class="glyphicon glyphicon-user text-success"></span> <asp:Label runat="server" ID="lblEmpName"></asp:Label></li>
                          </ul>
                      </div>
                      <div class="col-md-12">
                          <asp:UpdatePanel runat="server" ID="up1">
                              <ContentTemplate>

                                  <ul class="list-group">

                                      <li class="list-group-item">
                                          <div class="input-group">
                                              <span class="input-group-addon">Payroll Group:</span>
                                              <asp:DropDownList runat="server" ID="ddPayrollGroup" CssClass="dropdown form-control" AutoPostBack="true" OnSelectedIndexChanged="ddPayrollGroup_SelectedIndexChanged"></asp:DropDownList>
                                          </div>
                                      </li>
                                      <asp:Panel runat="server" ID="panelBranch">
                                      <li class="list-group-item">
                                          <div class="input-group">
                                              <span class="input-group-addon" id="basic-addon1">Branch Assign:</span>
                                              <asp:DropDownList runat="server" ID="ddBranchList" CssClass="dropdown form-control" AutoPostBack="true" OnSelectedIndexChanged="ddBranchList_SelectedIndexChanged"></asp:DropDownList>
                                              <%--<asp:CheckBox runat="server" ID="chkIsSupervisor" Checked="false" Text="Supervisor ?" />--%>
                                              <asp:CheckBox runat="server" ID="chkIsSenior" Checked="false" Text="Senior Litsonero ?" />
                                              <asp:CheckBox runat="server" ID="chkIsBranchWife" Checked="false" Text="Branch Wife ?" />
                                          </div>
                                      </li>
                                      </asp:Panel>

                                      <li class="list-group-item">
                                          <div class="input-group">
                                              <span class="input-group-addon">Basic Rate PD</span>
                                              <asp:TextBox runat="server" ID="txtBasicRatePerDay" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                          </div>
                                      </li>

                                      <li class="list-group-item">
                                          <div class="input-group">
                                              <span class="input-group-addon">Actual Rate PD</span>
                                              <asp:TextBox runat="server" ID="txtActualRatePerDay" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                          </div>
                                      </li>

                                      <li class="list-group-item">
                                          <asp:CheckBox runat="server" ID="chkDebitMemo" Checked="false" Text="Debit Memo Salary ?" />
                                          <asp:CheckBox runat="server" ID="chkManualSalary" Checked="false" Text="Manual Salary ?" />
                                      </li>

                                      <li class="list-group-item">
                                          <asp:LinkButton runat="server" ID="lnkUpdate" CssClass="btn btn-primary" OnClick="lnkUpdate_Click"><span class="glyphicon glyphicon-floppy-save"></span> Update</asp:LinkButton>
                                      </li>
                                  </ul>



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
                                                  <h4 class="modal-title">DGMU Enterprises System</h4>
                                              </div>
                                              <div class="modal-body">
                                                  <h4 class="text-danger">
                                                      <span class="glyphicon glyphicon-remove"></span>&nbsp;
                                            <asp:Label runat="server" ID="lblErrorMessage"></asp:Label></h4>
                                              </div>
                                              <div class="modal-footer">
                                              </div>
                                          </div>
                                      </div>
                                  </div>
                              </ContentTemplate>
                          </asp:UpdatePanel>

                      </div>
                  </div>

                 </div>
                 <div class="modal-footer">
                 </div>
             </div>
         </div>
     </div> 

   
                       

               </ContentTemplate>
                </asp:UpdatePanel>
      
    </div>

      </asp:Content>