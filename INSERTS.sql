USE APP_WEB_DB;

INSERT INTO PERFIL (Descripcion) VALUES
('Administrador'),
('Vendedor'),
('Deposito'),
('Supervisor'),
('Contador');

INSERT INTO CLIENTE
(Nombre, Apellido, Dni, Email, Telefono, Direccion, Activo)
VALUES
('Lucia', 'Fernandez', '32145678', 'lucia@gmail.com', '1145678901', 'Rivadavia 120', 1),
('Martin', 'Rodriguez', '33256789', 'martin@hotmail.com', '1156789012', 'Mitre 350', 1),
('Sofia', 'Martinez', '34367890', 'sofia@yahoo.com', '1167890123', 'Belgrano 780', 1),
('Diego', 'Sanchez', '35478901', 'diego@gmail.com', '1178901234', 'Sarmiento 560', 1),
('Valentina', 'Diaz', '36589012', 'valentina@hotmail.com', '1189012345', 'Moreno 920', 1);

INSERT INTO PROVEEDOR
(RazonSocial, Cuit, Email, Telefono, Direccion, Activo)
VALUES
('Distribuidora Norte', '30123456789', 'ventas@norte.com', '1144556677', 'Av. Rivadavia 1500', 1),
('Comercial Sur', '30234567890', 'info@sur.com', '1155667788', 'San Martin 230', 1),
('Mayorista Central', '30345678901', 'contacto@central.com', '1166778899', 'Belgrano 450', 1),
('Importadora Global', '30456789012', 'ventas@global.com', '1177889900', 'Mitre 780', 1),
('Distribuciones Oeste', '30567890123', 'info@oeste.com', '1188990011', 'Moreno 1200', 1);

INSERT INTO USUARIO
(NombreUsuario, Pass, Nombre, Apellido, Email, Perfil, Activo)
VALUES
('admin01', 'Admin1234', 'Juan', 'Perez', 'admin@app.com', 1, 1),
('vendedor01', 'Venta1234', 'Pedro', 'Gomez', 'pedro@app.com', 2, 1),
('deposito01', 'Deposito1', 'Laura', 'Lopez', 'laura@app.com', 3, 1),
('supervisor01', 'Super1234', 'Carlos', 'Diaz', 'carlos@app.com', 4, 1),
('contador01', 'Conta1234', 'Maria', 'Ruiz', 'maria@app.com', 5, 1);

INSERT INTO MARCA (Descripcion, Activo) VALUES
('Samsung', 1),
('Motorola', 1),
('Logitech', 1),
('Sony', 1),
('Philips', 1);

INSERT INTO CATEGORIA (Descripcion, Activo) VALUES
('Celulares', 1),
('Accesorios', 1),
('Audio', 1),
('Informatica', 1),
('Electrodomesticos', 1);

INSERT INTO PRODUCTO
(Codigo, Nombre, Descripcion, Costo, PrecioVenta, Marca, Categoria, Proveedor, StockActual, StockMinimo, PorcentajeGanancia, ImagenUrl, Activo)
VALUES
('PROD001', 'Galaxy A15', 'Celular Samsung 128GB', 200000, 260000, 1, 1, 1, 15, 3, 30, 'https://ejemplo.com/galaxy.jpg', 1),
('PROD002', 'Moto G24', 'Celular Motorola 128GB', 150000, 195000, 2, 1, 2, 20, 5, 30, 'https://ejemplo.com/moto.jpg', 1),
('PROD003', 'Mouse M170', 'Mouse inalambrico Logitech', 12000, 18000, 3, 2, 3, 30, 5, 50, 'https://ejemplo.com/mouse.jpg', 1),
('PROD004', 'Auricular WH', 'Auricular inalambrico Sony', 45000, 60000, 4, 3, 4, 12, 2, 33.33, 'https://ejemplo.com/auricular.jpg', 1),
('PROD005', 'Licuadora HR', 'Licuadora Philips 500W', 80000, 104000, 5, 5, 5, 8, 2, 30, 'https://ejemplo.com/licuadora.jpg', 1);

INSERT INTO COMPRA (Fecha, Proveedor, Usuario, Total) VALUES
(GETDATE(), 1, 1, 400000),
(GETDATE(), 2, 2, 300000),
(GETDATE(), 3, 3, 24000),
(GETDATE(), 4, 4, 90000),
(GETDATE(), 5, 5, 160000);

INSERT INTO COMPRA_DETALLE (Compra, Producto, Cantidad, PrecioUnitario) VALUES
(1, 1, 2, 200000),
(2, 2, 2, 150000),
(3, 3, 2, 12000),
(4, 4, 2, 45000),
(5, 5, 2, 80000);

INSERT INTO VENTA (NumeroFactura, Fecha, Cliente, Usuario, Total) VALUES
('FAC-0001', GETDATE(), 1, 2, 260000),
('FAC-0002', GETDATE(), 2, 2, 195000),
('FAC-0003', GETDATE(), 4, 1, 36000),
('FAC-0004', GETDATE(), 5, 3, 60000),
('FAC-0005', GETDATE(), 3, 4, 208000);

INSERT INTO VENTA_DETALLE (Venta, Producto, Cantidad, PrecioUnitario) VALUES
(1, 1, 1, 260000),
(2, 2, 1, 195000),
(3, 3, 2, 18000),
(4, 4, 1, 60000),
(5, 5, 2, 104000);