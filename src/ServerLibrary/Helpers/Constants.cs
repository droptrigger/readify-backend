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

        public static string? Subscribe { get; } = "Subscribe on ";
        public static string? UnSubscribe { get; } = "Unsubscribe by ";

        public static string? DeleteUser { get; } = "Was deleted";
        public static string? Ban { get; } = "Was banned";
        public static string? Unban { get; } = "Was unblocked";

        public static string? AddLibrary { get; } = "Added a book to the library. Book id: ";
        public static string? DeleteLibrary { get; } = "Deleted a book to the library. Book id: ";

        public static string? PathBookFiles { get; } = @"images\books\files\";
        public static string? PathBookImages { get; } = @"images\books\covers\";

        public static string? PathToBookFiles { get; } = @"..\Server\wwwroot\images\books\files\";
        public static string? PathToBookImages { get; } = @"..\Server\wwwroot\images\books\covers\";

        public static string? PathUserImages { get; } = @"images\users\"; 
        public static string? PathToUserAvatar { get; } = @"..\Server\wwwroot\images\users\";

        public static string? DefaultAvatar { get; } = @"images\users\default-cover.png";
        public static string? DefaultBookImage { get; } = @"images\books\covers\default-avatar.png";

        public static string? HtmlMailTemplate { get; } = @"
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
