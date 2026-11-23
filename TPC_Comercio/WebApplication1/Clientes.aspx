<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApplication1.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Clientes</h1>
        <p>Listado de clientes del comercio</p>

        <div class="mb-3">
            <asp:HyperLink ID="lnkNuevo" runat="server"
                NavigateUrl="FormularioCliente.aspx"
                CssClass="btn btn-primary mb-3">
                Nuevo cliente
            </asp:HyperLink>
        </div>

         <div class="mb-3">
            <asp:Label ID="lblFiltro" runat="server"
                AssociatedControlID="txtFiltro"
                Text="Filtrar clientes" />

            <asp:TextBox ID="txtFiltro" runat="server"
                CssClass="form-control mb-3"
                AutoPostBack="true"
                OnTextChanged="txtFiltro_TextChanged" />
        </div>
    
        <asp:GridView
            ID="gvClientes"
            runat="server"
            CssClass="table"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnSelectedIndexChanged="gvClientes_SelectedIndexChanged"
            EmptyDataText="No hay clientes para mostrar.">
    
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍" />
            </Columns>
    
        </asp:GridView>
    </div>
</asp:Content>
