USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployeeData]    Script Date: 12-12-2022 02:14:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetAllEmployeeData]
	-- Add the parameters for the stored procedure here
AS
BEGIN

DECLARE	@return_value int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			SET NOCOUNT ON;

			DECLARE	@return_value2 int;
			 select * from [dbo].[tbl_registration] ;
				  SELECT	'Return Value' = @return_value2		
END