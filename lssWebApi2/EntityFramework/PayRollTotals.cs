﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class PayRollTotals
    {
        public long PayRollTotalsId { get; set; }
        public long Employee { get; set; }
        public int? EarningCode { get; set; }
        public string EarningType { get; set; }
        public int? DeductionLiabilitiesCode { get; set; }
        public string DeductionLiabilitiesType { get; set; }
        public decimal? Amount { get; set; }
        public int PayRollGroupCode { get; set; }
        public long PaySeqence { get; set; }
        public DateTime PayRollBeginDate { get; set; }
        public DateTime PayRollEndDate { get; set; }
        public long PayRollTotalsNumber { get; set; }

    }
}