CREATE PROCEDURE [dbo].[spPrizes_Insert]
	@PlaceNumber int,
	@PlaceName nvarchar(50),
	@Amount money,
	@Percentage int,
	@id int = 0 output

AS
Begin
	Set NOCOUNT ON;

	insert into dbo.Prizes(PlaceNumber, PlaceName, Amount, Percentage)
	values (@PlaceNumber, @PlaceName, @Amount, @Percentage);
	
	select @id = SCOPE_IDENTITY();
end
GO
