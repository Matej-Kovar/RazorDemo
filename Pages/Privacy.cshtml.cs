using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages25P3A.Data;
using RazorPages25P3A.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPages25P3A.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly AppDbContext _db;

        public PrivacyModel(AppDbContext db)
        {
            _db = db;
        }

        public List<FormModel> Entries { get; set; } = new List<FormModel>();

        public async Task OnGetAsync()
        {
            Entries = await _db.FormModels.AsNoTracking().ToListAsync();
        }
    }

}
