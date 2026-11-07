<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebApplication1.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ventas</h1>
    <p>Listado de ventas del comercio.</p>

    <p>
        <asp:HyperLink ID="lnkNuevaVenta" runat="server"
            CssClass="btn btn-primary mb-3"
            NavigateUrl="FormularioVenta.aspx">Nueva venta</asp:HyperLink>
    </p>

    <asp:GridView ID="gvVentas" runat="server"
        CssClass="table"
        AutoGenerateColumns="False"
        ShowHeaderWhenEmpty="True"
        EmptyDataText="Todavia no hay ventas para mostrar.">
        <Columns>
            <asp:BoundField DataField="NumeroFactura" HeaderText="Nro. factura" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha"
                DataFormatString="{0:dd/MM/yyyy}" />

            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate><%# Eval("Cliente.Nombre") %> <%# Eval("Cliente.Apellido") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate><%# Eval("Usuario.NombreUsuario") %></ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Total" HeaderText="Total" />
        </Columns>
    </asp:GridView>
</asp:Content>
