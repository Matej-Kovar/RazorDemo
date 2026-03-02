using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages25P3A.Models;

namespace RazorPages25P3A.Pages.Index
{
    public class IndexModel : PageModel
    {
        public ClickerVM Clicker { get; set; } = new ClickerVM();

        public void OnGet()
        {
            Clicker.Clicks = 0;
            Clicker.Message = "Basic Click";
        }

        public void OnGetBetter()
        {
            Clicker.Clicks = 5;
            Clicker.Message = "Basic Click";
        }

        public void OnGetBest(int count = 10)
        {
            Clicker.Clicks = count;
            Clicker.Message = "Best Of Click";
        }
    }
}
