<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="Planos.aspx.cs" Inherits="Gestor.Site.Home.Planos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Planos de Recuperação de Horas</h2>
        <table>
            <tr>
                <td colspan="3">

                    <asp:GridView ID="gvprh" OnRowDataBound="gvprh_RowDataBound" HeaderStyle-CssClass="thead-light" DataKeyNames="id_prh" OnRowEditing="gvprh_RowEditing" EmptyDataText="Sem Registo" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvprh_SelectedIndexChanged" CssClass="table table-responsive table-striped table-hover thead-dark">
                        
                        <Columns>
                            <asp:BoundField DataField="id_prh" ReadOnly="true" HeaderText="ID Prh" />
                            <asp:BoundField DataField="nome_dt" HeaderText="Nome do Diretor de Turma" />
                            <asp:BoundField DataField="nome_professor" HeaderText="Nome do Professor" />
                            <asp:BoundField DataField="nome_aluno" HeaderText="Nome do Aluno" />
                            <asp:BoundField DataField="nome_turma" HeaderText="Nome da Turma" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <h5><asp:Label id="lbestado" Font-Bold="true" Height=""  runat="server" /></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="progresso" ItemStyle-Font-Size="Large" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Red" HeaderText="Progresso do PRH" />
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtEdit" Visible="false" OnClick="FormCommandsEdit" Text="Editar" runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtSelect" OnClick="FormCommands" Text="Visualizar" runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lbmensagem" Font-Bold="true" ForeColor="Red" Text="" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="bnprh" CssClass="btn btn-primary" Text="Novo Prh" OnClick="bnprh_Click" runat="server" /></td>

            </tr>
        </table>
    </div>
</asp:Content>
