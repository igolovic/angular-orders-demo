CREATE TABLE [dbo].[OrderItems] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId]
    ON [dbo].[OrderItems]([OrderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderItems_ProductId]
    ON [dbo].[OrderItems]([ProductId] ASC);

