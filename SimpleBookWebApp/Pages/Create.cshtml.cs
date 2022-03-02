#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBookWebApp.Data;
using SimpleBookWebApp.Data.HttpVerbs;
using SimpleBookWebApp.ViewModels;

namespace SimpleBookWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly HttpClientHelper _httpClientHelper;

        public CreateModel(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookViewModel Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var response = await _httpClientHelper.EnviaHttpRequestAsync(new Post(), "create", Book);
                var newId = await HttpRequestHelper.ConverteHttpResponseToObjectTask<int>(response);

                ViewData["Message"] = $"Book Added successfully with Id: {newId}";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return Redirect("./Index");
        }
    }
}
