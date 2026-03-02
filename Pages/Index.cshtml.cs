using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages25P3A.Models;
using RazorPages25P3A.Data;

namespace RazorPages25P3A.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public FormIM Form { get; set; } = new FormIM();
        public string Message { get; set; } = "Hello, World!";
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Validation failed.";
                return Page();
            }

            try
            {
                FormModel? result = _db.FormModels.Where(f => f.Email == Form.Email).SingleOrDefault();
                if(result is not null)
                {
                    ErrorMessage = "Account with this email already exists";
                    return Page();
                }
            }
            catch
            {
                ErrorMessage = "Failed to verify account is unique.";
                return Page();
            }

            var model = new FormModel
            {
                Email = Form.Email ?? string.Empty,
                Password = Form.Password ?? string.Empty
            };

            try
            {
                _db.FormModels.Add(model);
                await _db.SaveChangesAsync();

                Message = "Saved successfully.";
                return RedirectToPage("./Privacy");
            }
            catch
            {
                ErrorMessage = "Failed to save to database.";
                return Page();
            }
        }
    }
}
