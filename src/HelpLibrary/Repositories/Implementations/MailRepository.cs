
using HelpLibrary.DTOs.Mail;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces;

namespace ServerLibrary.Repositories.Implementations
{
    public class MailRepository : IMailRepository
    {
        private readonly ReadifyContext _context;

        public MailRepository(ReadifyContext readifyContext)
        {
            _context = readifyContext;
        }

        public async Task DeleteCodeAsync(СonfirmationСode code)
        {
            _context.СonfirmationСodes.Remove(code);
            await _context.SaveChangesAsync();
        }

        public async Task<СonfirmationСode> FindByEmailAsync(string email) =>
            await _context.СonfirmationСodes.FirstOrDefaultAsync(c => c.Email == email);

        public async Task<СonfirmationСode> VerifyCodeAsync(ConfirmCode code) =>
            await _context.СonfirmationСodes.FirstOrDefaultAsync(c => c.Email == code.Email && c.Code == code.Code);

        public async Task<СonfirmationСode> WriteCodeAsync(ConfirmCode code)
        {
            СonfirmationСode model = new СonfirmationСode()
            {
                Code = code.Code!,
                Email = code.Email!,
                ExpiresIn = DateTime.UtcNow.AddMinutes(10)
            };

            var result = await _context.AddAsync(model!);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
