<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioProveedor.aspx.cs" Inherits="WebApplication1.FormularioProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario Proveedor</h1>
    <p>Completa los datos del proveedor.</p>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblRazonSocial" runat="server" CssClass="form-label"
                    AssociatedControlID="lblRazonSocial" Text="Razon Social" />

                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control" />

            </div>
            <div class="mb-3">
                <asp:Label ID="lblCuit" runat="server" CssClass="form-label"
                    AssociatedControlID="lblCuit" Text="Cuit" />

                <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" />
            </div>


            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" CssClass="form-label"
                    AssociatedControlID="lblEmail" Text="Email" />

                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblTelefono" runat="server" CssClass="form-label"
                    AssociatedControlID="lblTelefono" Text="Telefono" />

                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblDireccion" runat="server" CssClass="form-label"
                    AssociatedControlID="lblDireccion" Text="Direccion" />

                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>

            <p>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Proveedores.aspx">Cancelar</asp:HyperLink>
            </p>

        </div>
    </div>
</asp:Content>
