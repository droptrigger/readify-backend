using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations.Books
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ReadifyContext _context;

        public GenreRepository(ReadifyContext context) { _context = context; }

        public async Task<Genre> AddGenreAsync(string name)
        {
            Genre addGenre = new Genre() { Name = name.ToLower() };

            var result = await _context.Genres.AddAsync(addGenre);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await FindGenreByIdAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Genre>> FindAllGenresByNameAsync(string name) =>
            await _context.Genres.Where(g => EF.Functions.Like(g.Name, $"%{name.ToLower()}%")).ToListAsync();

        public async Task<Genre> FindGenreByIdAsync(int id) =>
            await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

        public async Task<Genre> FindGenreByNameAsync(string name) =>
            await _context.Genres.FirstOrDefaultAsync(g => g.Name == name.ToLower());

        public async Task<Genre> UpdateGenreAsync(GenreDTO genre)
        {
            var findGenre = await FindGenreByIdAsync(genre.Id);
            findGenre.Name = genre.Name.ToLower();
            await _context.SaveChangesAsync();
            return findGenre;
        }
    }
}
