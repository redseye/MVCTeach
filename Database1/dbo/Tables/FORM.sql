CREATE TABLE [dbo].[FORM] (
    [FormID]     VARCHAR (36)   NOT NULL,
    [FormName]   NCHAR (10)     NOT NULL,
    [FormVer]    NCHAR (10)     NOT NULL,
    [StageCode]  INT            NOT NULL,
    [Device]     NVARCHAR (50)  NOT NULL,
    [Other]      NVARCHAR (MAX) NULL,
    [Status]     VARCHAR (10)   NOT NULL,
    [CreateTime] DATETIME       NOT NULL,
    [Creater]    NVARCHAR (50)  NOT NULL,
    [UpdateTime] DATETIME       NOT NULL,
    [UpdateUser] NVARCHAR (50)  NOT NULL
);

