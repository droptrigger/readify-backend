using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    /// <summary>
    /// Конвертер для получения <see cref="UserDTO"/> из <see cref="User"/>
    /// </summary>
    public static class ConvertToUserDTO
    {
        /// <summary>
        /// Метод конвертации
        /// </summary>
        /// <param name="user">Экземпляр класса <see cref="User"/></param>
        /// <param name="includeNestedCollections">Булевый параметр для предотвращения рекурсии</param>
        /// <returns></returns>
        public static async Task<UserDTO> Convert(User user)
        {
            if (user == null)
                return null!;

            List<Book> books = user.Books.ToList();

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Description = user.Description,
                Name = user.Name,
                Email = user.Email,
                IdRole = user.IdRole,
                IsBanned = user.IsBanned,
                CreatedAt = user.CreatedAt,
                AvatarImage = await GetBytes.GetArray(Constants.PathToUserAvatarForBytes + user.AvatarImagePath),
                Books = (await Task.WhenAll(user.Libraries.Select(ConvertToLibraryDTO.Convert)))
                    .OrderByDescending(lib => lib.Book?.Author?.Id == user.Id).ToList(),
                Reviews = (await Task.WhenAll(user.BookReviews.Select(ConvertToSeeReviewDTO.Convert).ToList())).ToList(),
                Subscribers = (await Task.WhenAll(
                    user.UserSubscriberIdAuthorNavigations.Select(async s =>
                        await ConvertToAuthorDTO.Convert(s.IdSubscriberNavigation)
                    )
                )).ToList(),
                Subscriptions = (await Task.WhenAll(
                    user.UserSubscriberIdSubscriberNavigations.Select(async s =>
                        await ConvertToAuthorDTO.Convert(s.IdAuthorNavigation)
                    )
                )).ToList()
            };

            return userDTO;
        } 
    }
}