namespace ServerLibrary.Helpers
{
    public class Constants
    {

        public static readonly Dictionary<int, string> Roles = new Dictionary<int, string>
        {
            { 1, "user" },
            { 2, "admin" }
        };

        public static string? Register { get; } = "Registration";
        public static string? Login { get; } = "Login";
        public static string? Update { get; } = "Update";
        public static string? Refresh { get; } = "Refresh";
        public static string? GenerateToken { get; } = "Generate token";
        public static string? PathToUserAvatar { get; } = @"..\Server\wwwroot\images\users\";
        public static string? DefaultAvatar { get; } = @"..\Server\wwwroot\images\users\default.png";
    }
}
