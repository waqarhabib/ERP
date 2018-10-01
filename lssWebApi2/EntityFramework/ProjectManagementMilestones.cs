﻿using System;
using System.Collections.Generic;

namespace lssWebApi2.entityframework
{
    public partial class ProjectManagementMilestones
    {
        public ProjectManagementMilestones()
        {
            ProjectManagementTask = new HashSet<ProjectManagementTask>();
        }

        public long MilestoneId { get; set; }
        public string MilestoneName { get; set; }
        public long? ProjectId { get; set; }
        public decimal? EstimatedHours { get; set; }
        public int? ActualDays { get; set; }
        public int? EstimatedDays { get; set; }
        public decimal? ActualHours { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public decimal? Cost { get; set; }
        public string Wbs { get; set; }

        public ProjectManagementProject Project { get; set; }
        public ICollection<ProjectManagementTask> ProjectManagementTask { get; set; }
    }
}