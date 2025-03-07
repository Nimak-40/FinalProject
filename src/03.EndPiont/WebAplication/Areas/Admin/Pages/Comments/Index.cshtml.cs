using App.src.Domain.Core.Contracts.AppServices;
using App.src.Domain.Core.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAplication.Areas.Admin.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;

        public IndexModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [BindProperty]
        public List<GetCommentDto> Comments { get; set; }

        [BindProperty]
        public int CommentCount { get; set; }

        [BindProperty]
        public static int CurrentPage { get; set; }

        [BindProperty]
        public int MyPage { get; set; }

        // بارگذاری کامنت‌ها برای صفحه انتخابی
        public async Task OnGet(CancellationToken cancellationToken, int pageNumber = 1)
        {
            if (pageNumber > 100 || pageNumber <= 0)
                pageNumber = 1;
            CurrentPage = pageNumber;
            MyPage = pageNumber;
            Comments = await _commentAppService.GetAllAsync(pageNumber, cancellationToken);
            CommentCount = await _commentAppService.GetTotalCount(cancellationToken);
        }

        // پیمایش به صفحه بعد
        public IActionResult OnGetNextPage()
        {
            return RedirectToPage("/Comments/Index", new { pageNumber = CurrentPage + 1 });
        }

        // پیمایش به صفحه قبلی
        public IActionResult OnGetPreviousPage()
        {
            return RedirectToPage("/Comments/Index", new { pageNumber = CurrentPage - 1 });
        }
    }
}
