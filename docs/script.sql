USE [master]
GO
/****** Object:  Database [Readify]    Script Date: 05.02.2025 14:04:48 ******/
CREATE DATABASE [Readify]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Readify', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Readify.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Readify_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Readify_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Readify] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Readify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Readify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Readify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Readify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Readify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Readify] SET ARITHABORT OFF 
GO
ALTER DATABASE [Readify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Readify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Readify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Readify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Readify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Readify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Readify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Readify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Readify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Readify] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Readify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Readify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Readify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Readify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Readify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Readify] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Readify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Readify] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Readify] SET  MULTI_USER 
GO
ALTER DATABASE [Readify] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Readify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Readify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Readify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Readify] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Readify] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Readify] SET QUERY_STORE = ON
GO
ALTER DATABASE [Readify] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Readify]
GO
/****** Object:  Table [dbo].[BannedUsers]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[Bookmarks]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[BookReviews]    Script Date: 05.02.2025 14:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReviews](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_author] [int] NOT NULL,
	[id_book] [int] NOT NULL,
	[comment] [nvarchar](500) NOT NULL,
	[rating] [tinyint] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_BookReviews] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 05.02.2025 14:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[id_author] [int] NOT NULL,
	[cover_image_path] [nvarchar](250) NOT NULL,
	[file_book_path] [nvarchar](200) NOT NULL,
	[id_genre] [int] NULL,
	[is_private] [bit] NOT NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[Libraries]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[LikesReviews]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[Logs]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 05.02.2025 14:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nickname] [nvarchar](50) NOT NULL,
	[description] [nvarchar](150) NULL,
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
/****** Object:  Table [dbo].[UserSessions]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[UserSubscribers]    Script Date: 05.02.2025 14:04:48 ******/
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
/****** Object:  Table [dbo].[СonfirmationСodes]    Script Date: 05.02.2025 14:04:48 ******/
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
USE [master]
GO
ALTER DATABASE [Readify] SET  READ_WRITE 
GO
