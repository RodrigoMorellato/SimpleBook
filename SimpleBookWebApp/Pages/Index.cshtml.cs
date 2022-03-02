#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBookWebApp.Data;
using SimpleBookWebApp.Data.HttpVerbs;
using SimpleBookWebApp.ViewModels;

namespace SimpleBookWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClientHelper _httpClientHelper;
        public IList<BookViewModel> BookDto { get; set; }

        public IndexModel(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var response = await _httpClientHelper.EnviaHttpRequestAsync(new Get(), "getall");
                BookDto = await HttpRequestHelper.ConverteHttpResponseToObjectTask<List<BookViewModel>>(response);
            }
            catch (Exception ex)
            {
                BookDto = new List<BookViewModel>();
                ViewData["Message"] = ex.Message;
            }
        }
    }
}
