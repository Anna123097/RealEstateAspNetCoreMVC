using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Недвижимость.Models;

namespace Недвижимость.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        real_estates real_Estates = new real_estates();


      
            public IActionResult Index()
        {
            List<real_estate> listRealEstate1 = real_Estates.getGarajs();
            List<real_estate> listRealEstate2 = real_Estates.getDachs();
            List<real_estate> listRealEstate3 = real_Estates.getHouses();
            List<real_estate> listRealEstate4 = real_Estates.getKvartirs();
            List<real_estate> all = new List<real_estate>();
            all.AddRange(listRealEstate1);
            all.AddRange(listRealEstate2);
            all.AddRange(listRealEstate3);
            all.AddRange(listRealEstate4);
            return View( all);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}