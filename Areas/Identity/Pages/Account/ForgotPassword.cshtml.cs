using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace WebApplication1.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ForgotPasswordModel> _logger;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, ILogger<ForgotPasswordModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ResetLink { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                // Do not reveal that the user does not exist
                ModelState.AddModelError(string.Empty, "Si un compte existe, un lien de réinitialisation sera envoyé.");
                return Page();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var callbackUrl = Url.Page("/Account/ResetPassword", pageHandler: null, values: new { area = "Identity", code }, protocol: Request.Scheme);

            // In development we display the link. In production you should email it.
            ResetLink = callbackUrl;
            _logger.LogInformation("Generated password reset link for {Email}", Input.Email);

            ModelState.AddModelError(string.Empty, "Si un compte existe, un lien de réinitialisation sera envoyé (affiché en dev).");
            return Page();
        }
    }
}
