USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 7/4/2018 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptId] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierId] [bigint] NOT NULL,
	[ReceiptDate] [datetime] NOT NULL,
	[ReceiptDocument] [varchar](50) NULL,
	[OrderNumber] [varchar](50) NULL,
	[Remark] [varchar](max) NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Supplier]
GO
