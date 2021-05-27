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
  [Route("[controller]/{userEmail}")]
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
    public string Get(string userEmail)
    {
      var schedule = _unitOfWork.Users.Select(u => u.Email == userEmail).First().schedule.ToList();
      foreach (var errand in schedule)
      {
        errand.SetUser(null);
      }
      return JsonSerializer.Serialize(schedule, options);
    }

    [HttpPost]
    [EnableCors("MVC")]
    public ActionResult Add(Errand errand, string userEmail)
    {
      if (_user == null)
      {
        _user = _unitOfWork.Users.Select(u => u.Email == userEmail).First();
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
