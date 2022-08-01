CREATE TABLE [dbo].[Tournaments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TournamentName] varchar(120) NOT NULL,
	[EntryFee] INT DEFAULT 0
)
