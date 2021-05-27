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
    public string Get(int userId)
    {
      var errands = _unitOfWork.Errands.Select(e => e.User.EntityId == userId).ToList();
      return JsonSerializer.Serialize(errands, options);
    }
  }
}
