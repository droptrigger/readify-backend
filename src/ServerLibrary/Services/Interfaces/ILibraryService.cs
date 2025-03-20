using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<GeneralResponce> AddBookToLibraryAsync(AddLibraryDTO library);
        Task<GeneralResponce> DeleteBookFromLibraryAsync(AddLibraryDTO library);
        Task<GeneralResponce> UpdateProgressPagesAsync(UpdateProgressDTO update);
        Task<List<Book>> GetAllBooksUserAsync(int id);

        Task<GeneralResponce> AddBokmarkAsync(AddBookmarkDTO addBookmark);
        Task<List<Bookmark>> GetAllBookmarksLibraryAsync(int idLibrary);
        Task<GeneralResponce> UpdateBookmarkAsync(UpdateBookmarkDTO update);
        Task<GeneralResponce> DeleteBookmarkAsync(int idBookmark);
    }
}
