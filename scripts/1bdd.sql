USE [bd_movimientos]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 9/8/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[codigo_cli] [int] IDENTITY(1,1) NOT NULL,
	[contrasena_cli] [varchar](max) NOT NULL,
	[estado_cli] [bit] NOT NULL,
	[codigo_per] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[codigo_cli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 9/8/2022 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[codigo_cue] [int] IDENTITY(1,1) NOT NULL,
	[numero_cue] [varchar](50) NOT NULL,
	[saldo_inicial_cue] [money] NOT NULL,
	[codigo_tc] [int] NOT NULL,
	[codigo_cli] [int] NOT NULL,
	[codigo_est] [int] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[codigo_cue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCuenta]    Script Date: 9/8/2022 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCuenta](
	[codigo_est] [int] IDENTITY(1,1) NOT NULL,
	[nombre_est] [varchar](50) NOT NULL,
	[estado_est] [bit] NOT NULL,
 CONSTRAINT [PK_EstadoCuenta] PRIMARY KEY CLUSTERED 
(
	[codigo_est] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 9/8/2022 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[codigo_mov] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha_mov] [datetime] NOT NULL,
	[valor_mov] [money] NOT NULL,
	[saldo_mov] [money] NOT NULL,
	[codigo_cue] [int] NOT NULL,
	[codigo_tm] [int] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[codigo_mov] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 9/8/2022 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[codigo_per] [int] IDENTITY(1,1) NOT NULL,
	[nombre_per] [varchar](50) NOT NULL,
	[genero_per] [bit] NOT NULL,
	[edad_per] [int] NOT NULL,
	[identificacion_per] [varchar](20) NOT NULL,
	[direccion_per] [varchar](200) NOT NULL,
	[telefono_per] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[codigo_per] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCuenta]    Script Date: 9/8/2022 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCuenta](
	[codigo_tc] [int] IDENTITY(1,1) NOT NULL,
	[cuenta_tc] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_TipoCuenta] PRIMARY KEY CLUSTERED 
(
	[codigo_tc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 9/8/2022 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[codigo_tm] [int] IDENTITY(1,1) NOT NULL,
	[movimiento_tp] [varchar](50) NOT NULL,
	[estado_tp] [bit] NOT NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[codigo_tm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([codigo_cli], [contrasena_cli], [estado_cli], [codigo_per]) VALUES (1, N'1234', 1, 2)
INSERT [dbo].[Cliente] ([codigo_cli], [contrasena_cli], [estado_cli], [codigo_per]) VALUES (2, N'5678', 1, 3)
INSERT [dbo].[Cliente] ([codigo_cli], [contrasena_cli], [estado_cli], [codigo_per]) VALUES (4, N'1245', 1, 4)
INSERT [dbo].[Cliente] ([codigo_cli], [contrasena_cli], [estado_cli], [codigo_per]) VALUES (5, N'2222', 1, 4)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([codigo_cue], [numero_cue], [saldo_inicial_cue], [codigo_tc], [codigo_cli], [codigo_est]) VALUES (6, N'478758', 2000.0000, 1, 1, 1)
INSERT [dbo].[Cuenta] ([codigo_cue], [numero_cue], [saldo_inicial_cue], [codigo_tc], [codigo_cli], [codigo_est]) VALUES (8, N'225487', 100.0000, 2, 2, 1)
INSERT [dbo].[Cuenta] ([codigo_cue], [numero_cue], [saldo_inicial_cue], [codigo_tc], [codigo_cli], [codigo_est]) VALUES (10, N'496825', 540.0000, 2, 2, 1)
INSERT [dbo].[Cuenta] ([codigo_cue], [numero_cue], [saldo_inicial_cue], [codigo_tc], [codigo_cli], [codigo_est]) VALUES (11, N'495878', 0.0000, 1, 4, 1)
INSERT [dbo].[Cuenta] ([codigo_cue], [numero_cue], [saldo_inicial_cue], [codigo_tc], [codigo_cli], [codigo_est]) VALUES (12, N'585545', 100.0000, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoCuenta] ON 

INSERT [dbo].[EstadoCuenta] ([codigo_est], [nombre_est], [estado_est]) VALUES (1, N'Activa', 1)
SET IDENTITY_INSERT [dbo].[EstadoCuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([codigo_mov], [fecha_mov], [valor_mov], [saldo_mov], [codigo_cue], [codigo_tm]) VALUES (2, CAST(N'2022-09-01T08:10:25.000' AS DateTime), 200.0000, 1800.0000, 6, 1)
INSERT [dbo].[Movimiento] ([codigo_mov], [fecha_mov], [valor_mov], [saldo_mov], [codigo_cue], [codigo_tm]) VALUES (8, CAST(N'2022-09-02T18:15:25.000' AS DateTime), 600.0000, 700.0000, 8, 2)
INSERT [dbo].[Movimiento] ([codigo_mov], [fecha_mov], [valor_mov], [saldo_mov], [codigo_cue], [codigo_tm]) VALUES (9, CAST(N'2022-09-02T18:15:25.000' AS DateTime), 150.0000, 150.0000, 11, 2)
INSERT [dbo].[Movimiento] ([codigo_mov], [fecha_mov], [valor_mov], [saldo_mov], [codigo_cue], [codigo_tm]) VALUES (10, CAST(N'2022-09-04T18:15:25.000' AS DateTime), 540.0000, 0.0000, 10, 1)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([codigo_per], [nombre_per], [genero_per], [edad_per], [identificacion_per], [direccion_per], [telefono_per]) VALUES (2, N'Jose Lema', 1, 30, N'1722046628', N'otavalo sn principal', N'098254785')
INSERT [dbo].[Persona] ([codigo_per], [nombre_per], [genero_per], [edad_per], [identificacion_per], [direccion_per], [telefono_per]) VALUES (3, N'Marianela Montalvo', 0, 25, N'1711235121', N'Amazonas Y NNUU', N'097548965')
INSERT [dbo].[Persona] ([codigo_per], [nombre_per], [genero_per], [edad_per], [identificacion_per], [direccion_per], [telefono_per]) VALUES (4, N'Juan Osoario', 1, 24, N'1111111111', N'13 Junio y Equinoccial', N'098874587')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCuenta] ON 

INSERT [dbo].[TipoCuenta] ([codigo_tc], [cuenta_tc], [estado]) VALUES (1, N'Ahorosss', 1)
INSERT [dbo].[TipoCuenta] ([codigo_tc], [cuenta_tc], [estado]) VALUES (2, N'Corriente', 1)
SET IDENTITY_INSERT [dbo].[TipoCuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoMovimiento] ON 

INSERT [dbo].[TipoMovimiento] ([codigo_tm], [movimiento_tp], [estado_tp]) VALUES (1, N'Retiro', 1)
INSERT [dbo].[TipoMovimiento] ([codigo_tm], [movimiento_tp], [estado_tp]) VALUES (2, N'Deposito', 1)
SET IDENTITY_INSERT [dbo].[TipoMovimiento] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([codigo_per])
REFERENCES [dbo].[Persona] ([codigo_per])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_EstadoCuenta] FOREIGN KEY([codigo_est])
REFERENCES [dbo].[EstadoCuenta] ([codigo_est])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_EstadoCuenta]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY([codigo_tc])
REFERENCES [dbo].[TipoCuenta] ([codigo_tc])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta] FOREIGN KEY([codigo_cue])
REFERENCES [dbo].[Cuenta] ([codigo_cue])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_TipoMovimiento] FOREIGN KEY([codigo_tm])
REFERENCES [dbo].[TipoMovimiento] ([codigo_tm])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_TipoMovimiento]
GO
