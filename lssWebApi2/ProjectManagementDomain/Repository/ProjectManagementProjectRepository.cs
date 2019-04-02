﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Core2.AutoMapper;
using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ERP_Core2.ProjectManagementDomain
{
    public class ProjectManagementProjectView
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public decimal? ActualHours { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public decimal? EstimatedHours { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public decimal? Cost { get; set; }
        public int? ActualDays { get; set; }
        public int? EstimatedDays { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? BudgetHours { get; set; }
        public long? ProjectNumber { get; set; }
    }
    public class ProjectManagementProjectRepository: Repository<ProjectManagementProject>
    {
        ListensoftwaredbContext _dbContext;
        public ProjectManagementProjectRepository(DbContext db) : base(db)
        {
            _dbContext = (ListensoftwaredbContext)db;
        }
        public async Task<ProjectManagementProjectView> GetProjectViewById(long projectId)
        {
            try
            {
                var query = await (from project in _dbContext.ProjectManagementProject

                                   where (project.ProjectId == projectId)
                                   select project).FirstOrDefaultAsync<ProjectManagementProject>();

                Mapper mapper = new Mapper();

                ProjectManagementProjectView view = mapper.Map<ProjectManagementProjectView>(query);
                return view;
            }
            catch (Exception ex)
            {
                throw new Exception(GetMyMethodName(), ex);
            }
        }
        public async Task<ProjectManagementProject> GetProjectById(long projectId)
        {
            try
            {
                var query = await (from project in _dbContext.ProjectManagementProject

                                   where (project.ProjectId == projectId)
                                   select project).FirstOrDefaultAsync<ProjectManagementProject>();

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(GetMyMethodName(), ex);
            }

        }
        public async Task<ProjectManagementProject> GetProjectByNumber(long projectNumber)
        {
            try
            {
                var query = await(from project in _dbContext.ProjectManagementProject

                                 where (project.ProjectNumber==projectNumber)
                                 select project).FirstOrDefaultAsync<ProjectManagementProject>();

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(GetMyMethodName(), ex);
            }
        }
        public async Task<IQueryable<ProjectManagementWorkOrder>> GetWorkOrdersByProjectId(long projectId)
        {
            try
            {
                var list = await (from workorders in _dbContext.ProjectManagementWorkOrder

                                  where (workorders.ProjectId == projectId)
                                  select workorders).ToListAsync<ProjectManagementWorkOrder>();

                return list.AsQueryable<ProjectManagementWorkOrder>();
            }
            catch (Exception ex) {
                throw new Exception(GetMyMethodName(), ex);
            }
        }
        public async Task<IQueryable<ProjectManagementProject>> GetMilestones(long projectId)
        {
            try
            {
                var list = await base.GetObjectsQueryable(e => e.ProjectId == projectId, "ProjectManagementMilestones").ToListAsync();

                return list.AsQueryable<ProjectManagementProject>();
            }
            catch (Exception ex)
            { throw new Exception(GetMyMethodName(), ex); }

        }
        public async Task<IQueryable<ProjectManagementTask>> GetTasksByProjectId(long projectId)
        {
            try
            {
                var list = await (from milestones in _dbContext.ProjectManagementMilestones
                                  join tasks in _dbContext.ProjectManagementTask on milestones.MilestoneId equals tasks.MileStoneId
                                  where (milestones.ProjectId == projectId)
                                  select tasks).ToListAsync<ProjectManagementTask>();

                return list.AsQueryable<ProjectManagementTask>();
            }
            catch (Exception ex)
            { throw new Exception(GetMyMethodName(), ex); }


        }
      
    }
}
