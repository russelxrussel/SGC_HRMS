<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAttachment.aspx.cs" Inherits="DGMU_HR.EmployeeAttachment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>DGMU - Human Resource Management System</title>


    <link href="Content/bootstrap.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap.js"></script>    
</head>
<body>
    <form id="form1" runat="server">
        <br />  
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-8">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="input-group">
                            <div class="input-group-addon">
                               Attachment Title: 
                            </div>
                            <asp:TextBox runat="server" ID="txtAttachmentFileName" CssClass="form-control">

                            </asp:TextBox>
                        </div>
                    </li>
                    <li class="list-group-item">
                        
     <asp:FileUpload runat="server" ID="fuAttachment" />
    
                    </li>
                    <li class="list-group-item">
                          <asp:LinkButton runat="server" ID="lnkUploadFile" CssClass="btn btn-sm btn-warning" OnClick="lnkUploadFile_Click">Upload</asp:LinkButton>
                    </li>
                </ul>


            </div>
        </div>
  
       
     <br />
    
   
            
        
        <asp:GridView runat="server" ID="gvEmployeeAttachments" CssClass="table table-condensed table-responsive" AutoGenerateColumns="FALSE">
                                                                    <Columns>
                  <asp:BoundField DataField="EmpAttachmentID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                  <asp:BoundField DataField="Title" />
                  <asp:BoundField DataField="File_Name"/>
                  <asp:BoundField DataField="FilePath" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:LinkButton runat="server" Id="lnkDownloadAttachment" OnClick="lnkDownloadAttachment_Click" CssClass="btn btn-sm btn-primary">
                              <span class="glyphicon glyphicon-arrow-down"></span> Download
                          </asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>                                                            
    </div>
    </form>
</body>
</html>
