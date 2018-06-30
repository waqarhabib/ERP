USE [listensoftwareDB]
GO
/****** Object:  View [dbo].[CustomerView]    Script Date: 6/25/2018 6:26:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[CustomerView] AS
SELECT Customer.CustomerId, Customer.AddressId, AddressBook.Name, LocationAddress.LocationId, LocationAddress.[Address Line 1], LocationAddress.[Address Line 2], LocationAddress.City, LocationAddress.StateXRefId, 
                  LocationAddress.Zipcode, LocationAddress.CountryXRefId, LocationAddress.TypeXRefId, 
phones.phonenumber,
phones.phonetype,
emails.email,
state_udc.value state,
country_udc.value country,
locationType_udc.value locationType
FROM     Customer INNER JOIN
                  LocationAddress ON Customer.AddressId = LocationAddress.AddressId LEFT OUTER JOIN
                  AddressBook ON Customer.AddressId = AddressBook.AddressId LEFT OUTER JOIN
                  phones ON phones.addressid = Customer.AddressId LEFT OUTER JOIN
                  emails ON emails.addressid = Customer.AddressId join
		  udc state_udc on state_udc.xrefid=LocationAddress.StateXRefId join
	          udc country_udc on country_udc.xrefid=LocationAddress.CountryXRefId join
		  udc locationType_udc on locationType_udc.xrefid=LocationAddress.TypeXRefId


GO
