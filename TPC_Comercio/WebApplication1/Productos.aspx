<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApplication1.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Productos</h1>

    <p>
        <asp:HyperLink ID="lnkNuevo" runat="server" CssClass="btn btn-primary mb-3"
            NavigateUrl="FormularioProducto.aspx">Nuevo producto</asp:HyperLink>
    </p>

    <p>Listado de productos del comercio.</p>

    <asp:GridView ID="gvListado" runat="server" CssClass="table"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        OnSelectedIndexChanged="gvListado_SelectedIndexChanged"
        EmptyDataText="No hay productos para mostrar.">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
             <asp:BoundField DataField="Marca.Descripcion" HeaderText="Marca" />
            <asp:BoundField DataField="Categoria.Descripcion" HeaderText="Categoria" />
            <asp:BoundField DataField="Proveedor.RazonSocial" HeaderText="Proveedor" />
            <asp:BoundField DataField="StockActual" HeaderText="Stock actual" />
            <asp:BoundField DataField="Activo" HeaderText="Activo" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
</asp:Content>
