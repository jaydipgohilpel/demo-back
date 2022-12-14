USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[NewEmployeeRegistration]    Script Date: 12-12-2022 02:17:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

ALTER PROCEDURE [dbo].[NewEmployeeRegistration] 
	-- Add the parameters for the stored procedure here
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
			SET NOCOUNT ON;
			 INSERT INTO tbl_registration
					  (firstName,lastName,email,mobile,password,dob,createdAt,isActive)
			 VALUES
					  (@firstName,@lastName,@email,@mobile,@password,@dob,GETDATE(),1)	
END
