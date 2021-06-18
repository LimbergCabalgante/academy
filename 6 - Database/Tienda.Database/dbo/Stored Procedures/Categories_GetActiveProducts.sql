-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categories_GetActiveProducts] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.Id, c.Description, COUNT(p.CategoryId) Members
	FROM dbo.Categories c
	LEFT OUTER JOIN
	dbo.Products p
	ON c.Id = p.CategoryId AND p.StatusId = 1
	GROUP BY c.Id, c.Description

END