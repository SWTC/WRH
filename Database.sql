USE [STCW]
GO
/****** Object:  Table [dbo].[ships]    Script Date: 02/10/2015 10:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ships](
	[ship_id] [int] IDENTITY(1,1) NOT NULL,
	[ship_name] [varchar](100) NULL,
	[ship_IMO] [int] NULL,
	[serial_number] [varchar](50) NULL,
	[licence_key] [varchar](50) NULL,
	[flag] [varchar](50) NULL,
 CONSTRAINT [PK__ships__CCF471DA7F60ED59] PRIMARY KEY CLUSTERED 
(
	[ship_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rank]    Script Date: 02/10/2015 10:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rank](
	[rank_id] [int] IDENTITY(1,1) NOT NULL,
	[rank_name] [varchar](50) NULL,
 CONSTRAINT [PK_rank] PRIMARY KEY CLUSTERED 
(
	[rank_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Keys]    Script Date: 02/10/2015 10:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Keys](
	[SerialKey] [varchar](255) NOT NULL,
	[ActivationKey] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Keys] PRIMARY KEY CLUSTERED 
(
	[SerialKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 02/10/2015 10:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](50) NULL,
	[firstname] [varchar](100) NULL,
	[lastname] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[rank_id] [int] NULL,
	[signon_date] [datetime] NULL,
	[signoff_date] [datetime] NULL,
	[password] [varchar](50) NULL,
	[passport_number] [varchar](50) NULL,
	[cdc_number] [varchar](50) NULL,
	[ship_id] [int] NULL,
 CONSTRAINT [PK__users__B9BE370F0EA330E9] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user_entry]    Script Date: 02/10/2015 10:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user_entry](
	[entry_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[work_date] [datetime] NULL,
	[hours_list] [varchar](200) NULL,
	[total_hours] [float] NULL,
	[comments] [varchar](max) NULL,
	[nc_remarks] [varchar](max) NULL,
 CONSTRAINT [PK__user_ent__810FDCE10425A276] PRIMARY KEY CLUSTERED 
(
	[entry_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF__ships__ship_name__014935CB]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[ships] ADD  CONSTRAINT [DF__ships__ship_name__014935CB]  DEFAULT (NULL) FOR [ship_name]
GO
/****** Object:  Default [DF__user_entr__user___060DEAE8]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[user_entry] ADD  CONSTRAINT [DF__user_entr__user___060DEAE8]  DEFAULT (NULL) FOR [user_id]
GO
/****** Object:  Default [DF__user_entr__work___07F6335A]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[user_entry] ADD  CONSTRAINT [DF__user_entr__work___07F6335A]  DEFAULT (NULL) FOR [work_date]
GO
/****** Object:  Default [DF__users__user_name__108B795B]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__user_name__108B795B]  DEFAULT (NULL) FOR [user_name]
GO
/****** Object:  Default [DF__users__firstname__117F9D94]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__firstname__117F9D94]  DEFAULT (NULL) FOR [firstname]
GO
/****** Object:  Default [DF__users__lastname__1273C1CD]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__lastname__1273C1CD]  DEFAULT (NULL) FOR [lastname]
GO
/****** Object:  Default [DF__users__email__1367E606]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__email__1367E606]  DEFAULT (NULL) FOR [email]
GO
/****** Object:  Default [DF__users__rankid__145C0A3F]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__rankid__145C0A3F]  DEFAULT (NULL) FOR [rank_id]
GO
/****** Object:  Default [DF__users__signon_da__15502E78]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__signon_da__15502E78]  DEFAULT (NULL) FOR [signon_date]
GO
/****** Object:  Default [DF__users__signoff_d__164452B1]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__signoff_d__164452B1]  DEFAULT (NULL) FOR [signoff_date]
GO
/****** Object:  Default [DF_users_password]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_password]  DEFAULT ('Password123') FOR [password]
GO
/****** Object:  ForeignKey [FK_user_entry_users]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[user_entry]  WITH CHECK ADD  CONSTRAINT [FK_user_entry_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[user_entry] CHECK CONSTRAINT [FK_user_entry_users]
GO
/****** Object:  ForeignKey [FK_users_rank]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users]  WITH NOCHECK ADD  CONSTRAINT [FK_users_rank] FOREIGN KEY([rank_id])
REFERENCES [dbo].[rank] ([rank_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_rank]
GO
/****** Object:  ForeignKey [FK_users_ships]    Script Date: 02/10/2015 10:15:11 ******/
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_ships] FOREIGN KEY([ship_id])
REFERENCES [dbo].[ships] ([ship_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_ships]
GO


ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_ships]
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Administrator')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Chief Engineer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Second Engineer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Third Engineer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Fourth Engineer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Elect Officer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Chief Officer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Second Officer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Third Officer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Gas Engineer')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Deck User1')
GO
INSERT INTO [STCW].[dbo].[rank] ([rank_name]) VALUES ('Deck User2')
GO