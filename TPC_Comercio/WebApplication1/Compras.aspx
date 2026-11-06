<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebApplication1.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Compras</h1>
        <p>
            <asp:HyperLink ID="lnkNuevo" runat="server"
                CssClass="btn btn-primary"
                NavigateUrl="FormularioCompra.aspx">
            Nueva Compra
        </asp:HyperLink>
        </p>
        
        <p>Listado de compras del comercio</p>

        <asp:GridView
            ID="gvCompras"
            runat="server"
             CssClass="table"
            AutoGenerateColumns="False"
            EmptyDataText="No hay compras para mostrar.">

            <Columns>
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:TemplateField HeaderText="Proveedor">
                    <ItemTemplate>
                        <%# Eval("Proveedor.RazonSocial") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Usuario">
                    <ItemTemplate>
                        <%# Eval("Usuario.NombreUsuario") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Total" HeaderText="Total" />
            </Columns>

        </asp:GridView>
        
    </div>
</asp:Content>
