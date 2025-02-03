namespace ServerLibrary.Helpers.Exceptions.User
{
    public class EmailIsBusyException : Exception
    {
        public EmailIsBusyException(string message) : base(message) { }
    }
}
