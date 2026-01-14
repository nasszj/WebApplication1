using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BeloningsPotController : Controller
    {
        private readonly DatabaseHelper _db;

        public BeloningsPotController(DatabaseHelper db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var pot = _db.GetBeloningsPot();

            // Als pot null is, maak een lege BeloningsPot aan
            if (pot == null)
            {
                pot = new BeloningsPot
                {
                    Id = 0,
                    HuidigePunten = 0,
                    DoelPunten = 0,
                    Ronde = 0
                };
            }

            return View(pot);
        }
    }
}