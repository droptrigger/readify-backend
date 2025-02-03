namespace ServerLibrary.Helpers.Exceptions.User
{
    public class NicknameIsBusyException : Exception
    {
        public NicknameIsBusyException(string message) : base(message) { }
    }
}
