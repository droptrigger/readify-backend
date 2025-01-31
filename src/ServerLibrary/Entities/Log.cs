using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class Log
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Action { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
