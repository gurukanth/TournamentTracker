CREATE PROCEDURE [dbo].[spPeople_GetByTeam]
	@TeamId int

AS
BEGIN

	SET NOCOUNT ON;

	SELECT p.* from People p
		inner join TeamMembers tm on p.Id = tm.PersonId
		where tm.TeamId = @TeamId;
		
END
GO
