CREATE TABLE [dbo].[Clients]
(
	[ClientID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [StreetAddress] NCHAR(10) NOT NULL, 
    [Area] NCHAR(10) NOT NULL, 
    [Town] NCHAR(10) NOT NULL, 
    [PostalCode] INT NOT NULL, 
    [BookingDate] DATETIME NOT NULL
)
