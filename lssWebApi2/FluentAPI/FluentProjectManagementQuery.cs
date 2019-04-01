﻿using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using lssWebApi2.Enumerations;
using lssWebApi2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lssWebApi2.FluentAPI
{
    public class FluentProjectManagementQuery: IFluentProjectManagementQuery
    {
        private UnitOfWork _unitOfWork;
        public FluentProjectManagementQuery(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ProjectManagementMilestones>> GetTasksByMilestoneId(long milestoneId)
        {
            try
            {
                IQueryable<ProjectManagementMilestones> query = await _unitOfWork.projectManagementMilestoneRepository.GetTasksByMilestoneId(milestoneId);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("GetTasksByMilestoneId", ex);
            }
        }
        public async Task<IQueryable<ProjectManagementProject>> GetMilestones(long projectId)
        {
            try
            {
                IQueryable<ProjectManagementProject> query = await _unitOfWork.projectManagementProjectRepository.GetMilestones(projectId);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("GetMilestones", ex);
            }
        }

        public async Task<IQueryable<ProjectManagementTask>> GetTasksByProjectId(long projectId)
        {
            try
            {
                IQueryable<ProjectManagementTask> query = await _unitOfWork.projectManagementProjectRepository.GetTasksByProjectId(projectId);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("GetTasksByProjectId", ex);
            }
        }
        public async Task<NextNumber> GetProjectNumber()
        {
            return await _unitOfWork.projectManagementProjectRepository.GetNextNumber(TypeOfProjectManagement.Project.ToString());
        }
        public async Task<NextNumber> GetWorkOrderNumber()
        {
            return await _unitOfWork.projectManagementProjectRepository.GetNextNumber(TypeOfProjectManagement.WorkOrder.ToString());
        }
        public async Task<ProjectManagementProject> GetProjectByNumber(long projectNumber)
        {
            try
            {
                ProjectManagementProject project = await _unitOfWork.projectManagementProjectRepository.GetProjectByNumber(projectNumber);
                return project;
            }
            catch (Exception ex)
            {
                throw new Exception("GetProjectByNumber", ex);
            }
        }
        public async Task<ProjectManagementWorkOrder> GetWorkOrderByNumber(long workOrderNumber)
        {
            try
            {
                ProjectManagementWorkOrder workOrder = await _unitOfWork.projectManagementWorkOrderRepository.GetWorkOrderByNumber(workOrderNumber);
                return workOrder;
            }
            catch (Exception ex)
            {
                throw new Exception("GetWorkOrderByNumber", ex);
            }
        }

        public async Task<IQueryable<ProjectManagementWorkOrder>> GetWorkOrdersByProjectId(long projectId)
        {
            try
            {
                IQueryable<ProjectManagementWorkOrder> query = await _unitOfWork.projectManagementProjectRepository.GetWorkOrdersByProjectId(projectId);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("GetWorkOrdersByProjectId", ex);
            }

        }
    }
}