﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class PayRollDeductionLiabilities
    {
        public long PayRollDeductionLiabilitiesId { get; set; }
        public int DeductionLiabilitiesCode { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Percentage { get; set; }
        public string Description { get; set; }
        public string DeductionLiabilitiesType { get; set; }
        public decimal? LimitAmount { get; set; }

    }
}