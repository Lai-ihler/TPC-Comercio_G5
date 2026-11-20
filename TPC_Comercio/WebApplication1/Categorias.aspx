<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="WebApplication1.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categorías</h1>
    <p>Listado de categorías.</p>

    <p>
        <asp:HyperLink ID="lnkNuevo" runat="server" CssClass="btn btn-primary mb-3"
            NavigateUrl="FormularioCategoria.aspx">Nueva categoría</asp:HyperLink>
    </p>

    <div class="mb-3">
        <asp:Label Text="Filtrar" runat="server" />
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
    </div>

    <asp:GridView ID="gvCategorias" runat="server" CssClass="table"
        AutoGenerateColumns="False" DataKeyNames="Id"
        OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged"
        EmptyDataText="No hay categorías para mostrar.">

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
        </Columns>

    </asp:GridView>

</asp:Content>
