using App.src.Domain.Core.Dtos.Categories;

namespace App.src.Domain.Core.Contracts.Service
{
    public interface ICommentService
    {
        Task<List<GetCommentDto>> GetAllAsync(int pageNumber, CancellationToken cancellationToken);
        Task<int> GetTotalCount(CancellationToken cancellationToken);
        Task ApproveCommentAsync(int id, CancellationToken cancellationToken);
        Task RejectCommentAsync(int id, CancellationToken cancellationToken);
    }
}
