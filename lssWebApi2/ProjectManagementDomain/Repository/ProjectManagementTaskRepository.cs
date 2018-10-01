﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ERP_Core2.Services;
using lssWebApi2.entityframework;
using Microsoft.EntityFrameworkCore;

namespace ERP_Core2.ProjectManagementDomain
{
    public class ProjectManagementMilestoneRepository : Repository<ProjectManagementMilestones>
    {
        ListensoftwareDBContext _dbContext;
        public ProjectManagementMilestoneRepository(DbContext db) : base(db)
        {
            _dbContext = (ListensoftwareDBContext)db;
        }

        public async Task<IQueryable<ProjectManagementMilestones>> GetTasksByMilestoneId(long milestoneId)
        {
            try
            {
                var list = await base.GetObjectsQueryable(e => e.MilestoneId == milestoneId, "ProjectManagementTasks").ToListAsync();

                return list.AsQueryable<ProjectManagementMilestones>();
          
            }
            catch (Exception ex) { throw new Exception(GetMyMethodName(), ex); }

        }
    }
}