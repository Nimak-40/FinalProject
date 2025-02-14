using Achare.src.Domain.Core.Entities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IChatMessageRepository
    {
        Task<List<ChatMessage>> GetAllAsync();
        Task<ChatMessage?> GetByIdAsync(int id);
        Task<List<ChatMessage>> GetBySenderIdAsync(int senderId);
        Task<List<ChatMessage>> GetByReceiverIdAsync(int receiverId);
        Task AddAsync(ChatMessage chatMessage);
        Task UpdateAsync(ChatMessage chatMessage);
        Task DeleteAsync(int id);
    }
}
