<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="PraPreenchimento.aspx.cs" Inherits="Gestor.Site.Home.PraPreenchimento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .auto-style2 {
            width: 57px;
        }

        .auto-style3 {
            width: 789px;
        }

        .auto-style6 {
            width: 615px;
        }

        .auto-style7 {
            width: 225px;
        }

        .auto-style8 {
            width: 195px;
        }

        .auto-style12 {
            width: 65px;
        }
        
        .auto-style19 {
            width: 432px;
        }

        .auto-style20 {
            width: 478px;
        }

        .auto-style21 {
            width: 200px;
        }

        .auto-style22 {
            width: 20px;
        }

        .auto-style23 {
            width: 241px;
        }

        .auto-style25 {
            width: 852px;
        }

        .auto-style26 {
            width: 147px;
        }

        .auto-style27 {
            width: 107px;
        }
        .auto-style28 {
            width: 1163px;
        }
        .auto-style29 {
            width: 131px;
        }
        .auto-style30 {
            width: 135px;
        }
        .auto-style31 {
            width: 68px;
        }
        .auto-style32 {
            width: 137px;
        }
        
        .auto-style34 {
            width: 215px;
        }

        .auto-style35 {
            width: 41px;
        }

        .auto-style36 {
            width: 162px;
        }

        </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hiddenid_pra" runat="server" />
    <div id="content-page">
    <br />
    <h1>Prenchimento de Pra</h1>
        <br />
    <br />
    <br />
            <h3><b><u><asp:Label ID="lbdmtt" Text="Disciplina(S)/ Módulo(S):" runat="server" /></u></b></h3>
        <asp:Label ID="lbendr" Text="Escolha o numero de disciplinas para recuperar" runat="server" />
        <br />
        <asp:DropDownList id="ndisciplinas" AutoPostBack="True" BorderWidth="3" BorderColor="SlateGray" class="form-control" OnSelectedIndexChanged="ndisciplinas_SelectedIndexChanged" runat="server" Width="509px">

                  <asp:ListItem Value="1"> 1 </asp:ListItem>
                  <asp:ListItem Value="2"> 2 </asp:ListItem>
                  <asp:ListItem Value="3"> 3 </asp:ListItem>
                  <asp:ListItem Value="4"> 4 </asp:ListItem>
                  <asp:ListItem Value="5"> 5 </asp:ListItem>

               </asp:DropDownList>
        <br />
    <table class="auto-style28">
        <colgroup span="1"></colgroup>
        <colgroup span="1"></colgroup>
        <colgroup span="1"></colgroup>
        <colgroup span="1"></colgroup>
        <colgroup span="1"></colgroup>
        <tbody>
            <tr>
                <th rowspan="2" class="auto-style29" >&nbsp;<asp:Label ID="lbdis" Text="Disciplina(s)" runat="server" />  </th>
                <th rowspan="2" class="auto-style27" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbmod" Text="Módulo" runat="server" />  </th>
                <th rowspan="2" class="auto-style36" >&nbsp;&nbsp;&nbsp;<asp:Label ID="lbfe" Text="Faltas em" runat="server" /> <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbe" Text="excesso" runat="server" /> </th>
                <th colspan="1" rowspan="2" scope="colgroup" class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbassi" Text="Assinatura" runat="server" /> </th>
                <th colspan="1" rowspan="2" scope="colgroup" class="auto-style30">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbda" Text="Data" runat="server" /> </th>
                <th colspan="2" scope="colgroup">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbava" Text="Avaliação" runat="server" /> </th>
                <th colspan="2" rowspan="2" class="auto-style2"><asp:Label ID="lbret" Text="Retido/" runat="server" /> <br />
                    <asp:Label ID="lbexcl" Text="Excluído" runat="server" /></th>
            </tr>
            <tr>
                <th scope="col" class="auto-style31">&nbsp;<asp:Label ID="lbsatis" Text="Satisfaz" runat="server" /> </th>
                <th scope="col" class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbnsatis" Text="Não Satisfaz" runat="server" /> </th>
            </tr>
            <tr>
                <td class="auto-style29">
                    <asp:DropDownList ID="ddldisciplina1" BorderWidth="3" Visible="false" Enabled="false" BorderColor="SlateGray" class="form-control" OnSelectedIndexChanged="ddldisciplina1_SelectedIndexChanged" AutoPostBack="true" runat="server" >
                    </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbdisciplina1" Width="266px"/></td>
                <td class="auto-style27">
                    <asp:DropDownList ID="ddlmodulo1" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbmodulo1" Width="266px"/>
                </td>
                <td class="auto-style36">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbfaltasexcesso1" /></td>
                <td class="auto-style32">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbassprofdisci1" /></td>
                <td class="auto-style30">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" Text="" TextMode="Date" ID="tbdataassprof1" /></td>
                <td class="auto-style31">
                    <asp:CheckBox ID="cbsat1" value="Satisfaz" class="form-control" OnCheckedChanged="cbsat1_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style12">
                    <asp:CheckBox ID="cbnsat1" value="Não Satisfaz" class="form-control" OnCheckedChanged="cbnsat1_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style2">
                    <asp:CheckBox ID="cbexcluido1" class="form-control" OnCheckedChanged="cbexcluido1_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style29">
                    <asp:DropDownList ID="ddldisciplina2" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" class="form-control" OnSelectedIndexChanged="ddldisciplina2_SelectedIndexChanged" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbdisciplina2" Width="266px"/></td>
                <td class="auto-style27">
                    <asp:DropDownList ID="ddlmodulo2" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbmodulo2" Width="266px"/></td>
                <td class="auto-style36">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbfaltasexcesso2" /></td>
                <td class="auto-style32">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbassprofdisci2" /></td>
                <td class="auto-style30">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" Text="" TextMode="Date" ID="tbdataassprof2"  /></td>
                <td class="auto-style31">
                    <asp:CheckBox ID="cbsat2" value="Satisfaz" class="form-control" OnCheckedChanged="cbsat2_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style12">
                    <asp:CheckBox ID="cbnsat2" value="Não Satisfaz" class="form-control" OnCheckedChanged="cbnsat2_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style2">
                    <asp:CheckBox ID="cbexcluido2" class="form-control" OnCheckedChanged="cbexcluido2_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style29">
                    <asp:DropDownList ID="ddldisciplina3" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" OnSelectedIndexChanged="ddldisciplina3_SelectedIndexChanged" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbdisciplina3" Width="266px"/></td>
                <td class="auto-style27">
                    <asp:DropDownList ID="ddlmodulo3" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbmodulo3" Width="266px"/></td>
                <td class="auto-style36">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbfaltasexcesso3"  /></td>
                <td class="auto-style32">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbassprofdisci3"  /></td>
                <td class="auto-style30">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" Text="" TextMode="Date" ID="tbdataassprof3"  /></td>
                <td class="auto-style31">
                    <asp:CheckBox ID="cbsat3" value="Satisfaz" class="form-control" OnCheckedChanged="cbsat3_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style12">
                    <asp:CheckBox ID="cbnsat3" value="Não Satisfaz" class="form-control" OnCheckedChanged="cbnsat3_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style2">
                    <asp:CheckBox ID="cbexcluido3" class="form-control" OnCheckedChanged="cbexcluido3_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style29">
                    <asp:DropDownList ID="ddldisciplina4" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" OnSelectedIndexChanged="ddldisciplina4_SelectedIndexChanged" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbdisciplina4" Width="266px"/></td>
                <td class="auto-style27">
                    <asp:DropDownList ID="ddlmodulo4" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbmodulo4" Width="266px"/></td>
                <td class="auto-style36">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbfaltasexcesso4"  /></td>
                <td class="auto-style32">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbassprofdisci4"  /></td>
                <td class="auto-style30">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" Text="" TextMode="Date" ID="tbdataassprof4"  /></td>
                <td class="auto-style31">
                    <asp:CheckBox ID="cbsat4" value="Satisfaz" class="form-control" OnCheckedChanged="cbsat4_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style12">
                    <asp:CheckBox ID="cbnsat4" value="Não Satisfaz" class="form-control" OnCheckedChanged="cbnsat4_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style2">
                    <asp:CheckBox ID="cbexcluido4" class="form-control" OnCheckedChanged="cbexcluido4_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style29">
                    <asp:DropDownList ID="ddldisciplina5" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" OnSelectedIndexChanged="ddldisciplina5_SelectedIndexChanged" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbdisciplina5" Width="266px"/></td>
                <td class="auto-style27">
                    <asp:DropDownList ID="ddlmodulo5" Visible="false" Enabled="false" BorderWidth="3" BorderColor="SlateGray" class="form-control" AutoPostBack="true" runat="server" >
                </asp:DropDownList><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" class="form-control" ID="tbmodulo5" Width="266px"/></td>
                <td class="auto-style36">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbfaltasexcesso5"  /></td>
                <td class="auto-style32">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbassprofdisci5"  /></td>
                <td class="auto-style30">
                    <asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" Text="" TextMode="Date" ID="tbdataassprof5"  /></td>
                <td class="auto-style31">
                    <asp:CheckBox ID="cbsat5" value="Satisfaz" class="form-control" OnCheckedChanged="cbsat5_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style12">
                    <asp:CheckBox ID="cbnsat5" value="Não Satisfaz" class="form-control" OnCheckedChanged="cbnsat5_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
                <td class="auto-style2">
                    <asp:CheckBox ID="cbexcluido5" class="form-control" OnCheckedChanged="cbexcluido5_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" /></td>
            </tr>

        </tbody>
    </table>
        <table>
            <tr>
                <td>
                <asp:Button ID="binserir1" Text="Inserir" Class="btn btn-black" OnClick="binserir1_Click" runat="server" /></td>
        </tr><tr><td>
                <asp:Button ID="binserir2" Text="Inserir" Class="btn btn-black" OnClick="binserir2_Click" runat="server" /></td>
            </tr>
        </table>
    <br />
        <br />
    <br />

    <h3><b><u><asp:Label ID="titmraiec" Text="Medidas de Recuperação das Aprendizagens e ou de Integração Escolar e Comunitária" runat="server" /> </u></b></h3>
        <br />
        <br /><table>
         <tr> <td><b>
             <asp:Label ID="lbeee" Text="Email Do Encarregado de Educação" runat="server" /> </b></td>
             <td><asp:TextBox ID="tbeee" class="form-control" BorderWidth="3" BorderColor="SlateGray" runat="server" Height="27px" Width="696px" /></td>
         </tr></table>
    <br />
    <table class="auto-style25">
        <tr>
            <td class="auto-style34"><b>
                <asp:Label ID="lbrnp" Text="Realizadas no período de:" runat="server" /> </b></td><td class="auto-style23"><asp:TextBox BorderWidth="3" BorderColor="SlateGray" runat="server" TextMode="DateTimeLocal" class="form-control" ID="tbdataperiodoinicio" Width="266px"/></td><td class="auto-style22"><b>&nbsp;<asp:Label ID="lbtexta" Text="a" runat="server" /></b></td><td><asp:TextBox runat="server" TextMode="DateTimeLocal" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="tbdataperiodofim" Width="266px"  /></td>
        </tr>
        
       
    </table>
        
    <br />
    <table>
        <tr>
            <td class="auto-style21">
                <b><asp:Label ID="lbmedi" Text="Medidas:" runat="server" /></b><asp:TextBox ID="tbmedidas" TextMode="MultiLine" class="form-control" BorderWidth="3" BorderColor="SlateGray" runat="server" Height="109px" Width="738px" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir3" Text="Inserir" Class="btn btn-black" OnClick="binserir3_Click" runat="server" /></td>
            </tr>
        </table>
    <br />
        <br />
    <br />
    <table class="auto-style3">
        <tbody>

            <tr>
                <th colspan="1" class="auto-style8">
                    <asp:Label ID="lbcdp" Text="Cumprimento do Plano" runat="server" /> </th>
                <th colspan="1" class="auto-style7"><asp:Label ID="lbcdi" Text="Cessou o dever de incumprimento" runat="server" /></th>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:CheckBox ID="cbcumprimentosim" class="form-control" OnCheckedChanged="cbcumprimentosim_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" Width="37px" /><b><asp:Label ID="lbcumprimentosim" Text="Sim" runat="server" /></b></td>
                <td class="auto-style7" colspan="2">
                    <asp:CheckBox ID="cbincumprimentosim" class="form-control" OnCheckedChanged="cbincumprimentosim_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" Width="39px" /><b><asp:Label ID="lbincumprimentosim" Text="Sim" runat="server" /></b></td>

            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:CheckBox ID="cbcumprimentonao" class="form-control" OnCheckedChanged="cbcumprimentonao_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" Width="37px" /><b><asp:Label ID="lbcumprimentonao" Text="Não" runat="server" /></b></td>
                <td class="auto-style7" colspan="2">
                    <asp:CheckBox ID="cbincumprimentonao" class="form-control" OnCheckedChanged="cbincumprimentonao_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" Width="39px" /><b><asp:Label ID="lbincumprimentonao" Text="Não" runat="server" /></b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" class="form-control" ID="datacumprimento" BorderWidth="3" BorderColor="SlateGray" TextMode="Date" Width="150px" /></td>
                <td>
                    <asp:TextBox runat="server" class="form-control" ID="dataincumprimento" BorderWidth="3" BorderColor="SlateGray" TextMode="Date" Width="150px" /></td>
            </tr>
        </tbody>
    </table>
        <br />
    <br />
    <h3><b><u><asp:Label ID="lbfd" Text="Faltas Desconsideradas" runat="server" /> </u></b></h3>
    <br />
    <table class="auto-style3">
        <tr>
            <td class="auto-style6">
                <asp:TextBox ID="tbfaltasdesconsideradas" BorderWidth="3" TextMode="MultiLine" BorderColor="SlateGray" class="form-control" runat="server" Height="109px" Width="769px" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir5" Text="Inserir" Class="btn btn-black" OnClick="binserir5_Click" runat="server" /></td>
            </tr>
        </table>
    <br />
        <br />
    <br />
    <h3><b><u><asp:Label ID="lbn" Text="Notificações" runat="server" /> </u></b></h3>
    <br />
    <table class="auto-style3">
        <tr>
            <td class="auto-style20">
                <asp:Label ID="lbpeea" Text="Pais ou Encarregado de Educação ou Aluno" runat="server" /></td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" Width="452px" ID="tbpeeanotificacoes" /></td>
            <td>
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" TextMode="Date" ID="datapeeanotificacoes" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir6" Text="Inserir" Class="btn btn-black" OnClick="binserir6_Click" runat="server" /></td>
            </tr>
        </table>
        <br />
    <table class="auto-style3">
        <tr>
            <td class="auto-style20">
                <asp:Label ID="lbdt" Text="Diretor de Turma" runat="server" /></td>
            </tr>
        <tr>
            <td class="auto-style20">
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" Width="452px" ID="tbdtnotificacoes" /></td>
            <td>
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" TextMode="Date" ID="datadtnotificacoes" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir7" Text="Inserir" Class="btn btn-black" OnClick="binserir7_Click" runat="server" /></td>
            </tr>
        </table>
        <br />
    <table class="auto-style3">
        <tr>
            <td class="auto-style20">
                <asp:Label ID="lbpt" Text="Professor Tutor" runat="server" /></td>
            </tr>
        <tr>
            <td class="auto-style20">
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" Width="452px" ID="tbptnotificacoes" /></td>
            <td>
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" TextMode="Date" ID="dataptnotificacoes" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir8" Text="Inserir" Class="btn btn-black" OnClick="binserir8_Click" runat="server" /></td>
            </tr>
        </table>
        <br />
    <table class="auto-style3">
        <tr>
            <td colspan="2">
                <asp:Label ID="lbcpcjr" Text="Comissão de Proteção de Crianças e Jovens em Risco" runat="server" /></td>
            </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" TextMode="Date" ID="datacpcjnotificacoes" Width="342px" /></td>
        </tr>

    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir9" Text="Inserir" Class="btn btn-black" OnClick="binserir9_Click" runat="server" /></td>
            </tr>
        </table>
    <br />
    <br />
    <h3><b><u><asp:Label ID="lbdre" Text="Decisão de Retenção/ Exclusão" runat="server" /></u></b></h3>
    <br />
    <table class="auto-style3">
        <tr>
            <td class="auto-style26">
                <asp:Label ID="lbct" Text="Conselho de Turma" runat="server" /></td>
        <tr>
            <td>
                <asp:TextBox runat="server" TextMode="Date" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="datactdecisaoretencao" Width="216px" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir10" Text="Inserir" Class="btn btn-black" OnClick="binserir10_Click" runat="server" /></td>
            </tr>
        </table>
    <br />
    <br />
    <h3><b><u>
        <asp:Label ID="lbac" Text="Averbamento/ Consequência" runat="server" /></u></b></h3>
    <br />
    <table class="auto-style3">
        <tr>
            <td class="auto-style35">
                <asp:CheckBox ID="cbpiaaverbamento" class="form-control" OnCheckedChanged="cbpiaaverbamento_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                <td class="auto-style19"><asp:Label ID="lbpia" Text="Processo Individual do Aluno" runat="server" Width="405px" /></td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:CheckBox ID="cbeadpfaverbamento" class="form-control" OnCheckedChanged="cbeadpfaverbamento_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                <td class="auto-style19"><asp:Label ID="lbeadpf" Text="Encaminhamento do aluno para diferente percurso formativo" runat="server" Width="405px" /></td>
            <td>
                <asp:TextBox runat="server" TextMode="Date" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="dataeadpfaverbamento" /></td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:CheckBox ID="cbmcsaverbamento" class="form-control" OnCheckedChanged="cbmcsaverbamento_CheckedChanged" borderwidth="3" bordercolor="SlateGray"  AutoPostBack="true" runat="server" />
                <td class="auto-style19"><asp:Label ID="lbmcs" Text="Medidas corretivas/ sancionatórias" runat="server" Width="405px" /></td>
            <td>
                <asp:TextBox runat="server" BorderWidth="3" BorderColor="SlateGray" class="form-control" ID="tbmedidasaverbamento" /></td>
        </tr>
    </table>
        <table>
            <tr><td>
                <asp:Button ID="binserir11" Text="Inserir" Class="btn btn-black" OnClick="binserir11_Click" runat="server" /></td>
            </tr>
        </table>
    <br />
    <br />
    <table >
        <tr>
            <td>
                <asp:Label ID="lbd" Text="O Diretor," runat="server" /></td><td><asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" ID="tbassdiretoraverbamento" Width="176px"  /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbaal" Text="AE Amato Lusitano," runat="server" /></td><td><asp:TextBox runat="server" class="form-control" BorderWidth="3" BorderColor="SlateGray" TextMode="Date" ID="dataassdaverbamento" /></td>
        </tr>
        </table>
    <br />
    <br />
    <table >
        <tr class="form-group">
            <td>
                <asp:Button ID="binserir12" Text="Inserir" Class="btn btn-black" OnClick="binserir12_Click" runat="server" /></td>
            <td>
                <asp:Button ID="bcancelar" Text="Cancelar" Class="btn btn-secondary" CausesValidation="false" OnClick="bcancelar_Click" runat="server" /></td>
            
        </tr>
    </table>
        </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>