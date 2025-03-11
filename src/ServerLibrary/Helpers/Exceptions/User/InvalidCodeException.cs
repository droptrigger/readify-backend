namespace ServerLibrary.Helpers.Exceptions.User
{
    public class InvalidCodeException : Exception
    {
        public InvalidCodeException(string? message) : base(message)
        {
        }
    }
}
