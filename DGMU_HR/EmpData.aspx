<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/HRMS.Master"  CodeBehind="EmpData.aspx.cs" Inherits="DGMU_HR.EmpData" %>

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
 width: 110px;
 height: 24px;
 text-align: center;
 filter: Alpha(Opacity=100);
 opacity: 1;
 -moz-opacity: 1;
}

#modalProgress{
 position: absolute;
 top: 50%;
 left: 50%;
 margin: -11px 0 0 -55px;
 color: black;
}

body>modalProgress {
position: fixed;
}
</style>


<br /><br /><br />
<%--<div class="container container_content">--%>
   
    <asp:UpdatePanel runat="server" ID="uplMain" UpdateMode="Conditional">
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

                function imagePreview(input) {
                    if (input.files && input.files[0]) {

                        var filedr = new FileReader();
                        filedr.onload = function (e) {
                            $('#imgEmployeePicture').attr('src', e.target.result);
                        }
                        filedr.readAsDataURL(input.files[0]);

                    }
                }

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
                                $('.calendarInput').datetimepicker(
                                    {
                                        format: 'L'
                                    });
                            });

                            $(function () {
                                $('[data-toggle="tooltip"]').tooltip()
                            })

                            function imagePreview(input) {
                                if (input.files && input.files[0]) {

                                    var filedr = new FileReader();
                                    filedr.onload = function (e) {
                                        $('#imgEmployeePicture').attr('src', e.target.result);
                                    }
                                    filedr.readAsDataURL(input.files[0]);

                                }
                            }
                            
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
                                    <h4><span class="glyphicon glyphicon-briefcase"></span> Employee Master List</h4>
                                </div>
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-4 text-right">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control text-uppercase"
                                            placeholder="Search" data-toggle="tooltip" data-placement="top" title="Search Employee">
                                        </asp:TextBox>
                                        <div class="input-group-btn input-group-sm">
                                            <asp:LinkButton runat="server" ID="U_Search" CssClass="btn btn-warning" OnClick="U_Search_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="panel-body">
                            <div class="text-left">
                                <asp:LinkButton runat="server" ID="lnkCreateNew" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Create New Employee Record" OnClick="lnkCreateNew_Click"><span class="glyphicon glyphicon-plus-sign"></span> NEW</asp:LinkButton>
                            </div>
                            <hr />

                            <asp:Panel runat="server" ID="panelListEmployee" Height="800px" ScrollBars="Vertical">
                                <asp:GridView runat="server" ID="gvEmployeeList" GridLines="None" OnRowCommand="gvEmployeeList_RowCommand" AutoGenerateColumns="false" CssClass="table table-hover table-condensed table-responsive small" ShowHeader="false">
                                    <Columns>
                                         <%--<asp:TemplateField ItemStyle-Width="60px" ControlStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:Image runat="server" ID="imgEmployee" Width="50px" Height="50px" CssClass="img-rounded img-responsive" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        <asp:BoundField DataField="EmployeeID" ReadOnly="true" />
                                        <%--<asp:BoundField DataField="EmployeeName" />--%>
                                        <asp:TemplateField>
                            <ItemTemplate>
                                   <div class="input-group">
                          <asp:Image runat="server" ID="Image1" CssClass="img-circle" ImageUrl='<%# Eval("EmployeeAvatar") %>' />
                          <asp:label runat="server" Text='<%# Eval("EmployeeName") %>'></asp:label>
                                       
                        </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                                        <asp:BoundField DataField="GenderDescription" />
                                        <asp:BoundField DataField="MaritalStatus" />
                                        <asp:BoundField DataField="Date_Of_Birth" DataFormatString="{0:MM/d/yyyy}" HtmlEncode="false" />
                                         <asp:BoundField DataField="CompanyName" />
                                        <asp:BoundField DataField="Date_Hired" DataFormatString="{0:MM/d/yyyy}" HtmlEncode="false" />
                                        <asp:BoundField DataField="Position" />
                                        <asp:BoundField DataField="Department" />
                                        <asp:BoundField DataField="Status" />

                                        <%--Date Hired here--%>
                                        <asp:TemplateField ItemStyle-Width="50px" ControlStyle-Width="40px" ItemStyle-CssClass="text-right">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkEdit" CommandName="Select" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Edit Employee"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField ItemStyle-Width="50px" ControlStyle-Width="40px" ItemStyle-CssClass="text-right">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkFingerPrint" CommandName="Biometric" CssClass="btn btn-warning" data-toggle="tooltip" data-placement="top" title="Register Biometric"><span class="glyphicon glyphicon-qrcode"></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                        </div>
                    </div>

                </asp:Panel>


                <asp:Panel runat="server" Visible="false" ID="panel_Employee_Content">

                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>
                                        <asp:Label runat="server" ID="lblEmployeeFullName"></asp:Label> 201 Files <asp:LinkButton runat="server" ID="lnkRemoveEmployee" CssClass="btn btn-sm btn-danger" OnClick="lnkRemoveEmployee_Click">Remove Employee?</asp:LinkButton>
                                    </h4>
                                </div>
                                <div class="col-md-8 text-right">
                                    <asp:LinkButton runat="server" ID="lnkReturn" CssClass="btn btn-success btn-sm" OnClick="lnkReturn_Click">Back</asp:LinkButton>
                                </div>
                            </div>


                        </div>

                        <div class="panel-body">

                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#Basic" aria-controls="Basic" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-user text-success"></span> Basic</a> </li>
                                <li role="presentation"><a href="#Family" aria-controls="Family" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-home"></span> Family</a></li>
                                <li role="presentation"><a href="#Education" aria-controls="Education" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-book"></span> Education</a></li>
                                <li role="presentation"><a href="#SkillTraining" aria-controls="SkillTraining" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-flash"></span> Skills and Training</a></li>
                                <li role="presentation"><a href="#EmploymentHistory" aria-controls="EmploymentHistory" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-flash"></span> Employment History</a></li>
                                <%--<li role="presentation"><a href="#Evaluation" aria-controls="Evaluation" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-briefcase text-success"></span> Work Evaluation</a></li>
                                <li role="presentation"><a href="#Offenses" aria-controls="Offenses" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-comment text-danger"></span> Offenses Record</a></li>--%>
                                <li role="presentation"><a href="#Manage" aria-controls="Manage" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-comment text-danger"></span> Manage</a></li>
                                <%--<li role="presentation"><a href="#Attachment" aria-controls="Attachment" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-file text-danger"></span> Attachment</a></li>--%>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">

                                <div role="tabpanel" class="tab-pane fade in active" id="Basic">
                                    <br />
                                    <!-- Employee Basic Details-->



                                    <asp:Panel runat="server" ID="panelBasic">
                                      <%--  <asp:UpdatePanel runat="server" ID="upPanelBasicInfo">
                                            <ContentTemplate>--%>


                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <div class="row">
                                                            <div class="col-md-3"></div>
                                                            <div class="col-md-9 text-right">
                                                                <asp:LinkButton runat="server" ID="lnkUpdateEmployeeInformation" CssClass="btn btn-success btn-sm" OnClick="lnkUpdateEmployeeInformation_Click">Update</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="panel-body">

                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                <div class="panel panel-success small">
                                                                    <div class="panel-heading">
                                                                        EMP #: <b>
                                                                            <asp:Label runat="server" ID="lblEmployeeID"></asp:Label></b>
                                                                    </div>
                                                                    <div class="panel-body text-center">
                                                                        <asp:UpdatePanel runat="server" ID="upEmployeePicture">
                                                                            <ContentTemplate>

                                                                                <table class="table text-center">
                                                                                    <tr><td><asp:Image runat="server" ID="imgEmployeePicture" Width="120px" Height="120px" CssClass="img-thumbnail img-responsive" /></td></tr>
                                                                                    <tr><td><asp:LinkButton runat="server" ID="lnkUploadEmployeeImage" CssClass="btn btn-primary btn-sm" OnClick="lnkUploadEmployeeImage_Click"><i class="fa fa-user-circle"></i> Upload Picture</asp:LinkButton></td></tr>
                                                                                </table>
                                                                                

                                                                                <%-- <input type="file" name="fileupload" onchange="imagePreview(this)"  />--%>
                                                                                <%--<asp:FileUpload ID="fuEmployeePicture" runat="server" Width="100%" onchange="imagePreview(this)" />--%>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-10">
                                                                <table class="table table-responsive table-condensed">
                                                                    <tr>
                                                                        <td>
                                                                            <small class="form-text text-muted">Last Name</small>
                                                                            <asp:TextBox runat="server" ID="txtLastName" CssClass="text-uppercase form-control" data-toggle="tooltip" data-placement="top" title="Last Name *" placeholder="Last Name *"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <small class="form-text text-muted">First Name</small>
                                                                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="text-uppercase form-control" data-toggle="tooltip" data-placement="top" title="First Name *" placeholder="First Name *"></asp:TextBox></td>
                                                                        <td>
                                                                            <small class="form-text text-muted">Middle Name</small>
                                                                            <asp:TextBox runat="server" ID="txtMiddleName" CssClass="text-uppercase form-control" data-toggle="tooltip" data-placement="top" title="Middle Name" placeholder="Middle Name"></asp:TextBox></td>
                                                                        <td colspan="2">
                                                                            <small class="form-text text-muted">Nick Name</small>
                                                                            <asp:TextBox runat="server" ID="txtNickName" CssClass="text-uppercase form-control" data-toggle="tooltip" data-placement="top" title="Nick Name" placeholder="Nick Name"></asp:TextBox></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <small class="form-text text-muted">Gender</small>
                                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddGender" data-toggle="tooltip" data-placement="top" title="Gender"></asp:DropDownList></td>
                                                                        <td>
                                                                            <small class="form-text text-muted">Date of Birth</small>
                                                                            <asp:TextBox runat="server" ID="txtDateOfBirth" CssClass="calendarInput form-control" data-toggle="tooltip" data-placement="top" title="Date of Birth" placeholder="Date of Birth *"></asp:TextBox>



                                                                        </td>

                                                                        <td>
                                                                            <small class="form-text text-muted">Place of Birth</small>
                                                                            <asp:TextBox runat="server" ID="txtPlaceOfBirth" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Place of Birth" placeholder="Place of Birth"></asp:TextBox></td>

                                                                        <td>
                                                                            <small class="form-text text-muted">Weight</small>
                                                                            <asp:TextBox runat="server" ID="txtWeight" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Weight" placeholder="Weight"></asp:TextBox></td>
                                                                        <td>
                                                                            <small class="form-text text-muted">Height</small>
                                                                            <asp:TextBox runat="server" ID="txtHeight" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Height" placeholder="Height"></asp:TextBox></td>



                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <small class="form-text text-muted">Marital Status</small>
                                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddMaritalStatus" data-toggle="tooltip" data-placement="top" title="Marital Status"></asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <small class="form-text text-muted">Blood Type</small>
                                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddBloodType" data-toggle="tooltip" data-placement="top" title="Blood Type"></asp:DropDownList>
                                                                        </td>


                                                                        <td>
                                                                            <small class="form-text text-muted">Religion</small>
                                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddReligion" data-toggle="tooltip" data-placement="top" title="Religion"></asp:DropDownList>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <small class="form-text text-muted">Citizenship</small>
                                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddCitizenship" data-toggle="tooltip" data-placement="top" title="Citizenship"></asp:DropDownList></td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <small class="form-text text-muted">Landline Number</small>
                                                                            <asp:TextBox ID="txtLandlineNumber" runat="server" CssClass="form-control" data-placement="top" data-toggle="tooltip" placeholder="Landline Number" title="Landline Number"> </asp:TextBox></td>
                                                                        <td>
                                                                            <small class="form-text text-muted">Mobile Number</small>
                                                                            <asp:TextBox ID="txtMobilePhone" runat="server" CssClass="form-control" data-placement="top" data-toggle="tooltip" placeholder="Mobile Phone" title="Mobile Phone"></asp:TextBox></td>
                                                                        <td>
                                                                            <small class="form-text text-muted">Present Address</small>
                                                                            <asp:TextBox runat="server" ID="txtPresent_Address" TextMode="MultiLine" Rows="2" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Present Address" placeholder="Present Address"></asp:TextBox></td>
                                                                        <td colspan="2">
                                                                            <small class="form-text text-muted">Provincial Address</small>
                                                                            <asp:TextBox runat="server" ID="txtProvincial_Address" TextMode="MultiLine" Rows="2" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Provincial Address" placeholder="Provincial Address"></asp:TextBox></td>

                                                                    </tr>

                                                                </table>


                                                            </div>
                                                        </div>



                                                    </div>
                                                </div>


                                                <%--This is the modal that display prompt confirmation 
                                        of removing selected attachment--%>

                                                <div class="modal fade" id="promptRemoveEmployee" data-backdrop="static" tabindex="-1" role="dialog">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header alert-warning">
                                                                <button class="close" data-dismiss="modal">&times;</button>
                                                                <h4 class="modal-title">HR Management System</h4>
                                                            </div>

                                                            <div class="modal-body">
                                                                <h3><span class="glyphicon glyphicon-exclamation-sign text-warning"></span>
                                                                    Are you sure you want to remove this record?
                                                                </h3>
                                                                <br />
                                                                <p>This record will no longer available once you agree.</p>
                                                            </div>


                                                            <div class="modal-footer">

                                                                <asp:LinkButton runat="server" ID="lnkRemoveEmployeeData" CssClass="btn btn-primary btn-sm" OnClick="lnkRemoveEmployeeData_Click">Yes</asp:LinkButton>

                                                                <asp:LinkButton runat="server" ID="LinkButton3" CssClass="btn btn-danger btn-sm" data-dismiss="modal">No</asp:LinkButton>

                                                            </div>



                                                        </div>
                                                    </div>


                                                </div>
                                         <%--   </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </asp:Panel>
                                </div>

                                <%--End of Basic information--%>

                                <div role="tabpanel" class="tab-pane fade" id="Family">
                                    <br />
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:Panel runat="server" ID="panelFamilyControl">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    <div class="row">
                                                        <div class="col-md-3">Family </div>
                                                        <div class="col-md-9 text-right">
                                                            <asp:LinkButton runat="server" ID="lnkUpdateFamily" CssClass="btn btn-success btn-sm" OnClick="lnkUpdateFamily_Click">Update</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-body">

                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="panel panel-warning">
                                                                <div class="panel-heading">Father Details</div>
                                                                <ul class="list-group">
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Father Name</small>
                                                                        <asp:TextBox runat="server" ID="txtFatherName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Father Name" placeholder="Father Name"></asp:TextBox></li>
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Father Contact #</small>
                                                                        <asp:TextBox runat="server" ID="txtFatherContactNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Father Contact #" placeholder="Father Contact #"></asp:TextBox></li>

                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Mother Name</small>
                                                                        <asp:TextBox runat="server" ID="txtMotherName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Mother Name" placeholder="Mother Name"></asp:TextBox></li>
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Mother Contact #</small>
                                                                        <asp:TextBox runat="server" ID="txtMotherContactNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Mother Contact #" placeholder="Mother Contact #"></asp:TextBox></li>
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Sibling(s)</small>
                                                                        <asp:TextBox runat="server" ID="txtSiblingsCount" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="How many siblings you have?" placeholder="Sibling(s) Count"></asp:TextBox></li>
                                                                </ul>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="panel panel-warning">
                                                                <div class="panel-heading">Spouse Name</div>
                                                                <ul class="list-group">
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Spouse Last Name</small>
                                                                        <asp:TextBox runat="server" ID="txtSpouseLastName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Spouse Last Name" placeholder="Last Name"></asp:TextBox></li>
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Spouse First Name</small>
                                                                        <asp:TextBox runat="server" ID="txtSpouseFirstName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Spouse First Name" placeholder="First Name"></asp:TextBox></li>
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Spouse Middle Name</small>
                                                                        <asp:TextBox runat="server" ID="txtSpouseMiddleName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Spouse Middle Name" placeholder="Middle Name"></asp:TextBox></li>
                                                                    <li class="list-group-item">
                                                                        <small class="form-text text-muted">Spouse Contact Number</small>
                                                                        <asp:TextBox runat="server" ID="txtSpouseContactNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Spouse Contact #" placeholder="Spouse Contact #"></asp:TextBox></li>
                                                                </ul>
                                                            </div>

                                                        </div>

                                                       <div class="col-md-3">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">
                                                             <div class="row">
                                                                   <div class="col-lg-6 col-md-6 col-sm-6">Children(s)</div>
                                                                   <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                                                       <asp:LinkButton runat="server" ID="lnkUpdateChild" CssClass="btn btn-sm btn-success" OnClick="lnkUpdateChild_Click">
                                                                           <span class="glyphicon glyphicon-floppy-saved" data-toggle="tooltip" data-placement="top" title="Update Child"></span>
                                                                       </asp:LinkButton>
                                                                   </div>
                                                               </div>
                                                            </div>
                                                            <ul class="list-group">
                                                                
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">Name:</span>
                                                                    <asp:TextBox runat="server" ID="txtChildName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Child Name" placeholder="Child Name"></asp:TextBox>
                                                                     </div>   
                                                                     </li>

                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">Gender</span>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddChildGender" data-toggle="tooltip" data-placement="top" title="Gender"></asp:DropDownList>
                                                                    </div> 
                                                                    </li>
                                                              
                                                                 <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Date Hired</small>
                                                                    <asp:TextBox runat="server" ID="txtChildDOB" CssClass="form-control calendarInput " data-toggle="tooltip" data-placement="top" title="Date of Birth" placeholder="Date of Birth"></asp:TextBox>
                                                                    </div></li>

                                                                <li class="list-group-item">
                                                                   <asp:GridView runat="server" ID="gvFamilyChildren" AutoGenerateColumns="false" CssClass="table table-responsive">
                                                                       <Columns>
                                                                           <asp:BoundField DataField="id" />
                                                                           <asp:BoundField DataField="ChildName" />
                                                                           <asp:BoundField DataField="GenderCode" />
                                                                           <asp:BoundField DataField="DOB" DataFormatString="{0:d}" />
                                                                           <asp:TemplateField>
                                                                               <ItemTemplate>
                                                                                   <asp:LinkButton runat="server" ID="lnkChildEdit" CssClass="btn btn-sm btn-primary" OnClick="lnkChildEdit_Click">Edit</asp:LinkButton>
                                                                                   <asp:LinkButton runat="server" ID="lnkChildRemove" CssClass="btn btn-sm btn-danger" OnClick="lnkChildRemove_Click">Remove</asp:LinkButton>
                                                                               </ItemTemplate>
                                                                           </asp:TemplateField>
                                                                       </Columns>
                                                                   </asp:GridView>
                                                                </li>
                                                            </ul>
                                                        </div>

                                                    </div>

                                                         <div class="col-md-3">
                                                        <div class="panel panel-danger">
                                                            <div class="panel-heading">Incase of Emergency</div>
                                                            <ul class="list-group">
                                                                <li class="list-group-item">
                                                                <small class="form-text text-muted">Contact Person</small>
                                                                    <asp:TextBox runat="server" ID="txtContactPerson" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Contact Person" placeholder="Contact Person"></asp:TextBox></li>
                                                                <li class="list-group-item">
                                                                <small class="form-text text-muted">Relationship</small>
                                                                    <asp:TextBox runat="server" ID="txtContactRelationship" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Relationship" placeholder="Relationship"></asp:TextBox></li>
                                                                                                                               <li class="list-group-item">
                                                                <small class="form-text text-muted">Contact Number:</small>
                                                                    <asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Contact Number" placeholder="Contact Number"></asp:TextBox></li>
                                                                </ul>
                                                            </div>
                                                    </div>
                                                    </div>

                                                </div>
                                            </div>

                                            </asp:Panel>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>



                                </div>

                                <div role="tabpanel" class="tab-pane fade" id="Education">
                                    <br />
                                     <asp:UpdatePanel runat="server" ID="updateEducation" UpdateMode="Conditional">
                                     <ContentTemplate>
                                        <asp:Panel runat="server" ID="panelEducationControl">
                                        <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <div class="row">


                                                <div class="col-md-3">
                                                    Education
                                                </div>

                                                <div class="col-md-9 text-right">
                                                    <asp:LinkButton runat="server" ID="lnkUpdateEducation" CssClass="btn btn-success btn-sm" OnClick="lnkUpdateEducation_Click">Update</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="panel panel-warning">
                                                        <div class="panel-heading">Primary</div>
                                                        <ul class="list-group">
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">School Name</small>
                                                                <asp:TextBox runat="server" ID="txtPrimarySchool" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Primary School Name"></asp:TextBox></li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Year Graduated</small>
                                                                 <asp:TextBox runat="server" ID="txtPrimaryYG" CssClass="form-control" MaxLength="9" data-toggle="tooltip" data-placement="top" title="Primary Year Graduated"></asp:TextBox></li>
                                                            </li>
                                                            
                                                        </ul>
                                                    </div>
                                                </div>

                                                 <div class="col-md-4">
                                                    <div class="panel panel-warning">
                                                        <div class="panel-heading">Secondary</div>
                                                        <ul class="list-group">
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">School Name</small>
                                                                <asp:TextBox runat="server" ID="txtSecondarySchool" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Secondary School Name"></asp:TextBox></li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Year Graduated</small>
                                                                 <asp:TextBox runat="server" ID="txtSecondaryYG" CssClass="form-control" MaxLength="9" data-toggle="tooltip" data-placement="top" title="Secondary Year Graduated"></asp:TextBox></li>
                                                            </li>
                                                            
                                                        </ul>
                                                    </div>
                                                </div>

                                                 <div class="col-md-4">
                                                    <div class="panel panel-warning">
                                                        <div class="panel-heading">Tertiary</div>
                                                        <ul class="list-group">
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">School Name</small>
                                                                <asp:TextBox runat="server" ID="txtTertiarySchool" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Tertiary School Name"></asp:TextBox></li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Year Graduated</small>
                                                                 <asp:TextBox runat="server" ID="txtTertiaryYG" CssClass="form-control" MaxLength="9" data-toggle="tooltip" data-placement="top" title="Tertiary Year Graduated"></asp:TextBox></li>
                                                            </li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Course</small>
                                                                <asp:TextBox runat="server" ID="txtCourse" CssClass="form-control"  data-toggle="tooltip" data-placement="top" title="Course"></asp:TextBox>
                                                                <asp:CheckBox runat="server" ID="chkIsGraduate" Text="Graduate?" />
                                                            </li>
                                                            </li>
                                                            
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                              


                                        </div>
                                    </div>
                                        </asp:Panel>
                                        </ContentTemplate>
                                     </asp:UpdatePanel>
                                </div>
                                <%-- End of Education--%>
                                  <div role="tabpanel" class="tab-pane fade" id="SkillTraining">
                                    <br />
                                     <asp:Panel runat="server" ID="panelSkillsControl">
                                     <asp:UpdatePanel runat="server" ID="panelSkillsTraining" UpdateMode="Conditional">
                                    <ContentTemplate>

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <div class="row">


                                                <div class="col-md-3">
                                                    Skills and Training
                                                </div>

                                                <div class="col-md-9 text-right">
                                                    <asp:LinkButton runat="server" ID="lnkUpdateSkills" CssClass="btn btn-success btn-sm" OnClick="lnkUpdateSkills_Click">Update</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <!--Input Entry of Skills -->
                                                <div class="col-md-4">
                                                     <ul class="list-group">
                                                          <li class="list-group-item">
                                                                <small class="form-text text-muted">Company Sponsored?</small>
                                                              <asp:CheckBox runat="server" ID="chkCompanySponsor" Text="Yes" />
                                                            </li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Skills/Training:</small>
                                                                <asp:TextBox runat="server" ID="txtSkillsTraining" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Skill / Training"></asp:TextBox></li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Name of Training Center:</small>
                                                                 <asp:TextBox runat="server" ID="txtTrainingCenterName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Name of Training Center"></asp:TextBox></li>
                                                            </li>
                                                          <li class="list-group-item">
                                                                <small class="form-text text-muted">Start date of Training:</small>
                                                                 <asp:TextBox runat="server" ID="txtStartDateTraining" CssClass="form-control calendarInput" data-toggle="tooltip" data-placement="top" title="Date Training End"></asp:TextBox></li>
                                                            </li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">End date of Training:</small>
                                                                 <asp:TextBox runat="server" ID="txtEndDateTraining" CssClass="form-control calendarInput" data-toggle="tooltip" data-placement="top" title="Date Training End"></asp:TextBox></li>
                                                            </li>
                                                            
                                                        </ul>
                                                </div>
                                                <!-- List of Skills and Training -->
                                                <div class="col-md-8">
                                                    <div class="panel panel-warning">
                                                        <div class="panel-heading">Skills and Training List</div>
                                                        <asp:GridView runat="server" ID="gvSkillsTraining" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="true">
                                                            <Columns>
                                                                 <asp:BoundField DataField="ID" />
                                                                <asp:BoundField DataField="SkillTraining" HeaderText="Skills and Training" />
                                                                <asp:BoundField DataField="TrainingCenter" HeaderText="Training Center" />
                                                                <asp:BoundField DataField="StartTrainingDate" HeaderText="Training Date Start" DataFormatString="{0:d}" />
                                                                <asp:BoundField DataField="EndTrainingDate" HeaderText="Training Date End" DataFormatString="{0:d}" />
                                                                <%--<asp:BoundField DataField="IsCompanySponsor" HeaderText="Company Sponsor" DataFormatString=""/>--%>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <%# (Boolean.Parse(Eval("IsCompanySponsor").ToString())) ? "Yes" : "No" %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lnkRemove" CssClass="btn btn-danger btn-sm" OnClick="lnkRemove_Click">X</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                        
                                           </ContentTemplate>
                                </asp:UpdatePanel>
                                     </asp:Panel>
                                </div>
                                <%--End of Skills and Training--%>
                                    

                                <div role="tabpanel" class="tab-pane fade" id="EmploymentHistory">
                                         <br />
                                     <asp:Panel runat="server" ID="panelEmploymentHistoryControl">
                                     <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional">
                                    <ContentTemplate>

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <div class="row">


                                                <div class="col-md-3">
                                                   Employment History
                                                </div>

                                                <div class="col-md-9 text-right">
                                                    <asp:LinkButton runat="server" ID="lnkUpdateEmploymentHistory" CssClass="btn btn-success btn-sm" OnClick="lnkUpdateEmploymentHistory_Click" data-toggle="tooltip" data-placement="top" title="Update Employment History">Update</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <!--Input Entry of Skills -->
                                                <div class="col-md-4">
                                                     <ul class="list-group">
                                                          <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Company Name</small>
                                                                    <asp:TextBox runat="server" ID="txtEH_CompanyName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Company Name" placeholder="Company Name"></asp:TextBox>
                                                           </div></li>
                                                          <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Address</small>
                                                                    <asp:TextBox runat="server" ID="txtEH_CompanyAddress" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Company Address" placeholder="Company Address"></asp:TextBox>
                                                           </div></li>
                                                          <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Position</small>
                                                                    <asp:TextBox runat="server" ID="txtEH_Position" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Position" placeholder="Position"></asp:TextBox>
                                                           </div></li>
                                                            <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Date Started</small>
                                                                    <asp:TextBox runat="server" ID="txtEH_DateStarted" CssClass="form-control calendarInput" data-toggle="tooltip" data-placement="top" title="Date Started" placeholder="Date Started"></asp:TextBox>
                                                           </div></li>
                                                          <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Date Ended</small>
                                                                    <asp:TextBox runat="server" ID="txtEH_DateEnd" CssClass="form-control calendarInput" data-toggle="tooltip" data-placement="top" title="Date Ended" placeholder="Date Ended"></asp:TextBox>
                                                           </div></li>

                                                          <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Remarks:</small>
                                                                    <asp:TextBox runat="server" ID="txtEH_Remarks" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Remarks" placeholder="Remarks"></asp:TextBox>
                                                           </div></li>
                                                            
                                                        </ul>
                                                </div>
                                                <!-- List of Skills and Training -->
                                                <div class="col-md-8">
                                                    <div class="panel panel-warning">
                                                        <div class="panel-heading">Employment History Record</div>
                                                        <asp:GridView runat="server" ID="gvEmploymentHistory" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="true">
                                                            <Columns>
                                                                <asp:BoundField DataField="ID" />
                                                                <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                                                                <asp:BoundField DataField="CompanyAddress" HeaderText="Address" />
                                                                <asp:BoundField DataField="Position" HeaderText="Position" />
                                                                <asp:BoundField DataField="DateStarted" HeaderText="Start" DataFormatString="{0:d}" />
                                                                <asp:BoundField DataField="DateEnded" HeaderText="End" DataFormatString="{0:d}" />
                                                                 <asp:BoundField DataField="Remarks" HeaderText="Position" />
                                                                <%--<asp:BoundField DataField="IsCompanySponsor" HeaderText="Company Sponsor" DataFormatString=""/>--%>
                                                               
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lnkRemoveEmploymentHistory" CssClass="btn btn-danger btn-sm" OnClick="lnkRemoveEmploymentHistory_Click">X</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                        
                                           </ContentTemplate>
                                </asp:UpdatePanel>
                                     </asp:Panel>
                                    </div>
                                <%--End of Employment History--%>

                                    <div role="tabpanel" class="tab-pane fade" id="Manage">
                                    <br />
                                    <asp:Panel runat="server" ID="panelManageControl">
                                         <div class="row">
                                     
                                     
                                     
                                     <div class="col-lg-12 col-md-12 col-sm-12">
                                       
                                          <ul class="nav nav-pills" role="tablist">
                                
                                <li role="presentation" class="active"><a href="#Details" aria-controls="Details" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-align-left text-success"></span> Details</a></li>
                                
                                <li role="presentation"><a href="#Evaluation" aria-controls="Evaluation" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-briefcase text-success"></span> Work Evaluation</a></li>
                                
                                <li role="presentation"><a href="#Offenses" aria-controls="Offenses" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-comment text-danger"></span> Offenses Record</a></li>
                                <li role="presentation"><a href="#Promotion" aria-controls="Promotion" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-briefcase text-success"></span> Promotion / Demotion</a></li>
                                <li role="presentation"><a href="#Transfer" aria-controls="Transfer" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-briefcase text-success"></span> Transfer</a></li>
                                <li role="presentation"><a href="#EndOfService" aria-controls="EndOfService" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-briefcase text-success"></span> End Of Service</a></li>
                                <li role="presentation"><a href="#Attachment" aria-controls="Attachment" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-file text-danger"></span> Attachment</a></li>
                            </ul>

                                            <!-- Tab panes -->
                                            <div class="tab-content">

                                               

                                                <div role="tabpanel" class="tab-pane fade in active" id="Details">
                                                    <br />
                                                    <asp:UpdatePanel runat="server" ID="upDetailsTab">
                                                        <ContentTemplate>

                                                      
                                                    <div class="row">
                                                          <div class="col-md-4">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">
                                                               <div class="row">
                                                                   <div class="col-lg-6 col-md-6 col-sm-6">Employment Details</div>
                                                                   <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                                                       <asp:LinkButton runat="server" ID="lnkUpdateEmploymentDetails" CssClass="btn btn-sm btn-success" OnClick="lnkUpdateEmploymentDetails_Click">
                                                                           <span class="glyphicon glyphicon-floppy-saved" data-toggle="tooltip" data-placement="top" title="Update Employment Details"></span>
                                                                       </asp:LinkButton>
                                                                   </div>
                                                               </div>
                                                                 

                                                            </div>
                                                            <ul class="list-group">
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Company</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddCompany" data-toggle="tooltip" data-placement="top" title="Company"></asp:DropDownList>
                                                                        </div></li>
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Date Hired</small>
                                                                    <asp:TextBox runat="server" ID="txtDateHired" CssClass="form-control calendarInput " data-toggle="tooltip" data-placement="top" title="Date Hired" placeholder="Date Hired *"></asp:TextBox>
                                                                    </div></li>
                                                               
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Department</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddDepartment" data-toggle="tooltip" data-placement="top" title="Department"></asp:DropDownList>
                                                                    </div></li>
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Position</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddPosition" data-toggle="tooltip" data-placement="top" title="Position"></asp:DropDownList>
                                                                    
                                                                    </div></li>
                                                                 <li class="list-group-item">
                                                                     <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Employment Type</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddEmploymentType" data-toggle="tooltip" data-placement="top" title="Employment Type"></asp:DropDownList>
                                                                    </div></li>
                                                                 <li class="list-group-item">
                                                                     <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Employment Status</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddEmploymentStatus" data-toggle="tooltip" data-placement="top" title="Status"></asp:DropDownList>
                                                                    </div></li>
                                                            </ul>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">
                                                             <div class="row">
                                                                   <div class="col-lg-6 col-md-6 col-sm-6">Government ID's</div>
                                                                   <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                                                       <asp:LinkButton runat="server" ID="lnkUpdateGovtID" CssClass="btn btn-sm btn-success" OnClick="lnkUpdateGovtID_Click">
                                                                           <span class="glyphicon glyphicon-floppy-saved" data-toggle="tooltip" data-placement="top" title="Update Employee Govt IDs"></span>
                                                                       </asp:LinkButton>
                                                                   </div>
                                                               </div>
                                                            </div>
                                                            <ul class="list-group">
                                                                
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">SSS #</span>
                                                                    <asp:TextBox runat="server" ID="txtSSSNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Social Security System Number" placeholder="Social Security System Number"></asp:TextBox>
                                                                     </div>   
                                                                     </li>

                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">Pagibig #</span>
                                                                    <asp:TextBox runat="server" ID="txtPagibigNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Home Development Mutual Fund (HDMF)" placeholder="HDMF (Pag-IBIG) No"></asp:TextBox>
                                                                    </div> 
                                                                    </li>
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">PhilHealth #</span>
                                                                    <asp:TextBox runat="server" ID="txtPhilHealthNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Philippine Health Insurance Corporation (PHIC)" placeholder="PhilHealth ID"></asp:TextBox>
                                                                    </div>    
                                                                    </li>
                                                            <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">TIN #</span>
                                                                    <asp:TextBox runat="server" ID="txtTinNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Tax Identification Number" placeholder="TIN Number"></asp:TextBox>
                                                                    </div>
                                                                    </li>

                                                                 <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Company To Bill:</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddCompanyToBill" data-toggle="tooltip" data-placement="top" title="Company"></asp:DropDownList>
                                                                 </div>
                                                                         <br />
                                                                     <asp:LinkButton runat="server" id="lnkShowCompanyBillTransactions" CssClass="btn btn-info" OnClick="lnkShowCompanyBillTransactions_Click">Show Transactions</asp:LinkButton>      

                                                                     <!-- Display to modal list of Company Bill Transactions -->
                                                                      <div class="modal fade" id="showCompanyBillTransactions">
                                                                 <div class="modal-dialog">
                                                                     <div class="modal-content">
                                                                         <div class="modal-header bg-success">
                                                                             <button class="close" data-dismiss="modal">
                                                                                 &times;</button>
                                                                             <h4 class="modal-title">HR Management System</h4>
                                                                         </div>
                                                                         <div class="modal-body">
                                                                             <asp:GridView runat="server" ID="gvShowCompanyBillTransactions" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                                                 <Columns> 
                                                                                     <asp:BoundField DataField="CompanyName" HeaderText="Company to Bill" />
                                                                                     <asp:BoundField DataField="Year" HeaderText="Year Applied" />
                                                                                     <asp:BoundField DataField ="Month" HeaderText="Month in #" />
                                                                                 </Columns>
                                                                             </asp:GridView>
                                                                         </div>
                                                                         <div class="modal-footer">
                                                                         </div>
                                                                     </div>
                                                                 </div>
                                                             </div>
                                                                 </li>
                                                            </ul>
                                                        </div>

                                                    </div>

                                                     <div class="col-md-4">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">
                                                                <div class="row">
                                                                   <div class="col-lg-6 col-md-6 col-sm-6">Application Details</div>
                                                                   <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                                                       <asp:LinkButton runat="server" ID="lnkEmployeeApplicationRecord" CssClass="btn btn-sm btn-success" OnClick="lnkEmployeeApplicationRecord_Click">
                                                                           <span class="glyphicon glyphicon-floppy-saved" data-toggle="tooltip" data-placement="top" title="Update Employee Application"></span>
                                                                       </asp:LinkButton>
                                                                   </div>
                                                               </div>
                                                                </div>
                                                            <ul class="list-group">
                                                           
                                                                <li class="list-group-item">
                                                                    <div class="input-group input-group-sm">
                                                                    <span class="form-text text-muted input-group-addon">Application Date</span>
                                                                    <asp:TextBox runat="server" ID="txtApplicationDate" CssClass="form-control calendarInput" data-toggle="tooltip" data-placement="top" title="Date Applied" placeholder="Application Date" TextMode="DateTime"></asp:TextBox>
                                                                        </div></li>
                                                                 <li class="list-group-item">
                                                                     <div class="input-group input-group-sm">
                                                                    <small class="form-text text-muted input-group-addon">Job Posting</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddJobPosting" data-toggle="tooltip" data-placement="top" title="How does applicant know the job posting?"></asp:DropDownList>
                                                                         </div></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Applicant Evaluation Remarks</small>
                                                                    <asp:TextBox runat="server" ID="txtApplicantEvaluation" TextMode="MultiLine" Rows="3" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Initial Applicant Evaluation" placeholder="Applicant Evaluation"></asp:TextBox>
                                                                </li>
                                                            </ul>
                                                        </div>

                                                    </div>

                                                  
                                                    </div>

                                                            <div class="modal fade" id="msgSuccess">
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
                                                                                <asp:Label runat="server" ID="lblmsgSuccess"></asp:Label>

                                                                             </h4>
                                                                         </div>
                                                                         <div class="modal-footer">
                                                                         </div>
                                                                     </div>
                                                                 </div>
                                                             </div>

                                                      </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div> <%--End of Tab Panel--%>

                                                

                                                <div role="tabpanel" class="tab-pane fade" id="Evaluation">
                                                    <br />
                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="panel panel-primary">
                                                                <div class="panel-heading">
                                                                    <div class="row">
                                                                        <div class="col-md-6 col-sm-6">
                                                                            Work Evaluation / Performance
                                                                        </div>
                                                                        <div class="col-md-6 col-sm-6 text-right">
                                                                        </div>
                                                                    </div>



                                                                </div>
                                                                <div class="panel-body">
                                                                    <div class="row small">
                                                                        <div class="col-md-4 col-sm-4">
                                                                            <div class="text-right">
                                                                                <asp:LinkButton runat="server" ID="lnkCreateWorkEvaluation" CssClass="btn btn-success btn-sm" OnClick="lnkCreateWorkEvaluation_Click">Create</asp:LinkButton>

                                                                            </div>
                                                                            <br />
                                                                            <asp:GridView runat="server" ID="gvWorkEvaluationRecord" CssClass="table table-hover table-responsive" AutoGenerateColumns="false">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="WE_ID" HeaderText="ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                                                            <asp:BoundField DataField="DateStart" HeaderText="Date From" DataFormatString="{0:d}" />
                                                                                            <asp:BoundField DataField="DateEnd" HeaderText="Date To" DataFormatString="{0:d}" />
                                                                                            <asp:BoundField DataField="EvalPercentage" HeaderText="Eval %" DataFormatString="{0:n}" />
                                                                                            <asp:BoundField DataField="GeneralRemarks" HeaderText="Remarks" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>

                                                                                                    <asp:LinkButton runat="server" ID="lnkViewEvaluation" CssClass="btn btn-sm btn-primary" OnClick="lnkViewEvaluation_Click">View/Edit</asp:LinkButton>


                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                          


                                                                        </div>

                                                                        <div class="col-md-8 col-sm-8">
                                                                            <asp:Panel runat="server" ID="panelUpdateEvaluation" Enabled="false">


                                                                                <div class="panel panel-info">
                                                                                    <div class="panel-heading">

                                                                                        <div class="row">
                                                                                            <div class="col-md-6 col-sm-6">Evaluation Details</div>
                                                                                            <div class="col-md-6 col-sm-6 text-right">
                                                                                                <asp:LinkButton runat="server" ID="lnkEvaluationUpdate" CssClass="btn btn-success btn-sm" OnClick="lnkEvaluationUpdate_Click">Update</asp:LinkButton>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="panel-body">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6 col-sm-6">
                                                                                                <table class="table table-condensed">
                                                                                                    <tr>
                                                                                                        <td>Date From:</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox runat="server" ID="txtEditEvalDateFrom" CssClass="form-control calendarInput"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>Date To:</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox runat="server" ID="txtEditEvalDateTo" CssClass="form-control calendarInput"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>Remarks:</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox runat="server" ID="txtEditEvalRemarks" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>

                                                                                            <div class="col-md-6 col-sm-6">
                                                                                                <asp:GridView runat="server" ID="gvRatingsLegend" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="true">
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="WER_Title" HeaderText="Legend" ItemStyle-Font-Bold="true" />
                                                                                                        <asp:BoundField DataField="Value_Min" HeaderText="Ratings" />
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </div>



                                                                                        <asp:GridView runat="server" ID="gvEmployeeEvaluationResult" CssClass="table table-hover table-responsive" AutoGenerateColumns="false" OnRowDataBound="gvEmployeeEvaluationResult_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="WE_ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                                                                <asp:BoundField DataField="WEC_CODE" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                                                                <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <strong>
                                                                                                            <asp:Label runat="server" ID="lblWEC_Title" Text='<%#Eval("WEC_Title") %>'></asp:Label></strong>
                                                                                                        <p>
                                                                                                            <i>
                                                                                                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("WEC_Details") %>'></asp:Label></i>
                                                                                                        </p>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:DropDownList runat="server" ID="ddRatings" CssClass="form-control small">
                                                                                                        </asp:DropDownList>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </div>

                                                                            </asp:Panel>

                                                                        </div>







                                                                        <!--Selected Item Modal -->
                                                                        <div class="modal fade" id="promptEvaluationEntry" data-backdrop="static" tabindex="-1" role="dialog">
                                                                            <div class="modal-dialog" role="document">
                                                                                <div class="modal-content">
                                                                                    <div class="modal-header alert-info">
                                                                                        <button class="close" data-dismiss="modal">&times;</button>
                                                                                        <h4 class="modal-title">Work Evaluation Entry</h4>
                                                                                    </div>
                                                                                    <div class="modal-body">
                                                                                        <table class="table table-condensed table-hover">
                                                                                            <tr>
                                                                                                <td>Date Start:</td>
                                                                                                <td>
                                                                                                    <asp:TextBox runat="server" ID="txtEvalDateStart" CssClass="form-control calendarInput"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Date End:</td>
                                                                                                <td>
                                                                                                    <asp:TextBox runat="server" ID="txtEvalDateEnd" CssClass="form-control calendarInput"></asp:TextBox></td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td>General Remarks:</td>
                                                                                                <td>
                                                                                                    <asp:TextBox runat="server" ID="txtEvaluationRemarks" TextMode="MultiLine" Rows="2" CssClass="form-control" placeholder="General Remarks">
                                                                                                    </asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>


                                                                                        <asp:GridView runat="server" ID="gvWorkEvaluationCriteria" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="true" OnRowDataBound="gvWorkEvaluationCriteria_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="WEC_CODE" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                                                                <asp:BoundField DataField="WEC_Title" HeaderText="Title" ItemStyle-Font-Bold="true" />
                                                                                                <asp:BoundField DataField="WEC_Details" HeaderText="Details" />
                                                                                                <asp:TemplateField>
                                                                                                    <HeaderTemplate>
                                                                                                        Ratings
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:DropDownList runat="server" ID="ddRatings" CssClass="form-control small">
                                                                                                        </asp:DropDownList>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>

                                                                                    <div class="modal-footer">
                                                                                        <asp:LinkButton runat="server" ID="lnkSaveWorkEvaluation" CssClass="btn btn-success btn-sm" OnClick="lnkSaveWorkEvaluation_Click">Save</asp:LinkButton>
                                                                                        <asp:LinkButton runat="server" ID="lnkClose" CssClass="btn btn-danger btn-sm" data-dismiss="modal">Cancel</asp:LinkButton>
                                                                                    </div>



                                                                                </div>
                                                                            </div>


                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <%--End of Work Evaluation--%>
                                               
                                                <div role="tabpanel" class="tab-pane fade" id="Offenses">
                                                    <br />

                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                                                        <ContentTemplate>

                                                            <div class="panel panel-danger">
                                                                <div class="panel-heading">
                                                                    <div class="row">


                                                                        <div class="col-md-3">
                                                                            Offenses Record
                                                                        </div>

                                                                        <div class="col-md-9 text-right">
                                                                            <asp:LinkButton runat="server" ID="lnkOffenses" CssClass="btn btn-success btn-sm" OnClick="lnkOffenses_Click">Update</asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="panel-body">
                                                                    <div class="row">
                                                                        <!--Input Entry of Skills -->
                                                                        <div class="col-md-4">
                                                                            <ul class="list-group">
                                                                                <li class="list-group-item">
                                                                                    <small class="form-text text-muted">Offense Title:</small>
                                                                                    <asp:TextBox runat="server" ID="txtOffenseTitle" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Offense Title"></asp:TextBox>

                                                                                </li>
                                                                                <li class="list-group-item">
                                                                                    <small class="form-text text-muted">Details/Particular:</small>
                                                                                    <asp:TextBox runat="server" ID="txtOffenseDetails" TextMode="MultiLine" Rows="3" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Details"></asp:TextBox></li>
                                                                                </li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Recommendation:</small>
                                                                <asp:TextBox runat="server" ID="txtOffenseRecommendation" CssClass="form-control" TextMode="MultiLine" Rows="2" data-toggle="tooltip" data-placement="top" title="Recommendation"></asp:TextBox></li>
                                                                                </li>
                                                            
                                                                            </ul>
                                                                        </div>
                                                                        <!-- List of Skills and Training -->
                                                                        <div class="col-md-8">
                                                                            <div class="panel panel-warning">
                                                                                <div class="panel-heading">Offenses Committed</div>
                                                                                <asp:GridView runat="server" ID="gvEmployeeOffense" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="true">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="OffenseID" />
                                                                                        <asp:BoundField DataField="OffenseTitle" HeaderText="Title" />
                                                                                        <asp:BoundField DataField="OffenseDetails" HeaderText="Details" />
                                                                                        <asp:BoundField DataField="OffenseRecommendation" HeaderText="Recommendation" />
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkRemoveOffense" CssClass="btn btn-danger btn-sm" OnClick="lnkRemoveOffense_Click">X</asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>




                                                </div>
                                                 <%--End of Violation--%>

                                                <div class="tab-pane fade" id="Promotion">
                                                    <br />
                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                                        <ContentTemplate>

                                                            <h1>Work in progress.....</h1>
                                                             </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                  <%--End of Promotion--%>

                                                 <div class="tab-pane fade" id="Transfer">
                                                    <br />
                                                     <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                                                         <ContentTemplate>
                                                             <div class="row">
                                                                   <div class="col-md-12">
                                                                    <div class="panel panel-default">
                                                                   <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> <asp:Label runat="server" ID="lblEmployeeName"></asp:Label></div>
                                                                    <div class="panel-body">
                                                                            <div class="row">
                     
                                                                          <div class="col-md-2 hidden">
                             
                                                                                     <div class="text-center">
                                                                                         <asp:Image runat="server" ID="imgEmployee" CssClass="img-circle img-responsive" Width="200px" Height="200px" />
                                                                                         <hr />
                                    
                                                                                     </div>
                          
                                                                              </div>

                                                                                <div class="col-md-6">
                                                                                    <div class="panel panel-info">
                                                                                        <div class="panel-heading">
                                                                                            <span class="glyphicon glyphicon-briefcase"></span> Employment Transfer History
                                                                                        </div>
                                                                                        <div class="panel-body">
                                                                                           <h5> Current Company :
                                                                                            <b><asp:Label runat="server" ID="lblCurrentCompany"></asp:Label></b></h5>
                                                                                            <hr />
                                                                                            <asp:GridView runat="server" ID="gvEmployeeTransferHistory" CssClass="table table-responsive" AutoGenerateColumns="false">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="OldCompany" HeaderText="Previous Company" />
                                                                                                    <asp:BoundField DataField="TransferDate" HeaderText="Date Transfer" DataFormatString="{0:d}" />
                                                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                                                                   <%-- <asp:BoundField DataField="Used" HeaderText="Used" />
                                                                                                    <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-CssClass="text-danger" ItemStyle-Font-Bold="true" />--%>

                                                                                                </Columns>
                                                                                            </asp:GridView>


                                                                                        </div>
                                                                                    </div>

                                                                                </div>

                                                                                <div class="col-md-6">
                                                                                    <div class="panel panel-default">
                                                                                        <div class="panel-heading"><span class="glyphicon glyphicon-tag"></span> Company Transfer Data Entry</div>
                                                                                        <div class="panel-body">
                                                                                            <ul class="list-group">
                                                                                                <%-- <li class="list-group-item">
                                                                                                    <div class="input-group">
                                                                                                        <span class="input-group-addon alert-warning">Date End in Current Company:</span>
                                                                                                        <asp:TextBox runat="server" ID="txtDateEnd" CssClass="form-control calendarInput"></asp:TextBox>
                                                    
                                                                                                    </div>
                                                                                                </li>--%>

                                                                                                <li class="list-group-item">
                                                                                                    <div class="input-group">
                                                                                                        <span class="input-group-addon alert-warning">Date Transfer:</span>
                                                                                                        <asp:TextBox runat="server" ID="txtDateTransfer" CssClass="form-control calendarInput"></asp:TextBox>
                                                                                                    </div>
                                                                                                </li>

                                                                                                <li class="list-group-item">
                                                                                                    <div class="input-group">

                                                                                                        <span class="input-group-addon alert-warning">Transfer To :</span>

                                                                                                        <asp:DropDownList runat="server" ID="ddTransferCompanyTo" CssClass="form-control">
                                                                                                        </asp:DropDownList>

                                                                                                        <%-- <span class="input-group-addon alert-warning">Days</span>
                                                                            <asp:TextBox runat="server" ID="txtDays" CssClass="form-control"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </li>

                                                                                               
                                                                                                <%--<li class="list-group-item">
                                                                                                    <div class="input-group">
                                                                                                        <span class="input-group-addon alert-warning">Date Start:</span>
                                                                                                        <asp:TextBox runat="server" ID="txtDateStart" CssClass="form-control calendarInput"></asp:TextBox>
                                                   
                                                                                                    </div>
                                                                                                </li>--%>
                                           

                                                                                                <li class="list-group-item">
                                                                                                    <asp:TextBox runat="server" ID="txtTransferRemarks" TextMode="MultiLine" CssClass="form-control" Rows="2" placeholder="Remarks/Notes"></asp:TextBox>
                                                                                                </li>

                                                                                                <li class="list-group-item text-right">
                                                                                                    <asp:LinkButton runat="server" ID="lnkProcessTransfer" CssClass="btn btn-primary btn-sm" OnClick="lnkProcessTransfer_Click"><span class="glyphicon glyphicon-floppy-saved"></span> Process</asp:LinkButton>
                                                                                                </li>
                                                                                            </ul>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                             

                                                                         </div>
                                                                    </div>
                   
                          
                    

              
                                                                    </div>

                                                                   </div>
                                                             </div>

                                                        <!--Messages Confirmation / Error -->
                                                            
                                                               <!--CONFIRM USER SELECTION -->
                                                            <div class="modal fade" id="confirmationTransfer" data-backdrop="static" tabindex="-1" role="dialog">
                                                                <div class="modal-dialog" role="document">
                                                                  <div class="modal-content">
                                                                    <div class="modal-header alert-warning">
                                                                        <button class="close" data-dismiss="modal">&times;</button>
                                                                        <h4 class="modal-title">HR Management System</h4>
                                                                    </div>
                 
                                                                          <div class="modal-body">
                                                                          <h3><span class="glyphicon glyphicon-question-sign alert-info"></span> Transfer Employee Company?.</h3>
                     
                                                                          <p>Are you sure you want to continue to transfer employee company record?</p>
                       

                                                                          </div>
                

                                                                      <div class="modal-footer">
                    
                                                                    <asp:LinkButton runat="server" ID="lnkYesTransfer" CssClass="btn btn-primary btn-sm" OnClick="lnkYesTransfer_Click">Yes</asp:LinkButton>

                                                                    <asp:LinkButton runat="server" ID="lnkNoTransfer" CssClass="btn btn-danger btn-sm" data-dismiss="modal">No</asp:LinkButton>

                                                                    </div>


                 
                                                                </div>
                                                                </div>

          
                                                           </div>
                                                             
                                                              <!--SUCCESS MESSAGES -->
                                                             <div class="modal fade" id="msgSuccessTransfer">
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
                                                                                <asp:Label runat="server" ID="lblSuccessMessageTransfer"></asp:Label>

                                                                             </h4>
                                                                         </div>
                                                                         <div class="modal-footer">
                                                                         </div>
                                                                     </div>
                                                                 </div>
                                                             </div>
                                                             <!--ERROR MESSAGES -->
                                                             <div class="modal fade" id="msgErrorTransfer">
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
                                                                                <asp:Label runat="server" ID="lblErrorMessageTransfer"></asp:Label></h4>
                                                                         </div>

                                                                     </div>
                                                                 </div>
                                                             </div>
                                                            
                                                          
                                                         </ContentTemplate>
                                                     </asp:UpdatePanel>
                                                </div>
                                                  <%--End of Company Transfer--%>
                                                 
                                                <div class="tab-pane fade" id="EndOfService">
                                                  
                                                      <br />
                                                     <asp:UpdatePanel runat="server" ID="UpdatePanel7">
                                                         <ContentTemplate>

                                                             
                                                                    
                                                                 
                                                               
                                                                      <div class="row">
                                                                <div class="col-md-5">
                                                                 <asp:Panel runat="server" ID="panelEOSForm">
                                                                     <div class="panel panel-success">
                                                                  <div class="panel-heading text-right">
                                                                      <asp:LinkButton runat="server" ID="lnkEOSUpdate" OnClick="lnkEOSUpdate_Click" CssClass="btn btn-success">
                                                                     <span class="glyphicon glyphicon-floppy-saved" data-toggle="tooltip" data-placement="top" title="Update End of Service"></span>
                                                                                            </asp:LinkButton>
                                                                      <asp:LinkButton runat="server" ID="lnkEOSRemove" OnClick="lnkEOSRemove_Click" CssClass="btn btn-danger">
                                                                     <span class="glyphicon glyphicon-remove" data-toggle="tooltip" data-placement="top" title="Remove Resignation Application"></span>
                                                                                            </asp:LinkButton>
                                                                  </div>
                                                                      



                                                                   <div class="panel-body">
                                                                     <ul class="list-group">
                                                                                   <li class="list-group-item">
                                                                                   <div class="input-group">
                                                                                       <span class="input-group-addon alert-warning">Date Applied:</span>
                                                                                       <asp:TextBox runat="server" ID="txtEOSDateApplied" CssClass="form-control calendarInput"></asp:TextBox>
                                                                                   </div>
                                                                               </li>

  
                                                                            <li class="list-group-item">
                                                                                  <div class="input-group">

                                                                                    <span class="input-group-addon alert-warning">Type :</span>

                                                                                    <asp:DropDownList runat="server" ID="ddEOSType" CssClass="form-control">
                                                                                    </asp:DropDownList>

                                                                                   
                                                                                                    </div>
                                                                               </li>

                                                                               <li class="list-group-item">
                                                                                   <div class="input-group">
                                                                                       <span class="input-group-addon alert-warning">Effectivity Date:</span>
                                                                                       <asp:TextBox runat="server" ID="txtEOSDate" CssClass="form-control calendarInput"></asp:TextBox>
                                                                                   </div>
                                                                               </li>

                                                                            
                                                                     <li class="list-group-item">
                                                                          <asp:TextBox runat="server" ID="txtEOSRemarks" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Reason/Remarks">

                                                                          </asp:TextBox>
                                                                     </li>
                                                                     </ul>

                                                             </div>
                                                                  </asp:Panel>
                                                                       
                                                             </div>
                                                                 </div>
                                                             </div>
                                                             

                                                               <!--SUCCESS MESSAGES -->
                                                             <div class="modal fade" id="msgSuccessEOS">
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
                                                                                <asp:Label runat="server" ID="lblSuccessEOS"></asp:Label>

                                                                             </h4>
                                                                         </div>
                                                                         <div class="modal-footer">
                                                                         </div>
                                                                     </div>
                                                                 </div>
                                                             </div>
                                                             <!--ERROR MESSAGES -->
                                                             <div class="modal fade" id="msgErrorEOS">
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
                                                                                <asp:Label runat="server" ID="lblErrorEOS"></asp:Label></h4>
                                                                         </div>

                                                                     </div>
                                                                 </div>
                                                             </div>
                                                           </ContentTemplate>
                                                         </asp:UpdatePanel>
                                                </div>

                                                 <div role="tabpanel" class="tab-pane fade" id="Attachment">
                                    <br />
                                   <asp:Panel runat="server" ID="panelAttachmentControl">
                                   <asp:UpdatePanel runat="server" ID="upAttachments" UpdateMode="Conditional">
                                    <ContentTemplate>
                                     <div class="panel panel-info">
                                        
                                         <div class="panel-body">
                                             <div class="row">
                                               
                                                 <div class="col-lg-8 col-md-8 col-sm-8">
                                                      <div class="text-left">
                                                      <asp:UpdatePanel runat="server" ID="upAttachment" UpdateMode="Conditional">
                                                         <ContentTemplate>
                                                             <asp:LinkButton runat="server" ID="lnkUploadAndDownload" CssClass="btn btn-sm btn-primary" OnClick="lnkUploadAndDownload_Click"> Upload/Download Attachment </asp:LinkButton>
                                                         </ContentTemplate>
                                                     </asp:UpdatePanel>
                                                          </div>

                                                     <div class="text-right">
                                                     <asp:LinkButton runat="server" ID="lnkAttachmentRefresh" CssClass="btn btn-sm btn-primary" OnClick="lnkAttachmentRefresh_Click"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                                     </div>
                                                      <br />
                                                     <asp:GridView runat="server" ID="gvAttachmentList" AutoGenerateColumns="false" CssClass="table table-condensed table-responsive table-hover">
                                                         <Columns>
                                                             <asp:BoundField DataField="EmpAttachmentID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                             <asp:BoundField DataField="Title" HeaderText="File"  />
                                                             <asp:BoundField DataField="DI" DataFormatString="{0:d}" HeaderText="Date Attached" />
                                                             <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton runat="server" ID="lnkDeleteAttacment" CssClass="btn btn-sm btn-danger" OnClick="lnkDeleteAttacment_Click"><span class="glyphicon glyphicon-remove-sign"></span> Remove   </asp:LinkButton>
                                                                 </ItemTemplate>
                                                             </asp:TemplateField>
                                                         </Columns>
                                                     </asp:GridView>
                                                 </div>
                                             </div>
                                         </div>
                                     </div>

                                        <%--This is the modal that display prompt confirmation 
                                        of removing selected attachment--%>

                                        <div class="modal fade" id="promptRemoveAttachment" data-backdrop="static" tabindex="-1" role="dialog">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header alert-warning">
                                                        <button class="close" data-dismiss="modal">&times;</button>
                                                        <h4 class="modal-title">HR Management System</h4>
                                                    </div>

                                                    <div class="modal-body">
                                                        <h3><span class="glyphicon glyphicon-exclamation-sign text-warning"></span>
                                                            Are you sure you want to remove this attachment?
                                                        </h3>
                                                        <br />

                                                    </div>


                                                    <div class="modal-footer">

                                                        <asp:LinkButton runat="server" ID="lnkRemoveAttachment" CssClass="btn btn-primary btn-sm" OnClick="lnkRemoveAttachment_Click">Yes</asp:LinkButton>

                                                        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-danger btn-sm" data-dismiss="modal">No</asp:LinkButton>

                                                    </div>



                                                </div>
                                            </div>


                                        </div>

                                    </ContentTemplate>
                                           </asp:UpdatePanel>
                                       </asp:Panel>
                                 </div>

                                            </div> <%--End of Tab content--%>
                                    
                                     </div><%--End of Col-9--%>
                                  
                                 </div><%--End of Row--%>
                                    </asp:Panel>
                                    </div>
                                <%--End of Manage TAB--%>

                               

                            </div>
                            <!-- End of Tab Content-->



                        </div>

                    </div>

                    </a>

                </asp:Panel>

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






            </div>


              <!--PROMPT USER SELECTION -->
        

        
        </ContentTemplate>

       
        
    </asp:UpdatePanel>

         <asp:UpdateProgress id="upgLoading" runat="server" AssociatedUpdatePanelID="uplMain">
                    <ProgressTemplate>
                        <div id="overlay">
                            <div id="modalProgress">
                                <div id="theProgress">
                                    <img src="images/loading2.gif" alt="Loading..." />
                                </div>
                            </div>
                        </div>
                        
                    </ProgressTemplate>
                </asp:UpdateProgress>

    
                              
<%--</div>--%>
  </asp:Content>
