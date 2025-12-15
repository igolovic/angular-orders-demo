CREATE TABLE [dbo].[Clients] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

