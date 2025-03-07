using App.src.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAplication.Areas.Admin.Pages.Comments
{
    public class AcceptCommentModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;

        public AcceptCommentModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        // تایید کامنت
        public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
        {
            await _commentAppService.ApproveCommentAsync(id, cancellationToken);
            TempData["SuccessMessage"] = "کامنت تایید شد.";
            return RedirectToPage("/Comments/Index");
        }
    }
}
