<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApplication1.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Usuarios</h1>
        <p>Listado de usuarios del comercio</p>

        <asp:HyperLink ID="lnkNuevo" runat="server"
            NavigateUrl="FormularioUsuario.aspx"
            CssClass="btn btn-primary">
            Nuevo Usuario
        </asp:HyperLink>

        <asp:GridView
            ID="gvUsuarios"
            runat="server"
            CssClass="table"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged"
            OnRowDataBound="gvUsuarios_RowDataBound"
            EmptyDataText="No hay usuarios para mostrar.">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Perfil">
                    <ItemTemplate>
                        <%# Eval("Perfil.Descripcion") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
            </Columns>

        </asp:GridView>
                    
    </div>
</asp:Content>
