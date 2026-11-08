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
                    AssociatedControlID="lblNombreUsuario" Text="Nombre de Usuario" />

                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblPass" runat="server" CssClass="form-label"
                    AssociatedControlID="lblPass" Text="Contraseña" />

                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" CssClass="form-label"
                    AssociatedControlID="lblNombre" Text="Nombre" />

                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblApellido" runat="server" CssClass="form-label"
                    AssociatedControlID="lblApellido" Text="Apellido" />

                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" CssClass="form-label"
                    AssociatedControlID="lblEmail" Text="Email" />

                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            
            <div class="mb-3">
                <asp:Label ID="lblPerfil" runat="server" CssClass="form-label"
                    AssociatedControlID="ddlPerfil" Text="Perfil" />

                <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-select">

                </asp:DropDownList>

            </div>

            <p>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" onclick="btnGuardar_Click"/>
                <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-warning" onclick="btnInactivar_Click"/>
                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Usuarios.aspx">Cancelar</asp:HyperLink>
            </p>

        </div>
    </div>
</asp:Content>
