USE [myLocalDb]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeRecord]    Script Date: 12-12-2022 02:13:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

ALTER PROCEDURE [dbo].[DeleteEmployeeRecord] 
	-- Add the parameters for the stored procedure here
	   @id int
AS
BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
			SET NOCOUNT ON
				DECLARE	@return_value2 int;
				DELETE FROM tbl_registration
				WHERE id=@id;
				SELECT	'Return Value' = @return_value2;
END
