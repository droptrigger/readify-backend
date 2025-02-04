namespace ServerLibrary.Helpers
{
    public class JwtSection
    {
        public string? SecretKey { get; set; }
        public TimeSpan Expires { get; set; }
    }
}
