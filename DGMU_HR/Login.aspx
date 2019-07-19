<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DGMU_HR.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DGMU - Human Resources Management System</title>

    <style type="text/css">
        .centeredBox {
            /*background-color: #ff0000;*/
            position: absolute;
            width: 600px;
            height: 400px;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);

        }

       
     
        .bg_transparent {
            opacity: .7;
           
        }

        .bg_transparent:hover {
            opacity: 1.0;
          
        }
    
        html {
        height: 100%;
        }
        body {
            height: 100%;
            background-size: auto 100%;
            background-repeat: no-repeat;
            background-image: linear-gradient(to bottom right, skyblue , green); /* Standard syntax (must be last) */
        }

        li.borderless {
            border: 0 none;
        }
    </style>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />


     <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="bg">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upLogin">
        <ContentTemplate>

            <div class="centeredBox">
      
                 <div class="panel panel-info">
            <div class="panel-heading">
                 <div class="text-center">
                 <img src="images/DGMU.PNG" width="200px" height="100px"/>
                    </div>
                </div>
            <div class="panel-body">
               <%-- <strong>User Login</strong>--%>
                <ul class="list-group">
                    <li class="list-group-item borderless">
                        <div class="input-group">
                         <span class="input-group-addon alert-info"><span class="glyphicon glyphicon-user"></span></span>
                        <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Username"></asp:TextBox> 
                        </div>
                        </li>
                    <li class="list-group-item borderless">
                        <div class="input-group">
                         <span class="input-group-addon alert-info"><span class="glyphicon glyphicon-inbox"></span></span>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </li>   
                    <li class="list-group-item borderless text-right">
                                <asp:LinkButton runat="server" ID="lnkLogin" CssClass="btn btn-sm btn-primary" OnClick="lnkLogin_Click"><span class="glyphicon glyphicon-log-in"></span> Login</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div class="panel-footer">
                <p class="small text-muted" style="font-size: 12px;"><i>DGMU - Human Resources Management System</i></p>
            </div>
        </div>
               
        </div>

           <div class="modal fade" id="msgErrorModal">
                                      <div class="modal-dialog">
                                          <div class="modal-content">
                                              <div class="modal-header bg-danger">
                                                  <button class="close" data-dismiss="modal">
                                                      &times;</button>
                                                  <h4 class="modal-title">DGMU - Human Resources Management System</h4>
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

    </div>
    </form>
</body>
</html>
