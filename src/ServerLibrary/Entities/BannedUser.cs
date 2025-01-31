using System;
using System.Collections.Generic;

namespace HelpLibrary;

public partial class BannedUser
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string? BanReason { get; set; }

    public DateTime BannedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
