<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePictureAttachment.aspx.cs" Inherits="DGMU_HR.EmployeePictureAttachment" %>

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
                        
         <asp:FileUpload runat="server" ID="fuAttachment" />
    
                        </li>
                        <li class="list-group-item">
                              <asp:LinkButton runat="server" ID="lnkUploadFile" CssClass="btn btn-sm btn-warning" OnClick="lnkUploadFile_Click">Upload</asp:LinkButton>
                        </li>
                    </ul>


                </div>
            </div>
  
       
         <br />
    
   
            
        
                                                            
        </div>
    </form>
</body>
</html>
