<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="WebApplication1.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario Usuario</h1>
    <p>Completa los datos del usuario.</p>
    
    <p>
        <asp:Label ID="lblNombreUsuario" runat="server"
            AssociatedControlID="lblNombreUsuario" Text="Nombre de Usuario" />
        <br />
        <asp:TextBox ID="txtNombreUsuario" runat="server" />
    </p>

    <p>
        <asp:Label ID="lblPass" runat="server"
            AssociatedControlID="lblPass" Text="Contraseña" />
        <br />
        <asp:TextBox ID="txtPass" runat="server" />
    </p>

    <p>
        <asp:Label ID="lblNombre" runat="server"
            AssociatedControlID="lblNombre" Text="Nombre" />
        <br />
        <asp:TextBox ID="txtNombre" runat="server" />
    </p>

    <p>
     <asp:Label ID="lblApellido" runat="server"
            AssociatedControlID="lblApellido" Text="Apellido" />
        <br />
        <asp:TextBox ID="txtApellido" runat="server" />
    </p>

    <p>
    <asp:Label ID="lblEmail" runat="server"
          AssociatedControlID="lblEmail" Text="Email" />
         <br />
        <asp:TextBox ID="txtEmail" runat="server" />
    </p>

    <p>
    <asp:Label ID="lblPerfil" runat="server"
         AssociatedControlID="lblPerfil" Text="Perfil" />
         <br />
    <asp:TextBox ID="txtPerfil" runat="server" />
    </p>
    
    <p>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="Marcas.aspx">Cancelar</asp:HyperLink>
    </p>
</asp:Content>
