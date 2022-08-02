﻿CREATE PROCEDURE [dbo].[spTeamMembers_Insert]
	@TeamId int,
	@PersonId int,
	@Id int = 0 output
	
AS
BEGIN
	
	SET NOCOUNT ON;

	insert into dbo.TeamMembers(TeamId, PersonId)
	values(@TeamId, @PersonId);

	select @Id = SCOPE_IDENTITY();

END
GO
