CREATE TABLE [dbo].[MemberStatus] (
    [ID]                INT      IDENTITY (1, 1) NOT NULL,
    [MemberID]          INT      NOT NULL,
    [DonationsGiven]    INT      NOT NULL,
    [DonationsReceived] INT      NOT NULL,
    [StatusDate]        DATETIME CONSTRAINT [DF_MemberStatus_StatusDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_MemberStatus] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MemberStatus_Member] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member] ([ID]) ON DELETE CASCADE
);



