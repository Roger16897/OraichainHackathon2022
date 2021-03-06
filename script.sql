USE [db_1877]
GO
/****** Object:  Table [dbo].[tb_Action]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Action](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ActionName] [nvarchar](100) NULL,
	[ID_Controller] [int] NULL,
	[MoTa] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_CauHinhThamSo]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CauHinhThamSo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenTruong] [nvarchar](200) NULL,
	[ID_DichVu] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ChuyenGia]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ChuyenGia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenChuyenGia] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[email] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
	[TrinhDo] [nvarchar](100) NULL,
	[MoTa] [nvarchar](200) NULL,
	[Image] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_CongViec]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CongViec](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_KetQuaAI] [int] NULL,
	[ID_ChuyenGia] [int] NULL,
	[KetQuaChuyenGia] [nvarchar](max) NULL,
	[TrangThaiChuyenGia] [nvarchar](100) NULL,
	[TenKetQua] [nvarchar](100) NULL,
	[Image] [nvarchar](100) NULL,
	[Hash] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Controller]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Controller](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ControllerName] [nvarchar](100) NULL,
	[MoTa] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_DichVu]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DichVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](100) NULL,
	[MoTa] [nvarchar](max) NULL,
	[Gia] [nvarchar](100) NULL,
	[ID_LoaiDichVu] [int] NULL,
	[ID_NhaCungCapAI] [int] NULL,
	[ID_User] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_KetQuaAI]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_KetQuaAI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_DichVu] [int] NULL,
	[ID_User] [int] NULL,
	[KetQuaNhaCungCapAI] [nvarchar](max) NULL,
	[TenKetQua] [nvarchar](100) NULL,
	[Hash] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_KetQuaAI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_LoaiDichVu]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_LoaiDichVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiDichVu] [nvarchar](200) NULL,
	[Gia] [nvarchar](200) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_NhaCungCapAI]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhaCungCapAI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaCungCap] [nvarchar](200) NULL,
	[MoTa] [nvarchar](max) NULL,
	[ID_LoaiDichVu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PhanQuyen]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PhanQuyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Id_Action] [int] NULL,
	[Id_NguoiDung] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_RatingChuyenGia]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_RatingChuyenGia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Star] [real] NULL,
	[BinhLuan] [nvarchar](200) NULL,
	[ID_ChuyenGia] [int] NULL,
	[ID_KhachHang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_RatingNhaCungCap]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_RatingNhaCungCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Star] [real] NULL,
	[BinhLuan] [nvarchar](200) NULL,
	[ID_NhaCungCapAI] [int] NULL,
	[ID_KhachHang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_User]    Script Date: 6/12/2022 9:45:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDayDu] [nvarchar](100) NULL,
	[TenDangNhap] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[isAdmin] [bit] NULL,
	[Type] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_Action] ON 

INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (154, N'AboutController-Index', 84, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (155, N'ApiAdminCongViecController-Get', 85, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (156, N'ApiAdminCongViecController-Put', 85, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (157, N'ApiCauHinhThamSoController-Delete', 86, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (158, N'ApiCauHinhThamSoController-Get', 86, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (159, N'ApiCauHinhThamSoController-Post', 86, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (160, N'ApiCauHinhThamSoController-Put', 86, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (161, N'ApiCauHinhThamSoController-tb_DichVuLookup', 86, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (162, N'ApiChuyenGiaController-Delete', 87, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (163, N'ApiChuyenGiaController-Get', 87, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (164, N'ApiChuyenGiaController-Post', 87, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (165, N'ApiChuyenGiaController-Put', 87, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (166, N'ApiCongViecController-Get', 88, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (167, N'ApiControllerController-Delete', 89, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (168, N'ApiControllerController-Get', 89, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (169, N'ApiControllerController-GetActionByController', 89, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (170, N'ApiControllerController-Post', 89, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (171, N'ApiControllerController-Put', 89, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (172, N'ApiDichVuController-Delete', 90, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (173, N'ApiDichVuController-Get', 90, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (174, N'ApiDichVuController-Post', 90, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (175, N'ApiDichVuController-Put', 90, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (176, N'ApiDichVuController-tb_LoaiDichVuLookup', 90, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (177, N'ApiDichVuController-tb_NhaCungCapLookup', 90, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (178, N'ApiLoaiDichVuController-Delete', 91, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (179, N'ApiLoaiDichVuController-Get', 91, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (180, N'ApiLoaiDichVuController-Post', 91, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (181, N'ApiLoaiDichVuController-Put', 91, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (182, N'ApiNhaCungCapAIController-Delete', 92, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (183, N'ApiNhaCungCapAIController-Get', 92, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (184, N'ApiNhaCungCapAIController-Post', 92, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (185, N'ApiNhaCungCapAIController-Put', 92, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (186, N'ApiNhaCungCapAIController-tb_LoaiDichVuLookup', 92, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (187, N'ApiUserController-Delete', 93, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (188, N'ApiUserController-Get', 93, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (189, N'ApiUserController-Post', 93, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (190, N'ApiUserController-Put', 93, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (191, N'ChuyenGiaController-GuiChuyenGia', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (192, N'ChuyenGiaController-GuiKetQua', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (193, N'ChuyenGiaController-Index', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (194, N'ChuyenGiaController-Create', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (195, N'ChuyenGiaController-Delete', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (196, N'ChuyenGiaController-Edit', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (197, N'ChuyenGiaController-Index', 95, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (198, N'CongViecController-Index', 97, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (199, N'DichVuController-ChiTietDichVu', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (200, N'DichVuController-GetDichVu', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (201, N'DichVuController-Index', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (202, N'DichVuController-LuuKetQua', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (203, N'DichVuController-PhanTich', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (204, N'DichVuController-PhanTichCovid', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (205, N'DichVuController-PhanTichMaDoc', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (206, N'DichVuController-CauHinhThamSo', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (207, N'DichVuController-DanhSachDichVu', 98, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (208, N'ErrorController-Index', 100, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (209, N'HomeController-Index', 101, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (210, N'HomeController-Index', 101, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (211, N'LoaiDichVuController-Index', 103, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (212, N'LoginController-Index', 104, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (213, N'LoginController-Login', 104, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (214, N'LoginController-Logout', 104, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (215, N'LoginController-NotFound', 104, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (216, N'NhaCungCapAIController-Index', 105, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (217, N'QuanLyCGController-DanhSachYeuCau', 106, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (218, N'QuanLyCGController-Home', 106, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (219, N'QuanLyCGController-Vi', 106, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (220, N'QuanLyNhaCCAIController-Home', 107, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (221, N'QuanLyNhaCCAIController-Vi', 107, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (222, N'UserController-CapNhatQuyen', 108, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (223, N'UserController-DanhSachNguoiDung', 108, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (224, N'UserController-Edit', 108, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (225, N'UserController-GetController', 108, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (226, N'UserController-Info', 108, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (227, N'UserController-UserAddRoleApply', 108, N'Chưa có mô tả')
INSERT [dbo].[tb_Action] ([ID], [ActionName], [ID_Controller], [MoTa]) VALUES (228, N'UserController-UserAddRoleView', 108, N'Chưa có mô tả')
SET IDENTITY_INSERT [dbo].[tb_Action] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_CauHinhThamSo] ON 

INSERT [dbo].[tb_CauHinhThamSo] ([ID], [TenTruong], [ID_DichVu], [MoTa]) VALUES (1, N'Nhận diện về phổi', NULL, N'{}')
INSERT [dbo].[tb_CauHinhThamSo] ([ID], [TenTruong], [ID_DichVu], [MoTa]) VALUES (2, N'Nhận diện về phổi', NULL, N'{')
INSERT [dbo].[tb_CauHinhThamSo] ([ID], [TenTruong], [ID_DichVu], [MoTa]) VALUES (3, N'Cấu hình tham số AI phát hiện bệnh về phổi', 1, N'{     "checkimg":[         "url":"http://192.168.1.100:5000/process",         "type":"POST",         "input":         [             "image"         ]     ],     "download":[     "url":"http://192.168.1.100:5000/download",     "type":"GET",     "input":     [         "filename"     ] ], }')
INSERT [dbo].[tb_CauHinhThamSo] ([ID], [TenTruong], [ID_DichVu], [MoTa]) VALUES (4, N'Cấu hình tham số AI phát hiện độ nghiêm trọng của phổi sau khi mắc Covid', 2, N'{     "filename": "image",     "serverity level": "res",     "confidence": "res" }')
INSERT [dbo].[tb_CauHinhThamSo] ([ID], [TenTruong], [ID_DichVu], [MoTa]) VALUES (5, N'Cấu hình tham số AI phát hiện mã độc', 3, N'{     "SortWindows61.dll": "Normal File",     "VirusShare_971dd15bf1121124119bc8db948b70fe": "Malicious File",     "VirusShare_05510bf3e87272bc47c96afb42fb46e3": "Malicious File",     "VirusShare_e04d72359ae6e291102c0ff2569bf3dc": "Malicious File",     "VirusShare_e938ee5caf20e286011b986634c9a838": "Malicious File",     "VirusShare_556476cfd1ec317826b84351be6aad43": "Malicious File",     "VirusShare_601f49a41ce94345c106bae4f149d7d1": "Malicious File",     "Windows.System.Diagnostics.dll": "Normal File",     "VirusShare_d4d1443b8bd590898adb37e1ccf38748": "Malicious File",     "win32appinventorycsp.dll": "Normal File" }')
SET IDENTITY_INSERT [dbo].[tb_CauHinhThamSo] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_ChuyenGia] ON 

INSERT [dbo].[tb_ChuyenGia] ([ID], [TenChuyenGia], [NgaySinh], [email], [SDT], [TrinhDo], [MoTa], [Image]) VALUES (5, N'Trần Nam Trung', CAST(N'2022-06-10' AS Date), N'namtrung@gmail.com', N'0971456123', N'Tiến sĩ', N'Giám đốc bệnh viện Bạch Mai', N'43e8c779d2e5e6eec5006d91169e0c40cce894c6cccbcb85a959db04d3fa24e5/chuyengia1.jpg')
INSERT [dbo].[tb_ChuyenGia] ([ID], [TenChuyenGia], [NgaySinh], [email], [SDT], [TrinhDo], [MoTa], [Image]) VALUES (6, N'Nguyễn Văn Quang', CAST(N'2022-06-14' AS Date), N'nguyentanquang8888@gmail.com', N'0111111111', N'Tiến sĩ', N'Trưởng khoa chuyên khoa phổi, Bệnh viện 108', N'4910d26ba3e3dc8ef2e9d2561f62ba808764bf11d82c6b48b8f9c45725eb12b1/expert.png')
INSERT [dbo].[tb_ChuyenGia] ([ID], [TenChuyenGia], [NgaySinh], [email], [SDT], [TrinhDo], [MoTa], [Image]) VALUES (7, N'Nguyễn Văn An', CAST(N'2022-06-17' AS Date), N'namtrung@gmail.com', N'0971456123', N'Thạc sĩ', N'Chuyên viên mã độc - FPT', N'de18db32e26eb23e9dc021c8c71ffe4d0f8e855ed4091f97b5576c8c011ab88f/fpt.jpg')
SET IDENTITY_INSERT [dbo].[tb_ChuyenGia] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_CongViec] ON 

INSERT [dbo].[tb_CongViec] ([ID], [ID_KetQuaAI], [ID_ChuyenGia], [KetQuaChuyenGia], [TrangThaiChuyenGia], [TenKetQua], [Image], [Hash]) VALUES (2, 1, 5, N'Có bệnh', N'Hoàn thành', N'Chuyên gia đánh giá :Kết quả phân tích phổi', NULL, N'B98B2AEEED7852632BFD70F0F591DA1542A8789866CB90D3DB9ABC6BE2ADD351')
INSERT [dbo].[tb_CongViec] ([ID], [ID_KetQuaAI], [ID_ChuyenGia], [KetQuaChuyenGia], [TrangThaiChuyenGia], [TenKetQua], [Image], [Hash]) VALUES (3, 2, 5, NULL, N'Chờ xử lý', N'Chuyên gia đánh giá :Kết quả phân tích gan', N'4b227777d4dd1fc61c6f884f48641d02b4d121d3fd328cb08b5531fcacdabf8a/36199.png', NULL)
SET IDENTITY_INSERT [dbo].[tb_CongViec] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Controller] ON 

INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (84, N'AboutController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (85, N'ApiAdminCongViecController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (86, N'ApiCauHinhThamSoController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (87, N'ApiChuyenGiaController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (88, N'ApiCongViecController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (89, N'ApiControllerController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (90, N'ApiDichVuController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (91, N'ApiLoaiDichVuController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (92, N'ApiNhaCungCapAIController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (93, N'ApiUserController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (94, N'BaseController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (95, N'ChuyenGiaController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (96, N'ChuyenGiaController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (97, N'CongViecController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (98, N'DichVuController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (99, N'DichVuController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (100, N'ErrorController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (101, N'HomeController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (102, N'HomeController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (103, N'LoaiDichVuController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (104, N'LoginController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (105, N'NhaCungCapAIController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (106, N'QuanLyCGController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (107, N'QuanLyNhaCCAIController', N'Chưa có mô tả')
INSERT [dbo].[tb_Controller] ([ID], [ControllerName], [MoTa]) VALUES (108, N'UserController', N'Chưa có mô tả')
SET IDENTITY_INSERT [dbo].[tb_Controller] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_DichVu] ON 

INSERT [dbo].[tb_DichVu] ([ID], [TenDichVu], [MoTa], [Gia], [ID_LoaiDichVu], [ID_NhaCungCapAI], [ID_User]) VALUES (1, N'Nhận diện bệnh về phổi', N'Phát hiện sớm các loại bệnh liên quan đến phổi', N'1$', 1, 1, 3)
INSERT [dbo].[tb_DichVu] ([ID], [TenDichVu], [MoTa], [Gia], [ID_LoaiDichVu], [ID_NhaCungCapAI], [ID_User]) VALUES (2, N'Phát hiện bệnh hậu covid', N'Phát hiện các dấu hiệu bất thường sau khi mắc covid', N'1$', 1, 1, 3)
INSERT [dbo].[tb_DichVu] ([ID], [TenDichVu], [MoTa], [Gia], [ID_LoaiDichVu], [ID_NhaCungCapAI], [ID_User]) VALUES (3, N'Nhận diện mã độc', N'Phát hiện mã độc từ file nghi ngờ', N'0.3$', 2, 2, 3)
SET IDENTITY_INSERT [dbo].[tb_DichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_KetQuaAI] ON 

INSERT [dbo].[tb_KetQuaAI] ([ID], [ID_DichVu], [ID_User], [KetQuaNhaCungCapAI], [TenKetQua], [Hash]) VALUES (1, 1, 4, N'image: http://192.168.1.100:5000/download?filename=39734.png
Chuẩn đoán bệnh:
Tên bệnh: Calcification- xác xuất: 0.845
', N'Kết quả phân tích phổi', NULL)
INSERT [dbo].[tb_KetQuaAI] ([ID], [ID_DichVu], [ID_User], [KetQuaNhaCungCapAI], [TenKetQua], [Hash]) VALUES (2, 1, 4, N'image: http://192.168.1.100:5000/download?filename=39524.png
Chuẩn đoán bệnh:
Tên bệnh: Fibrosis- xác xuất: 0.886
Tên bệnh: Calcification- xác xuất: 0.851
Tên bệnh: Pleural Thickening- xác xuất: 0.819
', N'Kết quả phân tích gan', NULL)
INSERT [dbo].[tb_KetQuaAI] ([ID], [ID_DichVu], [ID_User], [KetQuaNhaCungCapAI], [TenKetQua], [Hash]) VALUES (3, 2, 4, N'Chuẩn đoán bệnh:
Mức độ: level2- xác xuất: 1.000
', N'Ket qua covid', NULL)
INSERT [dbo].[tb_KetQuaAI] ([ID], [ID_DichVu], [ID_User], [KetQuaNhaCungCapAI], [TenKetQua], [Hash]) VALUES (4, 3, 4, N'{"SortWindows61.dll": "Normal File", "VirusShare_971dd15bf1121124119bc8db948b70fe": "Malicious File", "VirusShare_05510bf3e87272bc47c96afb42fb46e3": "Malicious File", "VirusShare_e04d72359ae6e291102c0ff2569bf3dc": "Malicious File", "VirusShare_e938ee5caf20e286011b986634c9a838": "Malicious File", "VirusShare_556476cfd1ec317826b84351be6aad43": "Malicious File", "VirusShare_601f49a41ce94345c106bae4f149d7d1": "Malicious File", "Windows.System.Diagnostics.dll": "Normal File", "VirusShare_d4d1443b8bd590898adb37e1ccf38748": "Malicious File", "win32appinventorycsp.dll": "Normal File"}', N'Kết quả mã độc', NULL)
INSERT [dbo].[tb_KetQuaAI] ([ID], [ID_DichVu], [ID_User], [KetQuaNhaCungCapAI], [TenKetQua], [Hash]) VALUES (5, 2, 4, N'Chuẩn đoán bệnh:
Mức độ: level1- xác xuất: 1.000
', N'Kết quả chuẩn đoán phổi', N'E91B66EC903C6F65141B786CFC50853986E4B890766607E4FD1C13DBF0457D5E')
INSERT [dbo].[tb_KetQuaAI] ([ID], [ID_DichVu], [ID_User], [KetQuaNhaCungCapAI], [TenKetQua], [Hash]) VALUES (6, 3, 4, N'{"SortWindows61.dll": "Normal File", "VirusShare_971dd15bf1121124119bc8db948b70fe": "Malicious File", "VirusShare_05510bf3e87272bc47c96afb42fb46e3": "Malicious File", "VirusShare_e04d72359ae6e291102c0ff2569bf3dc": "Malicious File", "VirusShare_e938ee5caf20e286011b986634c9a838": "Malicious File", "VirusShare_556476cfd1ec317826b84351be6aad43": "Malicious File", "VirusShare_601f49a41ce94345c106bae4f149d7d1": "Malicious File", "Windows.System.Diagnostics.dll": "Normal File", "VirusShare_d4d1443b8bd590898adb37e1ccf38748": "Malicious File", "win32appinventorycsp.dll": "Normal File"}', N'Kết quả phân tích file ABC', N'8F0EB42DC4F34357F4AD10D83643BF2CBB4566A6AB1B5FE0BD8AA087E2705F84')
SET IDENTITY_INSERT [dbo].[tb_KetQuaAI] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_LoaiDichVu] ON 

INSERT [dbo].[tb_LoaiDichVu] ([ID], [TenLoaiDichVu], [Gia], [MoTa]) VALUES (1, N'Dịch vụ AI hỗ trợ y tế', NULL, N'Nhận diện các loại bệnh bất thường ')
INSERT [dbo].[tb_LoaiDichVu] ([ID], [TenLoaiDichVu], [Gia], [MoTa]) VALUES (2, N'Dịch vụ AI hỗ trợ nhận diện mã độc', NULL, N'Nhận diện các file nghi ngờ nhiễm mã độc')
SET IDENTITY_INSERT [dbo].[tb_LoaiDichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_NhaCungCapAI] ON 

INSERT [dbo].[tb_NhaCungCapAI] ([ID], [TenNhaCungCap], [MoTa], [ID_LoaiDichVu]) VALUES (1, N'Nhà cung cấp Việt Đức', N'Hỗ trợ nhận diện liên quan đến các bệnh về phổi, xương và một số bệnh khác', 1)
INSERT [dbo].[tb_NhaCungCapAI] ([ID], [TenNhaCungCap], [MoTa], [ID_LoaiDichVu]) VALUES (2, N'Nhà cung cấp QĐ', N'Hỗ trợ nhận diện các chủng mã độc mới', 2)
SET IDENTITY_INSERT [dbo].[tb_NhaCungCapAI] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_PhanQuyen] ON 

INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (66, 157, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (67, 158, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (68, 159, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (69, 160, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (70, 161, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (71, 172, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (72, 173, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (73, 174, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (74, 175, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (75, 176, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (76, 177, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (77, 206, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (78, 207, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (79, 220, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (80, 221, 3)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (81, 155, 2)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (82, 156, 2)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (83, 217, 2)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (84, 218, 2)
INSERT [dbo].[tb_PhanQuyen] ([ID], [Id_Action], [Id_NguoiDung]) VALUES (85, 219, 2)
SET IDENTITY_INSERT [dbo].[tb_PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_RatingChuyenGia] ON 

INSERT [dbo].[tb_RatingChuyenGia] ([ID], [Star], [BinhLuan], [ID_ChuyenGia], [ID_KhachHang]) VALUES (1, 5, N'Chuyên gia chất lượng tốt', 5, 4)
INSERT [dbo].[tb_RatingChuyenGia] ([ID], [Star], [BinhLuan], [ID_ChuyenGia], [ID_KhachHang]) VALUES (2, 4, N'Chuyên gia chất lượng đảm bảo, tuy nhiêu chưa thật sự nhiệt tình!', 5, 4)
SET IDENTITY_INSERT [dbo].[tb_RatingChuyenGia] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_RatingNhaCungCap] ON 

INSERT [dbo].[tb_RatingNhaCungCap] ([ID], [Star], [BinhLuan], [ID_NhaCungCapAI], [ID_KhachHang]) VALUES (1, 5, N'Dịch vụ tốt!', 1, 4)
INSERT [dbo].[tb_RatingNhaCungCap] ([ID], [Star], [BinhLuan], [ID_NhaCungCapAI], [ID_KhachHang]) VALUES (2, 4, N'Dịch vụ có chất lượng tương đối tốt!', 1, 4)
INSERT [dbo].[tb_RatingNhaCungCap] ([ID], [Star], [BinhLuan], [ID_NhaCungCapAI], [ID_KhachHang]) VALUES (3, 5, N'Chất lượng dịch vụ tốt, có kết quả chính xác cao!', 2, 4)
INSERT [dbo].[tb_RatingNhaCungCap] ([ID], [Star], [BinhLuan], [ID_NhaCungCapAI], [ID_KhachHang]) VALUES (4, 1, N'Chất lượng kém', 1, 4)
SET IDENTITY_INSERT [dbo].[tb_RatingNhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_User] ON 

INSERT [dbo].[tb_User] ([ID], [TenDayDu], [TenDangNhap], [MatKhau], [NgaySinh], [GioiTinh], [Email], [isAdmin], [Type]) VALUES (1, N'Quản trị hệ thống', N'boss', N'64fd436087d83ab58c3eecdd47b2f42e38aec181d6c3765d5070c042dec24ce1', CAST(N'2022-06-13' AS Date), N'Nam', NULL, 1, N'Quản trị')
INSERT [dbo].[tb_User] ([ID], [TenDayDu], [TenDangNhap], [MatKhau], [NgaySinh], [GioiTinh], [Email], [isAdmin], [Type]) VALUES (2, N'Chuyên gia', N'chuyengia', N'64fd436087d83ab58c3eecdd47b2f42e38aec181d6c3765d5070c042dec24ce1', CAST(N'2022-06-06' AS Date), N'Nam', NULL, NULL, N'Chuyên gia')
INSERT [dbo].[tb_User] ([ID], [TenDayDu], [TenDangNhap], [MatKhau], [NgaySinh], [GioiTinh], [Email], [isAdmin], [Type]) VALUES (3, N'Nhà cung cấp dịch vụ AI', N'ai', N'64fd436087d83ab58c3eecdd47b2f42e38aec181d6c3765d5070c042dec24ce1', CAST(N'2022-06-08' AS Date), N'Nữ', NULL, NULL, N'Nhà cung cấp AI')
INSERT [dbo].[tb_User] ([ID], [TenDayDu], [TenDangNhap], [MatKhau], [NgaySinh], [GioiTinh], [Email], [isAdmin], [Type]) VALUES (4, N'Khách hàng', N'khachhang', N'64fd436087d83ab58c3eecdd47b2f42e38aec181d6c3765d5070c042dec24ce1', CAST(N'2022-06-05' AS Date), N'Nữ', NULL, NULL, N'Khách hàng')
SET IDENTITY_INSERT [dbo].[tb_User] OFF
GO
