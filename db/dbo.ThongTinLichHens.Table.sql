USE [QLGT]
GO
/****** Object:  Table [dbo].[ThongTinLichHens]    Script Date: 1/16/2021 1:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinLichHens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bienSoXe] [nvarchar](max) NULL,
	[soKhung] [nvarchar](max) NULL,
	[soMay] [nvarchar](max) NULL,
	[ngayDangKy] [datetime] NOT NULL,
	[tenNguoiDangKy] [nvarchar](max) NULL,
	[soDienThoai] [nvarchar](max) NULL,
	[CMND] [nvarchar](max) NULL,
	[khungGio] [datetime] NOT NULL,
	[trangThaiXetDuyet] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ThongTinLichHens] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ThongTinLichHens] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [ngayDangKy]
GO
ALTER TABLE [dbo].[ThongTinLichHens] ADD  DEFAULT ((0)) FOR [trangThaiXetDuyet]
GO
