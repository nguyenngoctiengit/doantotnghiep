USE [NhaHang]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaBan] [nvarchar](10) NOT NULL,
	[TinhTrang] [tinyint] NOT NULL,
 CONSTRAINT [PK__Ban__3520ED6C4E1C0824] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ca]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ca](
	[MaCa] [nvarchar](10) NOT NULL,
	[TenCa] [nvarchar](100) NULL,
	[LuuY] [nvarchar](200) NULL,
	[NgayBD] [datetime] NULL,
	[NgayKT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MaHD] [int] NOT NULL,
	[MaMonAn] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[MaCTHD] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaCTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] NOT NULL,
	[MaBan] [nvarchar](10) NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[NgayLap] [datetime] NULL,
	[TongTien] [int] NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK__HoaDon__2725A6E083A769B9] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuVuc]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuVuc](
	[MaKhuVuc] [int] NOT NULL,
	[TenKhuVuc] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhuVuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMonAn]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMonAn](
	[MaLoai] [nvarchar](10) NOT NULL,
	[TenLoai] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMonAN] [nvarchar](10) NOT NULL,
	[MaLoai] [nvarchar](10) NOT NULL,
	[TenMon] [nvarchar](100) NOT NULL,
	[DVT] [nvarchar](50) NOT NULL,
	[DonGia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMonAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](10) NOT NULL,
	[TenNV] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [datetime] NULL,
	[SDT] [int] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[NgayVaoLam] [datetime] NULL,
	[ChucVu] [nvarchar](100) NULL,
	[phuCap] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaCa] [nvarchar](10) NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[NgayBatDau] [datetime] NOT NULL,
	[NgayKetThuc] [datetime] NULL,
	[MaPC] [int] IDENTITY(1,1) NOT NULL,
	[MaKhuVuc] [int] NULL,
 CONSTRAINT [PK_PhanCong] PRIMARY KEY CLUSTERED 
(
	[MaPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanHoi]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoi](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[HoTenKH] [nvarchar](100) NOT NULL,
	[SDT] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[MaNV] [nvarchar](10) NULL,
	[Hinhthuc] [nvarchar](150) NOT NULL,
	[NoiDung] [nvarchar](700) NOT NULL,
	[NgayLap] [datetime] NULL,
	[TinhTrang] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 8/13/2021 5:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTK] [nvarchar](100) NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[ChucVu] [nvarchar](100) NOT NULL,
	[NgayDK] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'1', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'10', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'11', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'12', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'13', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'14', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'15', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'16', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'17', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'18', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'19', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'2', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'20', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'21', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'22', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'23', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'24', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'25', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'3', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'4', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'5', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'6', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'7', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'8', 0)
INSERT [dbo].[Ban] ([MaBan], [TinhTrang]) VALUES (N'9', 0)
GO
INSERT [dbo].[Ca] ([MaCa], [TenCa], [LuuY], [NgayBD], [NgayKT]) VALUES (N'Ca01', N'CA 1', N'Ca Sa´ng', CAST(N'2021-06-01T00:00:00.000' AS DateTime), CAST(N'2021-07-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Ca] ([MaCa], [TenCa], [LuuY], [NgayBD], [NgayKT]) VALUES (N'Ca02', N'CA 2', N'Ca Tô´i', CAST(N'2021-06-01T00:00:00.000' AS DateTime), CAST(N'2021-07-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (1, N'Ba`n 1-5')
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (2, N'Ba`n 6-10')
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (3, N'Ba`n 11-15')
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (4, N'Ba`n 16-20')
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (5, N'Ba`n 21-25')
GO
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML01', N'Tiến')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML02', N'YaKi')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML03', N'Gohan')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML04', N'YaKiton')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML05', N'Itame')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML06', N'Age')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML07', N'Sashimi')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML08', N'Maki-Roll')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML09', N'Soft drink')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML10', N'Beer')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML11', N'Sochu')
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai]) VALUES (N'ML12', N'Sake')
GO
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD01', N'ML01', N'Hiyashi Konbu', N'Chén', 90000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD04', N'ML01 ', N'Horenso Ohitashi', N'Chén', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD05', N'ML01 ', N'Hiyashi Tomato', N'Chén', 30000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD06', N'ML01', N'Moyashi Namuru', N'Chén', 50000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD07', N'ML01 ', N'Negishio Yakko', N'Chén', 70000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD08', N'ML01 ', N'Edamame', N'Dĩa', 60000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD09', N'ML01 ', N'Butasabu Salad', N'Dĩa', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD10', N'ML01 ', N'Potato Salad', N'Chén', 40000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD100', N'ML12 ', N'Junmai Ginjo 300ml', N'Chai', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD101', N'ML12 ', N'Junmai Ginjo 720ml', N'Chai', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD102', N'ML12 ', N'Junmai Ginjo Glass', N'Ly', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD103', N'ML12 ', N'Bansaku 250ml', N'chai', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD104', N'ML12 ', N'Bansaku Glass', N'Ly', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD105', N'ML12 ', N'Ikkon 250ml', N'Chai', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD106', N'ML12 ', N'Ikkon Glass', N'Ly', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD107', N'ML12 ', N'Karakuchi 720ml', N'Chai', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD108', N'ML12 ', N'Karakuchi 300ml', N'chai', 15000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD11', N'ML01 ', N'Maccaroni Salad', N'Chén', 15000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD12', N'ML01 ', N'Tori Salad', N'Chén', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD13', N'ML01 ', N'Onion Slice', N'Chén', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD14', N'ML01 ', N'Vermiceli Salad', N'Chén', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD15', N'ML02 ', N'Momo', N'xiên', 30000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD16', N'ML02 ', N'Sunagimo', N'xiên', 40000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD17', N'ML02 ', N'Nankotsu', N'xiên', 50000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD18', N'ML02 ', N'Reba', N'xiên', 30000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD19', N'ML02 ', N'Kokoro', N'xiên', 30000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD20', N'ML02 ', N'Kawa', N'xiên', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD21', N'ML02 ', N'Momonegi', N'xiên', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD22', N'ML02 ', N'Bonjiri', N'xiên', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD23', N'ML02 ', N'Sasami', N'xiên', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD24', N'ML02 ', N'Tsukune', N'xiên', 25000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD25', N'ML02 ', N'Tebasaki', N'xiên', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD27', N'ML03 ', N'Gohan', N'Tô', 65000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD28', N'ML03 ', N'Toridon', N'Tô', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD29', N'ML03 ', N'Katsudon', N'Tô', 35000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD30', N'ML03 ', N'Oyakodon', N'Tô', 400000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD31', N'ML03 ', N'Chicken Omrice', N'Dĩa', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD32', N'ML03 ', N'Cuury Rice', N'Dĩa', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD33', N'ML03 ', N'Unagidon', N'Tô', 60000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD34', N'ML03 ', N'Tori Tsukunedon', N'Tô', 70000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD35', N'ML03 ', N'Onigiri', N'Phần', 40000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD36', N'ML03 ', N'Onigiri yaki', N'Phần', 30000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD37', N'ML03 ', N'Tori Chazuke', N'Tô', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD38', N'ML03 ', N'Ume Chazuke', N'Tô', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD39', N'ML03 ', N'Miso Soup', N'Chén', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD40', N'ML03 ', N'Tori Soup', N'', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD51', N'ML04 ', N'Uzura', N'xiên', 160000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD52', N'ML04 ', N'Aspara', N'xiên', 150000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD53', N'ML04 ', N'Enoki', N'xiên', 145000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD54', N'ML04 ', N'Nira Cheese', N'xiên', 150000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD55', N'ML04 ', N'Shimeje', N'xiên', 170000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD56', N'ML04 ', N'Nasu', N'xiên', 160000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD57', N'ML04 ', N'Negi', N'xiên', 150000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD58', N'ML05 ', N'Nikuyasai Itame', N'Dĩa', 50000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD59', N'ML05 ', N'Curry Udon', N'Dĩa', 55000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD60', N'ML05 ', N'Yaki Soba', N'Dĩa', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD61', N'ML05 ', N'Yaki Udon', N'Dĩa', 160000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD62', N'ML05 ', N'Omusoba', N'Dĩa', 50000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD63', N'ML05 ', N'Horenso Omlete', N'Dĩa', 35000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD64', N'ML06 ', N'Torikara Age', N'Dĩa', 40000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD65', N'ML06 ', N'Age Gyoza', N'Dĩa', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD66', N'ML06 ', N'Chiken NanBan', N'Dĩa', 30000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD67', N'ML06 ', N'Ikaring Age', N'Dĩa', 40000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD68', N'ML06 ', N'Nankotsu Karaage', N'Dĩa', 50000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD69', N'ML06 ', N'Yu Rin Chi', N'Dĩa', 45000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD70', N'ML06 ', N'Aji Furai', N'Con', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD71', N'ML06 ', N'Takoyaki', N'Dĩa', 40000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD72', N'ML07 ', N'Salmon Sashimi', N'Phần', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD73', N'ML07 ', N'Maguro Sashimi', N'Phần', 25000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD74', N'ML07 ', N'Tako Sashimi', N'Phần', 25000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD75', N'ML07 ', N'Amaeni Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD76', N'ML07 ', N'Shimesaba Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD77', N'ML07 ', N'Mamakari Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD78', N'ML07 ', N'Santen Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD79', N'ML07 ', N'Higawari Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD80', N'ML07 ', N'Hokkigai Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD81', N'ML07 ', N'Maguro Butsu', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD82', N'ML07 ', N'Natto', N'Phần', 10000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD83', N'ML08 ', N'Salmon Maki', N'Phần', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD84', N'ML08 ', N'Negitoro Maki', N'Phần', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD85', N'ML08 ', N'Anago Avocado Roll', N'Phần', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD86', N'ML08 ', N'Anago HaKo Zushi', N'Phần', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD87', N'ML08 ', N'Salmon Hoko Zushi', N'Phần', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD88', N'ML09 ', N'Tea', N'Ly', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD89', N'ML09 ', N'Coca', N'Lon', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD90', N'ML09 ', N'7up', N'Lon', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD91', N'ML09 ', N'Lemon soda', N'Ly', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD92', N'ML09 ', N'Water', N'Chai', 20000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD93', N'ML10 ', N'Sapporo Craft', N'Ly', 17000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD94', N'ML10 ', N'Sapporo Bottle', N'Chai', 13000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD95', N'ML11 ', N'Kurogodai 720ml', N'Chai', 100000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD96', N'ML11 ', N'Kurogodai Glass', N'Ly', 100000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD97', N'ML11 ', N'Imohajime 720ml', N'Chai', 150000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD98', N'ML11 ', N'Ikinoshima 720ml', N'Chai', 200000)
INSERT [dbo].[MonAn] ([MaMonAN], [MaLoai], [TenMon], [DVT], [DonGia]) VALUES (N'TD99', N'ML11 ', N'Satsuma Kobiki Kuro 720ml', N'Chai', 500000)
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV01', N'Đoàn Kim Huệ', N'Nữ', CAST(N'1998-10-28T00:00:00.000' AS DateTime), 855266455, N'Gò Công,Tiền Giang', N'doankimhue1998@gmail.com', CAST(N'2018-02-28T00:00:00.000' AS DateTime), N'Quản Lý', 1200000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV02', N'Võ Thị Bé Thảo', N'Nữ', CAST(N'1995-01-03T00:00:00.000' AS DateTime), 396956163, N'Tân Hồng, Đồng Tháp', N'vothibethao@gmail.com', CAST(N'2015-06-02T00:00:00.000' AS DateTime), N'Nhân Viên', 1200000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV03', N'Trần Thị Huỳnh Như', N'Nữ', CAST(N'2002-08-17T00:00:00.000' AS DateTime), 968512456, N'Thạnh Hóa, Long An', N'tranthihuynhnhu@gmail.com', CAST(N'2016-06-03T00:00:00.000' AS DateTime), N'Nhân Viên', 1000000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV04', N'Nguyễn Thị Hoàng Oanh', N'Nữ', CAST(N'1997-04-08T00:00:00.000' AS DateTime), 976451253, N'Bình Thạnh, TP.HCM', N'nguyenhoangoanh@gmail.com', CAST(N'2019-06-04T00:00:00.000' AS DateTime), N'Nhân Viên', 1000000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV05', N'Trần Thanh Phong', N'Nam', CAST(N'1987-07-04T00:00:00.000' AS DateTime), 964312564, N'Thạnh Hóa, Long An', N'thanhphong@gmail.com', CAST(N'2015-06-02T00:00:00.000' AS DateTime), N'Nhân Viên', 800000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV06', N'Nguyễn Thị Anh Thư', N'Nữ', CAST(N'1998-01-03T00:00:00.000' AS DateTime), 791544562, N'Long Xuyên, An Giang', N'NguyenThu@gmail.com', CAST(N'2019-06-04T00:00:00.000' AS DateTime), N'Nhân Viên', 800000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV07', N'Trần Thị Thu Nguyên', N'Nữ', CAST(N'1998-09-06T00:00:00.000' AS DateTime), 962457856, N'Bình Thuận', N'Thunguyen1998@gmail.com', CAST(N'2017-06-02T00:00:00.000' AS DateTime), N'Nhân Viên', 600000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV08', N'Trần Thị Ánh Hồng', N'Nữ', CAST(N'2001-08-01T00:00:00.000' AS DateTime), 976431652, N'Q10, TP.HCM', N'Anhhong@gmail.com', CAST(N'2021-02-02T00:00:00.000' AS DateTime), N'Nhân Viên', 700000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV09', N'Nguyễn Phạm Bảo Lam', N'Nam', CAST(N'2003-03-01T00:00:00.000' AS DateTime), 856312457, N'Gò Công,Tiền Giang', N'nguyenbaolam@gmail.com', CAST(N'2018-02-01T00:00:00.000' AS DateTime), N'Nhân Viên', 800000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [Email], [NgayVaoLam], [ChucVu], [phuCap]) VALUES (N'NV10', N'Trần Hoài Thương', N'Nữ', CAST(N'1995-11-10T00:00:00.000' AS DateTime), 896542154, N'Thạnh Hóa, Long An', N'Hoaithuong1995@gmail.com', CAST(N'2014-06-03T00:00:00.000' AS DateTime), N'Nhân Viên', 700000)
GO
SET IDENTITY_INSERT [dbo].[PhanCong] ON 

INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-03T20:55:54.000' AS DateTime), CAST(N'2021-08-07T20:55:54.000' AS DateTime), 28, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV02', CAST(N'2021-08-07T21:05:00.000' AS DateTime), CAST(N'2021-08-01T21:05:00.000' AS DateTime), 29, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV03', CAST(N'2021-08-07T21:05:36.000' AS DateTime), CAST(N'2021-08-01T21:05:36.000' AS DateTime), 30, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca02', N'NV04', CAST(N'2021-08-07T21:05:55.000' AS DateTime), CAST(N'2021-08-01T21:05:55.000' AS DateTime), 31, 2)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca02', N'NV05', CAST(N'2021-08-07T21:06:22.000' AS DateTime), CAST(N'2021-08-01T21:06:22.000' AS DateTime), 32, 2)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca02', N'NV06', CAST(N'2021-08-07T21:06:45.000' AS DateTime), CAST(N'2021-08-01T21:06:45.000' AS DateTime), 33, 2)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca02', N'NV07', CAST(N'2021-08-07T21:07:47.000' AS DateTime), CAST(N'2021-08-01T21:07:47.000' AS DateTime), 34, 2)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV02', CAST(N'2021-08-03T21:10:29.000' AS DateTime), CAST(N'2021-08-07T21:10:29.000' AS DateTime), 37, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV03', CAST(N'2021-08-03T21:10:47.000' AS DateTime), CAST(N'2021-08-07T21:10:47.000' AS DateTime), 38, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV04', CAST(N'2021-08-03T21:11:07.000' AS DateTime), CAST(N'2021-08-07T21:11:07.000' AS DateTime), 39, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV05', CAST(N'2021-08-03T21:11:21.000' AS DateTime), CAST(N'2021-08-03T21:11:21.000' AS DateTime), 40, 2)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV06', CAST(N'2021-08-03T21:12:21.480' AS DateTime), CAST(N'2021-08-03T21:12:21.480' AS DateTime), 41, 2)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV07', CAST(N'2021-08-03T21:12:47.177' AS DateTime), CAST(N'2021-08-03T21:12:47.177' AS DateTime), 42, 3)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV08', CAST(N'2021-08-03T21:13:07.000' AS DateTime), CAST(N'2021-08-03T21:13:07.000' AS DateTime), 43, 3)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV09', CAST(N'2021-08-03T21:14:13.113' AS DateTime), CAST(N'2021-08-03T21:14:13.113' AS DateTime), 44, 3)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca02', N'NV01', CAST(N'2021-08-03T21:14:56.097' AS DateTime), CAST(N'2021-08-03T21:14:56.097' AS DateTime), 45, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca02', N'NV03', CAST(N'2021-08-03T21:15:18.183' AS DateTime), CAST(N'2021-08-03T21:15:18.187' AS DateTime), 46, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV02', CAST(N'2021-08-03T21:16:54.183' AS DateTime), CAST(N'2021-08-03T21:16:54.187' AS DateTime), 47, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-03T21:17:12.813' AS DateTime), CAST(N'2021-08-03T21:17:12.813' AS DateTime), 48, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-21T21:17:32.000' AS DateTime), CAST(N'2021-08-16T21:17:32.000' AS DateTime), 49, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-21T21:18:00.000' AS DateTime), CAST(N'2021-08-16T21:18:00.000' AS DateTime), 50, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-14T21:19:37.000' AS DateTime), CAST(N'2021-08-09T21:19:37.000' AS DateTime), 51, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-03T20:55:54.000' AS DateTime), CAST(N'2021-08-03T20:55:54.000' AS DateTime), 52, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV01', CAST(N'2021-08-09T21:29:35.000' AS DateTime), CAST(N'2021-08-14T21:29:35.000' AS DateTime), 53, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV02', CAST(N'2021-08-10T19:22:20.000' AS DateTime), CAST(N'2021-08-14T19:22:20.000' AS DateTime), 54, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV03', CAST(N'2021-08-15T19:23:32.000' AS DateTime), CAST(N'2021-08-21T19:23:32.000' AS DateTime), 55, 1)
INSERT [dbo].[PhanCong] ([MaCa], [MaNV], [NgayBatDau], [NgayKetThuc], [MaPC], [MaKhuVuc]) VALUES (N'Ca01', N'NV04', CAST(N'2021-08-10T19:23:55.167' AS DateTime), CAST(N'2021-08-10T19:23:55.167' AS DateTime), 56, 1)
SET IDENTITY_INSERT [dbo].[PhanCong] OFF
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [MaNV], [MatKhau], [ChucVu], [NgayDK]) VALUES (N'a', N'NV04', N'123', N'Nhân Viên', CAST(N'2021-06-01' AS Date))
INSERT [dbo].[TaiKhoan] ([TenTK], [MaNV], [MatKhau], [ChucVu], [NgayDK]) VALUES (N'abc', N'NV03', N'1', N'Nhân Viên', CAST(N'2021-06-01' AS Date))
INSERT [dbo].[TaiKhoan] ([TenTK], [MaNV], [MatKhau], [ChucVu], [NgayDK]) VALUES (N'admin', N'NV01', N'123', N'Quản Lý', CAST(N'2021-06-01' AS Date))
INSERT [dbo].[TaiKhoan] ([TenTK], [MaNV], [MatKhau], [ChucVu], [NgayDK]) VALUES (N'hue', N'NV02', N'1', N'Nhân Viên', CAST(N'2021-06-01' AS Date))
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAN])
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [fk_cthd_mahd] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [fk_cthd_mahd]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__MaNV__33D4B598] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__MaNV__33D4B598]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [fk_HoaDon_maban] FOREIGN KEY([MaBan])
REFERENCES [dbo].[Ban] ([MaBan])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [fk_HoaDon_maban]
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiMonAn] ([MaLoai])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaKhuVuc])
REFERENCES [dbo].[KhuVuc] ([MaKhuVuc])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [fk_phancong_maca] FOREIGN KEY([MaCa])
REFERENCES [dbo].[Ca] ([MaCa])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [fk_phancong_maca]
GO
ALTER TABLE [dbo].[PhanHoi]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
