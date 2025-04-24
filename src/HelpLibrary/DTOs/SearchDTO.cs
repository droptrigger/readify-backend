using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Users;

namespace HelpLibrary.DTOs
{
    public class SearchDTO
    {
        /// <summary>
        /// Поисковой запрос
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Найденные книги
        /// </summary>
        public List<SeeBookDTO>? FoundBooks { get; set; }

        /// <summary>
        /// Найденные пользователи
        /// </summary>
        public List<AuthorDTO>? FoundUsers { get; set; }
    }
}
