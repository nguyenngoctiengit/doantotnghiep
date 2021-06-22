create database NhaHang
go
use NhaHang
go
set dateformat dmy
go
create table LoaiMonAn
	(
	MaLoai Nvarchar (10) PRIMARY KEY,
	TenLoai Nvarchar (10) not null
	)
go
create table MonAn
	( 
	MaMonAN Nvarchar (10)PRIMARY KEY,
	MaLoai Nvarchar (10)not null,
	TenMon Nvarchar  (100)not null,
	DVT Nvarchar (50)not null, 
	DonGia int not null,
	foreign key (MaLoai) REFERENCES LoaiMonAn(MaLoai)
	)
go

CREATE TABLE NhanVien 
	( 
	MaNV  nvarchar(10) NOT NULL
	PRIMARY KEY(MaNV), 
	TenNV nvarchar(100) NULL,
	GioiTinh nvarchar(10) NULL,		
	NgaySinh datetime NULL,	
	SDT int NULL,
	DiaChi nvarchar(200) NULL,	
	Email nvarchar(200) NULL,
	NgayVaoLam datetime null,
	ChucVu nvarchar(100) NULL,
	phuCap int,
	)
GO
CREATE TABLE TaiKhoan 
( 
TenTK nvarchar(100) NOT NULL	
PRIMARY KEY(TenTK), 
MaNV nvarchar(10) NOT NULL,
MatKhau nvarchar(100) NOT NULL,	
ChucVu nvarchar(100) NOT NULL,	
NgayDK date NULL
foreign key (MaNV) REFERENCES NhanVien(MaNV),
)
GO

create table PhanHoi
	(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	HoTenKH nvarchar (100)not null,
	SDT int not null,
	Email nvarchar (100)not null,
	MaNV nvarchar(10) NULL,
	Hinhthuc nvarchar(150) not null,
	NoiDung nvarchar(700) not null,		
	NgayLap datetime,
	TinhTrang nvarchar(100) null,
	foreign key (MaNV) REFERENCES NhanVien(MaNV)
	)
go


CREATE TABLE CTHD 
	( 
	
	MaHD int NOT NULL,
	PRIMARY KEY( MaHD,MaMonAn),
	MaMonAn nvarchar(10) NOT NULL,
	SoLuong int NULL,
	DonGia int NULL,
	foreign key (MaMonAn) REFERENCES MonAn(MaMonAn),
	)
GO

CREATE TABLE HoaDon
	(
	MaHD INT not null,
	PRIMARY KEY (MaHD),
	MaBan nvarchar(10) not null,
	MaNV nvarchar(10) NOT NULL,
	MaKH NVARCHAR(10) NOT NULL,		
	NgayLap datetime,
	TongTien int,
	foreign key (MaNV) REFERENCES NhanVien(MaNV),
	)
Go
ALTER TABLE CTHD
ADD CONSTRAINT fk_cthd_mahd
FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD)
GO
CREATE TABLE Ca 
	( 
	MaCa nvarchar(10) NOT NULL,
	PRIMARY KEY(MaCa), 
	TenCa nvarchar(100) NULL,
	LuuY nvarchar(200) NULL,
	NgayBD datetime null,
	NgayKT datetime null
	) 
GO  
CREATE TABLE Ban
	(
	MaBan nvarchar(10) NOT NULL,
	PRIMARY KEY(MaBan),
	TinhTrang nvarchar (20) not null
	)
go
ALTER TABLE HoaDon
ADD CONSTRAINT fk_HoaDon_maban
FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)
GO
CREATE TABLE PhanCong 
	( 
	MaCa nvarchar(10) NOT NULL,
	PRIMARY KEY(MaCa,MaNV,MaBan,NgayBatDau), 
	MaNV nvarchar(10) NOT NULL,
	MaBan nvarchar(10) NOT NULL,
	NgayBatDau datetime not null,
	NgayKetThuc datetime null,
	
	foreign key (MaNV) REFERENCES NhanVien(MaNV),	
	)
go


ALTER TABLE PhanCong
ADD CONSTRAINT fk_phancong_maca
FOREIGN KEY (MaCa) REFERENCES Ca(MaCa)
GO
ALTER TABLE PhanCong
ADD CONSTRAINT fk_phancong_maban
FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)
go




INSERT [dbo].[LoaiMonAn] VALUES (N'ML01', N'Tsumami')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML02', N'YaKi')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML03', N'Gohan')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML04', N'YaKiton')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML05', N'Itame')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML06', N'Age')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML07', N'Sashimi')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML08', N'Maki-Roll')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML09', N'Soft drink')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML10', N'Beer')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML11', N'Sochu')
INSERT [dbo].[LoaiMonAn] VALUES (N'ML12', N'Sake')


INSERT [dbo].[NhanVien] VALUES (N'NV01', N'Đoàn Kim Huệ', N'Nữ', '29/10/1998', '0855266455', N'Gò Công,Tiền Giang', N'doankimhue1998@gmail.com', '01/02/2018', N'Quản Lý',  1200000)
INSERT [dbo].[NhanVien] VALUES (N'NV02', N'Võ Thị Bé Thảo', N'Nữ', '03/01/1995', '0396956163', N'Tân Hồng, Đồng Tháp', N'vothibethao@gmail.com', '02/06/2015', N'Quản Lý',  1200000)
INSERT [dbo].[NhanVien] VALUES (N'NV03', N'Trần Thị Huỳnh Như', N'Nữ', '17/08/2002', '0968512456', N'Thạnh Hóa, Long An', N'tranthihuynhnhu@gmail.com', '03/06/2016', N'Nhân Viên',  1000000)
INSERT [dbo].[NhanVien] VALUES (N'NV04', N'Nguyễn Thị Hoàng Oanh', N'Nữ', '08/04/1997', '0976451253', N'Bình Thạnh, TP.HCM', N'nguyenhoangoanh@gmail.com', '04/06/2019', N'Nhân Viên',  1000000)
INSERT [dbo].[NhanVien] VALUES (N'NV05', N'Trần Thanh Phong', N'Nam', '04/07/1987', '0964312564', N'Thạnh Hóa, Long An', N'thanhphong@gmail.com', '02/06/2015', N'Nhân Viên',  800000)
INSERT [dbo].[NhanVien] VALUES (N'NV06', N'Nguyễn Thị Anh Thư', N'Nữ', '03/01/1998', '0791544562', N'Long Xuyên, An Giang', N'NguyenThu@gmail.com', '04/06/2019', N'Nhân Viên',  800000)
INSERT [dbo].[NhanVien] VALUES (N'NV07', N'Trần Thị Thu Nguyên', N'Nữ', '06/09/1998', '0962457856', N'Bình Thuận', N'Thunguyen1998@gmail.com', '02/06/2017', N'Nhân Viên',  600000)
INSERT [dbo].[NhanVien] VALUES (N'NV08', N'Trần Thị Ánh Hồng', N'Nữ', '01/08/2001', '0976431652', N'Q10, TP.HCM', N'Anhhong@gmail.com', '02/02/2021', N'Nhân Viên',  700000)
INSERT [dbo].[NhanVien] VALUES (N'NV09', N'Nguyễn Phạm Bảo Lam', N'Nam', '01/03/2003', '0856312457', N'Gò Công,Tiền Giang', N'nguyenbaolam@gmail.com', '01/02/2018', N'Nhân Viên',  800000)
INSERT [dbo].[NhanVien] VALUES (N'NV10', N'Trần Hoài Thương', N'Nữ', '10/11/1995', '0896542154', N'Thạnh Hóa, Long An', N'Hoaithuong1995@gmail.com', '03/06/2014', N'Nhân Viên',  700000)

INSERT [dbo].[TaiKhoan] VALUES (N'admin',N'NV01', N'123', N'Quản Lý', '01/06/2021')
INSERT [dbo].[TaiKhoan] VALUES (N'hue',N'NV02', N'1', N'Nhân Viên', '01/06/2021')
INSERT [dbo].[TaiKhoan] VALUES (N'abc',N'NV03', N'1', N'Nhân Viên', '01/06/2021')
INSERT [dbo].[TaiKhoan] VALUES (N'a',N'NV04', N'1', N'Nhân Viên', '01/06/2021')

INSERT [dbo].[MonAn] VALUES (N'TD01', N'ML01 ', N'Hiyashi Konbu', N'Chén', 50000)
INSERT [dbo].[MonAn] VALUES (N'TD02', N'ML01 ', N'Kyuri Tataki', N'Chén', 35000)
INSERT [dbo].[MonAn] VALUES (N'TD04', N'ML01 ', N'Horenso Ohitashi', N'Chén', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD05', N'ML01 ', N'Hiyashi Tomato', N'Chén', 30000)
INSERT [dbo].[MonAn] VALUES (N'TD06', N'ML01 ', N'Moyashi Namuru', N'Chén', 60000)
INSERT [dbo].[MonAn] VALUES (N'TD07', N'ML01 ', N'Negishio Yakko', N'Chén', 70000)
INSERT [dbo].[MonAn] VALUES (N'TD08', N'ML01 ', N'Edamame', N'Dĩa', 60000)
INSERT [dbo].[MonAn] VALUES (N'TD09', N'ML01 ', N'Butasabu Salad', N'Dĩa', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD10', N'ML01 ', N'Potato Salad', N'Chén', 40000)
INSERT [dbo].[MonAn] VALUES (N'TD100', N'ML12 ', N'Junmai Ginjo 300ml', N'Chai', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD101', N'ML12 ', N'Junmai Ginjo 720ml', N'Chai', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD102', N'ML12 ', N'Junmai Ginjo Glass', N'Ly', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD103', N'ML12 ', N'Bansaku 250ml', N'chai', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD104', N'ML12 ', N'Bansaku Glass', N'Ly', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD105', N'ML12 ', N'Ikkon 250ml', N'Chai', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD106', N'ML12 ', N'Ikkon Glass', N'Ly', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD107', N'ML12 ', N'Karakuchi 720ml', N'Chai', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD108', N'ML12 ', N'Karakuchi 300ml', N'chai', 15000)
INSERT [dbo].[MonAn] VALUES (N'TD11', N'ML01 ', N'Maccaroni Salad', N'Chén', 15000)
INSERT [dbo].[MonAn] VALUES (N'TD12', N'ML01 ', N'Tori Salad', N'Chén', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD13', N'ML01 ', N'Onion Slice', N'Chén', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD14', N'ML01 ', N'Vermiceli Salad', N'Chén', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD15', N'ML02 ', N'Momo', N'xiên', 30000)
INSERT [dbo].[MonAn] VALUES (N'TD16', N'ML02 ', N'Sunagimo', N'xiên', 40000)
INSERT [dbo].[MonAn] VALUES (N'TD17', N'ML02 ', N'Nankotsu', N'xiên', 50000)
INSERT [dbo].[MonAn] VALUES (N'TD18', N'ML02 ', N'Reba', N'xiên', 30000)
INSERT [dbo].[MonAn] VALUES (N'TD19', N'ML02 ', N'Kokoro', N'xiên', 30000)
INSERT [dbo].[MonAn] VALUES (N'TD20', N'ML02 ', N'Kawa', N'xiên', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD21', N'ML02 ', N'Momonegi', N'xiên', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD22', N'ML02 ', N'Bonjiri', N'xiên', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD23', N'ML02 ', N'Sasami', N'xiên', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD24', N'ML02 ', N'Tsukune', N'xiên', 25000)
INSERT [dbo].[MonAn] VALUES (N'TD25', N'ML02 ', N'Tebasaki', N'xiên', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD27', N'ML03 ', N'Gohan', N'Tô', 65000)
INSERT [dbo].[MonAn] VALUES (N'TD28', N'ML03 ', N'Toridon', N'Tô', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD29', N'ML03 ', N'Katsudon', N'Tô', 35000)
INSERT [dbo].[MonAn] VALUES (N'TD30', N'ML03 ', N'Oyakodon', N'Tô', 400000)
INSERT [dbo].[MonAn] VALUES (N'TD31', N'ML03 ', N'Chicken Omrice', N'Dĩa', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD32', N'ML03 ', N'Cuury Rice', N'Dĩa', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD33', N'ML03 ', N'Unagidon', N'Tô', 60000)
INSERT [dbo].[MonAn] VALUES (N'TD34', N'ML03 ', N'Tori Tsukunedon', N'Tô', 70000)
INSERT [dbo].[MonAn] VALUES (N'TD35', N'ML03 ', N'Onigiri', N'Phần', 40000)
INSERT [dbo].[MonAn] VALUES (N'TD36', N'ML03 ', N'Onigiri yaki', N'Phần', 30000)
INSERT [dbo].[MonAn] VALUES (N'TD37', N'ML03 ', N'Tori Chazuke', N'Tô', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD38', N'ML03 ', N'Ume Chazuke', N'Tô', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD39', N'ML03 ', N'Miso Soup', N'Chén', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD40', N'ML03 ', N'Tori Soup', N'', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD51', N'ML04 ', N'Uzura', N'xiên', 160000)
INSERT [dbo].[MonAn] VALUES (N'TD52', N'ML04 ', N'Aspara', N'xiên', 150000)
INSERT [dbo].[MonAn] VALUES (N'TD53', N'ML04 ', N'Enoki', N'xiên', 145000)
INSERT [dbo].[MonAn] VALUES (N'TD54', N'ML04 ', N'Nira Cheese', N'xiên', 150000)
INSERT [dbo].[MonAn] VALUES (N'TD55', N'ML04 ', N'Shimeje', N'xiên', 170000)
INSERT [dbo].[MonAn] VALUES (N'TD56', N'ML04 ', N'Nasu', N'xiên', 160000)
INSERT [dbo].[MonAn] VALUES (N'TD57', N'ML04 ', N'Negi', N'xiên', 150000)
INSERT [dbo].[MonAn] VALUES (N'TD58', N'ML05 ', N'Nikuyasai Itame', N'Dĩa', 50000)
INSERT [dbo].[MonAn] VALUES (N'TD59', N'ML05 ', N'Curry Udon', N'Dĩa', 55000)
INSERT [dbo].[MonAn] VALUES (N'TD60', N'ML05 ', N'Yaki Soba', N'Dĩa', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD61', N'ML05 ', N'Yaki Udon', N'Dĩa', 160000)
INSERT [dbo].[MonAn] VALUES (N'TD62', N'ML05 ', N'Omusoba', N'Dĩa', 50000)
INSERT [dbo].[MonAn] VALUES (N'TD63', N'ML05 ', N'Horenso Omlete', N'Dĩa', 35000)
INSERT [dbo].[MonAn] VALUES (N'TD64', N'ML06 ', N'Torikara Age', N'Dĩa', 40000)
INSERT [dbo].[MonAn] VALUES (N'TD65', N'ML06 ', N'Age Gyoza', N'Dĩa', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD66', N'ML06 ', N'Chiken NanBan', N'Dĩa', 30000)
INSERT [dbo].[MonAn] VALUES (N'TD67', N'ML06 ', N'Ikaring Age', N'Dĩa', 40000)
INSERT [dbo].[MonAn] VALUES (N'TD68', N'ML06 ', N'Nankotsu Karaage', N'Dĩa', 50000)
INSERT [dbo].[MonAn] VALUES (N'TD69', N'ML06 ', N'Yu Rin Chi', N'Dĩa', 45000)
INSERT [dbo].[MonAn] VALUES (N'TD70', N'ML06 ', N'Aji Furai', N'Con', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD71', N'ML06 ', N'Takoyaki', N'Dĩa', 40000)
INSERT [dbo].[MonAn] VALUES (N'TD72', N'ML07 ', N'Salmon Sashimi', N'Phần', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD73', N'ML07 ', N'Maguro Sashimi', N'Phần', 25000)
INSERT [dbo].[MonAn] VALUES (N'TD74', N'ML07 ', N'Tako Sashimi', N'Phần', 25000)
INSERT [dbo].[MonAn] VALUES (N'TD75', N'ML07 ', N'Amaeni Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD76', N'ML07 ', N'Shimesaba Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD77', N'ML07 ', N'Mamakari Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD78', N'ML07 ', N'Santen Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD79', N'ML07 ', N'Higawari Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD80', N'ML07 ', N'Hokkigai Sashimi', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD81', N'ML07 ', N'Maguro Butsu', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD82', N'ML07 ', N'Natto', N'Phần', 10000)
INSERT [dbo].[MonAn] VALUES (N'TD83', N'ML08 ', N'Salmon Maki', N'Phần', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD84', N'ML08 ', N'Negitoro Maki', N'Phần', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD85', N'ML08 ', N'Anago Avocado Roll', N'Phần', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD86', N'ML08 ', N'Anago HaKo Zushi', N'Phần', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD87', N'ML08 ', N'Salmon Hoko Zushi', N'Phần', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD88', N'ML09 ', N'Tea', N'Ly', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD89', N'ML09 ', N'Coca', N'Lon', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD90', N'ML09 ', N'7up', N'Lon', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD91', N'ML09 ', N'Lemon soda', N'Ly', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD92', N'ML09 ', N'Water', N'Chai', 20000)
INSERT [dbo].[MonAn] VALUES (N'TD93', N'ML10 ', N'Sapporo Craft', N'Ly', 17000)
INSERT [dbo].[MonAn] VALUES (N'TD94', N'ML10 ', N'Sapporo Bottle', N'Chai', 13000)
INSERT [dbo].[MonAn] VALUES (N'TD95', N'ML11 ', N'Kurogodai 720ml', N'Chai', 100000)
INSERT [dbo].[MonAn] VALUES (N'TD96', N'ML11 ', N'Kurogodai Glass', N'Ly', 100000)
INSERT [dbo].[MonAn] VALUES (N'TD97', N'ML11 ', N'Imohajime 720ml', N'Chai', 150000)
INSERT [dbo].[MonAn] VALUES (N'TD98', N'ML11 ', N'Ikinoshima 720ml', N'Chai', 200000)
INSERT [dbo].[MonAn] VALUES (N'TD99', N'ML11 ', N'Satsuma Kobiki Kuro 720ml', N'Chai', 500000)

INSERT [dbo].[Ban] VALUES (1,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (2,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (3,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (4,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (5,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (6,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (7,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (8,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (9,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (10,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (11,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (12,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (13,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (14,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (15,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (16,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (17,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (18,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (19,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (20,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (21,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (22,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (23,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (24,N'TRỐNG')
INSERT [dbo].[Ban] VALUES (25,N'TRỐNG')

INSERT [dbo].[Ca] VALUES (N'Ca01',N'CA 1',N'Cố Định(14h-23h)', '1/6/2021','1/7/2021')
INSERT [dbo].[Ca] VALUES (N'Ca02',N'CA 2',N'Part Time(17h-23h)','1/6/2021','1/7/2021')
INSERT [dbo].[Ca] VALUES (N'Ca03',N'CA 3',N'Cố Định(Full time 12tiếng)','1/6/2021','1/7/2021')
INSERT [dbo].[Ca] VALUES (N'Ca04',N'CA 4',N'Cố Định(15h-23h)','1/6/2021','1/7/2021')
INSERT [dbo].[Ca] VALUES (N'Ca05',N'CA 5',N'Part Time(18h-23h)','1/6/2021','1/7/2021')
INSERT [dbo].[Ca] VALUES (N'Ca06',N'CA 6',N'Part Time(Đủ 4 tiếng lương)','1/6/2021','1/7/2021')


INSERT [dbo].[PhanCong] VALUES (N'CA01', N'NV01',1,'1/6/2021','1/7/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA01', N'NV02',2,'1/6/2021','1/7/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA02', N'NV04',4,'1/7/2021','1/8/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA02', N'NV05',5,'1/7/2021','1/8/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA02', N'NV06',6,'1/7/2021','1/8/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA03', N'NV07',7,'1/8/2021','1/9/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA03', N'NV08',8,'1/8/2021','1/9/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA03', N'NV09',9,'1/8/2021','1/9/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA04', N'NV10',10,'1/9/2021','1/10/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA04', N'NV02',12,'1/9/2021','1/10/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA05', N'NV04',14,'1/10/2021','1/11/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA05', N'NV05',15,'1/10/2021','1/11/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA06', N'NV06',16,'1/11/2021','1/12/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA06', N'NV07',17,'1/11/2021','1/12/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA06', N'NV08',18,'1/11/2021','1/12/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA06', N'NV09',19,'1/11/2021','1/12/2021')
INSERT [dbo].[PhanCong] VALUES (N'CA06', N'NV10',20,'1/11/2021','1/12/2021')
