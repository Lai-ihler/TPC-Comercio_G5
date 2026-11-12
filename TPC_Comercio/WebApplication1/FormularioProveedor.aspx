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
                    AssociatedControlID="txtRazonSocial" Text="Razon Social" />

                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control" MaxLength="40" />
                <asp:RequiredFieldValidator ErrorMessage="Ingresá la razón social." ControlToValidate="txtRazonSocial" CssClass="text-danger" runat="server" />

            </div>
            <div class="mb-3">
                <asp:Label ID="lblCuit" runat="server" CssClass="form-label"
                    AssociatedControlID="txtCuit" Text="Cuit" />

                <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" MaxLength="11" />
                <asp:RequiredFieldValidator ErrorMessage="Ingresá el CUIT." ControlToValidate="txtCuit" CssClass="text-danger" Display="Dynamic" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="El CUIT tiene que tener 11 números, sin guiones." ControlToValidate="txtCuit" ValidationExpression="^[0-9]{11}$" CssClass="text-danger" Display="Dynamic" runat="server" />
                <asp:Label ID="lblErrorCuit" runat="server" CssClass="text-danger" />

            </div>


            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" CssClass="form-label"
                    AssociatedControlID="txtEmail" Text="Email" />

                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100"/>
                <asp:RequiredFieldValidator ErrorMessage="Ingresá el email." ControlToValidate="txtEmail" CssClass="text-danger" Display="Dynamic" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingresá un email válido." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblTelefono" runat="server" CssClass="form-label"
                    AssociatedControlID="txtTelefono" Text="Telefono" />

                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" />
                <asp:RequiredFieldValidator ErrorMessage="Ingresá el teléfono." ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblDireccion" runat="server" CssClass="form-label"
                    AssociatedControlID="txtDireccion" Text="Direccion" />

                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="50" />
                <asp:RequiredFieldValidator ErrorMessage="Ingresá la dirección." ControlToValidate="txtDireccion" CssClass="text-danger" runat="server" />
            </div>

            <p>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" />
                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Proveedores.aspx">Cancelar</asp:HyperLink>
            </p>

        </div>
    </div>
</asp:Content>
