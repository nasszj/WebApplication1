using Microsoft.Data.SqlClient;
using WebApplication1.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StatistiekenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
