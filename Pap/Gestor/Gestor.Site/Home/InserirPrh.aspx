<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="InserirPrh.aspx.cs" Inherits="Gestor.Site.Home.InserirPrh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 900px;
        }

        .auto-style20 {
            width: 352px;
        }

        .auto-style52 {
            width: 551px;
        }

        .auto-style53 {
            width: 531px;
        }
    </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hiddenid_prh" runat="server" />
    <div id="content-page">
        <br />
        <h1>Inserção de Prh </h1>
        <br />
        <br />
        <br />
        <h3><b><u>Identificação dos membros participantes:</u></b></h3>
        <br />
        <table>
            <tr>
                <td><b>Turma:</b>
                    <asp:TextBox ID="tbturma" BorderWidth="3" BorderColor="SlateGray" class="form-control" ReadOnly="True" runat="server" Width="800px" /></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="auto-style52"><b>
                    <asp:Label Text="Disciplina: " runat="server" /></b><asp:DropDownList ID="ddldisciplinas" BorderWidth="3" OnSelectedIndexChanged="ddldisciplinas_SelectedIndexChanged" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="799px">
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddldisciplinasva" ForeColor="Red" ControlToValidate="ddldisciplinas" Font-Bold="true" Text="*" ErrorMessage="É necessária a disciplina!" /></td>
            </tr>
        </table>
        <br />

        <table>
            <tr>
                <td><b>Professor</b><asp:DropDownList ID="ddlprofessores" BorderWidth="3" OnSelectedIndexChanged="ddlprofessores_SelectedIndexChanged" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" Width="799px">
                </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddlprofessoresva" ForeColor="Red" ControlToValidate="ddlprofessores" Font-Bold="true" Text="*" ErrorMessage="É necessário o professor!" /></td>
            </tr>
        </table>
        
        <br />
        <br />
        <h3><b><u>Identificação do Aluno:</u></b></h3>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style52"><b>
                    <asp:Label Text="Nome do Aluno: " runat="server" /></b><asp:DropDownList ID="ddlalunos" BorderWidth="3" BorderColor="SlateGray" class="form-control" OnSelectedIndexChanged="ddlalunos_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="799px">
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="ddlalunosva" ForeColor="Red" ControlToValidate="ddlalunos" Font-Bold="true" Text="*" ErrorMessage="É necessário o aluno!" /></td>

            </tr>
        </table>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style20"><b>
                    <asp:Label Text="Nº: " runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbnaluno" ReadOnly="True" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="800px" /></td>
            </tr>
        </table>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style20"><b>
                    <asp:Label Text="Ano Letivo: " runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbanoletivo" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="800px" /></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="tbvaanoletivo" ForeColor="Red" ControlToValidate="tbanoletivo" Font-Bold="true" Text="*" ErrorMessage="É necessário o ano letivo!" /></td>
            </tr>
        </table>
        <br />

        <table class="auto-style3">
            <tr>
                <td class="auto-style20"><b>
                    <asp:Label Text="Curso: " runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbcurso" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" ReadOnly="True" Width="800px" /></td>
            </tr>
        </table>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style53"><b>
                    <asp:Label Text="Número de tempos (45 minutos) em falta devidamente justificadas: " runat="server" /></b></td>
            </tr>
            <tr>
                <td class="auto-style53">
                    <asp:TextBox ID="tbntempos" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="800px" /></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="tbntemposva" ForeColor="Red" ControlToValidate="tbntempos" Font-Bold="true" Text="*" ErrorMessage="É necessário o ano letivo!" /><asp:RequiredFieldValidator runat="server" ID="tbntemposva1" ForeColor="Red" ControlToValidate="tbntempos" Operator="DataTypeCheck" Type="Integer" Font-Bold="true" Text="*" ErrorMessage="A indicação dos tempos letivos tem de ser por numero!" /></td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr class="form-group">
                <td>
                    <asp:Button ID="binserir" Text="Inserir" Class="btn btn-black" OnClick="binserir_Click" runat="server" /></td>
                <td>
                    <asp:Button ID="bcancelar" Text="Cancelar" Class="btn btn-secondary" OnClick="bcancelar_Click" CausesValidation="false" runat="server" /></td>

            </tr>
        </table>
                            <asp:TextBox ID="tbmod" ReadOnly="True" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="800px" />

    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>
