USE [listensoftwareDB]
GO
/****** Object:  View [dbo].[SalesOrderDetailView]    Script Date: 6/25/2018 6:26:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[SalesOrderDetailView]
as
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT SalesOrderDetail.[SalesOrderDetailID]
      ,SalesOrderDetail.[SalesOrderID]
      ,SalesOrderDetail.[ItemID]
      ,SalesOrderDetail.[Description]
      ,SalesOrderDetail.[Quantity]
      ,SalesOrderDetail.[Amount]
      ,SalesOrderDetail.[UnitOfMeasure]
      ,SalesOrderDetail.[UnitPrice]
	  ,SalesOrder.OrderNumber
	  ,SalesOrder.OrderType
	  ,InvoiceDetail.InvoiceDetailDescription
  FROM SalesOrder SalesOrder
  left join [dbo].[SalesOrderDetail] SalesOrderDetail on SalesOrder.SalesOrderID=SalesOrderDetail.SalesOrderID
  outer apply
  (
	select Description InvoiceDetailDescription from invoiceDetail invoiceDetail where
	invoiceDetail.InvoiceDetailId=salesorderdetail.InvoiceDetailId
  ) InvoiceDetail
  
GO
