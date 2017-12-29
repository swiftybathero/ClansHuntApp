CREATE TABLE [dbo].[MemberStatus] (
    [MemberID]          INT      NOT NULL,
    [DonationsGiven]    INT      NOT NULL,
    [DonationsReceived] INT      NOT NULL,
    [StatusDate]        DATETIME CONSTRAINT [DF_MemberStatus_StatusDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [FK_MemberStatus_Member] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member] ([ID]) ON DELETE CASCADE
);

