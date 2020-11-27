CREATE TABLE [dbo].[Categorys] (
    [CategotyID] INT        NOT NULL IDENTITY,
    [CatName]    NCHAR (16) NOT NULL,
    CONSTRAINT [PK_Categorys] PRIMARY KEY CLUSTERED ([CategotyID] ASC)
);

