using HelpLibrary.DTOs;
using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using ServerLibrary.Helpers;
using ServerLibrary.Helpers.Converters.Libraries;
using ServerLibrary.Repositories.Interfaces;
using ServerLibrary.Repositories.Interfaces.ILibrares;
using ServerLibrary.Services.Interfaces;

namespace ServerLibrary.Services.Implementations
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly ILogRepository _logRepository;
        private readonly IBookmarksRepository _bookmarksRepository;


        public LibraryService(
            ILibraryRepository libraryRepository, 
            ILogRepository logRepository, 
            IBookmarksRepository bookmarksRepository)
        {
            _libraryRepository = libraryRepository;
            _logRepository = logRepository;
            _bookmarksRepository = bookmarksRepository;
        }

        public async Task<GeneralResponce> AddBokmarkAsync(AddBookmarkDTO addBookmark)
        {
            if (addBookmark is null) throw new NullReferenceException("Model is empty");

            Bookmark bookmark = new Bookmark()
            {
                IdLibrary = addBookmark.IdLibrary,
                Page = addBookmark.Page,
                Comment = addBookmark.Comment,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _bookmarksRepository.AddBookMarkAsync(bookmark);
            if (result is null) throw new Exception("Oopsss... Erorr :/");

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> AddBookToLibraryAsync(AddLibraryDTO library)
        {
            if (library is null) throw new NullReferenceException("Model is empty");

            var findLibrary = await _libraryRepository.FindLibraryByIdUserIdBookAsync(library);
            if (findLibrary is not null) throw new Exception("Book already added");

            Library newLibrary = new Library()
            {
                IdBook = library.idBook,
                IdUser = library.idUser,
                CreatedAt = DateTime.UtcNow,
                ProgressPage = 0
            };

            var result = await _libraryRepository.AddBookToLibraryAsync(newLibrary);
            if (result is null) throw new Exception("Opsss.. Error :/");

            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = library.idUser, Action = Constants.AddLibrary + library.idBook });

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> DeleteBookFromLibraryAsync(AddLibraryDTO library)
        {
            if (library is null) throw new NullReferenceException("Model is empty");

            var findLibrary = await _libraryRepository.FindLibraryByIdUserIdBookAsync(library);
            if (findLibrary is null) throw new Exception("I did not find such an entry.");

            await _libraryRepository.RemoveBookFromLibraryAsync(findLibrary);
            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = library.idUser, Action = Constants.DeleteLibrary + library.idBook });

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> DeleteBookmarkAsync(int idBookmark)
        {
            var bookmark = await _bookmarksRepository.GetBookmarkByIdAsync(idBookmark);
            if (bookmark is null) throw new Exception("I did not find such an entry.");

            await _bookmarksRepository.RemoveBookMarkAsync(bookmark);

            return new GeneralResponce("Success");

        }

        public async Task<List<Bookmark>> GetAllBookmarksLibraryAsync(int idLibrary) =>
            await _bookmarksRepository.GetAllBookmarksByLibrayAsync(idLibrary);


        public async Task<SeeLibrariesDTO> GetAllBooksUserAsync(int id)
        {
            var libraries = await _libraryRepository.GetAllBooksFromLibraryAsync(id);
            Console.WriteLine(libraries.Count);
            return ConvertToSeeLibraryDTO.Convert(libraries);
        }


        public async Task<GeneralResponce> UpdateBookmarkAsync(UpdateBookmarkDTO update)
        {
            if (update is null) throw new Exception("Model is empty.");

            await _bookmarksRepository.UpdateBookmarkAsync(update);
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> UpdateProgressPagesAsync(UpdateProgressDTO update)
        {
            if (update is null) throw new NullReferenceException("Model is empty");

            var findLibrary = await _libraryRepository.FindLibraryByIdUserIdBookAsync(new AddLibraryDTO { idBook = update.IdBook, idUser = update.IdUser });
            if (findLibrary is null) throw new Exception("I did not find such an entry.");

            var result = await _libraryRepository.UpdateProgressAsync(update);
            return new GeneralResponce($"Success\n{result}");
        }
    }
}
