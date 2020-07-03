<%@ Page Title="" Language="C#" MasterPageFile="~/HRMS.Master"  AutoEventWireup="true" CodeBehind="data13thMonthManualEntry.aspx.cs" Inherits="DGMU_HR.data13thMonthManualEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
<style type="text/css">
 #overlay{
 position: fixed;
 z-index: 99;
 top: 0px;
 left: 0px;
 background-color: black;
 width: 100%;
 height: 100%;
 filter: Alpha(Opacity=80);
 opacity: 0.80;
-moz-opacity: 0.80;
}

#theProgress{
 /*width: 110px;
 height: 24px;*/
 text-align: center;
 filter: Alpha(Opacity=100);
 opacity: 1;
 -moz-opacity: 1;
}

#modalProgress{
 position: absolute;
 /*top: 50%;*/
 left: 50%;
 /*width: 50%;*/
 display: block;
 margin-left: auto;
 margin-right:auto;
 /*margin: -11px 0 0 -55px;*/
 color: white;
}

body>modalProgress {
position: fixed;
}
</style>

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
 
                <h5><span class="glyphicon glyphicon-cog"></span> Manual 13th Month Entry | Year: <asp:Label runat="server" ID="lblFY"></asp:Label></h5>
                <asp:LinkButton runat="server" ID="lnkRefresh" CssClass="btn btn-sm btn-success" OnClick="lnkRefresh_Click">Refresh Data</asp:LinkButton>
    </div>
    <div class="panel-body">
    
      
        <div class="row">
        <!-- LEFT -->
       <!-- Search Area -->
         <div class="col-md-3">
             <div class="input-group">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                        placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                    </asp:TextBox>
                    <div class="input-group-btn input-group-sm">
                        <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                    </div>
             </div>
         </div>
        <div class="col-md-3 col-md-offset-6 text-right">
            <asp:LinkButton runat="server" ID="lnkSave" CssClass="btn btn-primary" OnClick="lnkSave_Click"><span class="glyphicon glyphicon-saved"></span> Save All</asp:LinkButton>
        </div>
        <div class="col-md-12">
             
         <hr />
            <asp:Panel runat="server" ID="panelEmployeeList" Height="550px" ScrollBars="Vertical">
                <asp:GridView runat="server" ID="gvEmployeeList"
                    CssClass="table table-responsive table-hover table-condensed table-bordered" AutoGenerateColumns="False" OnRowCommand="gvEmployeeList_RowCommand" 
                    OnRowDataBound="gvEmployeeList_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="Code" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                        <asp:BoundField DataField="Date_Hired" HeaderText ="Date Hired" DataFormatString="{0:d}" />
                       
                         <asp:TemplateField ItemStyle-CssClass="text-center" HeaderText="Total Working Days" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddTotalWorksInYear" CssClass="dropdown form-control">
                                    <%--AppendDataBoundItems="true" DataSourceID="datasource"  DataTextField="key" DataValueField="data" AutoPostBack="True" SelectedValue='<%# Eval("Prioridade") %>'--%>
                                     <asp:ListItem Text="312" Value="312"></asp:ListItem>
                                     <asp:ListItem Text="261" Value="261"></asp:ListItem>
                                    <asp:ListItem Text="156" Value="156"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderText="Basic Monthly Rate" ControlStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtTotalYearBasicPay" Text='<%# Eval("TotalMonthBasicPay") %>' CssClass="form-control text-center" TextMode="Number"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                         <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderText="Total # of Days Absent" ControlStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtTotalAbsences" Text='<%# Eval("TotalAbsences") %>' CssClass="form-control text-center" TextMode="Number"></asp:TextBox>
                            </ItemTemplate> 
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <%----%>
                        <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderText="13th Month Pay" ControlStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblComputed13thMonth" Text='<%# string.Format("{0:n}", Eval("Computed13thMonth"))%>' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Computed13thMonth" HeaderText ="Computed Amount"/>--%>
                   
                        <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderText="Control" ControlStyle-CssClass="text-center">
                            <ItemTemplate>
                               <asp:LinkButton runat="server" ID="lnkProcessIndividual" CssClass="btn btn-primary" CommandName="SAVE"><span class="glyphicon glyphicon-floppy-save"></span> Save</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderText="Control" ControlStyle-CssClass="text-center">
                            <ItemTemplate>
                               <asp:LinkButton runat="server" ID="lnkRemove13thMonth" CssClass="btn btn-sm btn-danger" CommandName="REMOVE"><span class="glyphicon glyphicon-remove"></span> Remove</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                             
                        
                    </Columns>

                </asp:GridView>
            </asp:Panel>
        </div>
     
       
    </div>


    <!-- Display Modal Input Here -->
   

    </div>
   </div>


     

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
               

    </ContentTemplate>
</asp:UpdatePanel>
</div><!-- END OF DIV CONTAINER-->

        <asp:UpdateProgress id="upgLoading" runat="server" AssociatedUpdatePanelID="uplMain">
                    <ProgressTemplate>
                        <div id="overlay">
                            <div id="modalProgress">
                                <div id="theProgress">
                                    <img src="images/updating1.gif" alt="Updating..." />
                                </div>
                            </div>
                        </div>
                        
                    </ProgressTemplate>
                </asp:UpdateProgress>

</asp:Content>
