USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 6/25/2018 6:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[ItemId] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NULL,
	[UnitOfMeasure] [varchar](20) NULL,
	[CommodityCode] [varchar](10) NULL,
	[ItemPriceGroup] [varchar](20) NULL,
	[Description2] [varchar](255) NULL,
	[ItemNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ItemMaster] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
