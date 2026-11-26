<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="WebApplication1.DetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media print {

            @page {
                size: A4;
                margin: 15mm;
            }

            body * {
                visibility: hidden;
            }

            .factura,
            .factura * {
                visibility: visible;
            }

            .factura {
                position: absolute;
                left: 0;
                top: 0;
                width: 100%;
                color: black;
                background: white;
            }

            .no-imprimir {
                display: none !important;
            }

            .factura h2 {
                text-align: center;
                margin-bottom: 20px;
            }

            .factura table {
                width: 100%;
                border-collapse: collapse;
            }

            .factura th,
            .factura td {
                border: 1px solid black !important;
                padding: 8px;
                color: black !important;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Detalle de venta</h1>

    <asp:Panel ID="pnlFactura" runat="server" CssClass="factura">

        <h2>FACTURA</h2>

        <asp:Label ID="lblFactura" runat="server" />

        <p>
            <strong>Cliente:</strong>
            <asp:Label ID="lblCliente" runat="server" />
        </p>

        <p>
            <strong>Fecha:</strong>
            <asp:Label ID="lblFecha" runat="server" />
        </p>

        <hr />

        <asp:GridView ID="gvDetalle" runat="server"
            CssClass="table table-striped"
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
            <h4>Total:
               
                <asp:Label ID="lblTotal" runat="server" Text="$0" />
            </h4>
        </div>

    </asp:Panel>
    <div class="no-imprimir mt-3">

        <asp:Button ID="btnImprimir" runat="server"
            Text="Imprimir factura"
            CssClass="btn btn-primary"
            OnClientClick="window.print(); return false;" />

        <asp:HyperLink ID="lnkVolver" runat="server"
            NavigateUrl="Ventas.aspx"
            CssClass="btn btn-secondary">
            Volver a ventas
        </asp:HyperLink>

    </div>

</asp:Content>
