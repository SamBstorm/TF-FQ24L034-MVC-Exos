using ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Handlers.Validations;

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

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            ModelState
                .ValidateRequired(form.Email, nameof(form.Email))
                .ValidateRequired(form.Password, nameof(form.Password))
                .ValidateLength(form.Email, nameof(form.Email), 3, 320)
                .ValidateLength(form.Password, nameof(form.Password), 8, 32)
                .ValidateNeedLowerCase(form.Password, nameof(form.Password))
                .ValidateNeedUpperCase(form.Password, nameof(form.Password))
                .ValidateNeedNumber(form.Password, nameof(form.Password))
                .ValidateNeedSymbol(form.Password, nameof(form.Password));
            if (ModelState.IsValid)
            {
                TempData["message"] = "Vous êtes connecté!";
                return RedirectToAction(nameof(Index),"Home");
            }
            ViewBag.errorMessage = "Données incorrectes!";
            return View();
        }
    }
}
