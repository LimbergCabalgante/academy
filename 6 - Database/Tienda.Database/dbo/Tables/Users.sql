CREATE TABLE [dbo].[Users] (
    [Id]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50)  NOT NULL,
    [Surname]        VARCHAR (50)  NOT NULL,
    [DocumentNumber] VARCHAR (25)  NULL,
    [CreatedDate]    DATETIME      NOT NULL,
    [Username]       VARCHAR (50)  NOT NULL,
    [Password]       VARCHAR (50)  NOT NULL,
    [StatusId]       TINYINT       CONSTRAINT [DF_Users_StatusId] DEFAULT ((1)) NOT NULL,
    [BirthDate]      DATETIME      NOT NULL,
    [Email]          VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_UserStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[UserStatus] ([UserStatusId]),
    CONSTRAINT [UK_Users] UNIQUE NONCLUSTERED ([Id] ASC, [Username] ASC, [DocumentNumber] ASC, [Email] ASC),
    CONSTRAINT [UK_Users2] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [UK_Users3] UNIQUE NONCLUSTERED ([Username] ASC, [DocumentNumber] ASC)
);



