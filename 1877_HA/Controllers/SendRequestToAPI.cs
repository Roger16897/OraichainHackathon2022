using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _1877_HA.Controllers
{
    public class SendRequestToAPI
    {
        public async System.Threading.Tasks.Task<string> GetExploitAPI(string baseUrl)
        {
            string output = "";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        output = await content.ReadAsStringAsync();
                    }
                }
            }

            return output;
        }
        public async System.Threading.Tasks.Task<string> PostExploitAPI(string baseUrl,string status,string user_id,string input_data,string ai_service_id,string ai_output_data,string ai_provider_id,string experts_output_data)
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "status", status },
                { "user_id", user_id },
                { "input_data", input_data },
                { "ai_service_id", ai_service_id },
                { "ai_output_data", ai_output_data },
                { "ai_provider_id", ai_provider_id },
                { "experts_output_data", experts_output_data },
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(baseUrl, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
        public async System.Threading.Tasks.Task<string> SendPostRequest(string url, string status, string user_id, string input_data, string ai_service_id, string ai_output_data, string ai_provider_id, string experts_output_data)
        {
            string data = "{\"status\":\"" + status +
               "\",\"user_id\":\"" + user_id +
               "\",\"input_data\":\"" + input_data +
               "\",\"ai_service_id\":\"" + ai_service_id +
               "\",\"ai_output_data\":\"" + ai_output_data +
               "\",\"ai_provider_id\":\"" + ai_provider_id +
               "\",\"experts_output_data\":\"" + experts_output_data +
               "\"}";
            string result = "";
            using (var stringContent = new StringContent(data, System.Text.Encoding.UTF8,
               "application/json"))
            using (var client = new HttpClient())
            {
                //Accept all server certificate
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                try
                {
                    using (var message = client.PostAsync(url, stringContent).Result)
                    {
                        result = await message.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public async System.Threading.Tasks.Task<string> addCustomerRequest(string url, string user_id, string input_data, string ai_service_id, string ai_output_data)
        {
            string data = "{\"user_id\":\"" + user_id +
               "\",\"input_data\":\"" + input_data +
               "\",\"ai_service_id\":\"" + ai_service_id +
               "\",\"ai_output_data\":\"" + ai_output_data +
               "\"}";
            string result = "";
            using (var stringContent = new StringContent(data, System.Text.Encoding.UTF8,
               "application/json"))
            using (var client = new HttpClient())
            {
                //Accept all server certificate
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                try
                {
                    using (var message = client.PostAsync(url, stringContent).Result)
                    {
                        result = await message.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public async System.Threading.Tasks.Task<string> addExpertResponse(string url, string expert_id, string input_data, string expert_output_data)
        {
            string data = "{\"expert_id\":\"" + expert_id +
               "\",\"input_data\":\"" + input_data +
               "\",\"expert_output_data\":\"" + expert_output_data +
               "\"}";
            string result = "";
            using (var stringContent = new StringContent(data, System.Text.Encoding.UTF8,
               "application/json"))
            using (var client = new HttpClient())
            {
                //Accept all server certificate
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                try
                {
                    using (var message = client.PostAsync(url, stringContent).Result)
                    {
                        result = await message.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }




        public async System.Threading.Tasks.Task<string> PostProcessDrawImage(string url, string service, string input)
        {
            string data = "{\"service\":\"" + service +
               "\",\"input\":\"" + input +
               "\"}";
            string result = "";
            using (var stringContent = new StringContent(data, System.Text.Encoding.UTF8,
               "application/json"))
            using (var client = new HttpClient())
            {
                //Accept all server certificate
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                try
                {
                    using (var message = client.PostAsync(url, stringContent).Result)
                    {
                        result = await message.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}