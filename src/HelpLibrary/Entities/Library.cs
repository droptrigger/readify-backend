using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class Library
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdBook { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ProgressPage { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
