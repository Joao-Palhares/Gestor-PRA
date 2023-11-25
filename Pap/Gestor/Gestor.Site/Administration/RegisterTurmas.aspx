<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="RegisterTurmas.aspx.cs" Inherits="Gestor.Site.Administration.RegisterTurmas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <br />
        <h1>Registo de Turmas</h1>
        <br /><br /><br />
    <table>
        
        <tr>
            <td class="auto-style1"><b>
                <asp:Label Text="Curso: " runat="server" /></b></td></tr><tr><td><asp:DropDownList ID="ddlcursos" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="783px" >
                </asp:DropDownList></td><td class="auto-style1">
                <asp:RequiredFieldValidator runat="server" ID="ddlcursosva" ForeColor="Red" ControlToValidate="ddlcursos" Font-Bold="true" Text="*" ErrorMessage="É necessária o Diretor do curso!" /></td></tr>
        </table>
    <br /><br />
        
            <asp:Label Text="Dica: Coloque no nome da turma o ano da turma tambem. Exemplo: 12º Programação." Font-Size="Smaller" runat="server" />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <b>Nome da Turma:</b></td></tr><tr>
            <td class="auto-style1">
                <asp:TextBox ID="tbnometurma" BorderWidth="3" BorderColor="SlateGray" class="form-control" placeholder="Nome da Turma" runat="server" Width="755px" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbnometurmava" ForeColor="Red" ControlToValidate="tbnometurma" Font-Bold="true" Text="*" ErrorMessage="É necessário o nome da turma" /></td>
        </tr>
        </table>
    <br />
    <table>
        <tr class="form-group">
            <td class="auto-style1">
                <b>Ano de Escolaridade:</b></td></tr><tr>
            <td class="auto-style1">
                <asp:TextBox ID="tbanoescolaridade" BorderWidth="3" BorderColor="SlateGray" TextMode="Number" class="form-control" placeholder="Ano de Escolaridade" runat="server" Width="755px" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="tbanoescolaridadeva" ForeColor="Red" ControlToValidate="tbanoescolaridade" Font-Bold="true" Text="*" ErrorMessage="É necessário o ano de escolaridade" /></td>
        </tr>
        </table>
    <br />
    <br />
    <table>
        <tr class="form-group">
            <td colspan="3">
                <asp:Label ID="lbmensagem" Font-Bold="true" ForeColor="Red" Text="" runat="server" /></td>
        </tr>
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
