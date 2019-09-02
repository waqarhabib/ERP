﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class PayRollInsurance
    {
        public long PayRollInsuranceId { get; set; }
        public string InsuranceCode { get; set; }
        public string Description { get; set; }
        public decimal EligibleAmount { get; set; }
        public decimal Rate { get; set; }
        public long Employee { get; set; }

    }
}