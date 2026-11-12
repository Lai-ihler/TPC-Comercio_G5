<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="WebApplication1.FormularioUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario Usuario</h1>
    <p>Completa los datos del usuario.</p>

    <div class="row">

        <div class="col-6">
            <div class="mb-3">

                <asp:Label ID="lblNombreUsuario" runat="server" CssClass=" form-label"
                    AssociatedControlID="txtNombreUsuario" Text="Nombre de Usuario" />

                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreUsuario"
                    ErrorMessage="El nombre de usuario es obligatorio." ForeColor="Red" Display="Dynamic" />

                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNombreUsuario"
                    ValidationExpression="^(?=.*\S).{1,20}$"
                    ErrorMessage="El nombre de usuario debe tener entre 1 y 20 caracteres."
                    ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblPass" runat="server" CssClass="form-label"
                    AssociatedControlID="txtPass" Text="Contraseña" />

                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass"
                    ErrorMessage="La contraseña es obligatoria." ForeColor="Red" Display="Dynamic" />

                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPass"
                    ValidationExpression="^(?=.*\S).{8,20}$"
                    ErrorMessage="La contraseña debe tener entre 8 y 20 caracteres."
                    ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" CssClass="form-label"
                    AssociatedControlID="txtNombre" Text="Nombre" />

                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es obligatorio." ForeColor="Red" Display="Dynamic" />

                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNombre"
                    ValidationExpression="^(?=.*\S).{1,20}$"
                    ErrorMessage="El nombre debe tener entre 1 y 20 caracteres."
                    ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblApellido" runat="server" CssClass="form-label"
                    AssociatedControlID="txtApellido" Text="Apellido" />

                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido"
                    ErrorMessage="El apellido es obligatorio." ForeColor="Red" Display="Dynamic" />

                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtApellido"
                    ValidationExpression="^(?=.*\S).{1,20}$"
                    ErrorMessage="El apellido debe tener entre 1 y 20 caracteres."
                    ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" CssClass="form-label"
                    AssociatedControlID="txtEmail" Text="Email" />

                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="El email es obligatorio." ForeColor="Red" Display="Dynamic" />

                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                    ErrorMessage="Ingrese un email válido."
                    ForeColor="Red" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblPerfil" runat="server" CssClass="form-label"
                    AssociatedControlID="ddlPerfil" Text="Perfil" />

                <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-select">
                </asp:DropDownList>

                <asp:RequiredFieldValidator
                    ControlToValidate="ddlPerfil"
                    InitialValue=""
                    ErrorMessage="Debe seleccionar un perfil."
                    ForeColor="Red"
                    runat="server" />
            </div>

            <p>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" />
                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Usuarios.aspx">Cancelar</asp:HyperLink>
            </p>

        </div>
    </div>
</asp:Content>
