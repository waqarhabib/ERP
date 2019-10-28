﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class PayRollEmployeeEarnings
    {
        public long PayRollEmployeeEarningsId { get; set; }
        public long Employee { get; set; }
        public int EarningCode { get; set; }
        public string Description { get; set; }
        public string EarningType { get; set; }
        public decimal Amount { get; set; }

    }
}