
using App.src.Domain.Core.Entities.BaseEntities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments(int pageNumber, CancellationToken cancellationToken);
        Task<int> GetTotalCount(CancellationToken cancellationToken);
        Task AcceptComment(int commentId, CancellationToken cancellationToken);
        Task RejectComment(int commentId, CancellationToken cancellationToken);
    }


}
