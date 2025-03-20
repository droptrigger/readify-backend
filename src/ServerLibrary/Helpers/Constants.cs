namespace ServerLibrary.Helpers
{
    public class Constants
    {

        public static readonly Dictionary<int, string> Roles = new Dictionary<int, string>
        {
            { 1, "user" },
            { 2, "admin" }
        };

        public const string? Register = "Registration";
        public const string? Login = "Login";
        public const string? Update = "Update";
        public const string? Refresh = "Refresh";
        public const string? GenerateToken = "Generate token";

        public const string? Subscribe = "Subscribe on ";
        public const string? UnSubscribe = "Unsubscribe by ";

        public const string? DeleteUser = "Was deleted";
        public const string? Ban = "Was banned";
        public const string? Unban = "Was unblocked";

        public const string? AddLibrary = "Added a book to the library. Book id: ";
        public const string? DeleteLibrary = "Deleted a book to the library. Book id: ";

        public const string? PathBookFiles = @"images\books\files\";
        public const string? PathBookImages = @"images\books\covers\";
        public const string? PathToBookImagesForBytes = @"..\Server\wwwroot\";

        public const string? PathToBookFiles = @"..\Server\wwwroot\images\books\files\";
        public const string? PathToBookImages = @"..\Server\wwwroot\images\books\covers\";

        public const string? PathUserImages = @"images\users\"; 
        public const string? PathToUserAvatar = @"..\Server\wwwroot\images\users\";
        public const string? PathToUserAvatarForBytes = @"..\Server\wwwroot\";

        public static string DefaultAvatar { get; } = @"images\users\default-cover.png";
        public const string? DefaultBookImage = @"images\books\covers\default-avatar.png";

        public const string? HtmlMailTemplate = @"
                                            <!DOCTYPE html>
                                            <html lang=""en"">
                                            <head>
                                                <meta charset=""UTF-8"">
                                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                                <title>Email Verification</title>
                                                <style>
                                                    body, h1, h2, p {
	                                                    margin: 0;
	                                                    padding: 0;
	                                                    background: #F8F8F8;
                                                    }

                                                    .container {
	                                                    font-family: Arial, sans-serif;
	                                                    max-width: 800px;
	                                                    margin: 50px auto;
	                                                    padding: 50px;
	                                                    border: 1px solid #eaeaea;
	                                                    border-radius: 10px;
	                                                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
	                                                    background: white;
                                                    }

                                                    h1 {
	                                                    font-size: 28px;
	                                                    margin: 20px 0;
	                                                    background: white;
                                                    }

                                                    p {
	                                                    font-size: 16px;
	                                                    line-height: 1.5;
	                                                    margin-bottom: 20px;
	                                                    background: white;
                                                    }

                                                    h2 {
	                                                    font-size: 37px;
	                                                    font-weight: normal;
	                                                    margin-bottom: 30px;
	                                                    margin-top: 30px;
	                                                    background: white;
                                                    }

                                                    .divider {
	                                                    height: 1px;
	                                                    background-color: #eaeaea;
	                                                    margin-bottom: 20px;
                                                    }
                                                </style>
                                            </head>
                                            <body>
                                                <div class=""container"">
                                                    <h1>Подтвердите адрес электронной почты</h1>
                                                    <p>Нам необходимо подтвердить ваш адрес электронной почты <a href=""#"">{email}</a> прежде чем вы сможете получить доступ к своей учетной записи. Введите приведенный ниже код.</p>
                                                    <h2>{code}</h2>
                                                    <div class=""divider""></div>
                                                    <p>Срок действия этого кода истекает через 10 минут.</p>
                                                    <p>Если вы не регистрировались на Readify, вы можете спокойно проигнорировать это электронное письмо. Возможно, кто-то другой ввел ваш адрес электронной почты по ошибке.</p>
                                                </div>
                                            </body>
                                            </html>";
    }
}
