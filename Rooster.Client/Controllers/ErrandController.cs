using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rooster.Storing;
using System.Web.Http.Cors;

namespace Rooster.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors(origins: "rooster-mvc-app.azurewebsites.net", headers: "*", methods: "*")]
    public class ErrandController : ControllerBase
    {
        private UnitOfWork _unitOfWork { get; set; }

        public ErrandController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public string Get()
        {
            return "hello";
        }
    }
}
