CREATE TABLE [dbo].[MemberStatus] (
    [MemberID]          INT      NOT NULL,
    [DonationsGiven]    INT      NULL,
    [DonationsReceived] INT      NULL,
    [CreatedDate]       DATETIME CONSTRAINT [DF_MemberStatus_CreatedDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [FK_MemberStatus_Member] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member] ([ID]) ON DELETE CASCADE
);

