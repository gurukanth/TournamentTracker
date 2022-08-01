CREATE TABLE [dbo].[MatchupEntries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[MatchupId] INT NOT NULL,
	[ParentMatchupId] INT NULL,
	[TeamCompetingId] INT NOT NULL,
	[Score] FLOAT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_MatchupEntries_ToTeams] FOREIGN KEY ([TeamCompetingId]) REFERENCES [Teams]([Id]),
    CONSTRAINT [FK_MatchupEntries_ToMatchup1] FOREIGN KEY ([MatchupId]) REFERENCES [Matchups]([Id]),
    CONSTRAINT [FK_MatchupEntries_ToMatchup2] FOREIGN KEY ([ParentMatchupId]) REFERENCES [Matchups]([Id])
)
