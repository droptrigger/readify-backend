﻿using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Library;
using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Метод добавления книги в БД
        /// </summary>
        /// <param name="book">Объект передачи данных, содержищий необходимую информацию</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> AddBookAsync(AddBookDTO book);

        /// <summary>
        /// Метод удаления книги из БД
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> RemoveBookAsync(int id);

        /// <summary>
        /// Метод обновления книги в БД
        /// </summary>
        /// <param name="book">Объект передачи данных, содержащий обновленную информацию</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> UpdateBookAsync(UpdateBookDTO book);

        Task<BookDTO> GetBookAsync(int id);


        Task<GeneralResponce> AddBookReviewAsync(AddReviewDTO review);
        Task<BookReview> GetBookReviewAsync(int id);
        Task<GeneralResponce> UpdateBookReviewAsync(UpdateReviewDTO update);
        Task<GeneralResponce> DeleteBookReviewAsync(int id);


        Task<List<Genre>> GetAllGenresAsync();
        Task<GeneralResponce> AddGenreAsync(string name);
        Task<GeneralResponce> RemoveGenreAsync(int id);
        Task<GeneralResponce> UpdateGenreAsync(GenreDTO genre);
    }
}
