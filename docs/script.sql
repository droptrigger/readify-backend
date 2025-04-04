USE [Readify]
GO
/****** Object:  Table [dbo].[BannedUsers]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BannedUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[ban_reason] [nvarchar](200) NULL,
	[banned_at] [datetime] NOT NULL,
 CONSTRAINT [PK_BannedUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookmarks]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookmarks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_library] [int] NOT NULL,
	[page] [int] NOT NULL,
	[comment] [nvarchar](100) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Bookmarks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookReviews]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReviews](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_author] [int] NOT NULL,
	[id_book] [int] NOT NULL,
	[comment] [nvarchar](2000) NOT NULL,
	[rating] [tinyint] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_BookReviews] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[page_quantity] [int] NOT NULL,
	[id_author] [int] NOT NULL,
	[cover_image_path] [nvarchar](250) NOT NULL,
	[file_book_path] [nvarchar](200) NOT NULL,
	[id_genre] [int] NULL,
	[is_private] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libraries]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libraries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_book] [int] NOT NULL,
	[progress_page] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Libraries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikesReviews]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikesReviews](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_author] [int] NOT NULL,
	[id_review] [int] NOT NULL,
	[reaction_type] [tinyint] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_LikesReviews] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[action] [nvarchar](200) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nickname] [nvarchar](50) NOT NULL,
	[description] [nvarchar](250) NULL,
	[avatar_image_path] [nvarchar](255) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[password_hash] [nvarchar](255) NOT NULL,
	[id_role] [int] NOT NULL,
	[is_banned] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSessions]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSessions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[refresh_token_hash] [nvarchar](255) NOT NULL,
	[device_type] [nvarchar](50) NOT NULL,
	[expires_in] [datetime] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_UserSessions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSubscribers]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSubscribers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_author] [int] NOT NULL,
	[id_subscriber] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_UserSubscribers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[СonfirmationСodes]    Script Date: 24.03.2025 4:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[СonfirmationСodes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](6) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[expires_in] [datetime] NOT NULL,
 CONSTRAINT [PK_СonfirmationСodes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BannedUsers] ON 

INSERT [dbo].[BannedUsers] ([id], [id_user], [ban_reason], [banned_at]) VALUES (2, 1, N'Нарушение правил', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BannedUsers] ([id], [id_user], [ban_reason], [banned_at]) VALUES (4, 3, N'Оскорбления', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BannedUsers] ([id], [id_user], [ban_reason], [banned_at]) VALUES (5, 4, N'Неподобающее поведение', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BannedUsers] ([id], [id_user], [ban_reason], [banned_at]) VALUES (6, 5, N'Жалобы пользователей', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
SET IDENTITY_INSERT [dbo].[BannedUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookmarks] ON 

INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (1, 1, 10, N'Закладка 1', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (3, 3, 30, N'Закладка 3', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (4, 4, 40, N'Закладка 4', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (5, 5, 50, N'Закладка 5', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (6, 6, 60, N'Закладка 6', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (7, 7, 70, N'Закладка 7', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (8, 8, 80, N'Закладка 8', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (9, 9, 90, N'Закладка 9', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Bookmarks] ([id], [id_library], [page], [comment], [created_at]) VALUES (10, 10, 100, N'Закладка 10', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bookmarks] OFF
GO
SET IDENTITY_INSERT [dbo].[BookReviews] ON 

INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (1, 1, 1, N'Отличная книга!', 5, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (3, 3, 3, N'Хорошо написано.', 4, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (4, 4, 4, N'Необычный стиль.', 3, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (5, 5, 5, N'Понравилось.', 5, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (6, 6, 6, N'Средне.', 3, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (7, 7, 7, N'Впечатляет.', 5, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (8, 8, 8, N'Нормально.', 4, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (9, 9, 9, N'Читабельно.', 3, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[BookReviews] ([id], [id_author], [id_book], [comment], [rating], [created_at]) VALUES (10, 10, 10, N'Увлекательно.', 5, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
SET IDENTITY_INSERT [dbo].[BookReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (1, N'Книга 1', N'Описание книги 1', 0, 1, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (3, N'Книга 3', N'Описание книги 3', 0, 3, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (4, N'Книга 4', N'Описание книги 4', 0, 4, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 4, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (5, N'Книга 5', N'Описание книги 5', 0, 5, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 5, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (6, N'Книга 6', N'Описание книги 6', 0, 6, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 6, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (7, N'Книга 7', N'Описание книги 7', 0, 7, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 7, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (8, N'Книга 8', N'Описание книги 8', 0, 8, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 8, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (9, N'Книга 9', N'Описание книги 9', 0, 9, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 9, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (10, N'Книга 10', N'Описание книги 10', 0, 10, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 10, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Books] ([id], [name], [description], [page_quantity], [id_author], [cover_image_path], [file_book_path], [id_genre], [is_private], [created_at]) VALUES (11, N'Тест', N'Крутая книга', 100, 11, N'images/books/covers/book-cover-id11.png', N'images/books/files/book-file-id11.png', 1, 0, CAST(N'2025-02-06T23:00:30.297' AS DateTime))
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([id], [name]) VALUES (1, N'Фантастика')
INSERT [dbo].[Genres] ([id], [name]) VALUES (4, N'Научная литература')
INSERT [dbo].[Genres] ([id], [name]) VALUES (5, N'История')
INSERT [dbo].[Genres] ([id], [name]) VALUES (6, N'Приключения')
INSERT [dbo].[Genres] ([id], [name]) VALUES (7, N'Поэзия')
INSERT [dbo].[Genres] ([id], [name]) VALUES (8, N'Биография')
INSERT [dbo].[Genres] ([id], [name]) VALUES (9, N'Философия')
INSERT [dbo].[Genres] ([id], [name]) VALUES (10, N'Комиксы')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Libraries] ON 

INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (1, 1, 1, 10, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (3, 3, 3, 30, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (4, 4, 4, 40, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (5, 5, 5, 50, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (6, 6, 6, 60, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (7, 7, 7, 70, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (8, 8, 8, 80, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (9, 9, 9, 90, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (10, 10, 10, 100, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Libraries] ([id], [id_user], [id_book], [progress_page], [created_at]) VALUES (11, 11, 1, 0, CAST(N'2025-02-06T22:11:40.310' AS DateTime))
SET IDENTITY_INSERT [dbo].[Libraries] OFF
GO
SET IDENTITY_INSERT [dbo].[LikesReviews] ON 

INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (1, 1, 1, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (3, 3, 3, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (4, 4, 4, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (5, 5, 5, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (6, 6, 6, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (7, 7, 7, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (8, 8, 8, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (9, 9, 9, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (10, 10, 10, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[LikesReviews] ([id], [id_author], [id_review], [reaction_type], [created_at]) VALUES (11, 11, 1, 1, CAST(N'2025-02-06T22:49:20.563' AS DateTime))
SET IDENTITY_INSERT [dbo].[LikesReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1, 1, N'Добавление книги', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (3, 3, N'Редактирование профиля', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (4, 4, N'Добавление отзыва', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (5, 5, N'Лайк отзыва', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (6, 6, N'Добавление в библиотеку', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (7, 7, N'Обновление данных', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (8, 8, N'Удаление книги', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (9, 9, N'Добавление жанра', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (10, 10, N'Изменение роли', CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (11, 11, N'Registration', CAST(N'2025-02-05T11:02:21.163' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (12, 11, N'Generate token', CAST(N'2025-02-05T11:02:44.053' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (13, 11, N'Login', CAST(N'2025-02-05T11:02:44.080' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (14, 11, N'Update', CAST(N'2025-02-05T11:03:26.147' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (15, 11, N'Generate token', CAST(N'2025-02-06T20:33:24.420' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (16, 11, N'Login', CAST(N'2025-02-06T20:33:24.587' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (17, 11, N'Update', CAST(N'2025-02-06T20:33:43.010' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (18, 11, N'Generate token', CAST(N'2025-02-06T20:46:12.653' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (19, 11, N'Login', CAST(N'2025-02-06T20:46:12.823' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (20, 11, N'Generate token', CAST(N'2025-02-06T22:10:58.187' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (21, 11, N'Login', CAST(N'2025-02-06T22:10:58.350' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (22, 11, N'Added a book to the library. Book id: 1', CAST(N'2025-02-06T22:11:40.330' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (23, 11, N'Generate token', CAST(N'2025-02-06T22:14:42.687' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (24, 11, N'Login', CAST(N'2025-02-06T22:14:42.843' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (25, 11, N'Generate token', CAST(N'2025-02-06T22:48:45.140' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (26, 11, N'Login', CAST(N'2025-02-06T22:48:45.307' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (27, 11, N'Generate token', CAST(N'2025-02-06T22:58:52.750' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (28, 11, N'Login', CAST(N'2025-02-06T22:58:52.797' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (29, 11, N'Generate token', CAST(N'2025-02-08T23:31:08.680' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (30, 11, N'Login', CAST(N'2025-02-08T23:31:08.827' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (31, 11, N'Generate token', CAST(N'2025-02-08T23:36:12.350' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (32, 11, N'Login', CAST(N'2025-02-08T23:36:12.357' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (33, 11, N'Generate token', CAST(N'2025-02-08T23:43:46.093' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (34, 11, N'Login', CAST(N'2025-02-08T23:43:46.227' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (35, 11, N'Generate token', CAST(N'2025-02-08T23:45:52.533' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (36, 11, N'Login', CAST(N'2025-02-08T23:45:52.540' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (37, 11, N'Generate token', CAST(N'2025-02-08T23:50:18.607' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (38, 11, N'Login', CAST(N'2025-02-08T23:50:18.613' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (40, 11, N'Generate token', CAST(N'2025-02-09T05:18:58.857' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (41, 11, N'Login', CAST(N'2025-02-09T05:18:59.003' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (42, 11, N'Generate token', CAST(N'2025-02-09T05:18:59.017' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (43, 11, N'Refresh', CAST(N'2025-02-09T05:18:59.017' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (44, 11, N'Generate token', CAST(N'2025-02-09T05:19:08.490' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (45, 11, N'Login', CAST(N'2025-02-09T05:19:08.493' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (46, 11, N'Generate token', CAST(N'2025-02-09T05:19:08.493' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (47, 11, N'Refresh', CAST(N'2025-02-09T05:19:08.497' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (48, 11, N'Generate token', CAST(N'2025-02-09T05:20:16.940' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (49, 11, N'Login', CAST(N'2025-02-09T05:20:16.947' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (50, 11, N'Generate token', CAST(N'2025-02-09T05:20:16.950' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (51, 11, N'Refresh', CAST(N'2025-02-09T05:20:16.950' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (58, 11, N'Generate token', CAST(N'2025-02-09T07:49:15.103' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (59, 11, N'Login', CAST(N'2025-02-09T07:49:15.133' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (60, 11, N'Generate token', CAST(N'2025-02-09T07:49:15.147' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (61, 11, N'Refresh', CAST(N'2025-02-09T07:49:15.150' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (103, 11, N'Generate token', CAST(N'2025-02-09T09:21:43.493' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (104, 11, N'Login', CAST(N'2025-02-09T09:21:43.770' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (105, 11, N'Generate token', CAST(N'2025-02-09T09:21:43.800' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (106, 11, N'Refresh', CAST(N'2025-02-09T09:21:43.800' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (107, 11, N'Generate token', CAST(N'2025-02-09T09:21:43.830' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (108, 11, N'Login', CAST(N'2025-02-09T09:21:43.833' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (109, 11, N'Generate token', CAST(N'2025-02-09T09:21:43.833' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (110, 11, N'Refresh', CAST(N'2025-02-09T09:21:43.837' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (111, 11, N'Generate token', CAST(N'2025-02-09T09:27:03.040' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (112, 11, N'Login', CAST(N'2025-02-09T09:27:03.170' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (113, 11, N'Generate token', CAST(N'2025-02-09T09:27:03.183' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (114, 11, N'Refresh', CAST(N'2025-02-09T09:27:03.187' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (115, 11, N'Generate token', CAST(N'2025-02-09T09:34:27.443' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (116, 11, N'Login', CAST(N'2025-02-09T09:34:27.573' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (117, 11, N'Generate token', CAST(N'2025-02-09T09:34:27.587' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (118, 11, N'Refresh', CAST(N'2025-02-09T09:34:27.590' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1057, 11, N'Generate token', CAST(N'2025-02-09T19:18:22.853' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1058, 11, N'Login', CAST(N'2025-02-09T19:18:22.990' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1059, 11, N'Generate token', CAST(N'2025-02-09T19:18:23.003' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1060, 11, N'Refresh', CAST(N'2025-02-09T19:18:23.003' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1061, 11, N'Generate token', CAST(N'2025-02-09T19:37:37.587' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1062, 11, N'Login', CAST(N'2025-02-09T19:37:37.723' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1063, 11, N'Generate token', CAST(N'2025-02-09T19:37:37.740' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1064, 11, N'Refresh', CAST(N'2025-02-09T19:37:37.740' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1065, 11, N'Generate token', CAST(N'2025-02-09T19:40:57.610' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1066, 11, N'Login', CAST(N'2025-02-09T19:40:57.743' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1067, 11, N'Generate token', CAST(N'2025-02-09T19:40:57.757' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1068, 11, N'Refresh', CAST(N'2025-02-09T19:40:57.760' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1069, 11, N'Generate token', CAST(N'2025-02-09T21:42:51.093' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1070, 11, N'Login', CAST(N'2025-02-09T21:42:51.240' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1071, 11, N'Generate token', CAST(N'2025-02-09T21:42:51.253' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1072, 11, N'Refresh', CAST(N'2025-02-09T21:42:51.253' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1073, 11, N'Generate token', CAST(N'2025-02-09T21:44:45.297' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1074, 11, N'Login', CAST(N'2025-02-09T21:44:45.443' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1075, 11, N'Generate token', CAST(N'2025-02-09T21:44:45.460' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1076, 11, N'Refresh', CAST(N'2025-02-09T21:44:45.460' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1077, 11, N'Generate token', CAST(N'2025-02-09T21:54:58.063' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1078, 11, N'Login', CAST(N'2025-02-09T21:54:58.200' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1079, 11, N'Generate token', CAST(N'2025-02-09T21:54:58.213' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1080, 11, N'Refresh', CAST(N'2025-02-09T21:54:58.213' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1081, 11, N'Generate token', CAST(N'2025-02-09T22:09:44.327' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1082, 11, N'Login', CAST(N'2025-02-09T22:09:44.477' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1083, 11, N'Generate token', CAST(N'2025-02-09T22:09:44.493' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1084, 11, N'Refresh', CAST(N'2025-02-09T22:09:44.497' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1085, 11, N'Generate token', CAST(N'2025-02-09T22:13:23.793' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1086, 11, N'Login', CAST(N'2025-02-09T22:13:23.927' AS DateTime))
GO
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1087, 11, N'Generate token', CAST(N'2025-02-09T22:13:23.943' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1088, 11, N'Refresh', CAST(N'2025-02-09T22:13:23.943' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1089, 11, N'Generate token', CAST(N'2025-02-09T22:13:26.257' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1090, 11, N'Refresh', CAST(N'2025-02-09T22:13:26.257' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1091, 11, N'Generate token', CAST(N'2025-02-09T22:14:33.670' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1092, 11, N'Refresh', CAST(N'2025-02-09T22:14:33.670' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1093, 11, N'Generate token', CAST(N'2025-02-09T22:14:35.840' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1094, 11, N'Refresh', CAST(N'2025-02-09T22:14:35.843' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1095, 11, N'Generate token', CAST(N'2025-02-09T22:16:04.933' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1096, 11, N'Refresh', CAST(N'2025-02-09T22:16:04.933' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1097, 11, N'Generate token', CAST(N'2025-02-09T22:16:06.367' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1098, 11, N'Refresh', CAST(N'2025-02-09T22:16:06.370' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1099, 11, N'Generate token', CAST(N'2025-02-09T22:16:32.877' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1100, 11, N'Refresh', CAST(N'2025-02-09T22:16:32.880' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1101, 11, N'Generate token', CAST(N'2025-02-09T22:16:48.350' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1102, 11, N'Refresh', CAST(N'2025-02-09T22:16:48.350' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1103, 11, N'Generate token', CAST(N'2025-02-09T22:17:01.863' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1104, 11, N'Refresh', CAST(N'2025-02-09T22:17:01.863' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1105, 11, N'Generate token', CAST(N'2025-02-09T22:17:09.633' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1106, 11, N'Refresh', CAST(N'2025-02-09T22:17:09.633' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1107, 11, N'Generate token', CAST(N'2025-02-09T22:39:19.953' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1108, 11, N'Login', CAST(N'2025-02-09T22:39:20.087' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1109, 11, N'Generate token', CAST(N'2025-02-09T22:39:20.100' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1110, 11, N'Refresh', CAST(N'2025-02-09T22:39:20.103' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1111, 11, N'Generate token', CAST(N'2025-02-09T22:39:24.747' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1112, 11, N'Refresh', CAST(N'2025-02-09T22:39:24.750' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1113, 11, N'Generate token', CAST(N'2025-02-09T22:42:36.830' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1114, 11, N'Refresh', CAST(N'2025-02-09T22:42:36.833' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1115, 11, N'Generate token', CAST(N'2025-02-09T22:50:41.037' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1116, 11, N'Refresh', CAST(N'2025-02-09T22:50:41.150' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1117, 11, N'Generate token', CAST(N'2025-02-09T22:50:43.167' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1118, 11, N'Refresh', CAST(N'2025-02-09T22:50:43.170' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1119, 11, N'Generate token', CAST(N'2025-02-10T03:11:23.617' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1120, 11, N'Refresh', CAST(N'2025-02-10T03:11:23.740' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1121, 11, N'Generate token', CAST(N'2025-02-10T03:12:39.933' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1122, 11, N'Refresh', CAST(N'2025-02-10T03:12:39.937' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1123, 11, N'Generate token', CAST(N'2025-02-10T03:13:12.027' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1124, 11, N'Refresh', CAST(N'2025-02-10T03:13:12.027' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1125, 11, N'Generate token', CAST(N'2025-02-10T03:17:28.527' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1126, 11, N'Login', CAST(N'2025-02-10T03:17:28.537' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1127, 11, N'Generate token', CAST(N'2025-02-10T03:19:19.307' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1128, 11, N'Refresh', CAST(N'2025-02-10T03:19:19.307' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1129, 11, N'Generate token', CAST(N'2025-02-10T03:19:20.883' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1130, 11, N'Refresh', CAST(N'2025-02-10T03:19:20.883' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1135, 11, N'Generate token', CAST(N'2025-02-10T03:54:27.653' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1136, 11, N'Login', CAST(N'2025-02-10T03:54:27.780' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1137, 11, N'Generate token', CAST(N'2025-02-10T03:54:33.950' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1138, 11, N'Refresh', CAST(N'2025-02-10T03:54:33.953' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1143, 11, N'Generate token', CAST(N'2025-02-10T04:00:00.363' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1144, 11, N'Login', CAST(N'2025-02-10T04:00:00.367' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1145, 11, N'Generate token', CAST(N'2025-02-10T04:00:10.660' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1146, 11, N'Refresh', CAST(N'2025-02-10T04:00:10.660' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1197, 11, N'Generate token', CAST(N'2025-03-11T20:30:25.973' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1198, 11, N'Login', CAST(N'2025-03-11T20:30:26.147' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1199, 11, N'Generate token', CAST(N'2025-03-11T22:29:54.677' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1200, 11, N'Login', CAST(N'2025-03-11T22:29:54.853' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1201, 11, N'Generate token', CAST(N'2025-03-11T22:29:54.877' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1202, 11, N'Refresh', CAST(N'2025-03-11T22:29:54.877' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1203, 11, N'Generate token', CAST(N'2025-03-11T22:33:28.920' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1204, 11, N'Login', CAST(N'2025-03-11T22:33:28.930' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1205, 11, N'Generate token', CAST(N'2025-03-11T22:33:28.937' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1206, 11, N'Refresh', CAST(N'2025-03-11T22:33:28.940' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1207, 11, N'Generate token', CAST(N'2025-03-19T22:45:47.097' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1208, 11, N'Login', CAST(N'2025-03-19T22:45:47.277' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1209, 11, N'Generate token', CAST(N'2025-03-19T22:45:47.297' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1210, 11, N'Refresh', CAST(N'2025-03-19T22:45:47.303' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1211, 11, N'Generate token', CAST(N'2025-03-19T23:06:13.337' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1212, 11, N'Login', CAST(N'2025-03-19T23:06:13.510' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1213, 11, N'Generate token', CAST(N'2025-03-19T23:06:13.533' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1214, 11, N'Refresh', CAST(N'2025-03-19T23:06:13.537' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1215, 11, N'Generate token', CAST(N'2025-03-20T10:11:06.780' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1216, 11, N'Login', CAST(N'2025-03-20T10:11:06.950' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1217, 11, N'Generate token', CAST(N'2025-03-20T10:11:06.970' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1218, 11, N'Refresh', CAST(N'2025-03-20T10:11:06.973' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1219, 11, N'Generate token', CAST(N'2025-03-20T10:31:47.530' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1220, 11, N'Login', CAST(N'2025-03-20T10:31:47.670' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1221, 11, N'Generate token', CAST(N'2025-03-20T10:31:47.693' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1222, 11, N'Refresh', CAST(N'2025-03-20T10:31:47.703' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1223, 11, N'Generate token', CAST(N'2025-03-20T10:53:44.577' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1224, 11, N'Login', CAST(N'2025-03-20T10:53:44.733' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1225, 11, N'Generate token', CAST(N'2025-03-20T10:53:44.967' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1226, 11, N'Refresh', CAST(N'2025-03-20T10:53:44.977' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1227, 11, N'Generate token', CAST(N'2025-03-22T14:03:16.213' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1228, 11, N'Login', CAST(N'2025-03-22T14:03:16.390' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1229, 11, N'Generate token', CAST(N'2025-03-22T14:04:53.557' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1230, 11, N'Login', CAST(N'2025-03-22T14:04:53.737' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1231, 11, N'Generate token', CAST(N'2025-03-22T14:04:54.010' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1232, 11, N'Refresh', CAST(N'2025-03-22T14:04:54.023' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1233, 11, N'Generate token', CAST(N'2025-03-22T14:11:49.073' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1234, 11, N'Login', CAST(N'2025-03-22T14:11:49.080' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1235, 11, N'Generate token', CAST(N'2025-03-22T14:11:49.123' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1236, 11, N'Refresh', CAST(N'2025-03-22T14:11:49.127' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1237, 11, N'Generate token', CAST(N'2025-03-22T14:12:21.783' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1238, 11, N'Login', CAST(N'2025-03-22T14:12:21.790' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1239, 11, N'Generate token', CAST(N'2025-03-22T14:12:21.813' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1240, 11, N'Refresh', CAST(N'2025-03-22T14:12:21.820' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1241, 11, N'Generate token', CAST(N'2025-03-22T14:14:22.230' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1242, 11, N'Login', CAST(N'2025-03-22T14:14:22.237' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1243, 11, N'Generate token', CAST(N'2025-03-22T14:14:22.273' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1244, 11, N'Refresh', CAST(N'2025-03-22T14:14:22.277' AS DateTime))
GO
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1245, 11, N'Generate token', CAST(N'2025-03-22T14:21:16.427' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1246, 11, N'Login', CAST(N'2025-03-22T14:21:16.437' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1247, 11, N'Generate token', CAST(N'2025-03-22T14:21:16.480' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1248, 11, N'Refresh', CAST(N'2025-03-22T14:21:16.483' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1249, 11, N'Generate token', CAST(N'2025-03-22T14:24:15.883' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1250, 11, N'Login', CAST(N'2025-03-22T14:24:15.890' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1251, 11, N'Generate token', CAST(N'2025-03-22T14:24:15.930' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1252, 11, N'Refresh', CAST(N'2025-03-22T14:24:15.933' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1253, 11, N'Generate token', CAST(N'2025-03-22T14:26:04.377' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1254, 11, N'Login', CAST(N'2025-03-22T14:26:04.547' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1255, 11, N'Generate token', CAST(N'2025-03-22T14:26:04.793' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1256, 11, N'Refresh', CAST(N'2025-03-22T14:26:04.807' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1257, 11, N'Generate token', CAST(N'2025-03-22T14:27:52.970' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1258, 11, N'Login', CAST(N'2025-03-22T14:27:52.980' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1259, 11, N'Generate token', CAST(N'2025-03-22T14:27:53.020' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1260, 11, N'Refresh', CAST(N'2025-03-22T14:27:53.023' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1261, 11, N'Generate token', CAST(N'2025-03-22T14:28:22.153' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1262, 11, N'Login', CAST(N'2025-03-22T14:28:22.163' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1263, 11, N'Generate token', CAST(N'2025-03-22T14:28:22.207' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1264, 11, N'Refresh', CAST(N'2025-03-22T14:28:22.210' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1265, 11, N'Generate token', CAST(N'2025-03-22T14:29:37.363' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1266, 11, N'Login', CAST(N'2025-03-22T14:29:37.370' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1267, 11, N'Generate token', CAST(N'2025-03-22T14:29:37.410' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1268, 11, N'Refresh', CAST(N'2025-03-22T14:29:37.413' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1269, 11, N'Generate token', CAST(N'2025-03-22T15:16:59.000' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1270, 11, N'Login', CAST(N'2025-03-22T15:16:59.017' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1271, 11, N'Generate token', CAST(N'2025-03-22T15:16:59.067' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1272, 11, N'Refresh', CAST(N'2025-03-22T15:16:59.073' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1273, 11, N'Generate token', CAST(N'2025-03-22T19:50:53.203' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1274, 11, N'Login', CAST(N'2025-03-22T19:50:53.387' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1275, 11, N'Generate token', CAST(N'2025-03-22T19:50:53.643' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1276, 11, N'Refresh', CAST(N'2025-03-22T19:50:53.657' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1277, 11, N'Generate token', CAST(N'2025-03-22T19:55:17.560' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1278, 11, N'Refresh', CAST(N'2025-03-22T19:55:17.713' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1279, 11, N'Generate token', CAST(N'2025-03-22T20:06:49.020' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1280, 11, N'Refresh', CAST(N'2025-03-22T20:06:49.170' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1281, 11, N'Generate token', CAST(N'2025-03-22T20:08:36.413' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1282, 11, N'Refresh', CAST(N'2025-03-22T20:08:36.557' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1283, 11, N'Generate token', CAST(N'2025-03-22T20:09:34.843' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1284, 11, N'Refresh', CAST(N'2025-03-22T20:09:34.850' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1303, 11, N'Generate token', CAST(N'2025-03-23T14:52:14.373' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1304, 11, N'Login', CAST(N'2025-03-23T14:52:14.540' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1305, 11, N'Generate token', CAST(N'2025-03-23T14:52:14.783' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1306, 11, N'Refresh', CAST(N'2025-03-23T14:52:14.793' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1307, 11, N'Generate token', CAST(N'2025-03-23T15:46:42.533' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1308, 11, N'Login', CAST(N'2025-03-23T15:46:42.723' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1309, 11, N'Generate token', CAST(N'2025-03-23T15:46:43.013' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1310, 11, N'Refresh', CAST(N'2025-03-23T15:46:43.027' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1311, 11, N'Generate token', CAST(N'2025-03-23T15:48:51.947' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1312, 11, N'Login', CAST(N'2025-03-23T15:48:52.113' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1313, 11, N'Generate token', CAST(N'2025-03-23T15:48:52.357' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1314, 11, N'Refresh', CAST(N'2025-03-23T15:48:52.370' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1315, 11, N'Generate token', CAST(N'2025-03-23T15:49:54.560' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1316, 11, N'Login', CAST(N'2025-03-23T15:49:54.727' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1317, 11, N'Generate token', CAST(N'2025-03-23T15:49:54.983' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1318, 11, N'Refresh', CAST(N'2025-03-23T15:49:54.997' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1319, 11, N'Generate token', CAST(N'2025-03-23T15:57:58.077' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1320, 11, N'Refresh', CAST(N'2025-03-23T15:57:58.080' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1378, 25, N'Registration', CAST(N'2025-03-23T20:41:16.820' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1379, 25, N'Generate token', CAST(N'2025-03-23T20:41:16.977' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1380, 25, N'Login', CAST(N'2025-03-23T20:41:16.983' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1381, 25, N'Update', CAST(N'2025-03-23T20:46:25.147' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1382, 25, N'Generate token', CAST(N'2025-03-23T20:47:17.903' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1383, 25, N'Refresh', CAST(N'2025-03-23T20:47:17.913' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1384, 25, N'Generate token', CAST(N'2025-03-23T20:50:10.680' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1385, 25, N'Refresh', CAST(N'2025-03-23T20:50:10.687' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1386, 25, N'Generate token', CAST(N'2025-03-23T20:58:51.490' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1387, 25, N'Refresh', CAST(N'2025-03-23T20:58:51.497' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1388, 25, N'Generate token', CAST(N'2025-03-23T20:59:44.313' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1389, 25, N'Refresh', CAST(N'2025-03-23T20:59:44.320' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1390, 25, N'Generate token', CAST(N'2025-03-23T21:08:45.140' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1391, 25, N'Refresh', CAST(N'2025-03-23T21:08:45.147' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1392, 25, N'Generate token', CAST(N'2025-03-23T21:30:19.387' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1393, 25, N'Refresh', CAST(N'2025-03-23T21:30:19.390' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1394, 25, N'Generate token', CAST(N'2025-03-23T21:31:25.797' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1395, 25, N'Refresh', CAST(N'2025-03-23T21:31:25.800' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1396, 25, N'Generate token', CAST(N'2025-03-23T21:33:09.260' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1397, 25, N'Refresh', CAST(N'2025-03-23T21:33:09.263' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1398, 25, N'Generate token', CAST(N'2025-03-23T21:34:00.873' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1399, 25, N'Refresh', CAST(N'2025-03-23T21:34:00.877' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1400, 25, N'Generate token', CAST(N'2025-03-23T21:34:49.013' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1401, 25, N'Refresh', CAST(N'2025-03-23T21:34:49.017' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1402, 25, N'Generate token', CAST(N'2025-03-23T21:37:21.673' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1403, 25, N'Refresh', CAST(N'2025-03-23T21:37:21.680' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1404, 25, N'Generate token', CAST(N'2025-03-23T21:38:06.773' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1405, 25, N'Refresh', CAST(N'2025-03-23T21:38:06.780' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1406, 25, N'Generate token', CAST(N'2025-03-23T21:39:49.657' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1407, 25, N'Refresh', CAST(N'2025-03-23T21:39:49.663' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1408, 25, N'Generate token', CAST(N'2025-03-23T21:41:26.567' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1409, 25, N'Refresh', CAST(N'2025-03-23T21:41:26.570' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1410, 25, N'Generate token', CAST(N'2025-03-23T21:41:57.413' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1411, 25, N'Refresh', CAST(N'2025-03-23T21:41:57.417' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1412, 25, N'Generate token', CAST(N'2025-03-23T21:51:14.230' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1413, 25, N'Refresh', CAST(N'2025-03-23T21:51:14.233' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1414, 25, N'Generate token', CAST(N'2025-03-23T21:52:42.457' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1415, 25, N'Refresh', CAST(N'2025-03-23T21:52:42.460' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1416, 25, N'Generate token', CAST(N'2025-03-23T21:54:55.607' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1417, 25, N'Refresh', CAST(N'2025-03-23T21:54:55.610' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1418, 25, N'Generate token', CAST(N'2025-03-23T21:55:56.563' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1419, 25, N'Refresh', CAST(N'2025-03-23T21:55:56.567' AS DateTime))
GO
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1420, 25, N'Generate token', CAST(N'2025-03-23T21:56:31.960' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1421, 25, N'Refresh', CAST(N'2025-03-23T21:56:31.963' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1422, 25, N'Generate token', CAST(N'2025-03-23T21:58:29.080' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1423, 25, N'Refresh', CAST(N'2025-03-23T21:58:29.083' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1424, 25, N'Generate token', CAST(N'2025-03-23T21:59:54.003' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1425, 25, N'Refresh', CAST(N'2025-03-23T21:59:54.007' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1426, 25, N'Generate token', CAST(N'2025-03-23T22:00:41.940' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1427, 25, N'Refresh', CAST(N'2025-03-23T22:00:41.943' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1428, 25, N'Generate token', CAST(N'2025-03-23T22:09:03.337' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1429, 25, N'Refresh', CAST(N'2025-03-23T22:09:03.337' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1430, 25, N'Generate token', CAST(N'2025-03-23T22:11:39.267' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1431, 25, N'Refresh', CAST(N'2025-03-23T22:11:39.270' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1432, 25, N'Generate token', CAST(N'2025-03-23T22:17:28.623' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1433, 25, N'Refresh', CAST(N'2025-03-23T22:17:28.627' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1434, 25, N'Generate token', CAST(N'2025-03-23T22:38:24.637' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1435, 25, N'Refresh', CAST(N'2025-03-23T22:38:24.640' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1436, 25, N'Generate token', CAST(N'2025-03-23T22:49:55.747' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1437, 25, N'Refresh', CAST(N'2025-03-23T22:49:55.750' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1438, 25, N'Generate token', CAST(N'2025-03-23T22:50:17.630' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1439, 25, N'Refresh', CAST(N'2025-03-23T22:50:17.637' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1440, 25, N'Generate token', CAST(N'2025-03-23T22:50:48.750' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1441, 25, N'Refresh', CAST(N'2025-03-23T22:50:48.753' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1442, 11, N'Generate token', CAST(N'2025-03-23T23:06:00.557' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1443, 11, N'Login', CAST(N'2025-03-23T23:06:00.717' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1444, 11, N'Generate token', CAST(N'2025-03-23T23:06:28.167' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1445, 11, N'Refresh', CAST(N'2025-03-23T23:06:28.193' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1446, 11, N'Generate token', CAST(N'2025-03-23T23:26:38.340' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1447, 11, N'Refresh', CAST(N'2025-03-23T23:26:38.347' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1448, 11, N'Generate token', CAST(N'2025-03-23T23:27:03.227' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1449, 11, N'Refresh', CAST(N'2025-03-23T23:27:03.230' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1450, 11, N'Generate token', CAST(N'2025-03-23T23:34:44.497' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1451, 11, N'Refresh', CAST(N'2025-03-23T23:34:44.503' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1452, 11, N'Generate token', CAST(N'2025-03-23T23:43:19.583' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1453, 11, N'Refresh', CAST(N'2025-03-23T23:43:19.587' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1454, 11, N'Generate token', CAST(N'2025-03-23T23:45:12.220' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1455, 11, N'Refresh', CAST(N'2025-03-23T23:45:12.223' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1456, 11, N'Generate token', CAST(N'2025-03-23T23:45:57.500' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1457, 11, N'Refresh', CAST(N'2025-03-23T23:45:57.503' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1458, 11, N'Generate token', CAST(N'2025-03-23T23:47:56.987' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1459, 11, N'Refresh', CAST(N'2025-03-23T23:47:56.990' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1460, 11, N'Generate token', CAST(N'2025-03-23T23:52:51.817' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1461, 11, N'Refresh', CAST(N'2025-03-23T23:52:51.823' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1462, 11, N'Generate token', CAST(N'2025-03-23T23:53:38.427' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1463, 11, N'Refresh', CAST(N'2025-03-23T23:53:38.433' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1464, 11, N'Generate token', CAST(N'2025-03-23T23:54:18.077' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1465, 11, N'Refresh', CAST(N'2025-03-23T23:54:18.083' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1466, 11, N'Generate token', CAST(N'2025-03-23T23:54:28.517' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1467, 11, N'Refresh', CAST(N'2025-03-23T23:54:28.520' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1468, 11, N'Generate token', CAST(N'2025-03-23T23:54:44.117' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1469, 11, N'Refresh', CAST(N'2025-03-23T23:54:44.120' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1470, 11, N'Generate token', CAST(N'2025-03-23T23:55:02.077' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1471, 11, N'Refresh', CAST(N'2025-03-23T23:55:02.080' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1472, 11, N'Generate token', CAST(N'2025-03-23T23:57:59.850' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1473, 11, N'Refresh', CAST(N'2025-03-23T23:57:59.853' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1474, 11, N'Generate token', CAST(N'2025-03-24T00:19:39.420' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1475, 11, N'Refresh', CAST(N'2025-03-24T00:19:39.423' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1476, 11, N'Generate token', CAST(N'2025-03-24T00:20:08.517' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1477, 11, N'Refresh', CAST(N'2025-03-24T00:20:08.520' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1478, 11, N'Generate token', CAST(N'2025-03-24T00:24:04.577' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1479, 11, N'Refresh', CAST(N'2025-03-24T00:24:04.580' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1480, 11, N'Generate token', CAST(N'2025-03-24T00:24:26.900' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1481, 11, N'Refresh', CAST(N'2025-03-24T00:24:26.903' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1482, 11, N'Generate token', CAST(N'2025-03-24T00:26:08.360' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1483, 11, N'Refresh', CAST(N'2025-03-24T00:26:08.363' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1484, 11, N'Generate token', CAST(N'2025-03-24T00:27:56.153' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1485, 11, N'Refresh', CAST(N'2025-03-24T00:27:56.157' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1486, 11, N'Generate token', CAST(N'2025-03-24T00:28:27.803' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1487, 11, N'Refresh', CAST(N'2025-03-24T00:28:27.810' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1488, 11, N'Generate token', CAST(N'2025-03-24T00:28:57.950' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1489, 11, N'Refresh', CAST(N'2025-03-24T00:28:57.953' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1490, 11, N'Generate token', CAST(N'2025-03-24T00:29:27.470' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1491, 11, N'Refresh', CAST(N'2025-03-24T00:29:27.477' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1492, 11, N'Generate token', CAST(N'2025-03-24T00:34:09.970' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1493, 11, N'Login', CAST(N'2025-03-24T00:34:10.133' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1494, 25, N'Generate token', CAST(N'2025-03-24T00:34:58.003' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1495, 25, N'Login', CAST(N'2025-03-24T00:34:58.013' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1496, 25, N'Generate token', CAST(N'2025-03-24T00:34:58.193' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1497, 25, N'Refresh', CAST(N'2025-03-24T00:34:58.197' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1498, 25, N'Generate token', CAST(N'2025-03-24T01:06:04.897' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1499, 25, N'Login', CAST(N'2025-03-24T01:06:04.903' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1500, 25, N'Generate token', CAST(N'2025-03-24T01:06:28.413' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1501, 25, N'Login', CAST(N'2025-03-24T01:06:28.420' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1502, 25, N'Generate token', CAST(N'2025-03-24T01:07:18.830' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1503, 25, N'Refresh', CAST(N'2025-03-24T01:07:18.833' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1504, 25, N'Generate token', CAST(N'2025-03-24T01:07:59.317' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1505, 25, N'Refresh', CAST(N'2025-03-24T01:07:59.323' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1506, 25, N'Generate token', CAST(N'2025-03-24T01:10:33.040' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1507, 25, N'Refresh', CAST(N'2025-03-24T01:10:33.043' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1508, 25, N'Generate token', CAST(N'2025-03-24T01:11:06.490' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1509, 25, N'Refresh', CAST(N'2025-03-24T01:11:06.493' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1510, 25, N'Generate token', CAST(N'2025-03-24T01:13:22.993' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1511, 25, N'Refresh', CAST(N'2025-03-24T01:13:22.997' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1512, 25, N'Generate token', CAST(N'2025-03-24T01:14:09.067' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1513, 25, N'Login', CAST(N'2025-03-24T01:14:09.073' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1514, 25, N'Generate token', CAST(N'2025-03-24T01:15:03.403' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1515, 25, N'Refresh', CAST(N'2025-03-24T01:15:03.410' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1516, 25, N'Generate token', CAST(N'2025-03-24T01:15:17.517' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1517, 25, N'Refresh', CAST(N'2025-03-24T01:15:17.520' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1518, 25, N'Generate token', CAST(N'2025-03-24T01:16:01.307' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1519, 25, N'Login', CAST(N'2025-03-24T01:16:01.313' AS DateTime))
GO
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1520, 25, N'Generate token', CAST(N'2025-03-24T01:18:46.173' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1521, 25, N'Refresh', CAST(N'2025-03-24T01:18:46.180' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1522, 25, N'Generate token', CAST(N'2025-03-24T01:24:10.410' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1523, 25, N'Refresh', CAST(N'2025-03-24T01:24:10.413' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1524, 25, N'Generate token', CAST(N'2025-03-24T01:27:19.017' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1525, 25, N'Refresh', CAST(N'2025-03-24T01:27:19.020' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1526, 25, N'Generate token', CAST(N'2025-03-24T01:30:17.267' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1527, 25, N'Refresh', CAST(N'2025-03-24T01:30:17.280' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1528, 11, N'Generate token', CAST(N'2025-03-24T01:31:48.797' AS DateTime))
INSERT [dbo].[Logs] ([id], [id_user], [action], [created_at]) VALUES (1529, 11, N'Login', CAST(N'2025-03-24T01:31:48.807' AS DateTime))
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [name]) VALUES (1, N'User')
INSERT [dbo].[Roles] ([id], [name]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (1, N'user1', N'Описание пользователя 1', N'images\users\default-avatar.png', N'Иван Иванов', N'user1@example.com', N'hashed_password_1', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (3, N'user3', N'Описание пользователя 3', N'images\users\default-avatar.png', N'Алексей Сидоров', N'user3@example.com', N'hashed_password_3', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (4, N'user4', N'Описание пользователя 4', N'images\users\default-avatar.png', N'Екатерина Кузнецова', N'user4@example.com', N'hashed_password_4', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (5, N'user5', N'Описание пользователя 5', N'images\users\default-avatar.png', N'Дмитрий Морозов', N'user5@example.com', N'hashed_password_5', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (6, N'user6', N'Описание пользователя 6', N'images\users\default-avatar.png', N'Анна Смирнова', N'user6@example.com', N'hashed_password_6', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (7, N'user7', N'Описание пользователя 7', N'images\users\default-avatar.png', N'Сергей Ковалев', N'user7@example.com', N'hashed_password_7', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (8, N'user8', N'Описание пользователя 8', N'images\users\default-avatar.png', N'Ольга Федорова', N'user8@example.com', N'hashed_password_8', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (9, N'user9', N'Описание пользователя 9', N'images\users\default-avatar.png', N'Николай Лебедев', N'user9@example.com', N'hashed_password_9', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (10, N'user10', N'Описание пользователя 10', N'images\users\default-avatar.png', N'Татьяна Николаева', N'user10@example.com', N'hashed_password_10', 1, 0, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (11, N'admin', NULL, N'images\users\default-avatar.png', N'vasya', N'fdf', N'AQAAAAIAAYagAAAAEL1KFs7oMZA26EWKbl26lP3I52+q1ez6BWe+ySGsy31U4Wx+yogj3WMi7K/GWKLJeA==', 2, 0, CAST(N'2025-02-05T11:02:21.107' AS DateTime))
INSERT [dbo].[Users] ([id], [nickname], [description], [avatar_image_path], [name], [email], [password_hash], [id_role], [is_banned], [created_at]) VALUES (25, N'vasya', N'Описание', N'images\users\user-id25.png', N'Василий', N'vasya.domakov@mail.ru', N'AQAAAAIAAYagAAAAEBz06UTnGNJt/BTCQbJwxXfEd/HLNrkXZ/9ME4D7kA2/mgaTaSvq3M3hu01ibbyurQ==', 1, 0, CAST(N'2025-03-23T20:41:16.810' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserSessions] ON 

INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (1, 1, N'token_hash_1', N'Mobile', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (3, 3, N'token_hash_3', N'Tablet', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (4, 4, N'token_hash_4', N'Mobile', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (5, 5, N'token_hash_5', N'Desktop', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (6, 6, N'token_hash_6', N'Tablet', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (7, 7, N'token_hash_7', N'Mobile', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (8, 8, N'token_hash_8', N'Desktop', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (9, 9, N'token_hash_9', N'Tablet', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (10, 10, N'token_hash_10', N'Mobile', CAST(N'2025-02-12T13:58:36.563' AS DateTime), CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (11, 11, N'B7Z7uUjaKpz59eFfXSpL3i/AtTd27NxH5/Xz9JhJoS8=', N'swagger', CAST(N'2025-07-05T11:02:44.083' AS DateTime), CAST(N'2025-02-05T11:02:44.083' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (12, 11, N'fyr8TjpfNP6iM8O3GdLCGM2Xej02VP40KYQdndQ3Ecw=', N'string', CAST(N'2025-02-21T22:58:52.800' AS DateTime), CAST(N'2025-02-06T22:58:52.800' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (27, 11, N'gZLkZU0dktxTR44nLZCY1/EniyFXhiqIHdT8tvfnY/c=', N'web', CAST(N'2025-08-08T20:30:26.153' AS DateTime), CAST(N'2025-03-11T20:30:26.153' AS DateTime))
INSERT [dbo].[UserSessions] ([id], [id_user], [refresh_token_hash], [device_type], [expires_in], [created_at]) VALUES (48, 11, N'BZc8ludLpAkaJZvLLHrOtXW5RXjMw/164sOq2aO4obA=', N'desktop', CAST(N'2025-08-21T01:31:48.810' AS DateTime), CAST(N'2025-03-24T01:31:48.810' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserSessions] OFF
GO
SET IDENTITY_INSERT [dbo].[UserSubscribers] ON 

INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (6, 3, 4, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (7, 4, 5, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (8, 5, 6, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (9, 6, 7, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (10, 7, 8, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (11, 8, 9, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (12, 9, 10, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (13, 10, 1, CAST(N'2025-02-05T13:58:36.563' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (16, 1, 10, CAST(N'2025-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[UserSubscribers] ([id], [id_author], [id_subscriber], [created_at]) VALUES (18, 1, 25, CAST(N'2025-02-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserSubscribers] OFF
GO
SET IDENTITY_INSERT [dbo].[СonfirmationСodes] ON 

INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (1, N'123456', N'user1@example.com', CAST(N'2025-02-05T14:58:36.563' AS DateTime))
INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (2, N'234567', N'user2@example.com', CAST(N'2025-02-05T14:58:36.563' AS DateTime))
INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (3, N'345678', N'user3@example.com', CAST(N'2025-02-05T14:58:36.563' AS DateTime))
INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (4, N'456789', N'user4@example.com', CAST(N'2025-02-05T14:58:36.563' AS DateTime))
INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (5, N'567890', N'user5@example.com', CAST(N'2025-02-05T14:58:36.563' AS DateTime))
INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (24, N'945944', N'neponal.vasya@vk.com', CAST(N'2025-02-08T19:23:13.573' AS DateTime))
INSERT [dbo].[СonfirmationСodes] ([id], [code], [email], [expires_in]) VALUES (25, N'187567', N'fomindanya61@gmail.com', CAST(N'2025-02-08T19:23:25.037' AS DateTime))
SET IDENTITY_INSERT [dbo].[СonfirmationСodes] OFF
GO
ALTER TABLE [dbo].[Libraries] ADD  CONSTRAINT [DF_Libraries_progress_page]  DEFAULT ((0)) FOR [progress_page]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_avatar_image_path]  DEFAULT (N'images\users\default-avatar.png') FOR [avatar_image_path]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_id_role]  DEFAULT ((1)) FOR [id_role]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_is_banned]  DEFAULT ((0)) FOR [is_banned]
GO
ALTER TABLE [dbo].[BannedUsers]  WITH CHECK ADD  CONSTRAINT [FK_BannedUsers_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BannedUsers] CHECK CONSTRAINT [FK_BannedUsers_Users]
GO
ALTER TABLE [dbo].[Bookmarks]  WITH CHECK ADD  CONSTRAINT [FK_Bookmarks_Libraries] FOREIGN KEY([id_library])
REFERENCES [dbo].[Libraries] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookmarks] CHECK CONSTRAINT [FK_Bookmarks_Libraries]
GO
ALTER TABLE [dbo].[BookReviews]  WITH CHECK ADD  CONSTRAINT [FK_BookReviews_Books1] FOREIGN KEY([id_book])
REFERENCES [dbo].[Books] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookReviews] CHECK CONSTRAINT [FK_BookReviews_Books1]
GO
ALTER TABLE [dbo].[BookReviews]  WITH CHECK ADD  CONSTRAINT [FK_BookReviews_Users] FOREIGN KEY([id_author])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[BookReviews] CHECK CONSTRAINT [FK_BookReviews_Users]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([id_genre])
REFERENCES [dbo].[Genres] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Users] FOREIGN KEY([id_author])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Users]
GO
ALTER TABLE [dbo].[Libraries]  WITH CHECK ADD  CONSTRAINT [FK_Libraries_Books] FOREIGN KEY([id_book])
REFERENCES [dbo].[Books] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Libraries] CHECK CONSTRAINT [FK_Libraries_Books]
GO
ALTER TABLE [dbo].[Libraries]  WITH CHECK ADD  CONSTRAINT [FK_Libraries_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Libraries] CHECK CONSTRAINT [FK_Libraries_Users]
GO
ALTER TABLE [dbo].[LikesReviews]  WITH CHECK ADD  CONSTRAINT [FK_LikesReviews_BookReviews] FOREIGN KEY([id_review])
REFERENCES [dbo].[BookReviews] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LikesReviews] CHECK CONSTRAINT [FK_LikesReviews_BookReviews]
GO
ALTER TABLE [dbo].[LikesReviews]  WITH CHECK ADD  CONSTRAINT [FK_LikesReviews_Users] FOREIGN KEY([id_author])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[LikesReviews] CHECK CONSTRAINT [FK_LikesReviews_Users]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([id_role])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[UserSessions]  WITH CHECK ADD  CONSTRAINT [FK_UserSessions_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSessions] CHECK CONSTRAINT [FK_UserSessions_Users]
GO
ALTER TABLE [dbo].[UserSubscribers]  WITH CHECK ADD  CONSTRAINT [FK_UserSubscribers_Users] FOREIGN KEY([id_author])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserSubscribers] CHECK CONSTRAINT [FK_UserSubscribers_Users]
GO
ALTER TABLE [dbo].[UserSubscribers]  WITH CHECK ADD  CONSTRAINT [FK_UserSubscribers_Users1] FOREIGN KEY([id_subscriber])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserSubscribers] CHECK CONSTRAINT [FK_UserSubscribers_Users1]
GO
