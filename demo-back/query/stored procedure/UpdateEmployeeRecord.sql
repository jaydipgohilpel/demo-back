USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeRecord]    Script Date: 12-12-2022 02:18:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

ALTER PROCEDURE [dbo].[UpdateEmployeeRecord] 
	-- Add the parameters for the stored procedure here
	   @id int,
       @firstName varchar(50)=NULL,
       @lastName varchar(50)=NULL,
       @email varchar(50)=NULL,
       @mobile varchar(13)=NULL,
       @password char(8)=NULL,
       @dob varchar(50)=NULL

AS
BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
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
