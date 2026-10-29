<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="WebApplication1.FormularioProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario de producto</h1>
    <p>Completa los datos del producto.</p>

    <fieldset>
        <legend>Datos del producto</legend>

        <p>
            <asp:Label ID="lblCodigo" runat="server"
                AssociatedControlID="txtCodigo" Text="Codigo" />
            <br />
            <asp:TextBox ID="txtCodigo" runat="server" />
        </p>

        <p>
            <asp:Label ID="lblNombre" runat="server"
                AssociatedControlID="txtNombre" Text="Nombre" />
            <br />
            <asp:TextBox ID="txtNombre" runat="server" />
        </p>

        <p>
            <asp:Label ID="lblDescripcion" runat="server"
                AssociatedControlID="txtDescripcion" Text="Descripcion" />
            <br />
            <asp:TextBox ID="txtDescripcion" runat="server"
                TextMode="MultiLine" Rows="3" Columns="40" />
        </p>
    </fieldset>

    <fieldset>
        <legend>Clasificacion</legend>

        <p>
            <asp:Label ID="lblMarca" runat="server"
                AssociatedControlID="ddlMarca" Text="Marca" />
            <br />
            <asp:DropDownList ID="ddlMarca" runat="server">
                <asp:ListItem Text="Selecciona una marca" Value="" />
            </asp:DropDownList>
        </p>

        <p>
            <asp:Label ID="lblCategoria" runat="server"
                AssociatedControlID="ddlCategoria" Text="Categoria" />
            <br />
            <asp:DropDownList ID="ddlCategoria" runat="server">
                <asp:ListItem Text="Selecciona una categoria" Value="" />
            </asp:DropDownList>
        </p>

        <p>
            <asp:Label ID="lblProveedores" runat="server" Text="Proveedores" />
            <br />
            <asp:CheckBoxList ID="cblProveedores" runat="server" />
        </p>
    </fieldset>

    <fieldset>
        <legend>Stock e imagen</legend>

        <p>
            <asp:Label ID="lblStockMinimo" runat="server"
                AssociatedControlID="txtStockMinimo" Text="Stock minimo" />
            <br />
            <asp:TextBox ID="txtStockMinimo" runat="server" />
        </p>

        <p>
            <asp:Label ID="lblPorcentajeGanancia" runat="server"
                AssociatedControlID="txtPorcentajeGanancia"
                Text="Porcentaje de ganancia" />
            <br />
            <asp:TextBox ID="txtPorcentajeGanancia" runat="server" />
        </p>

        <p>
            <asp:Label ID="lblImagenUrl" runat="server"
                AssociatedControlID="txtImagenUrl" Text="Imagen URL" />
            <br />
            <asp:TextBox ID="txtImagenUrl" runat="server" />
        </p>
    </fieldset>

    <p>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="Productos.aspx">Cancelar</asp:HyperLink>
    </p>
</asp:Content>
