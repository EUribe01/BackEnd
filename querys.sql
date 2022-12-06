use KNG8_Project

CREATE TABLE Usuarios (

	[ConsecutivoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](100) NOT NULL,
	[Cedula] [int] NOT NULL,
	[Correo] [varchar](75) NOT NULL,
	[Contrasenna] [varchar](75) NOT NULL,
	[FechaNacimiento] DATE NOT NULL,
	[Telefono] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[EstadoID] [int] NOT NULL,
	[ErrorID] [int] NOT NULL,
	[ExpedienteID] [int] ,
	[CitaID] [int] ,
	[OdontogramaID] [int] ,
	
 CONSTRAINT [PK_TUSUARIO] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Roles (

	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,

 CONSTRAINT [PK_ROLES] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER TABLE Usuarios WITH CHECK ADD CONSTRAINT [FK_USUARIOS_TRol] FOREIGN KEY([RoleID])
REFERENCES Roles ([RoleID])
GO
ALTER TABLE Usuarios CHECK CONSTRAINT [FK_USUARIOS_TRol]
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Estados (

	[ConsecutivoEstado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER TABLE Usuarios WITH CHECK ADD CONSTRAINT [FK_USUARIOS_TPerfil] FOREIGN KEY([EstadoID])
REFERENCES Estados ([ConsecutivoEstado])
GO
ALTER TABLE Usuarios CHECK CONSTRAINT [FK_USUARIOS_TPerfil]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [BITACORA](
	[ConsecutivoError] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[CodigoError] [int] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Origen] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBITACORA] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER TABLE [BITACORA]  WITH CHECK ADD  CONSTRAINT [FK_TBITACORA_USUARIO] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [Usuarios] ([ConsecutivoUsuario])
GO
ALTER TABLE [BITACORA] CHECK CONSTRAINT [FK_TBITACORA_USUARIO]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Expediente(
	[ConsecutivoExpediente] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	
 CONSTRAINT [PK_Expediente] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoExpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

---------------------------------------------------------------------------------------------------

ALTER TABLE Expediente WITH CHECK ADD CONSTRAINT [FK_USUARIOS_TExpediente] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES Usuarios ([ConsecutivoUsuario])
GO
ALTER TABLE Expediente CHECK CONSTRAINT [FK_TExpediente_USUARIOS]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Citas (

	[CitaID] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[TipoID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[FechaHora] DATETIME NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[CitaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------------------------------------------------------------------------------------------

ALTER TABLE Citas WITH CHECK ADD CONSTRAINT [FK_USUARIOS_TCitas] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES Usuarios ([ConsecutivoUsuario])
GO
ALTER TABLE Citas CHECK CONSTRAINT [FK_USUARIOS_TCitas]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE TiposCitas (

	[TipoID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	
 CONSTRAINT [PK_TuTipoCita] PRIMARY KEY CLUSTERED 
(
	[TipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER TABLE Citas WITH CHECK ADD CONSTRAINT [FK_Citas_TTipoCitas] FOREIGN KEY([CitaID])
REFERENCES TiposCitas ([TipoID])
GO
ALTER TABLE Citas CHECK CONSTRAINT [FK_Citas_TTipoCitas]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Odontograma (

	[OdontogramaID] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[NDiente] [int] NOT NULL,
	CoordenadaUno [int],
	CoordenadaDos [int],
	CoordenadaTres [int],
	CoordenadaCuatro [int],
	
 CONSTRAINT [PK_Odontograma] PRIMARY KEY CLUSTERED 
(
	[OdontogramaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER TABLE Odontograma WITH CHECK ADD CONSTRAINT [FK_USUARIOS_TOdontograma] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES Usuarios ([ConsecutivoUsuario])
GO
ALTER TABLE Odontograma CHECK CONSTRAINT [FK_USUARIOS_TOdontograma]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Correos(
	[ConsecutivoCorreos] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[To] [VARCHAR](75) NOT NULL,
	[CC] [VARCHAR] (75) NOT NULL,
	[Subject] [VARCHAR] (75) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	
 CONSTRAINT [PK_Correos] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoCorreos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE Consultar_Datos_Usuario
	@Correo VARCHAR(75),
	@Contrasenna VARCHAR(75)
AS
BEGIN

	SELECT	ConsecutivoUsuario,
			Correo,
			NombreCompleto,
			RoleID,
			EstadoID
	FROM	Usuarios
	WHERE	Correo		= @Correo
		AND Contrasenna = @Contrasenna
		AND RoleID		= 1

END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Registrar_Bitacora]
	@Correo				VARCHAR(75),
	@FechaHora          DATETIME,
	@CodigoError		INT,
	@Descripcion		NVARCHAR(MAX),
	@Origen				VARCHAR(50)
AS
BEGIN
	
	DECLARE @ConsecutivoUsuario BIGINT
	SELECT	@ConsecutivoUsuario = ConsecutivoUsuario
	FROM	Usuarios
	WHERE	Correo = @Correo

	IF(@ConsecutivoUsuario IS NOT NULL)
	BEGIN
		
		INSERT INTO Bitacora (ConsecutivoUsuario,FechaHora,CodigoError,Descripcion,Origen)
		VALUES (@ConsecutivoUsuario, @FechaHora, @CodigoError, @Descripcion, @Origen)
           
	END

END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE [Registrar_Correo]
	@To				VARCHAR(75),
	@ConsecutivoUsuario bigint,
	@FechaHora          DATETIME,
	@CC		VARCHAR(75),
	@Body		NVARCHAR(MAX),
	@Subject				VARCHAR(50)

AS
BEGIN

INSERT INTO [dbo].[Correos]
           ([ConsecutivoUsuario]
           ,[To]
           ,[CC]
           ,[Subject]
           ,[Body]
           ,[FechaHora])
     VALUES
           (@ConsecutivoUsuario
		   ,@To
		   ,@CC	
           ,@Subject
           ,@Body
           ,@FechaHora)

END
GO


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE SelectAllUsers
AS
SELECT * FROM Usuarios
GO;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE SelectAllRoles
AS
SELECT * FROM ROLES
GO;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE SelectAllTiposCitas
AS
SELECT * FROM TiposCitas
GO;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE SelectAllErrors
AS
SELECT * FROM [BITACORA]
GO;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT TiposCitas ON 
GO
INSERT TiposCitas ([TipoID], [Descripcion]) VALUES (1,'Consulta General')
GO
INSERT TiposCitas ([TipoID], [Descripcion]) VALUES (2,'Operación')
GO
INSERT TiposCitas ([TipoID], [Descripcion]) VALUES (3,'Odontología')
GO
INSERT TiposCitas ([TipoID], [Descripcion]) VALUES (4,'Especialidad')
GO
SET IDENTITY_INSERT TiposCitas OFF
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT Roles ON 
GO
INSERT Roles (RoleID, [Descripcion]) VALUES (1,'Administrador')
GO
INSERT Roles (RoleID, [Descripcion]) VALUES (2,'Cliente')
GO
INSERT Roles (RoleID, [Descripcion]) VALUES (3,'General')
GO
SET IDENTITY_INSERT Roles OFF
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT Estados ON 
GO
INSERT Estados (ConsecutivoEstado, [Descripcion]) VALUES (1,'Activo')
GO
INSERT Estados (ConsecutivoEstado, [Descripcion]) VALUES (2,'Aislado')
GO
INSERT Estados (ConsecutivoEstado, [Descripcion]) VALUES (3,'Inactivo')
GO
SET IDENTITY_INSERT Estados OFF
GO