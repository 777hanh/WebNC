-- use master; drop database testDB
-- Create database testDB;
use testDB;

--tạo bảng 

--Bang LoaiXe
CREATE TABLE [dbo].[LoaiXe] (
    [MaLoaiXe]		varchar(25)         NOT NULL,
    [TenLoaiXe]		nvarchar(MAX)		NULL,
    [SoCho]			INT					NULL,
    [SoLuong]		INT					NULL,
    PRIMARY KEY CLUSTERED ([MaLoaiXe] ASC)
);
--Bang Xe
CREATE TABLE [dbo].[Xe](
	[MaXe]			varchar(25)			NOT NULL,
	[MaLoaiXe]		varchar(25)			NOT NULL,
	[BienSo]		int					NULL,
	[TenXe]			nvarchar(MAX)		NULL,
	[MoTa]			nvarchar(MAX)		NULL,
	[GiaLoaiXe]			float(8)		NULL,
	[TinhTrang]		bit					NULL,
	PRIMARY KEY CLUSTERED ([MaXe] ASC),
	CONSTRAINT [FK_Xe_LoaiXe] FOREIGN KEY ([MaLoaiXe]) REFERENCES [dbo].[LoaiXe] ([MaLoaiXe])
);


--Bang Phan Quyen
CREATE TABLE [dbo].[PhanQuyen](
	[MaQuyen]			int			NOT NULL,
	[TenQuyen]			varchar(25)			NOT NULL, --admin  nhanvien  khachhang
	PRIMARY KEY CLUSTERED ([MaQuyen] ASC),
);
--Bang Account
CREATE TABLE [dbo].[Account](
	[IdA]			char(20)			NOT NULL,
	[PassA]			varchar(25)			NOT NULL,
	[MaQuyen]		int					NOT NULL,
	[TenUser]		nvarchar(40)		NOT NULL,
	PRIMARY KEY CLUSTERED ([IdA] ASC),
	CONSTRAINT [FK_Account_PhanQuyen] FOREIGN KEY ([MaQuyen]) REFERENCES [dbo].[PhanQuyen] ([MaQuyen])
);

--Bang Khach
CREATE TABLE [dbo].[KHACH](
	[MaKhach]		int					IDENTITY (1, 1)NOT NULL,
	[TenKhach]		nvarchar(40)		NOT NULL,
	[DiaChi]		nvarchar(MAX)		NULL,
	[Mail]			varchar(MAX)		NULL,
	[CMND]			int					NULL,
	[SDT]			char(20)			NOT NULL, --Tên đăng nhập
	[NganHang]		varchar(MAX)		NULL,
	[SoTK]			char(20)			NULL,
	PRIMARY KEY CLUSTERED ([MaKhach] ASC),
	--CONSTRAINT [FK_Khach_Account_ID] FOREIGN KEY ([SDT]) REFERENCES [dbo].[Account] ([IdA]),
);
--Alter table dbo.KHACH
--DROP CONSTRAINT FK_Khach_Account_ID
--Bang Loai NV
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNV]		int					IDENTITY (1, 1)NOT NULL,
	[TenLoaiNV]		nvarchar(MAX)		NOT NULL
	PRIMARY KEY CLUSTERED ([MaLoaiNV] ASC),

);
--Bang NV
CREATE TABLE [dbo].[NhanVien](
	[MaNV]			varchar(25)			NOT NULL,
	[MaLoaiNV]		int					NOT NULL,
	[TenNV]			nvarchar(40)		NOT NULL,
	[DiaChi]		nvarchar(MAX)		NULL,
	[Mail]			varchar(MAX)		NULL,
	[CMND]			int					NULL,
	[SDT]			char(20)			NOT NULL, --Tên đăng nhập
	PRIMARY KEY CLUSTERED ([MaNV] ASC),
	CONSTRAINT [FK_NV_LoaiNV] FOREIGN KEY ([MaLoaiNV]) REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNV]),
	--CONSTRAINT [FK_NV_Account_ID] FOREIGN KEY ([SDT]) REFERENCES [dbo].[Account] ([IdA]),
	--Alter table dbo.NhanVien
	--DROP CONSTRAINT FK_NV_Account_ID
);



--Bang Hop Dong
CREATE TABLE [dbo].[HopDong](
	[SoHD]			int					IDENTITY (1, 1) NOT NULL,
	[Ngay]			date				NULL,
	[MaKhach]		int					NOT NULL,
	[NoiDung]		nvarchar(MAX)		NULL,
	[DonGia]		float				NULL,
	[HTTT]			nvarchar(MAX)		NULL,
	[DieuKhoan]		nvarchar(MAX)		NULL,
	[TraTruoc]		float				NOT NULL,
	PRIMARY KEY CLUSTERED ([SoHD] ASC),
	CONSTRAINT [FK_HopDong_Khach] FOREIGN KEY ([MaKhach]) REFERENCES [dbo].[Khach] ([MaKhach])
);
--Bang Chi tiet hop dong
CREATE TABLE [dbo].[ChiTietHopDong](
	[SoCTHD]		int					IDENTITY (1, 1) NOT NULL,
	[SoHD]			int					NOT NULL,
	[MaLoaiXe]		varchar(25)         NOT NULL,
	[soLuong]		int					NOT NULL,
	[Gia]			float				NULL,
	[NgayNhan]		date				NULL,
	[NgayTra]		date				NULL,
	[GhiChu]		nvarchar(MAX)		NULL,
	PRIMARY KEY CLUSTERED ([SoHD] ASC),
	CONSTRAINT [FK_CTHopDong_HopDong] FOREIGN KEY ([SoHD]) REFERENCES [dbo].[HopDong] ([SoHD]),
	CONSTRAINT [FK_CTHopDong_LoaiXe] FOREIGN KEY ([MaLoaiXe]) REFERENCES [dbo].[LoaiXe] ([MaLoaiXe])
);


--Bảng DatXe
CREATE TABLE [dbo].[DatXe](
	[MaDatXe]		int					IDENTITY (1, 1) NOT NULL,
	[Ngay]			date				NULL,
	[MaKhach]		int					NOT NULL,
	[MaLoaiXe]		varchar(25)			NOT NULL,
	[SoLuong]		int					NULL,
	[NgayHenLay]	date				NOT NULL,
	[TinhTrang]		bit,
	PRIMARY KEY CLUSTERED ([MaDatXe] ASC),
	CONSTRAINT [FK_DatXe_LoaiXe] FOREIGN KEY ([MaLoaiXe]) REFERENCES [dbo].[LoaiXe] ([MaLoaiXe]),
	CONSTRAINT [FK_DatXe_Khach] FOREIGN KEY ([MaKhach]) REFERENCES [dbo].[Khach] ([MaKhach])
);


--Bang Xe Ra
CREATE TABLE [dbo].[XeRa](
	[NgayRa]		date				NOT NULL,
	[MaXe]			varchar(25)			NOT NULL,
	[GhiChu]		nvarchar(MAX)		NULL,
	CONSTRAINT [FK_XeRa_Xe] FOREIGN KEY ([MaXe]) REFERENCES [dbo].[Xe] ([MaXe]),
);
--Bang Xe Vao
CREATE TABLE [dbo].[XeVao](
	[NgayVao]		date				NOT NULL,
	[MaXe]			varchar(25)			NOT NULL,
	[GhiChu]		nvarchar(MAX)		NULL,
	CONSTRAINT [FK_XeVao_Xe] FOREIGN KEY ([MaXe]) REFERENCES [dbo].[Xe] ([MaXe]),
);

--Bang Thanh Toan
CREATE TABLE [dbo].[ThanhToan](
	[MaTT]			int					IDENTITY (1, 1)	NOT NULL,
	[SoHD]			int					NOT NULL,	
	[PhiPS]			float				NULL,
	[LyDo]			nvarchar(MAX)		NULL,
	[MaNV]			varchar(25)			NOT NULL,
	PRIMARY KEY CLUSTERED ([MaTT] ASC),
	CONSTRAINT [FK_ThanhToan_HopDong] FOREIGN KEY ([SoHD]) REFERENCES [dbo].[HopDong] ([SoHD]),
	CONSTRAINT [FK_ThanhToan_NhanVien] FOREIGN KEY ([MaNV]) REFERENCES [dbo].[NhanVien] ([MaNV]),
);
