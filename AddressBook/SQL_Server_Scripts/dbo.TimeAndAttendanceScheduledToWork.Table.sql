USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[TimeAndAttendanceScheduledToWork]    Script Date: 5/28/2018 10:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeAndAttendanceScheduledToWork](
	[ScheduleToWorkId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[ScheduleId] [bigint] NOT NULL,
 CONSTRAINT [PK_TimeAndAttendanceScheduledToWork] PRIMARY KEY CLUSTERED 
(
	[ScheduleToWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[TimeAndAttendanceScheduledToWork]  WITH CHECK ADD  CONSTRAINT [FK_TimeAndAttendanceScheduledToWork_TimeAndAttendanceSchedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[TimeAndAttendanceSchedule] ([ScheduleId])
GO
ALTER TABLE [dbo].[TimeAndAttendanceScheduledToWork] CHECK CONSTRAINT [FK_TimeAndAttendanceScheduledToWork_TimeAndAttendanceSchedule]
GO
