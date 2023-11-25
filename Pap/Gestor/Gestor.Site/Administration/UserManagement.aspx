<%@ Page Title="" Language="C#" MasterPageFile="~/Home/SiteHome.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Gestor.Site.Administration.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CustomStyles/LoginRegisterStyles/loginregister.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Utilizadores</h2>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvusermanagement" EmptyDataText="Sem Registo" OnRowDataBound="gvusers_RowDataBound" AutoGenerateColumns="false" DataKeyNames="id_user" runat="server">
                        <Columns>
                            <asp:BoundField DataField="id_user" ReadOnly="true" HeaderText="ID User" />
                            <asp:BoundField DataField="username" HeaderText="Nome de Utilizador" />
                            <asp:TemplateField HeaderText="Privilégios de Administrador">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbadmin" runat="server" Text="Administrador" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar Utilizador">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbdelete" runat="server" Text="Eliminar" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bloquear Utilizador">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbblock" runat="server" Text="bloquear" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            </table>
        <br />
        <table>
            
            <tr>
                <td><asp:Button ID="bsalvar" Text="Salvar as alterações" Class="btn btn-primary" OnClick="bsalvar_Click" runat="server" /></td>
            </tr>
        </table>
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</asp:Content>
