<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="dataEntryBranchIncentives.aspx.cs" Inherits="DGMU_HR.dataEntryBranchIncentives" %>
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
                                   $('[id*=gvBranchEmployeeList] tr').filter(function () {
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
                                               $('[id*=gvBranchEmployeeList] tr').filter(function () {
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
 
                <h5><span class="glyphicon glyphicon-cog"></span> Branch Incentives </h5>
   
    </div>
    <div class="panel-body">
    <div class="row">
        <!-- LEFT -->
        <div class="col-md-8">
            <ul class="list-group">
               
                 <li class="list-group-item">
                    <div class="row">
                        <div class="col-md-4">
                          <%--  <asp:DropDownList runat="server" id="ddMonthList" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Month" AutoPostBack="true"> </asp:DropDownList>--%>
                              <asp:TextBox runat="server" ID="txtMonth" TextMode="Month" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="col-md-4">
                             <asp:DropDownList runat="server" id="ddWageArea" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Wage Area" AutoPostBack="true" OnSelectedIndexChanged="ddWageArea_SelectedIndexChanged"> </asp:DropDownList>
                        </div>

                         <div class="col-md-4">
                            <asp:DropDownList runat="server" id="ddBranchList" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Select Branch" AutoPostBack="true" OnSelectedIndexChanged="ddBranchList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                      
                          
               
                </li>

                <li class="list-group-item">
                    <div class="row">
                       

                         <div class="col-md-4">
                              <asp:TextBox runat="server" ID="txtBranchMonthlySales" TextMode="Number" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Branch Sales"></asp:TextBox>
                            
                          </div>
                         <div class="col-md-4">
                         <asp:LinkButton runat="server" ID="lnkClearIncentiveZero" CssClass="btn btn-sm btn-danger" OnClick="lnkClearIncentiveZero_Click">Refresh</asp:LinkButton> Total Incentive Amount:  <h4><b><asp:Label runat="server" ID="lblTotalIncentives" CssClass="text-danger"></asp:Label></b></h4>
                         </div>
                        <div class="col-md-4 text-right">
                             <asp:LinkButton runat="server" ID="lnkCompute" CssClass="btn btn-sm btn-warning" OnClick="lnkCompute_Click" data-toggle="tooltip" data-placement="top" title="Compute Incentive Amount to be Share"><span class="glyphicon glyphicon-th"></span></asp:LinkButton>
                        </div>
                      
                    </div>
                      
                </li>
               
              
                <li class="list-group-item">
                 <asp:Panel runat="server" ID="panelEmployeeList">

                     <asp:GridView runat="server" ID="gvLinkBranchEmployeeAssigned"
                         CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False" OnRowDataBound="gvLinkBranchEmployeeAssigned_RowDataBound">

                         <Columns>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <asp:Image runat="server" ID="imgSenior" ImageUrl="~/images/senior.png" visible="false"/>
                                    <asp:Image runat="server" ID="imgEmpTransfer" ImageUrl="~/images/transfer.png" visible="false"/>
                                    <asp:LinkButton runat="server" ID="lnkRemove" CssClass="btn btn-sm btn-danger" Visible="false" OnClick="lnkRemoveEmployeeTransfer_Click"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
                             <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                               <asp:TemplateField HeaderText="Income">
                                 <ItemTemplate>
                                    
                                  
                                      <asp:Label runat="server" ID="lblGrossIncome"></asp:Label>
                                    
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                            <%-- <asp:TemplateField HeaderText="Quota">
                                 <ItemTemplate>
                                     <asp:TextBox runat="server" ID="txtQuota" TextMode="Number" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Quota" MaxLength="5"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>--%>
                             
                             <asp:TemplateField HeaderText="Days Present">
                                 <ItemTemplate>
                                    
                                     <asp:TextBox runat="server" ID="txtDaysPresent" TextMode="Number" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Days Present" MaxLength="5"></asp:TextBox>
                                     <asp:Label runat="server" ID="lblIncentiveCount" Visible="false"></asp:Label>
                                    
                                 </ItemTemplate>
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText="Incentive %">
                                 <ItemTemplate>
                                     <asp:TextBox runat="server" ID="txtIncentivePercentage" TextMode="Number" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Incentives Percentage" MaxLength="5"></asp:TextBox>
                                     
                                 </ItemTemplate>
                             </asp:TemplateField>


                             <asp:TemplateField ItemStyle-CssClass="text-center" HeaderText="Incentive Amount">
                                 <ItemTemplate>
                                  <asp:Label runat="server" ID="lblIncentiveAmount" CssClass="text-danger"></asp:Label>
                                 
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                             </asp:TemplateField>
                             <asp:TemplateField ItemStyle-CssClass="text-center" HeaderText="Less Amount">
                                 <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLessHolidayAmount" CssClass="text-danger"></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                             </asp:TemplateField>

                              <asp:TemplateField ItemStyle-CssClass="text-center" HeaderText="Total">
                                 <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTotalIncomeAndIncentives"></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                             </asp:TemplateField>

                         </Columns>

                     </asp:GridView>

                       <%--<asp:LinkButton runat="server" ID="lnkSetBranch" CssClass="btn btn-sm btn-primary" OnClick="lnkSetBranch_Click"><span class="glyphicon glyphicon-pushpin"></span> SET</asp:LinkButton>--%>
                    <div class="text-right">
                     <asp:LinkButton runat="server" ID="lnkComputeEmployeeIncentive" CssClass="btn btn-sm btn-warning" OnClick="lnkComputeEmployeeIncentive_Click"><span class="glyphicon glyphicon-th"></span> Compute Incentives</asp:LinkButton>
                    <hr />
                        <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" Rows="3" TextMode="MultiLine" placeholder="Remarks"></asp:TextBox>
                        <br />
                        <asp:LinkButton runat="server" ID="lnkProcessSave" CssClass="btn btn-sm btn-success" OnClick="lnkProcessSave_Click" Enabled="false"><span class="glyphicon glyphicon-floppy-disk"></span> Process and Save</asp:LinkButton>
                    </div>
                </asp:Panel>

                    
                   
                </li>
            </ul>
          
        </div>

        <!--RIGHT -->
        <div class="col-md-4">
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
            <asp:GridView runat="server" ID="gvBranchEmployeeList" 
            CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False">
    
        <Columns>
           <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
           <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
            <asp:BoundField DataField="Date_Hired"  DataFormatString="{0:d}" HeaderText="Date Hired" />
            <asp:TemplateField ItemStyle-CssClass="text-center">
            <ItemTemplate>
            <asp:LinkButton ID="lnkEmployeeTransfer" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkEmployeeTransfer_Click"><span class="glyphicon glyphicon-transfer"></span> Transfer</asp:LinkButton>
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
