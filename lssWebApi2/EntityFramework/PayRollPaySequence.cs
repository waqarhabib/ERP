﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class PayRollPaySequence
    {
        public long PayRollPaySequenceId { get; set; }
        public long PaySequence { get; set; }
        public DateTime PayRollBeginDate { get; set; }
        public DateTime PayRollEndDate { get; set; }
        public string Frequency { get; set; }
        public int PayRollGroupCode { get; set; }
        public long PayRollPaySequenceNumber { get; set; }

    }
}