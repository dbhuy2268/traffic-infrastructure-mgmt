USE [QLGT]
GO
/****** Object:  Table [dbo].[ChuPhuongTiens]    Script Date: 1/16/2021 1:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuPhuongTiens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoTen] [nvarchar](max) NULL,
	[thongBao] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ChuPhuongTiens] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
