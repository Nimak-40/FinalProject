using App.src.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAplication.Areas.Admin.Pages.Comments
{
    public class RejectCommentModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;

        public RejectCommentModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        // ?? ?????
        public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
        {
            await _commentAppService.RejectCommentAsync(id, cancellationToken);
            TempData["ErrorMessage"] = "????? ?? ??.";
            return RedirectToPage("/Comments/Index");
        }
    }
}
