﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class AccountPayableDetail
    {
        public long AccountPayableDetailId { get; set; }
        public long InvoiceId { get; set; }
        public long InvoiceDetailId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? QuantityReceived { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public long? PurchaseOrderDetailId { get; set; }
        public long? SalesOrderDetailId { get; set; }
        public long? ItemId { get; set; }
        public string ExtendedDescription { get; set; }
        public long AccountPayableDetailNumber { get; set; }
        public long? PurchaseOrderId { get; set; }
        public long? CustomerId { get; set; }
        public long? SupplierId { get; set; }
        public long? AccountPayableId { get; set; }

        public virtual AccountPayable AccountPayable { get; set; }

    }
}