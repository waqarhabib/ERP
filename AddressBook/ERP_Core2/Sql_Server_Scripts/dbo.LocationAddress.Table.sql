USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[LocationAddress]    Script Date: 5/28/2018 10:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationAddress](
	[LocationId] [bigint] IDENTITY(1,1) NOT NULL,
	[Address Line 1] [varchar](255) NULL,
	[Address Line 2] [varchar](255) NULL,
	[City] [varchar](50) NULL,
	[StateXRefId] [bigint] NOT NULL,
	[Zipcode] [varchar](20) NULL,
	[CountryXRefId] [bigint] NOT NULL,
	[TypeXRefId] [bigint] NOT NULL,
	[AddressId] [bigint] NOT NULL,
 CONSTRAINT [PK_LocationAddress] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[LocationAddress]  WITH CHECK ADD  CONSTRAINT [FK_LocationAddress_AddressBook] FOREIGN KEY([AddressId])
REFERENCES [dbo].[AddressBook] ([AddressId])
GO
ALTER TABLE [dbo].[LocationAddress] CHECK CONSTRAINT [FK_LocationAddress_AddressBook]
GO
ALTER TABLE [dbo].[LocationAddress]  WITH CHECK ADD  CONSTRAINT [FK_LocationAddress_UDCCountry] FOREIGN KEY([CountryXRefId])
REFERENCES [dbo].[UDC] ([XRefId])
GO
ALTER TABLE [dbo].[LocationAddress] CHECK CONSTRAINT [FK_LocationAddress_UDCCountry]
GO
ALTER TABLE [dbo].[LocationAddress]  WITH CHECK ADD  CONSTRAINT [FK_LocationAddress_UDCState] FOREIGN KEY([StateXRefId])
REFERENCES [dbo].[UDC] ([XRefId])
GO
ALTER TABLE [dbo].[LocationAddress] CHECK CONSTRAINT [FK_LocationAddress_UDCState]
GO
ALTER TABLE [dbo].[LocationAddress]  WITH CHECK ADD  CONSTRAINT [FK_LocationAddress_UDCType] FOREIGN KEY([TypeXRefId])
REFERENCES [dbo].[UDC] ([XRefId])
GO
ALTER TABLE [dbo].[LocationAddress] CHECK CONSTRAINT [FK_LocationAddress_UDCType]
GO
