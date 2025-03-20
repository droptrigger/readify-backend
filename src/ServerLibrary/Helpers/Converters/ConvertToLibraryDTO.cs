using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    /// <summary>
    /// Конвертер для получения <see cref="LibraryDTO"/> из <see cref="Library"/>
    /// </summary>
    public static class ConvertToLibraryDTO
    {
        /// <summary>
        /// Метод получения <see cref="LibraryDTO"/> из <see cref="Library"/>
        /// </summary>
        /// <param name="library">Экземпляр класса <see cref="Library"/></param>
        /// <returns>Экземпляр класса <see cref="LibraryDTO"/></returns>
        public async static Task<LibraryDTO> Convert(Library library)
        {
            if (library == null)
                return null!;

            return new LibraryDTO
            {
                Id = library.Id,
                IdUser = library.IdUser,
                Book = await ConvertToSeeBookDTO.Convert(library.IdBookNavigation),
                CreatedAt = library.CreatedAt,
                ProgressPage = library.ProgressPage,
                Bookmarks = library.Bookmarks?.Select(ConvertToBookmarkDTO.Convert).ToList()
            };
        }
    }
}
