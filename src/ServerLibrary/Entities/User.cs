using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string? Description { get; set; }

    public string AvatarImagePath { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int IdRole { get; set; }

    public bool IsBanned { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<BannedUser> BannedUsers { get; set; } = new List<BannedUser>();

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();

    public virtual ICollection<LikesReview> LikesReviews { get; set; } = new List<LikesReview>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();

    public virtual ICollection<UserSubscriber> UserSubscriberIdAuthorNavigations { get; set; } = new List<UserSubscriber>();

    public virtual ICollection<UserSubscriber> UserSubscriberIdSubscriberNavigations { get; set; } = new List<UserSubscriber>();
}
