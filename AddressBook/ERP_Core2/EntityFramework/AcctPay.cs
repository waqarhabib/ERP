namespace ERP_Core2.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcctPay")]
    public partial class AcctPay
    {
        public long Id { get; set; }

        public long? DocNumber { get; set; }

        [StringLength(10)]
        public string DocType { get; set; }

        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? InvoiceAmount { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [StringLength(10)]
        public string PaymentTerms { get; set; }

        [Column(TypeName = "money")]
        public decimal? GrossAmount { get; set; }

        public string Remark { get; set; }

        public DateTime? GLDate { get; set; }

        [StringLength(100)]
        public string AccountNumber { get; set; }

        public long SupplierId { get; set; }

        public long CustomerId { get; set; }

        public long ContractId { get; set; }

        public long POQuoteId { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public long ItemId { get; set; }

        [StringLength(50)]
        public string PONumber { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual POQuote POQuote { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
