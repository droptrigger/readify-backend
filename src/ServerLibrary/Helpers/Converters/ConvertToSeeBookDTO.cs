using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    /// <summary>
    /// Конвертер для получения <see cref="SeeBookDTO"/> из <see cref="Book"/>
    /// </summary>
    public static class ConvertToSeeBookDTO
    {
        /// <summary>
        /// Метод конвертации
        /// </summary>
        /// <param name="book">Экземпляр класса <see cref="Book"/></param>
        /// <param name="includeNestedCollections">Булевый параметр для предотвращения рекурсии</param>
        /// <returns>Экземпляр <see cref="SeeBookDTO"/>/returns>
        public static async Task<SeeBookDTO> Convert(Book book)
        {
            if (book == null)
                return null!;

            var seeBookDTO = new SeeBookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Author = await ConvertToAuthorDTO.Convert(book.IdAuthorNavigation),
                CoverImage = await GetBytes.GetArrayAsync(Constants.PathToBookImagesForBytes + book.CoverImagePath),
                Genre = new GenreDTO 
                { 
                    Id = book.IdGenreNavigation.Id, 
                    Name = book.IdGenreNavigation.Name 
                } 
            };

            return seeBookDTO;
        }
    }
}
