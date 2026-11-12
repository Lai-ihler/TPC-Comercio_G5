<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="WebApplication1.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1>Administrar clientes</h1>
    <p>Completa los datos del cliente.</p>

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server"
                    AssociatedControlID="txtNombre"
                    CssClass="form-label"
                    Text="Nombre" />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="30" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic"/>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblApellido" runat="server"
                    AssociatedControlID="txtApellido"
                    CssClass="form-label"
                    Text="Apellido" />
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="30" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio." CssClass="text-danger" Display="Dynamic"/>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblDni" runat="server"
                    AssociatedControlID="txtDni"
                    CssClass="form-label"
                    Text="DNI" />
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" maxlength="9"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDni" ErrorMessage="El DNI es obligatorio." CssClass="text-danger" Display="Dynamic"/>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtDni" ValidationExpression="^[0-9]{7,9}$" ErrorMessage="El DNI debe tener entre 7 y 9 numeros." CssClass="text-danger" Display="Dynamic" />
                <asp:CustomValidator ID="cvDni" runat="server" ControlToValidate="txtDni" OnServerValidate="cvDni_ServerValidate" ErrorMessage="Ya existe un cliente con ese DNI." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server"
                    AssociatedControlID="txtEmail"
                    CssClass="form-label"
                    Text="Email" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" maxlength="100"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio." CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Ingresa un email valido." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblTelefono" runat="server"
                    AssociatedControlID="txtTelefono"
                    CssClass="form-label"
                    Text="Telefono" />
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefono" ErrorMessage="El telefono es obligatorio." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblDireccion" runat="server"
                    AssociatedControlID="txtDireccion"
                    CssClass="form-label"
                    Text="Direccion" />
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" maxLength="50"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion" ErrorMessage="La direccion es obligatoria." CssClass="text-danger" Display="Dynamic" />
            </div>

            <p>
                <asp:Button ID="btnGuardar" runat="server"
                    Text="Guardar"
                    CssClass="btn btn-primary"
                    OnClick="btnGuardar_Click" />

                <asp:Button ID="btnInactivar" runat="server"
                    Text="Inactivar"
                    CssClass="btn btn-warning"
                    OnClick="btnInactivar_Click" />

                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Clientes.aspx">
                    Cancelar
                </asp:HyperLink>
            </p>

        </div>
    </div>
</asp:Content>
