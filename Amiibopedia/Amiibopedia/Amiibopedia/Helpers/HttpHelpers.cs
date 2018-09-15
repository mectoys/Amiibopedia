

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amiibopedia.Helpers
{

    //esta clase va a recibir un generico 
 public   class HttpHelpers<T>
    {
        #region Methods
        public async Task<T> GetRestServiceDataAsync(string serviceAddress)
        {
            //lo que hacemos de cualquier  resultado tipo rest lo
            //deserealizamos correcto de acuerdo al metodo indicado
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(serviceAddress);

            var response =
                await client.GetAsync(client.BaseAddress);

            response.EnsureSuccessStatusCode();
            //como esasyncrono
            var jsonResult =
               await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;


        } 
        #endregion
    }
}
