namespace ServerLibrary.Helpers.Exceptions.User
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException(string? message) : base(message)
        {
        }
    }
}
