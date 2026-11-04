<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="WebApplication1.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Proveedores</h1>
        <p>Listado de proveedores del comercio</p>

        <asp:GridView
            ID="gvProveedores"
            runat="server"
            CssClass="table"
            AutoGenerateColumns="False"
            EmptyDataText="No hay proveedores para mostrar.">

            <columns>
                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
                <asp:BoundField DataField="Cuit" HeaderText="Cuit" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            </columns>

        </asp:GridView>
        <p>
            <asp:HyperLink ID="lnkNuevo" runat="server"
                NavigateUrl="FormularioProveedor.aspx"
                CssClass="btn btn-primary">
                Nuevo Proveedor
            </asp:HyperLink>
        </p>
    </div>
</asp:Content>
