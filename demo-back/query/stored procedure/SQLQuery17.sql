USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 08-12-2022 11:58:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Registration] 
	-- Add the parameters for the stored procedure here
		@id int,
       @firstName varchar(50),
       @lastName varchar(50),
       @email varchar(50),
       @mobile numeric(13,0),
       @password char(8),
       @dob datetime,
	   @type varchar(50)

AS
BEGIN
	


		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		IF(@type='insert')
			BEGIN
			SET NOCOUNT ON;
			 INSERT INTO tbl_registration
					  (firstName,lastName,email,mobile,password,dob,createdAt,isActive)
			   VALUES
					  (@firstName,@lastName,@email,@mobile,@password,@dob,GETDATE(),1)	
			END
		ELSE IF(@type='getAll')
			BEGIN
			SET NOCOUNT ON;

			DECLARE	@return_value int
			 select * from [dbo].[tbl_registration] ;
				  SELECT	'Return Value' = @return_value
				
			END
		ELSE IF(@type='getID')
			BEGIN
			SET NOCOUNT ON;
			
			 select * from [dbo].[tbl_registration] 
			 where id=@id;
				  SELECT	'Return Value' = @return_value
				
			END
	
END
