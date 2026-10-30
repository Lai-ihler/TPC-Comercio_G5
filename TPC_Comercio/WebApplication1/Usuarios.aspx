<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApplication1.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Usuarios</h1>
        <p>Listado de usuarios del comercio</p>
    
        <asp:GridView
            ID="gvUsuarios"
            runat="server"
            AutoGenerateColumns="False"
            EmptyDataText="No hay usuarios para mostrar.">
    
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="Pass" HeaderText="Contraseña" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
            </Columns>
    
        </asp:GridView>
        <p>
            <asp:HyperLink ID="lnkNuevo" runat="server"
            NavigateUrl="FormularioUsuario.aspx">Nuevo Usuario
            </asp:HyperLink>
        </p>
    </div>
</asp:Content>
