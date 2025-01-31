using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class UserSession
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Refresh { get; set; } = null!;

    public DateTime ExpiresIn { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
