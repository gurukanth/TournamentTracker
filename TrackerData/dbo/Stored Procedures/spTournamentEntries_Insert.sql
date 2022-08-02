CREATE PROCEDURE [dbo].[spTournamentEntries_Insert]
	@TournamentId int,
	@TeamId int,
	@Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	insert into dbo.TournamentEntries(TournamentId, TeamId)
	values(@TournamentId, @TeamId);

	select @Id = SCOPE_IDENTITY();
	

END
GO