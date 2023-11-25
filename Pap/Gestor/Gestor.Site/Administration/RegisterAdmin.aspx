<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="RegisterAdmin.aspx.cs" Inherits="Gestor.Site.Administration.RegisterAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
    <br />
        <h1>Registo de Administradores </h1>
        <br />
        <br />
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
                <asp:TextBox ID="tbpassword" placeholder="password" class="form-control" TextMode="Password" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbpasswordva" ForeColor="Red" ControlToValidate="tbpassword" Font-Bold="true" Text="*" ErrorMessage="É necessária a password" /></td>
        </tr>
        <tr class="form-group">
            <td>
                <asp:Label Text="Confirme a password:" runat="server" /></td>
            <td>
                <asp:TextBox ID="tbconfirm" placeholder="password" class="form-control" TextMode="Password" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbconfirmva" ForeColor="Red" ControlToValidate="tbconfirm" Font-Bold="true" Text="*" ErrorMessage="É necessária a password de confimação" /></td>
            <td>
                <asp:CompareValidator ID="cmppass" Text="*" ErrorMessage="Password incompativél" Operator="Equal" ForeColor="red" Font-Bold="true" ControlToValidate="tbpassword" ControlToCompare="tbconfirm" runat="server" /></td>
        </tr>
        <tr class="form-group">
            <td>
                <asp:Label Text="Email:" runat="server" /></td>
            <td>
                <asp:TextBox ID="tbemail" placeholder="email" class="form-control" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbemailva" ForeColor="Red" ControlToValidate="tbemail" Font-Bold="true" Text="*" ErrorMessage="É necessário o email" /></td>
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
                <asp:Button ID="bregistar" Text="Registar" Class="btn btn-black" OnClick="bregistar_Click" runat="server" /></td>
            <td>
                <asp:Button ID="bcancelar" Text="Cancelar" Class="btn btn-secondary" CausesValidation="false" OnClick="bcancelar_Click" runat="server" /></td>
            
        </tr>


    </table>
        </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>
