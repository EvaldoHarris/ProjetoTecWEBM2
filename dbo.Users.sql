CREATE TABLE [dbo].[Users] (
    [UserID]          INT              IDENTITY (1, 1) NOT NULL,
    [FirstName]       VARCHAR (50)     NOT NULL,
    [LastName]        VARCHAR (50)     NOT NULL,
	[DateOfBirth]     DATETIME         NULL,
	[CPF]		      VARCHAR (50)     NOT NULL,
	[RG]		      VARCHAR (50)     NOT NULL,
	[ESTADO]		  VARCHAR (50)     NOT NULL,
	[Cidade]		  VARCHAR (50)     NOT NULL,
	[Renda]		      VARCHAR (50)     NOT NULL,
	[Dependentes]	  VARCHAR (50)     NOT NULL,
    [EmailID]         VARCHAR (254)    NOT NULL,    
    [Password]        NVARCHAR (MAX)   NOT NULL,
    [IsEmailVerified] BIT              NOT NULL,
    [ActivationCode]  UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

