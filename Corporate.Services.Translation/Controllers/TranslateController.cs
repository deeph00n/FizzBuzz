using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Corporate.Services.Translation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslateController : ControllerBase
    {
        [HttpGet]
        public string Get(TranslationKey key)
        {
            switch (key)
            {
                case TranslationKey.Three:
                    return "Fizz";
                case TranslationKey.Five:
                    return "Buzz";
                case TranslationKey.Both:
                    return "FizzBuzz";
                default:
                    return "WTF";
            }
        }

        public enum TranslationKey
        {
            Three = 3,
            Five = 5,
            Both = 15
        }
    }
}
