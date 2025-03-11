using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Interfaces.Books
{
    public interface IGenreRepository
    {
        /// <summary>
        /// Метод добавления нового жанра
        /// </summary>
        /// <param name="name">Название жанра</param>
        /// <returns>Созданный жанр</returns>
        Task<Genre> AddGenreAsync(string name);

        /// <summary>
        ///  Метод обновления названия жанра
        /// </summary>
        /// <param name="genre">Объект из БД</param>
        /// <returns>Обновленный жанр</returns>
        Task<Genre> UpdateGenreAsync(GenreDTO genre);

        /// <summary>
        /// Метод удаления жанра
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        Task DeleteGenreAsync(int id);

        /// <summary>
        /// Метод поиска жанра по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        /// <returns>Найденный жанр</returns>
        Task<Genre> FindGenreByIdAsync(int id);

        /// <summary>
        /// Метод получения жанра по названию
        /// </summary>
        /// <param name="name">Название жанра</param>
        /// <returns>Найденный жанр</returns>
        Task<Genre> FindGenreByNameAsync(string name);

        /// <summary>
        /// Метод поиска жанра по наванию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Найденные жанры</returns>
        Task<List<Genre>> FindAllGenresByNameAsync(string name);
    }
}
