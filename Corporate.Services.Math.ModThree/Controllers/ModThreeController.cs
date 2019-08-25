using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Corporate.Services.Math.ModThree.Controllers
{
    using System.Threading;

    [ApiController]
    [Route("[controller]")]
    public class ModThreeController : ControllerBase
    {
        [HttpGet]
        public bool Get(int value)
        {
            return value % 3 == 0;
        }
    }
}
