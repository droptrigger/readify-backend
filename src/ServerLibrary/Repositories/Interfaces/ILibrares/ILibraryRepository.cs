using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces.ILibrares
{
    public interface ILibraryRepository
    {
        /// <summary>
        /// Метод добавления книги в библиотеку 
        /// </summary>
        /// <param name="library">Объект, который необходимо добавить</param>
        /// <returns>Добавленный объект</returns>
        Task<Library> AddBookToLibraryAsync(Library library);

        /// <summary>
        /// Метод удаления книги из библиотеки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveBookFromLibraryAsync(Library library);

        /// <summary>
        /// Метод обновления прогресса чтения книги
        /// </summary>
        /// <param name="update">Объект передачи данных, содержащий новую страницу</param>
        /// <returns></returns>
        Task<Library> UpdateProgressAsync(UpdateProgressDTO update);

        /// <summary>
        /// Метод получения всех книг пользователя
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Список книг</returns>
        Task<List<Library>> GetAllBooksFromLibraryAsync(int idUser);

        /// <summary>
        /// Метод поиска книги пользователя по идентификатору книги и идентификатору пользователя
        /// </summary>
        /// <param name="library">Объект передачи данных, содержащий идентификаторы</param>
        /// <returns>Найденный объект</returns>
        Task<Library> FindLibraryByIdUserIdBookAsync(AddLibraryDTO library);
    }
}
