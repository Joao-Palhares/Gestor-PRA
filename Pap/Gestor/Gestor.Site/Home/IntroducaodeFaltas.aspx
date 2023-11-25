<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="IntroducaodeFaltas.aspx.cs" Inherits="Gestor.Site.Home.IntroducaodeFaltas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 559px;
        }

        .auto-style6 {
            font-weight: bold;
        }
    </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <br />
        <h1>Introdução de faltas</h1>
        <br />
        <br />
        <br />
        <table>
            <tr class="form-group">
                <td class="auto-style1"><span class="auto-style6">Turma</span><b>:</b></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlturmas" BorderWidth="3" OnSelectedIndexChanged="ddlturmas_SelectedIndexChanged" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="799px">
                    </asp:DropDownList>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddlturmasva" ForeColor="Red" ControlToValidate="ddlturmas" Font-Bold="true" Text="*" ErrorMessage="É necessário a turma" /></td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr class="form-group">
                <td class="auto-style1">
                    <b>Disciplina:</b></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddldisciplinas" BorderWidth="3" OnSelectedIndexChanged="ddldisciplina_SelectedIndexChanged" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="799px">
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddldisciplinava" ForeColor="Red" ControlToValidate="ddldisciplina" Font-Bold="true" Text="*" ErrorMessage="É necessária a disciplina" /></td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr class="form-group">
                <td class="auto-style1">
                    <b>Aluno:</b></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlalunos" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="799px">
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddlalunosva" ForeColor="Red" ControlToValidate="ddlalunos" Font-Bold="true" Text="*" ErrorMessage="É necessário o aluno" /></td>

            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr class="form-group">
                <td class="auto-style1">
                    <b>Tempo Letivo:</b></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddltemplet" BorderWidth="3" BorderColor="SlateGray" class="form-control" Width="799px" AutoPostBack="True" OnSelectedIndexChanged="Selection_Change" runat="server">

                        <asp:ListItem Value="1"> 08:30 - 09:15 | 1º Tempo</asp:ListItem>
                        <asp:ListItem Value="2"> 09:15 - 10:00 | 2º Tempo</asp:ListItem>
                        <asp:ListItem Value="3"> 10:25 - 11:10 | 3º Tempo</asp:ListItem>
                        <asp:ListItem Value="4"> 11:10 - 11:55 | 4º Tempo</asp:ListItem>
                        <asp:ListItem Value="5"> 12:05 - 12:50 | 5º Tempo</asp:ListItem>
                        <asp:ListItem Value="6"> 12:50 - 13:35 | 6º Tempo</asp:ListItem>
                        <asp:ListItem Value="7"> 13:35 - 14:20 | 7º Tempo</asp:ListItem>
                        <asp:ListItem Value="8"> 14:20 - 15:05 | 8º Tempo</asp:ListItem>
                        <asp:ListItem Value="9"> 15:10 - 15:55 | 9º Tempo</asp:ListItem>
                        <asp:ListItem Value="10"> 15:55 - 16:40 | 10º Tempo</asp:ListItem>
                        <asp:ListItem Value="11"> 16:50 - 17:35 | 11º Tempo</asp:ListItem>
                        <asp:ListItem Value="12"> 17:35- 18:20 | 12º Tempo</asp:ListItem>

                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddltempletva" ForeColor="Red" ControlToValidate="ddltemplet" Font-Bold="true" Text="*" ErrorMessage="É necessário o Tempo Letivo" /></td>
            </tr>
        </table>
        <br />
        <br />
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

