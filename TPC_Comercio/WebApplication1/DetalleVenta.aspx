<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="WebApplication1.DetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Detalle de venta</h1>
    <p>Productos correspondientes a la venta seleccionada.</p>

    <asp:Label ID="lblFactura" runat="server" CssClass="h4" />

    <asp:GridView ID="gvDetalle" runat="server"
        CssClass="table"
        AutoGenerateColumns="False"
        ShowHeaderWhenEmpty="True"
        EmptyDataText="Esta venta no tiene productos registrados.">

        <Columns>
            <asp:TemplateField HeaderText="Producto">
                <ItemTemplate>
                    <%# Eval("Producto.Nombre") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

            <asp:BoundField DataField="PrecioUnitario"
                HeaderText="Precio unitario"
                DataFormatString="{0:C}" />

            <asp:BoundField DataField="Subtotal"
                HeaderText="Subtotal"
                DataFormatString="{0:C}" />
        </Columns>

    </asp:GridView>

    <div class="text-end">
        <h4>
            Total:
            <asp:Label ID="lblTotal" runat="server" Text="$0" />
        </h4>
    </div>

    <asp:HyperLink ID="lnkVolver" runat="server"
        NavigateUrl="Ventas.aspx"
        CssClass="btn btn-secondary">
        Volver a ventas
    </asp:HyperLink>

</asp:Content>