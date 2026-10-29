<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="WebApplication1.FormularioCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario de categoría</h1>
    <p>Completa los datos de la categoría.</p>

    <p>
        <asp:Label ID="lblDescripcion" runat="server"
            AssociatedControlID="txtDescripcion" Text="Descripcion" />
        <br />
        <asp:TextBox ID="txtDescripcion" runat="server" />
    </p>

    <p>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="Categorias.aspx">Cancelar</asp:HyperLink>
    </p>
</asp:Content>
