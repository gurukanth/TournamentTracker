CREATE PROCEDURE [dbo].[spTournaments_Insert]
	@TournamentName nvarchar(120),
	@EntryFee money,
	@Id int = 0 output

AS
BEGIN

	SET NOCOUNT ON;

	insert into dbo.Tournaments(TournamentName, EntryFee, active)
	values(@TournamentName, @EntryFee, 1);

	select @Id = SCOPE_IDENTITY();

END
GO