<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="WebApplication1.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administrar Categorias</h1>
    <p>Completa los datos de la categoría.</p>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">

                <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label"
                    AssociatedControlID="txtDescripcion" Text="Descripcion" />
                
                 <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="20" />
                <asp:RequiredFieldValidator ErrorMessage="Ingresá el nombre de la categoría." ControlToValidate="txtDescripcion" CssClass="text-danger" runat="server" />
                <asp:Label ID="lblErrorDescripcion" runat="server" CssClass="text-danger" />
            </div>


            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" onClick="btnGuardar_Click" />
     

       <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" />
     
        
            <asp:HyperLink ID="lnkCancelar" runat="server" 
                NavigateUrl="Categorias.aspx">Cancelar</asp:HyperLink>
             
     

                
        </div>
    </div>
</asp:Content>
