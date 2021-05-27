using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors;
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

    public ErrandController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    JsonSerializerOptions options = new()
    {
      ReferenceHandler = ReferenceHandler.Preserve,
      WriteIndented = true
    };

    [HttpGet]
    [EnableCors("MVC")]
    public string Get(int userId)
    {
      var schedule = _unitOfWork.Users.Select(u => u.EntityId == userId).First().schedule.ToList();
      return JsonSerializer.Serialize(schedule, options);
    }

    [HttpPost]
    [EnableCors("MVC")]
    public ActionResult Add(Errand errand, int userId)
    {
      if (_user == null)
      {
        _user = _unitOfWork.Users.Select(u => u.EntityId == userId).First();
      }
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
