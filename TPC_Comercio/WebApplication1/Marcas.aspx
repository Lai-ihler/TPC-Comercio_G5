<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="WebApplication1.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Marcas</h1>
    <p>Listado de marcas.</p>

    <p>
        <asp:HyperLink ID="lnkNuevo" runat="server" CssClass="btn btn-primary mb-3"
            NavigateUrl="FormularioMarca.aspx">Nueva marca</asp:HyperLink>
    </p>

    <div class="mb-3">
        <asp:Label Text="Filtrar" runat="server" />
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
    </div>

    <asp:GridView ID="gvMarcas" runat="server" CssClass="table"
        AutoGenerateColumns="False" DataKeyNames="Id"
        OnSelectedIndexChanged="gvMarcas_SelectedIndexChanged"

        EmptyDataText="No hay marcas para mostrar.">

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
</asp:Content>
