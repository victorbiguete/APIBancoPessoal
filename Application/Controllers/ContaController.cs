using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIBanco.Application.Controllers
{
    public class ContaController : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }
    }
}
