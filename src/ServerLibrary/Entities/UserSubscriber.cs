using System;
using System.Collections.Generic;

namespace HelpLibrary.Entities;

public partial class UserSubscriber
{
    public int Id { get; set; }

    public int IdAuthor { get; set; }

    public int IdSubscriber { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User IdAuthorNavigation { get; set; } = null!;

    public virtual User IdSubscriberNavigation { get; set; } = null!;
}
