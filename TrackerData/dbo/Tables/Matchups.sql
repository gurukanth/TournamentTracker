CREATE TABLE [dbo].[Matchups]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[WinnerId] INT NULL,
	[Round] INT NOT NULL, 
    [TournamentId] INT NOT NULL, 
    CONSTRAINT [FK_Matchups_ToTeams] FOREIGN KEY ([WinnerId]) REFERENCES [Teams]([Id]),
    CONSTRAINT [FK_Matchups_ToTournaments] FOREIGN KEY ([TournamentId]) REFERENCES [Tournaments]([Id])
)
