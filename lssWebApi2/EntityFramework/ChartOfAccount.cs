﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class ChartOfAccount
    {
        public ChartOfAccount()
        {
            AccountBalance = new HashSet<AccountBalance>();
            AccountPayable = new HashSet<AccountPayable>();
            AccountReceivable = new HashSet<AccountReceivable>();
            Budget = new HashSet<Budget>();
            BudgetRange = new HashSet<BudgetRange>();
            GeneralLedger = new HashSet<GeneralLedger>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public long AccountId { get; set; }
        public string Location { get; set; }
        public string BusUnit { get; set; }
        public string Subsidiary { get; set; }
        public string SubSub { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public string CompanyCode { get; set; }
        public string GenCode { get; set; }
        public string SubCode { get; set; }
        public string ObjectNumber { get; set; }
        public string SupCode { get; set; }
        public string ThirdAccount { get; set; }
        public string CategoryCode1 { get; set; }
        public string CategoryCode2 { get; set; }
        public string CategoryCode3 { get; set; }
        public string PostEditCode { get; set; }
        public long CompanyId { get; set; }
        public int Level { get; set; }
        public long ChartOfAccountNumber { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<AccountBalance> AccountBalance { get; set; }
        public virtual ICollection<AccountPayable> AccountPayable { get; set; }
        public virtual ICollection<AccountReceivable> AccountReceivable { get; set; }
        public virtual ICollection<Budget> Budget { get; set; }
        public virtual ICollection<BudgetRange> BudgetRange { get; set; }
        public virtual ICollection<GeneralLedger> GeneralLedger { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    }
}