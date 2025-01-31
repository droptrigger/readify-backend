using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class Bookmark
{
    public int Id { get; set; }

    public int IdLibrary { get; set; }

    public int Page { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Library IdLibraryNavigation { get; set; } = null!;
}
