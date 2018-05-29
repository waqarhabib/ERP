USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[AcctPay]    Script Date: 5/28/2018 10:21:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcctPay](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DocNumber] [bigint] NULL,
	[DocType] [varchar](10) NULL,
	[InvoiceNumber] [varchar](50) NULL,
	[InvoiceAmount] [money] NULL,
	[InvoiceDate] [datetime] NULL,
	[PaymentTerms] [varchar](10) NULL,
	[GrossAmount] [money] NULL,
	[Remark] [varchar](max) NULL,
	[GLDate] [datetime] NULL,
	[AccountNumber] [varchar](100) NULL,
	[SupplierId] [bigint] NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[ContractId] [bigint] NOT NULL,
	[POQuoteId] [bigint] NOT NULL,
	[Description] [varchar](1000) NULL,
	[ItemId] [bigint] NOT NULL,
	[PONumber] [varchar](50) NULL,
 CONSTRAINT [PK_AcctPay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD  CONSTRAINT [FK_AcctPay_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[AcctPay] CHECK CONSTRAINT [FK_AcctPay_Contract]
GO
ALTER TABLE [dbo].[AcctPay]  WITH CHECK ADD  CONSTRAINT [FK_AcctPay_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[AcctPay] CHECK CONSTRAINT [FK_AcctPay_Customer]
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
