using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Corporate.Services.FizzBuzz.Controllers
{
    using System.Net.Http;
    using Enums;
    using Interactions;
    using MediatR;
    using Models;
    using Newtonsoft.Json;
    using Services;

    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IMediator mediator;

        public FizzBuzzController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<string> Get(int value)
            => await mediator.Send(new TranslateFizzBuzz.Query {Value = value});

    }
}
