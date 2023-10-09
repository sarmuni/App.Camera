USE [ACL]
GO

/****** Object:  Table [dbo].[CaptureMobile]    Script Date: 10/6/2023 1:29:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CaptureMobile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DirName] [varchar](100) NULL,
	[CaptureFile] [varchar](500) NULL,
	[CrtUsrID] [varchar](10) NOT NULL,
	[TsCrt] [datetime] NOT NULL,
	[ModUsrID] [varchar](10) NULL,
	[TsMod] [datetime] NULL,
	[ActiveFlag] [char](1) NOT NULL,
 CONSTRAINT [PK_CaptureMobile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CaptureMobile] ADD  CONSTRAINT [DF_CaptureMobile_TsCrt]  DEFAULT (getdate()) FOR [TsCrt]
GO

ALTER TABLE [dbo].[CaptureMobile] ADD  CONSTRAINT [DF_CaptureMobile_TsMod]  DEFAULT (getdate()) FOR [TsMod]
GO

ALTER TABLE [dbo].[CaptureMobile] ADD  CONSTRAINT [DF_CaptureMobile_ActiveFlag]  DEFAULT ('Y') FOR [ActiveFlag]
GO


USE [ACL]
GO

/****** Object:  Table [dbo].[CaptureMobile_Group]    Script Date: 10/6/2023 1:29:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CaptureMobile_Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NULL,
	[CrtUsrID] [varchar](10) NOT NULL,
	[TsCrt] [datetime] NOT NULL,
	[ModUsrID] [varchar](10) NULL,
	[TsMod] [datetime] NULL,
	[ActiveFlag] [char](1) NOT NULL,
 CONSTRAINT [PK_CaptureMobile_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CaptureMobile_Group] ADD  CONSTRAINT [DF_CaptureMobile_Group_TsCrt]  DEFAULT (getdate()) FOR [TsCrt]
GO

ALTER TABLE [dbo].[CaptureMobile_Group] ADD  CONSTRAINT [DF_CaptureMobile_Group_TsMod]  DEFAULT (getdate()) FOR [TsMod]
GO

ALTER TABLE [dbo].[CaptureMobile_Group] ADD  CONSTRAINT [DF_CaptureMobile_Group_ActiveFlag]  DEFAULT ('Y') FOR [ActiveFlag]
GO


USE [ACL]
GO

/****** Object:  Table [dbo].[CaptureMobile_GroupMember]    Script Date: 10/6/2023 1:29:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CaptureMobile_GroupMember](
	[GroupID] [int] NOT NULL,
	[UserID] [varchar](50) NOT NULL,
	[CrtUsrID] [varchar](10) NOT NULL,
	[TsCrt] [datetime] NOT NULL,
	[ModUsrID] [varchar](10) NULL,
	[TsMod] [datetime] NULL,
	[ActiveFlag] [char](1) NOT NULL,
 CONSTRAINT [PK_CaptureMobile_GroupMember] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CaptureMobile_GroupMember] ADD  CONSTRAINT [DF_CaptureMobile_GroupMember_TsCrt]  DEFAULT (getdate()) FOR [TsCrt]
GO

ALTER TABLE [dbo].[CaptureMobile_GroupMember] ADD  CONSTRAINT [DF_CaptureMobile_GroupMember_TsMod]  DEFAULT (getdate()) FOR [TsMod]
GO

ALTER TABLE [dbo].[CaptureMobile_GroupMember] ADD  CONSTRAINT [DF_CaptureMobile_GroupMember_ActiveFlag]  DEFAULT ('Y') FOR [ActiveFlag]
GO


