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
    
    public partial class BudgetRange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BudgetRange()
        {
            this.Budgets = new HashSet<Budget>();
        }
    
        public long RangeId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Location { get; set; }
        public string GenCode { get; set; }
        public string SubCode { get; set; }
        public string SubsidiaryAcct { get; set; }
        public string Company { get; set; }
        public string BusinessUnit { get; set; }
        public string Subsidiary { get; set; }
        public Nullable<long> AccountId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ChartOfAcct ChartOfAcct { get; set; }
    }
}
