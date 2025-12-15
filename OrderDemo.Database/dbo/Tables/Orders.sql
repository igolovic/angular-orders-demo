CREATE TABLE [dbo].[Orders] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [ClientId]   INT           NOT NULL,
    [CreatedAt]  DATETIME2 (7) NOT NULL,
    [ModifiedAt] DATETIME2 (7) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_ClientId]
    ON [dbo].[Orders]([ClientId] ASC);

