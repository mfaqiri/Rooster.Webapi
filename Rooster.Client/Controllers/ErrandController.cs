using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rooster.Storing

namespace Rooster.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrandController : ControllerBase
    {
        private UnitOfWork _unitOfWork { get; set; }

        public ErrandController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork
        }

        [HttpGet]
        public void Get()
        {
            return 'Hello'
        }
    }
}
