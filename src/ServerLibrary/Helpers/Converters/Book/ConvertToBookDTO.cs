using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    public static class ConvertToBookDTO
    {
        public static async Task<BookDTO> Convert(Book book)
        {
            if (book == null)
                return null!;

            var authorDto = await ConvertToAuthorDTO.Convert(book.IdAuthorNavigation);

            Console.WriteLine(Constants.PathToBookImagesForBytes + book.CoverImagePath);
            Console.WriteLine(Constants.PathToBookImagesForBytes + book.FileBookPath);

            var coverImage = await GetBytes.GetArrayAsync(Constants.PathToBookImagesForBytes + book.CoverImagePath);
            var fileBook = await GetBytes.GetArrayAsync(Constants.PathToBookImagesForBytes + book.FileBookPath);

            GenreDTO genreDto = null!;
            if (book.IdGenreNavigation != null)
            {
                genreDto = new GenreDTO
                {
                    Id = book.IdGenreNavigation.Id,
                    Name = book.IdGenreNavigation.Name
                };
            }

            var seeBookDto = await ConvertToSeeBookDTO.Convert(book);

            // Подготовка списка отзывов
            var reviews = new List<SeeReviewBookDTO>();
            foreach (var review in book.BookReviews)
            {
                var reviewAuthorDto = await ConvertToAuthorDTO.Convert(review.IdAuthorNavigation);

                reviews.Add(new SeeReviewBookDTO
                {
                    Id = review.Id,
                    Author = reviewAuthorDto,
                    IdBook = seeBookDto.Id,
                    Comment = review.Comment,
                    Rating = review.Rating,
                    CreatedAt = review.CreatedAt,
                });
            }

            // Создание итогового DTO
            return new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                PageQuantity = book.PageQuantity,
                Author = authorDto,
                CoverImage = coverImage,
                FileBook = fileBook,
                Genre = genreDto,
                IsPrivate = book.IsPrivate,
                CreatedAt = book.CreatedAt,
                CountLibraries = book.Libraries?.Count ?? 0,
                Reviews = reviews
            };
        }
    }
}
