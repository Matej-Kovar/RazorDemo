using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages25P3A.Data;
using RazorPages25P3A.Models;

namespace RazorPages25P3A.Pages
{
    [Authorize(Roles = "Admin")]
    public class PrivacyModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly UserManager<LargerUser> _userManager;

        public PrivacyModel(AppDbContext db, UserManager<LargerUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public List<LargerUser> Entries { get; set; } = new List<LargerUser>();
        
        // Dictionary to map User Id to their Roles
        public Dictionary<string, IList<string>> UserRoles { get; set; } = new Dictionary<string, IList<string>>();

        public async Task OnGetAsync()
        {
            Entries = await _db.Users.AsNoTracking().ToListAsync();

            // Fetch roles for each user
            foreach (var user in Entries)
            {
                var roles = await _userManager.GetRolesAsync(user);
                UserRoles[user.Id] = roles;
            }
        }
    }
}
