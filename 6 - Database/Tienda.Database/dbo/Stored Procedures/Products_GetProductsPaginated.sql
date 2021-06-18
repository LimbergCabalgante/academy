
CREATE PROCEDURE [dbo].[Products_GetProductsPaginated]
	-- Add the parameters for the stored procedure here
	@PageIndex INT,
	@PageSize INT,
	@Order INT,
	@Category INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@PageIndex is null or @PageIndex < 1)
	BEGIN
		SET @PageIndex = 1
	END

	IF(@PageSize is null or @PageSize < 1)
	BEGIN
		SET @PageSize = 1
	END

    SELECT *
	FROM dbo.Products

	WHERE CategoryId = @Category OR @Category = 0

	ORDER BY
		CASE WHEN @Order = 0 or @Order > 3 or @Order is null THEN [Name] END ASC,
		CASE WHEN @Order = 1 THEN [Name] END DESC,
		CASE WHEN @Order = 2 THEN [Price] END ASC,
		CASE WHEN @Order = 3 THEN [Price] END DESC

	OFFSET (@PageSize * (@PageIndex -1)) ROWS
	FETCH NEXT @PageSize ROWS ONLY

	
END