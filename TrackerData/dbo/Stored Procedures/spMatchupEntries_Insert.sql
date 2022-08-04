CREATE PROCEDURE [dbo].[spMatchupEntries_Insert]
	@MatchupId int,
	@ParentMatchupId int = null,
	@TeamCompetingId int = null,
	@Id int = 0 output

AS
Begin
	Set NOCOUNT ON;

	insert into dbo.MatchupEntries(MatchupId, ParentMatchupId, TeamCompetingId)
	values (@MatchupId, @ParentMatchupId, @TeamCompetingId);
	
	select @Id = SCOPE_IDENTITY();
end
GO