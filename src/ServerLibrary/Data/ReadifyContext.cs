using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data;

public partial class ReadifyContext : DbContext
{
    public ReadifyContext()
    {
    }

    public ReadifyContext(DbContextOptions<ReadifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BannedUser> BannedUsers { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookReview> BookReviews { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<UpdatesLibraries> UpdatesLibraries { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<СonfirmationСode> СonfirmationСodes { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<LikesReview> LikesReviews { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    public virtual DbSet<UserSubscriber> UserSubscribers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Readify;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BannedUser>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BanReason)
                .HasMaxLength(200)
                .HasColumnName("ban_reason");
            entity.Property(e => e.BannedAt)
                .HasColumnType("datetime")
                .HasColumnName("banned_at");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BannedUsers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BannedUsers_Users");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoverImagePath)
                .HasMaxLength(250)
                .HasColumnName("cover_image_path");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.PageQuantity).HasColumnName("page_quantity");
            entity.Property(e => e.FileBookPath)
                .HasMaxLength(200)
                .HasColumnName("file_book_path");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.IsPrivate).HasColumnName("is_private");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Users");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Categories");
        });

        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookReviews_Users");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookReviews_Books1");
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdLibrary).HasColumnName("id_library");
            entity.Property(e => e.Page).HasColumnName("page");

            entity.HasOne(d => d.IdLibraryNavigation).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.IdLibrary)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookmarks_Libraries");
        });

        modelBuilder.Entity<UpdatesLibraries>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdLibrary).HasColumnName("id_library");

            entity.HasOne(d => d.IdLibraryNavigation).WithMany(p => p.UpdatesLibrary)
                .HasForeignKey(d => d.IdLibrary)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UpdatesLibraries_Libraries");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<СonfirmationСode>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(6)
                .HasColumnName("code");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.ExpiresIn)
                .HasColumnType("datetime")
                .HasColumnName("expires_in");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.ProgressPage).HasColumnName("progress_page");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libraries_Books");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libraries_Users");
        });

        modelBuilder.Entity<LikesReview>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdReview).HasColumnName("id_review");
            entity.Property(e => e.ReactionType).HasColumnName("reaction_type");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.LikesReviews)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LikesReviews_Users");

            entity.HasOne(d => d.IdReviewNavigation).WithMany(p => p.LikesReviews)
                .HasForeignKey(d => d.IdReview)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LikesReviews_BookReviews");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(200)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Logs_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarImagePath)
                .HasMaxLength(255)
                .HasDefaultValueSql("(N'default-avatar.png')")
                .HasColumnName("avatar_image_path");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IdRole)
                .HasDefaultValueSql("((1))")
                .HasColumnName("id_role");
            entity.Property(e => e.IsBanned).HasColumnName("is_banned");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .HasColumnName("nickname");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<UserSession>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.RefreshTokenHash)
                .HasMaxLength(255)
                .HasColumnName("refresh_token_hash");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(50)
                .HasColumnName("device_type");
            entity.Property(e => e.ExpiresIn)
                .HasColumnType("datetime")
                .HasColumnName("expires_in");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserSessions)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSessions_Users");
        });

        modelBuilder.Entity<UserSubscriber>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdSubscriber).HasColumnName("id_subscriber");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.UserSubscriberIdAuthorNavigations)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSubscribers_Users");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.UserSubscriberIdSubscriberNavigations)
                .HasForeignKey(d => d.IdSubscriber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSubscribers_Users1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
