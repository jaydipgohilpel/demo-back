USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeDataById]    Script Date: 12-12-2022 02:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetEmployeeDataById]
	-- Add the parameters for the stored procedure here
 		@id int=NULL
AS
BEGIN

DECLARE	@return_value int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			SET NOCOUNT ON;
			 select * from [dbo].[tbl_registration] 
			 where id=@id;
		   SELECT	'Return Value' = @return_value
	
END