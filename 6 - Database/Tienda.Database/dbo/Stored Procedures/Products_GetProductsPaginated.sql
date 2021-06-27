
CREATE PROCEDURE [dbo].[Products_GetProductsPaginated]
	-- Add the parameters for the stored procedure here
	@PageIndex INT,
	@PageSize INT,
	@OrderBy VARCHAR(50),
	@OrderDirection INT,
	@Search VARCHAR(200),
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

	WHERE (CategoryId = @Category OR @Category = 0 OR @Category is null) AND ([Name] LIKE @Search + '%' OR @Search = '' OR @Search = 'null' OR @Search is null)

	ORDER BY
		CASE WHEN @OrderBy = 'name' AND @OrderDirection = 0 THEN [Name] END ASC,
		CASE WHEN @OrderBy = 'name' AND @OrderDirection = 1 THEN [Name] END DESC,
		CASE WHEN @OrderBy = 'price' AND @OrderDirection = 0 THEN [Price] END ASC,
		CASE WHEN @OrderBy = 'price' AND @OrderDirection = 1 THEN [Price] END DESC,
		CASE WHEN 1 = 1 THEN [Name] END ASC

	OFFSET (@PageSize * (@PageIndex -1)) ROWS
	FETCH NEXT @PageSize ROWS ONLY

	
END