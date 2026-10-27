<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApplication1.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Clientes</h1>
            <p>Listado de clientes del comercio</p>

            <asp:GridView
                ID="gvClientes"
                runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="No hay clientes para mostrar.">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Dni" HeaderText="DNI" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>