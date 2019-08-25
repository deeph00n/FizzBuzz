using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Services.FizzBuzz.Behaviours
{
    using System.Net.Http;

    public class StringFromUrl
    {
        public async Task<string> GetFrom(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
