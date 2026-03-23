using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages25P3A.Models;
using RazorPages25P3A.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RazorPages25P3A.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<LargerUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<LargerUser> _signInManager; // Add SignInManager

        // Inject UserManager, RoleManager, and SignInManager
        public IndexModel(
            UserManager<LargerUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<LargerUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginModelWTF Form { get; set; } = new LoginModelWTF();
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
                // Ensure the "admin" role exists in the database
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // Find the user by the email input
                var user = await _userManager.FindByEmailAsync(Form.Email);
                if (user == null)
                {
                    ErrorMessage = "User not found.";
                    return Page();
                }

                // Add the user to the admin role
                if (!await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    var result = await _userManager.AddToRoleAsync(user, "Admin");
                    if (!result.Succeeded)
                    {
                        ErrorMessage = "Failed to add role.";
                        return Page();
                    }
                }

                // If the user elevating themselves is the currently logged-in user, refresh their cookie
                if (User.Identity?.Name == user.UserName)
                {
                    await _signInManager.RefreshSignInAsync(user);
                }

                Message = "Admin role added successfully.";
                return Page();
            }
            catch
            {
                ErrorMessage = "An error occurred.";
                return Page();
            }
        }
    }
}
