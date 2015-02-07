USE [STCW]
GO

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
	[signon_date] [date] NULL,
	[signoff_date] [date] NULL,
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

ALTER TABLE [dbo].[users]  WITH NOCHECK ADD  CONSTRAINT [FK_users_rank] FOREIGN KEY([rank_id])
REFERENCES [dbo].[rank] ([rank_id])
GO

ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_rank]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__user_name__108B795B]  DEFAULT (NULL) FOR [user_name]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__firstname__117F9D94]  DEFAULT (NULL) FOR [firstname]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__lastname__1273C1CD]  DEFAULT (NULL) FOR [lastname]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__email__1367E606]  DEFAULT (NULL) FOR [email]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__rankid__145C0A3F]  DEFAULT (NULL) FOR [rank_id]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__signon_da__15502E78]  DEFAULT (NULL) FOR [signon_date]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__signoff_d__164452B1]  DEFAULT (NULL) FOR [signoff_date]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_password]  DEFAULT ('Password123') FOR [password]
GO


----------------------------------------------------------------------------------------

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

----------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ships](
	[ship_id] [int] NOT NULL,
	[ship_name] [varchar](100) NULL,
	[ship_IMO] [int] NULL,
	[serial_number] [int] NULL,
	[licence_key] [varchar](50) NULL,
	[flag] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ship_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ships]  WITH CHECK ADD  CONSTRAINT [FK_ships_users] FOREIGN KEY([ship_id])
REFERENCES [dbo].[users] ([user_id])
GO

ALTER TABLE [dbo].[ships] CHECK CONSTRAINT [FK_ships_users]
GO

ALTER TABLE [dbo].[ships] ADD  DEFAULT (NULL) FOR [ship_name]
GO

---------------------------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_entry](
	[entry_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[work_date] [date] NULL,
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

ALTER TABLE [dbo].[user_entry]  WITH CHECK ADD  CONSTRAINT [FK_user_entry_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO

ALTER TABLE [dbo].[user_entry] CHECK CONSTRAINT [FK_user_entry_users]
GO

ALTER TABLE [dbo].[user_entry] ADD  DEFAULT (NULL) FOR [user_id]
GO

ALTER TABLE [dbo].[user_entry] ADD  DEFAULT (NULL) FOR [work_date]
GO

----------------------------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_entry_hours](
	[entry_id] [int] NULL,
	[start_time] [time](7) NULL,
	[end_time] [time](7) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[user_entry_hours]  WITH CHECK ADD  CONSTRAINT [FK_user_entry_hours_user_entry] FOREIGN KEY([entry_id])
REFERENCES [dbo].[user_entry] ([entry_id])
GO

ALTER TABLE [dbo].[user_entry_hours] CHECK CONSTRAINT [FK_user_entry_hours_user_entry]
GO

ALTER TABLE [dbo].[user_entry_hours] ADD  DEFAULT (NULL) FOR [entry_id]
GO

ALTER TABLE [dbo].[user_entry_hours] ADD  DEFAULT (NULL) FOR [start_time]
GO

ALTER TABLE [dbo].[user_entry_hours] ADD  DEFAULT (NULL) FOR [end_time]
GO

------------------------------------------------------------------------------------

/****** Object:  Table [dbo].[Keys]    Script Date: 02/07/2015 19:29:42 ******/
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
