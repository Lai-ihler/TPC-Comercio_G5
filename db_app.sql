CREATE DATABASE APP_WEB_DB;

USE APP_WEB_DB;

CREATE TABLE PERFIL
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Descripcion VARCHAR(15) NOT NULL
);

CREATE TABLE CLIENTE
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Dni VARCHAR(9) NOT NULL UNIQUE
        CHECK (LEN(Dni) >= 7),
    Email VARCHAR(100) NOT NULL
        CHECK (Email LIKE '%_@_%._'),
    Telefono VARCHAR(20) NOT NULL,
    Direccion VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL
);

CREATE TABLE PROVEEDOR
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    RazonSocial VARCHAR(40) NOT NULL,
    Cuit VARCHAR(11) NOT NULL UNIQUE
        CHECK (LEN(Cuit) = 11),
    Email VARCHAR(100) NOT NULL
        CHECK (Email LIKE '%_@_%._'),
    Telefono VARCHAR(20) NOT NULL,
    Direccion VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL
);

CREATE TABLE USUARIO
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    NombreUsuario VARCHAR(30) NOT NULL UNIQUE,
    Pass VARCHAR(20) NOT NULL
        CHECK (LEN(Pass) >= 8),
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Email VARCHAR(100) NOT NULL
        CHECK (Email LIKE '%_@_%._'),
    Perfil INT NOT NULL
        CONSTRAINT FK_Usuario_IdPerfil
        FOREIGN KEY (Perfil)
        REFERENCES PERFIL(ID),
    Activo BIT NOT NULL
);

CREATE TABLE MARCA
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Descripcion VARCHAR(20) NOT NULL,
    Activo BIT NOT NULL
);

CREATE TABLE CATEGORIA
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Descripcion VARCHAR(20) NOT NULL,
    Activo BIT NOT NULL
);

CREATE TABLE PRODUCTO
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Codigo VARCHAR(15) NOT NULL UNIQUE,
    Nombre VARCHAR(30) NOT NULL,
    Descripcion VARCHAR(200),
    Costo DECIMAL(12, 2) NOT NULL
        CHECK (Costo > 0),
    PrecioVenta DECIMAL(12, 2) NOT NULL
        CHECK (PrecioVenta > 0),
    Marca INT NOT NULL
        CONSTRAINT FK_Producto_IdMarca
        FOREIGN KEY (Marca)
        REFERENCES MARCA(ID),
    Categoria INT NOT NULL
        CONSTRAINT FK_Producto_IdCategoria
        FOREIGN KEY (Categoria)
        REFERENCES CATEGORIA(ID),
    Proveedor INT NOT NULL
        CONSTRAINT FK_Producto_IdProveedor
        FOREIGN KEY (Proveedor)
        REFERENCES PROVEEDOR(ID),
    StockActual INT NOT NULL,
    StockMinimo INT NOT NULL
        CHECK (StockMinimo > 0),
    PorcentajeGanancia DECIMAL(5, 2),
    ImagenUrl VARCHAR(500) NOT NULL,
    Activo BIT NOT NULL
);

CREATE TABLE COMPRA
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Fecha DATETIME NOT NULL,
    Proveedor INT NOT NULL
        CONSTRAINT FK_Compra_IdProveedor
        FOREIGN KEY (Proveedor)
        REFERENCES PROVEEDOR(ID),
    Usuario INT NOT NULL
        CONSTRAINT FK_Compra_IdUsuario
        FOREIGN KEY (Usuario)
        REFERENCES USUARIO(ID),
    Total DECIMAL(12, 2) NOT NULL
        CHECK (Total > 0)
);

CREATE TABLE COMPRA_DETALLE
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Compra INT NOT NULL
        CONSTRAINT FK_CompraDetalle_IdCompra
        FOREIGN KEY (Compra)
        REFERENCES COMPRA(ID),
    Producto INT NOT NULL
        CONSTRAINT FK_CompraDetalle_IdProducto
        FOREIGN KEY (Producto)
        REFERENCES PRODUCTO(ID),
    Cantidad INT NOT NULL
        CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(12, 2) NOT NULL
        CHECK (PrecioUnitario > 0),
    Subtotal AS (Cantidad * PrecioUnitario)
);

CREATE TABLE VENTA
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    NumeroFactura VARCHAR(20) NOT NULL UNIQUE,
    Fecha DATETIME NOT NULL,
    Cliente INT NOT NULL
        CONSTRAINT FK_Venta_IdCliente
        FOREIGN KEY (Cliente)
        REFERENCES CLIENTE(ID),
    Usuario INT NOT NULL
        CONSTRAINT FK_Venta_IdUsuario
        FOREIGN KEY (Usuario)
        REFERENCES USUARIO(ID),
    Total DECIMAL(12, 2) NOT NULL
        CHECK (Total > 0)
);

CREATE TABLE VENTA_DETALLE
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Venta INT NOT NULL
        CONSTRAINT FK_VentaDetalle_IdVenta
        FOREIGN KEY (Venta)
        REFERENCES VENTA(ID),
    Producto INT NOT NULL
        CONSTRAINT FK_VentaDetalle_IdProducto
        FOREIGN KEY (Producto)
        REFERENCES PRODUCTO(ID),
    Cantidad INT NOT NULL
        CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(12, 2) NOT NULL
        CHECK (PrecioUnitario > 0),
    Subtotal AS (Cantidad * PrecioUnitario)
);