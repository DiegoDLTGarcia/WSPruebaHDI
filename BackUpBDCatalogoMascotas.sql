USE [CatalogoMascotas]
GO
/****** Object:  Table [dbo].[Especies]    Script Date: 09/05/2024 09:38:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[id_especie] [int] IDENTITY(1,1) NOT NULL,
	[nombre_especie] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_especie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 09/05/2024 09:38:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascotas](
	[id_mascota] [int] IDENTITY(1,1) NOT NULL,
	[id_propietario] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[id_raza] [int] NOT NULL,
	[edad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_mascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propietarios]    Script Date: 09/05/2024 09:38:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propietarios](
	[id_propietario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[correo_electronico] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_propietario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Razas]    Script Date: 09/05/2024 09:38:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Razas](
	[id_raza] [int] IDENTITY(1,1) NOT NULL,
	[id_especie] [int] NOT NULL,
	[nombre_raza] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_raza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD FOREIGN KEY([id_propietario])
REFERENCES [dbo].[Propietarios] ([id_propietario])
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD FOREIGN KEY([id_raza])
REFERENCES [dbo].[Razas] ([id_raza])
GO
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD FOREIGN KEY([id_especie])
REFERENCES [dbo].[Especies] ([id_especie])
GO
/****** Object:  StoredProcedure [dbo].[BuscarMascotasPorRaza]    Script Date: 09/05/2024 09:38:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarMascotasPorRaza]
    @nombre_raza VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT M.*
    FROM [dbo].[Mascotas] AS M
    INNER JOIN [dbo].[Razas] AS R ON M.[id_raza] = R.[id_raza]
    WHERE R.[nombre_raza] = @nombre_raza;
END;
GO
/****** Object:  StoredProcedure [dbo].[MostrarPerros]    Script Date: 09/05/2024 09:38:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarPerros]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT M.*
    FROM [dbo].[Mascotas] AS M
    INNER JOIN [dbo].[Razas] AS R ON M.[id_raza] = R.[id_raza]
    INNER JOIN [dbo].[Especies] AS E ON R.[id_especie] = E.[id_especie]
    WHERE E.[nombre_especie] = 'Perro';
END;
GO
