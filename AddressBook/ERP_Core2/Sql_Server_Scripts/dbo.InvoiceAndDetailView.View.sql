USE [listensoftwareDB]
GO
/****** Object:  View [dbo].[InvoiceAndDetailView]    Script Date: 5/14/2018 11:35:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[InvoiceAndDetailView]
as
select 
invoices.InvoiceId,
invoices.InvoiceNumber,
invoices.InvoiceDate,
invoices.Amount,
invoices.BillToAddressId,
invoices.Description,
invoices.TaxAmount,
invoices.PaymentDueDate,
invoices.PaymentTerms,
invoicesDetail.UnitPrice,
invoicesDetail.Quantity,
invoicesDetail.Amount DetailAmount,
invoicesDetail.DiscountPercent,
invoicesDetail.DiscountAmount
from invoices invoices
left join invoicesDetail invoicesDetail on invoices.invoiceId=invoicesDetail.invoiceId
inner join itemmaster itemmaster on invoicesdetail.itemid=itemmaster.itemid

GO
