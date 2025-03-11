using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces.Books
{
    public interface IBookRepository
    {
        /// <summary>
        /// Метод добавления новой книги
        /// </summary>
        /// <param name="book">Новый объект</param>
        /// <returns>Созданный обхект</returns>
        Task<Book> AddToDatabaseAsync(Book book);

        /// <summary>
        /// Метод удаления книги из БД
        /// </summary>
        /// <param name="book">Объект из БД</param>
        Task RemoveFromDatabaseAsync(Book book);

        /// <summary>
        /// Метод обновения книги
        /// </summary>
        /// <param name="book">Объект передачи данных, содержащий обновленную информацию о книге</param>
        /// <returns>Обновленная книга</returns>
        Task<Book> UpdateBookAsync(UpdateBookDTO book);

        /// <summary>
        /// Метод поиска книги по идентификатор
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Найденный объект</returns>
        Task<Book> FindBookByIdAsync(int id);

        /// <summary>
        /// Метод получения всех книг, похожих по названию
        /// </summary>
        /// <param name="name">Имя книги</param>
        /// <returns>Список книг</returns>
        Task<List<Book>> FindAllBooksByNameAsync(string name);

        /// <summary>
        /// Метод получения всех книг, похожих по описанию
        /// </summary>
        /// <param name="description">Описание книги</param>
        /// <returns>Список книг</returns>
        Task<List<Book>> FindAllBooksByDescriptionAsync(string description);

        /// <summary>
        /// Метод получения всех книг по жанру
        /// </summary>
        /// <param name="idGenre">Идентификатор жанра</param>
        /// <returns>Список книг</returns>
        Task<List<Book>> GetAllBooksByGenreAsync(int idGenre);

        Task SaveChangesAsync();
    }
}
