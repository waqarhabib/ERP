USE [listensoftwareDB]
GO
/****** Object:  Table [dbo].[ScheduleEvent]    Script Date: 5/28/2018 10:21:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleEvent](
	[ScheduleEventId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[EventDateTime] [datetime] NULL,
	[ServiceId] [bigint] NOT NULL,
	[DurationMinutes] [bigint] NULL,
	[CustomerId] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[ScheduleEvent]  WITH CHECK ADD FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServiceInformation] ([ServiceId])
GO
ALTER TABLE [dbo].[ScheduleEvent]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleEvent_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[ScheduleEvent] CHECK CONSTRAINT [FK_ScheduleEvent_Customer]
GO
ALTER TABLE [dbo].[ScheduleEvent]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleEvent_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[ScheduleEvent] CHECK CONSTRAINT [FK_ScheduleEvent_Employee]
GO
