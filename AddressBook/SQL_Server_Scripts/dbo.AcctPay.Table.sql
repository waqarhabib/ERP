USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[AcctPay]    Script Date: 6/25/2018 6:26:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcctPay](
	[AcctPayId] [bigint] IDENTITY(1,1) NOT NULL,
	[DocNumber] [bigint] NULL,
	[DocTypeXRefId] [bigint] NOT NULL,
	[PaymentTermsXRefId] [bigint] NOT NULL,
	[GrossAmount] [money] NULL,
	[DiscountAmount] [money] NULL,
	[Remark] [varchar](max) NULL,
	[GLDate] [datetime] NULL,
	[AccountNumber] [varchar](100) NULL,
	[SupplierId] [bigint] NOT NULL,
	[ContractId] [bigint] NULL,
	[POQuoteId] [bigint] NULL,
	[Description] [varchar](1000) NULL,
	[ItemId] [bigint] NULL,
	[PurchaseOrderId] [bigint] NULL,
	[Tax] [money] NULL,
	[InvoiceId] [bigint] NULL,
 CONSTRAINT [PK_AcctPay] PRIMARY KEY CLUSTERED 
(
	[AcctPayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD FOREIGN KEY([DocTypeXRefId])
REFERENCES [dbo].[UDC] ([XRefId])
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD FOREIGN KEY([PaymentTermsXRefId])
REFERENCES [dbo].[UDC] ([XRefId])
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD  CONSTRAINT [FK_AcctPay_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[AcctPay] CHECK CONSTRAINT [FK_AcctPay_Contract]
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD  CONSTRAINT [FK_AcctPay_POQuote] FOREIGN KEY([POQuoteId])
REFERENCES [dbo].[POQuote] ([POQuoteId])
GO
ALTER TABLE [dbo].[AcctPay] CHECK CONSTRAINT [FK_AcctPay_POQuote]
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD  CONSTRAINT [FK_AcctPay_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[AcctPay] CHECK CONSTRAINT [FK_AcctPay_Supplier]
GO
