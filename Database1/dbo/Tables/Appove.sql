CREATE TABLE [dbo].[Appove] (
    [FormID]            INT           NOT NULL,
    [FormName]          NVARCHAR (50) NOT NULL,
    [FormVer]           NVARCHAR (50) NOT NULL,
    [LeaderApprover]    NVARCHAR (50) NULL,
    [LeaderApproveDate] DATETIME      NULL,
    [PEApprover]        NVARCHAR (50) NULL,
    [PEApproveDate]     DATETIME      NULL,
    [EEApprover]        NVARCHAR (50) NULL,
    [EEApproveDate]     DATETIME      NULL,
    [MFGApprover]       NVARCHAR (50) NULL,
    [MFGApproveDate]    DATETIME      NULL,
    [QAApprover]        NVARCHAR (50) NULL,
    [AWApproveDate]     DATETIME      NULL
);

