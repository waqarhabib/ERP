﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class ContractInvoice
    {
        public long ContractInvoiceId { get; set; }
        public long ContractId { get; set; }
        public long InvoiceId { get; set; }

    }
}