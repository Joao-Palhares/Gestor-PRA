<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gestor.Site.Authentication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />

</head>
<body>
    <div class="sidenav">
        <div class="login-main-text">
            <h2>PGest - Planos de Recuperação</h2>
            <p>Login</p>
        </div>
    </div>
    <div class="main">
        <div class="col-md-6 col-sm-12">
            <div class="login-form">
                <form id="form1" runat="server">
                    <table>
                        <tr class="form-group">
                            <td>
                                <asp:Label Text="Username:" runat="server" /></td>
                            <td>
                                <asp:TextBox ID="tbusername" class="form-control" placeholder="username" runat="server" /></td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="tbusernameva" ForeColor="Red" ControlToValidate="tbusername" Font-Bold="true" Text="*" ErrorMessage="É necessário o username" /></td>
                        </tr>
                        <tr class="form-group">
                            <td>
                                <asp:Label Text="Password:" runat="server" /></td>
                            <td>
                                <asp:TextBox ID="tbpassword" class="form-control" placeholder="password" TextMode="Password" runat="server" /></td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="tbpasswordva" ForeColor="Red" ControlToValidate="tbpassword" Font-Bold="true" Text="*" ErrorMessage="É necessária a password" /></td>
                        </tr>
                        <tr class="form-group">
                            <td colspan="3">
                                <asp:ValidationSummary HeaderText="Erros de Validação" ForeColor="Red" Font-Bold="true" runat="server" />
                            </td>
                        </tr>
                        <tr class="form-group">
                            <td colspan="3">
                                <asp:Label ID="lbmensagem" Font-Bold="true" ForeColor="Red" Text="" runat="server" /></td>
                        </tr>
                        <tr class="form-group">
                            <td>
                                <asp:Button ID="blogin" Text="Login" Class="btn btn-black" OnClick="blogin_Click" runat="server" /></td>
                        </tr>
                        <tr class="form-group">
                            <td colspan="3">
                                <asp:HyperLink CssClass="alert-link" ID="hyperLinkEsqueceuPassword" Text="Esqueceu-se da password?" NavigateUrl="~/PwdMgmt/NewPasswordRequest.aspx" runat="server" /></td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</body>
</html>