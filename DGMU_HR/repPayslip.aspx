<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master" AutoEventWireup="true" CodeBehind="repPayslip.aspx.cs" Inherits="DGMU_HR.repPayslip" %>

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
                         <span class="input-group-addon alert-danger">Period</span>
                         <asp:DropDownList runat="server" ID="ddPP" CssClass="form-control"></asp:DropDownList>
                     </div>

                 </li>
                 <li class="list-group-item">
                       <div class="input-group input-group-sm">
                         <span class="input-group-addon alert-danger">Payroll Group</span>
                         <asp:DropDownList runat="server" ID="ddPayrollGroup" CssClass="form-control"></asp:DropDownList>
                     </div>

                 </li>

                 <li class="list-group-item">
                     <asp:LinkButton runat="server" ID="lnkView" CssClass="btn btn-sm btn-primary" OnClick="lnkView_Click"><span class="glyphicon glyphicon-file"></span> View</asp:LinkButton>
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
            HasToggleParameterPanelButton="False" GroupTreeStyle-CssClass="bg-success" />
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
                                        DGMU Enterprises</h4>
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
