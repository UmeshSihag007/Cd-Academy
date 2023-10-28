/*using Domain.Models.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public class EmailAppService : IEmailAppService
    {
        public Task<string> SendMessage(long fromNumber, long toNumber, string message)
        {
            try
            {
                RestClient   client = new RestClient();
                var request = new RestRequest("https://www.promessenger.in/api/Whatsappapi/send/message", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.Timeout = -1;


                request.AddBody(new { from = fromNumber.ToString(), to = toNumber.ToString(), message = message, apiKey = "f4f644f2ddb24ac5a9661b937715b195" });
                var response = client.ExecuteAsync(request);
                string content = response.Result.Content;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return "ok";
        }
    }
}
*/