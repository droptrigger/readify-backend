using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class BookReview
{
    public int Id { get; set; }

    public int IdAuthor { get; set; }

    public int IdBook { get; set; }

    public string Comment { get; set; } = null!;

    public byte Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User IdAuthorNavigation { get; set; } = null!;

    public virtual Book IdBookNavigation { get; set; } = null!;
}
