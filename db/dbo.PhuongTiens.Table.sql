USE [QLGT]
GO
/****** Object:  Table [dbo].[PhuongTiens]    Script Date: 1/16/2021 1:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuongTiens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ChuPhuongTien_id] [int] NULL,
	[nhanHieu] [nvarchar](max) NULL,
	[loaiPhuongTien] [nvarchar](max) NULL,
	[soKhung] [nvarchar](max) NULL,
	[soMay] [nvarchar](max) NULL,
	[kichThuocBao] [nvarchar](max) NULL,
	[khoiLuongBanThan] [nvarchar](max) NULL,
	[soNguoiChoPhepCho] [nvarchar](max) NULL,
	[soTruc_ChieuDaiCoSo] [nvarchar](max) NULL,
	[kichThuocThungHang] [nvarchar](max) NULL,
	[khoiLuongHangChoPhep] [nvarchar](max) NULL,
	[khoiLuongTongChoPhep] [nvarchar](max) NULL,
	[khoiLuongRomooc] [nvarchar](max) NULL,
	[thongBaoDanhChoPhuongTien] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PhuongTiens] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PhuongTiens]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhuongTiens_dbo.ChuPhuongTiens_ChuPhuongTien_id] FOREIGN KEY([ChuPhuongTien_id])
REFERENCES [dbo].[ChuPhuongTiens] ([id])
GO
ALTER TABLE [dbo].[PhuongTiens] CHECK CONSTRAINT [FK_dbo.PhuongTiens_dbo.ChuPhuongTiens_ChuPhuongTien_id]
GO
