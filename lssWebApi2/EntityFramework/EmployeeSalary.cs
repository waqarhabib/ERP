﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class EmployeeSalary
    {
        public long EmployeeSalaryId { get; set; }
        public long Employee { get; set; }
        public decimal AnnualSalary { get; set; }
        public DateTime StartEffectiveDate { get; set; }
        public DateTime EndEffectiveDate { get; set; }

    }
}