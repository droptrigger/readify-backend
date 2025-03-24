using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using Microsoft.AspNetCore.Http;
using ServerLibrary.Helpers;
using ServerLibrary.Helpers.Exceptions;
using ServerLibrary.Repositories.Interfaces;
using ServerLibrary.Repositories.Interfaces.Books;
using ServerLibrary.Repositories.Interfaces.BooksInterfaces;
using ServerLibrary.Services.Interfaces;
using System.Net;

namespace ServerLibrary.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ILogRepository _logRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly ILikesReviewsRepository _likesReviewRepository;
        
        public BookService(
            IGenreRepository genreRepository, 
            ILogRepository logRepository, 
            IBookRepository bookRepository,
            IBookReviewRepository bookReviewRepository,
            ILikesReviewsRepository likesReviewsRepository)
        {
            _genreRepository = genreRepository;
            _logRepository = logRepository;
            _bookRepository = bookRepository;
            _bookReviewRepository = bookReviewRepository;
            _likesReviewRepository = likesReviewsRepository; 
        }

        public async Task<GeneralResponce> AddBookAsync(AddBookDTO book)
        {
            if (book is null) throw new NullReferenceException("Model is empty");

            Book newBook = new Book()
            {
                Name = book.Name,
                Description = book.Description!,
                PageQuantity = book.PageQuantity,
                IdAuthor = book.IdAuthor,
                IdGenre = book.IdGenre,
                FileBookPath = "temp",
                CoverImagePath = "temp",
                IsPrivate = book.IsPrivate,
                CreatedAt = DateTime.UtcNow
            };

            var addedBook = await _bookRepository.AddToDatabaseAsync(newBook);

            try
            {
                await DownloadFile(book.FileBook, addedBook);
                await DownloadImage(book.CoverImageFIle, addedBook);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            await _bookRepository.SaveChangesAsync();
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> AddBookReviewAsync(AddReviewDTO review)
        {
            if (review is null) throw new NullReferenceException("Model is empty");

            BookReview newBookReview = new BookReview()
            {
                IdAuthor = review.IdAuthor,
                IdBook = review.IdBook,
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _bookReviewRepository.AddToDatabaseAsync(newBookReview);
            if (result is null) throw new Exception("Error");

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> AddGenreAsync(string name)
        {
            var tryFound = await _genreRepository.FindGenreByNameAsync(name);
            if (tryFound is not null) throw new GenreAlreadyExistException("Genre already exists");

            await _genreRepository.AddGenreAsync(name);

            return new GeneralResponce($"A genre named {name} has been added");
         
        }

        public async Task<GeneralResponce> AddLikeAsync(AddLikeReviewDTO like)
        {
            if (like is null) throw new NullReferenceException("Model is empty");

            var find = await _likesReviewRepository.GetLikeByAuthorIdAndReviewIdAsync(like.IdAuthor, like.IdReview);
            if (find is not null) throw new Exception("Have you given a reaction");

            LikesReview newLike = new LikesReview()
            {
                IdAuthor = like.IdAuthor,
                IdReview = like.IdReview,
                ReactionType = like.ReactionType,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _likesReviewRepository.AddToDatabaseAsync(newLike);
            if (result is null) throw new Exception("Error");

            return new GeneralResponce("Succes");
        }

        public async Task<GeneralResponce> DeleteBookReviewAsync(int id)
        {
            var findReview = await _bookReviewRepository.FindByIdAsync(id);
            if (findReview is null) throw new Exception("Don't found");

            await _bookReviewRepository.DeleteByIdAsync(id);
            return new GeneralResponce("Success");
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var result = await _bookRepository.FindBookByIdAsync(id);
            if (result is null) throw new Exception("Don't found");

            return result;
        }

        public async Task<BookReview> GetBookReviewAsync(int id)
        {
            var result = await _bookReviewRepository.FindByIdAsync(id);
            if (result is null) throw new Exception("Don't found");

            return result;
        }

        public async Task<LikesReview> GetLikeAsync(int id)
        {
            var result = await _likesReviewRepository.GetLikesReviewByIdAsync(id);
            if (result is null) throw new Exception("Don't found");

            return result;
        }

        public async Task<GeneralResponce> RemoveBookAsync(int id)
        {
            var book = await _bookRepository.FindBookByIdAsync(id);
            if (book is null) throw new Exception("Don't found");

            await _bookRepository.RemoveFromDatabaseAsync(book);
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> RemoveGenreAsync(int id)
        {
            var tryFound = await _genreRepository.FindGenreByIdAsync(id);
            if (tryFound is null) throw new NotFoundException($"Not found genre id {id}");

            await _genreRepository.DeleteGenreAsync(id);

            return new GeneralResponce($"A genre id {id} has been deleted");
        }

        public async Task<GeneralResponce> RemoveLikeAsync(int idLike)
        {
            var find = await _likesReviewRepository.GetLikesReviewByIdAsync(idLike);
            if (find is null) throw new NotFoundException("Don't found");
            await _likesReviewRepository.DeleteLikeReviewAsync(find);
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> UpdateBookAsync(UpdateBookDTO book)
        {
            if (book is null) throw new NullReferenceException("Model is empty");

            var foundBook = await _bookRepository.FindBookByIdAsync(book.Id);
            if (foundBook is null) throw new Exception($"{book.Id} is not found");

            await _bookRepository.UpdateBookAsync(book);
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> UpdateBookReviewAsync(UpdateReviewDTO update)
        {
            if (update is null) throw new NullReferenceException("Model is empty");

            var result = await _bookReviewRepository.UpdateReviewAsync(update);
            if (result is null) throw new Exception("Error");

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> UpdateGenreAsync(GenreDTO genre)
        {
            var tryFound = await _genreRepository.FindGenreByIdAsync(genre.Id);
            if (tryFound is null) throw new NotFoundException($"Not found genre id {genre.Id}");

            await _genreRepository.UpdateGenreAsync(genre);

            return new GeneralResponce($"A genre id {genre.Id} has been updated, new name {genre.Name}");
        }

        public async Task<GeneralResponce> UpdateLikeAsync(UpdateLikeReviewDTO updateLike)
        {
            if (updateLike is null) throw new NullReferenceException("Model is empty");

            var result = await _likesReviewRepository.UpdateLikeReviewAsync(updateLike);
            if (result is null) throw new Exception("Error");

            return new GeneralResponce("Success");
        }

        private async Task<string> DownloadFile(IFormFile file, Book book)
        {
            try
            {
                string fileName = $"book-file-id{book.Id}.pdf";
                var filePath = Path.Combine(Constants.PathToBookFiles!, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    book.FileBookPath = Constants.PathBookFiles + fileName;
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while downloading file: {ex.Message}", ex);
            }
        }

        private async Task<string> DownloadImage(IFormFile image, Book book)
        {
            try
            {
                string fileName = $"book-cover-id{book.Id}.png";
                var filePath = Path.Combine(Constants.PathToBookImages!, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                    book.CoverImagePath = Constants.PathBookImages + fileName;
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while downloading file: {ex.Message}", ex);
            }
        }
    }
}
