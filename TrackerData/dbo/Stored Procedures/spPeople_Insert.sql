CREATE PROCEDURE [dbo].[spPeople_Insert]
	@Firstname nvarchar(120),
	@LastName nvarchar(120),
	@EmailAddress nvarchar(120),
	@CellPhoneNumber nvarchar(50),
	@id int = 0 output

AS
Begin
	Set NOCOUNT ON;

	insert into dbo.People(Firstname, LastName, Email, CellPhoneNumber)
	values (@Firstname, @LastName, @EmailAddress, @CellPhoneNumber);
	
	select @id = SCOPE_IDENTITY();
end
GO
