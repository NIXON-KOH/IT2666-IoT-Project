CREATE TABLE [dbo].[Chat] (
    [Id]       INT            NOT NULL,
    [Datetime] DATETIME       NOT NULL,
    [Sender]   NVARCHAR (MAX) NOT NULL,
    [Receiver] NVARCHAR (MAX) NOT NULL,
    [Message]  NVARCHAR (MAX) NOT NULL,
	[Type] NVARCHAR (MAX) NOT NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);

