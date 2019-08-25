using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Services.FizzBuzz.Services
{
    using System.Net.Http;
    using Behaviours;
    using Interfaces;
    using Models;
    using Newtonsoft.Json;

    public class ModService : IModService
    {
        private readonly StringFromUrl stringFromWeb;

        public ModService(StringFromUrl stringFromWeb)
        {
            this.stringFromWeb = stringFromWeb;
        }

        public Mods GetMods(int value)
        {
            Mods mods = new Mods();

            // run in parallel for better performance
            Task.WaitAll(
                Task.Run(async () =>
                {
                    mods.Three = await GetModFromUrl(
                        $"https://localhost:44384/modthree?value={value}").ConfigureAwait(false);
                }),
                Task.Run(async () =>
                {
                    mods.Five = await GetModFromUrl(
                        $"https://localhost:44305/modfive?value={value}").ConfigureAwait(false);
                })
            );

            return mods;
        }

        private async Task<bool> GetModFromUrl(string url)
        {
            return JsonConvert.DeserializeObject<bool>(
                await stringFromWeb.GetFrom(url).ConfigureAwait(false));
        }

        
    }
}
