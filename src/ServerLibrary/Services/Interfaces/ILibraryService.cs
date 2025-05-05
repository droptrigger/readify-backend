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
        Task<SeeLibrariesDTO> GetAllBooksUserAsync(int id);
    }
}
