CREATE PROCEDURE [dbo].[spMatchups_Insert]
	@TournamentId int,
	@Round int,
	@Id int = 0 output

AS
Begin
	Set NOCOUNT ON;

	insert into dbo.Matchups(TournamentId, Round)
	values (@TournamentId, @Round);
	
	select @Id = SCOPE_IDENTITY();
end
GO