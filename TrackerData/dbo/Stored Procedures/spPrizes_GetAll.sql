CREATE PROCEDURE [dbo].[spPrizes_GetAll]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from dbo.Prizes;
END
GO
