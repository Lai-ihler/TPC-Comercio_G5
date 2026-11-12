<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioMarca.aspx.cs" Inherits="WebApplication1.FormularioMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administrar Marcas</h1>
    <p>Completa los datos de la marca.</p>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">

                <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label"
                    AssociatedControlID="txtDescripcion" Text="Nombre de la Marca" />

                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="20" />
                <asp:RequiredFieldValidator ErrorMessage="Ingresá el nombre de la marca." ControlToValidate="txtDescripcion" CssClass="text-danger" runat="server" />
                <asp:Label ID="lblErrorDescripcion" runat="server" CssClass="text-danger" />

            </div>
            <p>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

                <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" />
                <asp:HyperLink ID="lnkCancelar" runat="server"
                    NavigateUrl="Marcas.aspx">Cancelar</asp:HyperLink>

            </p>
        </div>
    </div>
</asp:Content>
