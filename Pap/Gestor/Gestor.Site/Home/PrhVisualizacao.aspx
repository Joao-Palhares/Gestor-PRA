<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="PrhVisualizacao.aspx.cs" Inherits="Gestor.Site.Home.Visualização" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hiddenid_prh" runat="server" />
    <div id="content-page">
        <br />
        <h1>Prenchimento de Prh</h1>

         
        <br />
        <br />
        <br />
        <h3><b><u>Identificação do Aluno:</u></b></h3>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style52"><b>
                    <asp:Label Text="Nome do Aluno: " runat="server" /></b><asp:TextBox ID="tbaluno" ReadOnly="True" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="800px" /></td>
                

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
                    <asp:TextBox ID="tbanoletivo" BorderWidth="3" BorderColor="SlateGray" ReadOnly="true" class="form-control" runat="server" Width="800px" /></td>
                
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
                <td class="auto-style20"><b>
                    <asp:Label Text="Turma: " runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbturma" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" ReadOnly="True" Width="800px" /></td>
            </tr>
        </table>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style20"><b>
                    <asp:Label Text="Disciplina: " runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbdisciplina" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" ReadOnly="True" Width="800px" /></td>
            </tr>
        </table>

        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style13"><b>
                    <asp:Label ID="lbnum" Text="Número de tempos (45 minutos) em falta devidamente justificadas " runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbntempos" BorderWidth="3" BorderColor="SlateGray" ReadOnly="true" class="form-control" runat="server" Width="800px" /></td>
                
            </tr>
        </table>
        <br />
        <br />
        <h3><b><u><asp:Label ID="lbmod" Text="Modalidade Adotada:" runat="server" /></u></b></h3>
        <table class="auto-style3">
            <tr>
                <td class="auto-style5">
                    <asp:CheckBox ID="cbmodalidadeea" Enabled="false" ValidationGroup="cbgroup"  borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="lbesac" Text="Estudo acompanhado." runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:CheckBox ID="cbmodalidadertp" Enabled="false" ValidationGroup="cbgroup"  borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="lbrtp" Text="Realização de trabalhos práticos." runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style62">
                    <asp:CheckBox ID="cbmodalidaderafal" Enabled="false" ValidationGroup="cbgroup"  borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style63">
                    <asp:Label ID="lbrafal" Text="Recuperação das aulas fora das atividades letivas." runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:CheckBox ID="cbmodalidaderot" Enabled="false" ValidationGroup="cbgroup" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="lbrot" Text="Relatórios ou outros trabalhos." runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:CheckBox ID="cbmodalidadeo" Enabled="false" ValidationGroup="cbgroup" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="lbot" Text="Outra(s): " runat="server" /></td>
                <td>
                    <asp:TextBox ID="tbmodalidadesoutras" ReadOnly="true" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="402px" Height="34px" /></td>

            </tr>
        </table>
        <br />
        <br />
        <h3><b><u><asp:Label ID="lbda" Text="Descrição da Atividade:" runat="server" /></u></b></h3>
        
        <table class="auto-style61">
            <tr>
                <td><b><asp:Label ID="lbati" Text="Atividade(s)" runat="server" /></b></td>
            </tr>
        <tr><td class="auto-style55"><asp:TextBox id="tbatividades" TextMode="MultiLine" ReadOnly="true" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="625px" Height="146px" /></td>
        </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="auto-style55"><b><asp:Label ID="lblocal" Text="Local" runat="server" /></b></td>
            </tr>
            <tr>
                <td class="auto-style55"><asp:TextBox id="tblocal1" BorderWidth="3" ReadOnly="true" BorderColor="SlateGray" class="form-control" runat="server" Width="625px" />
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <th colspan="2" class="auto-style23">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbrp" Text="Realizada(s) no período" runat="server" /></th>
            </tr>
            <tr>
                <th scope="col" class="auto-style65">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbinicio" Text="Inicio" runat="server" /></th>
                <th scope="col" class="auto-style64">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbfim" Text="Fim" runat="server" /></th>
            </tr>
            <tr>
            <td class="auto-style65">
                    <asp:TextBox ID="tbinicio" TextMode="Date" ReadOnly="true" BorderWidth="3" BorderColor="SlateGray" class="form-control" runat="server" Width="207px" />
                </td>
                <td class="auto-style64">
                    <asp:TextBox ID="tbfim" BorderWidth="3" ReadOnly="true" TextMode="Date" BorderColor="SlateGray" class="form-control" runat="server" Width="217px" /></td>         
                </tr>
        </table>
        <br />
        <h3><b><u><asp:Label ID="lbcumprimento" Text="Cumprimento das Atividades:" runat="server" /></u></b></h3>
        <table class="auto-style3">
        <tr>
                <td class="auto-style62">
                    <asp:CheckBox ID="cbcumpriu" Enabled="false" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style63">
                    <asp:Label ID="lbcumpriu" Text="Cumpriu." runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:CheckBox ID="cbncumpriu" Enabled="false" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="lbncumpriu" Text="Não Cumpriu." runat="server" /></td>
            </tr>
        </table><br />
        <br />
        <h3><b><u><asp:Label ID="lbat" Text="Avaliação da Atividade:" runat="server" /></u></b></h3>

        <table class="auto-style3">
            <tr>
                <td class="auto-style6">
                    <asp:TextBox ID="tbavaliaçaoatividade" ReadOnly="true" runat="server" Height="109px" Width="769px" BorderWidth="3" BorderColor="SlateGray" class="form-control" /></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <h3><b><u><asp:Label ID="lbfd" Text="Faltas Desconsideradas:" runat="server" /></u></b></h3>
        <table class="auto-style3">
            <tr>
                <td class="auto-style6">
                    <asp:TextBox ID="tbfaltasdesconsideradas" BorderWidth="3" BorderColor="SlateGray" class="form-control" ReadOnly="true" runat="server" Height="109px" Width="769px" /></td>
            </tr>
        </table>
        <br />
        <br />
        <h3><b><u><asp:Label ID="lbd" Text="Decisão:" runat="server" /></u></b></h3>
        <table>
            <tr>
                <th rowspan="1" colspan="1" class="auto-style36"><asp:Label ID="lboa" Text="O Aluno," runat="server" /></th>
                <th rowspan="1" colspan="1"><asp:Label ID="lbaal" Text="AE Amato Lusitano, " runat="server" /></th>
            </tr>
            <tr>
                <td class="auto-style36">
                    <asp:TextBox runat="server" ReadOnly="true" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="tbdecisaoaluno" Width="159px" />
                </td>

                <td>
                    <asp:TextBox runat="server"  BorderWidth="3" BorderColor="SlateGray" class="form-control" ReadOnly="true" TextMode="Date" ID="dataassaluno" Width="183px" /></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <th rowspan="1" colspan="1" class="auto-style36"><asp:Label ID="lbop" Text="O Professor, " runat="server" /></th>
                <th rowspan="1" colspan="1"><asp:Label ID="lbaal2" Text="AE Amato Lusitano, " runat="server" /></th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ReadOnly="true" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="tbdecisaoprofessor" Width="159px" />
                </td>
                <td>
                    <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" TextMode="Date" ReadOnly="true" ID="dataassprof" Width="183px" /></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <th rowspan="1" colspan="1" class="auto-style36"><asp:Label ID="lbodt" Text="O Diretor de Turma, " runat="server" /></th>
                <th rowspan="1" colspan="1"><asp:Label ID="lbaal3" Text="AE Amato Lusitano, " runat="server" /></th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ReadOnly="true" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="tbdecisaodt" Width="159px" />
                </td>
                <td>
                    <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" TextMode="Date" ReadOnly="true" ID="dataassdt" Width="183px" /></td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr class="form-group">
                <td>
                    <asp:Button ID="bsair" OnClick="bsair_Click" Text="Sair" Class="btn btn-secondary" CausesValidation="false" runat="server" /></td>

            </tr>
        </table>
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>
