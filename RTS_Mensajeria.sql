/**
	Dynamics Works
	Brandon Alexander
	RTS_Mensajeria v 1.2
*/
USE master
GO
DROP DATABASE RTS_Mensajeria
GO
CREATE DATABASE RTS_Mensajeria
GO
USE RTS_Mensajeria
GO

CREATE TABLE Nivel (
	Id_Nivel INT IDENTITY (1, 1) NOT NULL,
	Ubicacion VARCHAR (100) DEFAULT 'Edificio', /*Edificio, Comercial*/
	Descripcion TEXT,
	Estado VARCHAR (100) DEFAULT 'Activo', /*Activo, Inactivo*/
	CONSTRAINT PK_Nivel PRIMARY KEY (Id_Nivel)
);

CREATE TABLE HorarioEntrega (
	Id_HorarioEntrega INT IDENTITY (1, 1) NOT NULL,
	Hora_Entrega TIME,
	Hora_Salida TIME,
	Estado VARCHAR (100) DEFAULT 'Activo',
	CONSTRAINT PK_HorarioEntrega PRIMARY KEY (Id_HorarioEntrega)
);

CREATE TABLE TipoUsuario (
	Id_TipoUsuario INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Detalle TEXT,
	Estado VARCHAR (100) DEFAULT 'Activo', /*Activo, Inactivo*/
	CONSTRAINT PK_TipoUsuario PRIMARY KEY (Id_TipoUsuario)
);

INSERT INTO TipoUsuario (Nombre) VALUES ('Administrador GTO');
INSERT INTO TipoUsuario (Nombre) VALUES ('Administrador Edificio');
INSERT INTO TipoUsuario (Nombre) VALUES ('Supervisor Edifico');
INSERT INTO TipoUsuario (Nombre) VALUES ('Gerencia Cliente');
INSERT INTO TipoUsuario (Nombre) VALUES ('Supervisor Cliente');
INSERT INTO TipoUsuario (Nombre) VALUES ('Mensajero');

CREATE Table Usuario (
	Id_Usuario INT IDENTITY (1, 1) NOT NULL,
	Id_TipoUsuario INT NOT NULL,
	Usuario VARCHAR (100) DEFAULT NULL,
	NombreCompleto VARCHAR (255) DEFAULT NULL,
	CUI VARCHAR (100) DEFAULT NULL,
	Correo VARCHAR (200) DEFAULT NULL,
	Telefono VARCHAR (200) DEFAULT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (Id_Usuario),
	ConSTRAINT FK_TipoUsuario FOREIGN KEY (Id_TipoUsuario) REFERENCES TipoUsuario (Id_TipoUsuario)
);

CREATE TABLE Empresa (
	Id_Empresa INT IDENTITY (1, 1) NOT NULL,
	Id_Usuario INT,
	Nombre VARCHAR (255) DEFAULT NULL,
	TipoEmpresa VARCHAR (255) DEFAULT 'Oficina', /*Oficina, Comercial, Administración*/
	Estado VARCHAR (100) DEFAULT 'Activo', /*Activo, Inactivo*/
	CONSTRAINT PK_Empresa PRIMARY KEY (Id_Empresa),
	CONSTRAINT FK_Empresa_Usuario FOREIGN KEY (Id_Usuario) REFERENCES Usuario (Id_Usuario)
);

CREATE TABLE Oficina (
	Id_Oficina INT IDENTITY (1, 1) NOT NULL,
	Id_Nivel INT NOT NULL,
	Id_Empresa INT,
	Ocupada INT DEFAULT 0,
	Nombre VARCHAR (255) DEFAULT 'Oficina', 
	Estado VARCHAR (100) DEFAULT 'Activo', /*Activo, Inactivo*/
	CONSTRAINT PK_Oficina PRIMARY KEY (Id_Oficina),
	CONSTRAINT FK_Oficina_Nivel FOREIGN KEY (Id_Nivel) REFERENCES Nivel (Id_Nivel),
	CONSTRAINT FK_Oficina_Empresa FOREIGN KEY (Id_Empresa) REFERENCES Empresa (Id_Empresa)
);

CREATE TABLE Contacto (
	Id_Contacto INT IDENTITY (1, 1) NOT NULL,
	Id_Empresa INT NOT NULL,
	Nombre VARCHAR (200),
	CUI VARCHAR (100),
	Correo VARCHAR (200),
	Notificar INT DEFAULT 0,
	Estado VARCHAR (100) DEFAULT 'Activo', /*Activo, Inactivo*/
	CONSTRAINT PK_Contacto PRIMARY KEY (Id_Contacto),
	CONSTRAINT PK_Contacto_Empresa FOREIGN KEY (Id_Empresa) REFERENCES Empresa (Id_Empresa)
);

CREATE TABLE Proveedor (
	Id_Proveedor INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (255) DEFAULT NULL,
	Estado VARCHAR (100) DEFAULT 'Activo', /*Activo, Inactivo*/
	CONSTRAINT PK_Proveedor PRIMARY KEY (Id_Proveedor)
);

CREATE TABLE IngresoProveedor (
	Id_IngresoProveedor INT IDENTITY (1, 1) NOT NULL,
	Codigo_IngresoProveedor VARCHAR (100) NOT NULL,
	Id_Proveedor INT NOT NULL,
	Id_Usuario INT,
	Id_HorarioEntrega INT NOT NULL,
	Fecha_Ingreso DATE,
	Fecha_Creacion DATETIME DEFAULT GETDATE(),
	Detalle_Ingreso TEXT,
	Detalle_Producto TEXT,
	No_Paquetes INT DEFAULT 1,
	Elevador VARCHAR (20) DEFAULT 'No',
	Aprobada VARCHAR (20) DEFAULT 'No',
	CONSTRAINT PK_IngresoProveedor PRIMARY KEY (Id_IngresoProveedor),
	CONSTRAINT FK_IngresoProveedor_Proveedor FOREIGN KEY (Id_Proveedor)  REFERENCES Proveedor (Id_Proveedor),
	CONSTRAINT FK_IngresoProveedor_HoraEntrega FOREIGN KEY (Id_HorarioEntrega) REFERENCES HorarioEntrega (Id_HorarioEntrega),
	CONSTRAINT FK_IngresoProveedor_Usuario FOREIGN KEY (Id_Usuario) REFERENCES Usuario (Id_Usuario)
);

CREATE TABLE DetalleIngresoProveedor (
	Id_DetalleIngresoProveedor INT IDENTITY (1, 1) NOT NULL,
	Id_IngresoProveedor INT NOT NULL,
	CodigoDetalle TEXT,
	Detalle_Rechazo TEXT,
	Hora_Entrega TIME,
	Estado_Entrega VARCHAR (100) DEFAULT 'En espera', /*En espera, entregando, recibido*/
	CONSTRAINT PK_DetalleIngresoProveedor PRIMARY KEY (Id_DetalleIngresoProveedor),
	CONSTRAINT FK_DetalleIngresoProveedor_IngresoProveedor FOREIGN KEY (Id_IngresoProveedor) REFERENCES IngresoProveedor (Id_IngresoProveedor)

);

CREATE TABLE Modulo (
	Id_Modulo INT IDENTITY (1, 1) NOT NULL,
	Id_TipoUsuario INT NOT NULL,
	Nombre VARCHAR (200) NOT NULL,
	Enlace VARCHAR (100) DEFAULT NULL,
	Extra VARCHAR (100) DEFAULT NULL,
	CONSTRAINT PK_Modulo PRIMARY KEY (Id_Modulo),
	CONSTRAINT FK_Modulo_TipoUsuario FOREIGN KEY (Id_TipoUsuario) REFERENCES TipoUsuario (Id_TipoUsuario)
);

CREATE TABLE Ingreso (
	Id_Ingreso INT IDENTITY (1, 1) NOT NULL,
	Codigo_Ingreso VARCHAR (100) DEFAULT NULL,
	Id_Empresa INT NOT NULL,
	Id_Proveedor INT NOT NULL,
	Id_Usuario INT NOT NULL,
	No_Paquetes INT DEFAULT 1,
	Nombre_Mensajero VARCHAR (255) DEFAULT NULL,
	CUI_Mensajero VARCHAR (255) DEFAULT NULL,
	Detalle_Ingreso TEXT,
	Fecha_Ingreso DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_Ingreso PRIMARY KEY (Id_Ingreso),
	CONSTRAINT FK_Ingreso_Empresa FOREIGN KEY (Id_Empresa) REFERENCES Empresa (Id_Empresa),
	CONSTRAINT FK_Ingreso_Proveedor FOREIGN KEY (Id_Proveedor) REFERENCES Proveedor (Id_Proveedor),
	CONSTRAINT FK_Ingreso_Usuario FOREIGN KEY (Id_Usuario) REFERENCES Usuario (Id_Usuario)
);

CREATE TABLE Mensajero (
	Id_Mensajero INT IDENTITY (1, 1) NOT NULL,
	Id_Ingreso INT,
	Orden VARCHAR (100) DEFAULT 'Ascendente', /*Ascendente, Descendente*/
	Tipo_Ingreso VARCHAR (100) DEFAULT 'Entrada',  /*Entrada, Salida*/
	Nombre VARCHAR (255) DEFAULT NULL, 
	CUI VARCHAR (100) DEFAULT NULL,
	Carnet VARCHAR (100) DEFAULT NULL,
	CONSTRAINT PK_Mensajero PRIMARY KEY (Id_Mensajero),
	/*Cambiar de ser necesario*/
	CONSTRAINT FK_Mensajero_Ingreso FOREIGN KEY (Id_Ingreso) REFERENCES Ingreso (Id_Ingreso)
);

CREATE Table RutaEntrega (
	Id_RutaEntrega INT IDENTITY (1, 1),
	Id_Ingreso INT,
	Id_SolicitudProveedor INT,
	Orden VARCHAR (100) DEFAULT 'Ascendente', /*Ascendente, Descendente*/
	Anticipada VARCHAR (100) DEFAULT 'No',
	CONSTRAINT PK_RutaEntrega PRIMARY KEY (Id_RutaEntrega),
	CONSTRAINT FK_RutaEntrega_Ingreso FOREIGN KEY (Id_Ingreso) REFERENCES Ingreso (Id_Ingreso),
	CONSTRAINT FK_RutaEntrega_SolicitudProveedor FOREIGN KEY (Id_SolicitudProveedor) REFERENCES IngresoProveedor (Id_IngresoProveedor)
);