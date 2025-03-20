using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int PageQuantity { get; set; }

    public int IdAuthor { get; set; }

    public string CoverImagePath { get; set; } = null!;

    public string FileBookPath { get; set; } = null!;

    public int? IdGenre { get; set; } = null;

    public bool IsPrivate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual User IdAuthorNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();
}
