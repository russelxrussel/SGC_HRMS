<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master" AutoEventWireup="true" CodeBehind="repRemittances.aspx.cs" Inherits="DGMU_HR.repRemittances" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <br /><br /><br />
  <%--    <div class="row"><!--Main Row -->
        
        <div class="col-md-3">
         <div class="input-group input-group-sm">
                    <span class="input-group-addon alert-danger">Partner</span>
                    <asp:DropDownList runat="server" ID="ddPartnerList" CssClass="form-control"></asp:DropDownList>
                </div>
        </div>
        <div class="col-md-3">
                <!-- Start Date-->
                <div class="input-group input-group-sm">
                    <span class="input-group-addon alert-danger"><span class="glyphicon glyphicon-calendar">
                    </span>FROM</span>
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="calendarInput form-control"
                        placeholder="Start Date"></asp:TextBox>
                </div>
        </div>
        <div class="col-md-3">
                <!-- End Date-->
                <div class="input-group input-group-sm">
                    <span class="input-group-addon alert-danger"><span class="glyphicon glyphicon-calendar">
                    </span>TO</span>
                    <asp:TextBox runat="server" ID="txtEndDate" CssClass="calendarInput form-control"
                        placeholder="End Date"></asp:TextBox>
                </div>
       </div>
        
                
        <div class="col-md-3">
                <asp:LinkButton runat="server" ID="U_Print" CssClass="btn btn-success btn-sm" 
                        ><span class="glyphicon glyphicon-print"></span> PREVIEW</asp:LinkButton>
        </div>        
                
        
   </div>
 <hr />--%>

    <asp:UpdatePanel runat="server" ID="upSub">
        <ContentTemplate>

   
     <div class="row">
     
     <div class="col-md-3">
             <ul class="list-group">
                 <li class="list-group-item">
                     <div class="input-group input-group-sm">
                         <span class="input-group-addon alert-danger">Month</span>
                         <asp:TextBox ID="txtMonth" runat="server" TextMode="Month" CssClass="form-control"></asp:TextBox>
                     </div>

                 </li>
                 <li class="list-group-item">
                       <div class="input-group input-group-sm">
                         <span class="input-group-addon alert-danger">Remittance Type</span>
                         <asp:DropDownList runat="server" ID="ddRemittanceList" CssClass="form-control"></asp:DropDownList>
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
