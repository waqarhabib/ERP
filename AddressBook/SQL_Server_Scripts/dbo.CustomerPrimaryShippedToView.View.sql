USE [listensoftwareDB]
GO
/****** Object:  View [dbo].[CustomerPrimaryShippedToView]    Script Date: 6/25/2018 6:26:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[CustomerPrimaryShippedToView]
as
select 
addressBook.name,
shippedToAddresses.[AddressId]
      ,shippedToAddresses.[ShipToAddressLine1]
      ,shippedToAddresses.[ShipToAddressLine2]
      ,shippedToAddresses.[ShipToState]
      ,shippedToAddresses.[ShipToCity]
      ,shippedToAddresses.[ShipToZipcode]
	   from addressBook addressbook
left join shippedToAddresses shippedToAddresses
on addressbook.AddressId=shippedToAddresses.shippedToAddressId
GO
