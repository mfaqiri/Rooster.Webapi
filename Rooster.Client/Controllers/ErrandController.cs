using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rooster.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrandController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {
            
        }
    }
}
