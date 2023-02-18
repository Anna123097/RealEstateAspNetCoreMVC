using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Недвижимость.Models;

namespace Недвижимость.Controllers
{
    public class Real_estateController : Controller
    {
        real_estates real_Estates = new real_estates();


        public IActionResult Home()
        {
            List<real_estate> listRealEstate = real_Estates.getHouses();
            return View("RealEstate", listRealEstate);  
        }
        public IActionResult Kvartira()
        {
            List<real_estate> listRealEstate = real_Estates.getKvartirs();
            return View("RealEstate", listRealEstate);
        }
        public IActionResult Dacha()
        {
            List<real_estate> listRealEstate = real_Estates.getDachs();
            return View("RealEstate", listRealEstate);
        }
        public IActionResult Garaji()
        {
            List<real_estate> listRealEstate = real_Estates.getGarajs();
            return View("RealEstate", listRealEstate);

        }

        [Authorize]
        public IActionResult AddNewAdvt()
        {
            return View();
        }
        public void AddNewEstate(string name, string description, string price, string region, string view, string area, string comfort, bool site_availability)
        {

        }

        public IActionResult aboutTovar(int id) {


            foreach(var a in real_Estates.getHouses())
            {
                if(a.id==id)
                {
                    return View(a);
                }
            }
            foreach (var a in real_Estates.getKvartirs())
            {
                if (a.id == id)
                {
                    return View(a); 
                }
            }

            foreach (var a in real_Estates.getDachs())
            {
                if (a.id == id)
                {
                    return View(a);
                }
            }
            foreach (var a in real_Estates.getGarajs())
            {
                if (a.id == id)
                { 
                    return View(a); 
                }
            }

            return null;

        }
    }
}
