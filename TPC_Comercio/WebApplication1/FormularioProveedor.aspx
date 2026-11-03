<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioProveedor.aspx.cs" Inherits="WebApplication1.FormularioProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario Proveedor</h1>
    <p>Completa los datos del proveedor.</p>

    <p>
        <asp:Label ID="lblRazonSocial" runat="server"
            AssociatedControlID="lblRazonSocial" Text="Razon Social" />
        <br />
        <asp:TextBox ID="txtRazonSocial" runat="server" />
    </p>

    <p>
        <asp:Label ID="lblCuit" runat="server"
            AssociatedControlID="lblCuit" Text="Cuit" />
        <br />
        <asp:TextBox ID="txtCuit" runat="server" />
    </p>

    <p>
        <asp:Label ID="lblEmail" runat="server"
            AssociatedControlID="lblEmail" Text="Email" />
        <br />
        <asp:TextBox ID="txtEmail" runat="server" />
    </p>

    <p>
        <asp:Label ID="lblTelefono" runat="server"
            AssociatedControlID="lblTelefono" Text="Telefono" />
        <br />
        <asp:TextBox ID="txtPerfil" runat="server" />
    </p>

    <p>
        <asp:Label ID="lblDireccion" runat="server"
        AssociatedControlID="lblDireccion" Text="Direccion" />
        <br />
        <asp:TextBox ID="txtDireccion" runat="server" />
    </p>

    <p>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="Proveedores.aspx">Cancelar</asp:HyperLink>
    </p>
</asp:Content>
