using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Services.FizzBuzz.Services
{
    using System.Net.Http;
    using Behaviours;
    using Enums;
    using Interfaces;

    public class TranslationService : ITranslationService
    {
        private readonly StringFromUrl stringFromWeb;

        public TranslationService(StringFromUrl stringFromWeb)
        {
            this.stringFromWeb = stringFromWeb;
        }

        public string Translate(TranslationKey key)
        {
            return stringFromWeb.GetFrom(
                $"https://localhost:44338/translate?key={key}").Result;
        }
    }
}
