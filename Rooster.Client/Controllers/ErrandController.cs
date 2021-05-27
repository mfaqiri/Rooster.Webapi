using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Rooster.Domain.Models;
using Rooster.Storing;

namespace Rooster.Client.Controllers
{
  [ApiController]
  [Route("[controller]/{userId}")]
  public class ErrandController : ControllerBase
  {
    private UnitOfWork _unitOfWork { get; set; }
    private User _user { get; set; }

    public ErrandController(UnitOfWork unitOfWork, int userId)
    {
      _unitOfWork = unitOfWork;
      _user = _unitOfWork.Users.Select(u => u.EntityId == userId).First();
    }
    JsonSerializerOptions options = new()
    {
      ReferenceHandler = ReferenceHandler.Preserve,
      WriteIndented = true
    };

    [HttpGet]
    public string Get(int userId)
    {
      var errands = _unitOfWork.Errands.Select(e => e.User.EntityId == userId).ToList();
      return JsonSerializer.Serialize(errands, options);
    }

    [HttpPost]
    public ActionResult Add(Errand errand)
    {
      if (errand.Title == null || errand.ErrandStart == null)
      {
        return BadRequest();
      }
      errand.SetUser(_user);
      _unitOfWork.Errands.Insert(errand);
      _unitOfWork.Save();
      return Ok();
    }
  }
}
