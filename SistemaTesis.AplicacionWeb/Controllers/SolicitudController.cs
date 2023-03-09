using Microsoft.AspNetCore.Mvc;

namespace SistemaTesis.AplicacionWeb.Controllers
{
    public class SolicitudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
