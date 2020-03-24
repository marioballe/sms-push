using Newtonsoft.Json;
using Sms.Domain.Services;
using Sms.Provider.Models.NSR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Provider.Helpers
{
    public class CallWebRequest
    {
        private readonly IExceptionsService _exceptionsService;
        public CallWebRequest(IExceptionsService exceptionsService)
        {
            _exceptionsService = exceptionsService;
        }

        public async Task<NrsResult> SendRequestAsync(string urlProvider, string jsonMessage, string authorization)
        {
            try
            {
                var token = "Basic " + authorization;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                var httpContent = new StringContent(jsonMessage);

                var responseString = await client.PostAsync(urlProvider, httpContent);
                if (responseString.IsSuccessStatusCode) {
                    return new NrsResult {
                        IsSuccessStatusCode = responseString.IsSuccessStatusCode,
                    };
                }
                else
                {
                    NrsResult response = JsonConvert.DeserializeObject<NrsResult>(responseString.Content.ReadAsStringAsync().Result);
                    return response;
                }
            }
            catch (Exception e)
            {
                await _exceptionsService.Publish(e, "CallWebRequest", "SendRequestAsync");
                throw e;
            }
        }
    }
}
