CREATE TABLE [dbo].[Member] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Tag]  NVARCHAR (12) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Member]
    ON [dbo].[Member]([Tag] ASC);

