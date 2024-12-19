using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; } = "Technofutur TIC";
        public IActionResult Index()
        {
            Title += " - Accueil";
            return View();
        }
        public IActionResult Contact()
        {
            Title += " - Nous Contacter";
            return View();
        }
    }
}
