USE [listensoftwareDB]
GO
/****** Object:  View [dbo].[supervisorView]    Script Date: 7/4/2018 4:57:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[supervisorView]
as
select
supervisorid,
supervisorcode,
name supervisorname
from supervisor supervisor join
addressbook addressbook on supervisor.addressid=addressbook.addressid
GO
