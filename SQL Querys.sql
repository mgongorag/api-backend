/*****************************************************/
/***************SCRIPTS DE LAS TABLAS*****************/
/*****************************************************/

/*CREACION TABLA USUARIOS*/

CREATE TABLE TblUsuarios(
	IdUsuario int not null,
	TxtNomBres nvarchar(50) not null,
	TxtApellidos nvarchar(50) not null,
	TxtDireccion nvarchar(50) not null,
	TxtEmail nvarchar(50) not null,
	TxtPassword nvarchar(50) not null,
	FechaDeIngreso datetime not null,
	IntEstado tinyint not null,
	CONSTRAINT IdUsuarioPK PRIMARY KEY (IdUsuario) 
)

ALTER SCHEMA Sesion TRANSFER dbo.TblUsuarios
SELECT * FROM Sesion.TblUsuarios;

/* CREACION TABLA TOKENS */

CREATE TABLE TblTokens(
	IdToken int not null,
	TxtToken nVarchar(250) not null,
	VigenciaEnMinutos int not null,
	IdUsuario int not null,
	FechaIngreso datetime not null,
	IntEstado tinyint,
	CONSTRAINT IdTokenPK PRIMARY KEY(IdToken),
	CONSTRAINT IdUsuarioFK FOREIGN KEY(IdUsuario) REFERENCES Sesion.TblUsuarios(IdUsuario)
)

ALTER SCHEMA Sesion TRANSFER dbo.TblTokens;

/*CREACION TABLA INSTITUCIONES*/
CREATE TABLE TblInstituciones(
	IdInstitucion smallint not null,
	TxtCodigoUE smallint not null,
	TxtNombre nvarchar(100) not null,
	IdComunidad smallInt not null,
	TxtDireccion nvarchar(250),
	FechaIngreso datetime not null,
	IntEstado tinyint not null,
	CONSTRAINT IdInstitucionPK PRIMARY KEY(IdInstitucion)
)

ALTER SCHEMA Sistema TRANSFER Sesion.TblInstituciones;

/* TABLA ROLES */

CREATE TABLE TblRoles(
	IdRol tinyint not null,
	TxtNombre nvarchar(50) not null,
	TxtDescripcion nvarchar(50) not null,
	FechaIngreso datetime not null,
	IntEstado tinyint not null,
	CONSTRAINT IdRolPK PRIMARY KEY(IdRol)
)

ALTER SCHEMA Sesion TRANSFER dbo.TblRoles;

/*TABLA USUARIOS POR ROLES*/

CREATE TABLE TblUsuariosPorRoles(
	IdUsuarioPorRol smallint not null,
	IdUsuario int not null,
	IdRol tinyint not null,
	IdUsuarioIngresadoPor int not null,
	FechaIngreso datetime not null,
	IntEstado tinyint not null,
	CONSTRAINT idUsuarioPorRolPK PRIMARY KEY(IdUsuarioPorRol),
	CONSTRAINT IdUsuarioFK FOREIGN KEY (idUsuario) REFERENCES Sesion.TblUsuarios(IdUsuario),
	CONSTRAINT IdUsuarioIngresadoPorFK FOREIGN KEY (IdUsuarioIngresadoPor) REFERENCES Sesion.TblUsuarios(IdUsuario)
)

ALTER SCHEMA Sesion TRANSFER dbo.TblUsuariosPorRoles;

ALTER TABLE dbo.TblUsuariosPorRoles ADD
FOREIGN KEY (IdRol) REFERENCES Sesion.TblRoles(IdRol);


/*TABLA MENUS*/
CREATE TABLE TblMenus(
	IdMenu tinyint not null,
	IdModulo tinyint not null,
	TxtNombre nvarchar(50) not null,
	TxtDescripcion nvarchar(50) not null, 
	TxtLink nvarchar(250) not null,
	TxtImagen nvarchar(250),
	IdMenuPadre tinyint not null,
	IntEstado tinyint not null,
	DblOrden decimal(4,2) not null,
	CONSTRAINT IdMenuPK PRIMARY KEY (IdMenu),
	CONSTRAINT IdModuloFK FOREIGN KEY(IdModulo) REFERENCES Sesion.TblModulos(IdModulo),
	CONSTRAINT idMenuFK FOREIGN KEY(IdMenuPadre) REFERENCES TblMenus(IdMenu)

)
ALTER SCHEMA Sesion TRANSFER dbo.TblMenus;


/* TABLA MODULOS*/

CREATE TABLE TblModulos(
	IdModulo tinyint not null,
	TxtNombre nvarchar(50) not null,
	TxtDescripcion nvarchar(150) not null,
	TxtImagen nvarchar(250),
	IntEstado bit not null,
	
	CONSTRAINT IdModuloPK PRIMARY KEY (IdModulo)
	
)
ALTER SCHEMA Sesion TRANSFER dbo.TblModulos;


/* TABLA USUARIOS POR INSTITUCION (SESION) */

CREATE TABLE TblUsuariosPorInstitucion(
	IdUsuarioInstitucion int not null,
	IdUsuario int not null,
	IdInstitucion smallint not null,
	IdIngresadoPor int not null,
	FechaIngreso datetime not null,
	IntEstado tinyint not null,
	CONSTRAINT IdUsuarioInstitucionPK PRIMARY KEY(IdUsuarioInstitucion),
	CONSTRAINT IdUsuario_FK FOREIGN KEY(IdUsuario) REFERENCES Sesion.TblUsuarios(IdUsuario),
	CONSTRAINT IdInstitucionFK FOREIGN KEY(IdInstitucion) REFERENCES Sesion.TblInstituciones(IdInstitucion),
	CONSTRAINT IdUsuarioIngresadoPor_FK FOREIGN KEY(IdIngresadoPor) REFERENCES Sesion.TblUsuarios(IdUsuario)
)
ALTER SCHEMA Sesion TRANSFER dbo.TblUsuariosPorInstitucion;


/* TABLA ROLES POR MENUS */

CREATE TABLE TblRolesPorMenus(
	IdRolPorMenu tinyint not null,
	IdRol tinyint not null,
	IdMenu tinyint not null,
	Agregar bit null,
	ModificarActualizar bit not null,
	Eliminar bit not null,
	Consultar bit not null,
	Imprimir bit not null,
	Reservar bit not null,
	Aprobar bit not null,
	Finalizar bit not null,
	IdUsuario int not null,
	FechaIngreso datetime,
	IntEstado tinyint not null,
	CONSTRAINT IdRolPorMenuPK PRIMARY KEY(IdRolPorMenu),
	FOREIGN KEY (IdRol) REFERENCES Sesion.TblRoles(IdRol),
	FOREIGN KEY (IdMenu) REFERENCES Sesion.TblMenus(IdMenu),
	FOREIGN KEY (IdUsuario) REFERENCES Sesion.TblUsuarios(IdUsuario)
)

ALTER SCHEMA Sesion TRANSFER dbo.TblRolesPorMenus;

INSERT INTO Sistema.TblInstituciones values(1, 201, 'Ministerio de Salud', 1, 'Ciudad de Guatemala', getdate(), 1);
INSERT INTO Sesion.TblUsuariosPorInstitucion values (1, 1, 1,1, getdate(), 1);