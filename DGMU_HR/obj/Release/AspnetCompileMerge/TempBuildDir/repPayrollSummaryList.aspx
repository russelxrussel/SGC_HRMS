﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master" AutoEventWireup="true" CodeBehind="repPayrollSummaryList.aspx.cs" Inherits="DGMU_HR.repPayrollSummaryList" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <br /><br /><br />
 

    <asp:UpdatePanel runat="server" ID="upSub">
        <ContentTemplate>

   
     <div class="row">
     
     <div class="col-md-3">
             <ul class="list-group">
                 <li class="list-group-item">
                     <div class="input-group input-group-sm">
                         <span class="input-group-addon alert-danger">Payroll Period</span>
                        <asp:DropDownList runat="server" ID="ddPayrollPeriodList" CssClass="form-control"></asp:DropDownList>
                     </div>

                 </li>
                  <li class="list-group-item">
                      <div class="input-group input-group-sm">
                         <span class="input-group-addon alert-danger">Payroll Period</span>
                        <asp:DropDownList runat="server" ID="ddPayrollGroup" CssClass="form-control">
                            <asp:ListItem>--ALL--</asp:ListItem>
                            <asp:ListItem>Inhouse Payroll Group</asp:ListItem>
                            <asp:ListItem>Branch Payroll Group</asp:ListItem>
                        </asp:DropDownList>
                     </div>
                 </li>
                <%-- <li class="list-group-item">
                       <div class="input-group input-group-sm">
                           <asp:RadioButton runat="server" ID="optWithATM" Text="With ATM" GroupName="optSalaryType" />
                        
                     </div>

                 </li>
                
                 <li class="list-group-item">
                      <asp:RadioButton runat="server" ID="optNonATM" Text="Debit Memo / Manual Salary?" GroupName="optSalaryType" /> 
                 </li>--%>

                 <li class="list-group-item text-right">
                     <asp:LinkButton runat="server" ID="lnkView" CssClass="btn btn-sm btn-primary" OnClick="lnkView_Click"><span class="glyphicon glyphicon-print"></span> View</asp:LinkButton>
                 </li>
             </ul>
         </div>
     <div class="col-md-9">
     <asp:Panel runat="server" ID="panelReport" Height="800px" ScrollBars="Vertical">
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="True" 
            HasCrystalLogo="False" ToolPanelView="GroupTree" 
            EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" 
            HasToggleParameterPanelButton="False" GroupTreeStyle-CssClass="bg-success"/>
       </asp:Panel>
      </div>

    
    </div>
   
   <!--Message Error -->
                    <div class="modal fade" id="msgErrorModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header bg-danger">
                                    <button class="close" data-dismiss="modal">
                                        &times;</button>
                                    <h4 class="modal-title">
                                        HRMS</h4>
                                </div>
                                <div class="modal-body">
                                    <h4>
                                        <span class="glyphicon glyphicon-alert"></span>&nbsp;
                                        <asp:Label runat="server" ID="lblErrorPrompt"></asp:Label></h4>
                                </div>
                                <div class="modal-footer">
                                </div>
                            </div>
                        </div>
                    </div>

                 </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
