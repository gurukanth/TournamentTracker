CREATE TABLE [dbo].[Tournaments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TournamentName] varchar(120) NOT NULL,
	[EntryFee] DECIMAL DEFAULT 0, 
    [active] BIT NULL
)
