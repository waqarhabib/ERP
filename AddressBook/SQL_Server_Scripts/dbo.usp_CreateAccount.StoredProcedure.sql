USE [listensoftwareDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateAccount]    Script Date: 7/30/2018 6:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreateAccount]
(
  @ParamHashTable as AccountRegistrationTableType readonly
)
AS
BEGIN
   
   select * from @ParamHashTable

END
GO
