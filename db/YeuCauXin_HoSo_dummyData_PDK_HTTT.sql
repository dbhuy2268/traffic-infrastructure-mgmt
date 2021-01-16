USE [QLGT]
GO
/****** Object:  Table [dbo].[HoSoes]    Script Date: 1/16/2021 1:00:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSoes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaHoSo] [nvarchar](max) NULL,
	[LoaiHoSo] [nvarchar](max) NULL,
	[MoTaChiTiet] [nvarchar](max) NULL,
	[NoiCap] [nvarchar](max) NULL,
	[DiaChiLuu] [nvarchar](max) NULL,
	[ChuPhuongTien_id] [int] NULL,
	[YeuCauXin_id] [int] NULL,
 CONSTRAINT [PK_dbo.HoSoes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YeuCauXins]    Script Date: 1/16/2021 1:00:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YeuCauXins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenChuSoHuu] [nvarchar](max) NULL,
	[CMND_HoChieu] [nvarchar](max) NULL,
	[NgayCap_CMND_HoChieu] [datetime] NOT NULL,
	[DiaChiThuongTru] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[LoaiTaiSan] [nvarchar](max) NULL,
	[SoLoai] [nvarchar](max) NULL,
	[LoaiXe] [nvarchar](max) NULL,
	[NhanHieu] [nvarchar](max) NULL,
	[MauSon] [nvarchar](max) NULL,
	[NamSanXuat] [nvarchar](max) NULL,
	[XiLanh] [nvarchar](max) NULL,
	[SoKhung] [nvarchar](max) NULL,
	[SoMay] [nvarchar](max) NULL,
	[DaXetDuyet] [int] NOT NULL,
 CONSTRAINT [PK_dbo.YeuCauXins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[YeuCauXins] ADD  DEFAULT ((0)) FOR [DaXetDuyet]
GO
ALTER TABLE [dbo].[HoSoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HoSoes_dbo.ChuPhuongTiens_ChuPhuongTien_id] FOREIGN KEY([ChuPhuongTien_id])
REFERENCES [dbo].[ChuPhuongTiens] ([id])
GO
ALTER TABLE [dbo].[HoSoes] CHECK CONSTRAINT [FK_dbo.HoSoes_dbo.ChuPhuongTiens_ChuPhuongTien_id]
GO
ALTER TABLE [dbo].[HoSoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HoSoes_dbo.YeuCauXins_YeuCauXin_id] FOREIGN KEY([YeuCauXin_id])
REFERENCES [dbo].[YeuCauXins] ([id])
GO
ALTER TABLE [dbo].[HoSoes] CHECK CONSTRAINT [FK_dbo.HoSoes_dbo.YeuCauXins_YeuCauXin_id]
GO
