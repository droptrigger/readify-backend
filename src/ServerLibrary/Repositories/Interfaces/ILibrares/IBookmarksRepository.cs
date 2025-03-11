using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces.ILibrares
{
    public interface IBookmarksRepository
    {
        Task<Bookmark> AddBookMarkAsync(Bookmark bookmark);
        Task RemoveBookMarkAsync(Bookmark bookmark);
        Task<Bookmark> UpdateBookmarkAsync(UpdateBookmarkDTO update);
        Task<List<Bookmark>> GetAllBookmarksByLibrayAsync(int idLibrary);
        Task<Bookmark> GetBookmarkByIdAsync(int idBookmark);
    }
}
