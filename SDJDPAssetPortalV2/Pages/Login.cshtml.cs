using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SDJDPAssetPortalV2.Pages
{
    public class LoginModel : PageModel
    {
        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Invalid username or password.";

            return Page();
        }
    }
}