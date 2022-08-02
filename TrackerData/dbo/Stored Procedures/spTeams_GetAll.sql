CREATE PROCEDURE [dbo].[spTeams_GetAll]
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from dbo.Teams;
END
GO
