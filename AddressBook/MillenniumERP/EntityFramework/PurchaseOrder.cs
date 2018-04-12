//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MillenniumERP.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOrder
    {
        public string POType { get; set; }
        public string PaymentTerms { get; set; }
        public Nullable<decimal> GrossAmount { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> GLDate { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<long> SupplierAddressId { get; set; }
        public Nullable<long> CustomerAddressId { get; set; }
        public Nullable<long> ContractId { get; set; }
        public Nullable<long> POQuoteId { get; set; }
        public string Description { get; set; }
        public string PONumber { get; set; }
        public Nullable<int> Quantity { get; set; }
        public long PurchaseOrderId { get; set; }
        public string UnitOfMeasure { get; set; }
        public string TakenBy { get; set; }
        public Nullable<long> ShippedToAddressId { get; set; }
        public Nullable<long> BuyerAddressId { get; set; }
        public Nullable<System.DateTime> RequestedDate { get; set; }
        public Nullable<System.DateTime> PromisedDeliveredDate { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string TaxCode { get; set; }
        public Nullable<long> ItemId { get; set; }
    }
}
