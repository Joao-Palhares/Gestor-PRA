<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="RegisterProf.aspx.cs" Inherits="Gestor.Site.Administration.RegisterProf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 559px;
        }
        .auto-style4 {
            width: 178px;
            height: 48px;
        }
        .auto-style5 {
            width: 30px;
        }
        </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <br />
        <h1>Registo de Professores</h1>
        <br /><br /><br />
    <table>
        <tr class="form-group">
            <td class="auto-style1"><b>
                Username:</b></td>
            </tr><tr>
            <td class="auto-style1">
                <asp:TextBox ID="tbusername"  BorderWidth="3" BorderColor="SlateGray"  class="form-control" placeholder="username" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbusernameva" ForeColor="Red" ControlToValidate="tbusername" Font-Bold="true" Text="*" ErrorMessage="É necessário o username" /></td>
        </tr>
        </table>
    <br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <b>Password:</b></td></tr><tr>
            <td>
                <asp:TextBox ID="tbpassword"  BorderWidth="3" BorderColor="SlateGray"  placeholder="password" class="form-control" TextMode="Password" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbpasswordva" ForeColor="Red" ControlToValidate="tbpassword" Font-Bold="true" Text="*" ErrorMessage="É necessária a password" /></td>
        </tr>
        </table>
    <br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <b>Confirme a password:</b></td></tr><tr>
            <td>
                <asp:TextBox ID="tbconfirm"  BorderWidth="3" BorderColor="SlateGray"  placeholder="password" class="form-control" TextMode="Password" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbconfirmva" ForeColor="Red" ControlToValidate="tbconfirm" Font-Bold="true" Text="*" ErrorMessage="É necessária a password de confimação" /></td>
            <td>
                <asp:CompareValidator ID="cmppass" Text="*" ErrorMessage="Password incompativél" Operator="Equal" ForeColor="red" Font-Bold="true" ControlToValidate="tbpassword" ControlToCompare="tbconfirm" runat="server" /></td>
        </tr>
        </table>
    <br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
               <b> Email:</b></td></tr><tr>
            <td>
                <asp:TextBox ID="tbemail"  BorderWidth="3" BorderColor="SlateGray"  placeholder="email" class="form-control" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbemailva" ForeColor="Red" ControlToValidate="tbemail" Font-Bold="true" Text="*" ErrorMessage="É necessário o email" /></td>
        </tr>
        </table>
    <br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <b>Nome Completo:</b></td></tr><tr>
            <td>
                <asp:TextBox ID="tbnomecompleto" BorderWidth="3" BorderColor="SlateGray"  placeholder="Nome Completo" class="form-control" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbvanomecompleto" ForeColor="Red" ControlToValidate="tbnomecompleto" Font-Bold="true" Text="*" ErrorMessage="É necessário o nome completo" /></td>
        </tr>
        </table>
    <br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <b>Data de Nascimento:</b></td></tr><tr>
            <td class="auto-style1">
                <asp:TextBox ID="tbdatanascimento" BorderWidth="3" BorderColor="SlateGray"  TextMode="Date" placeholder="Data de Nascimento" class="form-control" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbvadatanascimento" ForeColor="Red" ControlToValidate="tbdatanascimento" Font-Bold="true" Text="*" ErrorMessage="É necessária a data de nascimento" /></td>
        </tr>
        </table>
    <br />
    <table>
            <tr>
                <td class="auto-style4" ><b>É Diretor de Turma?</b></td></tr>
        </table>
        <table>
        <tr>
                <td class="auto-style5">
                    <asp:CheckBox ID="cbdtsim" OnCheckedChanged="cbdtsim_CheckedChanged" class="form-control" CssClass="form-control" AutoPostBack="true" runat="server" />
                    
                    </td><td><b><asp:Label Text="Sim" runat="server" /></b></td></tr><tr>
                <td class="auto-style5">
                    <asp:CheckBox ID="cbdtnao" OnCheckedChanged="cbdtnao_CheckedChanged" class="form-control" CssClass="form-control" AutoPostBack="true" runat="server" />

                </td><td><b><asp:Label Text="Não" runat="server" /></b></td>
                    </tr>
            </table>
        <br />
        <table>
            <tr>
                
                <td><b><asp:Label ID="lbturma" Text="Turma" runat="server" /></b></td></tr><tr><td><asp:DropDownList ID="ddlturmas" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="799px">
                    </asp:DropDownList></td>
            </tr>
        </table>
    <br />
    <table>
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
            <td class="auto-style1">
                <asp:Button ID="bregistar" Text="Registar" Class="btn btn-black" OnClick="bregistar_Click" runat="server" /></td>
            <td>
                <asp:Button ID="bcancelar" Text="Cancelar" Class="btn btn-secondary" CausesValidation="false" OnClick="bcancelar_Click" runat="server" /></td>
        </tr>
    </table>
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>
