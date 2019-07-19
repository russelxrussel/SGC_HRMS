<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/HRMS.Master"  CodeBehind="EmpData.aspx.cs" Inherits="DGMU_HR.EmpData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
 

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
                                <asp:GridView runat="server" ID="gvEmployeeList" GridLines="None" OnRowCommand="gvEmployeeList_RowCommand" AutoGenerateColumns="false" CssClass="table table-hover table-condensed table-responsive small" OnRowDataBound="gvEmployeeList_RowDataBound" ShowHeader="false">
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
                                       <%-- <asp:BoundField DataField="Date_Of_Birth" DataFormatString="{0:MM/d/yyyy}" HtmlEncode="false" />--%>
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
                                    <h4>Employee 201 Files
                                    </h4>
                                </div>
                                <div class="col-md-8 text-right">
                                    <asp:LinkButton runat="server" ID="lnkReturn" CssClass="btn btn-success btn-sm" OnClick="lnkReturn_Click">Back</asp:LinkButton>
                                </div>
                            </div>


                        </div>

                        <div class="panel-body">

                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#Basic" aria-controls="Basic" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-user text-success"></span>Basic</a> </li>
                                <li role="presentation"><a href="#Family" aria-controls="Family" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-home"></span>Family</a></li>
                                <li role="presentation"><a href="#Education" aria-controls="Education" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-book"></span>Education</a></li>
                                <li role="presentation"><a href="#SkillTraining" aria-controls="SkillTraining" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-flash"></span>Skills and Training</a></li>
                                <li role="presentation"><a href="#Evaluation" aria-controls="Evaluation" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-briefcase text-success"></span> Work Evaluation</a></li>
                                <li role="presentation"><a href="#Violation" aria-controls="Violation" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-comment text-danger"></span> Violations Record</a></li>
                           
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">

                                <div role="tabpanel" class="tab-pane fade in active" id="Basic">
                                    <br />
                                    <!-- Employee Basic Details-->



                                    <asp:Panel runat="server" ID="panelBasic">

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


                                                                        <asp:Image runat="server" ID="imgEmployeePicture" Width="120px" Height="120px" CssClass="img-thumbnail img-responsive" />
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



                                                <div class="row">
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
                                                    <div class="col-md-3">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">Government ID's</div>
                                                            <ul class="list-group">
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Tax Identification Number (TIN)</small>
                                                                    <asp:TextBox runat="server" ID="txtTinNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="TIN Number" placeholder="TIN Number"></asp:TextBox></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Social Security System Number (SSS)</small>
                                                                    <asp:TextBox runat="server" ID="txtSSSNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="SSS Number" placeholder="SSS Number"></asp:TextBox></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Home Development Mutual Fund (HDMF)</small>
                                                                    <asp:TextBox runat="server" ID="txtPagibigNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="HDMF (Pag-IBIG) No" placeholder="HDMF (Pag-IBIG) No"></asp:TextBox></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Philippine Health Insurance Corporation (PHIC)</small>
                                                                    <asp:TextBox runat="server" ID="txtPhilHealthNumber" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="PhilHealth ID" placeholder="PhilHealth ID"></asp:TextBox></li>
                                                            </ul>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">Application Details</div>
                                                            <ul class="list-group">
                                                           
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Application Date</small>
                                                                    <asp:TextBox runat="server" ID="txtApplicationDate" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Date Applied" placeholder="Application Date" TextMode="DateTime"></asp:TextBox></li>
                                                                 <li class="list-group-item">
                                                                    <small class="form-text text-muted">Job Posting</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddJobPosting" data-toggle="tooltip" data-placement="top" title="How does applicant know the job posting?"></asp:DropDownList></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Applicant Evaluation</small>
                                                                    <asp:TextBox runat="server" ID="txtApplicantEvaluation" TextMode="MultiLine" Rows="3" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Initial Applicant Evaluation" placeholder="Applicant Evaluation"></asp:TextBox>
                                                                </li>
                                                            </ul>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="panel panel-warning">
                                                            <div class="panel-heading">Employment Details</div>
                                                            <ul class="list-group">
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Company</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddCompany" data-toggle="tooltip" data-placement="top" title="Company"></asp:DropDownList></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Date Hired</small>
                                                                    <asp:TextBox runat="server" ID="txtDateHired" CssClass="form-control calendarInput " data-toggle="tooltip" data-placement="top" title="Date Hired" placeholder="Date Hired *"></asp:TextBox></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Employment Status</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddEmploymentStatus" data-toggle="tooltip" data-placement="top" title="Status"></asp:DropDownList></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Department</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddDepartment" data-toggle="tooltip" data-placement="top" title="Department"></asp:DropDownList></li>
                                                                <li class="list-group-item">
                                                                    <small class="form-text text-muted">Position</small>
                                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddPosition" data-toggle="tooltip" data-placement="top" title="Position"></asp:DropDownList></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>

                                <%--End of Basic information--%>

                                <div role="tabpanel" class="tab-pane fade" id="Family">
                                    <br />
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                        <ContentTemplate>

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
                                                    </div>

                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>



                                </div>

                                <div role="tabpanel" class="tab-pane fade" id="Education">
                                    <br />
                                     <asp:UpdatePanel runat="server" ID="updateEducation" UpdateMode="Conditional">
                                     <ContentTemplate>
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

                                        </ContentTemplate>
                                     </asp:UpdatePanel>
                                </div>
                                <%-- End of Education--%>

                               
                                 
                                <div role="tabpanel" class="tab-pane fade" id="SkillTraining">
                                    <br />
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
                                                                <small class="form-text text-muted">Skills/Training:</small>
                                                                <asp:TextBox runat="server" ID="txtSkillsTraining" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Skill / Training"></asp:TextBox></li>
                                                            <li class="list-group-item">
                                                                <small class="form-text text-muted">Name of Training Center:</small>
                                                                 <asp:TextBox runat="server" ID="txtTrainingCenterName" CssClass="form-control" data-toggle="tooltip" data-placement="top" title="Name of Training Center"></asp:TextBox></li>
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
                                                                <asp:BoundField DataField="EndTrainingDate" HeaderText="Training Date End" DataFormatString="{0:d}" />
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

                                </div>
                                <%--End of Skills and Training--%>

                                <div role="tabpanel" class="tab-pane fade" id="Evaluation">
                                    <br />
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Work Evaluation
                                        </div>
                                        <div class="panel-body">
                                          
                                        </div>
                                    </div>

                                </div>
                                <%--End of Work Evaluation--%>

                               <div role="tabpanel" class="tab-pane fade" id="Violations">
                                    <br />
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Violation Record
                                        </div>
                                        <div class="panel-body">
                                          
                                        </div>
                                    </div>

                                </div>
                             
                                 
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

    

        
        </ContentTemplate>
    </asp:UpdatePanel>
<%--</div>--%>
  </asp:Content>
