<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="WebApplication1.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario de categoría</h1>
    <p>Completa los datos de la categoría.</p>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">

                <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label"
                    AssociatedControlID="txtDescripcion" Text="Descripcion" />
                
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            </div>


            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
            <asp:HyperLink ID="lnkCancelar" runat="server" 
                NavigateUrl="Categorias.aspx">Cancelar</asp:HyperLink>
        </div>
    </div>
</asp:Content>
