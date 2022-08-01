CREATE TABLE [dbo].[Prizes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PlaceNumber] INT NOT NULL,
	[PlaceName] NVARCHAR(120) NOT NULL,
	[Amount] MONEY NULL, 
    [Percentage] INT NULL
)
