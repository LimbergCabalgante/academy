-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Users_InsertUser]
	-- Add the parameters for the stored procedure here
	@name VARCHAR(50),
	@surname VARCHAR(50),
	@documentNumber VARCHAR(25),
	@createdDate DATETIME,
	@username VARCHAR(50),
	@password VARCHAR(50),
	@statusId TINYINT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Users(Name, Surname, DocumentNumber, CreatedDate, Username, Password, StatusId)
	VALUES (@name, @surname, @documentNumber, @createdDate, @username, @password, @statusId);

END