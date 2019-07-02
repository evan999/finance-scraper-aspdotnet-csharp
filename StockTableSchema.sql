CREATE TABLE [dbo].[Stocks1]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Symbol] VARCHAR(10) NOT NULL, 
    [LastPrice] VARCHAR(10) NOT NULL, 
    [Change] VARCHAR(10) NOT NULL, 
    [ChangeRate] VARCHAR(10) NOT NULL, 
    [Currency] VARCHAR(10) NOT NULL, 
    [MarketTime] VARCHAR(20) NOT NULL, 
    [Volume] VARCHAR(20) NOT NULL, 
    [Shares] VARCHAR(10) NULL, 
    [AverageVolume] VARCHAR(20) NOT NULL, 
    [DayRange] VARCHAR(50) NULL, 
    [52WeekRange] VARCHAR(50) NULL, 
    [MarketCap] VARCHAR(20) NOT NULL
);