USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[getAllData]    Script Date: 08-12-2022 11:28:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[getAllData]
	-- Add the parameters for the stored procedure here
 
AS
BEGIN

DECLARE	@return_value int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select * from [dbo].[tbl_registration] ;
	  SELECT	'Return Value' = @return_value
	

END