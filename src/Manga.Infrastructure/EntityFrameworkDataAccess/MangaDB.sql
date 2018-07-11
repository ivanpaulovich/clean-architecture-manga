CREATE TABLE [Account](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[PIN] [varchar](50) NOT NULL,
	[Version] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [Transaction](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[AccountId] [uniqueidentifier] NULL,
	[TransactionType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

GO
