USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[updateRecord]    Script Date: 08-12-2022 03:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[updateRecord] 
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

		IF(@type='update')
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
