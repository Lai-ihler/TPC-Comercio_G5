<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="WebApplication1.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario de producto</h1>
    <p>Completa los datos del producto.</p>

    <div class="row">

        <div class="col-6">

            <fieldset>
                <legend>Datos del producto</legend>

                <div class="mb-3">
                    <asp:Label ID="lblCodigo" runat="server" CssClass="form-label"
                        AssociatedControlID="txtCodigo" Text="Codigo" />

                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" CssClass="form-label"
                        AssociatedControlID="txtNombre" Text="Nombre" />

                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label"
                        AssociatedControlID="txtDescripcion" Text="Descripcion" />

                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"
                        TextMode="MultiLine" Rows="3" Columns="40" />
                </div>
            </fieldset>

            <fieldset>
                <legend>Clasificacion</legend>

                <div class="mb-3">
                    <asp:Label ID="lblMarca" runat="server" CssClass="form-label"
                        AssociatedControlID="ddlMarca" Text="Marca" />

                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Selecciona una marca" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblCategoria" runat="server" CssClass="form-label"
                        AssociatedControlID="ddlCategoria" Text="Categoria" />

                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Selecciona una categoria" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblProveedores" runat="server" CssClass="form-label" Text="Proveedores" />

                    <asp:CheckBoxList ID="cblProveedores" runat="server" />
                </div>
            </fieldset>

            <fieldset>
                <legend>Stock e imagen</legend>

                <div class="mb-3">
                    <asp:Label ID="lblStockMinimo" runat="server" CssClass="form-label"
                        AssociatedControlID="txtStockMinimo" Text="Stock minimo" />

                    <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblPorcentajeGanancia" runat="server" CssClass="form-label"
                        AssociatedControlID="txtPorcentajeGanancia"
                        Text="Porcentaje de ganancia" />

                    <asp:TextBox ID="txtPorcentajeGanancia" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblImagenUrl" runat="server" CssClass="form-label"
                        AssociatedControlID="txtImagenUrl" Text="Imagen URL" />

                    <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" />
                </div>
            </fieldset>

            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Productos.aspx">Cancelar</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
