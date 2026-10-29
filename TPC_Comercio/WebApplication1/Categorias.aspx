<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="WebApplication1.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categorías</h1>
    <p>Listado de categorías.</p>

    <p>
        <asp:HyperLink ID="lnkNuevo" runat="server"
            NavigateUrl="FormularioCategoria.aspx">Nueva categoría</asp:HyperLink>
    </p>

    <asp:GridView ID="gvCategorias" runat="server"
        AutoGenerateColumns="False"
        EmptyDataText="No hay categorías para mostrar.">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Activo" HeaderText="Activo" />
        </Columns>
    </asp:GridView>
</asp:Content>
