using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.BooksInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations.Books
{
    public class LikesReviewsRepository : ILikesReviewsRepository
    {
        private readonly ReadifyContext _context;

        public LikesReviewsRepository(ReadifyContext context)
        {
            _context = context;
        }

        public async Task<LikesReview> AddToDatabaseAsync(LikesReview likesReview)
        {
            var result = await _context.LikesReviews.AddAsync(likesReview);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteLikeReviewAsync(LikesReview delete)
        {
            _context.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<LikesReview> GetLikesReviewByIdAsync(int id) =>
            await _context.LikesReviews.FirstOrDefaultAsync(l => l.Id == id);

        public async Task<LikesReview> UpdateLikeReviewAsync(UpdateLikeReviewDTO update)
        {
            var find = await GetLikesReviewByIdAsync(update.Id);

            find.ReactionType = update.ReactionType;
            await _context.SaveChangesAsync();
            return find;
        }

        public async Task<LikesReview> GetLikeByAuthorIdAndReviewIdAsync(int idAuthor, int idReview) =>
            await _context.LikesReviews.FirstOrDefaultAsync(l => l.IdAuthor == idAuthor && l.IdReview == idReview);
    }
}
