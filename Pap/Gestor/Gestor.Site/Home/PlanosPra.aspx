<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="PlanosPra.aspx.cs" Inherits="Gestor.Site.Home.PlanosPra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Planos de Recuperação das Aprendizagens</h2>
        <table>
            <tr>
                <td colspan="3">

                    <asp:GridView ID="gvpra" OnRowDataBound="gvpra_RowDataBound" HeaderStyle-CssClass="thead-light" DataKeyNames="id_pra" OnRowEditing="gvpra_RowEditing" EmptyDataText="Sem Registo" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvpra_SelectedIndexChanged" CssClass="table table-responsive table-striped table-hover thead-dark">
                        
                        <Columns>
                            <asp:BoundField DataField="id_pra" ReadOnly="true" HeaderText="ID Pra" />
                            <asp:BoundField DataField="nome_dt" HeaderText="Nome do Diretor de Turma" />
                            <asp:BoundField DataField="nome_aluno" HeaderText="Nome do Aluno" />
                            <asp:BoundField DataField="nome_turma" HeaderText="Nome da Turma" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <h5><asp:Label id="lbestado" Font-Bold="true" Height=""  runat="server" /></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="progresso" ItemStyle-Font-Size="Large" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Red" HeaderText="Progresso do PRA" />
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
                    <asp:Button ID="bnpra" CssClass="btn btn-primary" Text="Novo Pra" OnClick="bnpra_Click" runat="server" /></td>

            </tr>
        </table>
    </div>
</asp:Content>
