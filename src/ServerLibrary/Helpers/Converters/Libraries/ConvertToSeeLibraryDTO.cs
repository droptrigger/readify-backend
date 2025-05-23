﻿using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerLibrary.Helpers.Converters.Libraries
{
    public static class ConvertToSeeLibraryDTO
    {
        public static SeeLibrariesDTO Convert(List<Library> libraries)
        {
            if (libraries == null)
                return new SeeLibrariesDTO();

            Library? library = libraries.LastOrDefault();

            if (library is null)
                return new SeeLibrariesDTO();

            int idAuthor = library.IdUser;

            return new SeeLibrariesDTO
            {
                LastBook = GetLastBook(libraries),
                Genres = GetUniqueGenres(libraries),
                NotFullyReadBooks = GetNotFullyReadBooks(libraries),
                DeployedBooks = GetDeployedBooks(libraries, idAuthor),
                FullyReadBooks = GetFullyReadBooksAsync(libraries)
            };
        }

        private static SeeLibraryBookDTO GetLastBook(List<Library> libraries)
        {
            var fallback = libraries
                .OrderByDescending(l => l.CreatedAt)
                .FirstOrDefault();

            return fallback != null ? ConvertToBookDTO(fallback) : null;
        }

        private static List<GenreDTO> GetUniqueGenres(List<Library> libraries)
        {
            return libraries
                .Select(l => l.IdBookNavigation.IdGenreNavigation)
                .GroupBy(g => new { g.Id, g.Name }) 
                .Select(g => g.First())
                .Select(g => new GenreDTO { Id = g.Id, Name = g.Name })
                .ToList();
        }

        private static List<SeeLibraryBookDTO> GetNotFullyReadBooks(List<Library> libraries)
        {
            return libraries
                .Where(l => l.ProgressPage < l.IdBookNavigation.PageQuantity)
                .Select(ConvertToBookDTO)
                .ToList();
        }

        private static List<SeeLibraryBookDTO> GetDeployedBooks(List<Library> libraries, int idAuthor)
        {
            return libraries
                .Where(l => l.IdBookNavigation.IdAuthor == idAuthor)
                .Select(ConvertToBookDTO)
                .ToList();
        }

        private static List<SeeLibraryBookDTO> GetFullyReadBooksAsync(List<Library> libraries)
        {
            return libraries
                .Where(l => l.ProgressPage >= l.IdBookNavigation.PageQuantity)
                .Select(ConvertToBookDTO)
                .ToList();
        }

        private static SeeLibraryBookDTO ConvertToBookDTO(Library library)
        {
            return new SeeLibraryBookDTO
            {
                Id = library.IdBookNavigation.Id,
                Name = library.IdBookNavigation.Name,
                LastPage = library.ProgressPage,
                PageQuantity = library.IdBookNavigation.PageQuantity,
                Genre = new GenreDTO
                {
                    Id = library.IdBookNavigation.IdGenreNavigation.Id,
                    Name = library.IdBookNavigation.IdGenreNavigation.Name.ToLower()
                },
                ImageBytes = GetBytes.GetArray(Constants.PathToBookImagesForBytes + library.IdBookNavigation.CoverImagePath)
            };
        }
    }
}