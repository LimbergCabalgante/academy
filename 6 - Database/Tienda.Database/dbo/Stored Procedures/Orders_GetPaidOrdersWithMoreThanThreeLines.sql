-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Orders_GetPaidOrdersWithMoreThanThreeLines] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ol.OrderId
	FROM dbo.Orders o
	JOIN
	dbo.OrderLines ol
	ON o.Id = ol.OrderId AND o.StatusId = 2
	GROUP BY ol.OrderId
	HAVING Count(o.Id) > 3
	--Para testear que funciona, se puede cambiar el 3 por otros números

END