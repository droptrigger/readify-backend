using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    public static class ConvertToAuthorDTO
    {
        /// <summary>
        /// Метод конвертации
        /// </summary>
        /// <param name="user">Экземпляр класса <see cref="AuthorDTO"/></param>
        /// <param name="includeNestedCollections">Булевый параметр для предотвращения рекурсии</param>
        /// <returns>Экземпляр класса <see cref="AuthorDTO"/></returns>
        public static async Task<AuthorDTO> Convert(User user)
        {
            if (user == null)
                return null!;

            var authorDTO = new AuthorDTO
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Name = user.Name,
                AvatarImage = await GetBytes.GetArray(Constants.PathToUserAvatarForBytes + user.AvatarImagePath),
                Description = user.Description
            };

            return authorDTO;
        }
    }
}
