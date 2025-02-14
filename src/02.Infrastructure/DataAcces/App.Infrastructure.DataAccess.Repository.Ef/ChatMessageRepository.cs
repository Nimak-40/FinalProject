using Achare.Infrastructure;
using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly AppDbContext _dbContext;

        public ChatMessageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChatMessage>> GetAllAsync()
        {
            return await _dbContext.ChatMessages
                                   .AsNoTracking()
                                   .Include(c => c.Sender)
                                   .Include(c => c.Receiver)
                                   .Include(c => c.Order)
                                   .ToListAsync();
        }

        public async Task<ChatMessage?> GetByIdAsync(int id)
        {
            return await _dbContext.ChatMessages
                                   .AsNoTracking()
                                   .Include(c => c.Sender)
                                   .Include(c => c.Receiver)
                                   .Include(c => c.Order)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<ChatMessage>> GetBySenderIdAsync(int senderId)
        {
            return await _dbContext.ChatMessages
                                   .AsNoTracking()
                                   .Where(c => c.SenderId == senderId)
                                   .Include(c => c.Receiver)
                                   .Include(c => c.Order)
                                   .ToListAsync();
        }

        public async Task<List<ChatMessage>> GetByReceiverIdAsync(int receiverId)
        {
            return await _dbContext.ChatMessages
                                   .AsNoTracking()
                                   .Where(c => c.ReceiverId == receiverId)
                                   .Include(c => c.Sender)
                                   .Include(c => c.Order)
                                   .ToListAsync();
        }

        public async Task AddAsync(ChatMessage chatMessage)
        {
            await _dbContext.ChatMessages.AddAsync(chatMessage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChatMessage chatMessage)
        {
            var existingChatMessage = await _dbContext.ChatMessages
                                                     .FirstOrDefaultAsync(c => c.Id == chatMessage.Id);

            if (existingChatMessage != null)
            {
                existingChatMessage.Message = chatMessage.Message;
                existingChatMessage.SentDate = chatMessage.SentDate;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var chatMessage = await GetByIdAsync(id);
            if (chatMessage != null)
            {
                _dbContext.ChatMessages.Remove(chatMessage);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}