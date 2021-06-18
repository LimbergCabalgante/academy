-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Products_UpdateProductStatusById]
	-- Add the parameters for the stored procedure here
	@newStatus SMALLINT,
	@id SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Products
	SET StatusId = @newStatus
	WHERE Id = @id

END