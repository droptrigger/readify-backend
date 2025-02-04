using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces;

namespace ServerLibrary.Repositories.Implementations
{
    public class SubscribeRepository : ISubscribeRepository
    {
        private readonly ReadifyContext _context;

        public SubscribeRepository(ReadifyContext context)
        {
            _context = context;
        }

        public async Task<UserSubscriber> GetSubByIdAsync(SubscribeDTO data) =>
            await _context.UserSubscribers.FirstOrDefaultAsync(us => us.IdAuthor == data.AuthorId && us.IdSubscriber == data.SubscriberId);

        public async Task<List<UserInfoDTO>> GetSubscribersByIdAsync(int id)
        {
            var subscribers = await _context.UserSubscribers
                .Where(us => us.IdAuthor == id) // Фильтруем по IdAuthor
                .Include(us => us.IdSubscriberNavigation) // Подгружаем данные подписчиков
                .Select(us => new UserInfoDTO // Проекция на DTO
                {
                    Id = us.IdSubscriberNavigation.Id,
                    Nickname = us.IdSubscriberNavigation.Nickname,
                    AvatarImagePath = us.IdSubscriberNavigation.AvatarImagePath,
                    Name = us.IdSubscriberNavigation.Name
                })
                .ToListAsync();

            return subscribers;
        }

        public async Task<List<UserInfoDTO>> GetSubscriptionsByIdAsync(int id)
        {
            var subscribers = await _context.UserSubscribers
                .Where(us => us.IdSubscriber == id)
                .Include(us => us.IdAuthorNavigation)
                .Select(us => new UserInfoDTO
                {
                    Id = us.IdSubscriberNavigation.Id,
                    Nickname = us.IdSubscriberNavigation.Nickname,
                    AvatarImagePath = us.IdSubscriberNavigation.AvatarImagePath,
                    Name = us.IdSubscriberNavigation.Name
                })
                .ToListAsync();

            return subscribers;
        }

        public async Task SubscribeAsync(SubscribeDTO subscribe)
        {
            UserSubscriber model = new UserSubscriber()
            {
                IdAuthor = subscribe.AuthorId,
                IdSubscriber = subscribe.SubscriberId,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UnsubscribeAsync(SubscribeDTO unsubscribe)
        {
            var model = GetSubByIdAsync(unsubscribe);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
