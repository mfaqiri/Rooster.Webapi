using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Rooster.Domain.Models;
using Rooster.Storing;

namespace Rooster.Client.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private UnitOfWork _unitOfWork { get; set; }
    public UserController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [EnableCors("MVC")]
    public ActionResult Get()
    {
      return Unauthorized();
    }

    [HttpPost]
    [EnableCors("MVC")]
    public ActionResult Add(User User)
    {
      if (User.Email == null)
      {
        return BadRequest("Email is required");
      }
      _unitOfWork.Users.Insert(User);
      _unitOfWork.Save();
      return Ok();
    }
  }
}
