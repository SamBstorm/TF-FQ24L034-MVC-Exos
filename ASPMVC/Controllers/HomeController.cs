using ASPMVC.Models;
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
            Contact model = new Contact()
            {
                Address = new Address()
                {
                    Street = "Av. Jean Mermoz",
                    Number = "18",
                    ZipCode = 6100,
                    City = "Gosselies",
                    Country = "Belgique"
                },
                Phone = new PhoneNumber()
                {
                    Number = "071 25 49 60",
                    International = "+32"
                }
            };
            return View(model);
        }
    }
}
