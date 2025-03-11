using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class LikesReview
{
    public int Id { get; set; }

    public int IdAuthor { get; set; }

    public int IdReview { get; set; }

    public byte ReactionType { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User IdAuthorNavigation { get; set; } = null!;

    public virtual BookReview IdReviewNavigation { get; set; } = null!;
}
