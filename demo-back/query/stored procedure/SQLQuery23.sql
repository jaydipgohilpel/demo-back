USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[getAllData]    Script Date: 08-12-2022 01:54:01 PM ******/
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
 	@id int=NULL,
	   @type varchar(50)
AS
BEGIN

DECLARE	@return_value int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	   IF(@type='getID')
			BEGIN
			SET NOCOUNT ON;
			 select * from [dbo].[tbl_registration] 
			 where id=@id;
				  SELECT	'Return Value' = @return_value
				
			END
		ELSE IF(@type='getAll')
			BEGIN
			SET NOCOUNT ON;

			DECLARE	@return_value2 int;
			 select * from [dbo].[tbl_registration] ;
				  SELECT	'Return Value' = @return_value2
				
			END
	

END