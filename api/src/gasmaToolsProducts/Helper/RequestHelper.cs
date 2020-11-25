using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Helper
{
    public class RequestHelper : IRequestHelper
    {
        public async Task<ResponseModel> SendRequest(string url, string pass, string user)
        {
            const double timeout = 60;
            try
            {
                using var handler = new HttpClientHandler();
                using HttpClient http = new HttpClient(handler);
                var byteArray = Encoding.ASCII.GetBytes($"{user}:{pass}");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using var request = new HttpRequestMessage(HttpMethod.Post, url);
                //request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeout));
                using var result = await http.SendAsync(request, cts.Token).ConfigureAwait(false);
                if (result.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<ResponseModel>(result.Content.ReadAsStringAsync().Result);
                else
                    return await Task.FromResult(new ResponseModel() { Success = false, Error = "Não foi possivel autenticar" });
            }
            catch
            {
                return await Task.FromResult(new ResponseModel() { Success = false, Error = "Não foi possivel autenticar" });
            }
        }
    }
}
