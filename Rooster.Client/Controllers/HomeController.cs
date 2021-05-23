using Microsoft.AspNetCore.Mvc;

namespace Rooster.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {

    [HttpGet]
    public IActionResult Index()
    {
      return View("index");
    }
  }
}