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


        public LibraryService(
            ILibraryRepository libraryRepository, 
            ILogRepository logRepository)
        {
            _libraryRepository = libraryRepository;
            _logRepository = logRepository;
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


        public async Task<SeeLibrariesDTO> GetAllBooksUserAsync(int id)
        {
            var libraries = await _libraryRepository.GetAllBooksFromLibraryAsync(id);
            Console.WriteLine(libraries.Count);
            return ConvertToSeeLibraryDTO.Convert(libraries);
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
