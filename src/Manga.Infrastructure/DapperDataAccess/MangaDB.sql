CREATE TABLE [Account](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

GO

CREATE TABLE [Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SSN] [varchar](50) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

GO

CREATE TABLE [Credit](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[AccountId] [uniqueidentifier] NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [Debit](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[AccountId] [uniqueidentifier] NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

GO
