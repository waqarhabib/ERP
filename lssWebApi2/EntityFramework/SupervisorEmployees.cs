﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.EntityFramework
{
    public partial class SupervisorEmployees
    {
        public long SupervisorEmployeesId { get; set; }
        public long SupervisorId { get; set; }
        public long EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Supervisor Supervisor { get; set; }

    }
}