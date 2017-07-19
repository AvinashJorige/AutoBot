USE [DataSourceAutobot]
GO
/****** Object:  Table [dbo].[AutobotDataSource]    Script Date: 19-Jul-17 4:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AutobotDataSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Indexes] [varchar](max) NULL,
	[Action] [varchar](max) NULL,
	[ActionDates] [datetime] NULL,
 CONSTRAINT [PK_AutobotDataSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AutobotDataSource] ON 

INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (1, N'this is a test program', N' test program ok', CAST(N'2017-07-16 14:49:16.113' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (2, N'what is your name', N' its savitar', CAST(N'2017-07-17 23:18:37.063' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (3, N'savitar what can you do', N' i can do what ever you want', CAST(N'2017-07-17 23:19:41.860' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (1002, N'what else', N' nothing.', CAST(N'2017-07-18 18:44:36.533' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (1003, N'can you talk with me', N' i can talk with you. just tap to next tab voice tab and go ahead and try me with voice assistance.', CAST(N'2017-07-18 18:46:41.833' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (1004, N'what are you', N' i am automated replying machine to assist you.', CAST(N'2017-07-18 18:47:47.020' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (1005, N'savitar what are you', N' i am automated replying machine to assist you.', CAST(N'2017-07-18 18:48:22.323' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (1006, N'ok', N' yah', CAST(N'2017-07-18 18:50:28.763' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (2002, N'can u talk with me', N' i can talk with you', CAST(N'2017-07-19 13:50:07.650' AS DateTime))
INSERT [dbo].[AutobotDataSource] ([Id], [Indexes], [Action], [ActionDates]) VALUES (2003, N'', N' my name', CAST(N'2017-07-19 13:50:49.567' AS DateTime))
SET IDENTITY_INSERT [dbo].[AutobotDataSource] OFF
