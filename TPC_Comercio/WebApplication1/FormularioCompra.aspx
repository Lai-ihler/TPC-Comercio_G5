<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCompra.aspx.cs" Inherits="WebApplication1.FormularioCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nueva compra</h1>
    <p>Completa los datos de la compra.</p>

    <div class="row">
        <div class="col-md-8">

            <fieldset class="mb-4">
                <legend>Datos de la compra</legend>

                <div class="mb-3">
                    <asp:Label ID="lblProveedor" runat="server"
                        AssociatedControlID="ddlProveedor"
                        CssClass="form-label" Text="Proveedor" />

                    <asp:DropDownList ID="ddlProveedor" runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Selecciona un proveedor" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblProducto" runat="server"
                        AssociatedControlID="ddlProducto"
                        CssClass="form-label" Text="Producto" />

                    <asp:DropDownList ID="ddlProducto" runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Selecciona un producto" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <asp:Label ID="lblCantidad" runat="server"
                            AssociatedControlID="txtCantidad"
                            CssClass="form-label" Text="Cantidad" />

                        <asp:TextBox ID="txtCantidad" runat="server"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6 mb-3">
                        <asp:Label ID="lblPrecio" runat="server"
                            AssociatedControlID="txtPrecio"
                            CssClass="form-label" Text="Precio unitario" />

                        <asp:TextBox ID="txtPrecio" runat="server"
                            CssClass="form-control" />
                    </div>
                </div>

                <asp:Button ID="btnAgregar" runat="server"
                    Text="Agregar producto" CssClass="btn btn-secondary" />
            </fieldset>

            <fieldset class="mb-4">
                <legend>Productos de la compra</legend>

                <asp:GridView ID="gvDetalle" runat="server"
                    CssClass="table table-striped"
                    AutoGenerateColumns="False"
                    EmptyDataText="Todavia no hay productos agregados.">
                    <Columns>
                        <asp:BoundField DataField="Producto" HeaderText="Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio unitario" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                    </Columns>
                </asp:GridView>

                <p class="text-end">
                    <strong>Total:</strong>
                    <asp:Label ID="lblTotal" runat="server" Text="$0" />
                </p>
            </fieldset>

            <asp:Button ID="btnConfirmar" runat="server"
                Text="Confirmar compra" CssClass="btn btn-primary" />

            <asp:HyperLink ID="lnkCancelar" runat="server"
                NavigateUrl="Compras.aspx" CssClass="btn btn-outline-secondary">
                Cancelar
            </asp:HyperLink>
        </div>
    </div>
</asp:Content>
