#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBookWebApp.Data;
using SimpleBookWebApp.Data.HttpVerbs;
using SimpleBookWebApp.ViewModels;

namespace SimpleBookWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly HttpClientHelper _httpClientHelper;

        public EditModel(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        [BindProperty]
        public BookViewModel Book { get; set; }

        public Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            Book = new BookViewModel
            {
                Id = id
            };

            //if (BookDto == null)
            //{
            //    return NotFound();
            //}
            return Task.FromResult<IActionResult>(Page());
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var response = await _httpClientHelper.EnviaHttpRequestAsync(new Put(), $"{Book.Id}/update", Book);
                Book = await HttpRequestHelper.ConverteHttpResponseToObjectTask<BookViewModel>(response);
                ViewData["Message"] = "Book updated";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return Redirect("./Index");
        }
    }
}
