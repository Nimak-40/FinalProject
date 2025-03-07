using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Contracts.AppServices;
using App.src.Domain.Core.Dtos.Categories;

namespace App.Domain.Service.AppServices.Users
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;

        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<List<GetCommentDto>> GetAllAsync(int pageNumber, CancellationToken cancellationToken)
        {
            return await _commentService.GetAllAsync(pageNumber, cancellationToken);
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _commentService.GetTotalCount(cancellationToken);
        }

        public async Task ApproveCommentAsync(int id, CancellationToken cancellationToken)
        {
            await _commentService.ApproveCommentAsync(id, cancellationToken);
        }

        public async Task RejectCommentAsync(int id, CancellationToken cancellationToken)
        {
            await _commentService.RejectCommentAsync(id, cancellationToken);
        }
    }


}
