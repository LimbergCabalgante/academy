-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Users_DeleteUserWithNoOrdersById] 
	-- Add the parameters for the stored procedure here
	@id SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DELETE u FROM dbo.Users u
	WHERE u.Id = @id 
	--Si el usuario no tiene ordenes, no lo borra por la FK, pero no se si era esa la idea
	
END