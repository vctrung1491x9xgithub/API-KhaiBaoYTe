USE [master]
GO
/****** Object:  Database [DB_KhaiBaoYTe]    Script Date: 27-01-2021 15:26:07 ******/
CREATE DATABASE [DB_KhaiBaoYTe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'khaibaoyte', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\khaibaoyte.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'khaibaoyte_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\khaibaoyte_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_KhaiBaoYTe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET  MULTI_USER 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DB_KhaiBaoYTe]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[MaCauHoi] [nvarchar](10) NOT NULL,
	[TenCauHoi] [nvarchar](255) NOT NULL,
	[NoiDung] [nvarchar](255) NOT NULL,
	[NhomCauHoi] [nvarchar](50) NOT NULL,
	[TrangThai] [nvarchar](10) NOT NULL,
	[MaDonVi] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__CauHoi__1937D77B45C6FFCB] PRIMARY KEY CLUSTERED 
(
	[MaCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucDonVi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucDonVi](
	[MaDonVi] [nvarchar](10) NOT NULL,
	[TenDonVi] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__DanhMucD__DDA5A6CFFA0540EE] PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucNguoiDung]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucNguoiDung](
	[TaiKhoan] [nvarchar](20) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[VaiTro] [nvarchar](10) NOT NULL CONSTRAINT [DF_DanhMucNguoiDung_VaiTro]  DEFAULT (N'user'),
	[MaDonVi] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__DanhMucN__D5B8C7F137580D16] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucThamSo]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucThamSo](
	[MaThamSo] [nvarchar](10) NOT NULL,
	[TenThamSo] [nvarchar](50) NOT NULL,
	[GiaTri] [nvarchar](20) NOT NULL,
	[MaDonVi] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_DanhMucThamSo] PRIMARY KEY CLUSTERED 
(
	[MaThamSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoiKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoiKhai](
	[MaLoiKhai] [nvarchar](10) NOT NULL,
	[LoiKhaiBao] [nvarchar](255) NOT NULL,
	[MaCauHoi] [nvarchar](10) NOT NULL,
	[MaToKhai] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__LoiKhai__8B048A4E679BB2A0] PRIMARY KEY CLUSTERED 
(
	[MaLoiKhai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiKhaiBao]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiKhaiBao](
	[MaNguoiKhai] [nvarchar](10) NOT NULL,
	[TenNguoiKhai] [nvarchar](25) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
	[NoiOHienNay] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__NguoiKha__D522BB707367D477] PRIMARY KEY CLUSTERED 
(
	[MaNguoiKhai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToKhai](
	[MaToKhai] [nvarchar](10) NOT NULL,
	[ThoiGianKhai] [datetime] NOT NULL,
	[MaNguoiKhai] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__ToKhai__ED643711992EFACE] PRIMARY KEY CLUSTERED 
(
	[MaToKhai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[CauHoi] ([MaCauHoi], [TenCauHoi], [NoiDung], [NhomCauHoi], [TrangThai], [MaDonVi]) VALUES (N'CH8FJKM', N'Gender', N'Giới tính?', N'NB', N'True', N'DVZL15R')
INSERT [dbo].[CauHoi] ([MaCauHoi], [TenCauHoi], [NoiDung], [NhomCauHoi], [TrangThai], [MaDonVi]) VALUES (N'CHDDWZB', N'Age', N'Tuổi của bạn', N'NA', N'True', N'DV1M6M5')
INSERT [dbo].[CauHoi] ([MaCauHoi], [TenCauHoi], [NoiDung], [NhomCauHoi], [TrangThai], [MaDonVi]) VALUES (N'CHOS3HQ', N'Name', N'Họ và tên?', N'NA', N'True', N'DV1M6M5')
INSERT [dbo].[DanhMucDonVi] ([MaDonVi], [TenDonVi]) VALUES (N'DV1M6M5', N'Đơn vị 3')
INSERT [dbo].[DanhMucDonVi] ([MaDonVi], [TenDonVi]) VALUES (N'DVU9PRQ', N'Đơn vị 2')
INSERT [dbo].[DanhMucDonVi] ([MaDonVi], [TenDonVi]) VALUES (N'DVZL15R', N'Đơn vị 1')
INSERT [dbo].[DanhMucNguoiDung] ([TaiKhoan], [MatKhau], [VaiTro], [MaDonVi]) VALUES (N'levu', N'123', N'User', N'DV1M6M5')
INSERT [dbo].[DanhMucNguoiDung] ([TaiKhoan], [MatKhau], [VaiTro], [MaDonVi]) VALUES (N'votrung', N'123', N'Admin', N'DVZL15R')
INSERT [dbo].[DanhMucThamSo] ([MaThamSo], [TenThamSo], [GiaTri], [MaDonVi]) VALUES (N'TSBZRY5', N'Tham số 2', N'True', N'DV1M6M5')
INSERT [dbo].[DanhMucThamSo] ([MaThamSo], [TenThamSo], [GiaTri], [MaDonVi]) VALUES (N'TSFV5AW', N'Tham số 3', N'False', N'DVZL15R')
INSERT [dbo].[DanhMucThamSo] ([MaThamSo], [TenThamSo], [GiaTri], [MaDonVi]) VALUES (N'TSR4RJ1', N'Tham số 1', N'True', N'DVU9PRQ')
INSERT [dbo].[LoiKhai] ([MaLoiKhai], [LoiKhaiBao], [MaCauHoi], [MaToKhai]) VALUES (N'LKJ34XZ', N'Trung', N'CHOS3HQ', N'TKPW5FZ')
INSERT [dbo].[NguoiKhaiBao] ([MaNguoiKhai], [TenNguoiKhai], [NgaySinh], [SDT], [NoiOHienNay]) VALUES (N'NK1RLE1', N'Nguyễn Văn A', CAST(N'2021-01-04' AS Date), N'0147852369', N'Hà Nội')
INSERT [dbo].[NguoiKhaiBao] ([MaNguoiKhai], [TenNguoiKhai], [NgaySinh], [SDT], [NoiOHienNay]) VALUES (N'NKZ8K3E', N'Nguyễn Văn B', CAST(N'2021-01-17' AS Date), N'0774787675', N'Cần Thơ')
INSERT [dbo].[ToKhai] ([MaToKhai], [ThoiGianKhai], [MaNguoiKhai]) VALUES (N'TKPW5FZ', CAST(N'2021-01-27 07:30:23.810' AS DateTime), N'NK1RLE1')
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_MaDonVi_CH] FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DanhMucDonVi] ([MaDonVi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_MaDonVi_CH]
GO
ALTER TABLE [dbo].[DanhMucNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_MaDonVi_DMND] FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DanhMucDonVi] ([MaDonVi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhMucNguoiDung] CHECK CONSTRAINT [FK_MaDonVi_DMND]
GO
ALTER TABLE [dbo].[DanhMucThamSo]  WITH CHECK ADD  CONSTRAINT [FK_MaDonVi_DMTS] FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DanhMucDonVi] ([MaDonVi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhMucThamSo] CHECK CONSTRAINT [FK_MaDonVi_DMTS]
GO
ALTER TABLE [dbo].[LoiKhai]  WITH CHECK ADD  CONSTRAINT [FK_MaCauHoi] FOREIGN KEY([MaCauHoi])
REFERENCES [dbo].[CauHoi] ([MaCauHoi])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoiKhai] CHECK CONSTRAINT [FK_MaCauHoi]
GO
ALTER TABLE [dbo].[LoiKhai]  WITH CHECK ADD  CONSTRAINT [FK_MaToKhai] FOREIGN KEY([MaToKhai])
REFERENCES [dbo].[ToKhai] ([MaToKhai])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoiKhai] CHECK CONSTRAINT [FK_MaToKhai]
GO
ALTER TABLE [dbo].[ToKhai]  WITH CHECK ADD  CONSTRAINT [FK_MaNguoiKhai] FOREIGN KEY([MaNguoiKhai])
REFERENCES [dbo].[NguoiKhaiBao] ([MaNguoiKhai])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ToKhai] CHECK CONSTRAINT [FK_MaNguoiKhai]
GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteCauHoi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteCauHoi]
	@MaCauHoi nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	DELETE FROM CauHoi
	WHERE MaCauHoi = @MaCauHoi 
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteDonVi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteDonVi]
	@MaDonVi nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM dbo.DanhMucDonVi
	WHERE MaDonVi = @MaDonVi
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteLoiKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteLoiKhai]
	@MaLoiKhai nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	DELETE FROM LoiKhai
	WHERE MaLoiKhai = @MaLoiKhai
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteNguoiDung]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteNguoiDung]
	@TaiKhoan nvarchar(20)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM dbo.DanhMucNguoiDung
	WHERE TaiKhoan = @TaiKhoan 
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteNguoiKhaiBao]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteNguoiKhaiBao]
	@MaNguoiKhai nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM NguoiKhaiBao
	WHERE MaNguoiKhai = @MaNguoiKhai
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteThamSo]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteThamSo]
	@MaThamSo nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM dbo.DanhMucThamSo
	WHERE MaThamSo = @MaThamSo
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteToKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_DeleteToKhai]
	@MaToKhai nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF;
	DELETE FROM ToKhai
	WHERE MaToKhai = @MaToKhai
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCauHoi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetCauHoi]
AS
BEGIN 
	SET NOCOUNT OFF;
	SELECT * FROM CauHoi AS C
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCauHoi_ByName_ByNhom_ByTrangThai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetCauHoi_ByName_ByNhom_ByTrangThai]
	@TenCauHoi nvarchar(255),
	@NhomCauHoi nvarchar(50),
	@TrangThai nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM CauHoi
	WHERE TenCauHoi LIKE '%' + @TenCauHoi + '%' 
			or NhomCauHoi = @NhomCauHoi 
			or TrangThai = @TrangThai
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCauHoi_NhomA]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetCauHoi_NhomA]
AS
BEGIN 
	SET NOCOUNT Off;
	 SELECT * FROM dbo.CauHoi AS C
	 WHERE C.NhomCauHoi = 'NA' and C.TrangThai = 'True'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCauHoi_NhomB]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetCauHoi_NhomB]
AS
BEGIN 
	SET NOCOUNT Off;
	 SELECT * FROM dbo.CauHoi AS C
	 WHERE C.NhomCauHoi = 'NB' and C.TrangThai = 'True'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCauHoi_NhomC]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetCauHoi_NhomC]
AS
BEGIN 
	SET NOCOUNT Off;
	 SELECT * FROM dbo.CauHoi AS C
	 WHERE C.NhomCauHoi = 'NC' and C.TrangThai = 'True'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCauHoiByID]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetCauHoiByID]
	@MaCauHoi nvarchar(10)
AS
BEGIN
	
	SET NOCOUNT OFF;
	SELECT * FROM dbo.CauHoi AS C
	WHERE C.MaCauHoi = @MaCauHoi
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetDonVi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetDonVi]
AS
BEGIN 
	SET NOCOUNT OFF; 
	SELECT * FROM dbo.DanhMucDonVi AS DMDV
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetDonViByID]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Proc_GetDonViByID]
	@MaDonVi nvarchar(10)
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT * FROM dbo.DanhMucDonVi
	WHERE MaDonVi = @MaDonVi
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetLoiKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetLoiKhai]
AS
BEGIN 
	SET NOCOUNT OFF;
	SELECT * FROM LoiKhai AS L
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiDung]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetNguoiDung] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.DanhMucNguoiDung AS DMND
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiDung_ByAccountNPassword]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetNguoiDung_ByAccountNPassword]
	@TaiKhoan nvarchar(20),
	@MatKhau nvarchar(255)
AS
BEGIN 
	SET NOCOUNT ON;
	SELECT * FROM dbo.DanhMucNguoiDung
	WHERE TaiKhoan = @TaiKhoan and MatKhau = @MatKhau
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiDung_ByTaiKhoan_ByDonVi_ByVaiTro]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetNguoiDung_ByTaiKhoan_ByDonVi_ByVaiTro]
	@TaiKhoan nvarchar(20),
	@VaiTro nvarchar(10),
	@TenDonVi nvarchar(255)
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT DISTINCT TaiKhoan, MatKhau, VaiTro, N.MaDonVi
	FROM DanhMucNguoiDung AS N, DanhMucDonVi AS D
    WHERE TaiKhoan = @TaiKhoan or VaiTro = @VaiTro or TenDonVi LIKE '%' + @TenDonVi + '%' and N.MaDonVi = D.MaDonVi
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiDungByTaiKhoan]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetNguoiDungByTaiKhoan]
	@TaiKhoan nvarchar(20)
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM dbo.DanhMucNguoiDung
	WHERE TaiKhoan = @TaiKhoan
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiKhaiBao]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetNguoiKhaiBao]
AS
BEGIN
	
	SET NOCOUNT OFF;
	SELECT * FROM NguoiKhaiBao
   
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiKhaiBao_ByName_ByNumberPhone_ByCity]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetNguoiKhaiBao_ByName_ByNumberPhone_ByCity]
	@TenNguoiKhai nvarchar(25),
	@SDT nvarchar(15),
	@NoiOHienNay nvarchar(255)
AS
BEGIN 
	SET NOCOUNT ON;
	SELECT * FROM NguoiKhaiBao 
	WHERE TenNguoiKhai LIKE '%' + @TenNguoiKhai + '%' 
			or SDT = @SDT 
			or NoiOHienNay LIKE '%' + @NoiOHienNay + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetNguoiKhaiBaoByID]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetNguoiKhaiBaoByID]
	@MaNguoiKhai nvarchar(10)
AS
BEGIN

	SET NOCOUNT OFF;
	SELECT * FROM dbo.NguoiKhaiBao AS N 
	WHERE N.MaNguoiKhai = @MaNguoiKhai 
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetThamSo]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetThamSo]

AS
BEGIN

	SET NOCOUNT ON;
	SELECT * FROM DanhMucThamSo
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetThamSoByID]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetThamSoByID]
	@MaThamSo nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM dbo.DanhMucThamSo
	WHERE MaThamSo = @MaThamSo
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetToKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_GetToKhai] 
AS
BEGIN 
	SET NOCOUNT OFF; 
	SELECT * FROM ToKhai
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetToKhai_ByName]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetToKhai_ByName] 
	@TenNguoiKhai nvarchar(25)
AS
BEGIN 
	SET NOCOUNT OFF;
	SELECT MaToKhai, ThoiGianKhai, T.MaNguoiKhai 
	FROM NguoiKhaiBao AS N, ToKhai AS T
	WHERE N.TenNguoiKhai LIKE '%' + @TenNguoiKhai + '%' AND
			T.MaNguoiKhai = N.MaNguoiKhai

END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertCauHoi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_InsertCauHoi]
	@MaCauHoi nvarchar(10),
	@TenCauHoi nvarchar(255),  
	@NoiDung nvarchar(255),
	@NhomCauHoi nvarchar(50),
	@TrangThai nvarchar(10),
	@MaDonVi nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	INSERT INTO dbo.CauHoi(MaCauHoi, TenCauHoi, NoiDung, NhomCauHoi, TrangThai, MaDonVi)
	VALUES (@MaCauHoi, @TenCauHoi, @NoiDung, @NhomCauHoi, @TrangThai, @MaDonVi)
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertDonVi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_InsertDonVi]
	@MaDonVi nvarchar(10),
	@TenDonVi nvarchar(255)
AS
BEGIN
	SET NOCOUNT OFF;
		INSERT INTO dbo.DanhMucDonVi(MaDonVi, TenDonVi)
		VALUES (@MaDonVi, @TenDonVi)

END
GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertLoiKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[Proc_InsertLoiKhai] 
	@MaLoiKhai nvarchar(20),
	@LoiKhaiBao nvarchar(255),  
	@MaCauHoi nvarchar(10),
	@MaToKhai nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	INSERT INTO dbo.LoiKhai (MaLoiKhai, LoiKhaiBao, MaCauHoi, MaToKhai)
	VALUES (@MaLoiKhai, @LoiKhaiBao, @MaCauHoi, @MaToKhai)
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertNguoiDung]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_InsertNguoiDung]
	@TaiKhoan nvarchar(20),
	@MatKhau nvarchar(255),  
	@VaiTro nvarchar(10),
	@MaDonVi nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	INSERT INTO dbo.DanhMucNguoiDung (TaiKhoan, MatKhau, VaiTro, MaDonVi)
	VALUES (@TaiKhoan, @MatKhau, @VaiTro, @MaDonVi)
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertNguoiKhaiBao]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_InsertNguoiKhaiBao]
	@MaNguoiKhai nvarchar(10),
	@TenNguoiKhai nvarchar(25), 
	@NgaySinh date,
	@SDT nvarchar(15),
	@NoiOHienNay nvarchar(255)
AS
BEGIN 
	SET NOCOUNT OFF;
	INSERT INTO dbo.NguoiKhaiBao (MaNguoiKhai, TenNguoiKhai, NgaySinh, SDT, NoiOHienNay)
	VALUES ( @MaNguoiKhai, @TenNguoiKhai, @NgaySinh, @SDT, @NoiOHienNay)
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertThamSo]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_InsertThamSo]
	@MaThamSo nvarchar(10),
	@TenThamSo nvarchar(50),
	@GiaTri nvarchar(20),
	@MaDonVi nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO dbo.DanhMucThamSo (MaThamSo, TenThamSo, GiaTri, MaDonVi)
	VALUES (@MaThamSo, @TenThamSo, @GiaTri, @MaDonVi)
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertToKhai]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_InsertToKhai]
	@MaToKhai nvarchar(10),
	@ThoiGianKhai datetime, 
	@MaNguoiKhai nvarchar(10) 
AS 
BEGIN   
	SET NOCOUNT OFF;
	INSERT INTO dbo.ToKhai(MaToKhai, ThoiGianKhai, MaNguoiKhai)
	VALUES ( @MaToKhai, @ThoiGianKhai, @MaNguoiKhai)
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateCauHoi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_UpdateCauHoi]
	@MaCauHoi nvarchar(10),
	@TenCauHoi nvarchar(255),  
	@NoiDung nvarchar(255),
	@NhomCauHoi nvarchar(50),
	@TrangThai nvarchar(10),
	@MaDonVi nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	UPDATE CauHoi
	SET TenCauHoi = @TenCauHoi, 
		NoiDung = @NoiDung,
		NhomCauHoi = @NhomCauHoi,
		TrangThai = @TrangThai,
		MaDonVi = @MaDonVi
	WHERE MaCauHoi = @MaCauHoi
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateDonVi]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_UpdateDonVi]
	@MaDonVi nvarchar(10),
	@TenDonVi nvarchar(255) 
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE dbo.DanhMucDonVi 
	SET TenDonVi = @TenDonVi
	WHERE MaDonVi = @MaDonVi
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateNguoiDung]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_UpdateNguoiDung]
	@TaiKhoan nvarchar(20),
	@MatKhau nvarchar(255), 
	@VaiTro nvarchar(10),
	@MaDonVi nvarchar(10) 
AS
BEGIN 
	SET NOCOUNT OFF;
	UPDATE DanhMucNguoiDung
	SET MatKhau = @MatKhau,
		VaiTro = @VaiTro, 
		MaDonVi = @MaDonVi
	WHERE TaiKhoan = @TaiKhoan
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateNguoiKhaiBao]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[Proc_UpdateNguoiKhaiBao]
	@MaNguoiKhai nvarchar(10),
	@TenNguoiKhai nvarchar(25), 
	@NgaySinh date,
	@SDT nvarchar(15),
	@NoiOHienNay nvarchar(255)
AS
BEGIN 
	SET NOCOUNT OFF;
	UPDATE NguoiKhaiBao
	SET TenNguoiKhai = @TenNguoiKhai,
		NgaySinh = @NgaySinh,
		SDT = @SDT,
		NoiOHienNay = @NoiOHienNay
	WHERE MaNguoiKhai = @MaNguoiKhai

END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateThamSo]    Script Date: 27-01-2021 15:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_UpdateThamSo]
	@MaThamSo nvarchar(10),
	@TenThamSo nvarchar(50),
	@GiaTri nvarchar(20),
	@MaDonVi nvarchar(10)
AS
BEGIN 
	SET NOCOUNT OFF; 
	UPDATE dbo.DanhMucThamSo
	SET TenThamSo = @TenThamSo, GiaTri = @GiaTri, MaDonVi = @MaDonVi
	WHERE MaThamSo = @MaThamSo
END
GO
USE [master]
GO
ALTER DATABASE [DB_KhaiBaoYTe] SET  READ_WRITE 
GO
