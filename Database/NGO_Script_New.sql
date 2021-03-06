USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases
			where name='NGOWebsite')
drop database NGOWebsite
go 

/****** Object:  Database [NGOWebsite]    Script Date: 22/09/2015 1:34:32 CH ******/
CREATE DATABASE [NGOWebsite]
go

USE [NGOWebsite]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Gender][varchar](6) not null,
	[Phone] [varchar](15) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[IsActived] bit not null,
	[IsSuperAdmin] bit not null
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserName_Admin] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CauseOfDonation]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CauseOfDonation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[IsFieldOfPrograms] smallint null,
	[IsDeleted] smallint not null,
 CONSTRAINT [PK_CauseOfDonation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContactDetails]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](100) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Donation]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Donation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullNameDonator] [varchar](50) not null,
	[GenderDonator][varchar] (6) not null,
	[EmailDonator] [varchar] (100) not null,
	[CauseId] [int] NULL,
	[ProgramId] [int] NULL,
	[DateOfDonation] [date] NOT NULL,
	[Amount] [money] NOT NULL,
	[CreditType][varchar](50)not null,
	[CardNumber] [varchar](50) NULL,
	[IsDeleted] smallint not null,
 CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ImageGallery]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImageGallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProgramId] [int] NULL,
	[ImagePath] [varchar](100) NOT NULL,
	[Description] [text] NULL,
	[IsTopicImage] smallint null,
	[IsSlideImage] smallint null,
	[PositionInSlide] smallint null,
	[IsDeleted] smallint not null,
 CONSTRAINT [PK_ImageGallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Informations]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Informations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[TextTooltip] [varchar](100) NULL,
	[Contents] [text] NULL,
	[ParentId] [int] NULL,
	[Position] smallint null,
	[IsDeleted] smallint not null,
	[Links] varchar(100) null,
 CONSTRAINT [PK_Informations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Gender] [varchar](6) not null,
	[Address] [varchar](100) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[IsMemberOfTeam] [smallint] NOT NULL,
	[IsDeleted] smallint not null,
	[Image] varchar(100) null
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserName_Member] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[TextTooltip] [varchar](100) NULL,
	[Position] smallint null,
	[IsDeleted] smallint not null,
	[Links] varchar(100) null,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Message]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProgramId] [int] NULL,
	[SenderName] [varchar](50) NOT NULL,
	[SenderEmail] [varchar](50) NOT NULL,
	[Message] [text] NOT NULL,
	[Status] [smallint] NOT NULL,
	[Replier] [int] NULL,
	[IsDeleted] smallint not null,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](15) NULL,
	[Logo] [varchar](100) NULL,
	[Profile]text null,
	[IsDeleted] smallint not null,
 CONSTRAINT [PK_Partners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Programs]    Script Date: 22/09/2015 1:34:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Programs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Contents] [text] NOT NULL,
	[Status] [smallint] NOT NULL,
	[CauseId] [int] NOT NULL,
	[IsDeleted] smallint not null,
 CONSTRAINT [PK_Programs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_CauseOfDonation] FOREIGN KEY([CauseId])
REFERENCES [dbo].[CauseOfDonation] ([Id])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_CauseOfDonation]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Programs] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Programs] ([Id])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Programs]
GO
ALTER TABLE [dbo].[ImageGallery]  WITH CHECK ADD  CONSTRAINT [FK_ImageGallery_Programs] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Programs] ([Id])
GO
ALTER TABLE [dbo].[ImageGallery] CHECK CONSTRAINT [FK_ImageGallery_Programs]
GO
ALTER TABLE [dbo].[Informations]  WITH CHECK ADD  CONSTRAINT [FK_Informations_Menu] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[Informations] CHECK CONSTRAINT [FK_Informations_Menu]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Admin] FOREIGN KEY([Replier])
REFERENCES [dbo].[Admin] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Admin]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Programs] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Programs] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Programs]
GO
ALTER TABLE [dbo].[Programs]  WITH CHECK ADD  CONSTRAINT [FK_Programs_Cause] FOREIGN KEY([CauseId])
REFERENCES [dbo].[CauseOfDonation] ([Id])
GO
ALTER TABLE [dbo].[Programs] CHECK CONSTRAINT [FK_Programs_Cause]
GO


---/////////////////////////////////////////// Template Date /////////////////////////////////////////////---

INSERT [dbo].[Admin] ([UserName], [Password], [FullName], [Gender], [Phone], [Address], [Email], [IsActived], [IsSuperAdmin]) VALUES (N'administrator', N'fcea920f7412b5da7be0cf42b8c93759', N'Nguyen Kim Manh', N'Male', N'01683311711', N'Gia Lam - Ha Noi', N'kimmanh92@gmail.com', 1, 1)
INSERT [dbo].[Admin] ([UserName], [Password], [FullName], [Gender], [Phone], [Address], [Email], [IsActived], [IsSuperAdmin]) VALUES (N'hakutu', N'fcea920f7412b5da7be0cf42b8c93759', N'Nguyen Thanh Ha', N'Male', N'01625685548', N'Long Bien- Ha Noi', N'hakutu22@gmail.com', 1, 0)
INSERT [dbo].[Admin] ([UserName], [Password], [FullName], [Gender], [Phone], [Address], [Email], [IsActived], [IsSuperAdmin]) VALUES (N'luannt', N'fcea920f7412b5da7be0cf42b8c93759', N'Nguyen Thanh Luan', N'Male', N'0165845558', N'Hoang Mai - Ha Noi', N'luannt33@gmail.com', 0, 0)
INSERT [dbo].[Admin] ([UserName], [Password], [FullName], [Gender], [Phone], [Address], [Email], [IsActived], [IsSuperAdmin]) VALUES (N'anhhnn', N'fcea920f7412b5da7be0cf42b8c93759', N'Hoang Ngoc Nhat Anh', N'Male', N'0163698558', N'Hai Ba Trung- Ha Noi', N'anhhnn123@gmail.com', 1, 0)


INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Children', 0, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Disabled', 0, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Education', 0, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Elderly', 0, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Health', 0, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Environment', 0, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Health Care', 1, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Privileged children', 1, 0)
INSERT [dbo].[CauseOfDonation] ([Description], [IsFieldOfPrograms], [IsDeleted]) VALUES (N'Education', 1, 0)

INSERT [dbo].[ContactDetails] ([Address], [Phone], [Email]) VALUES (N'125 Hang Bai- Ha Noi', N'0323336658', N'ngoacc@gmail.com')
INSERT [dbo].[ContactDetails] ([Address], [Phone], [Email]) VALUES (N'88 La Thanh - Ha Noi', N'04685495226', N'ngo2acc@gmail.com')



INSERT [dbo].[Programs] ( [Name], [Contents], [Status], [CauseId], [IsDeleted]) VALUES (N'Childrens - Health Care', N'<p><span style="font-family:open sans,sans-serif; font-size:20px">Children have the same rights as adults. As a vulnerable group, children have particular rights that recognize their special need for protection and also that help them develop their full potential. Children are not helpless objects of charity or a property of their parents. They are recognized as human beings and the subjects of their own rights. A child is an individual, a family and community member with rights and appropriate responsibilities for his or her age and development stage. Children should enjoy the basic qualities of life as rights rather than privileges accorded to them&nbsp;</span></p>
', 1, 7, 0)
INSERT [dbo].[Programs] ( [Name], [Contents], [Status], [CauseId], [IsDeleted]) VALUES (N'Dream Education', N'<p><span style="font-family:open sans,sans-serif; font-size:20px">Children have the same rights as adults. As a vulnerable group, children have particular rights that recognize their special need for protection and also that help them develop their full potential. Children are not helpless objects of charity or a property of their parents. They are recognized as human beings and the subjects of their own rights. A child is an individual, a family and community member with rights and appropriate responsibilities for his or her age and development stage. Children should enjoy the basic qualities of life as rights rather than privileges accorded to them&nbsp;</span></p>
', 1, 9, 0)
INSERT [dbo].[Programs] ( [Name], [Contents], [Status], [CauseId], [IsDeleted]) VALUES (N'Privileged children', N'<p><span style="font-size:20px"><span style="font-family:open sans,sans-serif">Children have the same rights as adults. As a vulnerable group, children have particular rights that recognize their special need for protection and also that help them develop their full potential. Children are not helpless objects of charity or a property of their parents. They are recognized as human beings and the subjects of their own rights. A child is an individual, a family and community member with rights and appropriate responsibilities for his or her age and development stage. Children should enjoy the basic qualities of life as rights rather than privileges accorded to them&nbsp;</span></span><br />
&nbsp;</p>
', 1, 8, 0)
INSERT [dbo].[Programs] ( [Name], [Contents], [Status], [CauseId], [IsDeleted]) VALUES (N'Lorem Ipsum', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 0, 7, 0)
INSERT [dbo].[Programs] ( [Name], [Contents], [Status], [CauseId], [IsDeleted]) VALUES (N'Lorem Ipsum 2', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 0, 8, 0)
INSERT [dbo].[Programs] ( [Name], [Contents], [Status], [CauseId], [IsDeleted]) VALUES (N'Lorem Ipsum 3', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 2, 9, 0)

INSERT [dbo].[Donation] ( [FullNameDonator], [GenderDonator], [EmailDonator], [CauseId], [ProgramId], [DateOfDonation], [Amount], [CreditType], [CardNumber], [IsDeleted]) VALUES (N'Le Thi Huong', N'Female', N'huonglt@gmail.com', 2, NULL, CAST(0x793A0B00 AS Date), 10000.0000, N'Visa', N'02154846658455', 0)
INSERT [dbo].[Donation] ( [FullNameDonator], [GenderDonator], [EmailDonator], [CauseId], [ProgramId], [DateOfDonation], [Amount], [CreditType], [CardNumber], [IsDeleted]) VALUES (N'Tran Trung Quan', N'Male', N'quankb3@gmail.com', NULL, 1, CAST(0x793A0B00 AS Date), 3000.0000, N'Master Card', N'56415648489894', 0)
INSERT [dbo].[Donation] ( [FullNameDonator], [GenderDonator], [EmailDonator], [CauseId], [ProgramId], [DateOfDonation], [Amount], [CreditType], [CardNumber], [IsDeleted]) VALUES (N'Perter Mocker', N'Male', N'peter@gmail.com', NULL, 1, CAST(0x793A0B00 AS Date), 5000.0000, N'Visa', N'03265652515', 0)
INSERT [dbo].[Donation] ( [FullNameDonator], [GenderDonator], [EmailDonator], [CauseId], [ProgramId], [DateOfDonation], [Amount], [CreditType], [CardNumber], [IsDeleted]) VALUES (N'Ta Thi Lan', N'Female', N'lannt@gmail.com', 2, NULL, CAST(0x793A0B00 AS Date), 2000.0000, N'Master Card', N'02313212321', 0)
INSERT [dbo].[Donation] ( [FullNameDonator], [GenderDonator], [EmailDonator], [CauseId], [ProgramId], [DateOfDonation], [Amount], [CreditType], [CardNumber], [IsDeleted]) VALUES (N'Tong Lam An', N'Female', N'anlm@gmail.com', 1, NULL, CAST(0x793A0B00 AS Date), 4000.0000, N'Master Card', N'21545132132123', 0)
INSERT [dbo].[Donation] ( [FullNameDonator], [GenderDonator], [EmailDonator], [CauseId], [ProgramId], [DateOfDonation], [Amount], [CreditType], [CardNumber], [IsDeleted]) VALUES (N'Hoang Van Quan', N'Female', N'quanmsj@gmail.com', 1, NULL, CAST(0x793A0B00 AS Date), 6500.0000, N'Visa', N'03213545645', 0)

INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/Slider/ngo1.jpg', N'', NULL, 1, 1, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/Slider/nog2.jpg', N'', NULL, 1, 2, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/Slider/ngo3.jpg', N'', NULL, 1, 3, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (2, N'Content/ImageUpload/program1.jpg', N'', 1, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (1, N'Content/ImageUpload/program2.jpg', N'', 1, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (3, N'Content/ImageUpload/program3.jpg', N'', 1, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (1, N'Content/ImageUpload/ngo1.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (1, N'Content/ImageUpload/program4.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (2, N'Content/ImageUpload/nog2.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (2, N'Content/ImageUpload/program2.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (2, N'Content/ImageUpload/program5.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (2, N'Content/ImageUpload/program10.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (3, N'Content/ImageUpload/ngo3.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (3, N'Content/ImageUpload/program11.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (3, N'Content/ImageUpload/program12.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (4, N'Content/ImageUpload/program7.jpg', N'', 1, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (4, N'Content/ImageUpload/program12.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/program6.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/program7.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/program8.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/program9.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/program11.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (NULL, N'Content/ImageUpload/program12.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (5, N'Content/ImageUpload/program3.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (5, N'Content/ImageUpload/program4.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (5, N'Content/ImageUpload/program5.jpg', N'', 1, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (6, N'Content/ImageUpload/ngo3.jpg', N'', 1, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (6, N'Content/ImageUpload/nog2.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (6, N'Content/ImageUpload/program6.jpg', N'', NULL, NULL, NULL, 0)
INSERT [dbo].[ImageGallery] ( [ProgramId], [ImagePath], [Description], [IsTopicImage], [IsSlideImage], [PositionInSlide], [IsDeleted]) VALUES (6, N'Content/ImageUpload/program11.jpg', N'', NULL, NULL, NULL, 0)

INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Home', N'Home', 1, 0, N'User/Home')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Programs', N'Our Program', 2, 0, N'Programs/Programs')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Donate', N'Donate', 3, 0, N'Donate/Donate')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'About Us', N'About Us', 4, 0, N'')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Partners', N'Our Partners', 5, 0, N'Partners/Partners')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Contact Us', N'Contact Us', 6, 0, N'Message/Message')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Gallery', N'Image Gallery', 7, 0, N'Gallery/Gallery')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Register', N'Register Member', 8, 0, N'User/Register')
INSERT [dbo].[Menu] ( [Subject], [TextTooltip], [Position], [IsDeleted], [Links]) VALUES (N'Login', N'Login Member', 9, 0, N'User/Login')


INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'What we do', N'What we do', N'<p><span style="font-size:36px"> What we do : Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 4, 1, 0, N'Informationss/WhatWeDo')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Our mission', N'Our mission', N'<p><span style="font-size:36px"> Our mission : Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 4, 2, 0, N'Informationss/OurMission')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Our team', N'Our team', N'<p><span style="font-size:36px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 4, 3, 0, N'Informationss/OurTeam')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Career with us', N'Career with us', N'', 4, 4, 0, N'User/Join')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Our achievements', N'Our achievements', N'<p><span style="font-size:36px">Our achievements : Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 4, 5, 0, N'Informationss/OurAchievements')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Our supporters', N'Our supporters', N'<p><span style="font-size:36px"> Our supporters : Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 4, 6, 0, N'Informationss/OurSupporters')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Read About us', N'Read About us', N'<p><span style="font-size:36px"> Read About us : Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:36px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', 4, 7, 0, N'Informationss/ReadAboutUs')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Lorem Ipsum 1', N'', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', NULL, NULL, 0, N'')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Lorem Ipsum 2', N'', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', NULL, NULL, 0, N'')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Lorem Ipsum 3', N'', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', NULL, NULL, 0, N'')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Lorem Ipsum 4', N'', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', NULL, NULL, 0, N'')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Lorem Ipsum 5', N'', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', NULL, NULL, 0, N'')
INSERT [dbo].[Informations] ( [Subject], [TextTooltip], [Contents], [ParentId], [Position], [IsDeleted], [Links]) VALUES (N'Lorem Ipsum 6', N'', N'<p><span style="font-size:28px">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&#39;s standard dummy text ever since the 1500s.</span></p>
', NULL, NULL, 0, N'')

INSERT [dbo].[Member] ( [UserName], [Password], [FullName], [Gender], [Address], [Phone], [Email], [IsMemberOfTeam], [IsDeleted], [Image]) VALUES (N'member1', N'fcea920f7412b5da7be0cf42b8c93759', N'Ta Hoang Hoa', N'Male', N'Gia Lam - Ha Noi', N'05485168454', N'member01@gmail.com', 1, 0, N'Content/ImageUpload/Users/default.png')
INSERT [dbo].[Member] ( [UserName], [Password], [FullName], [Gender], [Address], [Phone], [Email], [IsMemberOfTeam], [IsDeleted], [Image]) VALUES (N'member2', N'fcea920f7412b5da7be0cf42b8c93759', N'Le Quang Dung', N'Male', N'Long Bien- Ha Noi', N'01625685548', N'member02@gmail.com', 0, 0, N'Content/ImageUpload/Users/Hydrangeas.jpg')
INSERT [dbo].[Member] ( [UserName], [Password], [FullName], [Gender], [Address], [Phone], [Email], [IsMemberOfTeam], [IsDeleted], [Image]) VALUES (N'member3', N'fcea920f7412b5da7be0cf42b8c93759', N'Nguyen Thi Hoa', N'Female', N'Dong Da- Ha Noi', N'054654655665', N'member03@gmail.com', -1, 0, N'Content/ImageUpload/Users/Hydrangeas.jpg')


INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (NULL, N'Trung Quang Lam', N'trungql@mailgroup.com', N'I want to become a partner.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (1, N'Tran Hong Nam', N'hongtn@group.com', N'I want to join to this program.', 1, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Peter Yoker', N'peteryk@vtc.com', N'I want to join to this program.', 2, 2, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (1, N'Yoyo', N'yoyo@vtc.com', N'Iwanttojointothisprogram.', 1, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'OKoa', N'okoa@vtc.com', N'I want to join to this program.', 2, 2, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Seloas', N'seloas@vtc.com', N'I want to join to this program.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (3, N'Luan Nguyen', N'thanhluantl2304@gmail.com', N'I want to become a partner.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Ta Hoang Hoa', N'member01@gmail.com', N'I want to become a partner.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Ta Hoang Hoa', N'member01@gmail.com', N'I want to become a partner.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Ta Hoang Hoa', N'member01@gmail.com', N'I want to become a partner.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Luan Nguyen', N'thanhluantl2304@gmail.com', N'I want to become a partner.', 1, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (2, N'Luan Nguyen', N'thanhluantl2304@gmail.com', N'I want to become a partner.', 0, NULL, 0)
INSERT [dbo].[Message] ( [ProgramId], [SenderName], [SenderEmail], [Message], [Status], [Replier], [IsDeleted]) VALUES (3, N'Luan Nguyen', N'thanhluantl2304@gmail.com', N'I want to become a partner.', 0, NULL, 0)

SET IDENTITY_INSERT [dbo].[Partners] OFF
INSERT [dbo].[Partners] ([Name], [Address], [Email], [Phone], [Logo], [Profile], [IsDeleted]) VALUES (N'Nature & More', N'124 Ha Huy Tap - Ha Noi', N'naturemore@mail.com', N'0255154845', N'Content/ImageUpload/Partners/naturemore.jpg', N'Nature & More was created in response to consumer demand for healthy, organic and fairly traded food. Their aim is to communicate the commitment and effort that individual growers make towards the planet and its people. In this way they hope to empower consumers to make informed purchasing decisions.', 0)
INSERT [dbo].[Partners] ([Name], [Address], [Email], [Phone], [Logo], [Profile], [IsDeleted]) VALUES (N'Zukunftsstiftung-landwirtschaft', N'Le Xuan Lai - Ha Noi', N'landwirtschaft@mail.com', N'0215646512', N'Content/ImageUpload/Partners/zukunftsstiftung-landwirtschaft.jpg', N'Zukunftsstiftung Landwirtschaft has been supporting organic and bio-dynamic agriculture in Germany for many years now. While key focus is the conservation of seeds, healthy soils have always been on the agenda. Especially in the UN year of the Soil though, it was decided to take this engagement to the next level and support the development of pragmatic soil conservation training materials through the Save Our Soils Fund.', 0)
INSERT [dbo].[Partners] ([Name], [Address], [Email], [Phone], [Logo], [Profile], [IsDeleted]) VALUES (N'Lebensbaum', N'Phu Tay Ho - Ha Noi', N'lebensbaum@mail.com', N'4545045442', N'Content/ImageUpload/Partners/LEBENSBAUM.jpg', N'Lebensbaum specializes in tea, coffee and spices in bio-dynamic, organic and Fairtrade qualities and has been a supporter of soil fertility projects for a very long time.The Save Our Soils Fund was granted access to soil fertility data sets of the Finca Irlanda in Mexico – a biodynamic Finca, which supplies Lebensbaum. The Soil & More Foundation was contracted to assess these data sets, develop further recommendations and make them available to the broader public via the resources section on this website.', 0)

go

---///////////////////////////////////////////  STORE PROCEDURE  /////////////////////////////////////////////////////-----------
--1. Table Admin
create proc sp_getAllAdmin
as
begin
	select * from Admin
end
go

--exec sp_getAllAdmin 

create proc sp_addNewAdmin
@username varchar(50),
@password varchar(50),
@fullname varchar(50),
@gender varchar(6),
@phone varchar(15),
@address varchar(100),
@email varchar(100),
@isActived bit,
@isSuperAdmin bit
as
begin
	insert into Admin
	values(@username,@password,@fullname,@gender,@phone,@address,@email,@isActived,@isSuperAdmin)
end
go

--exec sp_addNewAdmin 'manhnk','fcea920f7412b5da7be0cf42b8c93759','Nguyen Duy Minh','male','03225876658','Thuy Khe - Ha Noi','minhnd@gmail.com',0 

create proc sp_editAdmin
@id int,
@fullname varchar(50),
@gender varchar(6),
@phone varchar(15),
@address varchar(100),
@email varchar(100),
@isActived bit
as
begin
	update Admin
	set FullName=@fullname,Gender=@gender,Phone=@phone,Address=@address,Email=@email,IsActived=@isActived
	where Id=@id
end
go
--exec sp_editAdmin 5,'25d55ad283aa400af464c76d713c07ad','Nguyen Duy Manh','female','03225876666','Thuy Khe 2 - Ha Noi','minhnd22@gmail.com',1 

create proc sp_changePassword
@id int,
@pass varchar(50)
as
begin
	update Admin
	set Password=@pass
	where Id=@id
end
go

create proc sp_deleteAdmin
@id int
as
begin
	delete from Admin
	where Id=@id and IsSuperAdmin=0
end
go
--exec sp_deleteAdmin 5

create proc sp_searchAdmin
@value varchar(100)
as
begin
	select * from Admin
	where UserName like '%'+@value+'%'
		  or FullName like '%'+@value+'%'
end
go
--exec sp_searchAdmin ha


create proc sp_checkUserNameExisted
@username varchar(50),
@id int = null 
as
begin
	if @id is null
	select * from Admin
	where UserName=@username 
	else
	select * from Admin
	where UserName=@username and Id!=@id
end
go
--exec sp_checkUserNameExisted 'admin'

create proc sp_findAdminById
@id int
as
begin
	select * from Admin
	where Id=@id
end
go

create proc sp_checkLogin
@username varchar(50),
@password varchar(50)
as
begin
	select * from Admin
	where UserName=@username and Password=@password and IsActived=1
end
go

--exec sp_checkLogin 'admin','fcea920f7412b5da7be0cf42b8c93759'

--2. Table Cause Of Donation
create proc sp_getAllCause
as
begin
	select * from CauseOfDonation where IsDeleted=0
end
go
--exec sp_getAllCause

create proc sp_getFieldOfProgram
as
begin
	select * from CauseOfDonation where IsDeleted=0 and IsFieldOfPrograms=1
end
go

create proc sp_addNewCause
@description varchar(100),
@isFieldOfProgram smallint,
@IsDeleted smallint
as
begin
	insert into CauseOfDonation
	values(@description,@isFieldOfProgram,@IsDeleted)
end
go
--exec sp_addNewCause 'Woman',null,0

create proc sp_editCause
@id int,
@description varchar(100),
@isFieldOfProgram smallint,
@isDeleted smallint
as
begin 
	update CauseOfDonation
	set Description=@description,IsFieldOfPrograms=@isFieldOfProgram,IsDeleted=@isDeleted
	where Id=@id
end
go
--exec sp_editCause 10,'Man',1,1


create proc sp_deleteCause
@id int
as
begin 
	update CauseOfDonation
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteCause 6



create proc sp_findCauseById
@id int
as
begin
	select * from CauseOfDonation
	where Id=@id and IsDeleted=0
end
go
--exec sp_findCauseById 1

create proc sp_searchCause
@value varchar(100)
as
begin
	select * from CauseOfDonation
	where Description like '%'+@value+'%' and IsDeleted=0
end
go
--exec sp_searchCause 'e'

create proc sp_checkCauseExisted
@description varchar(100),
@id int = null
as
begin
	if @id is null
	select * from CauseOfDonation
	where Description= @description and IsDeleted=0
	else
	select * from CauseOfDonation
	where Description= @description and Id!=@id and IsDeleted=0
end
go
--exec sp_checkCauseExisted 'healTH'


--3.Table Contact Details
create proc sp_getAllContact
as
begin
	select * from ContactDetails
end
go

--exec sp_getAllContact

create proc sp_addNewContact
@address varchar(100),
@phone varchar(15),
@email varchar(100)
as
begin
	insert into ContactDetails
	values(@address,@phone,@email)
end
go
--exec sp_addNewContact '33 Pho Hue - Ha Noi','03265956554','ngo3acc@gmail.com'

create proc sp_editContact
@id int,
@address varchar(100),
@phone varchar(50),
@email varchar(100)
as
begin 
	update ContactDetails
	set Address=@address,Phone=@phone,Email=@email
	where Id=@id
end
go
--exec sp_editContact 3,'335 Pho Hue - Ha Noi','03265956222','ngo33acc@gmail.com'

create proc sp_deleteContact
@id int
as
begin 
	delete from ContactDetails
	where Id=@id
end
go
--exec sp_deleteContact 3

create proc sp_findContactById
@id int
as
begin
	select * from ContactDetails
	where Id=@id
end
go
--exec sp_findContactById 1

create proc sp_searchContact
@value varchar(100)
as
begin
	select * from ContactDetails
	where Address like '%'+@value+'%'
			or Phone like '%'+@value+'%'
			or Email like '%'+@value+'%'	
end
go
--exec sp_searchContact 'h'



--4.Table member
create proc sp_getAllMember
as
begin
	select * from Member where IsDeleted=0
	order by Id desc
end
go

--exec sp_getAllMember

create proc sp_addNewMember
@username varchar(50),
@password varchar(50),
@fullname varchar(50),
@gender varchar(6),
@address varchar(100),
@phone varchar(15),
@email varchar(100),
@isMemberOfTeam smallint,
@isDeleted smallint,
@image varchar(100)
as
begin
	insert into Member
	values(@username,@password,@fullname,@gender,@address,@phone,@email,@isMemberOfTeam,@isDeleted,@image)
end
go

--exec sp_addNewMember 'manhnk','fcea920f7412b5da7be0cf42b8c93759','Nguyen Duy Minh','male','Thuy Khe - Ha Noi','03225876658','minhnd@gmail.com',0,0,'' 

create proc sp_editMember
@id int,
@fullname varchar(50),
@gender varchar(6),
@address varchar(100),
@phone varchar(15),
@email varchar(100),
@isMemberOfTeam smallint,
@isDeleted smallint,
@image varchar(100)
as
begin
	update Member
	set FullName=@fullname,Gender=@gender,Phone=@phone,Address=@address,Email=@email,IsMemberOfTeam=@isMemberOfTeam,IsDeleted=@isDeleted,[Image]=@image
	where Id=@id
end
go
--exec sp_editMember 3,'25d55ad283aa400af464c76d713c07ad','Nguyen Duy Manh','female','Thuy Khe 2 - Ha Noi','03225876666','minhnd22@gmail.com',1,1,'aa'

create proc sp_changePasswordMember
@id int,
@pass varchar(50)
as
begin
	update Member
	set Password=@pass
	where Id=@id
end
go

create proc sp_deleteMember
@id int
as
begin
	update Member
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteMember 2


create proc sp_searchMember
@value varchar(100)
as
begin
	select * from Member
	where (UserName like '%'+@value+'%'
		  or FullName like '%'+@value+'%') 
		  and IsDeleted=0
	order by Id desc
end
go
--exec sp_searchMember member

create proc sp_checkUserMemberExisted
@username varchar(50),
@id int=null
as
begin
	if @id is null
	select * from Member
	where UserName=@username and IsDeleted=0
	else
	select * from Member
	where UserName=@username and Id!=@id  and IsDeleted=0
end
go
--exec sp_checkUserMemberExisted 'member02'

create proc sp_findMemberById
@id int
as
begin
	select * from Member
	where Id=@id and IsDeleted=0
end
go
--exec sp_findMemberById 2

create proc sp_checkLoginMember
@username varchar(50),
@password varchar(50)
as
begin
	select * from Member
	where UserName=@username and Password=@password and IsDeleted=0
end
go
--exec sp_checkLoginMember 'member1','fcea920f7412b5da7be0cf42b8c93759'

--5. Table Donation
create proc sp_getAllDonation
as
begin	
	select d.*,c.Description,p.Name 
	from (Donation d left join CauseOfDonation c on d.CauseId=c.Id) left join Programs p on d.ProgramId=p.Id
	order by d.Id desc
end
go

--exec sp_getAllDonation

create proc sp_addNewDonation
@fullname varchar(50),
@gender varchar(6),
@email varchar(100),
@causeId int=null,
@programId int=null,
@dateOfDonation date,
@amount money,
@creditType varchar(50),
@cardNumber varchar(50),
@isDeleted smallint
as
begin
	insert into Donation
	values(@fullname,@gender,@email,@causeId,@programId,@dateOfDonation,@amount,@creditType,@cardNumber,@isDeleted)
end
go

--exec sp_addNewDonation 'Nguyen Van Nam','male','namnv@yahoo.com',3,null,'09-25-2015',2000,'Master Card','12151489512132',0 

create proc sp_editDonation
@id int,
@fullname varchar(50),
@gender varchar(6),
@email varchar(100),
@causeId int=null,
@programId int=null,
@dateOfDonation date,
@amount money,
@creditType varchar(50),
@cardNumber varchar(50),
@isDeleted smallint
as
begin
	update Donation
	set FullNameDonator=@fullname,GenderDonator=@gender,EmailDonator=@email,CauseId=@causeId,ProgramId=@programId,DateOfDonation=@dateOfDonation,Amount=@amount,CreditType=@creditType,CardNumber=@cardNumber,IsDeleted=@isDeleted
	where Id=@id
end
go
--exec sp_editDonation 'Nguyen Thi Lan','female','lannv@yahoo.com',4,null,'09-25-2015',1000,'Visa','13626595555554',1
						

create proc sp_deleteDonation
@id int
as
begin
	update Donation
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteDonation 2

create proc sp_searchDonation
@value varchar(100),
@flag varchar(10),
@id int
as
begin
	if @flag='program'
	select d.*,p.Name 
	from Donation d inner join Programs p on d.ProgramId=p.Id
	where (FullNameDonator like '%'+@value+'%'
		  or GenderDonator like '%'+@value+'%'
		  or EmailDonator like '%'+@value+'%')
		  and d.ProgramId=@id and d.IsDeleted=0
	order by d.Id desc
	else
	select d.*,c.Description
	from Donation d inner join CauseOfDonation c on d.CauseId=c.Id
	where (FullNameDonator like '%'+@value+'%'
		  or GenderDonator like '%'+@value+'%'
		  or EmailDonator like '%'+@value+'%')
		  and d.CauseId=@id and d.IsDeleted=0
	order by d.Id desc
end
go
--exec sp_searchDonation male

create proc sp_findDonationById
@id int
as
begin
	select d.*,c.Description,p.Name 
	from (Donation d left join CauseOfDonation c on d.CauseId=c.Id) left join Programs p on d.ProgramId=p.Id
	where d.Id=@id and d.IsDeleted=0
end
go
--exec sp_findDonationById 1 

create proc sp_getDonation
@id int,
@flag varchar(10)
as
begin
	if @flag ='program'
		select d.*,p.Name
		from Donation d inner join Programs p on d.ProgramId=p.Id
		where d.ProgramId=@id and d.IsDeleted=0
		order by d.ProgramId desc
	else
		select d.*,c.Description
		from Donation d inner join CauseOfDonation c on d.CauseId=c.Id
		where d.CauseId=@id and d.IsDeleted=0
		order by d.CauseId asc
end
go

create proc sp_getDonationByProgramOrCause
@flag varchar(10)
as
begin
	if @flag ='program'
		select p.Id,p.Name,sum(d.Amount) as 'TotalAmount',count(d.Id) as 'NumberOfDonation'
		from Donation d inner join Programs p on d.ProgramId=p.Id
		where d.IsDeleted=0
		group by d.ProgramId,d.ProgramId,p.Name,p.Id
		order by d.ProgramId desc
	else
		select c.Id,c.Description,sum(d.Amount) as 'TotalAmount',count(d.Id) as 'NumberOfDonation'
		from Donation d inner join CauseOfDonation c on d.CauseId=c.Id
		where d.IsDeleted=0
		group by d.ProgramId,d.CauseId,c.Description,c.Id
		order by d.CauseId asc
end
go

--6.Table Menu
create proc sp_getAllMenu
as
begin
	select * from Menu where IsDeleted=0
end
go
--exec sp_getAllMenuWithPositionNotNull


create proc sp_getAllMenuWithPositionNotNull
as
begin
	select * from Menu where Position is not null and IsDeleted=0
end
go


create proc sp_getMaxPositionMenu
as
begin
	select max(Position) as 'MaxPosition' 
	from Menu
	where IsDeleted=0
end
go

create proc sp_UpdatePositionMenu
@position int,
@oldPosition int=null,
@flag varchar(10)
as
begin
	if(@flag='asc')
	update Menu
	set Position=Position+1 
	where Position>=@position and IsDeleted=0
	else
	update Menu
	set Position=Position-1 
	where Position<=@position and Position>@oldPosition and IsDeleted=0
end
go

create proc sp_UpdatePositionMenuDesc
@position int
as
begin
	update Menu
	set Position=Position-1 
	where Position>@position and IsDeleted=0
end
go

select * from Menu
go

create proc sp_addNewMenu
@subject varchar(50),
@textTooltip varchar(100),
@position smallint =null,
@isDeleted smallint,
@links varchar(100)
as
begin
	insert into Menu
	values(@subject,@textTooltip,@position,@isDeleted,@links)
end
go
--exec sp_addNewMenu 'ABC','ABC',null,0


create proc sp_editMenu
@id int,
@subject varchar(50),
@textTooltip varchar(100),
@position smallint =null,
@isDeleted smallint,
@links varchar(100)
as
begin 
	update Menu
	set Subject=@subject,TextTooltip=@textTooltip,Position=@position,IsDeleted=@isDeleted,Links=@links
	where Id=@id
end
go
--exec sp_editMenu 10,'Zero','Zero',10,0


create proc sp_deleteMenu
@id int
as
begin 
	update Menu
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteMenu 10



create proc sp_findMenuById
@id int
as
begin
	select * from Menu
	where Id=@id and IsDeleted=0
end
go
--exec sp_findMenuById 1

create proc sp_searchMenu
@value varchar(50)
as
begin
	select * from Menu
	where Subject like '%'+@value+'%' and IsDeleted=0
end
go
--exec sp_searchMenu'h'

create proc sp_checkMenuExisted
@value varchar(50),
@id int=null
as
begin
	if @id is null
	select * from Menu
	where Subject=@value and IsDeleted=0
	else
	select * from Menu
	where Subject=@value and Id!=@id  and IsDeleted=0
end
go
--exec sp_checkMenuExisted 'home'

--7.Table Informations
create proc sp_getAllInformations
as
begin
	select i.*,m.Subject as 'ParentName'
	from Informations i left join Menu m on i.ParentId=m.Id 
	where i.IsDeleted=0
	order by i.Id desc
end
go

create proc sp_getSubmenuByParent
@parent int
as
begin
	select i.*,m.Subject as 'ParentName'
	from Informations i left join Menu m on i.ParentId=m.Id 
	where i.IsDeleted=0 and i.ParentId=@parent
	order by i.Id desc
end
go


--exec sp_getAllInformations
create proc sp_getMaxPositionBaseOnParent
@parentId int
as
begin
	select max(Position) as 'MaxPosition' 
	from Informations
	where ParentId=@parentId and IsDeleted=0
end
go


create proc sp_UpdatePosition
@parentId int,
@position int,
@oldPosition int=null,
@flag varchar(10)
as
begin
if(@flag='asc')
	update Informations
	set Position=Position+1 
	where Position>=@position and ParentId=@parentId and IsDeleted=0
else
update Informations
	set Position=Position-1 
	where Position<=@position  and Position>@oldPosition and ParentId=@parentId and IsDeleted=0
end
go

create proc sp_UpdatePositionDesc
@parentId int,
@position int
as
begin
	update Informations
	set Position=Position-1 
	where Position>@position and ParentId=@parentId and IsDeleted=0
end
go


create proc sp_addNewInformation
@subject varchar(50),
@textTooltip varchar(100),
@content text,
@parentId int = null,
@position smallint =null,
@isDeleted smallint,
@links varchar(100)
as
begin
	insert into Informations
	values(@subject,@textTooltip,@content,@parentId,@position,@isDeleted,@links)
end
go
--exec sp_addNewInformation 'ABC','ABC','ABC',null,null,0


create proc sp_editInformation
@id int,
@subject varchar(50),
@textTooltip varchar(100),
@content text,
@parentId int =null,
@position smallint =null,
@isDeleted smallint,
@links varchar(100)
as
begin 
	update Informations
	set Subject=@subject,TextTooltip=@textTooltip,Contents=@content,ParentId=@parentId,Position=@position,IsDeleted=@isDeleted,Links=@links
	where Id=@id
end
go
--exec sp_editInformation 8,'Zero','Zero','Zero',null,null,1


create proc sp_deleteInformation
@id int
as
begin 
	update Informations
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteInformation 2

create proc sp_findInformationById
@id int
as
begin
	select i.*,m.Subject as 'ParentName'
	from Informations i left join Menu m on i.ParentId=m.Id
	where i.Id=@id and i.IsDeleted=0
end
go
--exec sp_findInformationById 1

create proc sp_searchInformations
@value varchar(50)
as
begin
	select i.*,m.Subject 
	from Informations i left join Menu m on i.ParentId=m.Id 
	where i.Subject like '%'+@value+'%' and i.IsDeleted=0
	order by i.Id desc
end
go
--exec sp_searchInformations'our'

create proc sp_checkInformationExisted
@value varchar(50),
@id int=null
as
begin
	if @id is null
	select i.*,m.Subject as 'ParentName'
	from Informations i left join Menu m on i.ParentId=m.Id
	where i.Subject=@value and i.IsDeleted=0
	else
	select i.*,m.Subject as 'ParentName'
	from Informations i left join Menu m on i.ParentId=m.Id
	where i.Subject=@value and i.Id!=@id  and i.IsDeleted=0
end
go
--exec sp_checkInformationExisted 'read about us',7


--8.Table Partners
create proc sp_getAllPartners
as
begin
	select * from Partners where IsDeleted=0
end
go
--exec sp_getAllPartners

create proc sp_addNewPartner
@name varchar(50),
@address varchar(100),
@email varchar(100),
@phone varchar(15),
@logo varchar(100),
@profile text,
@isDeleted smallint
as
begin
	insert into Partners
	values(@name,@address,@email,@phone,@logo,@profile,@isDeleted)
end
go
--exec sp_addNewPartner 'ABC','ABC','ABC@gmail.com','0515646845','','1111',0



create proc sp_editPartner
@id int,
@name varchar(50),
@address varchar(100),
@email varchar(100),
@phone varchar(15),
@logo varchar(100),
@profile text,
@isDeleted smallint
as
begin 
	update Partners
	set Name=@name,Address=@address,Email=@email,Phone=@phone,Logo=@logo,Profile=@profile,IsDeleted=@isDeleted
	where Id=@id
end
go
--exec sp_editPartner 4,'Zero','Zero','Zero@gmail.com','92393202309','','2222',1

create proc sp_deletePartner
@id int
as
begin 
	update Partners
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deletePartner 2


create proc sp_findPartnerById
@id int
as
begin
	select * from Partners
	where Id=@id and IsDeleted=0
end
go
--exec sp_findPartnerById 1

create proc sp_searchPartners
@value varchar(100)
as
begin
	select * from Partners
	where (Name like '%'+@value+'%'
		or Email like '%'+@value+'%'
		or Phone like '%'+@value+'%')
		and IsDeleted=0
end
go
--exec sp_searchPartners'ze'

create proc sp_checkPartnerExisted
@value varchar(50),
@id int=null
as
begin
	if @id is null
	select * from Partners
	where Name=@value and IsDeleted=0
	else
	select * from Partners
	where Name=@value and Id!=@id  and IsDeleted=0
end
go
--exec sp_checkPartnerExisted 'lebensbaum'


--9.table Programs
create proc sp_getAllPrograms
as
begin
	select p.*,c.Description 
	from Programs p inner join CauseOfDonation c on p.CauseId=c.Id
	where p.IsDeleted=0
	order by p.Id desc
end
go
--exec sp_getAllPrograms


create proc sp_checkProgramExisted
@value varchar(50),
@id int=null
as
begin
	if @id is null
	select * from Programs
	where Name=@value and IsDeleted=0
	else
	select * from Programs
	where Name=@value and Id!=@id  and IsDeleted=0
end
go

create proc sp_addNewProgram
@name varchar(50),
@content text,
@status smallint,
@causeId int,
@isDeleted smallint
as
begin
	insert into Programs
	values(@name,@content,@status,@causeId,@isDeleted)
end
go
--exec sp_addNewProgram 'ABC','ABC',1,7,0

create proc sp_editProgram
@id int,
@name varchar(50),
@content text,
@status smallint,
@causeId int,
@isDeleted smallint
as
begin 
	update Programs
	set Name=@name,Contents=@content,Status=@status,CauseId=@causeId,IsDeleted=@isDeleted
	where Id=@id
end
go
--exec sp_editProgram 4,'Zero','Zero',2,2,0


create proc sp_deleteProgram
@id int
as
begin 
	update Programs
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteProgram 2


create proc sp_findProgramById
@id int
as
begin
	select p.*,c.Description 
	from Programs p inner join CauseOfDonation c on p.CauseId=c.Id
	where p.Id=@id and p.IsDeleted=0
end
go
--exec sp_findProgramById 1

create proc sp_searchPrograms
@value varchar(100)
as
begin
	select p.*,c.Description 
	from Programs p inner join CauseOfDonation c on p.CauseId=c.Id
	where Name like '%'+@value+'%' and p.IsDeleted=0
	order by p.Id desc
end
go
--exec sp_searchPrograms'chil'


--10.table Message.
create proc sp_getAllMessage
as
begin
	select * from Message where IsDeleted=0
	order by Id desc
end
go
--exec sp_getAllMessage


create proc sp_getOtherMessage
as
begin
		select m.*,a.UserName 
		from Message m  left join Admin a on m.Replier=a.Id 
		where m.IsDeleted=0 and m.ProgramId is null
end
go

create proc sp_getProgramMessage
as
begin
		select d.ProgramId,p.Name,count(d.Id) as 'TotalMessage',
				(select (count(Id)) from Message where Status=0 and ProgramId=d.ProgramId and IsDeleted=0 ) as 'TotalNewMessage',
				(select (count(Id)) from Message where Status=1 and ProgramId=d.ProgramId and IsDeleted=0 ) as 'TotalReadMessage',
				(select (count(Id)) from Message where Status=2 and ProgramId=d.ProgramId and  IsDeleted=0 ) as 'TotalRepliedMessage'
		from Message d inner join Programs p on d.ProgramId=p.Id
		where d.IsDeleted=0 and d.ProgramId is not null
		group by d.ProgramId,p.Name,p.Id
		order by d.ProgramId desc
	
end
go

create proc sp_getMessageByProgram
@programId int
as
begin
	select m.*,p.Name,a.UserName 
	from (Message m inner join Programs p on m.ProgramId=p.Id) left join Admin a on m.Replier=a.Id 
	where m.ProgramId=@programId and m.IsDeleted=0
end
go

create proc sp_addNewMessage
@programId int=null,
@name varchar(50),
@email varchar(100),
@message text,
@status smallint,
@replier int =null,
@isDeleted smallint
as
begin
	insert into Message
	values(@programId,@name,@email,@message,@status,@replier,@isDeleted)
end
go
--exec sp_addNewMessage 3,'ABC','ABC@lonk.com','ABC ABC ABC ABC ABC',0,null,0

create proc sp_editMessage
@id int,
@programId int=null,
@name varchar(50),
@email varchar(100),
@message text,
@status smallint,
@replier int=null,
@isDeleted smallint
as
begin 
	update Message
	set ProgramId=@programId,SenderName=@name,SenderEmail=@email,Message=@message,Status=@status,Replier=@replier,IsDeleted=@isDeleted
	where Id=@id
end
go
--exec sp_editMessage 4,1,'ABCD','ABCD@lonk.com','ABCDDD ABC ABC ABC ABC',1,3,0


create proc sp_deleteMessage
@id int
as
begin 
	update Message
	set IsDeleted=1
	where Id=@id
end
go
--exec sp_deleteMessage 2


create proc sp_findMessageById
@id int
as
begin
	select m.*,p.Name,a.UserName 
	from (Message m left join Programs p on m.ProgramId=p.Id) left join Admin a on m.Replier=a.Id 
	where m.Id=@id and m.IsDeleted=0
end
go
--exec sp_findMessageById 1

create proc sp_searchMessage
@value varchar(100),
@isProgram int
as
begin
	if @isProgram is not null
		select m.*,p.Name,a.UserName 
		from (Message m left join Programs p on m.ProgramId=p.Id) left join Admin a on m.Replier=a.Id 
		where (SenderName like '%'+@value+'%'
		or SenderEmail like '%'+@value+'%')
		and m.ProgramId > 0 and m.IsDeleted=0
		order by m.Id desc
	else
		select m.*,p.Name,a.UserName 
		from (Message m left join Programs p on m.ProgramId=p.Id) left join Admin a on m.Replier=a.Id 
		where (SenderName like '%'+@value+'%'
		or SenderEmail like '%'+@value+'%')
		and m.ProgramId is null and m.IsDeleted=0
		order by m.Id desc
end
go
--exec sp_searchMessage'a', 0

create proc sp_findMessage
@isProgram int
as
begin
	if @isProgram is not null
		select m.*,p.Name,a.UserName 
		from (Message m left join Programs p on m.ProgramId=p.Id) left join Admin a on m.Replier=a.Id
		where m.ProgramId >0
		order by m.ProgramId desc
	else
		select m.*,p.Name,a.UserName 
		from (Message m left join Programs p on m.ProgramId=p.Id) left join Admin a on m.Replier=a.Id
		where m.ProgramId is null
		order by m.Id desc
end
go
--exec sp_findMessage 1


--11.table ImageGallery
create proc sp_getAllImage
as
begin
	select i.*,p.Name 
	from ImageGallery i left join Programs p on i.ProgramId=p.Id 
	where i.IsDeleted=0
	order by i.Id desc
end
go
--exec sp_getAllImage

create proc sp_addNewImage
@programId int=null,
@imagePath varchar(100),
@description text,
@isTopicImage smallint=null,
@isSlideImage smallint=null,
@positionInSlide smallint=null,
@isDeleted smallint
as
begin
	insert into ImageGallery
	values(@programId,@imagePath,@description,@isTopicImage,@isSlideImage,@positionInSlide,@isDeleted)
end
go


create proc sp_editImage
@id int,
@programId int=null,
@imagePath varchar(100),
@description text,
@isTopicImage smallint=null,
@isSlideImage smallint=null,
@positionInSlide smallint=null,
@isDeleted smallint
as
begin 
	update ImageGallery
	set ProgramId=@programId,ImagePath=@imagePath,Description=@description,IsTopicImage=@isTopicImage,IsSlideImage=@isSlideImage,PositionInSlide=@positionInSlide,IsDeleted=@isDeleted
	where Id=@id
end
go


create proc sp_deleteImage
@id int
as
begin 
	update ImageGallery
	set IsDeleted=1
	where Id=@id
end
go


create proc sp_findImageById
@id int
as
begin
	select i.*,p.Name 
	from ImageGallery i left join Programs p on i.ProgramId=p.Id 
	where i.Id=@id and i.IsDeleted=0
end
go

create proc sp_getProgramImage
as
begin
	select i.ProgramId,p.Name,count(p.Id) as 'TotalImage'
	from Programs p inner join ImageGallery i on p.Id=i.ProgramId 
	where  i.IsDeleted=0 and p.IsDeleted=0
	group by i.ProgramId, p.Name
	order by i.ProgramId desc
end
go


create proc sp_getImageTopicPrograms
as
begin
select i.ProgramId,p.Name,i.ImagePath 
from Programs p inner join ImageGallery i on p.Id=i.ProgramId
where IsTopicImage=1 and i.IsDeleted=0
group by i.ProgramId,p.Name,ImagePath
	order by i.ProgramId desc

end
go

create proc sp_getImageOthers
as
begin
	select i.*,p.Name 
	from ImageGallery i left join Programs p on i.ProgramId=p.Id 
	where i.ProgramId is null and i.IsSlideImage is null and i.IsDeleted=0
end
go

create proc sp_findImageByProgram
@programId int
as
begin
	select i.*,p.Name 
	from ImageGallery i inner join Programs p on i.ProgramId=p.Id 
	where i.ProgramId=@programId and i.IsDeleted=0
	order by i.Id desc
end
go

create proc sp_findTopicImage
@programId int
as
begin
	select i.*,p.Name 
	from ImageGallery i inner join Programs p on i.ProgramId=p.Id 
	where ProgramId=@programId and IsTopicImage=1 and i.IsDeleted=0
end
go

create proc sp_findSlideImage
as
begin
	select * from ImageGallery
	where IsSlideImage=1 and IsDeleted=0
	order by PositionInSlide asc
end
go

create proc sp_updateIsTopicImage
@proId int
as
begin
	update ImageGallery
	set IsTopicImage=null
	where IsDeleted=0 and ProgramId=@proId 
end
go


create proc sp_setImageTopicForProgramOld
@proId int = null,
@id int
as
begin
	update ImageGallery
	set IsTopicImage=1
	where IsDeleted=0 and ProgramId=@proId and Id=(select Max(Id) from ImageGallery where IsDeleted=0 and ProgramId=@proId and Id!=@id)
end
go

create proc sp_getMaxPositionSilder
as
begin
select max(PositionInSlide) as 'MaxPosition'
from ImageGallery
where IsSlideImage=1 and IsDeleted=0
end
go

create proc sp_UpdatePositionSlide
@position int,
@oldPosition int=null,
@flag varchar(10)
as
begin
if(@flag='asc')
	update ImageGallery
	set PositionInSlide=PositionInSlide+1 
	where PositionInSlide>=@position and IsDeleted=0
else
update ImageGallery
	set PositionInSlide=PositionInSlide-1 
	where PositionInSlide<=@position and PositionInSlide>@oldPosition and IsDeleted=0
end
go

create proc sp_UpdatePositionSlideDesc
@position int
as
begin
	update ImageGallery
	set PositionInSlide=PositionInSlide-1 
	where PositionInSlide>@position and IsDeleted=0
end
go

select * from Admin
select * from ImageGallery
select * from Informations order by Position asc
select * from Menu

select * from Message