USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 08-12-2022 04:32:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

ALTER PROCEDURE [dbo].[Registration] 
	-- Add the parameters for the stored procedure here
	   @id int=NULL,
       @firstName varchar(50)=NULL,
       @lastName varchar(50)=NULL,
       @email varchar(50)=NULL,
       @mobile varchar(13)=NULL,
       @password char(8)=NULL,
       @dob varchar(50)=NULL,
	   @type varchar(50)=NULL

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
		ELSE IF(@type='delete')
			BEGIN
			SET NOCOUNT ON;

				DECLARE	@return_value2 int;
				DELETE FROM tbl_registration
				WHERE id=@id;
				SELECT	'Return Value' = @return_value2;
			END

		ELSE IF(@type='update')
		BEGIN
					DECLARE	@return_value int;
					SET NOCOUNT ON;

					UPDATE tbl_registration
					SET 
						firstName=@firstName,
						lastName=@lastName,
						email=@email,
						mobile=@mobile,
						password=@password,
						dob=@dob,
						updatedAt=GETDATE()
					 where id=@id;
					 SELECT	'Return Value' = @return_value;
		END
		

END
