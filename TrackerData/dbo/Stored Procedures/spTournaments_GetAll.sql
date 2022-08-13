CREATE PROCEDURE [dbo].[spTournaments_GetAll]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from dbo.Tournaments;
END
GO