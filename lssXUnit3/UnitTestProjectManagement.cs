﻿
using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ERP_Core2.ProjectManagementDomain
{

    public class UnitTestProjectManagement
    {

        private readonly ITestOutputHelper output;

        public UnitTestProjectManagement(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public async Task TestCreateProjecttoWorkOrder()
        {
            ProjectManagementModule pmMod = new ProjectManagementModule();

            NextNumber nnProject = await pmMod.ProjectManagement.Query().GetProjectNumber();

            ProjectManagementProject newProject = new ProjectManagementProject()
            {
                ProjectName = "Test Project",
                Version = "1",
                Description = "Test Project Description",
                EstimatedStartDate = DateTime.Parse("4/1/2019"),
                EstimatedHours = 10,
                EstimatedEndDate = DateTime.Parse("4/1/2019"),
                EstimatedDays = 1,
                ProjectNumber = nnProject.NextNumberValue
            };

            pmMod.ProjectManagement.AddProject(newProject).Apply();

            ProjectManagementProject project = await pmMod.ProjectManagement.Query().GetProjectByNumber(nnProject.NextNumberValue);

            long projectId = project.ProjectId;

            NextNumber nnWorkOrder = await pmMod.ProjectManagement.Query().GetWorkOrderNumber();

            ProjectManagementWorkOrder newWorkOrder = new ProjectManagementWorkOrder()
            {
                WorkOrderNumber = nnWorkOrder.NextNumberValue,
                Description = "Test Work Order",
                StartDate = DateTime.Parse("4/1/2019"),
                EndDate = DateTime.Parse("4/1/2019"),
                EstimatedAmount = 100,
                EstimatedHours = 10,
                AccountNumber = "Test Account",
                Instructions = "Test Instructions",
                ProjectId = projectId,
                Status = "Open",
                Location = "Test Location"
            };

            pmMod.ProjectManagement.AddWorkOrder(newWorkOrder).Apply();

            ProjectManagementWorkOrder workOrder = await pmMod.ProjectManagement.Query().GetWorkOrderByNumber(nnWorkOrder.NextNumberValue);

            //ProjectManagementMilestones mileStone = new ProjectManagementMilestones();


        }
        [Fact]
        public async Task TestGetTasksByMilestoneId()
        {
            long milestoneId = 1;
            ProjectManagementModule pmMod = new ProjectManagementModule();

            IQueryable<ProjectManagementMilestones> query = await pmMod.ProjectManagement.Query().GetTasksByMilestoneId(milestoneId);

            int count = 0;
            foreach (var item in query)
            {
                foreach (var task in item.ProjectManagementTask)
                {
                    output.WriteLine($"{task.TaskName}");
                    count++;
                }
            }
            Assert.True(count > 0);
        }

        [Fact]
        public async Task TestGetWorkOrdersByProjectId()
        {
            int projectId = 1;

            ProjectManagementModule pmMod = new ProjectManagementModule();

            IQueryable<ProjectManagementWorkOrder> query = await pmMod.ProjectManagement.Query().GetWorkOrdersByProjectId(projectId);

            foreach (var item in query)
            {
                output.WriteLine($"{item.Description}");
            }
            Assert.True(query.Count() > 0);
        }
        [Fact]
        public async Task TestGetMileStonesByProjectId()
        {
            int projectId = 1;

            ProjectManagementModule pmMod = new ProjectManagementModule();
            IQueryable<ProjectManagementProject> query = await pmMod.ProjectManagement.Query().GetMilestones(projectId);
            int count = 0;
            foreach (var item in query)
            {
                foreach (var milestone in item.ProjectManagementMilestones)
                {
                    output.WriteLine($"{milestone.MilestoneName}");
                    count++;
                }
            }
            Assert.True(count > 0);
        }

        [Fact]
        public async Task TestGetTasksByProjectId()
        {
            long projectId = 1;

            ProjectManagementModule pmMod = new ProjectManagementModule();

            IQueryable<ProjectManagementTask> query = await pmMod.ProjectManagement.Query().GetTasksByProjectId(projectId);

            int count = 0;
            foreach (var item in query)
            {

                output.WriteLine($"Task Name: {item.Wbs} {item.TaskName}");
                count++;

            }
            Assert.True(count > 0);
        }//end function

    }
}
