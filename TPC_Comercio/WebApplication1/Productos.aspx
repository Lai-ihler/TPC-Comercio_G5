<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApplication1.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Productos</h1>
    <p>Listado de productos del comercio.</p>

    <p>
        <asp:HyperLink ID="lnkNuevo" runat="server"
            NavigateUrl="FormularioProducto.aspx">Nuevo producto</asp:HyperLink>
    </p>

    <asp:GridView ID="gvListado" runat="server"
        AutoGenerateColumns="False"
        EmptyDataText="No hay productos para mostrar.">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Marca" HeaderText="ID Marca" />
            <asp:BoundField DataField="Categoria" HeaderText="ID Categoría" />
            <asp:BoundField DataField="StockActual" HeaderText="Stock actual" />
            <asp:BoundField DataField="Activo" HeaderText="Activo" />
        </Columns>
    </asp:GridView>
</asp:Content>
