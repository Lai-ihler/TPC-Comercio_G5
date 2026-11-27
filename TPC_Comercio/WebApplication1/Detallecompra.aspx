<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detallecompra.aspx.cs" Inherits="WebApplication1.Detallecompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle de compra</h1>
    <p>Productos y precios de compra.</p>

    <asp:GridView ID="gvDetalle" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
        EmptyDataText="Esta compra no tiene productos registrados.">
        <columns>
            <asp:TemplateField HeaderText="Producto">
                <itemtemplate>
                    <%# Eval("Producto.Nombre") %>
                </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio de compra" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        </columns>
    </asp:GridView>

    <div class="text-end">
        <h4>Total:
            <asp:Label ID="lblTotal" runat="server" Text="$0" />
        </h4>
    </div>

    <asp:HyperLink ID="lnkVolver" runat="server" NavigateUrl="Compras.aspx" CssClass="btn btn-secondary">
        Volver a compras
    </asp:HyperLink>
</asp:Content>
