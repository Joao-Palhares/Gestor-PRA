<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="RegisterCursos.aspx.cs" Inherits="Gestor.Site.Administration.RegisterCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 586px
        }
    </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
    <br />
        <h1>Registo de Cursos</h1>
        <br /><br /><br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <asp:Label Text="Nome do Curso:" runat="server" /></td></tr><tr>
            <td class="auto-style1">
                <asp:TextBox ID="tbnomecurso" class="form-control" placeholder="Nome do Curso" runat="server" Width="755px" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbnomecursova" ForeColor="Red" ControlToValidate="tbnomecurso" Font-Bold="true" Text="*" ErrorMessage="É necessário o nome do curso" /></td>
        </tr>
        </table>
        <br />
        <table>
        <tr>
            <td class="auto-style1"><b>
                <asp:Label Text="Diretor do Curso: " runat="server" /></b></td></tr><tr><td><asp:DropDownList ID="ddlprofessores" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="783px" >
                </asp:DropDownList></td><td class="auto-style1">
                <asp:RequiredFieldValidator runat="server" ID="ddlprofessoresva" ForeColor="Red" ControlToValidate="ddlprofessores" Font-Bold="true" Text="*" ErrorMessage="É necessária o Diretor do curso!" /></td></tr>
        <tr class="form-group">
            <td colspan="3">
                <asp:Label ID="lbmensagem" Font-Bold="true" ForeColor="Red" Text="" runat="server" /></td>
        </tr>
            </table>
        <br />
        <table>
        <tr class="form-group">
            <td class="auto-style1">
                <asp:Button ID="bregistar" Text="Registar" Class="btn btn-black" OnClick="bregistar_Click" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bcancelar" Text="Cancelar" Class="btn btn-secondary" CausesValidation="false" OnClick="bcancelar_Click" runat="server" /></td>
            
        </tr>
    </table>
        </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>
