CREATE TABLE [dbo].[DailyLinksContainer] (
    [Id]   INT      IDENTITY (1, 1) NOT NULL,
    [Date] DATETIME NOT NULL,
    CONSTRAINT [PK_DailyLinksContainer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[DailyLink] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]  INT            NOT NULL,
    [ContainerId] INT            NOT NULL,
    [Date]        DATETIME       NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Link]        NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DailyLink_DailyLinkContainer] FOREIGN KEY ([ContainerId]) REFERENCES [dbo].[DailyLinksContainer] ([Id])
);

