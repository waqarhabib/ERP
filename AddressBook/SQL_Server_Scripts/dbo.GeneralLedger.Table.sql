USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[GeneralLedger]    Script Date: 7/4/2018 4:56:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralLedger](
	[GeneralLedgerId] [bigint] IDENTITY(1,1) NOT NULL,
	[DocNumber] [bigint] NOT NULL,
	[DocType] [varchar](10) NOT NULL,
	[Amount] [money] NOT NULL,
	[LedgerType] [varchar](10) NOT NULL,
	[GLDate] [datetime] NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[AddressId] [bigint] NOT NULL,
	[Comment] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[GeneralLedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GeneralLedger]  WITH CHECK ADD  CONSTRAINT [FK_GeneralLedger_ChartOfAccts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[ChartOfAccts] ([AccountId])
GO
ALTER TABLE [dbo].[GeneralLedger] CHECK CONSTRAINT [FK_GeneralLedger_ChartOfAccts]
GO
ALTER TABLE [dbo].[GeneralLedger]  WITH CHECK ADD  CONSTRAINT [FK_GeneralLedger_GeneralLedger] FOREIGN KEY([GeneralLedgerId])
REFERENCES [dbo].[GeneralLedger] ([GeneralLedgerId])
GO
ALTER TABLE [dbo].[GeneralLedger] CHECK CONSTRAINT [FK_GeneralLedger_GeneralLedger]
GO
