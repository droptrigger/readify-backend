using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLibrary.Entities;

public partial class UpdatesLibraries
{
    public int Id { get; set; }

    public int IdLibrary { get; set; }

    public string Action { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Library IdLibraryNavigation { get; set; } = null!;
}