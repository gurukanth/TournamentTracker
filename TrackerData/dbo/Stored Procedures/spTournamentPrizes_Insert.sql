CREATE PROCEDURE [dbo].[spTournamentPrizes_Insert]
	@TournamentId int,
	@PrizeId int,
	@Id int =0 output
AS
BEGIN

	SET NOCOUNT ON;

	insert into dbo.TournamentPrizes(TournamentId, PrizeId)
	values(@TournamentId, @PrizeId);

	select @Id = SCOPE_IDENTITY();
	

END
GO
