namespace HelpLibrary.Entities;

public partial class СonfirmationСode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime ExpiresIn { get; set; }
}

