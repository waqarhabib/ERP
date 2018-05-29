USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[ProjectManagementTaskToEmployee]    Script Date: 5/28/2018 10:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectManagementTaskToEmployee](
	[TaskToEmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NULL,
	[TaskId] [bigint] NULL,
 CONSTRAINT [PK_ProjectManagementTaskToEmployee] PRIMARY KEY CLUSTERED 
(
	[TaskToEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[ProjectManagementTaskToEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ProjectManagementTaskToEmployee_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[ProjectManagementTaskToEmployee] CHECK CONSTRAINT [FK_ProjectManagementTaskToEmployee_Employee]
GO
ALTER TABLE [dbo].[ProjectManagementTaskToEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ProjectManagementTaskToEmployee_ProjectManagementTask] FOREIGN KEY([TaskId])
REFERENCES [dbo].[ProjectManagementTask] ([TaskId])
GO
ALTER TABLE [dbo].[ProjectManagementTaskToEmployee] CHECK CONSTRAINT [FK_ProjectManagementTaskToEmployee_ProjectManagementTask]
GO
