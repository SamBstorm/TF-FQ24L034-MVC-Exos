using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class AuthController : Controller
    {
        [ViewData]
        public string Title { get; set; } = "Accès Membres";
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Register()
        {
            Title += " - S'enregistrer";
            if (TempData.ContainsKey("message"))
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["message"] = "Vous êtes maintenant enregistré!";
                return View();
            }
        }
        public IActionResult Login()
        {
            Title += " - Se connecter";
            return View();
        }
    }
}
